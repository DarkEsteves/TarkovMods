# AmmoStats — SPT Mod

**Version:** 1.3.2
**Author:** Mattdokn (original)
**SPT Version:** 4.0.x
**License:** MIT

---


AmmoStats displays ammunition penetration and damage stats directly in the item name, making it easier to compare ammo types without opening the inspection window.

### Features

- Shows **penetration/damage** (or damage/penetration) in ammo names
- Configurable position: before or after the item name
- Optional parentheses around the stats
- Zero-padding for better sorting on the flea market
- Works with **all languages** (not just English)
- Supports all ammo types: bullets, buckshot, and grenades
- Supports ammo boxes (shows the stats of the contained ammo)

### Configuration (`config.json`)

| Setting | Default | Description |
|---------|---------|-------------|
| `ShowPenBeforeDmg` | `true` | Show penetration before damage (`false` = damage first) |
| `InfoBeforeName` | `true` | Place stats before the item name (`false` = after) |
| `InfoInParenthesis` | `true` | Wrap stats in parentheses |
| `PaddingLength` | `2` | Zero-padding length (set to `0` to disable) |

### Changelog

#### 1.3.2 (DarkEsteves)
- **Fix:** Now works with all game languages (PT, EN, etc.) — the original only modified the English locale
- **Fix:** `InfoBeforeName` config now works correctly (was being ignored)
- **Fix:** No longer crashes if a locale doesn't have a specific item entry
- Updated build target to SPT 4.0.13

#### 1.3.1 (Mattdokn)
- Attempted to fix locale issue but introduced new bugs

#### 1.3.0 (Mattdokn)
- Initial SPT 4.0.x release

---

---

🌐 [**Versão PT**](index.html) | [English Version](README.md)
