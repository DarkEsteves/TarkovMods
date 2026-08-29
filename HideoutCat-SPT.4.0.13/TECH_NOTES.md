# HideoutCat Port — Technical Notes (Internal)

**Not for publication. Internal reference for explanation if questioned.**

---

## Context

Port of Hideout Cat (tarkin, SPT 4.1.x) to SPT 4.0.13 (EFT 0.16.9). The original project did not compile on 4.0.13 because BSG changed several APIs between versions. The work involved re-targeting method calls to the versions that exist in 4.0.13 and fixing behavioral changes that resulted from those API differences.

---

## Problems Found and Resolved

### 1. HideoutController API changed

**Problem:** In 4.1, `HideoutController` was accessed via a Singleton (`Singleton<HideoutController>.Instance`). In 4.0.13, that no longer exists — the instance is obtained through a patch on `HideoutAwake` that captures the `HideoutController` when the hideout initializes.

**Solution:** Created a patch on `HideoutAwake` that stores the instance in a static variable. All logic that needed the controller now uses that captured reference instead of the Singleton.

---

### 2. Hideout areas have a different structure

**Problem:** In 4.1, `HideoutController.Areas` returned objects with `AreaData.CurrentLevel` (an integer). In 4.0.13, `Areas` is a `Dictionary<EAreaType, HideoutArea>` and the level lives in `AreaLevels[]` — an array where the current level is the current element, not a direct integer.

**Solution:** Created a `GetAreaLevel()` method that resolves the level by doing `Array.IndexOf(AreaLevels, CurrentLevel)`. This returns the index (0 = not built, 1-3 = built levels) which is what the spawn logic needs.

---

### 3. Cat spawning in the wrong place

**Problem:** The cat spawned at the prefab origin (0,0,0) instead of at a valid graph waypoint.

**Solution:** Restored the original 4.1 logic — iterate unlocked areas, find dead-end nodes via `FindDeadEndNodesByAreaTypeAndLevel()`, and position the cat at the nearest waypoint to those nodes.

---

### 4. IsBusy() blocking all interaction

**Problem:** The original comparison counted `Idle`, `Sitting`, and `Lying` as "busy" states. Result: the cat never did nothing — it didn't wander, didn't meow, didn't interact.

**Solution:** Changed the logic so only `Sleeping`, `Eating`, and `Defecating` count as busy. All other states allow interaction and movement.

---

### 5. Footstep audio dragging

**Problem:** On 4.0.13, `BetterSource.Play()` requires an explicit `oneShot: true` parameter. Without it, footstep clips stacked into a continuous dragging noise.

**Solution:** Added `oneShot: true` on all `Play()` calls for footsteps and landings.

---

### 6. Footstep timer firing every frame

**Problem:** `_stepTimer` was not reset after playing a step, so it fired every frame instead of respecting the interval.

**Solution:** Added `_stepTimer = 0f` after each `PlayStep()` call.

---

### 7. Meows cutting out mid-play

**Problem:** Meows played on the shared `BetterAudio.AudioSourceGroupType.Character` pool. Since player movement sounds use the same pool, meows got cut off whenever the player moved.

**Solution:** Added a dedicated `AudioSource` on the cat's GameObject, used exclusively for meows and purrs. It is no longer competing with other sounds.

---

### 8. Audio/mouth sync

**Problem:** The meow played immediately on the animation trigger, but the cat's mouth takes ~0.1s to actually open. Result: sound before visual.

**Solution:** Delayed audio playback by ~0.1s via coroutine (`WaitForSeconds(0.1f)`) to line up with the mouth opening.

---

### 9. Cat clipping through furniture

**Problem:** The node graph was authored for the 4.1 hideout layout, which has different furniture than 4.0.13. The cat walked through tables and fell inside objects.

**Solution:**
- **Idle:** Added `GroundSnap()` which uses raycasts downward and sideways — keeps the cat on real surfaces and pushes it out of walls
- **Jumps:** Collision checks during `JumpingUp` and `JumpingDown` to land on real surfaces
- **Movement:** `GetGroundHeightBelow()` uses raycasts to find the actual ground beneath the cat and adjusts the Y position

---

### 10. Flashlight eye reaction removed

**Problem:** In 4.1, the cat reacted to the player's flashlight (pupils contracted). In 4.0.13, `CameraManager.Flashlight` is not accessible.

**Solution:** Feature removed — it was purely cosmetic. The eyes still have pupil dilation based on distance to the player.

---

### 11. Anti-stuck system

**Problem:** If the cat got stuck in a corner or trying to reach an unreachable node, it stayed there indefinitely.

**Solution:** Added a timer that checks whether the cat moved at least 0.05m in the last frame. If it doesn't move for 1.5s, the path is recalculated from the current node.

---

## Additional Notes

- The obstacle avoidance system was implemented but disabled because it caused unexpected behavior (cat going in circles instead of going around)
- The collision system is "best-effort" — in rare cases the cat may not perfectly respect solid objects
- Audio can occasionally desync slightly from the animation (difference of ~0.05-0.1s)
