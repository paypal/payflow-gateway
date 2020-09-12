package paypal.payments.samples.dataobjects.misc;

import paypal.payflow.*;

// To assist is providing a PCI compliant solution, PayPal now allows a you to upload your
// existing credit card data using a new transaction type.  As the data is uploaded, a
// transaction id (PNREF) will be generated that can be stored locally to perform a Reference
// Transaction (tokenization).  This allows you to remove all credit card data from your
// local servers.  For more information regarding Reference Transactions review the section in
// the Payflow Developer's Guide.
//
// The transaction type value is "L" which allows the credit card data to be sent and stored
// without being sent to the banks for processing.  You must send at miminum the following
// items: TRXTYPE, TENDER, ACCT and EXPDATE.
//
// As you can see, you can send in Billing and Shipping information to be stored, but you must
// not include the AMT field.  If AMT is passed you will receive a RESULT=4, RESPMSG=Invalid Amount error.
///
// IMPORTANT:  The credit card data sent for storage is not verified in any way as it is not
// sent to the banks for processing.  To validate a transaction, you would do an account
// verification; also known as a, zero dollar authorization, type transaction.
//
// NOTE:  This is processor dependent and not all processors support this feature.
//
// For Reference transactions, please use ReferenceTransaction class and for Recurring use
// RecurringTransaction base class.

public class DODataUpload {
	public DODataUpload() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DODataUpload.java");
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
		// SDKProperties.setMaxLogFileSize(100000);

		// Uncomment the lines below and set the proxy address and port, if a proxy has
		// to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(0);

		// Create the Data Objects.
		// Create the User data object with the required user details.
		UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

		// Create the Payflow Connection data object with the required connection
		// details.
		PayflowConnectionData connection = new PayflowConnectionData();

		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		Invoice inv = new Invoice();

		// Remember, we do not send in an amount.

		// Set the Billing Address details.
		BillTo bill = new BillTo();
		bill.setBillToStreet("123 Main St.");
		bill.setBillToZip("12345");
		// Set the BillTo object into invoice.
		inv.setBillTo(bill);

		// Create a new Payment Device - Credit Card data object.
		// The input parameters are Credit Card Number and Expiration Date of the Credit
		// Card.
		CreditCard CC = new CreditCard("5105105105105100", "0115");

		// Create a new Tender - Card Tender data object.
		CardTender Card = new CardTender(CC);

		// Create a new Base Transaction.
		BaseTransaction trans = new BaseTransaction("L", user, connection, inv, Card, PayflowUtility.getRequestId());

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
				System.out.println("TRANSTIME = " + trxnResponse.getTransTime());
				System.out.println("RESULT = " + trxnResponse.getResult());
				System.out.println("PNREF = " + trxnResponse.getPnref());
				System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
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
