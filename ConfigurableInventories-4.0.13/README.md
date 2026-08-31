# ConfigurableInventories — SPT 4.0.13

> **Original mod by [Harmer](https://forge.sp-tarkov.com/user/28568/harmer)** | Converted from JS to C# by [DarkEsteves](https://github.com/DarkEsteves)

[![SPT 4.0.13](https://img.shields.io/badge/SPT-4.0.13-blue)](https://sp-tarkov.com)

---

## What is this?

A full conversion of **ConfigurableInventories** from JavaScript (SPT 3.11+) to C# (SPT 4.0.13). The original mod used JS APIs that were removed in SPT 4.0 (VFS, etc.). This version rewrites everything in native C# using SPT 4.0.13 APIs.

---

## Installation

1. Download the latest release ZIP
2. Extract into `SPT/user/mods/ConfigurableInventories/`
3. Restart the server

---

## What Changed

| Area | Before (JS) | After (C#) |
|------|-------------|------------|
| Language | TypeScript/JavaScript | C# |
| APIs | VFS, JS runtime | `DatabaseService`, `ModHelper`, `ISptLogger` |
| Lifecycle | JS module | `IOnLoad` with `Task` return |
| Project | Legacy .csproj | SDK-style `net9.0` |

### Categories Supported

- Backpacks
- Cases
- Plate Carriers
- Pockets
- Rigs
- Secure Containers

All 7 config JSONCs are preserved from the original mod.

---

## Build

```bash
dotnet build -c Release
```

Output: `bin/Release/net9.0/ConfigurableInventories.dll` (16.5 KB)

---

## Credits

- **[Harmer](https://forge.sp-tarkov.com/user/28568/harmer)** — original ConfigurableInventories mod
- **[DarkEsteves](https://github.com/DarkEsteves)** — JS → C# conversion, SPT 4.0.13 port

---

## License

This mod is licensed under the MIT License.
