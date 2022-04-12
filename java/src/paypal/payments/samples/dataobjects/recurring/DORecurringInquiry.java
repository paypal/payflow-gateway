package paypal.payments.samples.dataobjects.recurring;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a Recurring Inquiry transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DORecurringInquiry {
	public DORecurringInquiry() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DORecurringInquiry.java");
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
		SDKProperties.setMaxLogFileSize(1000000);
		// SDKProperties.setStackTraceOn(true);

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
		recurInfo.setOrigProfileId("<profile_id>"); // Example: RP0000000012
		// To show payment history instead of Profile details.
		recurInfo.setPaymentHistory("N");
		///////////////////////////////////////////////////////////////////

		// Create a new Recurring Inquiry Transaction.
		RecurringInquiryTransaction trans = new RecurringInquiryTransaction(user, connection, recurInfo,
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
			}

			// Get the Recurring Response parameters.
			RecurringResponse recurResponse = resp.getRecurringResponse();
			if (recurResponse != null) {

				System.out.println("RPREF = " + recurResponse.getRpRef());
				System.out.println("PROFILEID = " + recurResponse.getProfileId());
				// Show profile details.  These are not all the values available.
				if (recurResponse.getInquiryParams().isEmpty()) {
					System.out.println("STATUS = " + recurResponse.getStatus());
					System.out.println("PROFILENAME = " + recurResponse.getProfileName());
					System.out.println("CREATIONDATE = " + recurResponse.getCreationDate());
					System.out.println("LASTCHANGED = " + recurResponse.getLastChanged());
					System.out.println("START = " + recurResponse.getStart());
					System.out.println("TERM = " + recurResponse.getTerm());
					System.out.println("PAYNMENTSLEFT = " + recurResponse.getPaymentsLeft());
					System.out.println("NEXTPAYMENT = " + recurResponse.getNextPayment());
					System.out.println("NEXTPAYMENTNUM = " + recurResponse.getNextPaymentNumber());
					System.out.println("PAYPERIOD = " + recurResponse.getPayPeriod());
					System.out.println("RPSTATE = " + recurResponse.getRpState());
					System.out.println("FREQUENCY = " + recurResponse.getFrequency());
					System.out.println("TENDER = " + recurResponse.getTender());
					System.out.println("AMT = " + recurResponse.getAmt());
					System.out.println("CURRENCY = " + recurResponse.getCurrency());
					System.out.println("ACCT = " + recurResponse.getAcct());
					System.out.println("EXPDATE = " + recurResponse.getExpDate());
					System.out.println("AGGREGATEAMT = " + recurResponse.getAggregateAmt());
					System.out.println("AGGREGATEOPTIONALAMT = " + recurResponse.getAggregateOptionalAmt());
					System.out.println("MAXFAILPAYMENTS = " + recurResponse.getMaxFailPayments());
					System.out.println("NUMFAILPAYMENTS = " + recurResponse.getNumFailPayments());
					System.out.println("RETRYNUMDAYS = " + recurResponse.getRetryNumDays());
					System.out.println("END = " + recurResponse.getEnd());
					System.out.println("FIRSTNAME = " + recurResponse.getName());
					System.out.println("LASTNAME = " + recurResponse.getLastname());
					System.out.println("STREET = " + recurResponse.getStreet());
					System.out.println("CITY = " + recurResponse.getCity());
					System.out.println("ZIP = " + recurResponse.getZip());
					System.out.println("PHONENUM = " + recurResponse.getPhoneNum());
					System.out.println("EMAIL = " + recurResponse.getEmail());
				} else {
					// Display the Payment History instead of Profile data.
					// Payment History is stored in the HASHTABLE RecurResponse.InquiryParams.
					// PAYMENTHISTORY = Y
					System.out.println("INQUIRY PARAMS");
					int x = 1;
					double a;
					int t;
					while (recurResponse.getInquiryParams().get("P_PNREF" + x) != null) {
						if (recurResponse.getInquiryParams().get("P_AMT" + x) != null) {
							a = Double.parseDouble(recurResponse.getInquiryParams().get("P_AMT" + x).toString());
						} else {
							a = 0;
						}
						if (recurResponse.getInquiryParams().get("P_TRANSTATE" + x) != null) {
							t = Integer.parseInt(recurResponse.getInquiryParams().get("P_TRANSTATE" + x).toString());
						} else {
							t = 0;
						}
						System.out.println(formati(x, 4) + " | PNREF: "
								+ (recurResponse.getInquiryParams().get("P_PNREF" + x) + " | RESULT: "
										+ recurResponse.getInquiryParams().get("P_RESULT" + x) + " | TRANSTIME: "
										+ recurResponse.getInquiryParams().get("P_TRANSTIME" + x) + " | AMOUNT: "
										+ formatd(a, 2, 10) + " | TRANSTATE: " + formati(t, 4) + " | TENDER: "
										+ recurResponse.getInquiryParams().get("P_TENDER" + x)));
						x++;
					}
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

	static final String ZEROES = "000000000000";
	static final String BLANKS = "            ";

	static String formatd(double val, int n, int w) {
//	rounding
		// double incr = 0.5;
		// for (int j = n; j > 0; j--) incr /= 10;
		// val += incr;

		String s = Double.toString(val);
		int n1 = s.indexOf('.');
		int n2 = s.length() - n1 - 1;

		if (n > n2)
			s = s + ZEROES.substring(0, n - n2);
		else if (n2 > n)
			s = s.substring(0, n1 + n + 1);

		if (w > 0 & w > s.length())
			s = BLANKS.substring(0, w - s.length()) + s;
		else if (w < 0 & (-w) > s.length()) {
			w = -w;
			s = s + BLANKS.substring(0, w - s.length());
		}
		return s;
	}

	static String formati(int val, int w) {

		String s = Integer.toString(val);

		if (w > 0 & w > s.length())
			s = BLANKS.substring(0, w - s.length()) + s;
		else if (w < 0 & (-w) > s.length()) {
			w = -w;
			s = s + BLANKS.substring(0, w - s.length());
		}
		return s;
	}
}