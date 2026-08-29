# TarkovMods — SPT/EFT Mods Collection

**Author:** DarkEsteves  
**SPT Version:** 4.0.13 (EFT 0.16.9)  
**License:** MIT

---

## 📋 Mods Overview

| Mod | Version | Original Author | Link | Description |
|-----|---------|-----------------|------|-------------|
| **AmmoClarity** | 1.0.1-SPT.4.0.13-FixLang | Jehree | [original](https://github.com/Jehree/AmmoClarity) | Shortens ammo names + adds caliber info |
| **AmmoStats** | 1.3.2-SPT.4.0.13-FixLang | Mattdokn | [original](https://github.com/Mattdokn/AmmoStats) | Shows pen/damage stats in ammo names |
|| **HideoutCat** | 1.1.1-SPT.4.0.13 | tarkin | [original](https://github.com/tarkin/spt-hideoutcat) | Cat companion for your hideout |
| **DayTimeCultists** | 1.2.0-SPT.4.0.13 | p-kossa | [original](https://github.com/p-kossa/SPT_DayTimeCultists) | Cultists only spawn at night |
| **KmyTarkovApi** | 1.5.0-SPT.4.0.13 | kmyuhkyuk | [original](https://github.com/kmyuhkyuk/KmyTarkovApi) | Tarkov API freeze fix (multi-lang) |
| **SPTMiniLauncher** | 3.9-SPT.4.0.13 | Devraccoon | [original](https://github.com/minihazel/SPTMiniLauncher) | Mini launcher for SPT |

---

## 🔧 Installation

1. Download the release `.zip` for the mod you want
2. Extract into `SPT root folder`
3. Launch SPT

---

## 📦 Releases

### AmmoClarity
- **v1.0.1-SPT.4.0.13-FixLang** — [Download](releases/latest/download/AmmoClarity-SPT4.0.13-LangFix.zip)
- **Original:** [Jehree/AmmoClarity](https://github.com/Jehree/AmmoClarity)
- **Fixes:** Now works with all game languages (PT, EN, etc.)
- **Source:** [AmmoClarity-SPT.4.0.13-FixLang/](AmmoClarity-SPT.4.0.13-FixLang/)

### AmmoStats
- **v1.3.2-SPT.4.0.13-FixLang** — [Download](releases/latest/download/AmmoStats-1.3.1.zip)
- **Original:** [Mattdokn/AmmoStats](https://github.com/Mattdokn/AmmoStats)
- **Fixes:** Multi-lang support, `InfoBeforeName` config fix, locale crash fix
- **Source:** [AmmoStats-SPT.4.0.13-FixLang/](AmmoStats-SPT.4.0.13-FixLang/)

### HideoutCat
- **v1.1.1-SPT.4.0.13** — [Download](releases/latest/download/HideOutCat.SPT4.0.13.zip)
- **Original:** [tarkin/spt-hideoutcat](https://github.com/tarkin/spt-hideoutcat)
- **Fixes:** Full 4.0.13 port, audio sync, collision fixes, anti-stuck, F12 menu
- **Source:** [HideoutCat-SPT.4.0.13/](HideoutCat-SPT.4.0.13/)

### DayTimeCultists
- **v1.2.0-SPT.4.0.13** — [Download](releases/latest/download/DayTimeCultists-v1.2.0.zip)
- **Original:** [p-kossa/SPT_DayTimeCultists](https://github.com/p-kossa/SPT_DayTimeCultists)
- **Features:** Night-only cultist spawns, configurable hours
- **Source:** [DayTimeCultists-SPT.4.0.13/](DayTimeCultists-SPT.4.0.13/)

### KmyTarkovApi
- **v1.5.0-SPT.4.0.13** — Freeze fix for non-English languages
- **Original:** [kmyuhkyuk/KmyTarkovApi](https://github.com/kmyuhkyuk/KmyTarkovApi)
- **Source:** [KmyTarkovApi-SPT.4.0.13-FixLang/](KmyTarkovApi-SPT.4.0.13-FixLang/)

### SPTMiniLauncher
- **v3.9-SPT.4.0.13** — Mini launcher for SPT 4.0.13
- **Original:** [Devraccoon](https://forge-alt.katrinfoxvr.com/users/Devraccoon) / [minihazel/SPTMiniLauncher](https://github.com/minihazel/SPTMiniLauncher)
- **Source:** [SPTMiniLauncher-SPT.4.0.13/](SPTMiniLauncher-SPT.4.0.13/)

---

## 🛠️ Building from Source

```bash
cd <ModName>
dotnet build -c Release
```

References resolve against `J:\Jogos\SPT-4.0.13` by default. Change `TarkovDir` in the csproj if needed.

---

## 📝 License Notice

This repository contains code from multiple authors with different licenses:

- **AmmoClarity, AmmoStats, HideoutCat, DayTimeCultists, KmyTarkovApi** — MIT License
- **SPTMiniLauncher** — GPL-3.0 (original author: Devraccoon)
- **My own mods/fixes** — MIT License

Each mod folder retains its original license file. Please respect the original authors' licensing terms.

---

## 📝 Credits

- **Jehree** — AmmoClarity original
- **Mattdokn** — AmmoStats original
- **tarkin** — HideoutCat original mod
- **bushtail** — HideoutCat SPT 4.1.x version
- **p-kossa** — DayTimeCultists original
- **kmyuhkyuk** — KmyTarkovApi original
- **Devraccoon** — SPTMiniLauncher original
- **DarkEsteves** — Ports, fixes, and original mods

---

## 📜 License

MIT License. See [LICENSE](LICENSE) for details.
