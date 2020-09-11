Payflow .NET SDK (Archive)
--------------------------

These compiled version of the Payflow .NET SDK can continue to be used but will no longer be updated.  Should you need to add new parameters not supported by these SDKs to your application; and you choose not to upgrade to v5 of the .NET SDK, you can use the `EXTDATA` tag to add the functionality.  The following is example of how you would add a new NVP to your application:
```
// Set the extended data value.
ExtendData ExtData = new ExtendData("VERSION", "214.0");  // NVP, Value
// Add extended data to transaction.
Trans.AddToExtendData(ExtData);
```
## Current Release Notes
* v4.47
  * Fully backwards compatible with previous versions.
  * Added support for `CARDONFILE` and `TXID` as part of the `PaymentCard` (both) and `TransactionResponse` (TXID) objects) .  See [Card on File](https://developer.paypal.com/docs/payflow/integration-guide/card-on-file/) for more details.
    * Added support for 3DS v2 by adding `DSTRANSACTIONID` and `THREEDSVERSION` parameters.  See [3-D Secure with 3rd-Party Merchant Plug-ins](https://developer.paypal.com/docs/payflow/3d-secure-mpi/) for more details.

## Previous Release Notes
* 4.46
  * New Request NVPs - `AUTHTYPE` (TeleCheck) and `FREQUENCY` (Recurring Billing).
  * New Response NVPs - `TRACEID` and `ACHSTATUS` (both TeleCheck).

<<<<<<< HEAD
You must be using .NET 4.5 or greater for TLS 1.2 support. However, if still using .NET 3.5 (2.0) see this [article](https://support.microsoft.com/en-ca/help/3154519/support-for-tls-system-default-versions-included-in-the-net-framework).
=======
You must be using .NET 4.5 or greater for TLS 1.2 support. However, if still using .NET 3.5 (2.0) see this article https://support.microsoft.com/en-ca/help/3154519/support-for-tls-system-default-versions-included-in-the-net-framework
>>>>>>> fb84d15d93fe673bcad4cd8e8265716d14664f62

The Payflow Developer Guides can be found at [here](https://developer.paypal.com/docs/payflow/integration-guide/).

Any questions or issues with these SDKs, please send your inquires to DL-PayPal-Payflow-SDK@paypal.com.
