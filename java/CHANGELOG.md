## 5.0.3 (2026-06-28)

### Build Modernization

* Migrated build system from Apache Ant (`build/build.xml`) to **Maven** (`pom.xml`). Run `mvn clean package` from the `java/` directory to produce `target/payflow.jar`.
* Removed the Apache Xerces runtime dependency (`xerces:xercesImpl`). XML parsing in `IPXmlReader` now uses the JDK-bundled JAXP implementation (`DocumentBuilderFactory` / `DocumentBuilder`). The library now has **zero external runtime dependencies**.
* The three SDK source directories (`src/sdk/base`, `src/sdk/dataobjects`, `src/sdk/transactions`) are wired into Maven via `build-helper-maven-plugin`. Sample sources under `src/paypal/` are intentionally excluded from the library JAR.
* Minimum supported Java version is **Java 11**. Java 8 is also supported — set `maven.compiler.release=8` in `pom.xml` if needed.

### API Documentation

* Added `maven-javadoc-plugin` to `pom.xml`. Run `mvn javadoc:javadoc` (or the provided `generate-docs` scripts) to produce a full HTML API reference at `target/site/apidocs/index.html`. 99 of 102 SDK classes already carried Javadoc comments; `doclint` warnings are suppressed for legacy comment quirks.

### Security

* **Credentials moved out of source code** — `DOSaleComplete.java` previously required developers to paste live Payflow credentials directly into the source file, creating a risk of accidentally committing them to version control. Credentials are now read at runtime from `java/payflow.properties` using `java.util.Properties`. A template `payflow.properties` file is included in the repository with empty values; fill it in locally before running. The file is listed in `.gitignore` and will never be committed. If the file is missing at runtime the sample prints a clear error and exits.

### Quick-Start Scripts

Added `run-sample.ps1`, `run-sample.bat`, and `run-sample.sh` to the `java/` directory. Each script runs `mvn clean package`, compiles `DOSaleComplete`, and runs it in a single step — no manual classpath setup required.

Added `generate-docs.ps1`, `generate-docs.bat`, and `generate-docs.sh` for one-step Javadoc generation.

### Contributing

* Added `CONTRIBUTING.md` with development setup, build instructions, coding standards, and PR guidelines.

---

## 5.0.2 (2022-03-30)

### Changes

* Fixed issue where `RecurringResponse` object was not returning all available values in the response.
* Added `SCAExemption`, `CitDate` and `VMaid` under the `Invoice` object to support Strong Customer Authentication.

---

## 5.0.1 (2021-03-23)

### Changes

* Removed system-wide proxy and replaced with per-connection proxy.
* Updated Express Checkout to use current parameters and flow.
* Removed dependency on `sun.misc.BASE64Encoder`; replaced with `java.util.Base64`.

---

## 5.0.0 (2020-09-13)

> **IMPORTANT:** This version is not 100% compatible with older versions — some objects and their locations have moved. Do not use in production without adjusting your code and testing.

### Breaking Changes

These changes must be incorporated into your existing integration before upgrading.

* `FIRSTNAME`, `LASTNAME`, `STREET`, `CITY`, `STATE`, `PHONENUM`, `EMAIL`, etc. have been replaced by `BILLTO` versions to align with the `SHIPTO` parameters.

  Example: `Bill.FirstName = "Joe";` is now `Bill.BillToFirstName = "Joe";`

* Moved Merchant fields (Merchant Name, etc.) from `CustomerInfo` object to the new `MerchantInfo` object.

* Moved `MerchDescr` and `MerchSvc` from `Invoice` to `MerchantInfo`. Example:

  ```java
  MerchantInfo MerchInfo = new MerchantInfo();
  MerchInfo.setMerchantName("My Company Name");
  MerchInfo.setMerchantCity("My Company City");
  Inv.setMerchantInfo(MerchInfo);
  ```

* `VATAXPERCENT` is now `VATTAXPERCENT`. Example:

  ```java
  Inv.setVatTaxAmt(new Currency(new BigDecimal("25.00"), "USD"));
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
* **Request:** `ADDLAMT`, `ADDLAMTTYPE` in new `AdviceDetails` object; `CATTYPE`, `CONTACTLESS` in new `Devices` object; `CUSTDATA`, `CUSTOMERID`, `CUSTOMERNUMBER` in `CustomerInfo`; `ECHODATA`, `MISCDATA`, `REPORTGROUP`, `VATINVNUM`, `VATTAXRATE` in `Invoice`; `AUTHDATE` in `VoiceAuthTransaction`; `BUTTONSOURCE` in `BrowserInfo`.
* **Request Line Items:** `L_ALTTAXAMT`, `L_ALTTAXID`, `L_ALTTAXRATE`, `L_CARRIERSERVICELEVELCODE`, `L_EXTAMT` in `LineItem`.
* **Recurring:** `FREQUENCY` in `RecurringInfo`.

### New Samples

* **Data Upload (`DODataUpload`)** under `samples/dataobjects/misc` — demonstrates transaction type "L" for moving card data off local servers to PayPal for use in reference transactions.
* **Encrypted Swipe (`DOEncryptedSwipe`)** under `samples/dataobjects/basictransactions` — for MagTek Encrypted Swipe readers. See [Payflow Gateway MagTek Parameters](https://developer.paypal.com/docs/payflow/integration-guide/magtek/).
