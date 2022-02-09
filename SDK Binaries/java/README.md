Payflow Java SDK (Archive)
--------------------------
These compiled version of the Payflow Java SDK can continue to be used but will no longer be updated.  Should you need to add new parameters not supported by these SDKs to your application; and you choose not to upgrade to v5 of the Java SDK, you can use the `EXTDATA` tag to add the new functionality.  The following is example of how you would add a new NVP to your application:
```
// Set the extended data value.
ExtendData extData = new ExtendData("VERSION", "214.0");  // NVP, Value
// Add extended data to transaction.
trans.addToExtendData(extData);
```

Should you want to want to modify and compile for another version or application, please feel free to down the source code from the [Java Repo](https://github.com/paypal/payflow-gateway/tree/master/java) and feel free to offer pull requests of your changes.  However, remember that v5 of the Java SDK is not fully backwards compatible and requires testing prior to deploying in a production environment.

## Current Release Notes
* v4.49
  * Fixed issue with `RecurringReponse` not returning all the available fields returned in the API response.  Updated `DoRecurringInquiry` to reflect this change.
* v4.48
  * Fully backwards compatible with previous versions; except for Java version support. Compiled on Java 1.8.0_261.
  * Added support for `CARDONFILE` and `TXID` as part of the `PaymentCard` (both) and `TransactionResponse` (TXID) objects) .  See [Card on File](https://developer.paypal.com/docs/payflow/integration-guide/card-on-file/) for more details.
  * Added support for 3DS v2 by adding `DSTRANSACTIONID` and `THREEDSVERSION` parameters.  See [3-D Secure with 3rd-Party Merchant Plug-ins](https://developer.paypal.com/docs/payflow/3d-secure-mpi/) for more details.
  * `USER1` to `USER10` which is part of the `Invoice` object.</br>These can be returned in the response using the `EchoData` set to "User".
  * `ECHODATA` in the `Invoice` object.

## Previous Release Notes
* 4.47
  * Removed dependancy of sun.misc.BASE64Encoder and replaced with java.util.Base64.
* 4.46
  * Compiled on latest version of Java 1.8.
  * New Request NVPs - `AUTHTYPE` (TeleCheck) and `FREQUENCY` (Recurring Billing).
  * New Response NVPs - `TRACEID` and `ACHSTATUS` (both TeleCheck).

The Payflow Developer Guides can be found at [here](https://developer.paypal.com/docs/payflow/integration-guide/).

Any questions or issues with these SDKs, please send your inquires to DL-PayPal-Payflow-SDK@paypal.com.
