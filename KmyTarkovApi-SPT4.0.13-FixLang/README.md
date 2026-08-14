# 🛠️ KmyTarkovApi — SPT 4.0.13 Fix (PT/Non-EN-ZH Freeze Patch)

[![License: GPL-3.0](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![SPT](https://img.shields.io/badge/SPT-4.0.13-green.svg)](https://www.sp-tarkov.com/)
[![EFT](https://img.shields.io/badge/EFT-0.16.9.40087-orange.svg)](https://www.escapefromtarkov.com/)

> ⚠️ **This is NOT my mod.** This is a community bug-fix build of the original mod by **kmyuhkyuk**.
> All credit for the mod goes to the original author. I only applied a freeze-fix patch and recompiled it for **SPT 4.0.13**.

---

## 📌 What this is

**KmyTarkovApi** is an in-game configuration framework for **Escape from Tarkov** (via SPT-AKI / SPT). It adds a Configuration Manager menu accessible inside the game, and provides the API backbone for mods like **GamePanelHUD**.

This repository contains a **patched build of KmyTarkovApi 1.5.0** that fixes a game-freezing bug when the game's language is anything other than English or Chinese.

---

## 👤 Original author & where to get it

| | |
|---|---|
| **Author** | [kmyuhkyuk](https://github.com/kmyuhkyuk) |
| **Original repo** | https://github.com/kmyuhkyuk/KmyTarkovApi |
| **Official releases** | https://github.com/kmyuhkyuk/KmyTarkovApi/releases |
| **License** | GPL-3.0 |

➡️ **Always prefer the original repo/releases above** for official versions and updates. Use this patched build only if you specifically need the fix described below.

---

## 🔧 Compatibility

| Component | Version |
|---|---|
| Escape from Tarkov | build `0.16.9.40087` (client matching SPT 4.0.13) |
| SPT | `4.0.13` |
| BepInEx | `5.4.x` (shipped with SPT 4.0.13) |
| GamePanelHUD | `3.4.0` (requires KmyTarkovApi ≥ 1.5.0) |

> ℹ️ The official 1.5.0 release notes say "Compatible SPT-Aki 4.0.0". This build was tested and compiled against **SPT 4.0.13** (EFT `0.16.9.40087`).

---

## 🐛 The bug this fixes

In the original **1.5.0**, when the game language was **not English or Chinese**, the mod did a direct dictionary lookup (`LanguageNamesDictionary[gameLanguage]`). The EFT client passes the language in **long format** (e.g. `"Portuguese"`), but the dictionary only has 2-letter keys (`"pt"`, `"en"`, `"zh"`, ...). That threw a `KeyNotFoundException` **during loading** → the game froze before reaching the main menu.

Many users saw the error *"KmyTarkovConfiguration.dll is configured to support only English and Chinese"*. In reality the code supports **18 languages** — what was missing were the translation files for those languages. The **freeze itself** came from the fragile indexer.

### ✅ Fix applied (`KmyTarkovConfiguration/Models/SettingsModel.cs`)

The `SwitchLanguageFromGame` method was changed to:
- **Normalize** the game language (lowercase, trim, truncate to 2 letters: `"Portuguese" → "pt"`)
- Use **`TryGetValue`** instead of direct indexing (never throws)
- **Fallback to `"En"`** if the language isn't found

This fixes the freeze for **ALL languages**, not just Portuguese.

---

## 📦 What's in this repo

```
KmyTarkovApi-SPT4.0.13-FixLang/
├── KmyTarkovApi/              # Source (patched)
├── KmyTarkovConfiguration/    # Source (patched — contains the fix)
├── KmyTarkovReflection/       # Source
├── KmyTarkovUtils/            # Source
├── ConfigurationTest/         # Source (test project)
├── KmyTarkovApi.sln          # Visual Studio solution
├── LICENSE                   # GPL-3.0 (from original)
├── PATCH_SwitchLanguageFromGame.txt   # The exact diff of the fix
└── Build/
    └── kmyuhkyuk-KmyTarkovApi/        # ✅ Ready-to-install mod folder
        ├── KmyTarkovApi.dll            (1.5.0, patched)
        ├── KmyTarkovConfiguration.dll  (1.5.0, patched)
        ├── KmyTarkovReflection.dll
        ├── KmyTarkovUtils.dll
        ├── Crc32.NET.dll               (dependency)
        ├── HtmlAgilityPack.dll         (dependency)
        ├── localized/  (en.json, zh.json)
        ├── bundles/    (kmytarkovconfiguration.bundle)
        └── README.md
```

---

## 🚀 Installation

1. Close the game and **SPT.Server**.
2. Copy the `kmyuhkyuk-KmyTarkovApi` folder from `Build/` into:
   ```
   <SPT folder>\BepInEx\plugins\
   ```
   Result: `<SPT folder>\BepInEx\plugins\kmyuhkyuk-KmyTarkovApi\...`
3. If you already have an older version, replace it (or delete the old one first).
4. Launch **SPT.Server** and the game normally.

---

## 📝 Notes

- You don't need GamePanelHUD for this mod to work, but if you use it, keep **v3.4.0** (compatible with 1.5.0).
- The mod UI shows in **English by default** (only `en`/`zh` translations are bundled). To change the mod's UI language: **F12 → KmyTarkovApi settings → Language**.
- Compiled with **Visual Studio Build Tools 2022** (MSBuild 17) + **.NET Framework 4.7.2 Targeting Pack**. No strong-name signing.
- **License:** GPL-3.0 (inherited from the original project). This build is distributed under the same terms.

---

## 🙏 Credits

- **Original mod & framework:** [kmyuhkyuk](https://github.com/kmyuhkyuk/KmyTarkovApi) — *all credit to the author*
- **Freeze fix (PT and other languages):** applied manually in this build (not by the original author)
