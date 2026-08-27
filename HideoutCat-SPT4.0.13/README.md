# Hideout Cat — SPT 4.0.13 Port

**Original mod:** [bushtail/spt-hideoutcat](https://github.com/bushtail/spt-hideoutcat) by bushtail (v1.1.1, SPT 4.1.x)
**Port & fixes:** DarkEsteves
**Target:** SPT 4.0.13 (EFT 0.16.9)
**License:** MIT (same as original)

![F12 Config Menu](f12_menu.png)

---

## EN — Description

Full port of the Hideout Cat mod to SPT 4.0.13, with a batch of fixes and a fully
configurable in-game settings menu (F12). The cat lives in your hideout: wanders
between areas, sits, lies down, sleeps, eats, grooms, meows at you and can be petted.

### Requirements to spawn

- **Nutrition Unit** level 1+ **AND** Heating level 1+

### What was fixed / changed for 4.0.13

| # | Fix |
|---|-----|
| 1 | **API migration** — rebuilt on the 3.11-style API that still exists in 4.0.13: `HideoutController` instance capture (not a Singleton), `GetActionsClass.GetAvailableHideoutActions(HideoutPlayerOwner, GInterface177)`, `ActionsReturnClass`/`ActionsTypesClass`, `AreaScreenSubstrate.SelectArea`, `BonusPanel.UpdateView` |
| 2 | **Area levels** — `HideoutController.Areas` is a `Dictionary<EAreaType, HideoutArea>`; level is resolved via `Array.IndexOf(AreaLevels, CurrentLevel)` (`Plugin.GetAreaLevel`) instead of the int `AreaData.CurrentLevel` from 4.1 |
| 3 | **Spawn placement** — cat now spawns at a dead-end waypoint of an unlocked area (original logic restored), not frozen at the prefab origin |
| 4 | **`IsBusy()` freeze bug** — upstream comparison counted Idle/Sitting/Lying as "busy", so the cat never wandered or meowed. Now only Sleeping/Eating/Defecating are busy |
| 5 | **Stuck-target bug** — `_currentTargetArea` is cleared on arrival so the cat can pick any area again; fallback to closest waypoint if no area nodes exist |
| 6 | **Audio smear** — `BetterSource.Play` on 4.0.13 requires explicit `oneShot: true`; without it footsteps stacked into a dragging noise |
| 7 | **Footstep timer** — `_stepTimer` is now reset when a step plays (was firing every frame) |
| 8 | **Meow cutting out** — meows/purrs play on the cat's own `AudioSource` (the shared Character pool gets stolen by player movement sounds) |
| 9 | **Meow/mouth sync** — audio delayed ~0.1 s to line up with the animator's mouth opening |
| 10 | **No-clip through furniture** — the node graph was authored for the 4.1 hideout layout. Added `GroundSnap()` (idle) and landing checks during jumps: raycasts keep the cat on real surfaces, land on top of obstacles instead of falling inside them, and push him out of walls |
| 11 | **Flashlight eye reaction disabled** — 4.0.13 has no accessible `CameraManager.Flashlight`; cosmetic-only loss |

### F12 Configuration menu (live)

- **Cat** — Coat (Grey/Black/Orange/White/Brown/Bicolor), Eye Colour — *applies instantly*
- **Audio** — Meow Volume, Step Volume, Footsteps Enabled
- **Behavior** — Meow Frequency, Proximity Meow Distance
- **Movement** — Walk Speed Multiplier, Wander Frequency
- **Spawning** — Enable Cat (instant remove/spawn toggle)

### Install

1. Download the latest release (or build below)
2. Extract `HideoutCat` into `SPT/BepInEx/plugins/`
3. In-game: hideout requires Nutrition Unit 1+ and Heating 1+

### Build

```
dotnet build -c Release
```

References resolve against `J:\Jogos\SPT-4.0.13` by default (change `TarkovDir` in the csproj).

---

## PT — Descrição

Port completo do mod Hideout Cat para o SPT 4.0.13, com várias correções e um menu
de configurações no jogo (F12). O gato vive no teu hideout: passeia entre áreas,
senta-se, deita-se, dorme, come, lambe-se, mia-te e aceita festinhos.

### Requisitos para aparecer

- **Unidade de Nutrição** nível 1+ **E** **Aquecimento** nível 1+

### O que foi corrigido / alterado para a 4.0.13

| # | Correção |
|---|----------|
| 1 | **Migração de API** — reconstruído sobre a API estilo 3.11 que ainda existe na 4.0.13: captura da instância do `HideoutController` (não é Singleton), `GetActionsClass.GetAvailableHideoutActions(HideoutPlayerOwner, GInterface177)`, `ActionsReturnClass`/`ActionsTypesClass`, `AreaScreenSubstrate.SelectArea`, `BonusPanel.UpdateView` |
| 2 | **Níveis de área** — `HideoutController.Areas` é um `Dictionary<EAreaType, HideoutArea>`; o nível resolve-se via `Array.IndexOf(AreaLevels, CurrentLevel)` (`Plugin.GetAreaLevel`) em vez do `AreaData.CurrentLevel` inteiro da 4.1 |
| 3 | **Posição de spawn** — o gato nasce num waypoint "dead-end" de uma área desbloqueada (lógica original restaurada), não parado na origem do prefab |
| 4 | **Bug de congelação no `IsBusy()`** — a comparação original contava Idle/Sitting/Lying como "ocupado", logo o gato nunca passeava nem miava. Agora só Dormir/Comer/Cagar são ocupados |
| 5 | **Destino preso** — `_currentTargetArea` é limpo ao chegar, para poder escolher qualquer área outra vez; fallback para o waypoint mais próximo se não houver nós válidos |
| 6 | **Áudio arrastado** — o `BetterSource.Play` na 4.0.13 exige `oneShot: true` explícito; sem isso os passos empilhavam num barulho contínuo de arrastamento |
| 7 | **Timer dos passos** — `_stepTimer` agora é reiniciado quando toca um passo (antes disparava todas as frames) |
| 8 | **Miados cortados** — miados/purrs tocam numa `AudioSource` própria do gato (o pool partilhado Character é roubado pelos sons de movimento do jogador) |
| 9 | **Sync boca/miado** — áudio atrasado ~0.1 s para coincidir com a abertura da boca no animator |
| 10 | **Noclip pelo mobiliário** — o grafo de nós foi feito para o layout do hideout da 4.1. Adicionado `GroundSnap()` (parado) e verificações de aterragem nos saltos: raycasts mantêm o gato em superfícies reais, aterra EM CIMA de obstáculos em vez de cair lá dentro, e empurra-o para fora de paredes |
| 11 | **Reação aos olhos à lanterna desativada** — a 4.0.13 não expõe `CameraManager.Flashlight`; perda apenas cosmética |

### Menu de configuração F12 (ao vivo)

- **Cat** — Coat (Grey/Black/Orange/White/Brown/Bicolor), Eye Colour — *aplica instantaneamente*
- **Audio** — Meow Volume, Step Volume, Footsteps Enabled
- **Behavior** — Meow Frequency, Proximity Meow Distance
- **Movement** — Walk Speed Multiplier, Wander Frequency
- **Spawning** — Enable Cat (liga/desliga o gato na hora)

### Instalação

1. Descarrega a última release (ou compila abaixo)
2. Extract `HideoutCat` into `SPT/BepInEx/plugins/`
3. No jogo: o hideout precisa de Unidade de Nutrição 1+ e Aquecimento 1+

### Compilar

```
dotnet build -c Release
```

As referências apontam para `J:\Jogos\SPT-4.0.13` por defeito (muda `TarkovDir` no csproj).

---

## Credits / Créditos

- **bushtail** — original mod and asset bundles
- **DarkEsteves** — SPT 4.0.13 port, fixes and config menu
