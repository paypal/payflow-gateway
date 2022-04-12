package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Sale transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOSaleComplete {
	public DOSaleComplete() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOSaleComplete.java");
		System.out.println("------------------------------------------------------");

		/*
		 * This sample does not include all the available parameters available; however,
		 * it gives you a general idea of the most common ones.
		 */

		/*
		 * NOTE: All information regarding the available objects within payflow_jar can
		 * be found in the API doc found under the "Docs" directory of the installed
		 * SDK. You will also need to refer to the Payflow Gateway Developer's Guide
		 * found at https://developer.paypal.com/docs/classic/payflow/integration-guide.
		 * 
		 * Request ID: the request Id is a unique id that you send with your transaction
		 * data. This Id if not changed will help prevent duplicate transactions. The
		 * idea is to set this Id outside the loop or if on a page, prior to the final
		 * confirmation page.
		 * 
		 * Once the transaction is sent and if you don't receive a response you can
		 * resend the transaction and the server will respond with the response data of
		 * the original submission. Also, the object,
		 * Trans.Response.TransactionResponse.Duplicate will be set to "1" if the
		 * transaction is a duplicate.
		 * 
		 * This allows you to resend transaction requests should there be a network or
		 * user issue without re-charging a customers credit card.
		 * 
		 * COMMON ISSUES:
		 * 
		 * Result Code 1: Is usually caused by one of the following: Invalid login
		 * information, see result code 26 below. IP Restrictions on the account. Verify
		 * there are no ip restrictions in Manager under Service Settings.
		 * 
		 * Result Code 26: Verify USER, VENDOR, PARTNER and PASSWORD. Remember, USER and
		 * VENDOR are both the merchant login ID unless a Payflow Pro USER was created.
		 * All fields are case-sensitive. See this post for more information:
		 * http://www.x.com/docs/DOC-1884.
		 * 
		 * Receiving Communication Exceptions or No Response: Since this service is
		 * based on HTTPS it is possible that due to network issues either on PayPal's
		 * side or yours that you can not process a transaction. If this is the case,
		 * what is suggested is that you put some type of loop in your code to try up to
		 * X times before "giving up". This example will try to get a response up to 3
		 * times before it fails and by using the Request ID as described above, you can
		 * do these attempts without the chance of causing duplicate charges on your
		 * customer's credit card.
		 */

		// Set the Request ID
		// Uncomment the line below and run two concurrent transactions to show how
		// duplicate works. You will notice on
		// the second transaction that the response returned is identical to the first,
		// but the duplicate object will be set.
		// String strRequestID = "123456";
		// Comment out this line if testing duplicate response.
		String strRequestID = PayflowUtility.getRequestId();

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(60);

		// Logging is ON by default. To turn off logging comment out the following
		// lines:
		SDKProperties.setLogFileName("payflow_java.log");
		SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		SDKProperties.setMaxLogFileSize(10000000);

		// Log Stack Traces (boolean)
		SDKProperties.setStackTraceOn(true);

		// Support for additional URLSreamHandlers.
		// Application servers (for example Weblogic, Websphere, JBoss) implement their
		// own SSL API.
		// While integrating PayFlowPro API (which uses JSSE), it might be necessary to
		// use a proper
		// URLStreamHandler class while creating the necessary java.net.URL object (in
		// PayFlowPro API).
		// Take a look at http://java.sun.com/j2se/1.4.2/docs/api/java/net/URL.html.
		//
		// You can specify the appropriate URLStreamHandler class name using
		// SDKProperties.setURLStreamHandlerClass method. For example, in order to use
		// the PayFlowPro
		// library with Weblogic (tested with WLS 8.1 SP5), you must include the
		// following in your code:
		//
		// SDKProperties.setURLStreamHandlerClass("sun.net.www.protocol.https.Handler");

		// Uncomment the lines below and set the proxy address and port, if a proxy has
		// to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(0);
		// SDKProperties.setProxyLogin("");
		// SDKProperties.setProxyPassword("");

		// Create the Data Objects.
		// Create the User data object with the required user details.
		// Remember: <vendor> = your merchant (login id), <user> = <vendor> unless you
		// created a separate
		// <user> for Payflow Pro.
		// Result code 26 will be issued if you do not provide both the <vendor> and
		// <user> fields.

		// The other most common error with authentication is result code 1, user
		// authentication failed. This
		// is usually due to invalid account information or ip restriction on the
		// account. You can verify ip
		// restriction by logging into Manager. Result code 26, Invalid Vendor ID is
		// basically the same issue.
		// UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>",
		// "<password>");
		UserInfo user = new UserInfo("toddprov4", "toddprov4", "VeriSign", "zodiac69");

		// Create the Payflow Connection data object with the required connection
		// details.
		// The PAYFLOW_HOST is a property defined within SDKProperties. See above.
		PayflowConnectionData connection = new PayflowConnectionData();

		// *** Create a new Invoice data object ***
		// Set Invoice object with the Amount, Billing & Shipping Address, etc. ***
		Invoice inv = new Invoice();

		// Set the amount object.
		// Currency Code USD is US ISO currency code. If no code passed, USD is default.
		// See the Developer's Guide for the list of three-character currency codes
		// available.
		Currency amt = new Currency(new Double(25.25), "USD");

		// A valid amount is a two decimal value. An invalid amount will generate a
		// result code 4.
		// For values which have more than two decimal places such as:
		// Currency amt = new Currency(new Double(25.1214));
		// You will either need to truncate or round as needed using the following
		// properties:
		// amt.setRound(true);
		// amt.setTruncate(true);
		// If the setNoOfDecimalDigits property is used then it is mandatory to set
		// either setRound or setTruncate
		// to true.
		// For Currencies without a decimal, ie EURO, setNoOfDecimalDigits = 0.
		// amt.setNoOfDecimalDigits(2);
		inv.setAmt(amt);

		// PONum, InvNum and CustRef are sent to the processors and could show up on a
		// customers
		// or your bank statement. These fields are reportable but not searchable in
		// PayPal Manager.
		inv.setPoNum("PO12345");
		inv.setInvNum("INV12345");
		inv.setCustRef("CustRef1");

		// Merchant information is detailed data about a merchant such as the merchant's
		// name, business address, business location identifier,
		// and contact information and is used to change the merchant's information on a
		// customer's credit card.
		// See the section, "Submitting Soft Merchant Information" in te Payflow Pro
		// Developer's Guide for more information.
		// MerchantInfo merchant = new MerchantInfo();
		// merchant.setMerchantName("MerchantXXXXX");
		// merchant.setMerchantCity("Somewhere");
		// inv.setMerchantInfo (merchant);

		// Comment1 and Comment2 fields are searchable within PayPal Manager .
		// You may want to populate these fields with any of the above three fields or
		// any other data.
		// However, the search is a case-sensitive and is a non-wildcard search, so plan
		// accordingly.
		inv.setComment1("Comment1");
		inv.setComment2("Comment2");

		// *** Set the Billing Address details. ***
		//
		// The billing details below except for Street and Zip are for reporting
		// purposes only.
		// It is suggested that you pass all the billing details for enhanced reporting
		// and as data backup.

		// Create the BillTo object.
		BillTo bill = new BillTo();

		// Set the customer name.
		bill.setBillToFirstName("Joe & Moose");
		// bill.setMiddleName("M");
		bill.setBillToLastName("Smith");
		bill.setBillToCompanyName("Joe's Hardware");

		// It is highly suggested that you pass at minimum Street and Zip for AVS response.
		// However, AVS is only supported by US banks and some foreign banks. See the Payflow
		// Developer's Guide for more information. Sending these fields could help in obtaining
		// a lower discount rate from your Internet merchant Bank. Consult your bank for more information.

		bill.setBillToStreet("123 Main St.");
		// Secondary street address.
		bill.setBillToStreet2("#A");

		bill.setBillToCity("San Jose");
		bill.setBillToState("CA");
		bill.setBillToZip("12345");
		// BillToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
		// For more information, refer to the Payflow Developer's Guide.
		bill.setBillToCountry("840");

		bill.setBillToPhone("555-243-7689");
		// Secondary phone numbers (could be mobile number etc).
		// bill.setBillToPhone2("222-222-2222");
		// bill.setBillToHomePhone("555-123-9867");
		// bill.setBillToFax("555-343-5444");
		// bill.setBillToCompanyName("Company Name");
		// bill.setBillToEmail("Joe.Smith@anyemail.com");

		// Set the BillTo object into invoice.
		inv.setBillTo(bill);

		// Shipping details may not be necessary if providing a
		// service or downloadable product such as software etc.
		//
		// Set the Shipping Address details.
		// The shipping details are for reporting purposes only.
		// It is suggested that you pass all the shipping details for enhanced
		// reporting.
		//
		// Create the ShipTo object.
		ShipTo ship;
		new ShipTo();

		// To prevent an 'Address Mismatch' fraud trigger, we are shipping to the
		// billing address. However,
		// shipping parameters are listed.
		// Comment line below if you want a separate Ship To address.
		ship = bill.copy();

		// Uncomment statements below to send to separate Ship To address.
		// Set the recipient's name.
		// ship.setShipToFirstName("Sam");
		// ship.setShipToMiddleName("J");
		// ship.setShipToLastName("Spade");
		// ship.setShipToStreet("456 Shipping St.");
		// ship.setShipToStreet2("Apt A");
		// ship.setShipToCity("Las Vegas");
		// ship.setShipToState("NV");
		// ship.setShipToZip("99999");
		// ShipToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
		// For more information, refer to the Payflow Pro Developer's Guide.
		// ship.setShipToCountry("840");
		// ship.setShipToPhone("555-123-1233");
		// Secondary phone numbers (could be mobile number etc).
		// ship.setShipToPhone2("555-333-1222");
		// ship.setShipToEmail("Sam.Spade@email.com");
		// ship.setShipFromZip(bill.getZip());

		// Following 2 items are just for reporting purposes and are not required.
		// ship.setShipCarrier("UPS");
		// ship.setShipMethod("Ground");

		inv.setShipTo(ship);

		// *** Create Customer Data ***
		// There are additional CustomerInfo parameters that are used for Level 2
		// Purchase Cards.
		// Refer to the Payflow Pro Developer's Guide and consult with your Internet
		// Merchant Bank regarding what parameters to send.
		// Some of the parameters could include:
		// CustomerInfo CustInfo = new CustomerInfo();
		// CustInfo.setCustCode("CustCode123"); // Customer Code
		// CustInfo.setCustId("CustrID123");
		// CustInfo.CustIP ("255.255.255.255"); // Customer's ip address
		// inv.CustomerInfo = CustInfo;

		// *** Create Level 2/3 Data for Purchase Card ***
		// PayPal Payment Services supports passing Purchasing Card Level 2 information (such as
		// purchase order number, tax amount, and charge description) in the settlement file.
		// If additional required invoice information and line item details are included in the transaction,
		// PayPal formats Purchasing Card Level 3 information in an appropriate format, for example,
		// EDI (Electronic Data Interchange) 810 format as required by American Express during settlement processing.

		//// Create a line item.
		// LineItem item = new LineItem();
		//// Add first item.
		// Currency lnamt = new Currency(new Double(8.95), "USD");
		// item.setAmt(lnamt);
		// item.setDesc("Line 1");
		// item.setQty(1);
		// item.setItemNumber("1");
		//// Add line item to invoice.
		// inv.addLineItem(item);
		//// Create a line item.
		// LineItem item1 = new LineItem();
		//// Add second item.
		// Currency lnamt1 = new Currency(new Double(5.25), "USD");
		// item1.setAmt(lnamt);
		// item1.setDesc("Line 2");
		// item1.setQty(2);
		// item1.setItemNumber("2");
		//// Add line item to invoice.
		// inv.addLineItem(item1);

		// *** Send User fields ***
		// You can send up to ten string type parameters to store temporary data (for example, variables,
		// session IDs, order numbers, and so on). These fields will be echoed back either via API response
		// or as part of the Silent / Return post if using the hosted checkout page.
		//
		// Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in
		// the PayPal transaction database.
		//
		// UserItem nUser = new UserItem();
		// nUser.setUserItem1("TUSER1");
		// nUser.setUserItem2("TUSER2");
		// inv.setUserItem(nUser);

		// *** Create a new Payment Device - Credit Card data object. ***
		// The input parameters are Credit Card Number and Expiration Date of the Credit
		// Card.
		// Note: Expiration date is in the format MMYY.
		CreditCard cc = new CreditCard("4111111111111111", "0125");

		// Example of Swipe Transaction.
		// SwipeCard swipe = new SwipeCard(";5105105105105100=15121011000012345678?");

		/*
		 *** Card Security Code *** This is the 3 or 4 digit code on either side of the
		 * Credit Card. It is highly suggested that you obtain and pass this information
		 * to help prevent fraud. Sending this fields could help in obtaining a lower
		 * discount rate from your Internet merchant Bank.
		 * 
		 * This is the 3 or 4 digit code on either side of the Credit Card. It is highly
		 * suggested that you obtain and pass this information to help prevent fraud as
		 * sending this field could help in obtaining a lower discount rate from your
		 * Internet merchant Bank.
		 * 
		 * However, you are not allowed to store this data within your local database.
		 */
		cc.setCvv2("123");

		/* Card on File: Stored Credential
		 * A stored credential is information, including, but not limited to, an account number or a payment token.
		 * It is stored by a merchant, its agent, a payment facilitator or a staged digital wallet operator to process future transactions for a cardholder.
		 * Refer to the Payflow Gateway Developer Guide for more information.
		 *
		 * Example:
		 * CITI (CIT Initial) - Signifies that the merchant is storing the cardholder credentials for the first time in anticipation of future
		 * stored credential transactions. Example: A cardholder sets up a customer profile for future purchases.
		 */
		cc.setCardOnFile("CITI");

		// *** Create a new Tender - Card Tender data object. ***
		CardTender card = new CardTender(cc); // credit card
		// CardTender Card = new CardTender(swipe); // swipe card

		/*
		 *** Create a new Sale Transaction. *** The Request Id is the unique id necessary
		 * for each transaction. If you are performing an authorization - delayed
		 * capture transaction, make sure that you pass two different unique request ids
		 * for each of the transaction.
		 * 
		 * If you pass a non-unique request id, you will receive the transaction details
		 * from the original request. The only difference is you will also receive a
		 * parameter DUPLICATE indicating this request id has been used before.
		 * 
		 * The Request Id can be any unique number such order id, invoice number from
		 * your implementation or a random id can be generated using the
		 * PayflowUtility.RequestId.
		 */

		SaleTransaction trans = new SaleTransaction(user, connection, inv, card, strRequestID);

		/*
		 * Transaction results (especially values for declines and error conditions)
		 * returned by each PayPal-supported processor vary in detail level and in
		 * format. The Payflow Verbosity parameter enables you to control the kind and
		 * level of information you want returned.
		 * 
		 * By default, Verbosity is set to LOW. A LOW setting causes PayPal to normalize
		 * the transaction result values. Normalizing the values limits them to a
		 * standardized set of values and simplifies the process of integrating the
		 * Payflow SDK.
		 * 
		 * By setting Verbosity to MEDIUM, you can view the processor's raw response
		 * values. This setting is more 'verbose' than the LOW setting in that it
		 * returns more detailed, processor-specific information.
		 * 
		 * Setting Verbosity to HIGH, returns the maximum data related to your
		 * transaction. Items such as last 4-digits of the credit card, expiration date,
		 * amount, etc. are returned.
		 * 
		 * Review the chapter in the Payflow Pro Developer's Guide regarding VERBOSITY
		 * and the INQUIRY function for more details.
		 */

		// Set the transaction verbosity to HIGH to display most details.
		trans.setVerbosity("HIGH");

		// Try to submit the transaction up to 3 times with 5 second delay. This can be
		// used
		// in case of network issues. The idea here is since you are posting via HTTPS
		// behind the scenes there
		// could be general network issues, so try a few times before you tell customer
		// there is an issue.
		int trxCount = 1;
		Boolean RespRecd = false;
		while (trxCount <= 3 && !RespRecd) {
			// Notice we set the request id earlier in the application and outside our loop.
			// This way if a response was not received
			// but PayPal processed the original request, you'll receive the original
			// response with DUPLICATE set.

			// Submit the Transaction
			Response Resp = trans.submitTransaction();

			// Display the transaction response parameters.
			if (Resp != null) {
				RespRecd = true;
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse = Resp.getTransactionResponse();

				// Refer to the Payflow Pro Developer's Guide for explanation of the items
				// returned and for
				// additional information and parameters available.
				if (TrxnResponse != null) {
					System.out.println("Transaction Response:");
					System.out.println("Result Code (RESULT) = " + TrxnResponse.getResult());
					System.out.println("Transaction ID (PNREF) = " + TrxnResponse.getPnref());
					System.out.println("Response Message (RESPMSG) = " + TrxnResponse.getRespMsg());
					System.out.println("Authorization (AUTHCODE) = " + TrxnResponse.getAuthCode());
					System.out.println("Street Address Match (AVSADDR) = " + TrxnResponse.getAvsAddr());
					System.out.println("Street Zip Match (AVSZIP) = " + TrxnResponse.getAvsZip());
					System.out.println("International Card (IAVS) = " + TrxnResponse.getIavs());
					System.out.println("CVV2 Match (CVV2MATCH) = " + TrxnResponse.getCvv2Match());
					System.out.println("------------------------------------------------------");
					System.out.println("Credit Card Information:");
					System.out.println("Last 4-digits Credit Card Number (ACCT) = " + TrxnResponse.getAcct());
					if (TrxnResponse.getCardType() != null) {
						System.out.print("Card Type (CARDTYPE) = ");
						switch (Integer.parseInt(TrxnResponse.getCardType())) {
						case 0:
							System.out.println("Visa");
							break;
						case 1:
							System.out.println("MasterCard");
							break;
						case 2:
							System.out.println("Discover");
							break;
						case 3:
							System.out.println("American Express");
							break;
						case 4:
							System.out.println("Diner's Club");
							break;
						case 5:
							System.out.println("JCB");
							break;
						case 6:
							System.out.println("Maestro");
							break;
						}
					}
					System.out.println("Expiration Date (EXPDATE) = " + TrxnResponse.getExpDate());
					System.out.println("Billing Name (FIRSTNAME, LASTNAME) = " + TrxnResponse.getBillToFirstName() + " "
							+ TrxnResponse.getBillToLastName());
					System.out.println("------------------------------------------------------");
					System.out.println("Verbosity Response:");
					System.out.println("Processor AVS (PROCAVS) = " + TrxnResponse.getProcAvs());
					System.out.println("Processor CSC (PROCCVV2) = " + TrxnResponse.getProcCVV2());
					System.out.println("Processor Result (HOSTCODE) = " + TrxnResponse.getHostCode());
					System.out.println("Transaction Date/Time (TRANSTIME) = " + TrxnResponse.getTransTime());
					System.out.println("Amount of Transaction (AMT) = " + TrxnResponse.getAmt());
					System.out.println(
							"Payment Advice Code (PAYMENTADVICECODE) = " + TrxnResponse.getPaymentAdviceCode());
				}

				// Get the Fraud Response parameters.
				// All trial accounts come with basic Fraud Protection Services enabled.
				// Review the PayPal Manager guide to set up your Fraud Filters prior to
				// running this sample code.
				// If Fraud Filters are not set, you will receive a RESULT code 126.
				FraudResponse FraudResp = Resp.getFraudResponse();
				if (FraudResp != null) {
					System.out.println("------------------------------------------------------");
					System.out.println("Fraud Response:");
					System.out.println("Pre-Filters (PREFPSMSG) = " + FraudResp.getPreFpsMsg());
					System.out.println("Post-Filters (POSTFPSMSG) = " + FraudResp.getPostFpsMsg());
				}

				// Was this a duplicate transaction?
				// If this value is true, then the original response of the original transaction
				// will
				// be returned. The transaction type listed in Manager will be "N" and the
				// Original
				// Transaction ID will be the PNREF of the original transaction. The value would
				// be
				// true if the Request ID of the Transaction Object has not been changed.
				System.out.println("------------------------------------------------------");
				System.out.println("Duplicate Response:");
				String DupMsg;
				if (TrxnResponse.getDuplicate() == null) {
					DupMsg = "Not a Duplicate Transaction";
				} else {
					DupMsg = "Duplicate Transaction";
				}
				System.out.println(("Duplicate Transaction (DUPLICATE) = " + DupMsg));

				/*
				 * Example of adding in business rules. This is not an exhaustive list of
				 * failures or issues that could arise. Review the list of Result Code's in the
				 * Developer's Guide and add logic as you deem necessary.
				 * 
				 * These responses are just an example of what you can do and how you handle the
				 * response received from the bank is dependent on your business rules and
				 * needs.
				 */

				String RespMsg;
				// Evaluate Result Code
				if (TrxnResponse.getResult() < 0) { // Transaction failed.
					RespMsg = "There was an error processing your transaction. Please contact Customer Service."
							+ "\nError: " + TrxnResponse.getResult();
				} else if (TrxnResponse.getResult() == 1 || TrxnResponse.getResult() == 26) {
					// This is just checking for invalid login information. You would not want to
					// display this to your customers.
					RespMsg = "Account configuration issue.  Please verify your login credentials.";
				} else if (TrxnResponse.getResult() == 0) {
					RespMsg = "Your transaction was approved. Will ship in 24 hours.";
				} else if (TrxnResponse.getResult() == 12) { // Hard decline from bank.
					RespMsg = "Your transaction was declined.";
				} else if (TrxnResponse.getResult() == 13) { // Voice authorization required.
					RespMsg = "Your Transaction is pending. Contact Customer Service to complete your order.";
				} else if (TrxnResponse.getResult() == 23 || TrxnResponse.getResult() == 24) { // Issue with credit card
																								// number or expiration
																								// date.
					RespMsg = "Invalid credit card information. Please re-enter.";
				} else if (TrxnResponse.getResult() == 125) { // 125, 126 and 127 are Fraud Responses.
					// Refer to the Payflow Pro Fraud Protection Services User's Guide or Website
					// Payments Pro Payflow Edition - Fraud Protection Services User's Guide.
					RespMsg = "Your Transactions has been declined. Contact Customer Service.";
				} else if (TrxnResponse.getResult() == 126) { // Decline transaction if AVS fails.
					if ((!TrxnResponse.getAvsAddr().equals("Y") | !TrxnResponse.getAvsZip().equals("Y"))) {
						// Display message that transaction was not accepted. At this time, you
						// could display message that information is incorrect and redirect user
						// to re-enter STREET and ZIP information. However, there should be some sort of
						// 3 strikes your out check.
						RespMsg = "Your billing information does not match. Please re-enter.";
					} else {
						RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
					}
				} else if (TrxnResponse.getResult() == 127) {
					RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
				} else { // Error occurred, display normalized message returned.
					RespMsg = TrxnResponse.getRespMsg();
				}

				// Display Message
				System.out.println("------------------------------------------------------");
				System.out.println("User/System Response:");
				System.out.println("User Message (RESPMSG) = " + RespMsg);
				System.out.println("System Message (TRXNRESPONSE.RESPMSG) = " + TrxnResponse.getRespMsg());

				// Display the status response of the transaction.
				// This is just additional information and normally would not be used in
				// production.
				// Your business logic should be built around the result code returned as shown
				// above.
				System.out.println("------------------------------------------------------");
				System.out.println("Overall Transaction Status: " + PayflowUtility.getStatus(Resp));

				// Get the Transaction Context and check for any contained SDK specific errors
				// (optional code).
				// This is not normally used in production.
				Context TransCtx = Resp.getContext();
				if (TransCtx != null && TransCtx.getErrorCount() > 0) {
					System.out.println("------------------------------------------------------");
					System.out.println("Transaction Context Errors: " + TransCtx);
				}
				System.out.println("------------------------------------------------------");
				System.out.println("Press Enter to Exit ...");
			} else {
				try {
					Thread.currentThread().sleep(5000); // let's wait 5 seconds to see if this is a temporary network
														// issue.
					System.out.println("Retry #: " + Integer.toString(trxCount));
					trxCount++;
				} catch (Exception e) {
					System.out.println(e);
				}
				if (!RespRecd) {
					System.out.println("There is a problem obtaining an authorization for your order.");
					System.out.println("Please contact Customer Support.");
					System.out.println("------------------------------------------------------");
					System.out.println("Press Enter to Exit ...");
					System.out.println();
				}
			}
		}
	}
}