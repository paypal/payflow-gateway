using System;
using System.Globalization;
using System.Net;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;
using System.Threading;


namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// This class uses the Payflow .NET SDK Data Objects to do a Sale transaction including some business rules.
	/// This class depicts the use of the Data Objects which would normally be used in a transaction.
	/// </summary>
	public class DOSaleCompleteCS
	{
		public DOSaleCompleteCS()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOSaleComplete.cs");
			Console.WriteLine("------------------------------------------------------");

            // 
            // PLEASE READ ALL COMMENTS BELOW:
            // All information regarding the available objects within payflow_dotNET.dll can be found in the API doc
            // found under the "Docs" directory of the installed SDK.  You will also need to refer to the 
            // Payflow Gateway Developer Guide and Reference found at 
            // https://developer.paypal.com/docs/classic/payflow/integration-guide/
            //
            // Regarding the Request ID:
            // 
            // The request Id is a unique id that you send with your transaction data.  This Id if not changed
            // will help prevent duplicate transactions.  The idea is to set this Id outside the loop or if on a page,
            // prior to the final confirmation page.
            // 
            // Once the transaction is sent and if you don't receive a response you can resend the transaction and the 
            // server will respond with the response data of the original submission.  Also, the object, 
            // Trans.Response.TransactionResponse.Duplicate will be set to "1" if the transaction is a duplicate.
            // 
            // This allows you to resend transaction requests should there be a network or user issue without re-charging
            // a customers credit card.
            // 
            // COMMON ISSUES:
            // 
            // Result Code 1:
            // Is usually caused by one of the following:
            //		** Invalid login information, see result code 26 below.
            //		** IP Restrictions on the account. Verify there are no IP restrictions in Manager under Service Settings.
            // 
            // Result Code 26:
            // Verify USER, VENDOR, PARTNER and PASSWORD. Remember, USER and VENDOR are both the merchant login
            // ID unless a Payflow Pro USER was created.  All fields are case-sensitive. 
            //
            // Receiving Communication Exceptions or No Response: 
            // Since this service is based on HTTPS it is possible that due to network issues either on PayPal's side or 
            // yours that you can not process a transaction.  If this is the case, what is suggested is that you put some 
            // type of loop in your code to try up to X times before "giving up".  This example will try to get a response 
            // up to 3 times before it fails and by using the Request ID as described above, you can do these attempts without
            // the chance of causing duplicate charges on your customer's credit card.
            // 
            // END COMMENTS

            // Begin Application
            //
            // Set the Request ID
            // Uncomment the line below and run two concurrent transactions to show how duplicate works.  You will notice on
            // the second transaction that the response returned is identical to the first, but the duplicate object will be set.
            // String strRequestID = "123456";
            // Comment out this line if testing duplicate response. 
            String RequestID = PayflowUtility.RequestId;

            // *** Create the Data Objects. ***
            //
            // *** Create the User data object with the required user details. ***
            //         
            // Should you choose to store the login information (Vendor, User, Partner and Password) in
            // app.config, you can retrieve the data using PayflowUtility.AppSettings. 
            //
            // For Example:
            //
            //      App.Config Entry: <add key="PayflowPartner" value="PayPal"/>
            //
            //      String mUser = PayflowUtility.AppSettings("PayflowUser"); 
            //      String mVendor = PayflowUtility.AppSettings("PayflowVendor");
            //      String mPartner = PayflowUtility.AppSettings("PayflowPartner");
            //      String mPassword = PayflowUtility.AppSettings("PayflowPassword");
            //
            // UserInfo User = new UserInfo (mUser, mVendor, mPartner, mPassword);

            // Remember: <vendor> = your merchant (login id), <user> = <vendor> unless you created a separate <user> for Payflow Pro.
            // Result code 26 will be issued if you do not provide both the <vendor> and <user> fields.

            // The other most common error with authentication is result code 1, user authentication failed.  This is usually
            // due to invalid account information or IP restriction on the account.  You can verify IP restriction by logging 
            // into Manager.
            UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

            // *** Create the Payflow Connection data object with the required connection details. ***
            //
            // To allow the ability to change easily between the live and test servers, the PFPRO_HOST 
            // property is defined in the App.config (or web.config for a web site) file.  However,
            // you can also pass these fields and others directly from the PayflowConnectionData constructor. 
            // This will override the values passed in the App.config file.
            //
            // For Example:
            //
            //      Example values passed below are as follows:
            //      Payflow Pro Host address : pilot-payflowpro.paypal.com 
            //      Payflow Pro Host Port : 443
            //      Timeout : 45 ( in seconds )
            //
            //      PayflowConnectionData Connection = new PayflowConnectionData("pilot-payflowpro.paypal.com", 443, 45, "",0,"","");
            //
            // Obtain Host address from the app.config file and use default values for
            // timeout and proxy settings.

            PayflowConnectionData Connection = new PayflowConnectionData();

			// *** Create a new Invoice data object ***
			// Set Invoice object with the Amount, Billing & Shipping Address, etc. ***

			Invoice Inv = new Invoice();

            // Creates a CultureInfo for English in the U.S.
            // Not necessary, just here for example of using currency formatting.
            //CultureInfo us = new CultureInfo("en-US");
            //String usCurrency = "USD";

            // Set the amount object. For Partial Authorizations, refer to the DoPartialAuth example.
            // Currency Code 840 (USD) is US ISO currency code.  If no code passed, 840 is default.
            // See the Developer's Guide for the list of the three-digit currency codes.
            //Currency Amt = new Currency(new decimal(0.00), usCurrency);
            Currency Amt = new Currency(new decimal(25.00), "USD");
            
			// A valid amount has either no decimal value or only a two decimal value. 
			// An invalid amount will generate a result code 4.
			//
			// For values which have more than two decimal places such as:
			// Currency Amt = new Currency(new Decimal(25.1214));
			// You will either need to truncate or round as needed using the following property: Amt.NoOfDecimalDigits
			//
			// If the NoOfDecimalDigits property is used then it is mandatory to set one of the following
			// properties to true.
			//
			//Amt.Round = true;
			//Amt.Truncate = true;
			//
			// For Currencies without a decimal, you'll need to set the NoOfDecimalDigits = 0.
			//Amt.NoOfDecimalDigits = 0;
			Inv.Amt = Amt;

            Currency TaxAmt = new Currency(new decimal(0.00), "USD");
            Inv.TaxAmt = TaxAmt;

            // PONum, InvNum and CustRef are sent to the processors and could show up on a customers
            // or your bank statement. These fields are reportable but not searchable in PayPal Manager.
            Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";
			Inv.CustRef = "CustRef1";
          
            // Merchant information is detailed data about a merchant such as the merchant's name, business address, business location identifier, 
            // and contact information and is used to change the merchant's information on a customer's credit card.
            // See the section, "Submitting Soft Merchant Information" in the Payflow Pro Developer's Guide for more information.
            //MerchantInfo Merchant = new MerchantInfo();
            //Merchant.MerchantName = "MerchantXXXXX";
            //Merchant.MerchantCity = "Somewhere";
            //Inv.MerchantInfo = Merchant;
			Inv.VatTaxAmt = new Currency(new decimal(25.00), "USD");

            // Comment1 and Comment2 fields are search-able within PayPal Manager .
            // You may want to populate these fields with any of the above three fields or any other data.
            // However, the search is a case-sensitive and is a non-wild card search, so plan accordingly.

            Inv.Comment1 = "Comment1";
			Inv.Comment2 = "Comment2";

            // There are additional Invoice parameters that could assist you in obtaining a better rate
            // from your merchant bank.  Refer to the Payflow Pro Developer’s Guide1
            // and consult your Internet Merchant Bank on what parameters (if any) you can use.
            // Some of the parameters could include:
            // Inv.TaxExempt = "Y";


            // *** Create Level 2/3 Data for Purchase Card ***
            // PayPal Payment Services supports passing Purchasing Card Level 2 information (such as
            // purchase order number, tax amount, and charge description) in the settlement file.
            // If additional required invoice information and line item details are included in the transaction,
            // PayPal formats Purchasing Card Level 3 information in an appropriate format, for example,
            // EDI (Electronic Data Interchange) 810 format as required by American Express during
            // settlement processing.
            //
            // Discuss with your merchant acquiring bank to determine if you should be passing this data and
            // refer to the Payflow Gateway Developer's Guide under your processor for all valid and required
            // parameters.
            //
            //Create a line item.
            //LineItem Item = new LineItem();
            //Add info to line item.
            //Item.Amt = new Currency(new Decimal(100.00));
            //Item.Cost = new Currency(new Decimal(49.99));
            //Add line item to invoice.
            //Inv.AddLineItem(Item);
            // To add additional line items, just repeat the same statements above changing the values.	

            // *** Set the Billing Address details. ***
            //
            // The billing details below except for Street and Zip are for reporting purposes only. 
            // It is suggested that you pass all the billing details for enhanced reporting and as data backup.

            // Create the BillTo object.
            BillTo Bill = new BillTo();
			// Set the customer name.
			Bill.BillToFirstName = "Joe";
			Bill.BillToMiddleName = "M";
			Bill.BillToLastName = "Smith";
			Bill.BillToCompanyName = "Joe's Hardware";
			// It is highly suggested that you pass at minimum Street and Zip for AVS response.
			// However, AVS is only supported by US banks and some foreign banks.  See the Payflow 
			// Developer's Guide for more information.  Sending these fields could help in obtaining
			// a lower discount rate from your Internet merchant Bank.  Consult your bank for more information.
			Bill.BillToStreet = "123 Main St.";
            Bill.BillToStreet2 = "Suite A";
            Bill.BillToCity = "San Jose";
			Bill.BillToState = "CA";
			Bill.BillToZip = "12345";
			// BillToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
			// For more information, refer to the Payflow Developer's Guide.
			Bill.BillToCountry = "840";
			Bill.BillToPhone = "555-243-7689";
			// Secondary phone numbers (could be mobile number etc).
			Bill.BillToPhone2 = "222-222-2222";
			Bill.BillToHomePhone = "555-123-9867";
			Bill.BillToFax = "555-343-5444";
			Bill.BillToEmail = "Joe.Smith@anyemail.com";
     
            // Set the BillTo object into invoice.
			Inv.BillTo = Bill;

			// Shipping details may not be necessary if providing a service or downloadable product such as software etc.
			//
			// Set the Shipping Address details.
			// The shipping details are for reporting purposes only. 
			// It is suggested that you pass all the shipping details for enhanced reporting.
			//
			// Create the ShipTo object.
			ShipTo Ship = new ShipTo();

			// To prevent an 'Address Mismatch' fraud trigger, we are shipping to the billing address.  However,
			// shipping parameters are listed.
			// Comment line below if you want a separate Ship To address.
			//Ship = Bill.Copy();

    		// Uncomment statements below to send to separate Ship To address.
            // Set the recipient's name.			
			// Ship.ShipToFirstName = "Sam";
			// Ship.ShipToMiddleName = "J";
			// Ship.ShipToLastName = "Spade";
			// Ship.ShipToStreet = "456 Shipping St.";
			// Ship.ShipToStreet2 = "Apt A";
			// Ship.ShipToCity = "Las Vegas";
			// Ship.ShipToState = "NV";
			// Ship.ShipToZip = "99999";
			// ShipToCountry code is based on numeric ISO country codes. (e.g. 840 = USA)
			// For more information, refer to the Payflow Pro Developer's Guide.
			// Ship.ShipToCountry = "840";
			// Ship.ShipToPhone = "555-123-1233";
			// Secondary phone numbers (could be mobile number etc).
			// Ship.ShipToPhone2 = "555-333-1222";
			// Ship.ShipToEmail = "Sam.Spade@email.com";
			// Ship.ShipFromZip = Bill.BillToZip;
			// Following 2 items are just for reporting purposes and are not required.
			// Ship.ShipCarrier = "UPS";
			// Ship.ShipMethod = "Ground";
			//Inv.ShipTo = Ship;

            // ECHODATA allows you to trigger data sent in the request to be returned in the request.
            // "ADDRESS" will return both shipping and billing address data, if sent.  
			// "USER" will return User Information, set below.  
			// "CUSTDATA" returns miscellaneous fields.  Refer to the developer guide.
            //Inv.EchoData = "USER";

            // *** 	Create Customer Data ***
            // There are additional CustomerInfo parameters that are used for Level 2 Purchase Cards.
            // Refer to the Payflow Pro Developer’s Guide and consult with your Internet
            // Merchant Bank regarding what parameters to send.
            // Some of the parameters could include:
            //
            //CustomerInfo CustInfo = new CustomerInfo(); 
            //CustInfo.CustCode = "CustCode123";    // Customer Code
            //CustInfo.CustId = "CustId123";
            //CustInfo.CustIP = "255.255.255.255";  // Customer's IP Address
            //Inv.CustomerInfo = CustInfo;

            // *** Send User fields ***
            // You can send up to ten string type parameters to store temporary data (for example, variables, 
            // session IDs, order numbers, and so on). These fields will be echoed back either via API response
            // or as part of the Silent / Return post if using the hosted checkout page.
            // 
            // Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in 
            // the PayPal transaction database.
            //
            // For these fields to echoed back in the response, you need to set the ECHODATA object.
            //UserItem nUser = new UserItem();
            //nUser.UserItem1 = "TUSER1";
            //nUser.UserItem2 = "TUSER2";
            //Inv.UserItem = nUser;

            // *** Create Soft Descriptor Data ***
            // There are additional MerchantInfo parameters that are used for Level 2 Purchase Cards
            // to change the Merchant Name and other information that is shown on a card holders statement.
            // Refer to the Payflow Gateway Developer's Guide for more information.
            //
            //MerchantInfo MerchInfo = new MerchantInfo();
            //MerchInfo.MerchantName = "My Company Name";
            //MerchInfo.MerchantCity = "My Company City";
            //Inv.MerchantInfo = MerchInfo;

            // *** Create a new Payment Device - Credit Card data object. ***
            // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
            // Note: Expiration date is in the format MMYY.
            CreditCard CC = new CreditCard("4111111111111111", "0125");

 			// Example of Swipe Transaction.
			// See DOSwipe.cs example for more information.
			//SwipeCard Swipe = new SwipeCard(";5105105105105100=15121011000012345678?");

			// *** Card Security Code ***
			// This is the 3 or 4 digit code on either side of the Credit Card.
			// It is highly suggested that you obtain and pass this information to help prevent fraud.
			// Sending this fields could help in obtaining a lower discount rate from your Internet merchant Bank.
			// CVV2 is not required when performing a Swipe transaction as the card is present.
			CC.Cvv2 = "123";

            // Name on Credit Card is optional and not used as part of the authorization.
            // Also, this field populates the NAME field which is the same as FIRSTNAME, so if you
            // are already populating first name, do not use this field.
            //CC.Name = "Joe Smith";

            // Card on File: Stored Credential
            // A stored credential is information, including, but not limited to, an account number or a payment token. 
            // It is stored by a merchant, its agent, a payment facilitator or a staged digital wallet operator to process future transactions for a cardholder. 
            // Refer to the Payflow Gateway Developer Guide for more information.
            //
            // Example: 
            // CITI (CIT Initial) - Signifies that the merchant is storing the cardholder credentials for the first time in anticipation of future 
            // stored credential transactions. Example: A cardholder sets up a customer profile for future purchases. 
            CC.CardonFile = "CITI";
            
            // *** Create a new Tender - Card Tender data object. ***
            CardTender Card = new CardTender(CC);  // credit card
			// If you are doing card-present (retail)type transactions you will want to use the swipe object.  Before doing so, verify with
			// your merchant bank that you are setup to process card-present transactions and contact Payflow support to request your account
			// be setup to process these types of transactions.  You will need to request your market seqment be changed from e-commerce (default)
			// to retail.
			//CardTender Card = new CardTender(Swipe);

			// *** Create a new Sale Transaction. ***
			// The Request Id is the unique id necessary for each transaction.  If you are performing an authorization
			// - delayed capture transaction, make sure that you pass two different unique request ids for each of the
			// transaction.
			// If you pass a non-unique request id, you will receive the transaction details from the original request.
			// The only difference is you will also receive a parameter DUPLICATE indicating this request id has been used
			// before.
			// The Request Id can be any unique number such order id, invoice number from your implementation or a random
			// id can be generated using the PayflowUtility.RequestId.
			SaleTransaction Trans = new SaleTransaction(User, Connection, Inv, Card, RequestID);

            // Used to store client information; such as your cart name, version, etc.  Only informational.
            //ClientInfo cInfo = new ClientInfo();
            //cInfo.IntegrationProduct = "Shopping Cart";
            //cInfo.IntegrationVersion = "1.0";
            //Trans.ClientInfo = cInfo;
            
			// Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
			// processor vary in detail level and in format. The Payflow Verbosity parameter enables you to control the kind
			// and level of information you want returned. 
			//
			// By default, Verbosity is set to LOW. A LOW setting causes PayPal to normalize the transaction result values. 
			// Normalizing the values limits them to a standardized set of values and simplifies the process of integrating 
			// the Payflow SDK.
			//
			// By setting Verbosity to HIGH, you can view the processor's raw response values along with card information. This 
			// setting is more verbose than the LOW or MEDIUM setting in that it returns more detailed, processor and card specific
			// information. 
			//
			// Review the chapter in the Payflow Pro Developer's Guide regarding VERBOSITY and the INQUIRY function for more details.

			// Set the transaction verbosity to HIGH to display most details.
			Trans.Verbosity = "HIGH";

			// Try to submit the transaction up to 3 times with 5 second delay.  This can be used
			// in case of network issues.  The idea here is since you are posting via HTTPS behind the scenes there
			// could be general network issues, so try a few times before you tell customer there is an issue.
			int trxCount = 1;
			bool RespRecd = false;
			while (trxCount <= 3 && !RespRecd)
			{
				// Notice we set the request id earlier in the application and outside our loop.  This way if a response was not received
				// but PayPal processed the original request, you'll receive the original response with DUPLICATE set.

				// Submit the Transaction
				Response Resp = Trans.SubmitTransaction();

				// Uncomment line below to simulate "No Response"
				//Resp = null;

				// Display the transaction response parameters.
				if (Resp != null)
				{
					RespRecd = true;  // Got a response.

					// Get the Transaction Response parameters.
					TransactionResponse TrxnResponse = Resp.TransactionResponse;

					// Refer to the Payflow Pro .NET API Reference Guide and the Payflow Pro Developer's Guide
					// for explanation of the items returned and for additional information and parameters available.
					if (TrxnResponse != null)
					{
						Console.WriteLine("Transaction Response:");
						Console.WriteLine("Result Code (RESULT) = " + TrxnResponse.Result);
						Console.WriteLine("Transaction ID (PNREF) = " + TrxnResponse.Pnref);
						Console.WriteLine("Response Message (RESPMSG) = " + TrxnResponse.RespMsg);
						Console.WriteLine("Authorization (AUTHCODE) = " + TrxnResponse.AuthCode);
						Console.WriteLine("Street Address Match (AVSADDR) = " + TrxnResponse.AVSAddr);
						Console.WriteLine("Street Zip Match (AVSZIP) = " + TrxnResponse.AVSZip);
						Console.WriteLine("International Card (IAVS) = " + TrxnResponse.IAVS);
						Console.WriteLine("CVV2 Match (CVV2MATCH) = " + TrxnResponse.CVV2Match);
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Credit Card Information:");
						Console.WriteLine("Last 4-digits Credit Card Number (ACCT) = " + TrxnResponse.Acct);
						if (TrxnResponse.CardType != null)
						{
							Console.Write("Card Type (CARDTYPE) = ");
							switch (TrxnResponse.CardType)
							{
								case "0":
									Console.WriteLine("Visa");
									break;
								case "1":
									Console.WriteLine("MasterCard");
									break;
								case "2":
									Console.WriteLine("Discover");
									break;
								case "3":
									Console.WriteLine("American Express");
									break;
								case "4":
									Console.WriteLine("Diner's Club");
									break;
								case "5":
									Console.WriteLine("JCB");
									break;
								case "6":
									Console.WriteLine("Maestro");
									break;
								case "S":
									Console.WriteLine("Solo");
									break;
							}
						}
						Console.WriteLine("Billing Name (FIRSTNAME, LASTNAME) = " + TrxnResponse.FirstName + " " + TrxnResponse.LastName);
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Verbosity Response:");
                        // Displays amount formatted as currency for the CurrentCulture.
                        // Due to operating system differences, you cannot be sure what currency
                        // symbol will be used.
                        //Console.WriteLine("Amount of Transaction (AMT) = " + Convert.ToDecimal(TrxnResponse.Amt).ToString("c", us));
                        Console.WriteLine("Amount of Transaction (AMT) = " + TrxnResponse.Amt);
                        Console.WriteLine("Processor AVS (PROCAVS) = " + TrxnResponse.ProcAVS);
						Console.WriteLine("Processor CSC (PROCCVV2) = " + TrxnResponse.ProcCVV2);
						Console.WriteLine("Processor Result (HOSTCODE) = " + TrxnResponse.HostCode);
						Console.WriteLine("Transaction Date/Time (TRANSTIME) = " + TrxnResponse.TransTime);
                        Console.WriteLine("Expiration Date (EXPDATE) = " + TrxnResponse.ExpDate);
                        if (TrxnResponse.TxId != null)
                        {
                            // If card is flagged as Card on file (Stored Credential) a transaction ID will be returned that is used on future reference/recurring transactions.
                            Console.WriteLine("Transaction ID (TXID) = " + TrxnResponse.TxId);
                        }
					}

					// Get the Fraud Response parameters.
					// All trial accounts come with basic Fraud Protection Services enabled.
					// Review the PayPal Manager guide to set up your Fraud Filters prior to 
					// running this sample code.
					// If Fraud Filters are not set, you will receive a RESULT code 126.
					FraudResponse FraudResp = Resp.FraudResponse;
					if (FraudResp != null)
					{
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Fraud Response:");
						Console.WriteLine("Pre-Filters (PREFPSMSG) = " + FraudResp.PreFpsMsg);
						Console.WriteLine("Post-Filters (POSTFPSMSG) = " + FraudResp.PostFpsMsg);
					}

					// The details below describe what you'd see in the raw response which can be seen in the log file.
					//
					// Was this a duplicate transaction, i.e. the request ID was NOT changed.
					// Remember, a duplicate response will return the results of the original transaction which
					// could be misleading if you are debugging your software.
					// For Example, let's say you got a result code 4, Invalid Amount from the original request because
					// you were sending an amount like: 1,050.98.  Since the comma is invalid, you'd receive result code 4.
					// RESULT=4&PNREF=V18A0C24920E&RESPMSG=Invalid amount&PREFPSMSG=No Rules Triggered
					// Now, let's say you modified your code to fix this issue and ran another transaction but did not change
					// the request ID.  Notice the PNREF below is the same as above, but DUPLICATE=1 is now appended.
					// RESULT=4&PNREF=V18A0C24920E&RESPMSG=Invalid amount&DUPLICATE=1
					// This would tell you that you are receiving the results from a previous transaction.  This goes for
					// all transactions even a Sale transaction.  In this example, let's say a customer ordered something and got
					// a valid response and now a different customer with different credit card information orders something, but again
					// the request ID is NOT changed, notice the results of these two sales.  In this case, you would have not received
					// funds for the second order.
					// First order: RESULT=0&PNREF=V79A0BC5E9CC&RESPMSG=Approved&AUTHCODE=166PNI&AVSADDR=X&AVSZIP=X&CVV2MATCH=Y&IAVS=X
					// Second order: RESULT=0&PNREF=V79A0BC5E9CC&RESPMSG=Approved&AUTHCODE=166PNI&AVSADDR=X&AVSZIP=X&CVV2MATCH=Y&IAVS=X&DUPLICATE=1
					// Again, notice the PNREF is from the first transaction, this goes for all the other fields as well.
					// It is suggested that your use this to your benefit to prevent duplicate transaction from the same customer, but you want
					// to check for DUPLICATE=1 to ensure it is not the same results as a previous one.
					//
					// Since we are using objects instead of the raw name-value-pairs, you'd check the Duplicate parameter of the TrxnResponse object.
					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine("Duplicate Response:");
					string DupMsg;
					if (TrxnResponse.Duplicate == "1")
					{
						DupMsg = "Duplicate Transaction";
					}
					else
					{
						DupMsg = "Not a Duplicate Transaction";
					}
					Console.WriteLine(("Duplicate Transaction (DUPLICATE) = " + DupMsg));

					// Part of accepting credit cards or PayPal is to determine what your business rules are.  Basically, what risk are you
					// willing to take, especially with credit cards.  The code below gives you an idea of how to check the results returned
					// so you can determine how to handle the transaction.
					//
					// This is not an exhaustive list of failures or issues that could arise.  Review the list of Result Code's in the
					// Developer Guide and add logic as you deem necessary.
					// These responses are just an example of what you can do and how you handle the response received
					// from the bank/PayPal is dependent on your own business rules and needs.

					string RespMsg;
					// Evaluate Result Code
					if (TrxnResponse.Result < 0)
					{
						// Transaction failed.
						RespMsg = "There was an error processing your transaction. Please contact Customer Service." + 
							Environment.NewLine + "Error: " + TrxnResponse.Result.ToString();
					}
					else if (TrxnResponse.Result == 1 || TrxnResponse.Result == 26)
					{
						// This is just checking for invalid login credentials.  You normally would not display this type of message.
						// Result code 26 will be issued if you do not provide both the <vendor> and <user> fields.
						// Remember: <vendor> = your merchant (login id), <user> = <vendor> unless you created a seperate <user> for Payflow Pro.
						//
						// The other most common error with authentication is result code 1, user authentication failed.  This is usually
						// due to invalid account information or ip restriction on the account.  You can verify ip restriction by logging
						// into Manager.  See Service Settings >> Allowed IP Addresses.  Lastly it could be you forgot the path "/transaction"
						// on the URL.
						RespMsg = "Account configuration issue.  Please verify your login credentials.";
					}
					else if (TrxnResponse.Result == 0)
					{
						// Example of a message you might want to display with an approved transaction.
						RespMsg = "Your transaction was approved. Will ship in 24 hours.";

						// Even though the transaction was approved, you still might want to check for AVS or CVV2(CSC) prior to
						// accepting the order.  Do realize that credit cards are approved (charged) regardless of the AVS/CVV2 results.
						// Should you decline (void) the transaction, the card will still have a temporary charge (approval) on it.
						//
						// Check AVS - Street/Zip
						// In the message below it shows what failed, ie street, zip or cvv2.  To prevent fraud, it is suggested
						// you only give a generic billing error message and not tell the card-holder what is actually wrong.  However,
						// that decision is yours.
						//
						// Also, it is totally up to you on if you accept only "Y" or allow "N" or "X".  You need to decide what
						// business logic and liability you want to accept with cards that either don't pass the check or where
						// the bank does not participate or return a result.  Remember, AVS is mostly used in the US but some foreign
						// banks do participate.
						//
						// Remember, this just an example of what you might want to do.
						if (TrxnResponse.AVSAddr != "Y")
						{
							// Display message that transaction was not accepted.  At this time, you
							// could display message that information is incorrect and redirect user
							// to re-enter STREET and ZIP information.  However, there should be some sort of
							// 3 strikes your out check.
							RespMsg = "Your billing (street) information does not match. Please re-enter.";
							// Here you might want to put in code to flag or void the transaction depending on your needs.
						}
						if (TrxnResponse.AVSZip != "Y")
						{
							// Display message that transaction was not accepted.  At this time, you
							// could display message that information is incorrect and redirect user
							// to re-enter STREET and ZIP information.  However, there should be some sort of
							// 3 strikes your out check.
							RespMsg = "Your billing (zip) information does not match. Please re-enter.";
							// Here you might want to put in code to flag or void the transaction depending on your needs.
						}
						if (TrxnResponse.CVV2Match != "Y")
						{
							// Display message that transaction was not accepted.  At this time, you
							// could display message that information is incorrect.  Normally, to prevent
							// fraud you would not want to tell a customer that the 3/4 digit number on
							// the credit card was invalid.
							RespMsg = "Your billing (cvv2) information does not match. Please re-enter.";
							// Here you might want to put in code to flag or void the transaction depending on your needs.
						}
					}
					else if (TrxnResponse.Result == 12)
					{
						// Hard decline from bank.  Customer will need to use another card or payment type.
						RespMsg = "Your transaction was declined.";
					}
					else if (TrxnResponse.Result == 13)
					{
						// Voice authorization required.  You would need to contact your merchant bank to obtain a voice authorization.  If authorization is 
						// given, you can manually enter it via Virtual Terminal in PayPal Manager or via the VoiceAuthTransaction object.
						RespMsg = "Your Transaction is pending. Contact Customer Service to complete your order.";
					}
					else if (TrxnResponse.Result == 23 || TrxnResponse.Result == 24)
					{
						// Issue with credit card number or expiration date.
						RespMsg = "Invalid credit card information. Please re-enter.";
					}
					else if (TrxnResponse.Result == 125)
					{
						// Using the Fraud Protection Service.
						// This portion of code would be is you are using the Fraud Protection Service, this is for US merchants only.
						// 125, 126 and 127 are Fraud Responses.
						// Refer to the Payflow Pro Fraud Protection Services User's Guide or Website Payments Pro Payflow Edition - Fraud Protection Services User's Guide.
						RespMsg = "Your Transactions has been declined. Contact Customer Service.";
					}
					else if (TrxnResponse.Result == 126)
					{
						// One of more filters were triggered.  Here you would check the fraud message returned if you
						// want to validate data.  For example, you might have 3 filters set, but you'll allow 2 out of the
						// 3 to consider this a valid transaction.  You would then send the request to the server to modify the
						// status of the transaction.  Performing this function is outside the scope of this sample, refer
						// to the Fraud Developer's Guide.
						//
						// Decline transaction if AVS fails.
						if (TrxnResponse.AVSAddr != "Y" || TrxnResponse.AVSZip != "Y")
						{
							// Display message that transaction was not accepted.  At this time, you
							// could display message that information is incorrect and redirect user 
							// to re-enter STREET and ZIP information.  However, there should be some sort of
							// strikes your out check.
							RespMsg = "Your billing information does not match.  Please re-enter.";
						}
						else
						{
							RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
						}
						RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
					}
					else if (TrxnResponse.Result == 127)
					{
						// There is an issue with checking this transaction through the fraud service.
						// You will need to manually approve.
						RespMsg = "Your Transaction is Under Review. We will notify you via e-mail if accepted.";
					}
					else
					{
						// Error occurred, display normalized message returned.
						RespMsg = TrxnResponse.RespMsg;
                    }

						// Display Message
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("User/System Response:");
						Console.WriteLine("User Message (RESPMSG) = " + RespMsg);
						Console.WriteLine("System Message (TRXNRESPONSE.RESPMSG) = " + TrxnResponse.RespMsg);

						// Display the status response of the transaction.
						// This is just additional information and normally would not be used in production.
						// Your business logic should be built around the result code returned as shown above.
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Overall Transaction Status: " + PayflowUtility.GetStatus(Resp));

						// Get the Transaction Context and check for any contained SDK specific errors (optional code).
						// This is not normally used in production.
						Context TransCtx = Resp.TransactionContext;
						if (TransCtx != null && TransCtx.getErrorCount() > 0)
						{
							Console.WriteLine("------------------------------------------------------");
							Console.WriteLine("Transaction Context Errors: " + TransCtx.ToString());
						}
                    					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine("Press Enter to Exit ...");
					Console.ReadLine();
					}
				else
				{
					Thread.Sleep(5000); // let's wait 5 seconds to see if this is a temporary network issue.
					Console.WriteLine("Retry #: " + trxCount.ToString());
					trxCount++;
				}
			}
			if (!RespRecd)
			{
				Console.WriteLine("There is a problem obtaining an authorization for your order.");
				Console.WriteLine("Please contact Customer Support.");
				Console.WriteLine("------------------------------------------------------");
				Console.WriteLine("Press Enter to Exit ...");
				Console.ReadLine();
			}
		}
	}
}