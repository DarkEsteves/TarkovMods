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

---
---

# 🇵🇹 Versão em Português

# 🛠️ KmyTarkovApi — Fix para SPT 4.0.13 (Correção de Freeze em PT/Outras Línguas)

[![License: GPL-3.0](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![SPT](https://img.shields.io/badge/SPT-4.0.13-green.svg)](https://www.sp-tarkov.com/)
[![EFT](https://img.shields.io/badge/EFT-0.16.9.40087-orange.svg)](https://www.escapefromtarkov.com/)

> ⚠️ **Este NÃO é o meu mod.** É uma build comunitária de correção de bug do mod original criado por **kmyuhkyuk**.
> Todo o crédito do mod vai para o autor original. Eu apenas apliquei um patch de correção de freeze e recompilei para **SPT 4.0.13**.

---

## 📌 O que é isto

O **KmyTarkovApi** é uma framework de configuração dentro do jogo para **Escape from Tarkov** (via SPT-AKI / SPT). Adiciona um menu de Configuration Manager acessível dentro do jogo e fornece a base (API) para mods como o **GamePanelHUD**.

Este repositório contém uma **build corrigida do KmyTarkovApi 1.5.0** que resolve um bug de freeze do jogo quando a língua não é inglês nem chinês.

---

## 👤 Autor original e onde ir buscar

| | |
|---|---|
| **Autor** | [kmyuhkyuk](https://github.com/kmyuhkyuk) |
| **Repositório original** | https://github.com/kmyuhkyuk/KmyTarkovApi |
| **Downloads oficiais** | https://github.com/kmyuhkyuk/KmyTarkovApi/releases |
| **Licença** | GPL-3.0 |

➡️ **Usa sempre o repositório/releases acima** para versões oficiais e atualizações. Usa esta build corrigida apenas se precisares especificamente do fix descrito abaixo.

---

## 🔧 Compatibilidade

| Componente | Versão |
|---|---|
| Escape from Tarkov | build `0.16.9.40087` (cliente correspondente ao SPT 4.0.13) |
| SPT | `4.0.13` |
| BepInEx | `5.4.x` (incluído no SPT 4.0.13) |
| GamePanelHUD | `3.4.0` (requer KmyTarkovApi ≥ 1.5.0) |

> ℹ️ As notas oficiais da 1.5.0 dizem "Compatible SPT-Aki 4.0.0". Esta build foi testada e compilada para **SPT 4.0.13** (EFT `0.16.9.40087`).

---

## 🐛 O bug que isto corrige

Na versão original **1.5.0**, quando a língua do jogo **não era inglês nem chinês**, o mod fazia uma pesquisa direta no dicionário (`LanguageNamesDictionary[gameLanguage]`). O cliente EFT passa a língua em **formato longo** (ex: `"Portuguese"`), mas o dicionário só tem chaves de 2 letras (`"pt"`, `"en"`, `"zh"`, ...). Isso lançava uma `KeyNotFoundException` **durante o loading** → o jogo travava antes de chegar ao menu principal.

Muitos utilizadores viram o erro *"KmyTarkovConfiguration.dll is configured to support only English and Chinese"*. Na realidade o código suporta **18 línguas** — o que faltavam eram os ficheiros de tradução para essas línguas. O **freeze em si** vinha do indexador frágil.

### ✅ Fix aplicado (`KmyTarkovConfiguration/Models/SettingsModel.cs`)

O método `SwitchLanguageFromGame` foi alterado para:
- **Normalizar** a língua do jogo (lowercase, trim, cortar para 2 letras: `"Portuguese" → "pt"`)
- Usar **`TryGetValue`** em vez de indexação direta (nunca lança exceção)
- **Fallback para `"En"`** se a língua não for encontrada

Isto resolve o freeze para **TODAS as línguas**, não só Português.

---

## 📦 O que há neste repo

```
KmyTarkovApi-SPT4.0.13-FixLang/
├── KmyTarkovApi/              # Source (patched)
├── KmyTarkovConfiguration/    # Source (patched — contém o fix)
├── KmyTarkovReflection/       # Source
├── KmyTarkovUtils/            # Source
├── ConfigurationTest/         # Source (projeto de teste)
├── KmyTarkovApi.sln          # Solution do Visual Studio
├── LICENSE                   # GPL-3.0 (do original)
├── PATCH_SwitchLanguageFromGame.txt   # O diff exato do fix
└── Build/
    └── kmyuhkyuk-KmyTarkovApi/        # ✅ Pasta do mod pronta a instalar
        ├── KmyTarkovApi.dll            (1.5.0, patched)
        ├── KmyTarkovConfiguration.dll  (1.5.0, patched)
        ├── KmyTarkovReflection.dll
        ├── KmyTarkovUtils.dll
        ├── Crc32.NET.dll               (dependência)
        ├── HtmlAgilityPack.dll         (dependência)
        ├── localized/  (en.json, zh.json)
        ├── bundles/    (kmytarkovconfiguration.bundle)
        └── README.md
```

---

## 🚀 Instalação

1. Fecha o jogo e o **SPT.Server**.
2. Copia a pasta `kmyuhkyuk-KmyTarkovApi` de dentro de `Build/` para:
   ```
   <pasta do SPT>\BepInEx\plugins\
   ```
   Resultado: `<pasta do SPT>\BepInEx\plugins\kmyuhkyuk-KmyTarkovApi\...`
3. Se já tiveres uma versão antiga, substitui (ou apaga a antiga primeiro).
4. Arranca o **SPT.Server** e o jogo normalmente.

---

## 📝 Notas

- Não precisas do GamePanelHUD para este mod funcionar, mas se o usares, mantém a **v3.4.0** (compatível com 1.5.0).
- A UI do mod aparece em **inglês por defeito** (só há traduções `en`/`zh` embutidas). Para mudar a língua da UI do mod: **F12 → configurações do KmyTarkovApi → Language**.
- Compilado com **Visual Studio Build Tools 2022** (MSBuild 17) + **.NET Framework 4.7.2 Targeting Pack**. Sem strong-name signing.
- **Licença:** GPL-3.0 (herdada do projeto original). Esta build é distribuída sob os mesmos termos.

---

## 🙏 Créditos

- **Mod e framework original:** [kmyuhkyuk](https://github.com/kmyuhkyuk/KmyTarkovApi) — *todo o crédito para o autor*
- **Fix de freeze (PT e outras línguas):** aplicado manualmente nesta build (não pelo autor original)
