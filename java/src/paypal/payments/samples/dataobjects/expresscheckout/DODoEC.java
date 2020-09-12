package paypal.payments.samples.dataobjects.expresscheckout;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a normal DO Express Checkout transaction.
// The request is sent as a Data Object and the response received is also a Data Object.
//
// This sample is for reference and for testing purposes only.  See the eStoreFront sample for
// one way to perform an Express Checkout transaction from your web site.
//
// Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developer's
// Guide (US, AU) or the Websites Payments Pro Payflow Edition Developer's Guide (UK).
//
// Besides doing a standard Express Checkout transactions, you can also do a Express Checkout Reference
// Transaction.
//
// A reference transaction takes existing billing information already gathered from a previously
// authorized transaction and reuses it to charge the customer in a subsequent transaction.
// Reference transactions, typically used for repeat billing to a merchants PayPal account when
// customers are not present to log in, are now supported through Express Checkout.
//
// NOTE: You must be enabled by PayPal to use reference transactions.  Contact your account manager
// or the sales department for more details.
//
// See the DOSetEC Sample for more details on Reference Transations using Express Checkout.

public class DODoEC {
	public DODoEC() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DODoEC.cs");
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

		// Create the Data Objects.
		// Create the User data object with the required user details.
		UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

		// Create the Payflow Connection data object with the required connection
		// details.
		// The PAYFLOW_HOST property is defined in the App config file.
		PayflowConnectionData Connection = new PayflowConnectionData();

		// Once the customer has reviewed the shipping details and decides to continue
		// checkout by clicking on "Continue Checkout" button, it's time to actually
		// authorize the transaction.
		// This is the third step in PayPal Express Checkout, in which you need to
		// perform a
		// DO operation to authorize the purchase amount.
		//
		// For more information on Reference Transactions, see the DOSetEC Sample for
		// more details.

		// For Regular Express Checkout or Express Checkout Reference Transaction with
		// Purchase.
		// ECDoRequest doRequest = new ECDoRequest("<TOKEN>", "<PAYERID>");
		ECDoRequest doRequest = new ECDoRequest("EC-7GF96160AD060941R", "9A7GVVKMK64FS");

		// For Express Checkout Reference Transaction without Purchase.
		// ECDoBARequest doRequest = new ECDoBARequest("<TOKEN>", "<PAYERID>");

		// Performing a Reference Transaction, Do Authorization or Re Doauthorization
		// These transactions do not require a token or payerid. Additional fields
		// are set using the ExtendData, ECDoRequest or AuthorizationTransaction
		// objects, see below.
		// ECDoRequest doRequest = new ECDoRequest("", "");

		// Perform a Do Reauthorization
		// To reauthorize an Authorization for an additional three-day honor period, you
		// can use a Do
		// Reauthorization transaction. A Do Reauthorization can be used at most once
		// during the 29-day
		// authorization period.
		// To set up a Do Reauthorization, you must pass ORIGID in the
		// AuthorizationTransaction object
		// and set DoReauthorization to 1.
		// doRequest.setDoReauthorization("1");

		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		Invoice inv = new Invoice();
		// Set Amount.
		Currency amt = new Currency(new Double(15.00));
		inv.setAmt(amt);
		inv.setComment1("Testing Express Checkout");

		// **** PayPal Pay Later Service ****
		// See DoSetEC.java for information on PayPal's Pay Later Service.

		// Create the Tender object.
		PayPalTender paypalTender = new PayPalTender(doRequest);

		// Create the transaction object.

		AuthorizationTransaction Trans = new AuthorizationTransaction(user, Connection, inv, paypalTender,
				PayflowUtility.getRequestId());

		// Using a Reference Transaction
		// To be able to "charge" a customer using their Billing Agreement you will need
		// to pass the BAID
		// and other parameters via the ExtendData Object.
		// ExtendData extData = new ExtendData("BAID", "<BAID>");
		// Trans.setExtData(extData);
		// ExtendData captureComplete = new ExtendData("CAPTURECOMPLETE", "NO");
		// Trans.setExtData(captureComplete);
		// ExtendData maxAmt = new ExtendData("MAXAMT", "15.00");
		// Trans.setExtData(maxAmt);

		// Submit the transaction.
		Response Resp = Trans.submitTransaction();

		// Display the transaction response parameters.
		if (Resp != null) {
			// Get the Transaction Response parameters.
			TransactionResponse TrxnResponse = Resp.getTransactionResponse();

			if (TrxnResponse != null) {
				System.out.println("RESULT = " + TrxnResponse.getResult());
				System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
				System.out.println("PNREF = " + TrxnResponse.getPnref());
				System.out.println("PPREF = " + TrxnResponse.getPPRef());
				System.out.println("TOKEN = " + Trans.getResponse().getEcSetResponse().getToken());
				System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
				System.out.println("PAYERID = " + Trans.getResponse().getEcGetResponse().getPayerId());
				System.out.println("PAYMENTTYPE = " + Trans.getResponse().getTransactionResponse().getPaymentType());
				System.out
						.println("PENDINGREASON = " + Trans.getResponse().getTransactionResponse().getPendingReason());
				System.out.println("BAID = " + Trans.getResponse().getEcDoResponse().getbaId());
				System.out.println("");
			}
			// If value is true, then the Request ID has not been changed and the original
			// response
			// of the original transction is returned.
			System.out.println();
			System.out.println("DUPLICATE = " + TrxnResponse.getDuplicate());
		}

		// Display the response.
		System.out.println();
		System.out.println(PayflowUtility.getStatus(Resp));

		// Get the Transaction Context and check for any contained SDK specific errors
		// (optional code).
		Context TransCtx = Resp.getContext();
		if (TransCtx != null && TransCtx.getErrorCount() > 0) {
			System.out.println();
			System.out.println("Transaction Errors = " + TransCtx.toString());
		}
	}
}
