# WTT-CornerStore — SPT 4.0.13

> **Original mod by [RockaHorse](https://github.com/RockaHorse) & [DarkEsteves](https://github.com/DarkEsteves)** | Ported to SPT 4.0.13 by [DarkEsteves](https://github.com/DarkEsteves)

[![SPT 4.0.13](https://img.shields.io/badge/SPT-4.0.13-blue)](https://sp-tarkov.com)

---

## What is this?

WTT-CornerStore adds a fully functional food & drink trader called **Le Cheff** to your SRT server, along with a massive database of custom consumable items including real-world brands like Coca-Cola, Red Bull, Four Loko, Doritos, Cheetos, beer, whiskey, and more. Each item has unique buffs and effects — from healing and stamina boosts to... interesting side effects.

---

## Features

- **Le Cheff Trader** — A culinary specialist selling food and drinks
- **50+ Custom Items** — Drinks, snacks, chips, energy drinks, alcohol, and posters
- **Custom Buffs** — Each item has unique effects (stamina, health, skills, weight limit, etc.)
- **Fully Configurable** — Prices, stock, buy restrictions, refresh time via `config.json`
- **Localization** — English names and descriptions for all items
- **Loot Integration** — Items can spawn in containers (jackets, duffles, safes, etc.)
- **Bot Bots** — Some items can be found on bots

---

## Items Included

### Drinks
- Orange Water Bottle, WaTTer (Welcome to Tarkov Water)
- Coca-Cola, Dr Pepper, Sprite
- Red Bull (12+ flavors: Dragonfruit, Blueberry, Strawberry Apricot, Watermelon, Tropical, etc.)
- Beer: Bud Light, Heineken, Stella Artois
- RockaHorse Brewery's LSD Energy Beer
- Ten High Bourbon Whiskey, Jägermeister
- Four Loko (20+ flavors)

### Food & Snacks
- GrooveyPenguin's Space Gummies (THC)
- Doritos (Nacho Cheese, Cool Ranch)
- Cheetos (Crunchy, Flamin Hot, Puffed, Funyuns)

### Posters
- RockaHorse's Foodmart, Drink Four Loko, Red Bull Arena, Red Bull Stratosphere Jump

---

## Installation

1. Download the latest release ZIP
2. Extract into your SPT directory (the ZIP contains the mod folder)
3. Restart the server

---

## Configuration

Edit `config.json` in the mod folder:

| Setting | Default | Description |
|---------|---------|-------------|
| `ItemPriceMultiplier` | 0.3 | Multiplier for all item prices |
| `TraderRefreshMin` | 3600 | Minimum restock time (seconds) |
| `TraderRefreshMax` | 10800 | Maximum restock time (seconds) |
| `AddTraderToFlea` | false | Show trader items on flea market |
| `RandomizeBuyRestriction` | true | Randomize buy limit per item |
| `RandomizeStockAvailable` | false | Randomize stock count |
| `OutOfStockChance` | 40 | Chance item is out of stock (%) |
| `BuyRestrictionMax` | 10 | Maximum buy restriction |
| `StockAvailable` | 10 | Default stock count |
| `IgnoreList` | [] | Item IDs to exclude from trader |

---

## What changed for SPT 4.0.13

| Area | Change |
|------|--------|
| Framework | Updated to SPT 4.0.13 / .NET 9.0 |
| Dependencies | Uses `WTT-ServerCommonLib` v2.0.6 |
| DI | Full dependency injection with `[Injectable]` |
| Database | Uses `DatabaseService` for item/trader registration |
| Locales | Custom locale service for item names |

---

## Credits

- **RockaHorse** — Original mod author, item design, buffs, locales
- **DarkEsteves** — SPT 4.0.13 port, trader integration, C# rewrite

---

## License

This mod is licensed under the MIT License.
