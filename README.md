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
- **DarkEsteves** — Ports, fixes, and original mods

---

## 📜 License

MIT License. See [LICENSE](LICENSE) for details.

This repository contains code from multiple authors with different licenses. Each mod folder retains its original license file. Please respect the original authors' licensing terms.
