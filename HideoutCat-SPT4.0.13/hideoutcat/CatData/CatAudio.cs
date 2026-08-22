using System;
using System.Diagnostics.CodeAnalysis;
using AssetBundleLoader;
using Comfort.Common;
using EFT.Ballistics;
using HideoutCat.Pathfinding;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HideoutCat.CatData;

public class CatAudio : MonoBehaviour
{
    private const float GroundRaycastDistance = 0.2f;
    private const int GroundLayerMask = 4096;

    private float _stepTimer;
    private MaterialType _lastPlayedMaterialType = MaterialType.Concrete; // original default = 5

    private AudioClip[]? _allClips;
    private BetterSource? _audioSource;
    private AudioSource? _ownSource;
    private CatGraphTraverser? _graphTraverser;

    private void Start()
    {
        _graphTraverser = GetComponent<CatGraphTraverser>();
        _graphTraverser.OnJumpAirEnd += GraphTraverser_OnJumpAirEnd;

        _allClips = BundleLoader.LoadAssetBundle("hideoutcat_audio")!.LoadAllAssets<AudioClip>();

        if (_allClips != null && _allClips.Length != 0) { return; }

        Plugin.Log!.LogError("CatAudio: No audio clips loaded from bundle!");
        enabled = false;
    }

    private void OnEnable()
    {
        _audioSource = Singleton<BetterAudio>.Instance.GetSource(BetterAudio.AudioSourceGroupType.Character);

        if (!_audioSource)
        {
            Debug.LogError("CatAudio: Could not get BetterAudio source.");
        }

        // Own 3D source for meows/purrs — immune to the shared pool being stolen
        _ownSource = gameObject.AddComponent<AudioSource>();
        _ownSource.playOnAwake = false;
        _ownSource.spatialBlend = 1f;
        _ownSource.minDistance = 1f;
        _ownSource.maxDistance = 10f;
        _ownSource.rolloffMode = AudioRolloffMode.Linear;
    }

    private void OnDisable()
    {
        if (_ownSource)
        {
            _ownSource!.Stop();
            Destroy(_ownSource);
            _ownSource = null;
        }

        if (_audioSource)
        {
            _audioSource!.Release();
        }
    }

    private void Update()
    {
        _audioSource!.Position = transform.position;

        if (Plugin.StepsEnabled != null && !Plugin.StepsEnabled.Value)
        {
            _stepTimer = 0f;
            return;
        }

        if (_graphTraverser!.VelocityMagnitude > 0.1f)
        {
            _stepTimer += Time.deltaTime;

            var speedNorm = Mathf.Clamp01(_graphTraverser.VelocityMagnitude / 3.6f);
            var stepInterval = Mathf.Lerp(0.5f, 0.1f, speedNorm);

            if (_stepTimer >= stepInterval && _graphTraverser.IsMovement())
            {
                // Reset BEFORE playing — without this every frame fires a new clip
                // and they stack into a continuous dragging noise
                _stepTimer = 0f;
                PlayStep();
            }
        }
        else
        {
            _stepTimer = 0f;
        }
    }

    public void Meow(EMeowType meowType)
    {
        if (_allClips == null) { return; }

        // Sync: the animator transition takes ~0.25s before the mouth actually opens,
        // so delay the clip slightly to line up with the visual
        StartCoroutine(MeowDelayed(meowType, 0.25f));
    }

    private System.Collections.IEnumerator MeowDelayed(EMeowType meowType, float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (meowType)
        {
            case EMeowType.Address:
            {
                PlayRandomClipByPrefix(_allClips, "cat_meow_look");
                break;
            }

            case EMeowType.Far:
            {
                PlayRandomClipByPrefix(_allClips, "cat_generic_meow");
                break;
            }

            case EMeowType.Exertion:
            {
                PlayRandomClipByPrefix(_allClips, "cat_meow_after_jump");
                break;
            }

            case EMeowType.Grumpy:
            {
                PlayRandomClipByPrefix(_allClips, "cat_meow_grumpy");
                break;
            }

            case EMeowType.Short:
            {
                PlayRandomClipByPrefix(_allClips, "cat_meow_ok");
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException(nameof(meowType), meowType, null);
            }
        }
    }

    public void Purr()
    {
        PlayRandomClipByPrefix(_allClips, "cat_purr");
    }

    public void PlayStep()
    {
        PlayMaterialSound("cat_walk_");
    }

    private void GraphTraverser_OnJumpAirEnd()
    {
        PlayMaterialSound("cat_land_");
        Meow(EMeowType.Exertion);
    }

    private void PlayMaterialSound(string prefix)
    {
        var groundMaterial = GetGroundMaterial();
        var clipPrefix = prefix + GetMaterialClipNamePrefix(groundMaterial);

        PlayRandomClipByPrefix(_allClips, clipPrefix);
        _lastPlayedMaterialType = groundMaterial;
    }

    private MaterialType GetGroundMaterial()
    {
        var down = GetMaterialFromRaycast(-transform.up);
        if (down.HasValue) { return down.Value; }

        return GetMaterialFromRaycast(transform.forward + new Vector3(0f, -0.1f, 0f)) ?? _lastPlayedMaterialType;
    }

    private MaterialType? GetMaterialFromRaycast(Vector3 direction)
    {
        if (!Physics.Raycast(
                transform.position,
                direction,
                out var hit,
                GroundRaycastDistance,
                GroundLayerMask,
                QueryTriggerInteraction.Ignore)) { return null; }

        if (hit.collider.gameObject.TryGetComponent(out BallisticCollider bc))
        {
            return bc.TypeOfMaterial;
        }

        return null;
    }

    [SuppressMessage("ReSharper", "SwitchStatementHandlesSomeKnownEnumValuesWithDefault")]
    private static string GetMaterialClipNamePrefix(MaterialType materialType)
    {
        switch (materialType)
        {
            case <= MaterialType.Plastic:
            {
                switch (materialType)
                {
                    case MaterialType.Asphalt:
                    case MaterialType.Concrete:
                    {
                        return "concrete";
                    }

                    case MaterialType.Chainfence:
                    case MaterialType.Fabric:
                    case MaterialType.GarbageMetal:
                    {
                        return "carpet";
                    }

                    case MaterialType.Cardboard:
                    {
                        return "cardboard";
                    }

                    case MaterialType.GarbagePaper:
                    {
                        return "garbage";
                    }

                    case MaterialType.GenericSoft:
                    {
                        return "paper";
                    }

                    default:
                    {
                        if (materialType != MaterialType.MetalThin && materialType != MaterialType.MetalThick)
                        {
                            return materialType == MaterialType.Plastic ? "plastic" : "carpet";
                        }

                        return "metal";
                    }
                }
            }
            case MaterialType.Tile:
            {
                return "tile";
            }
            case MaterialType.WoodThin or MaterialType.WoodThick:
            {
                return "wood";
            }
            default:
            {
                return materialType == MaterialType.MetalNoDecal ? "metal" : "carpet";
            }
        }
    }


    private void PlayRandomClipByPrefix(AudioClip[]? clips, string prefix)
    {
        if (clips == null) { return; }
        var matches = Array.FindAll(clips, clip => clip.name.StartsWith(prefix));

        if (matches.Length > 0)
        {
            var chosen = matches[Random.Range(0, matches.Length)];
            // Meows/purrs use the cat's OWN AudioSource — the shared Character pool
            // gets stolen by player movement sounds, cutting meows mid-play.
            if (prefix.StartsWith("cat_meow") || prefix.StartsWith("cat_generic_meow") || prefix.StartsWith("cat_purr"))
            {
                var vol = Plugin.MeowVolume != null ? Plugin.MeowVolume.Value : 1f;
                _ownSource!.PlayOneShot(chosen, vol);
            }
            else
            {
                // oneShot: true is required on 4.0.13 — without it BetterSource holds the
                // source and clips smear into a dragging noise
                var svol = Plugin.StepVolume != null ? Plugin.StepVolume.Value : 1f;
                _audioSource!.Play(chosen, null, 0f, svol, false, true);
            }
        }
        else
        {
            Plugin.Log!.LogWarning($"CatAudio: No clips found with prefix: {prefix}");
        }
    }
}