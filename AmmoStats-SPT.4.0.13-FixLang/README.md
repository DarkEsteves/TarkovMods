# AmmoStats — SPT Mod

**Version:** 1.3.2
**Author:** Mattdokn (original)
**SPT Version:** 4.0.x
**License:** MIT

---

## EN — Description

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

## PT — Descrição

O AmmoStats mostra os estatísticas de penetração e dano da munição diretamente no nome do item, facilitando a comparação de tipos de munição sem abrir a janela de inspeção.

### Funcionalidades

- Mostra **penetração/dano** (ou dano/penetração) nas nomes das munições
- Posição configurável: antes ou depois do nome do item
- Parênteses opcionais à volta das estatísticas
- Preenchimento com zeros para melhor ordenação no flea market
- Funciona com **todos os idiomas** (não só Inglês)
- Suporta todos os tipos de munição: balas, buckshot e granadas
- Suporta caixas de munição (mostra as estatísticas da munição contida)

### Configuração (`config.json`)

| Defeito | Padrão | Descrição |
|---------|---------|-------------|
| `ShowPenBeforeDmg` | `true` | Mostrar penetração antes do dano (`false` = dano primeiro) |
| `InfoBeforeName` | `true` | Colocar estatísticas antes do nome do item (`false` = depois) |
| `InfoInParenthesis` | `true` | Envolver estatísticas em parênteses |
| `PaddingLength` | `2` | Comprimento do preenchimento com zeros (por a `0` para desativar) |

### Changelog

#### 1.3.2 (DarkEsteves)
- **Correção:** Agora funciona com todos os idiomas do jogo (PT, EN, etc.) — o original só modificava o locale Inglês
- **Correção:** O config `InfoBeforeName` agora funciona corretamente (estava a ser ignorado)
- **Correção:** Já não crasha se um locale não tiver uma entrada de item específica
- Atualizado para SPT 4.0.13

#### 1.3.1 (Mattdokn)
- Tentativa de correção do problema de locale mas introduziu novos bugs

#### 1.3.0 (Mattdokn)
- Lançamento inicial para SPT 4.0.x
