# Contributing to the Payflow Java SDK

Thank you for your interest in contributing. This document covers how to report issues, propose changes, and submit pull requests.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Reporting Issues](#reporting-issues)
- [Requesting Features](#requesting-features)
- [Development Setup](#development-setup)
- [Making Changes](#making-changes)
- [Pull Request Guidelines](#pull-request-guidelines)
- [Coding Standards](#coding-standards)
- [License](#license)

---

## Code of Conduct

Please be respectful and constructive in all interactions. Harassment or abusive behavior of any kind will not be tolerated.

---

## Reporting Issues

Before opening an issue, please search [existing issues](https://github.com/paypal/payflow-gateway/issues) to avoid duplicates.

When filing a bug report, include:

- A clear, descriptive title
- The SDK version you are using (e.g., `5.0.3`)
- The Java version you are running (e.g., `Java 21`)
- A minimal code sample that reproduces the problem
- The full error message or stack trace, if applicable
- Expected behavior vs. actual behavior

> **Security vulnerabilities** should not be reported through public GitHub issues. Follow PayPal's responsible disclosure process instead.

---

## Requesting Features

Open a [GitHub issue](https://github.com/paypal/payflow-gateway/issues) with the label `enhancement`. Describe the use case, the proposed API or behavior change, and any alternatives you considered. For significant changes, please open an issue for discussion before submitting a pull request.

---

## Development Setup

### Prerequisites

- [Java 11+](https://adoptium.net/) (LTS releases recommended; Java 8 is also supported)
- [Apache Maven 3.6+](https://maven.apache.org/download.cgi)

### Build

```bash
cd java
mvn clean package
```

This produces `target/payflow.jar` with no external runtime dependencies.

### Running the Samples

Sample files live under `src/paypal/payments/samples/`. They are not included in `payflow.jar` — compile and run them directly:

```bash
# Build the SDK first
mvn clean package

# Compile a sample (fill in your credentials inside the file first)
javac -cp target/payflow.jar src/paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java

# Run the sample
java -cp "target/payflow.jar:src" DOSaleComplete
```

On Windows, replace `:` with `;` in the classpath.

### IDE Setup

Open the `java/` directory as a Maven project in IntelliJ IDEA, Eclipse, or VS Code (Java Extension Pack). The IDE will auto-detect `pom.xml` and configure the source roots.

---

## Making Changes

1. **Fork** the repository and create a branch from `master`:

   ```
   git checkout -b fix/brief-description
   ```

2. Make your changes. Keep commits focused — one logical change per commit.

3. **Build** to confirm the project compiles cleanly:

   ```bash
   cd java
   mvn clean package
   ```

4. Test your change manually against the Payflow sandbox environment if it touches request/response handling.

5. Update `CHANGELOG.md` with a summary of your change under an `## Unreleased` section (add the section at the top if it doesn't exist).

6. Open a pull request against `master`.

---

## Pull Request Guidelines

- **One concern per PR.** Bug fixes, features, and refactors should be separate pull requests.
- Reference the related issue in the PR description (e.g., `Closes #42`).
- Keep the diff focused — avoid unrelated whitespace or formatting changes in the same PR.
- For major changes (new objects, API changes, breaking changes), open an issue first to align on approach before investing in implementation.
- PRs that introduce breaking changes must update the `IMPORTANT` notice in `CHANGELOG.md` and note the migration path.

---

## Coding Standards

- **Minimum Java version is 11.** Do not use APIs introduced after Java 11 without a clear justification and version check.
- Use generic collections (`List<T>`, `Map<K,V>`) rather than raw types (`List`, `HashMap` without type parameters).
- Match the existing naming conventions: `m` prefix for private fields (e.g., `mHostAddress`), `PascalCase` for class names, `camelCase` for methods and local variables.
- Do not introduce external runtime dependencies to the SDK library without discussion — the library intentionally has zero external runtime dependencies and relies solely on the JDK.
- XML parsing should use the JDK-bundled JAXP implementation (`DocumentBuilderFactory`, `DocumentBuilder`). Do not re-introduce Apache Xerces or similar third-party XML parsers.
- Keep the three SDK source directories (`src/sdk/base`, `src/sdk/dataobjects`, `src/sdk/transactions`) as the only sources compiled into the JAR. Sample sources under `src/paypal/` must not be included in the library artifact.

---

## License

By contributing, you agree that your contributions will be licensed under the same [MIT License](https://github.com/paypal/payflow-gateway/blob/master/LICENSE) that covers this project.
