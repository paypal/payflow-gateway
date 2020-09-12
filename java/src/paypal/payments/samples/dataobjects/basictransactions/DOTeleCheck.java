package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Telecheck - Sale transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOTeleCheck {
	public DOTeleCheck() {
	}

	public static void main(String args[]) {
		System.out.println("----------------------------------------------------------");
		System.out.println("Executing Sample from File: DOTeleCheck.java");
		System.out.println("----------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Logging is by default off. To turn logging on uncomment the following lines:
		SDKProperties.setLogFileName("payflow_java.log");
		SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		SDKProperties.setMaxLogFileSize(100000);

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
		inv.setCustIp("111.11.111.111");

		// Set the Billing Address details.
		BillTo bill = new BillTo();
		bill.setBillToStreet("123 Main St.");
		bill.setBillToZip("12345");
		bill.setBillToCity("New York");
		bill.setBillToState("PA");
		bill.setBillToCountry("US");
		bill.setBillToEmail("ivan@test.com");
		bill.setBillToPhone("1234567890");
		inv.setBillTo(bill);

		// Create a new Payment Device - Check Payment data object.
		// The input parameters is MICR. Magnetic Ink Check Reader. This is the entire
		// line
		// of numbers at the bottom of all checks. It includes the transit number,
		// account
		// number, and check number.
		CheckPayment ChkPayment = new CheckPayment("1234567804390850001001");
		// Name property needs to be set for the Check Payment.
		ChkPayment.setName("Ivan Smith");
		// Create a new Tender - Check Tender data object.
		CheckTender chkTender = new CheckTender(ChkPayment);
		// Account holder's next unused (available) check number. Up to 7 characters.
		chkTender.setChkNum("1234");
		// DL or SS is required for a TeleCheck transaction.
		// If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
		// If CHKTYPE=C, the Federal Tax ID must be passed as the SS value.
		chkTender.setChkType("P");
		// Driver's License number. If CHKTYPE=P, a value for either DL or SS must be
		// passed as an identifier.
		// Format: XXnnnnnnnn
		// XX = State Code
		// nnnnnnnn = DL Number - up to 31 characters.
		chkTender.setDL("CAN85452345");
		// Social Security number.
		chkTender.setSS("456765833");
		// AuthType = I-Internet Check, P-Checks by Phone, D-Prearranged Deposit
		chkTender.setAuthType("I");

		///////////////////////////////////////////////////////////////////

		// Create a new TeleCheck - Authorization Transaction.
		AuthorizationTransaction trans = new AuthorizationTransaction(user, connection, inv, chkTender,
				PayflowUtility.getRequestId());

		// Want VERBOSITY=HIGH to get all the response values back.
		trans.setVerbosity("HIGH");

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
				System.out.println("HOSTCODE = " + trxnResponse.getHostCode());
				System.out.println("TRACEID = " + trxnResponse.getTraceId());
				System.out.println("ACHSTATUS = " + trxnResponse.getAchStatus());
			}

			// Display the response.
			System.out.println(PayflowUtility.getStatus(resp) + "\n");
			// Get the Transaction Context and check for any contained SDK specific errors
			// (optional code).
			Context transCtx = resp.getContext();
			if (transCtx != null && transCtx.getErrorCount() > 0) {
				System.out.println("\nTransaction Errors = " + transCtx.toString());
			}

			if (trxnResponse.getResult() == 0) {
				// Transaction approved, display acceptance verbiage, after consumer accepts,
				// capture the
				// transaction to finalize it.
				CaptureTransaction capTrans = new CaptureTransaction(trxnResponse.getPnref(), user, connection, null,
						chkTender, PayflowUtility.getRequestId());
				// Set the transaction verbosity to HIGH to display most details.
				capTrans.setVerbosity("HIGH");

				// Submit the Transaction
				Response capResp = capTrans.submitTransaction();

				// Display the transaction response parameters.
				if (capResp != null) {
					// Get the Transaction Response parameters.
					TransactionResponse capTrxnResponse = capResp.getTransactionResponse();
					if (capTrxnResponse != null) {
						System.out.println("RESULT = " + capTrxnResponse.getResult());
						System.out.println("PNREF = " + capTrxnResponse.getPnref());
						System.out.println("RESPMSG = " + capTrxnResponse.getRespMsg());
						System.out.println("HOSTCODE = " + capTrxnResponse.getHostCode());
						System.out.println("TRACEID = " + capTrxnResponse.getTraceId());
					}
					// Display the response.
					System.out.println(PayflowUtility.getStatus(capResp) + "\n");

					// Get the Transaction Context and check for any contained SDK specific errors
					// (optional code).
					Context capTransCtx = capResp.getContext();
					if (capTransCtx != null && capTransCtx.getErrorCount() > 0) {
						System.out.println("Transaction Errors = " + capTransCtx + "\n");
					}
				} else {
					System.out.println("Unable to capture transaction as it declined or failed." + "\n");
				}
			}
		}
	}
}
