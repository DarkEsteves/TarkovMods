# SPTVRAMCleaner — SPT 4.0.13 (MoreOptions / Enhanced)

> ⚠️ **Este não é o meu mod.** / **This is NOT my mod.**
> Original by **Matsix** — repo: https://github.com/Matsix/SPTVRAMCleaner
> Licença / License: GPL-3.0 (igual ao original / same as original)
> Downloads oficiais / Official downloads: https://github.com/Matsix/SPTVRAMCleaner/releases

## O que é / What it is
Um limpador de VRAM/RAM para SPTarkov 4.0.13. Limpa automaticamente memória não usada no início e fim de raid, periodicamente durante a raid, ou manualmente via hotkey — libertando ~1–2 GB de VRAM.

A VRAM/RAM cleaner for SPTarkov 4.0.13. Automatically frees unused memory on raid start, raid exit, on a configurable periodic interval, or via a manual hotkey — freeing ~1–2 GB of VRAM.

## Funcionalidades / Features
| | Português | English |
|---|---|---|
| **Limpeza no início** | Limpa VRAM/RAM quando a raid começa | Cleans VRAM/RAM when raid starts |
| **Limpeza na saída** | Limpa ao sair da raid (quando o mundo é destruído) | Cleans on raid exit (when world is destroyed) |
| **Limpeza periódica** | Limpa automaticamente a cada 1–120 minutos durante a raid | Auto-cleans every 1–120 minutes during raid |
| **Hotkey manual** | Tecla para forçar limpeza (dentro e fora da raid) | Key to force a clean (works in & out of raid) |
| **Config F12** | Todas as opções via menu BepInEx (F12 in-game) | All options via BepInEx menu (F12 in-game) |

## Configuração / Configuration
Todas as opções são configuradas no menu BepInEx (F12 durante o jogo):

| Secção / Section | Opção / Option | Descrição / Description | Default |
|---|---|---|---|
| 1. Geral / General | Enabled | Liga/desliga todo o mod | `true` |
| 1. Geral / General | Clean on raid start | Limpa no início de cada raid | `true` |
| 1. Geral / General | Clean on raid exit | Limpa ao sair da raid | `true` |
| 2. Limpeza periódica / Periodic | Enabled | Limpa periodicamente durante a raid | `true` |
| 2. Limpeza periódica / Periodic | Interval minutes | Minutos entre limpezas (1–120) | `10` |
| 3. Limpeza manual / Manual | Hotkey | Tecla para limpeza manual | `Keypad0` |
| 4. Avançado / Advanced | Verbose diagnostics | Regista eventos no log | `true` |

## Compatibilidade / Compatibility
| | |
|---|---|
| EFT build | 0.16.9.40087 |
| SPT | 4.0.13 |
| BepInEx | 5.4.x |
| Autor original / Original author | Matsix |

## Instalação / Install
1. Faz download do ZIP em Releases.
2. Extrai a pasta para `BepInEx\plugins\` (fica `BepInEx\plugins\SPTVRAMCleaner\`).
3. Corre o SPT.

1. Download the ZIP from Releases.
2. Extract the folder into `BepInEx\` (you'll get `BepInEx\plugins\SPTVRAMCleaner\`).
3. Run SPT.

## Nota / Note
Espera um pequeno lag spike no momento da limpeza (logo após o countdown de início de raid, ou quando a limpeza periódica dispara). É normal — o jogo está a libertar memória.

Expect a small lag spike at the moment of cleaning (right after the raid-start countdown, or when periodic cleaning fires). This is normal — the game is freeing memory.

## Créditos / Credits
- Autor original / Original author: **Matsix** — https://github.com/Matsix/SPTVRAMCleaner
- Build SPT 4.0.13 / Enhanced fork: comunidade / community fork
