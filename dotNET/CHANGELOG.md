## 5.0.4 (2026-06-29)

### Bug Fixes

* **`view-docs.bat` false error after successful `dotnet-serve` install** — `%ERRORLEVEL%` inside a parenthesized block is expanded at parse time, so the nested install-failure check was reading the exit code from the preceding `findstr` (1 = not found) rather than from `dotnet tool install`. Fixed with `setlocal EnableDelayedExpansion` and `!ERRORLEVEL!`.
* **`view-docs.bat` / `view-docs.ps1` `dotnet serve` not found after fresh install** — `dotnet tool install -g` places the executable in `%USERPROFILE%\.dotnet\tools`, which is not on `PATH` in the current shell session. Both scripts now call `dotnet-serve.exe` by its full path instead of relying on `PATH` discovery.
* **`SamplesCS` net48 — CS8370 `using` declarations require C# 8.0 or greater** — SDK-style projects targeting `net48` default to C# 7.3. `Reporting.cs` uses C# 8.0 `using`-declaration syntax. Fixed by adding `<LangVersion>latest</LangVersion>` for the `net48` target in `SamplesCS.csproj`.
* **`SamplesCS` net48 — CS0234 `System.Net.Http` not found** — SDK-style projects do not implicitly reference `System.Net.Http.dll` for `net48`. Fixed with an explicit `<Reference Include="System.Net.Http" />` for the `net48` target.
* **SHFB warning BE0066 — `Context.Equals` missing `<param>` documentation** — `<param name="obj"></param>` was present but empty; SHFB's `ShowMissingComponent` treats empty tags as missing. Added description text.

### New Scripts

* Added `build-docs.bat` and `build-docs.ps1` to `dotNET/Payflow SDK Docs/`. Each script builds `PFProSDK` in Release (regenerating the XML doc file) and then runs the SHFB project in one step. Both pause on completion so the window stays open.

### Documentation

* SHFB API docs — license page corrected from GNU General Public License to Apache License 2.0.
* SHFB API docs — v5.0.3 version history topic added.
* Copyright year updated from 2020 to 2026 across all three `LICENSE` files and the SHFB copyright footer.
* Java SDK API reference now published to GitHub Pages: <https://paypal.github.io/payflow-gateway/>

---

## 5.0.3 (2026-06-28)

### Build Modernization

* Migrated project file from VS 2013 format (`ToolsVersion="12.0"`) to SDK-style (`<Project Sdk="Microsoft.NET.Sdk">`). Explicit per-file `<Compile Include>` entries are no longer needed — the SDK discovers all `.cs` files automatically.
* Added **.NET 8.0** and **.NET 10.0** as supported targets alongside .NET Framework 4.8. The project now multi-targets `net8.0;net10.0;net48`; .NET 8.0 is the default active target in the CLI and Visual Studio.
* NuGet packaging metadata is now embedded directly in `PFProSDK.csproj`. The separate `PFProSDK.nuspec` and vendored `nuget.exe` have been removed. Use `dotnet pack` to produce a `.nupkg`.
* Removed legacy COM interop registration (`RegisterForComInterop`).
* Added `System.Configuration.ConfigurationManager` NuGet package reference (net8.0 target only) to preserve `AppSettingsReader` support on modern .NET.
* `SamplesCS` and `SamplesVB` sample projects migrated from old-style project files to SDK-style, targeting `net8.0`.

### TLS

* TLS configuration on .NET Framework 4.8 now enables both TLS 1.2 and TLS 1.3 (`SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13`). On .NET 8 the OS handles TLS negotiation automatically and the `ServicePointManager` call is excluded via conditional compilation.

### Bug Fixes

* **`ACHTender` duplicate `AUTHTYPE` field** — `ACHTender` declared its own private `mAuthType` field that shadowed the one in `BaseTender`. Because `BaseTender.GenerateRequest()` (called via `base.GenerateRequest()`) already writes `AUTHTYPE` from the correctly-set base field, the subclass was appending `AUTHTYPE` a second time with an always-null value. Removed the dead shadow field and the redundant append.
* **`BaseTransaction.mUserItem` dead field** — `BaseTransaction` contained a `private UserInfo mUserItem` field typed as `UserInfo` instead of `UserItem` (incorrect type), with no public property or setter, making it permanently null. The `if (mUserItem != null)` guard block that depended on it was unreachable dead code. Both removed. `UserItem` support in `Invoice` is unaffected.
* **`RecurringResponse.Name` always-null backing field** — The `NAME` Payflow parameter is not returned in recurring responses; the field assignment was commented out, leaving a backing field that could never be set. Removed the dead field; the public `Name` property now returns `null` explicitly.
* **`Reporting.cs` missing `readServiceResponse` method** — The method was called but never defined, causing a compile error. Added the correct implementation.
* **`DOClientInfo.vb` stale API references** — Fixed `Bill.Street` → `Bill.BillToStreet` and `Bill.Zip` → `Bill.BillToZip` (renamed in 5.0.0). Removed the defunct `CommitResponse` / `AddCommitHeader` / `SubmitCommitTransaction` block which was removed from the SDK in 5.0.0.

### Code Quality

* Replaced non-generic `Hashtable` with `Dictionary<string, string>` for `PayflowConstants.CommErrorCodes` and `PayflowConstants.CommErrorMessages`.
* `LocalPolicy` (a deprecated SSL certificate bypass stub, marked obsolete since VS 2005) is now excluded from .NET 8+ builds via `#if NET48`. The `ICertificatePolicy` interface it implemented was removed in .NET 5.
* Removed unused `using System.Security.Permissions` import from `PaymentConnection.cs`.
* Set `[assembly: ComVisible(false)]` in `AssemblyInfo.cs`; COM visibility is no longer registered at build time.

### Documentation

* Sandcastle Help File Builder (SHFB) project updated to SHFB v2026.3.29.0: presentation style changed from `VS2013` to `Themed2026`; documentation source pinned to the `net8.0` TFM; `.NET Framework 4.8` reference assemblies no longer required.
* Added `<GenerateDocumentationFile>true</GenerateDocumentationFile>` to `PFProSDK.csproj` so the XML comments file is produced on every build and picked up by SHFB automatically.
* Added complete XML doc comments for all previously undocumented public members: `UserItem2`–`UserItem10`, `Invoice.CitDate/VMaid/Par`, `PayPalTender.ExpressCheckoutRequest`, `PayflowNETAPI.GenerateRequestId()`, `PayflowNETAPI.SetParameters()`, `GlobalClass.GlobalVar`, `PayflowUtility.AppSettings()`, `ECDoRequest`/`ECGetRequest`/`ECGetBARequest`/`ECSetRequest` protected constructors. Fixed malformed XML comment blocks and broken `<cref>` attributes.

### Security

* **Credentials moved out of source code** — All sample files (C# and VB DataObjects, NVP, and XMLPay samples) no longer contain hardcoded credential placeholders. Credentials are resolved at runtime in priority order: (1) environment variables `PAYFLOW_USER`, `PAYFLOW_VENDOR`, `PAYFLOW_PARTNER`, `PAYFLOW_PASSWORD`; (2) `App.config` keys `PayflowUser`, `PayflowVendor`, `PayflowPartner`, `PayflowPassword` as a fallback. This allows CI/CD pipelines and shared machines to use env vars while individual developers use `App.config`. Both `SamplesCS/App.config` and `SamplesVB/App.config` ship with placeholder values and are marked `git update-index --skip-worktree` so local edits are never staged or committed.

### Sample Fixes

* **Expired test card dates** — All hardcoded expiration dates across every sample file updated to `0130` (January 2030). Previously dates ranged from `0109` to `1215`, all of which were expired.
* **`Reporting.cs` obsolete HTTP API** — Replaced `HttpWebRequest` / `HttpWebResponse` (obsolete since .NET 5, warning `SYSLIB0014`) with `HttpClient`. Eliminated the `readServiceResponse` helper; `Main` is now `async Task`. Also corrected `xml.LoadXml("report.xml")` → `xml.Load("report.xml")` (LoadXml parses a string, not a filename).

### Quick-Start Scripts

Added `run-sample.ps1`, `run-sample.bat`, and `run-sample.sh` to the `dotNET/` directory. Each script builds the C# sample project and runs `DOSaleComplete` in one step. Pass `vb` / `-VB` to run the Visual Basic sample instead. An optional framework flag (`-Framework net48`, `net10.0`) selects the target; default is `net8.0`.

### Contributing

* Added `CONTRIBUTING.md` with development setup, build instructions, coding standards, and PR guidelines.

---

## 5.0.2 (2022-03-30)

### Changes

* Fixed issue where `RecurringResponse` object was not returning all available values in the response.
* Added `SCAExemption`, `CitDate` and `VMaid` under the `Invoice` object to support Strong Customer Authentication.

---

## 5.0.0 (2020-09-13)

> **IMPORTANT:** This version is not 100% compatible with older versions — some objects and their locations have moved. Do not use in production without adjusting your code and testing.

### Breaking Changes

These changes must be incorporated into your existing integration before upgrading.

* `FIRSTNAME`, `LASTNAME`, `STREET`, `CITY`, `STATE`, `PHONENUM`, `EMAIL`, etc. have been replaced by `BILLTO` versions to align with the `SHIPTO` parameters.

  Example: `Bill.FirstName = "Joe";` is now `Bill.BillToFirstName = "Joe";`

* Moved Merchant fields (Merchant Name, etc.) from `CustomerInfo` object to the new `MerchantInfo` object.

* Moved `MerchDescr` and `MerchSvc` from `Invoice` to `MerchantInfo`. Example:

  ```csharp
  MerchantInfo MerchInfo = new MerchantInfo();
  MerchInfo.MerchantName = "My Company Name";
  MerchInfo.MerchantCity = "My Company City";
  Inv.MerchantInfo = MerchInfo;
  ```

* `VATAXPERCENT` is now `VATTAXPERCENT`. Example:

  ```csharp
  Inv.VatTaxAmt = new Currency(new decimal(25.00), "USD");
  ```

### New Objects

* `MerchantInfo` — holds soft descriptor fields such as Merchant Name, Merchant City, etc.
* `EchoData` added to `Invoice` — allows echoing data back in the response. See [Echo Data](https://developer.paypal.com/docs/payflow/integration-guide/submit-transactions/#echo-data).
* `ORDERID` added to `Invoice` — prevents duplicate orders from being processed.

  > **Note:** `ORDERID` is not the same as Request ID. Request ID operates at the transaction level; `ORDERID` checks for duplicate orders over time (stored for 3 years). Use both together to prevent duplicates from processing/communication errors.

### New NVP Parameters

Some parameters listed below were added in earlier builds but are included here for reference.

* **Stored Credential:** `CARDONFILE` (Request), `TXID` (Request and Response) in the `PaymentCard` object. See [Card on File](https://developer.paypal.com/docs/payflow/integration-guide/card-on-file/#supported-card-on-file-types).
* **v2 3DS:** `DSTRANSACTIONID` and `THREEDSVERSION` in the `BuyerAuthStatus` object. See [3-D Secure with 3rd-Party Merchant Plug-ins](https://developer.paypal.com/docs/payflow/3d-secure-mpi/).
* `USER1` to `USER10` in the `Invoice` object. Can be returned in the response via `EchoData = "User"`. See the `DOSaleComplete` sample.
* Support for MagTek Encrypted Card Readers in the `Swipe` object. See the `DOEncryptedSwipe` sample.

* **Processor-specific Response:** `PAYMENTADVICECODE`, `TYPE`, `AFFLUENT`, `CCUPDATED`, `RRN`, `STAN`, `ACI`, `VALIDATIONCODE` in `TransactionResponse`.
* **Location/Advice Addendum:** `MERCHANTLOCATIONID`, `MERCHANTID`, `MERCHANTCONTACTINFO`, `MERCHANTURL`, `MERCHANTVATNUM`, `MERCHANTINVNUM` in `MerchantInfo`.
* **Response:** `CCTRANSID`, `CCTRANS_POSDATA` in `TransactionResponse`.
* **Request:** `ADDLAMT`, `ADDLAMTTYPE` in new `AdviceDetails` object; `CATTYPE`, `CONTACTLESS` in new `Devices` object; `CUSTDATA`, `CUSTOMERID`, `CUSTOMERNUMBER` in `CustomerInfo`; `MISCDATA`, `REPORTGROUP`, `VATINVNUM`, `VATTAXRATE` in `Invoice`; `AUTHDATE` in `VoiceAuthTransaction`; `BUTTONSOURCE` in `BrowserInfo`.
* **Request Line Items:** `L_ALTTAXAMT`, `L_ALTTAXID`, `L_ALTTAXRATE`, `L_CARRIERSERVICELEVELCODE`, `L_EXTAMT` in `LineItem`.
* **Recurring:** `FREQUENCY` in `RecurringInfo`.

### New Samples

* **Data Upload (`DODataUpload`)** under `samples/dataobjects/misc` — demonstrates transaction type "L" for moving card data off local servers to PayPal for use in reference transactions.
* **Encrypted Swipe (`DOEncryptedSwipe`)** under `samples/dataobjects/basictransactions` — for MagTek Encrypted Swipe readers. See [Payflow Gateway MagTek Parameters](https://developer.paypal.com/docs/payflow/integration-guide/magtek/).
