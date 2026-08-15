# 🛠️ SPTMiniLauncher — SPT 4.0.13 Port

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![SPT](https://img.shields.io/badge/SPT-4.0.13-green.svg)](https://www.sp-tarkov.com/)
[![EFT](https://img.shields.io/badge/EFT-0.16.9.40087-orange.svg)](https://www.escapefromtarkov.com/)

> ⚠️ **This is NOT my mod.** This is a fork of the original [SPTMiniLauncher](https://github.com/minihazel/SPTMiniLauncher) by **minihazel**.
> All credit goes to the original author. I only ported it to **SPT 4.0+** and recompiled it, because the original targets SPT 3.x.

---

## 📌 What this is

**SPTMiniLauncher** is an overhauled launcher + mini mod manager for **SPT** (Single Player Tarkov). It handles launching the server/launcher, profile selection, cache clearing, shortcuts to mods/database folders, a control panel, and small-scale mod management.

This fork ports it to **SPT 4.0+**, whose install layout and data paths differ from SPT 3.x (which the original was built for). The original's hardcoded `SPT_Data\Server\...` probes fail silently on SPT 4.0, so clicking an install showed **no options panel** — this fork fixes that and a few other 4.0 incompatibilities.

---

## 👤 Original author & where to get it

| | |
|---|---|
| **Author** | [minihazel](https://github.com/minihazel) |
| **Original repo** | https://github.com/minihazel/SPTMiniLauncher |
| **License** | MIT (inherited from the original) |

➡️ **Always prefer the original repo** for official versions and updates. Use this fork only if you need it running on **SPT 4.0+**.

---

## 🔧 Compatibility

| Component | Version |
|---|---|
| SPT | `4.0.13` |
| Escape from Tarkov | build `0.16.9.40087` (client matching SPT 4.0.13) |
| BepInEx | `5.4.x` (shipped with SPT 4.0.13) |
| Build toolchain | .NET SDK 9 (no Visual Studio / Build Tools required) |

> ℹ️ The original targets SPT 3.x. This build was compiled and tested against **SPT 4.0.13** (EFT `0.16.9.40087`).

---

## 🐛 What was changed (and why)

### 1. SPT 4.0 path detection — `SPT_Data` lost the `Server` subfolder
The original probes `SPT_Data\Server\configs\core.json` and `SPT_Data\Server\database\server.json`. SPT 4.0 removed the `Server` subfolder, so those probes returned `false` and `useInstall(...)` silently skipped `listServerOptions(...)` → **clicking an install showed no options panel, with no error**.

Fixed all three probe sites (drop the `Server` level):
- `useInstall` core.json chain → `SPT_Data\configs\core.json`
- port/IP detection → `SPT_Data\database\server.json`
- `CheckServerWorker` port path → `SPT_Data\database\server.json`

### 2. Client mods (BepInEx) live at the install root
In SPT 4.0 the `BepInEx\plugins` folder sits **one level above** `server_path` (at the install root), not inside it. The "Open client mods" / modlist handlers now fall back to `server_path\..\BepInEx\plugins` when the direct path doesn't exist.

### 3. "Open profiles" is more reliable
Switched to `Process.Start("explorer.exe", profilesFolder)` instead of `Process.Start(folderPath)` with `Verb="open"`.

### 4. "Open modloader JSON" → "Open Root"
`order.json` no longer exists in SPT 4.0, so the old button pointed at a dead file. It's now **"Open Root"** and opens the install root folder.

### 5. Auto-open the official launcher when the server starts
When the server finishes loading, the official `SPT.Launcher.exe` opens automatically so you can hit "Play" without hunting for it.

### 6. Build without Visual Studio
The project was rewritten to an **SDK-style `net48`** `.csproj`, so it builds with the .NET 9 SDK alone (no VS / MSBuild Build Tools needed).

---

## 🧱 Building from source

```bash
git clone https://github.com/DarkEsteves/SPTMiniLauncher.git
cd SPTMiniLauncher
dotnet build -c Release
```

The output lands in `bin/Release/net48/` — run `SPT Launcher.exe`.

> Requires the .NET SDK (9.x). On Windows with a system `dotnet`, use `"/c/Program Files/dotnet/dotnet.exe" build -c Release`.

---

## ⚖️ License

MIT — inherited from the [original project](https://github.com/minihazel/SPTMiniLauncher). This fork adds no additional restrictions.

---

---

# 🛠️ SPTMiniLauncher — Port para SPT 4.0.13

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![SPT](https://img.shields.io/badge/SPT-4.0.13-green.svg)](https://www.sp-tarkov.com/)
[![EFT](https://img.shields.io/badge/EFT-0.16.9.40087-orange.svg)](https://www.escapefromtarkov.com/)

> ⚠️ **Isto NÃO é o meu mod.** É um fork do [SPTMiniLauncher](https://github.com/minihazel/SPTMiniLauncher) original do **minihazel**.
> Todo o crédito vai para o autor original. Eu só o portei para **SPT 4.0+** e recompilei, porque o original foi feito para SPT 3.x.

---

## 📌 O que é

O **SPTMiniLauncher** é um launcher + mini gestor de mods para **SPT** (Single Player Tarkov). Trata de lançar o servidor/launcher, seleção de perfil, limpar cache, atalhos para as pastas de mods/banco de dados, um painel de controlo e gestão simples de mods.

Este fork porta-o para **SPT 4.0+**, cujo layout de instalação e caminhos de dados diferem do SPT 3.x (para o qual o original foi feito). As probes `SPT_Data\Server\...` do original falham silenciosamente no SPT 4.0 — por isso clicar numa instalação **não mostrava o painel de opções** — este fork corrige isso e mais algumas incompatibilidades do 4.0.

---

## 👤 Autor original & onde obter

| | |
|---|---|
| **Autor** | [minihazel](https://github.com/minihazel) |
| **Repo original** | https://github.com/minihazel/SPTMiniLauncher |
| **Licença** | MIT (herdada do original) |

➡️ **Prefere sempre o repo original** para versões e atualizações oficiais. Usa este fork só se precisares dele a correr em **SPT 4.0+**.

---

## 🔧 Compatibilidade

| Componente | Versão |
|---|---|
| SPT | `4.0.13` |
| Escape from Tarkov | build `0.16.9.40087` (cliente correspondente ao SPT 4.0.13) |
| BepInEx | `5.4.x` (incluído no SPT 4.0.13) |
| Toolchain de build | .NET SDK 9 (sem Visual Studio / Build Tools) |

> ℹ️ O original aponta para SPT 3.x. Este build foi compilado e testado contra **SPT 4.0.13** (EFT `0.16.9.40087`).

---

## 🐛 O que mudou (e porquê)

### 1. Deteção de caminhos SPT 4.0 — o `SPT_Data` perdeu a subpasta `Server`
O original procura `SPT_Data\Server\configs\core.json` e `SPT_Data\Server\database\server.json`. O SPT 4.0 removeu a subpasta `Server`, por isso essas probes davam `false` e o `useInstall(...)` saltava silenciosamente o `listServerOptions(...)` → **clicar numa instalação não mostrava o painel de opções, sem qualquer erro**.

Corrigidos os três pontos de probe (remover o nível `Server`):
- cadeia `core.json` do `useInstall` → `SPT_Data\configs\core.json`
- deteção de porta/IP → `SPT_Data\database\server.json`
- caminho da porta do `CheckServerWorker` → `SPT_Data\database\server.json`

### 2. Os mods do cliente (BepInEx) ficam na raiz da instalação
No SPT 4.0 a pasta `BepInEx\plugins` fica **um nível acima** de `server_path` (na raiz da instalação), não dentro dela. Os handlers "Open client mods" / modlist agora têm fallback para `server_path\..\BepInEx\plugins` quando o caminho direto não existe.

### 3. "Open profiles" mais fiável
Passou a usar `Process.Start("explorer.exe", profilesFolder)` em vez de `Process.Start(folderPath)` com `Verb="open"`.

### 4. "Open modloader JSON" → "Open Root"
O `order.json` já não existe no SPT 4.0, por isso o botão antigo apontava para um ficheiro morto. Agora chama-se **"Open Root"** e abre a pasta raiz da instalação.

### 5. Abrir o launcher oficial automaticamente quando o servidor arranca
Quando o servidor acaba de carregar, o `SPT.Launcher.exe` oficial abre automaticamente, para carregares em "Play" sem teres de o procurar.

### 6. Build sem Visual Studio
O projeto foi reescrito para um `.csproj` **SDK-style `net48`**, para compilar só com o .NET 9 SDK (sem VS / MSBuild Build Tools).

---

## 🧱 Compilar a partir do source

```bash
git clone https://github.com/DarkEsteves/SPTMiniLauncher.git
cd SPTMiniLauncher
dotnet build -c Release
```

O output fica em `bin/Release/net48/` — corre `SPT Launcher.exe`.

> Requer o .NET SDK (9.x). No Windows com `dotnet` do sistema, usa `"/c/Program Files/dotnet/dotnet.exe" build -c Release`.

---

## ⚖️ Licença

MIT — herdada do [projeto original](https://github.com/minihazel/SPTMiniLauncher). Este fork não acrescenta restrições adicionais.
