# Payflow .NET SDK

A .NET SDK for easy integration with the PayPal Payflow Gateway. Supports **.NET 8.0** (LTS), **.NET 10.0** (LTS), and **.NET Framework 4.8**.

> **Note:** v5 contains breaking changes from v4. Review the [CHANGELOG](./CHANGELOG.md) before upgrading an existing integration.

## Requirements

| Target | Minimum Tooling |
|--------|----------------|
| .NET 10.0 (LTS) | .NET 10 SDK or Visual Studio 2022 17.12+ |
| .NET 8.0 (LTS) | .NET 8 SDK or Visual Studio 2022 17.8+ |
| .NET Framework 4.8 | .NET Framework 4.8 Developer Pack + Visual Studio 2019+ |

## Quick Start

### Step 1 — Configure credentials

Credentials are read at runtime — never hardcoded. You have two options:

**Option A — Environment variables (recommended for CI/CD and shared machines):**

```powershell
# Windows (PowerShell)
$env:PAYFLOW_USER     = "your_user"
$env:PAYFLOW_VENDOR   = "your_vendor"
$env:PAYFLOW_PARTNER  = "PayPal"
$env:PAYFLOW_PASSWORD = "your_password"
```

```bash
# Linux / macOS / Git Bash
export PAYFLOW_USER=your_user
export PAYFLOW_VENDOR=your_vendor
export PAYFLOW_PARTNER=PayPal
export PAYFLOW_PASSWORD=your_password
```

**Option B — App.config (simple local use):**

Open `dotNET/SamplesCS/App.config` (or `SamplesVB/App.config` for VB) and fill in your account details:

```xml
<add key="PayflowUser"     value="your_user" />
<add key="PayflowVendor"   value="your_vendor" />
<add key="PayflowPartner"  value="PayPal" />
<add key="PayflowPassword" value="your_password" />
```

Git is pre-configured (`--skip-worktree`) to ignore local changes to both `App.config` files so your credentials are never staged or committed.

> **Priority:** Environment variables take precedence over `App.config`. If any env var is missing the file is used as a fallback.

### Step 2 — Run the sample

The fastest way to verify connectivity is the `DOSaleComplete` sample. Once credentials are set in `App.config`, run:

```powershell
# Windows (PowerShell)
cd dotNET
.\run-sample.ps1
```

```bash
# Linux / macOS / Git Bash
cd dotNET
./run-sample.sh
```

```bat
REM Windows (Command Prompt)
cd dotNET
run-sample.bat
```

Pass `vb` / `-VB` to run the Visual Basic sample instead of the C# one.

## Building the SDK

```powershell
cd dotNET/PFProSDK
dotnet build
```

This produces `Payflow_dotNET.dll` under `bin/Debug/net8.0/`, `bin/Debug/net10.0/`, and `bin/Debug/net48/`. Use `-c Release` for release binaries.

## Building a NuGet Package

Package metadata is embedded directly in `PFProSDK.csproj` — no separate `.nuspec` or `nuget.exe` is needed.

```powershell
cd dotNET/PFProSDK
dotnet pack -c Release
```

Output: `bin/Release/PayPal.Payflow.5.0.3.nupkg` — a single multi-targeted package containing `net8.0`, `net10.0`, and `net48` assemblies.

## Building with Visual Studio

Open `dotNET/Payflow dotNET SDK.sln` in Visual Studio 2022 or later. The SDK-style project loads directly with no migration wizard.

## Running the Samples

All sample projects target `net8.0`, `net10.0`, and `net48`.

**Before running:** fill in your credentials in `App.config` as described in the Quick Start section above.

To run from Visual Studio:

1. Open the solution in Visual Studio.
2. Set `SamplesCS` (C#) or `SamplesVB` (VB.NET) as the startup project.
3. Update `<StartupObject>` in the project file if you want a different entry point than `DOSaleComplete`.
4. Press **F5** or use `dotnet run --project SamplesCS -f net8.0`.

## API Documentation

The `Payflow SDK Docs` project generates a full API reference website using [Sandcastle Help File Builder (SHFB)](https://github.com/EWSoftware/SHFB) v2026.3.29.0 or later.

**Requirements:** Install SHFB from its GitHub releases page. Opening the docs project in Visual Studio also requires the **.NET Framework 4.8 targeting pack** — install it via **VS Installer → Modify → Individual components → ".NET Framework 4.8 targeting pack"**. This is a VS IDE requirement only; the SHFB command-line build does not need it.

```powershell
$env:SHFBROOT = "C:\Program Files (x86)\EWSoftware\Sandcastle Help File Builder\"
cd "dotNET/Payflow SDK Docs"
dotnet msbuild PayflowSDKDocs.shfbproj /p:Configuration=Release
```

Output is written to `Payflow SDK Docs/Help/`.

> **Important:** Do not open `Help/index.html` directly in a browser. The SHFB website output
> requires a local HTTP server — browsers block its JavaScript when loaded via `file://`.
> Use the provided scripts to serve it:
>
> ```powershell
> cd "dotNET/Payflow SDK Docs"
> .\view-docs.ps1        # Windows PowerShell
> ```
> ```bash
> ./view-docs.sh         # Linux / macOS / Git Bash
> ```
> ```bat
> view-docs.bat          # Windows Command Prompt
> ```
>
> Each script installs `dotnet-serve` automatically (one time) and opens the browser.
> See `Payflow SDK Docs/README.md` for additional viewing options.

See also the [Payflow Gateway Developer Guide](https://developer.paypal.com/docs/payflow/integration-guide/).

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md). PRs are welcome; open an issue first for major changes.

## Older Versions

The last v4 SDK binaries are in the [SDK Binaries](https://github.com/paypal/payflow-gateway/tree/master/SDK%20Binaries/) directory.

## License

[SDK LICENSE](https://github.com/paypal/payflow-gateway/blob/master/LICENSE)
