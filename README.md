# TarkovMods — SPT/EFT Mods Collection

> Curated collection of SPT/EFT mods with fixes, ports and quality-of-life improvements.

---

## 📋 Mods

| Mod | Version | SPT | Original Author | Description |
|-----|---------|-----|-----------------|-------------|
| **AmmoClarity** | 1.0.1-FixLang | 4.0.13 | [Jehree](https://github.com/Jehree/AmmoClarity) | Shortens ammo names + adds caliber info |
| **AmmoStats** | 1.3.2-FixLang | 4.0.13 | [Mattdokn](https://github.com/Mattdokn/AmmoStats) | Shows pen/damage stats in ammo names |
| **HideoutCat** | 1.1.2 | 4.0.13 | [bmpq](https://github.com/bmpq/spt-hideoutcat) | Cat companion for your hideout |
| **DayTimeCultists** | 1.2.0 | 4.0.13 | [p-kossa](https://github.com/p-kossa/SPT_DayTimeCultists) | Cultists only spawn at night |
| **KmyTarkovApi** | 1.5.0-FixLang | 4.0.13 | [kmyuhkyuk](https://github.com/kmyuhkyuk/KmyTarkovApi) | Tarkov API freeze fix (multi-lang) |
| **SPTMiniLauncher** | 3.9 | 4.0.13 | [Devraccoon](https://github.com/minihazel/SPTMiniLauncher) | Mini launcher for SPT |
| **CNN-Containers** | v4.4.0 | 4.0.13 | [Cannuccia](https://forge.sp-tarkov.com/user/16896/cannuccia) | Tiered storage containers + barter feature |
| **ConfigurableInventories** | 1.6.1 | 4.0.13 | [Harmer](https://forge.sp-tarkov.com/user/28568/harmer) | Configure sizes & filters of inventories |
| **GrenadeIndicator** | 1.0.0 | 4.0.13 | [Solarint](https://github.com/Solarint) | Visual indicator for thrown grenades |

---

## 🔫 AmmoClarity

Shortens ammo names and adds caliber info directly in the item name.

**Fixes in this version:**
- Now works with all game languages (PT, EN, etc.)
- Updated for SPT 4.0.13

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.0.1-SPT.4.0.13-FixLang-AmmoClarity/AmmoClarity-SPT4.0.13-LangFix.zip)

---

## 📊 AmmoStats

Displays ammunition penetration and damage stats directly in the item name.

**Fixes in this version:**
- Multi-lang support
- `InfoBeforeName` config fix
- Locale crash fix
- Updated for SPT 4.0.13

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.3.2-SPT.4.0.13-FixLang-AmmoStats/AmmoStats-1.3.1.zip)

---

## 🐱 HideoutCat

Full port of the Hideout Cat mod to SPT 4.0.13, with a batch of fixes and a fully configurable in-game settings menu (F12). The cat lives in your hideout: wanders between areas, sits, lies down, sleeps, eats, grooms, meows at you and can be petted.

**Fixes in this version:**
- Rebuilt from the 4.1.x version to work with the older 4.0.13 game code
- Fixed spawn placement (cat now spawns at a valid waypoint)
- Fixed "always busy" bug (cat never wandered or meowed)
- Fixed getting stuck in place
- Fixed footstep audio and timer
- Fixed meows cutting out
- Fixed meow/mouth sync
- Fixed cat clipping through furniture
- Added F12 configuration menu

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.1.2-SPT.4.0.13-HideoutCat/HideOutCat.SPT4.0.13-v1.1.2.zip)

---

## 🌙 DayTimeCultists

Adjusts cultist spawn behavior to only occur during nighttime hours.

**Features:**
- Night-only cultist spawns
- Configurable spawn window (default: 21:00 - 06:00)

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.2.0-SPT.4.0.13-DayTimeCultists/DayTimeCultists-v1.2.0.zip)

---

## 🔧 KmyTarkovApi

Tarkov API freeze fix for non-English languages.

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.5.0-SPT4.0.13-FixLang/KmyTarkovApi-SPT4.0.13-FixLang.zip)

---

## 🚀 SPTMiniLauncher

Mini launcher for SPT 4.0.13.

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v3.9-SPT-4.0.13/SPTMiniLauncher-SPT4.0.13.zip)

---

## 📦 CNN-Containers

Tiered storage containers for your hideout traders. This version adds a **configurable barter** feature — sell containers for items instead of money.

**What's new:**
- **Barter via config** — new `barterItems` field in container config
- **Multiple items together** — array of items required in a single trade
- **Any item as payment** — use any item ID (Graphic Card, Wire, CPU, etc.)
- **Fully optional** — configs without `barterItems` work exactly as before

**Containers:** Recycled Ammo Bag, Recycled FAK, Small Portable Fridge, Small Toolbox, Mod Case, Secure Mapbook, Ruined Wooden Box, Gear Box, Secure Container Onyx

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v4.4.0-SPT.4.0.13-CNN-Containers/CNN-Containers-v4.4.0.zip)

---

## 🎒 ConfigurableInventories

Configure sizes and filters of your backpacks, cases, plate carriers, pockets, rigs, and secure containers.

**What changed:**
- Full conversion from JavaScript (SPT 3.11+) to C# (SPT 4.0.13)
- Removed dependencies on removed JS APIs (VFS, etc.)
- Uses native SPT 4.0.13 APIs (`DatabaseService`, `ModHelper`, `ISptLogger`)

**Categories:** Backpacks, Cases, Plate Carriers, Pockets, Rigs, Secure Containers

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.6.1-SPT.4.0.13-ConfigurableInventories/ConfigurableInventories-1.6.1-SPT.4.0.13.zip)

---

## 💣 GrenadeIndicator

Visual indicator for thrown grenades. Shows a marker and trail for grenades in flight.

**What changed:**
- Converted from `SPT.Reflection.ModulePatch` (removed in SPT 4.0) to direct Harmony patches
- New SDK-style `net472` project with direct game DLL references
- Added proper cleanup with `OnDestroy()` / `UnpatchSelf()`

**Features:** 13 F12 configuration options, customizable colors, trails, sizes

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.0.0-SPT.4.0.13-GrenadeIndicator/GrenadeIndicator-SPT.4.0.13.zip)

---

## 📦 Installation

1. Download the release `.zip` for the mod you want
2. Extract into your `SPT root folder` (where `SPT.Server.exe` is located)
3. Launch SPT

---

## 🛠️ Building from Source

```bash
cd <ModName>
dotnet build -c Release
```

References resolve against `J:\Jogos\SPT-4.0.13` by default. Change `TarkovDir` in the csproj if needed.

---

## 📝 Credits

- **Jehree** — AmmoClarity original
- **Mattdokn** — AmmoStats original
- **bmpq** — HideoutCat original mod
- **bushtail** — HideoutCat SPT 4.1.x version
- **p-kossa** — DayTimeCultists original
- **kmyuhkyuk** — KmyTarkovApi original
- **Devraccoon** — SPTMiniLauncher original
- **Cannuccia** — CNN-Containers original mod
- **AMightyTank** — CNN-Containers SPT 3.11.X update
- **MrVibesRSA** — Secure Mapbook mod
- **Dsnyder** — Container-Onyx (Re-Upload)
- **Dildz** — CNN-Containers SPT 4.0.X port
- **Harmer** — ConfigurableInventories original mod
- **Solarint** — GrenadeIndicator original mod
- **DarkEsteves** — Ports, fixes, and original mods

---

## 📜 License

MIT License. See [LICENSE](LICENSE) for details.

This repository contains code from multiple authors with different licenses. Each mod folder retains its original license file. Please respect the original authors' licensing terms.
