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
| **SamSWAT.FOV** | 1.0.6 | 4.0.13 | [SamSWAT](https://github.com/SamSWAT) | Custom FOV clamp + camera position adjustment |
| **SPTVRAMCleaner** | 1.1.0 | 4.0.13 | [Matsix](https://github.com/Matsix/SPTVRAMCleaner) | VRAM/RAM cleaner — auto, periodic & manual |
|| **SPT-RamCleanerInterval** | 1.0.0 | 4.0.13 | [CactusPie](https://github.com/CactusPie) | Customizable RAM cleaner interval (30-900s) |
|| **WTT-CornerStore** | 1.1.0 | 4.0.13 | [RockaHorse](https://github.com/RockaHorse) | Le Cheff food & drink trader + 50+ items |

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

## 🎯 SamSWAT.FOV

Customize your FOV (Field of View) beyond normal limits and adjust camera position relative to your player body.

**Features:**
- FOV clamp customization (min: 1, max: 150)
- Horizontal HUD camera offset (more negative = more hands/weapon visible)
- Vertical HUD camera offset (more negative = arms/weapon move up)
- F12 ConfigurationManager integration

**Changes for SPT 4.0.13:**
- Updated to `GClass1085` (was `GClass1053` on SPT 3.x)
- HarmonyLib instead of Aki.Reflection
- New `SettingsTab.BindNumberSliderToSetting()` API

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.0.6-SPT.4.0.13-SamSWAT.FOV/SamSWAT.FOV-v1.0.6-SPT.4.0.13.zip)

---

## 🧹 SPTVRAMCleaner

VRAM/RAM cleaner for SPT 4.0.13. Frees unused memory automatically on raid start, raid exit, on a configurable periodic interval, or via a manual hotkey — freeing ~1–2 GB of VRAM.

**Features:**
- Clean on raid start (after countdown finishes)
- Clean on raid exit (when world is destroyed)
- Periodic cleaning during raid (configurable: 1–120 minutes)
- Manual hotkey (default: `Keypad0`, configurable)
- Full F12 ConfigurationManager integration
- Verbose diagnostics option for debugging

**Note:** Expect a small lag spike at the moment of cleaning — this is normal as the game frees memory.

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.1.0-SPT.4.0.13-SPTVRAMCleaner/SPTVRAMCleaner-v1.1.0-SPT.4.0.13.zip)

---

## 🧹 SPT-RamCleanerInterval

Customizable RAM cleaner interval for SPT 4.0.13. Allows you to override the default RAM cleaner execution interval (30-900 seconds), with options to run only in raid and trigger manual cleaning via a button in F12.

**Features:**
- Custom interval: 30-900 seconds (default: 300)
- "Clean now" button in F12 menu
- Only-in-raid toggle
- Uses `EmptyWorkingSet` Windows API to free memory

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/SPT-RamCleanerInterval-v1.0.0-SPT.4.0.13/SPT-RamCleanerInterval-v1.0.0-SPT.4.0.13.zip)

---

## 🍔 WTT-CornerStore

Adds **Le Cheff**, a culinary trader selling food and drink items. Includes 50+ custom consumables: Coca-Cola, Red Bull (12+ flavors), Four Loko (20+ flavors), beer, whiskey, Doritos, Cheetos, Funyuns, posters, and more. Each item has unique buffs and effects.

**Features:**
- Le Cheff trader with configurable prices, stock, and buy restrictions
- 50+ items with custom buffs (stamina, health, skills, weight limit, etc.)
- Items spawn in loot containers (jackets, duffles, safes)
- Config.json for easy customization

**Items:** Water, Coca-Cola, Dr Pepper, Sprite, Red Bull (12 flavors), Bud Light, Heineken, Stella Artois, RockaHorse LSD Energy Beer, Bourbon Whiskey, Jägermeister, Four Loko (20+ flavors), Doritos, Cheetos, Funyuns, THC Gummies, Posters

📥 [Download](https://github.com/DarkEsteves/TarkovMods/releases/download/v1.1.0-SPT.4.0.13-WTT-CornerStore/WTT-CornerStore-v1.1.0-SPT.4.0.13.zip)

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
- **SamSWAT** — SamSWAT.FOV original mod
- **Matsix** — SPTVRAMCleaner original mod
- **CactusPie** — SPT-RamCleanerInterval original mod
- **RockaHorse** — WTT-CornerStore original mod
- **DarkEsteves** — Ports, fixes, and original mods

---

## 📜 License

MIT License. See [LICENSE](LICENSE) for details.

This repository contains code from multiple authors with different licenses. Each mod folder retains its original license file. Please respect the original authors' licensing terms.
