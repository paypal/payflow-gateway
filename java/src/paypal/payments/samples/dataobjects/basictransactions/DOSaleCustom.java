package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Sale transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOSaleCustom {
	public DOSaleCustom() {
	}

	public static SaleTransaction createTransaction(PayflowConnectionData connection, String po, String invoice,
			double amount) {
		// Create the Data Objects.
		// Create the User data object with the required user details.
		UserInfo user = new UserInfo("toddprov4", "toddprov4", "VeriSign", "toddprov41");

		// Create a new Invoice data object with the Amount, Billing Address etc.
		// details.
		Invoice inv = new Invoice();

		// Set Amount.
		Currency amt = new Currency(amount, "USD");
		inv.setAmt(amt);
		inv.setPoNum(po);
		inv.setInvNum(invoice);

		// Set the Billing Address details.
		BillTo bill = new BillTo();
		// bill.setStreet("123 Main St.");
		// bill.setZip("12345");
		bill.setBillToStreet("123 Main St.");
		bill.setBillToZip("12345");

		inv.setBillTo(bill);

		// Create a new Payment Device - Credit Card data object.
		// The input parameters are Credit Card No. and Expiry Date for the Credit Card.
		CreditCard cc = new CreditCard("4111111111111111", "0918");
		cc.setCvv2("027");

		// Create a new Tender - Card Tender data object.
		CardTender card = new CardTender(cc);

		// Create a new Sale Transaction.
		SaleTransaction trans = new SaleTransaction(user, connection, inv, card, PayflowUtility.getRequestId());
		return trans;
	}

	public static void submitTransaction(SaleTransaction tx) {
		// Submit the Transaction
		Response resp = tx.submitTransaction();

		// Display the transaction response parameters.
		if (resp != null) {
			// Get the Transaction Response parameters.
			TransactionResponse trxnResponse = resp.getTransactionResponse();

			// Create a new Client Information data object.
			ClientInfo clInfo = new ClientInfo();

			// Set the ClientInfo object of the transaction object.
			tx.setClientInfo(clInfo);

			if (trxnResponse != null) {
				System.out.println("*** RequestId = " + tx.getRequestId());
				System.out.println("RESULT = " + trxnResponse.getResult());
				System.out.println("PNREF = " + trxnResponse.getPnref());
				System.out.println("PPREF = " + trxnResponse.getPPRef());
				System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
				System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
				System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
				System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
				System.out.println("IAVS = " + trxnResponse.getIavs());
				System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
				System.out.println("PROCCVV2 = " + trxnResponse.getProcCVV2());

				// If value is true, then the Request ID has not been changed and the original
				// response
				// of the original transaction is returned.
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

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOSaleCustom.java");
		System.out.println("------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		// DO NOT use payflow.verisign.com or test-payflow.verisign.com!
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Logging is by default off. To turn logging on uncomment the following lines:
		SDKProperties.setLogFileName("payflow_java.log");
		SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		SDKProperties.setMaxLogFileSize(100000);
		SDKProperties.setStackTraceOn(true);

		// Create the Payflow Connection data object with the required connection
		// details.
		// The PAYFLOW_HOST are properties defined within SDKProperties.
		PayflowConnectionData connection = new PayflowConnectionData();

		SaleTransaction tx1 = createTransaction(connection, "PO12350", "INV51032", 25.00);
		System.out.println("tx1: RequestId = " + tx1.getRequestId() + " Initial creation");

		SaleTransaction tx2 = createTransaction(connection, "PO12350", "INV510033", 50.00);
		System.out.println("tx1: RequestId = " + tx1.getRequestId() + " After tx2 created");
		System.out.println("tx2: RequestId = " + tx2.getRequestId() + " Initial creation");
		System.out.println("");

		submitTransaction(tx1);
		submitTransaction(tx2);
	}
}
