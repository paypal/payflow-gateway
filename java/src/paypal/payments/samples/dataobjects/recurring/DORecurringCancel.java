package paypal.payments.samples.dataobjects.recurring;

import paypal.payflow.*;

/// This class uses the Payflow SDK Data Objects to do a Recurring Cancel transaction.
/// The request is sent as a Data Object and the response received is also a Data Object.

public class DORecurringCancel {
	public DORecurringCancel() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DORecurringCancel.java");
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

		RecurringInfo recurInfo = new RecurringInfo();
		recurInfo.setOrigProfileId("RT0000001350");
		///////////////////////////////////////////////////////////////////

		// Create a new Recurring Cancel Transaction.
		RecurringCancelTransaction trans = new RecurringCancelTransaction(user, connection, recurInfo,
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
