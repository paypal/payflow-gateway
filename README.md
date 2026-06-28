# Payflow Gateway SDKs

Open-source SDKs for the PayPal Payflow Gateway — available for **.NET** and **Java**. Both SDKs are currently at **v5.0.3**.

> **Important:** v5 is not fully backwards-compatible with v4. Review the CHANGELOG in each SDK directory before upgrading an existing integration.

## SDKs

| SDK | Directory | Build Tool | Min Runtime |
|-----|-----------|------------|-------------|
| .NET | [`dotNET/`](./dotNET/) | `dotnet` CLI / Visual Studio 2022+ | .NET 8.0, .NET 10.0, or .NET Framework 4.8 |
| Java | [`java/`](./java/) | Apache Maven 3.6+ | Java 11 |

The .NET SDK is published on NuGet: [![NuGet](https://img.shields.io/nuget/v/PayPal.Payflow)](https://www.nuget.org/packages/PayPal.Payflow)

```powershell
dotnet add package PayPal.Payflow
```

See each SDK's directory for full setup and usage details:

* [dotNET/README.md](./dotNET/README.md) — build, NuGet packaging, samples, SHFB docs
* [java/README.md](./java/README.md) — Maven build, sample compilation, IDE setup

See the CHANGELOG in each directory for a detailed history of changes:

* [dotNET/CHANGELOG.md](./dotNET/CHANGELOG.md)
* [java/CHANGELOG.md](./java/CHANGELOG.md)

## Quick Start

Both SDKs ship with `run-sample` scripts that build and run the `DOSaleComplete` connectivity test in one step.

**PowerShell (Windows):**

```powershell
# .NET
cd dotNET && .\run-sample.ps1

# Java
cd java && .\run-sample.ps1
```

**Bash (Linux / macOS / Git Bash):**

```bash
# .NET
cd dotNET && ./run-sample.sh

# Java
cd java && ./run-sample.sh
```

**Command Prompt (Windows):**

```bat
cd dotNET && run-sample.bat
cd java    && run-sample.bat
```

Fill in your Payflow credentials in the sample file before running. The credentials section is near the top of `DOSaleComplete.cs` / `DOSaleComplete.java`.

## Build Systems

### .NET

The .NET SDK uses the standard **`dotnet` CLI** (SDK-style project file). The package is published on NuGet.org as [`PayPal.Payflow`](https://www.nuget.org/packages/PayPal.Payflow) and can be installed directly:

```powershell
dotnet add package PayPal.Payflow
```

To build locally from source:

```powershell
cd dotNET/PFProSDK
dotnet build            # build for net8.0, net10.0, and net48
dotnet pack -c Release  # produces PayPal.Payflow.5.0.3.nupkg
```

The resulting `.nupkg` is a multi-targeted NuGet package compatible with .NET 8.0, .NET 10.0, and .NET Framework 4.8.

### Java

The Java SDK uses **Apache Maven**. The library has zero external runtime dependencies — XML parsing uses the JDK-bundled JAXP implementation.

```bash
cd java
mvn clean package   # produces target/payflow.jar
```

## Documentation

* **Payflow Gateway Developer's Guide:** [developer.paypal.com/docs/payflow/integration-guide/](https://developer.paypal.com/docs/payflow/integration-guide/)
* **XMLPay schema and general info:** [Payflow Developer's Guide (NVP/SOAP)](https://developer.paypal.com/api/nvp-soap/payflow/integration-guide/)
* **New Features & Revision History:** [developer.paypal.com/docs/payflow/integration-guide/new-features/](https://developer.paypal.com/docs/payflow/integration-guide/new-features/)
* **.NET API Reference** (generated): build `dotNET/Payflow SDK Docs/PayflowSDKDocs.shfbproj` with [SHFB v2026+](https://github.com/EWSoftware/SHFB); output at `dotNET/Payflow SDK Docs/Help/index.html`
* **Java API Reference** (generated): run `mvn javadoc:javadoc` in `java/` (or use `generate-docs.bat/ps1/sh`); output at `java/target/site/apidocs/index.html`

## SDK Binaries (v4)

The last pre-open-source v4 SDK binaries are preserved in the [SDK Binaries](./SDK%20Binaries/) directory. They do not include the newest NVPs; all active development is on v5.

## Contributing

See the `CONTRIBUTING.md` in the relevant SDK directory:

* [dotNET/CONTRIBUTING.md](./dotNET/CONTRIBUTING.md)
* [java/CONTRIBUTING.md](./java/CONTRIBUTING.md)

Questions or bugs? Open an [issue](https://github.com/paypal/payflow-gateway/issues).

## License

Code released under the [SDK LICENSE](./LICENSE).
