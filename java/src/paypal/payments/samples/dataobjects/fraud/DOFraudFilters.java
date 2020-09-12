package paypal.payments.samples.dataobjects.fraud;

import paypal.payflow.*;

import java.util.ArrayList;
import java.util.Iterator;

// This class uses the Payflow SDK Data Objects to do a Fraudulent Sale transaction. A pre-requisite
// to this transaction is to set a value of $50 for the "Purchase Price Ceiling Filter".
// An amount of $51 is passed to trigger the filter.

public class DOFraudFilters {
	public DOFraudFilters() {
	}

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: DOFraudFilters.java");
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
		Currency amt = new Currency(new Double(51.00));
		inv.setAmt(amt);
		inv.setPoNum("PO12345");
		inv.setInvNum("INV12345");

		CustomerInfo custinfo = new CustomerInfo();
		custinfo.setCustIP("10.1.1.1"); // IP Velocity Filter
		inv.setCustomerInfo(custinfo);

		// Set the Billing Address details.
		BillTo bill = new BillTo();
		bill.setBillToStreet("123 Main St.");
		bill.setBillToZip("12345");
		inv.setBillTo(bill);

		// Create a new Payment Device - Credit Card data object.
		// The input parameters are Credit Card No. and Expiry Date for the Credit Card.
		CreditCard cc = new CreditCard("5105105105105100", "0109");
		cc.setCvv2("444");

		// Create a new Tender - Card Tender data object.
		CardTender card = new CardTender(cc);
		///////////////////////////////////////////////////////////////////

		// Create a new Sale Transaction with purchase price ceiling amount filter set
		// to $50.
		SaleTransaction trans = new SaleTransaction(user, connection, inv, card, PayflowUtility.getRequestId());

		// Set the Verbosity of the transaction to HIGH to get maximum information in
		// the response.
		trans.setVerbosity("HIGH");

		// Submit the Transaction
		Response resp = trans.submitTransaction();

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

				// The following lines of code dealing with PreXmlData and PostXmlData will
				// return all th rules
				// that were triggered by the Fraud Service. For Example, let's assume the both
				// AVS and CSC (CVV2)
				// failed, the FraudResp.PostFpsMsg would something similar to:
				// "Review: More than one rule was triggered for Review".
				//
				// The Fps_PreXmlData is returned as an Xml string. This is converted into Data
				// Objects
				// with the object hierarchy as shown below:
				// FpsXmlData
				// >>>>>>>>> List of Rule objects
				// >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
				FpsXmlData preXmlData = fraudResp.getFpsPreXmlData();
				if (preXmlData != null) {
					// Get the list of Rules.
					ArrayList rulesList = preXmlData.getRules();
					if (rulesList != null && rulesList.size() > 0) {
						Iterator rulesEnum = rulesList.iterator();
						Rule doRule;
						// Loop through the list of Rules.
						while (rulesEnum.hasNext()) {
							doRule = (Rule) rulesEnum.next();
							System.out.println("------------------------------------------------------");
							System.out.println("PRE-XML DATA");
							System.out.println("------------------------------------------------------");
							System.out.println("Rule Number = " + String.valueOf(doRule.getNum()));
							System.out.println("Rule Id = " + doRule.getRuleId());
							System.out.println("Rule Alias = " + doRule.getRuleAlias());
							System.out.println("Rule Description = " + doRule.getRuleDescription());
							System.out.println("Action = " + doRule.getAction());
							System.out.println("Triggered Message = " + doRule.getTriggeredMessage());

							// Get the list of Rule Vendor Parameters.
							ArrayList ruleVendorParmsList = doRule.getRuleVendorParms();

							if (ruleVendorParmsList != null && ruleVendorParmsList.size() > 0) {
								Iterator ruleParametersEnum = ruleVendorParmsList.iterator();
								// Loop through the list of Rule Parameters.
								while (ruleParametersEnum.hasNext()) {
									RuleParameter doRuleParam = (RuleParameter) ruleParametersEnum.next();
									System.out.println("Number = " + String.valueOf(doRuleParam.getNum()));
									System.out.println("Name = " + doRuleParam.getName());
									System.out.println("Type = " + doRuleParam.getType());
									System.out.println("Value = " + doRuleParam.getValue());
								}
							}
						}
					}
				}
				// The Fps_PostXmlData is returned as an Xml string. This is converted into Data
				// Objects
				// with the object hierarchy as shown below:
				// FpsXmlData
				// >>>>>>>>> List of Rule objects
				// >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
				FpsXmlData postXmlData = fraudResp.getFpsPostXmlData();
				if (postXmlData != null) {
					// Get the list of Rules.
					ArrayList rulesList = postXmlData.getRules();
					if (rulesList != null && rulesList.size() > 0) {
						Iterator rulesEnum = rulesList.iterator();
						Rule doRule;
						// Loop through the list of Rules.
						while (rulesEnum.hasNext()) {
							doRule = (Rule) rulesEnum.next();
							System.out.println("------------------------------------------------------");
							System.out.println("POST-XML DATA");
							System.out.println("------------------------------------------------------");
							System.out.println("Rule Number = " + String.valueOf(doRule.getNum()));
							System.out.println("Rule Id = " + doRule.getRuleId());
							System.out.println("Rule Alias = " + doRule.getRuleAlias());
							System.out.println("Rule Description = " + doRule.getRuleDescription());
							System.out.println("Action = " + doRule.getAction());
							System.out.println("Triggered Message = " + doRule.getTriggeredMessage());

							// Get the list of Rule Vendor Parameters.
							ArrayList ruleVendorParmsList = doRule.getRuleVendorParms();

							if (ruleVendorParmsList != null && ruleVendorParmsList.size() > 0) {
								Iterator ruleParametersEnum = ruleVendorParmsList.iterator();
								// Loop through the list of Rule Parameters.
								while (ruleParametersEnum.hasNext()) {
									RuleParameter doRuleParam = (RuleParameter) ruleParametersEnum.next();
									System.out.println("Number = " + String.valueOf(doRuleParam.getNum()));
									System.out.println("Name = " + doRuleParam.getName());
									System.out.println("Type = " + doRuleParam.getType());
									System.out.println("Value = " + doRuleParam.getValue());
								}
							}
						}
					}
				}
			}
		}

		// Display the response.
		System.out.println("\n" + PayflowUtility.getStatus(resp));

		// Get the Transaction Context and check for any contained SDK specific errors
		// (optional code).
		Context transCtx = null;
		if (resp != null) {
			transCtx = resp.getContext();
		}
		if (transCtx != null && transCtx.getErrorCount() > 0) {
			System.out.println("\nTransaction Errors = " + transCtx.toString());
		}
	}
}
