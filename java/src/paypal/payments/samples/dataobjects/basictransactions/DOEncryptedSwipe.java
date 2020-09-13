package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Authorize transaction using Encrypted Swipe Data
// from card readers by Magtek, http://www.magtek.com.
//
// The request is sent as a Data Object and the response received is also a Data Object.
// Payflow Pro supports card-present transactions (face-to-face purchases).
//
// Follow these guidelines to take advantage of the lower card-present transaction rate:
//
//		* Contact your merchant account provider to ensure that they support card-present transactions.
//		* Contact PayPal Customer Service to request having your account set up properly for accepting and passing
//		  swipe data.
//		* If you plan to process card-present as well as card-not-present transactions, set up two separate Payflow
//		  Pro accounts.  Request that one account be set up for card-present transactions, and use it solely for that
//		  purpose. Use the other for card-not-present transactions. Using the wrong account may result in downgrades.
//		* A Sale is the preferred method to use for card-present transactions. Consult with your acquiring bank for
//		  recommendations on other methods.
//
//	NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.  This would include Website
//	      Payments Pro UK accounts.
//
//	See the Payflow Gateway Developer Guide and Reference at https://developer.paypal.com/docs/classic/payflow/integration-guide for more information.

public class DOEncryptedSwipe {
	public DOEncryptedSwipe() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOEncryptedSwipe.java");
		System.out.println("------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Logging is by default off. To turn logging on uncomment the following lines:
		// SDKProperties.setLogFileName("payflow_java.log");
		// SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		// SDKProperties.setMaxLogFileSize(1000000);

		// Uncomment the lines below and set the proxy address and port, if a proxy has to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(80);
		// SDKProperties.setProxyLogin("");
		// SDKProperties.setProxyPassword("");

		// Create the Data Objects.
		// Create the User data object with the required user details.
		UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

		// Create the Payflow Connection data object with the required connection
		// details.
		PayflowConnectionData connection = new PayflowConnectionData();

		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		Invoice inv = new Invoice();

		// Set Amount.
		Currency amt = new Currency(new Double(25.12));
		inv.setAmt(amt);
		inv.setPoNum("PO12345");
		inv.setInvNum("INV12345");

		// Set the Billing Address details.
		BillTo bill = new BillTo();
		bill.setBillToStreet("123 Main St.");
		bill.setBillToZip("12345");
		inv.setBillTo(bill);

		// Create a new Payment Device - Swipe data object.  The input parameter is Swipe Data.
		// The data passed in this example will be extracted from a Magtek Encrypted Card reader.  Please refer
		// to the Magtek SDK and documentation on how to obtain the data from the reader.
		// The parameter data for the SwipeCard object is usually obtained with a card reader and this shows
		// how to send data obtained from a Magtek Encrypted reader.
		// NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.

		// Create a new Magtek data object with the device serial number, track data, etc.
		MagTekInfo mT = new MagTekInfo();

		// The data below CANNOT be used for Testing. It is only here to show what the data fields look like once you
		// obtain them from the reader itself.  Refer to the Payflow Pro Developers Guide and the Appendix related to processing
		// with Magtek card readers for more information.
		// The Payflow Gateway Developer Guide and Reference found at https://developer.paypal.com/docs/classic/payflow/integration-guide/
		mT.setDeviceSN("B32XXXXXXXXXXAA");
		mT.setEncMP("34F29380E6AFED395472A63063B6XXXXXXXXXXXXXXXXXXXXXXXXXC987D2A1F7A50554DFC4A0D215A8AA0591D82B6DB13516F220C4CB93899");
		mT.setEncryptionBlockType("1");
		mT.setEncTrack1("80BC13515EF76421FCXXXXXXXXXXXXXXXXXXXXXXXXX02E53C0ECCC83B1787DE05BB5D8C7FA679D0C40CC989F7FAF307FE7FD0B588261DDA0");
		mT.setEncTrack2("4CDD6BC521B397CD2DB1324199XXXXXXXXXXXXXXXXXXXXXXXXX83A9044B397C1D14AFEE2C0BA1002");
		mT.setEncTrack3("");
		mT.setKsn("901188XXXXXXXXXX00F4");
		mT.setMagtekCardType("1");
		mT.setMpStatus("61403000");
		mT.setRegisteredBy("PayPal");
		mT.setSwipedECRHost("MAGT");

		// When using Encrypted Card Readers you do not populate the SwipeCard object as the data from the Magtek object
		// will be used instead.
		SwipeCard swipe = new SwipeCard("");
		swipe.getMagTek(mT);

		// Create a new Tender - Swipe  Tender data object.
		CardTender card = new CardTender(swipe);
		///////////////////////////////////////////////////////////////////

		// Create a new Sale Transaction.
		SaleTransaction trans = new SaleTransaction(user, connection, inv, card, PayflowUtility.getRequestId());

		// Submit the Transaction
		Response resp = trans.submitTransaction();

		// Display the transaction response parameters.
		if (resp != null) {
			// Get the Transaction Response parameters.
			TransactionResponse trxnResponse = resp.getTransactionResponse();

			if (trxnResponse != null) {

				System.out.println("RESULT = " + trxnResponse.getResult());
				System.out.println("PNREF = " + trxnResponse.getPnref());
				System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
				System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
				// Magtek Response will only be available if a failure or error in the request.
				System.out.println("MAGTRESPONSE = " + trxnResponse.getMagTResponse());
				// If value is true, then the Request ID has not been changed and the original
				// response of the original transaction is returned.
				System.out.println("DUPLICATE = " + trxnResponse.getDuplicate());
			}

			// Display the response.
			System.out.println("\n" + PayflowUtility.getStatus(resp));

			// Get the Transaction Context and check for any contained SDK specific errors
			// (optional code).
			Context transCtx = resp.getContext();
			if (transCtx != null && transCtx.getErrorCount() > 0) {
				System.out.println("\nTransaction Errors = " + transCtx.toString());
			}
		}
	}
}
