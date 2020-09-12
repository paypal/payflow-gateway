package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Authorize transaction using Swipe Data.
// The request is sent as a Data Object and the response received is also a Data Object.
// Payflow Pro supports card-present transactions (face-to-face purchases).
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
//	See the Payflow Pro Developer's Guide for more information.

public class DOSwipe {
	public DOSwipe() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOSwipe.java");
		System.out.println("------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		// DO NOT use payflow.verisign.com or test-payflow.verisign.com!
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Logging is by default off. To turn logging on uncomment the following lines:
		// SDKProperties.setLogFileName("payflow_java.log");
		// SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		// SDKProperties.setMaxLogFileSize(1000000);

		// Uncomment the lines below and set the proxy address and port, if a proxy has
		// to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(0);
		// SDKProperties.setProxyLogin("");
		// SDKProperties.setProxyPassword("");

		// Create the Data Objects.
		// Create the User data object with the required user details.
		UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

		// Create the Payflow Connection data object with the required connection
		// details.
		// The PAYFLOW_HOST are properties defined within SDKProperties.
		PayflowConnectionData connection = new PayflowConnectionData();

		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		Invoice inv = new Invoice();

		// Set Amount.
		Currency amt = new Currency(new Double(25.00), "USD");
		inv.setAmt(amt);
		inv.setPoNum("PO12345");
		inv.setInvNum("INV12345");

		// Create a new Payment Device - Swipe data object. The input parameter is Swipe
		// Data.
		// Used to pass the Track 1 or Track 2 data (the card's magnetic stripe
		// information) for card-present
		// transactions. Include either Track 1 or Track 2 data'not both. If Track 1 is
		// physically damaged,
		// the POS application can send Track 2 data instead.

		// The parameter data for the SwipeCard object is usually obtained with a card
		// reader.
		// NOTE: The SWIPE parameter is not supported on accounts where PayPal is the
		// Processor.
		SwipeCard swipe = new SwipeCard(";5105105105105100=15121011000012345678?");
		// Create a new Tender - Swipe Tender data object.
		CardTender card = new CardTender(swipe);

		// Create a new Sale Transaction.
		SaleTransaction trans = new SaleTransaction(user, connection, inv, card, PayflowUtility.getRequestId());

		// Submit the Transaction
		Response resp = trans.submitTransaction();

		// Display the transaction response parameters.
		if (resp != null) {
			// Get the Transaction Response parameters.
			TransactionResponse trxnResponse = resp.getTransactionResponse();

			// Create a new Client Information data object.
			ClientInfo clInfo = new ClientInfo();

			// Set the ClientInfo object of the transaction object.
			trans.setClientInfo(clInfo);

			if (trxnResponse != null) {
				System.out.println("RESULT = " + trxnResponse.getResult());
				System.out.println("PNREF = " + trxnResponse.getPnref());
				System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
				System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
				// If value is true, then the Request ID has not been changed and the original
				// response
				// of the original transction is returned.
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
		System.out.println("Press Enter to Exit ...");
	}
}
