# Remove old combined README and creates EN-only README + index.html with PT toggle

import os
import re

MODS = [
    "AmmoClarity-SPT.4.0.13-FixLang",
    "AmmoStats-SPT.4.0.13-FixLang",
    "DayTimeCultists-SPT.4.0.13",
    "HideoutCat-SPT.4.0.13",
    "KmyTarkovApi-SPT.4.0.13-FixLang",
    "SPTMiniLauncher-SPT.4.0.13",
]

BASE = r"G:\Tools\TarkovMods_new"

def split_en_pt(content):
    """Split README content into EN and PT sections."""
    en_lines = []
    pt_lines = []
    current = "en"
    
    for line in content.split('\n'):
        # Check if we're entering PT section
        if line.strip().startswith("## PT") or line.strip().startswith("## PT —"):
            current = "pt"
            continue
        # Check if we're entering EN section (first section)
        elif line.strip().startswith("## EN") or line.strip().startswith("## EN —"):
            current = "en"
            continue
        # Skip the PT header line itself
        elif line.strip().startswith("### PT") or line.strip().startswith("#### PT"):
            current = "pt"
            continue
        
        if current == "en":
            en_lines.append(line)
        else:
            pt_lines.append(line)
    
    return '\n'.join(en_lines), '\n'.join(pt_lines)

def create_index_html(mod_name, en_content, pt_content):
    """Create index.html with EN/PT toggle."""
    # Escape for JS string
    en_escaped = en_content.replace('\\', '\\\\').replace('`', '\\`').replace('${', '\\${')
    pt_escaped = pt_content.replace('\\', '\\\\').replace('`', '\\`').replace('${', '\\${')
    
    return f"""<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>{mod_name}</title>
    <style>
        body {{ font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif; max-width: 900px; margin: 0 auto; padding: 20px; background: #0d1117; color: #c9d1d9; }}
        h1, h2, h3 {{ color: #58a6ff; }}
        a {{ color: #58a6ff; }}
        code {{ background: #161b22; padding: 2px 6px; border-radius: 3px; }}
        pre {{ background: #161b22; padding: 16px; border-radius: 6px; overflow-x: auto; }}
        blockquote {{ border-left: 4px solid #30363d; margin: 0; padding-left: 16px; color: #8b949e; }}
        hr {{ border: 1px solid #21262d; }}
        table {{ border-collapse: collapse; width: 100%; }}
        th, td {{ border: 1px solid #30363d; padding: 8px 12px; text-align: left; }}
        th {{ background: #161b22; }}
        .lang-toggle {{ position: fixed; top: 20px; right: 20px; background: #21262d; border: 1px solid #30363d; border-radius: 6px; padding: 8px 16px; cursor: pointer; color: #c9d1d9; font-size: 14px; }}
        .lang-toggle:hover {{ background: #30363d; }}
        .pt {{ display: none; }}
    </style>
</head>
<body>
    <button class="lang-toggle" onclick="toggleLang()">Versão PT</button>
    <div id="en-content">
        {en_content}
    </div>
    <div id="pt-content" class="pt">
        {pt_content}
    </div>
    <script>
        function toggleLang() {{
            var en = document.getElementById('en-content');
            var pt = document.getElementById('pt-content');
            var btn = document.querySelector('.lang-toggle');
            if (en.style.display === 'none') {{
                en.style.display = 'block';
                pt.style.display = 'none';
                btn.textContent = 'Versão PT';
            }} else {{
                en.style.display = 'none';
                pt.style.display = 'block';
                btn.textContent = 'English Version';
            }}
        }}
    </script>
</body>
</html>"""

for mod in MODS:
    readme_path = os.path.join(BASE, mod, "README.md")
    if not os.path.exists(readme_path):
        print(f"[SKIP] {mod}/README.md not found")
        continue
    
    with open(readme_path, 'r', encoding='utf-8') as f:
        content = f.read()
    
    en_content, pt_content = split_en_pt(content)
    
    # Create EN-only README with link
    en_readme = en_content.strip() + "\n\n---\n\n🌐 [**Versão PT**](index.html) | [English Version](README.md)\n"
    
    # Write EN-only README
    with open(readme_path, 'w', encoding='utf-8') as f:
        f.write(en_readme)
    
    # Create index.html
    index_path = os.path.join(BASE, mod, "index.html")
    index_content = create_index_html(mod, en_content, pt_content)
    with open(index_path, 'w', encoding='utf-8') as f:
        f.write(index_content)
    
    print(f"[OK] {mod} → README.md (EN) + index.html (toggle)")

print("\nDone!")
