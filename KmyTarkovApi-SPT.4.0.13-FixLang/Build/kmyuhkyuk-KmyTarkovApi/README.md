# KmyTarkovApi — Build para SPT 4.0.13 (Fix de Freeze em PT)

> ⚠️ **Este não é o meu mod.** É um build da comunidade (corrigido) do mod original criado por **kmyuhkyuk**. Eu apenas apliquei um patch para corrigir um bug de freeze e recompilei para SPT 4.0.13. Todo o crédito do mod vai para o autor original.

## O que é
Mod de configuração em-game para Escape from Tarkov (via SPT-AKI / SPT), que adiciona um menu de configurações (Configuration Manager) acessível dentro do jogo, além do suporte para o mod **GamePanelHUD**.

Este build é uma **versão corrigida (patched)** do KmyTarkovApi 1.5.0.

## Autor original e onde ir buscar
- **Autor:** [kmyuhkyuk](https://github.com/kmyuhkyuk)
- **Repositório original:** https://github.com/kmyuhkyuk/KmyTarkovApi
- **Downloads (versões oficiais):** https://github.com/kmyuhkyuk/KmyTarkovApi/releases
- **Licença:** GPL-3.0

Vai ao repositório/releases acima para a versão oficial e para acompanhar atualizações. Usa este build apenas se precisares especificamente do fix descrito abaixo.

## Compatibilidade
- **Escape from Tarkov:** build `0.16.9.40087` (cliente EFT correspondente ao SPT 4.0.13)
- **SPT:** `4.0.13`
- **BepInEx:** `5.4.x` (o incluído no SPT 4.0.13)
- **GamePanelHUD:** `3.4.0` (exige KmyTarkovApi 1.5.0+, daí manter a 1.5.0 em vez da 1.4.0)

> Nota: o release oficial 1.5.0 diz "Compatible SPT-Aki 4.0.0". Este build foi testado e compilado para SPT 4.0.13 (EFT 0.16.9.40087).

## O problema que este fix resolve
Na versão original 1.5.0, quando a língua do jogo **não era inglês nem chinês**, o mod fazia uma pesquisa direta (`LanguageNamesDictionary[gameLanguage]`) pela língua do jogo. O EFT passa a língua em formato longo (ex: `"Portuguese"`), e como o dicionário só tem chaves de 2 letras (`"pt"`, `"en"`, `"zh"`...), isso lançava `KeyNotFoundException` **durante o loading** → o jogo travava antes do ecrã principal.

Muitos utilizadores reportaram o erro "KmyTarkovConfiguration.dll is configured to support only English and Chinese" — na verdade o código suporta 18 línguas, o que faltava eram os ficheiros de tradução para essas línguas; o **freeze** em si vinha do indexador frágil.

### Correção aplicada (`KmyTarkovConfiguration/Models/SettingsModel.cs`)
O método `SwitchLanguageFromGame` foi alterado para:
- Normalizar a língua do jogo (lowercase, trim, cortar para 2 letras: `"Portuguese" → "pt"`)
- Usar `TryGetValue` em vez de indexação direta (nunca lança exceção)
- Fazer fallback para `"En"` se a língua não for encontrada

Isto resolve o freeze para **TODAS as línguas**, não só PT.

## Ficheiros incluídos
```
kmyuhkyuk-KmyTarkovApi/
├── KmyTarkovApi.dll            (1.5.0, patched)
├── KmyTarkovConfiguration.dll  (1.5.0, patched)
├── KmyTarkovReflection.dll     (1.5.0)
├── KmyTarkovUtils.dll          (1.5.0)
├── Crc32.NET.dll               (dependência)
├── HtmlAgilityPack.dll         (dependência)
├── localized/
│   ├── en.json
│   └── zh.json
└── bundles/
    └── kmytarkovconfiguration.bundle
```

## Como instalar
1. Fecha o jogo e o SPT.Server.
2. Copia a pasta `kmyuhkyuk-KmyTarkovApi` (esta, com tudo dentro) para:
   ```
   <pasta do SPT>\BepInEx\plugins\
   ```
   Fica: `<pasta do SPT>\BepInEx\plugins\kmyuhkyuk-KmyTarkovApi\...`
3. Se já tiveres uma versão antiga, substitui (ou apaga a antiga primeiro).
4. Arranca o SPT.Server e o jogo normalmente.

## Notas
- Não precisas do GamePanelHUD para este mod funcionar, mas se o usares, mantém a versão 3.4.0 (compatível com 1.5.0).
- A UI do mod aparece em inglês por defeito (só há traduções `en`/`zh` embutidas). Para mudar a língua da UI do mod: F12 → configurações do KmyTarkovApi → Language.
- Build compilado com Visual Studio Build Tools 2022 (MSBuild 17) + .NET Framework 4.7.2 Targeting Pack. Sem strong-name signing.
- **Licença:** GPL-3.0 (herdada do projeto original). Este build é disponibilizado sob os mesmos termos.

## Créditos
- Mod original e framework: **kmyuhkyuk** — https://github.com/kmyuhkyuk/KmyTarkovApi
- Fix de freeze (PT e outras línguas): aplicado manualmente neste build (não pelo autor original)
