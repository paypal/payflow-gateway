# Contributing to the Payflow .NET SDK

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
- The .NET target framework (e.g., `net48`, `net8.0`)
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

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download) (also builds the net48 target on Windows)
- Visual Studio 2022 17.8+ **or** any editor with the C# extension (VS Code, Rider, etc.)
- .NET Framework 4.8 Developer Pack (Windows only, required to produce the `net48` target)

### Build

```powershell
cd dotNET/PFProSDK
dotnet build
```

Both `net8.0` and `net48` targets are built. Output lands in `bin/Debug/net8.0/` and `bin/Debug/net48/`.

### Running the Samples

Open `dotNET/Payflow dotNET SDK.sln` in Visual Studio, or build `SamplesCS` from the CLI:

```powershell
cd dotNET/SamplesCS
dotnet build
```

Edit the credentials inside the sample file you want to run, then set it as the startup object in `SamplesCS.csproj` (`<StartupObject>`).

### Producing a NuGet Package

```powershell
cd dotNET/PFProSDK
dotnet pack -c Release
```

Output: `bin/Release/PayPal.Payflow.<version>.nupkg`

---

## Making Changes

1. **Fork** the repository and create a branch from `master`:

   ```
   git checkout -b fix/brief-description
   ```

2. Make your changes. Keep commits focused — one logical change per commit.

3. **Build** to confirm both targets compile cleanly:

   ```powershell
   dotnet build
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

The SDK targets both .NET Framework 4.8 and .NET 8.0. Keep the following in mind:

- **Do not use APIs that are unavailable on one of the two targets** without a `#if` conditional compile guard. Check the [.NET API compatibility table](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) when in doubt.
- Use generic collections (`List<T>`, `Dictionary<TKey, TValue>`) rather than non-generic ones (`ArrayList`, `Hashtable`).
- Prefer explicit types over `var` for public/internal member declarations; `var` is fine for local variables where the type is obvious.
- Match the existing naming conventions: `mCamelCase` for private fields, `PascalCase` for properties and methods.
- Do not add external NuGet dependencies to the SDK library (`PFProSDK`) without discussion — minimizing the dependency footprint is a stated goal.
- Avoid platform-specific APIs unless guarded by a `Condition` in the project file or a `#if` in code.

---

## License

By contributing, you agree that your contributions will be licensed under the same [MIT License](https://github.com/paypal/payflow-gateway/blob/master/LICENSE) that covers this project.
