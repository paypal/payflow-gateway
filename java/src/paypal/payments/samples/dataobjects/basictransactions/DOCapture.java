package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Capture transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOCapture {
	public DOCapture() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOCapture.java");
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
		///////////////////////////////////////////////////////////////////

		// If you want to change the amount being captured, you'll need to set the
		// Amount object.
		// Invoice inv = new Invoice();
		// Set the amount object if you want to change the amount from the original
		// authorization.
		// Currency Code USD is US ISO currency code. If no code passed, USD is default.
		// See the Developer//s Guide for the list of three-character currency codes
		// available.
		// Currency amt = new Currency(new Double(25.12));
		// inv.setAmt(amt);
		// CaptureTransaction Trans = new CaptureTransaction("<ORIGINAL_PNREF>", User,
		// Connection, Inv, PayflowUtility.RequestId);

		// Create a new Capture Transaction for the original amount of the
		// authorization. See above if you
		// need to change the amount.
		CaptureTransaction trans = new CaptureTransaction("<ORIGINAL_PNREF>", user, connection,
				PayflowUtility.getRequestId());
		// Indicates if this Delayed Capture transaction is the last capture you intend
		// to make.
		// The values are: Y (default) / N
		// NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original
		// reauthorized transaction
		// is automatically voided. Also, this is only used for UK and US accounts where
		// PayPal is acting
		// as your bank.
		// trans.setcaptureComplete("Y");

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
				System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
				System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
				System.out.println("IAVS = " + trxnResponse.getIavs());
				// If value is true, then the Request ID has not been changed and the original
				// response
				// of the original transction is returned.
				System.out.println("DUPLICATE = " + trxnResponse.getDuplicate());
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
