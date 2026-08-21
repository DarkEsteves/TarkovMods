# AmmoClarity — SPT Mod

**Version:** 1.0.1
**Author:** Jehree (original) / DarkEsteves (fixes)
**SPT Version:** 4.0.x
**License:** MIT

---

## EN — Description

AmmoClarity shortens ammunition names and adds caliber info to the short name, making it easier to read in your inventory.

### Features

- Replaces long ammo short names with shorter versions (e.g., "5.56x45mm M855A1" → "556 55A1")
- Configurable caliber leading or trailing position
- Custom name overrides via `NameUpdates` dict
- Works with **all languages** (not just English)
- Warning system for names longer than 9 characters

### Configuration (`config.json`)

| Setting | Default | Description |
|---------|---------|-------------|
| `LeadingCaliberName` | `true` | Caliber name before ammo type |
| `LogAllAmmos` | `false` | Log all ammos to console on startup |
| `STFU` | `false` | Disable long name warnings |
| `Calibers` | — | Full name → short name mapping |
| `NameUpdates` | — | Custom short name overrides |

### Changelog

#### 1.0.1 (DarkEsteves)
- **Fix:** Now works with all game languages (PT, EN, etc.) — the original only modified the `en` locale
- Updated build target to SPT 4.0.13

---

## PT — Descrição

O AmmoClarity encurta os nomes das munições e adiciona info de calibre ao nome curto, facilitando a leitura no inventário.

### Funcionalidades

- Substitui nomes longos de munições por versões curtas (ex: "5.56x45mm M855A1" → "556 55A1")
- Posição do calibre configurável (antes ou depois)
- Overrides de nomes customizados via `NameUpdates`
- Funciona com **todos os idiomas** (não só Inglês)
- Sistema de aviso para nomes com mais de 9 caracteres

### Configuração (`config.json`)

| Defeito | Padrão | Descrição |
|---------|---------|-------------|
| `LeadingCaliberName` | `true` | Nome do calibre antes do tipo de munição |
| `LogAllAmmos` | `false` | Loga todas as munições na consola no arranque |
| `STFU` | `false` | Desativa avisos de nomes longos |
| `Calibers` | — | Mapeamento nome completo → nome curto |
| `NameUpdates` | — | Overrides de nomes customizados |

### Changelog

#### 1.0.1 (DarkEsteves)
- **Correção:** Agora funciona com todos os idiomas do jogo (PT, EN, etc.) — o original só modificava o locale `en`
- Atualizado para SPT 4.0.13
