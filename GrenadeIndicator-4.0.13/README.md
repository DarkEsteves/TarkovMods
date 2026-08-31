# GrenadeIndicator — SPT 4.0.13

> **Original mod by [Solarint](https://github.com/Solarint)** | Ported to SPT 4.0.13 by [DarkEsteves](https://github.com/DarkEsteves)

[![SPT 4.0.13](https://img.shields.io/badge/SPT-4.0.13-blue)](https://sp-tarkov.com)

---

## What is this?

A port of **Grenade Indicator** from SPT 3.x to SPT 4.0.13. The original mod used `SPT.Reflection.Patching.ModulePatch`, which was **removed in SPT 4.0**. This version replaces the patching system with direct Harmony patches.

---

## Installation

1. Download the latest release ZIP
2. Extract `Solarint-GrenadeIndicator.dll` into `BepInEx/plugins/`
3. Restart the game

---

## What Changed

| Area | Before (SPT 3.x) | After (SPT 4.0.13) |
|------|------------------|---------------------|
| Patching | `SPT.Reflection.ModulePatch` | `[HarmonyPatch]` direct |
| Plugin init | `new Patch().Enable()` | `Harmony.PatchAll()` |
| Cleanup | None | `OnDestroy()` with `UnpatchSelf()` |
| Logger | `ModulePatch` logger | `Plugin.Log` (BepInEx standard) |
| .csproj | Legacy format | SDK-style `net472` |

### What Stayed the Same

- All EFT/Unity logic (grenade tracking, components, GUI, gizmos)
- All 13 F12 ConfigurationManager options
- `TrackedGrenade`, `GrenadeIndicatorComponent`, `DebugGizmos`, `GUIObject`, `StyleState`, `ApplyToStyle`

---

## Build

```bash
dotnet build -c Release
```

Output: `bin/Release/net472/Solarint-GrenadeIndicator.dll`

---

## Credits

- **[Solarint](https://github.com/Solarint)** — original Grenade Indicator mod
- **[DarkEsteves](https://github.com/DarkEsteves)** — SPT 4.0.13 port, Harmony conversion

---

## License

This mod is licensed under the MIT License.
