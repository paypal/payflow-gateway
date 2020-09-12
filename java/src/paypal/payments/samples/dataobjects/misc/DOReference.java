package paypal.payments.samples.dataobjects.misc;

import paypal.payflow.*;

// This class uses the Payflow SDK Reference Transaction object to do a Sale transaction.
// The request is sent as a Data Object and the response received is also a Data Object.
// The Reference Transaction object should be used be used only in a remote scenario when the user
// needs to do a reference transaction type which is not directly supported by the transaction objects
// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in
// terms of specifying the transaction type (TRXTYPE).
// For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction
// base class.

public class DOReference {
	public DOReference() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOReference.java");
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

		// Create a new Tender - Base Tender data object and set the Tender Type to "C".
		// We do not pass any payment device
		BaseTender tender = new BaseTender("C", null);

		// Create a new Reference Transaction.
		ReferenceTransaction trans = new ReferenceTransaction("S", "<origId>", user, connection, inv, tender,
				PayflowUtility.getRequestId());

		// Should you need to change the expiration date of the new reference
		// transaction, you
		// can do so, by passing the EXPDATE via the ExtendData object.
		// ExtendData expDate = new ExtendData("EXPDATE", "1212>");
		// trans.setExtData(expDate);

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
				System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
				System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
				System.out.println("IAVS = " + trxnResponse.getIavs());
				System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
			}

			// Get the Fraud Response parameters.
			FraudResponse fraudResp = resp.getFraudResponse();
			if (fraudResp != null) {
				System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
				System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
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
