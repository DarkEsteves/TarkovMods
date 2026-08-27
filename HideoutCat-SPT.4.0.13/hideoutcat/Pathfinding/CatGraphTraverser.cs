using System;
using System.Collections.Generic;
using EFT.Interactive;
using HideoutCat.Extensions;
using UnityEngine;

namespace HideoutCat.Pathfinding;

public class CatGraphTraverser : MonoBehaviour
{
    private static readonly int Thrust = Animator.StringToHash("Thrust");
    private static readonly int Turn = Animator.StringToHash("Turn");
    private static readonly int JumpingUp = Animator.StringToHash("JumpingUp");
    private static readonly int JumpingDown = Animator.StringToHash("JumpingDown");
    private static readonly int JumpingForward = Animator.StringToHash("JumpingForward");

    private Vector3 _prevPos;
    private Node? _currentNode;
    public List<Node>? currentPath;
    private int _currentPathIndex;

    private Animator? _animator;
    public Door[]? doors;

    private float _currentTurnVelocity;
    private float _currentThrustVelocity;
    private float _prevDistToDest;

    // Anti-stuck timer - if the cat hasn't moved closer to its destination for too long, abandon it
    private float _stuckTimer;
    private Vector3 _lastPosition;
    private const float STUCK_TIMEOUT = 1.5f;
    private float _jumpUpEndOffset = -0.5f;

    private Vector3 Velocity { get; set; }
    public float VelocityMagnitude => Velocity.magnitude / Time.deltaTime;
    public float DeltaY { get; private set; }

    private static Graph? PathfindingGraph => Plugin.CatGraph;

    public bool HasDestination => currentPath != null;

    public event Action<Node>? OnDestinationReached;
    public event Action<List<Node>>? OnNodeReached;
    public event Action? OnJumpAirEnd;

    public Door? DoorInTheWay { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        doors = FindObjectsByType<Door>(FindObjectsSortMode.None);
    }

    public void ForgetDestination()
    {
        _currentNode = null;
        currentPath = null;
    }

    public void LayNewPath(Node targetNode)
    {
        _currentNode ??= PathfindingGraph!.GetNodeClosestWaypoint(transform.position);

        currentPath = Graph.FindPathBFS(_currentNode, targetNode);
        _currentPathIndex = 0;

        if (currentPath == null)
        {
            Plugin.Log!.LogError($"No Path Found from {_currentNode} to {targetNode}");
        }
    }

    private void Update()
    {
        if (!_animator) { return; }

        if (currentPath == null || _currentPathIndex >= currentPath.Count)
        {
            TickMovement(0f, 0f);
            return;
        }

        var node = currentPath[_currentPathIndex];
        var isFinalNode = _currentPathIndex == currentPath.Count - 1;

        var stillMoving =
            Vector3.Distance(transform.position, node.position) >= 0.1f ||
            _animator!.GetBool(JumpingUp) ||
            _animator.GetBool(JumpingDown);

        if (stillMoving)
        {
            // Anti-stuck: check if we're making progress toward the destination
            if (Vector3.Distance(transform.position, _lastPosition) < 0.05f)
            {
                _stuckTimer += Time.deltaTime;
                if (_stuckTimer > STUCK_TIMEOUT)
                {
                    Plugin.Log!.LogWarning($"Cat stuck for {STUCK_TIMEOUT}s, recalculating path");
                    _stuckTimer = 0f;
                    _lastPosition = transform.position;
                    // Recalculate path instead of giving up
                    if (currentPath != null && _currentPathIndex < currentPath.Count)
                    {
                        var remainingPath = currentPath.GetRange(_currentPathIndex, currentPath.Count - _currentPathIndex);
                        currentPath = remainingPath;
                        _currentPathIndex = 0;
                    }
                    return;
                }
            }
            else
            {
                _stuckTimer = 0f;
            }
            _lastPosition = transform.position;

            return;
        }

        _stuckTimer = 0f;

        _currentNode = node;

        if (isFinalNode)
        {
            var angleDelta = Mathf.DeltaAngle(_currentNode.poseRotation, transform.eulerAngles.y);

            if (_currentNode.poseParameters.Count > 0 && Mathf.Abs(angleDelta) > 10f)
            {
                var turnDir = -Mathf.Sign(angleDelta);
                TickMovement(0f, turnDir);
                return;
            }

            _currentPathIndex++;
            var finalNode = currentPath[^1];
            currentPath = null!;

            Plugin.Log!.LogInfo("Reached final destination!");

            OnDestinationReached!.Invoke(finalNode);
        }
        else
        {
            _currentPathIndex++;
            Plugin.Log!.LogInfo("Set next node to: " + currentPath[_currentPathIndex].name);

            var remaining = new List<Node>();
            for (var i = _currentPathIndex; i < currentPath.Count; i++)
            {
                remaining.Add(currentPath[i]);
            }
            OnNodeReached!.Invoke(remaining);
        }
    }

    private void LateUpdate()
    {
        Velocity = transform.position - _prevPos;
        _prevPos = transform.position;

        if (currentPath == null || currentPath.Count == 0)
        {
            GroundSnap();
            return;
        }

        if (_currentPathIndex < currentPath.Count)
        {
            Locomotion();
        }
        else
        {
            var y = transform.position.y;
            var targetY = Mathf.Lerp(y, currentPath[^1].position.y, Time.deltaTime * 3f);
            transform.SetPositionIndividualAxis(null, targetY);
        }

        DeltaY = transform.position.y - currentPath[Mathf.Min(_currentPathIndex, currentPath.Count - 1)].position.y;
    }

    // 4.0.13: the node graph was authored for the 4.1 hideout layout. Furniture differs,
    // so direct transform movement can end up inside a box/table with no collider to stop it.
    // Snap to whatever surface is actually beneath/around the cat so it never clips through.
    private void GroundSnap()
    {
        // Don't snap if we're currently pathfinding — let Locomotion handle Y
        if (currentPath != null && currentPath.Count > 0 && _currentPathIndex < currentPath.Count)
        {
            return;
        }

        const int mask = ~0; // any solid geometry
        var origin = transform.position + Vector3.up * 0.3f;

        // Down first: keeps him glued to tables/floor he is legitimately standing on
        if (Physics.Raycast(origin, Vector3.down, out var hit, 2f, mask, QueryTriggerInteraction.Ignore))
        {
            var y = hit.point.y;
            if (Mathf.Abs(transform.position.y - y) > 0.05f)
            {
                // Only snap if the surface is within a reasonable distance (prevent teleporting through floors)
                if (hit.distance < 1.5f)
                {
                    transform.SetPositionIndividualAxis(null, Mathf.Lerp(transform.position.y, y, Time.deltaTime * 10f));
                }
            }

            // Also push horizontally out of walls: raycast forward at body height
            var fwd = transform.forward;
            if (Physics.Raycast(origin, fwd, out var wallHit, 0.35f, mask, QueryTriggerInteraction.Ignore))
            {
                var push = (transform.position - wallHit.point);
                push.y = 0f;
                if (push.sqrMagnitude > 0.0001f)
                {
                    transform.position += push.normalized * (Time.deltaTime * 1.5f);
                }
            }
            return;
        }

        // Nothing below within 2m — he is inside geometry; pull up toward nearest surface above
        if (Physics.Raycast(origin, Vector3.up, out var ceilHit, 1.5f, mask, QueryTriggerInteraction.Ignore))
        {
            transform.SetPositionIndividualAxis(null, Mathf.Lerp(transform.position.y, ceilHit.point.y + 0.35f, Time.deltaTime * 6f));
        }
    }

    private void TickMovement(float thrust, float turn)
    {
        if (!_animator) { return; }

        var smoothedThrust = Mathf.SmoothDamp(
            _animator!.GetFloat(Thrust),
            thrust,
            ref _currentThrustVelocity,
            0.3f
        );

        var smoothedTurn = Mathf.SmoothDamp(
            _animator.GetFloat(Turn),
            turn,
            ref _currentTurnVelocity,
            0.2f
        );

        _animator.SetFloat(Thrust, smoothedThrust);
        _animator.SetFloat(Turn, smoothedTurn);
    }

    private void Locomotion()
    {
        if (!_animator) { return; }

        var node = currentPath![_currentPathIndex];
        if (node == null) { throw new NullReferenceException(); }

        var targetPos = node.position;

        if (_animator!.GetBool(JumpingUp))
        {
            HandleJumpingUp();
            return;
        }

        if (_animator.IsInTransition(0))
        {
            var info = _animator.GetAnimatorTransitionInfo(0);

            if (info.IsName("JumpUpAir -> JumpUpEnd") ||
                info.IsName("JumpUpStart -> JumpUpEnd"))
            {
                var t = info.normalizedTime;
                var y = Mathf.Lerp(targetPos.y - _jumpUpEndOffset, targetPos.y, t);
                transform.SetPositionIndividualAxis(null, y);

                transform.position += transform.forward * (Time.deltaTime * (1f - t));
                return;
            }
        }

        if (_animator.GetBool(JumpingDown))
        {
            HandleJumpingDown();
            return;
        }

        if (_animator.GetBool(JumpingForward))
        {
            HandleJumpingForward();
            return;
        }

        var dir = (targetPos - transform.position).normalized;
        dir.y = 0f;

        var angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);
        var turn = angle.RemapClamped(-40f, 40f, -1f, 1f);
        var dist = Vector3.Distance(transform.position, targetPos);

        var thrust = ComputeThrust(node, angle, dist) * (Plugin.WalkSpeed != null ? Plugin.WalkSpeed.Value : 1f);

        // Ground check - prevent falling through objects
        var targetY = GetGroundHeightBelow(transform.position);
        var finalY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * 3f);
        
        transform.SetPositionIndividualAxis(
            null,
            finalY
        );

        if (_currentPathIndex == currentPath.Count - 1 && dist < 0.1f)
            return;

        DoorInTheWay = BlockedPathByDoor();
        if (DoorInTheWay)
        {
            thrust = 0f;
        }

        // Obstacle avoidance - disabled for now as it causes issues
        // var obstacleDir = AvoidObstacles(dir);
        // if (obstacleDir != dir)
        // {
        //     var avoidAngle = Vector3.SignedAngle(transform.forward, obstacleDir, Vector3.up);
        //     turn = avoidAngle.RemapClamped(-40f, 40f, -1f, 1f);
        //     thrust *= 1.5f;
        // }

        TickMovement(thrust, turn);
        _prevDistToDest = dist;
    }

    /// <summary>
    /// Gets the ground height below the cat using raycasts.
    /// Prevents the cat from falling through objects like tables.
    /// </summary>
    private float GetGroundHeightBelow(Vector3 position)
    {
        var origin = position + Vector3.up * 0.5f;
        
        // Check for ground below
        if (Physics.Raycast(origin, Vector3.down, out var hit, 3f, ~0, QueryTriggerInteraction.Ignore))
        {
            return hit.point.y;
        }
        
        // No ground found - return current position to prevent falling
        return position.y;
    }

    /// <summary>
    /// Checks for obstacles ahead and returns a direction to avoid them.
    /// Tries to climb low objects (chairs) and avoid high objects (walls).
    /// </summary>
    private Vector3 AvoidObstacles(Vector3 originalDir)
    {
        var origin = transform.position + Vector3.up * 0.15f;
        var checkDist = 0.5f;

        // Check forward
        if (Physics.Raycast(origin, originalDir, out var hit, checkDist, ~0, QueryTriggerInteraction.Ignore))
        {
            // Check if the obstacle is low enough to climb (like a chair or table)
            var obstacleTop = hit.point.y + hit.collider.bounds.extents.y;
            var heightDiff = obstacleTop - transform.position.y;
            
            if (heightDiff < 0.6f && heightDiff > -0.1f)
            {
                // Low/medium obstacle - try to climb it (jump up)
                _animator!.SetBool(JumpingUp, true);
                _animator.Update(0f);
                return originalDir;
            }
            
            // High obstacle - try to go around
            // Try left
            var leftDir = Quaternion.Euler(0, -45, 0) * originalDir;
            if (!Physics.Raycast(origin, leftDir, checkDist, ~0, QueryTriggerInteraction.Ignore))
                return leftDir;

            // Try right
            var rightDir = Quaternion.Euler(0, 45, 0) * originalDir;
            if (!Physics.Raycast(origin, rightDir, checkDist, ~0, QueryTriggerInteraction.Ignore))
                return rightDir;

            // Try diagonal left
            var diagLeft = Quaternion.Euler(0, -90, 0) * originalDir;
            if (!Physics.Raycast(origin, diagLeft, checkDist, ~0, QueryTriggerInteraction.Ignore))
                return diagLeft;

            // Try diagonal right
            var diagRight = Quaternion.Euler(0, 90, 0) * originalDir;
            if (!Physics.Raycast(origin, diagRight, checkDist, ~0, QueryTriggerInteraction.Ignore))
                return diagRight;
        }

        return originalDir;
    }

    private bool IsObstacleInPath(Vector3 dir)
    {
        var origin = transform.position + Vector3.up * 0.15f;
        var checkDistance = 0.4f;

        // Check forward at body height for obstacles
        if (Physics.Raycast(origin, dir, out var hit, checkDistance, ~0, QueryTriggerInteraction.Ignore))
        {
            // Check if the obstacle is tall enough to block the cat
            var obstacleTop = hit.point.y + hit.collider.bounds.extents.y;
            if (obstacleTop > transform.position.y + 0.1f)
            {
                return true;
            }
        }

        // Check if there's ground beneath the target position (prevent walking off edges)
        var targetOrigin = transform.position + dir * 0.3f + Vector3.up * 0.5f;
        if (!Physics.Raycast(targetOrigin, Vector3.down, 1.5f, ~0, QueryTriggerInteraction.Ignore))
        {
            // No ground ahead - don't move
            return true;
        }

        return false;
    }

    private float ComputeThrust(Node node, float angle, float dist)
    {
        var thrust = 1f;

        if (node.forwardJump && dist > 0.4f && Mathf.Abs(angle) < 7f)
        {
            _animator!.SetBool(JumpingForward, true);
            _animator.Update(0f);
            return 0f;
        }

        if (TargetIsAbove(node, angle))
        {
            _animator!.SetBool(JumpingUp, true);
            _animator.Update(0f);
            return 0f;
        }

        if (TargetIsBelow(node, angle))
        {
            _animator!.SetBool(JumpingDown, true);
            _animator.Update(0f);
            return 0f;
        }

        if (Mathf.Abs(angle) > 20f && dist < 0.5f)
            return 0f;

        if (!(Mathf.Abs(angle) < 30f)) { return thrust; }

        for (var i = _currentPathIndex; i < currentPath!.Count; i++)
        {
            var distance = Vector3.Distance(transform.position, currentPath[i].position);

            switch (distance)
            {
                case <= 3f:
                {
                    thrust = Mathf.Max(thrust, 1f);
                    break;
                }
                case <= 6f:
                {
                    thrust = Mathf.Max(thrust, 1.66f);
                    break;
                }
                case <= 8f:
                {
                    thrust = Mathf.Max(thrust, 2.55f);
                    break;
                }
                default:
                {
                    if (Mathf.Abs(angle) < 5f)
                    {
                        thrust = Mathf.Max(thrust, 3.6f);
                    }

                    break;
                }
            }
        }

        return thrust;
    }

    private bool TargetIsAbove(Node node, float angle)
    {
        return node.position.y > transform.position.y + 0.3f && Mathf.Abs(angle) < 10f;
    }

    private bool TargetIsBelow(Node node, float angle)
    {
        return node.position.y < transform.position.y - 0.3f && Mathf.Abs(angle) < 10f;
    }

    public bool IsMovement()
    {
        return !_animator ? throw new NullReferenceException("IsMovement") : _animator!.GetCurrentAnimatorStateInfo(0).IsName("Movement");
    }

    private Door? BlockedPathByDoor()
    {
        if (doors == null) { throw new NullReferenceException("BlockedPathByDoor"); }

        foreach (var door in doors)
        {
            if (!door || !door.gameObject.activeInHierarchy || door.DoorState == EDoorState.Open) { continue; }

            var dist = Vector3.Distance(door.transform.parent.position, transform.position);

            var dir = (door.transform.parent.position - transform.position).normalized;
            dir.y = 0f;

            var angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);

            if (dist < 2f && Mathf.Abs(angle) < 90f) { return door; }
        }

        return null;
    }

    private void HandleJumpingForward()
    {
        if (currentPath == null || !_animator) { return; }

        var node = currentPath[_currentPathIndex];
        if (!node.forwardJump) return;

        if (_animator!.GetFloat(Thrust) < 0.1f)
        {
            _animator!.SetBool(JumpingForward, false);
            _animator.Update(0f);
            return;
        }

        var targetPos = node.position;
        var t = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (t < 1f)
        {
            var y = Mathf.Lerp(transform.position.y, targetPos.y, Time.deltaTime * 5f);
            transform.SetPositionIndividualAxis(null, y);
            transform.position += transform.forward * (Time.deltaTime * 2f);
        }
        else
        {
            _animator!.SetBool(JumpingForward, false);
            _animator.Update(0f);
        }
    }

    private void HandleJumpingUp()
    {
        if (currentPath == null || !_animator) { return; }

        var node = currentPath[_currentPathIndex];

        if (_animator!.GetBool(JumpingUp) && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _animator!.SetBool(JumpingUp, false);
            _animator.Update(0f);
            transform.position = new Vector3(node.position.x, node.position.y, node.position.z);
        }
    }

    private void HandleJumpingDown()
    {
        if (currentPath == null || !_animator) { return; }

        var node = currentPath[_currentPathIndex];

        if (_animator!.GetBool(JumpingDown) && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _animator!.SetBool(JumpingDown, false);
            _animator.Update(0f);
            transform.position = new Vector3(node.position.x, node.position.y, node.position.z);
        }
    }
}