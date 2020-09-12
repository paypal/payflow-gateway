package paypal.payments.samples.namevaluepairs;

import paypal.payflow.*;

public class NVPSale {

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: NVPSale.java");
		System.out.println("------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		// DO NOT use payflow.verisign.com or test-payflow.verisign.com!
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Uncomment the lines below and set the proxy address and port, if a proxy has
		// to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(0);
		// SDKProperties.setProxyLogin("");
		// SDKProperties.setProxyPassword("");

		// Logging is by default off. To turn logging on uncomment the following lines:
		// SDKProperties.setLogFileName("payflow_java.log");
		// SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		// SDKProperties.setMaxLogFileSize(1000000);
		// Log Stack Traces (boolean)
		// SDKProperties.setStackTraceOn(true);

		// Create an instance of PayflowAPI.
		PayflowAPI pa = new PayflowAPI();

		// Sample Request.
		// Please replace <user>, <vendor>, <password> & <partner> with your merchant
		// information.
		String request = "USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>&TRXTYPE=S&ACCT=5100000000000008&EXPDATE=0119&TENDER=C&INVNUM=INV12345&PONUM=PO12345&STREET=123 Main St.&ZIP=12345&AMT=12.25&CVV2=123&VERBOSITY=HIGH";

		// RequestId is a unique string that is required for each & every transaction.
		// The merchant can use her/his own algorithm to generate this unique request id
		// or
		// use the SDK provided API to generate this as shown below
		// (PayflowAPI.generateRequestId).
		// NOTE: Review the comments in the DoSaleComplete example under
		// BasicTransactions for
		// more information on the Request ID.
		String requestId = pa.generateRequestId();

		String response = pa.submitTransaction(request, requestId);

		System.out.println("Transaction Request :\n-------------------- \n" + request);
		System.out.println("Transaction Response :\n-------------------- \n" + response);

		// Following lines of code are optional.
		// Begin optional code for displaying SDK errors ...
		// It is used to read any errors that might have occurred in the SDK.
		// Get the transaction errors.

		String transErrors = pa.getTransactionContext().toString();
		if (transErrors != null && transErrors.length() > 0) {
			System.out.println("Transaction Errors from SDK = \n" + transErrors);
		}
	}
}