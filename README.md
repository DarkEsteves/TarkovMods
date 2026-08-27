# TarkovMods — SPT/EFT Mods Collection

**Author:** DarkEsteves  
**SPT Version:** 4.0.13 (EFT 0.16.9)  
**License:** MIT

---

## 📋 Mods Overview

| Mod | Version | Original Author | Description |
|-----|---------|-----------------|-------------|
| **AmmoClarity** | 1.0.1 | Jehree | Shortens ammo names + adds caliber info |
| **AmmoStats** | 1.3.2 | Mattdokn | Shows pen/damage stats in ammo names |
| **HideoutCat** | 1.1.2 | bushtail | Cat companion for your hideout |
| **DayTimeCultists** | 1.2.0 | DarkEsteves | Cultists only spawn at night |
| **KmyTarkovApi** | 1.5.0 | — | Tarkov API freeze fix (multi-lang) |
| **SPTMiniLauncher** | 3.9 | — | Mini launcher for SPT |

---

## 🔧 Installation

1. Download the release `.zip` for the mod you want
2. Extract into `SPT/`
3. Launch SPT

---

## 📦 Releases

### AmmoClarity
- **v1.0.1** — [Download](releases/latest/download/AmmoClarity-SPT4.0.13-LangFix.zip)
- **Fixes:** Now works with all game languages (PT, EN, etc.)
- **Source:** [AmmoClarity/](AmmoClarity/)

### AmmoStats
- **v1.3.2** — [Download](releases/latest/download/AmmoStats-1.3.1.zip)
- **Fixes:** Multi-lang support, `InfoBeforeName` config fix, locale crash fix
- **Source:** [AmmoStats/](AmmoStats/)

### HideoutCat
- **v1.1.2** — [Download](releases/latest/download/HideOutCat.SPT4.0.13.zip)
- **Fixes:** Full 4.0.13 port, audio sync, collision fixes, anti-stuck, F12 menu
- **Source:** [HideoutCat-SPT4.0.13/](HideoutCat-SPT4.0.13/)

### DayTimeCultists
- **v1.2.0** — [Download](releases/latest/download/DayTimeCultists-v1.2.0.zip)
- **Features:** Night-only cultist spawns, configurable hours
- **Source:** (included in release)

### KmyTarkovApi
- **v1.5.0** — Freeze fix for non-English languages
- **Source:** [KmyTarkovApi-SPT4.0.13-FixLang/](KmyTarkovApi-SPT4.0.13-FixLang/)

### SPTMiniLauncher
- **v3.9** — Mini launcher for SPT 4.0.13
- **Source:** [SPTMiniLauncher-SPT4.0.13/](SPTMiniLauncher-SPT4.0.13/)

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
- **bushtail** — HideoutCat original
- **DarkEsteves** — Ports, fixes, and original mods

---

## 📜 License

MIT License. See [LICENSE](LICENSE) for details.
