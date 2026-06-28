# Payflow .NET SDK — API Documentation

This project generates the full API reference for the Payflow .NET SDK using
[Sandcastle Help File Builder (SHFB)](https://github.com/EWSoftware/SHFB).

## Requirements

* **SHFB v2026.3.29.0 or later** — download from the SHFB GitHub releases page.
* **Visual Studio IDE (optional):** also requires the **.NET Framework 4.8 targeting pack**
  (VS Installer → Modify → Individual components → ".NET Framework 4.8 targeting pack").
  The command-line build does not need it.

## Building the Docs

```powershell
$env:SHFBROOT = "C:\Program Files (x86)\EWSoftware\Sandcastle Help File Builder\"
dotnet msbuild PayflowSDKDocs.shfbproj /p:Configuration=Release
```

Output is written to the `Help\` subdirectory.

## Viewing the Docs

> **Important:** Do not open `Help\index.html` directly in a browser by double-clicking
> or dragging it to the address bar. The SHFB website output uses JavaScript to load the
> table of contents and search index, and modern browsers block those requests when a page
> is served over the `file://` protocol (browser security / same-origin policy). The page
> will display the message *"This will not work if loaded from the file system directly."*

You must serve the `Help\` folder through a local HTTP server. The quickest options are
listed below — use whichever tools you already have installed.

### Option 1 — `dotnet-serve` (recommended; .NET is already required)

Install once, then run any time:

```powershell
dotnet tool install -g dotnet-serve   # one-time global install
dotnet serve -o -p 8080 -d "Help"    # opens browser automatically
```

Or use the provided script which handles the install check for you:

```powershell
.\view-docs.ps1
```

### Option 2 — Python (if installed)

```bash
cd Help
python -m http.server 8080
# then open http://localhost:8080/ in a browser
```

### Option 3 — Node.js / npx (if installed)

```bash
npx serve Help -l 8080
```

### Option 4 — VS Code Live Server extension

Right-click `Help\index.html` in the VS Code Explorer and choose
**Open with Live Server**. No separate install needed if you already have the extension.

## Quick-View Scripts

Three convenience scripts are provided that start a `dotnet-serve` instance (installing
it automatically if needed) and open your browser:

| Script | Platform |
|--------|----------|
| `view-docs.ps1` | Windows PowerShell / PowerShell 7 |
| `view-docs.bat` | Windows Command Prompt |
| `view-docs.sh` | Linux / macOS / Git Bash |

Press **Ctrl+C** in the terminal to stop the server when you are done.
