# SamSWAT.FOV — SPT 4.0.13

> **Original mod by [SamSWAT](https://github.com/SamSWAT)** | Ported to SPT 4.0.13 by [DarkEsteves](https://github.com/DarkEsteves)

[![SPT 4.0.13](https://img.shields.io/badge/SPT-4.0.13-blue)](https://sp-tarkov.com)

---

## What is this?

A mod for SPT 4.0.13 that allows you to customize the in-game FOV (Field of View) beyond the normal limits, and adjust the camera position relative to your player body (horizontal/vertical HUD FOV).

---

## Installation

1. Download the latest release ZIP
2. Extract into your SPT directory
3. Restart the game

---

## Configuration

All settings are in the **F12 ConfigurationManager** menu:

| Setting | Default | Range | Description |
|---------|---------|-------|-------------|
| Min FOV Value | 20 | 1-149 | Minimum FOV clamp |
| Max FOV Value | 150 | 1-150 | Maximum FOV clamp |
| Horizontal HUD FOV | 0.05 | -0.1 to 0.1 | Camera offset horizontally (more negative = more hands/weapon visible) |
| Vertical HUD FOV | 0.05 | -0.1 to 0.1 | Camera offset vertically (more negative = arms/weapon move up) |

---

## What changed for SPT 4.0.13

| Area | Change |
|------|--------|
| **Target Framework** | net472 (.NET Framework 4.7.2) |
| **Harmony** | HarmonyLib (not Aki.Reflection) |
| **GameSettings class** | `GClass1085` (was `GClass1053` on SPT 3.x) |
| **Clamp class** | `GClass1085.Class1841` (was `GClass1053.Class1718`) |
| **Patch method** | `GameSettingsTab.Show` now takes `gameSettings` as parameter |
| **NumberSlider** | Uses `SettingsTab.BindNumberSliderToSetting()` (new API) |
| **PlayerSpring** | `CameraOffset` field now uses `ProceduralWeaponAnimation.HandsContainer` |

---

## Files

| File | Purpose |
|------|---------|
| `FovPlugin.cs` | Main plugin — config entries, patch initialization |
| `FovPatch.cs` | Patches `GameSettingsTab.Show` — applies FOV clamp to settings slider |
| `PlayerSpringPatch.cs` | Patches `PlayerSpring.Start` — applies camera offset |
| `SettingsApplierPatch.cs` | Patches `GClass1085.Class1841.method_0` — clamps FOV value |

---

## Build

```bash
dotnet build -c Release
```

Output: `Release/BepInEx/plugins/SamSWAT.FOV.dll`

---

## Credits

- **[SamSWAT](https://github.com/SamSWAT)** — original mod
- **[DarkEsteves](https://github.com/DarkEsteves)** — SPT 4.0.13 port

---

## License

This mod is licensed under the MIT License.
