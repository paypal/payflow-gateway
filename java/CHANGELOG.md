## <small>5.0.0 (2020-09-10)</small>

### IMPORTANT: THIS VERSION IS NOT 100%  COMPATIBLE WITH OLDER VERSIONS AS SOME OF THE OBJECTS AND THEIR LOCATIONS HAVE MOVED.

#### Changes
These changes will need to be incorporated into your existing integration before you can use this version.
* FIRSTNAME, LASTNAME, STREET, CITY, STATE, PHONENUM, EMAIL, etc. have been replaced by "BILLTO" versions to align with the "SHIPTO" parameters. </p>Example:</br>`bill.setFirstName = "Joe";` is now `bill.setBillToFirstName = "Joe";`.

* Moved `MerchDescr` and `MerchSvc` from `Invoice` object to new `MerchantInfo` object. This new object now holds the soft descriptor fields; such as, Merchant Name, Merchant City, etc.  The following is an example of the change:

	```<language>
    MerchantInfo merchant = new MerchantInfo();
    merchant.setMerchantName("Merchant Name");
    merchant.setMerchantCity("Somewhere");
    inv.setMerchantInfo (merchant);
	```

* `VATAXPERCENT` is now `VATTAXPERCENT`.  The following is an example of the change:

	`inv.setVatTaxAmt = new Currency(new decimal(5.00), "USD");`

#### New Objects:
* `MerchantInfo`.  This object holds the soft descriptor fields; such as, Merchant Name, Merchant City, etc. 
* `EchoData` to Invoice object, this parameter will allow you to "echo" back data in the response. See [Echo Data](https://developer.paypal.com/docs/payflow/integration-guide/submit-transactions/#echo-data).

* `ORDERID` as part of the Invoice object. Order ID is used to prevent duplicate "orders" from being processed.

	>This is NOT the same as Request ID; which is used at the transaction level.  Order ID (ORDERID) is used to check for a duplicate order in the future.  For example, if I pass ORDERID=10101 and in two weeks another order is processed with the same ORDERID, a duplicate condition will occur.  The results you receive will be from the original order with DUPLICATE=2 to show that it was ORDERID that triggered the duplicate. The order id is stored for 3 years.</br></br>Important Note: Order ID functionality to catch duplicate orders processed withing seconds of each other is limited.  Order ID should be used in conjunction with Request ID to prevent duplicates due to processing / communication errors. DO NOT use ORDERID as your only means to check for duplicate transactions.

#### New NVP Parameters:
Some of the NVPs listed below have been added in earlier builds, but are here for reference.

* `USER1` to `USER10` which is part of the `Invoice` object.  These can be returned in the response using the `EchoData` set to "User". See the enclosed DOSaleComplete sample for more information.
* Support for Magtek Encrypted Card Readers as part of the `Swipe` object.  Refer to DOEncryptedSwipe sample for more information.
* Processor-specific Response Parameters: `PAYMENTADVICECODE`, `ASSOCIATIONRESPCODE`, `TYPE`, `AFFLUENT`, `CCUPDATED`, `RRN`, `STAN`, `ACI` and `VALIDATIONCODE`.
* Location Transaction Advice Addendum Parameters: `MERCHANTLOCATIONID`, `MERCHANTID`, `MERCHANTCONTACTINFO`
* Response Parameters: `CCTRANSID`, `CCTRANS`_POSDATA`
* Request Parameters: `ADDLAMT`, `ADDLAMTTYPE`, `AUTHDATE`, `CATTYPE`, `CONTACTLESS`, `CUSTDATA`, `CUSTOMERID`, `CUSTOMERNUMBER`, `MERCHANTINVNUM`, `MERCHANTURL`, `MERCHANTVATNUM`, `MISCDATA`, `REPORTGROUP`, `VATINVNUM`, `VATTAXRATE`
* Request Line Item Parameters: `L_ALTTAXAMT`, `L_ALTTAXID`, `L_ALTTAXRATE`, `L_CARRIERSERVICESLEVELCODE`, `L-EXTAMT`
* `BUTTONSOURCE` to `BrowserInfo` object.
* Recurring Parameter: `FREQUENCY`
* Stored Credential Parameters: `CARDONFILE` (Request), `TXID` (Response) - See [Card on File](https://developer.paypal.com/docs/payflow/integration-guide/card-on-file/#supported-card-on-file-types).
* 3DS Parameters: `DSTRANSACTIONID` (Directory Server Transaction ID) and `THREEDSVersion` (3D-Secure Version) to the `BuyerAuthStatus` object. See [3-D Secure with 3rd-Party Merchant Plug-ins](https://developer.paypal.com/docs/payflow/3d-secure-mpi/).

### New Samples
* Data Upload (DODataUpload) under Samples/Misc to show how to use transaction type "L" allowing credit card data to be removed from local servers and stored at PayPal to be used via reference transactions.
