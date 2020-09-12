package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do an Inquiry transaction.
//
// You perform an inquiry using a reference to an original transaction'either the PNREF
// value returned for the original transaction or the CUSTREF value that you specified for the original
// transaction.
//
// While the amount of information returned in an Inquiry transaction depends upon the VERBOSITY setting,
// Inquiry responses mimic the verbosity level of the original transaction as much as possible.
//
// Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
// processor vary in detail level and in format. The Payflow Pro Verbosity parameter enables you to control
// the kind and level of information you want returned.  By default, Verbosity is set to LOW.
// A LOW setting causes PayPal to normalize the transaction result values. Normalizing the values limits
// them to a standardized set of values and simplifies the process of integrating Payflow Pro.
// By setting Verbosity to MEDIUM, you can view the processor?s raw response values. This setting is more
// "verbose" than the LOW setting in that it returns more detailed, processor-specific information.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOInquiry {
	public DOInquiry() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOInquiry.java");
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

		// Create a new Inquiry Transaction.
		// Replace <PNREF> with a previous transaction ID that you processed on your
		// account.
		InquiryTransaction trans = new InquiryTransaction("<PNREF>", user, connection, PayflowUtility.getRequestId());

		// To use CUSTREF instead of PNREF you need to set the CustRef and include the
		// INVOICE object in your
		// request. Since you will be using CUSTREF instead of PNREF, PNREF will be ""
		// (null).
		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		// Invoice inv = new Invoice();
		// inv.setCustRef("CUSTREF1");
		// InquiryTransaction trans = new InquiryTransaction("", user, connection, inv,
		// PayflowUtility.getRequestId());

		// Refer to the Payflow Pro Developer's Guide for more information regarding the
		// parameters returned
		// when VERBOSITY is set.
		trans.setVerbosity("LOW"); // Change VERBOSITY to MEDIUM to display additional information.

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
				System.out.println("--------------------------------------------");
				System.out.println("Original Response Data");
				System.out.println("--------------------------------------------");
				if ("LOW".equals(trans.getVerbosity().toUpperCase())) {
					System.out.println("RESULT = " + trxnResponse.getOrigResult());
					System.out.println("PNREF = " + trxnResponse.getOrigPnref());
					System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
					System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
					System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
					System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
					System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
					System.out.println("IAVS = " + trxnResponse.getIavs());
					System.out.println("CARDSECURE = " + trxnResponse.getProcCardSecure());
				} else if ("MEDIUM".equals(trans.getVerbosity().toUpperCase())) {
					System.out.println("RESULT = " + trxnResponse.getOrigResult());
					System.out.println("PNREF = " + trxnResponse.getOrigPnref());
					System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
					System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
					System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
					System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
					System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
					System.out.println("IAVS = " + trxnResponse.getIavs());
					System.out.println("CARDSECURE = " + trxnResponse.getProcCardSecure());
					System.out.println("HOSTCODE = " + trxnResponse.getHostCode());
					System.out.println("RESPTEXT = " + trxnResponse.getRespText());
					System.out.println("PROCAVS = " + trxnResponse.getProcAvs());
					System.out.println("PROCCVV2 = " + trxnResponse.getProcCVV2());
					System.out.println("ADDLMSGS = " + trxnResponse.getAddlMsgs());
					System.out.println("TRANSSTATE = " + trxnResponse.getTransState());
					System.out.println("DATE_TO_SETTLE = " + trxnResponse.getDateToSettle());
					System.out.println("BATCHID = " + trxnResponse.getBatchId());
					System.out.println("SETTLE_DATE = " + trxnResponse.getSettleDate());
				}
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
