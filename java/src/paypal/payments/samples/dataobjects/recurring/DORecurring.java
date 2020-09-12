package paypal.payments.samples.dataobjects.recurring;

import paypal.payflow.*;

// This class uses the Payflow SDK Recurring Transaction object to do a simple Recurring Add transaction.
// The request is sent as a Data Object and the response received is also a Data Object.
// The Recurring Transaction object should be used be used only in a remote scenario when the user
// needs to do a recurring transaction type which is not directly supported by the transaction objects
// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in
// terms of specifying the transaction type (TRXTYPE).
// For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction
// base class.

public class DORecurring {
	public DORecurring() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DORecurring.java");
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

		// Create a new Payment Device - Credit Card data object.
		// The input parameters are Credit Card No. and Expiry Date for the Credit Card.
		CreditCard cc = new CreditCard("5105105105105100", "0109");
		cc.setCvv2("123");

		// Create a new Tender - Card Tender data object.
		CardTender card = new CardTender(cc);
		///////////////////////////////////////////////////////////////////

		RecurringInfo recurInfo = new RecurringInfo();
		// The date that the first payment will be processed.
		// This will be of the format mmddyyyy.
		recurInfo.setStart("01012009");
		recurInfo.setProfileName("PayPal");
		// Specifies how often the payment occurs. All PAYPERIOD values must use
		// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		// QTER / SMYR / YEAR
		recurInfo.setPayPeriod("WEEK");
		///////////////////////////////////////////////////////////////////

		// Create a new Recurring Transaction.
		RecurringTransaction trans = new RecurringTransaction("A", recurInfo, user, connection, inv, card,
				PayflowUtility.getRequestId());

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
				System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
			}

			// Get the Recurring Response parameters.
			RecurringResponse recurResponse = resp.getRecurringResponse();
			if (recurResponse != null) {
				System.out.println("RPREF = " + recurResponse.getRpRef());
				System.out.println("PROFILEID = " + recurResponse.getProfileId());
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
