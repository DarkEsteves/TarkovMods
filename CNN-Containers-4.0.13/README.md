# CNN-Containers — SPT 4.0.13

> **Original mod by [Cannuccia](https://forge.sp-tarkov.com/user/16896/cannuccia)** | Ported to SPT 4.0.X by [Dildz](https://github.com/Dildz/CNN-Containers) | Barter feature added by [DarkEsteves](https://github.com/DarkEsteves)

[![SPT 4.0.13](https://img.shields.io/badge/SPT-4.0.13-blue)](https://sp-tarkov.com) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

---

## What is this?

A port of the **CNN-Containers** mod for SPT 4.0.13, with an added **configurable barter** feature. The original mod adds tiered storage containers (ammo bags, toolboxes, secure containers, etc.) to your hideout traders.

This version adds the ability to purchase containers via **barter items** instead of money, configurable directly in the JSON.

---

## Installation

1. Download the latest release ZIP
2. Extract into your SPT directory (`SPT/user/mods/`)
3. Restart the server

---

## What's New in This Version

### Barter via Config

- **New `barterItems` field** in container config — sell containers for items instead of money
- **Multiple items together** — array of items required in a single trade (AND logic)
- **Any item as payment** — use any item ID (Graphic Card, Wire, CPU, etc.)
- **Fully optional** — configs without `barterItems` work exactly as before (money only)
- **Well-documented** — comments and examples in `config.jsonc`

### Example

```jsonc
"modCase": {
    "enabled": true,
    "gridH": 6, "gridV": 5,
    "barterItems": [{ "tpl": "57347ca9245977452a", "count": 3 }]  // 3x Graphic Card
}
```

---

## Containers

| Container | Type | Grid | Trader |
|-----------|------|------|--------|
| Recycled Ammo Bag | Portable | 2x2 | Prapor LL1 |
| Recycled FAK | Portable | 3x3 | Therapist LL1 |
| Small Portable Fridge | Portable | 2x3 | Jaeger LL1 |
| Small Toolbox | Stash | 4x6 | Skier LL1 |
| Mod Case | Stash | 6x5 | Peacekeeper LL2 |
| Secure Mapbook | Portable | per-map | Therapist LL2 |
| Ruined Wooden Box | Stash | 8x6 | Jaeger LL2 |
| Gear Box | Stash | 10x8 | Ragman LL3 |
| Secure Container Onyx | Secure | 2x3+3x4+1x2 | Peacekeeper LL4 |

---

## Configuration

Edit `config/config.jsonc` to:
- Enable/disable individual containers
- Change trader prices and loyalty levels
- Resize container grids
- Add barter items (new!)
- Set custom flea market prices
- Add extra allowed item filters
- Rename/translate container names

---

## Known Issues

- Mod Case and Ruined Wooden Box models show pink/purple textures (missing shaders from older Unity version). Functionally fine.

---

## Credits

- **[Cannuccia](https://forge.sp-tarkov.com/user/16896/cannuccia)** — original CNN-Containers mod
- **[AMightyTank](https://forge.sp-tarkov.com/user/59864/amightytank)** — SPT 3.11.X update
- **[MrVibesRSA](https://forge.sp-tarkov.com/user/75504/mrvibesrsa)** — Secure Mapbook mod
- **[Dsnyder](https://forge.sp-tarkov.com/user/28568/dsnyder)** — Container-Onyx (Re-Upload)
- **[Dildz](https://github.com/Dildz/CNN-Containers)** — SPT 4.0.X port
- **[TheSunGod](https://forge.sp-tarkov.com/user/108019/thesungod)** — testing & feedback
- **[DarkEsteves](https://github.com/DarkEsteves)** — barter feature, SPT 4.0.13 build

---

## License

This mod is licensed under the MIT License. See [LICENSE](LICENSE) for details.
