# Payflow Java SDK

A Java SDK for easy integration with the PayPal Payflow Gateway. Requires **Java 11** or newer.

> **Note:** v5 contains breaking changes from v4. Review the [CHANGELOG](./CHANGELOG.md) before upgrading an existing integration.

## Requirements

* Java 11+ (LTS releases recommended; Java 8 also works — set `maven.compiler.release=8` in `pom.xml`)
* Apache Maven 3.6+ (for building)

## Quick Start

### Step 1 — Configure credentials

Credentials are read at runtime — never hardcoded. You have two options:

**Option A — Environment variables (recommended for CI/CD and shared machines):**

```bash
export PAYFLOW_USER=your_user
export PAYFLOW_VENDOR=your_vendor
export PAYFLOW_PARTNER=PayPal
export PAYFLOW_PASSWORD=your_password
```

On Windows (PowerShell):
```powershell
$env:PAYFLOW_USER     = "your_user"
$env:PAYFLOW_VENDOR   = "your_vendor"
$env:PAYFLOW_PARTNER  = "PayPal"
$env:PAYFLOW_PASSWORD = "your_password"
```

**Option B — Properties file (simple local use):**

Create `java/payflow.properties` and fill in your account details:

```properties
PayflowUser=your_user
PayflowVendor=your_vendor
PayflowPartner=PayPal
PayflowPassword=your_password
```

This file is listed in `.gitignore` and will never be committed.

> **Priority:** Environment variables take precedence over `payflow.properties`. If any env var is missing, the file is used as a fallback. If neither is available, the sample prints an error and exits.

### Step 2 — Run the sample

Once credentials are set in `payflow.properties`, run:

```powershell
# Windows (PowerShell)
cd java
.\run-sample.ps1
```

```bash
# Linux / macOS / Git Bash
cd java
./run-sample.sh
```

```bat
REM Windows (Command Prompt)
cd java
run-sample.bat
```

Each script runs `mvn clean package`, compiles the sample against the resulting JAR, and runs it — no manual classpath setup required.

> **Note:** When running on JDK 21 or later you may see the following warning from Maven's
> own Guava dependency. It is cosmetic and can be safely ignored — it has no effect on the
> build or on the SDK at runtime:
> ```
> WARNING: sun.misc.Unsafe::objectFieldOffset has been called by com.google.common.util.concurrent...
> ```
> This will be resolved in a future Maven release.

## Building the SDK

```bash
cd java
mvn clean package
```

Output: `target/payflow.jar` with **zero external runtime dependencies**. Copy it to your project's classpath.

## Building with an IDE

Open the `java/` directory as a Maven project in IntelliJ IDEA, Eclipse, or VS Code (Java Extension Pack). The IDE detects `pom.xml` and configures the source roots automatically.

## Running the Samples Manually

The sample files live under `src/paypal/payments/samples/`. They are not included in `payflow.jar`; compile and run them separately:

```bash
# 1. Build the SDK
mvn clean package

# 2. Compile the sample into a local output directory
mkdir -p samplebin
javac -cp target/payflow.jar \
      -d samplebin \
      src/paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java

# 3. Run (payflow.properties must be in the working directory)
java -cp "target/payflow.jar:samplebin" \
     paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete
```

On Windows use `;` instead of `:` as the classpath separator.

> **Note:** `payflow.properties` must be present in the directory you run the `java` command from. The `run-sample` scripts automatically run from the `java/` directory where the file lives.

## API Documentation

The SDK ships with full Javadoc comments. Generate the HTML reference with:

```powershell
# Windows (PowerShell)
.\generate-docs.ps1
```

```bash
# Linux / macOS / Git Bash
./generate-docs.sh
```

```bat
REM Windows (Command Prompt)
generate-docs.bat
```

Output is written to `target/site/apidocs/index.html`.

See also the [Payflow Gateway Developer Guide](https://developer.paypal.com/docs/payflow/integration-guide/).

## Contributing

See [CONTRIBUTING.md](./CONTRIBUTING.md). PRs are welcome; open an issue first for major changes.

## Older Versions

The last v4 SDK binaries are in the [SDK Binaries](https://github.com/paypal/payflow-gateway/tree/master/SDK%20Binaries/) directory.

## License

[SDK LICENSE](https://github.com/paypal/payflow-gateway/blob/master/LICENSE)
