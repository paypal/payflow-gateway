using System;
using System.Globalization;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple Partial Authorize transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// 
	/// Partial Approval is supported for Visa, MasterCard, American Express and Discover (JCB 
	/// (US Domestic only), and Diners) Prepaid card products such as gift, Flexible Spending Account 
	/// (FSA) or Healthcare Reimbursement Account (HRA) cards. In addition Discover (JCB (US Domestic only), 
	/// and Diners) supports partial Approval on their consumer credit card. It is often difficult for the 
	/// consumer to spend the exact amount available on the prepaid account, as the purchase can be for 
	/// amounts greater than the value available. This can result in unnecessary declines. Visa, MasterCard, 
	/// American Express and Discover (JCB (US Domestic only), and Diners) recognize that the prepaid products 
	/// represent unique opportunities for both merchants and consumers. With Partial Approval issuers may 
	/// approve a portion of the amount requested. This will enable the residual transaction amount to be 
	/// paid by other means. The introduction of the partial approval capability will reduce decline frequency 
	/// and enhance the consumer and merchant experience at the point of sale. Merchants will now have the 
	/// ability to accept partial approval rather than having the sale declined. 
	/// </summary>
	public class DOPartialAuth
	{
		public DOPartialAuth()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOPartialAuth.cs");
			Console.WriteLine("------------------------------------------------------");
			
			// Refer to the DOSaleComplete.cs sample for a more detailed explaination of fields.
			//
			//Create the Data Objects.
			// Creates a CultureInfo for English in the U.S.
			// Not necessary, just here for example of using currency formatting.
			CultureInfo us = new CultureInfo("en-US");
			String usCurrency = "USD";

			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();
            
            // Set the amount and currency being used.  
            // See the Developer's Guide for the list of the three-digit currency codes.
            // Refer to the Payflow Pro Developer's Guide on testing parameters for Partial Authorization.
            // In this example, sending $120.00 will generate a partial approval of only $100.00.

			Currency Amt = new Currency(new decimal(120.00), usCurrency);
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";
			
			// Set the Billing Address details.
			BillTo Bill = new BillTo();
			Bill.BillToFirstName = "Sam";
			Bill.BillToLastName = "Smith";
			Bill.BillToStreet = "123 Main St.";
			Bill.BillToZip = "12345";
			Inv.BillTo = Bill;

			// Create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0115");
			CC.Cvv2 = "123";

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);

			// Create a new Auth Transaction.
			AuthorizationTransaction Trans = new AuthorizationTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId);

			// Set the flag to request that Partial Authorizations be accepted.
			Trans.PartialAuth = "Y";

			// You must set the transaction verbosity to HIGH to display the appropriate response.
			Trans.Verbosity = "HIGH";

			// Submit the Transaction
			Response Resp = Trans.SubmitTransaction();

			// Display the transaction response parameters.
			if (Resp != null)
			{
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse =  Resp.TransactionResponse;

				// Refer to the Payflow Pro .NET API Reference Guide and the Payflow Pro Developer's Guide
				// for explanation of the items returned and for additional information and parameters available.
				if (TrxnResponse != null)
				{
					Console.WriteLine("Transaction Response:");
					Console.WriteLine("Result Code (RESULT) = " + TrxnResponse.Result);
					Console.WriteLine("Transaction ID (PNREF) = " + TrxnResponse.Pnref);
					// If the amount is partially authorized the RESPMSG will be "Partial Approval".
					// If the amount is fully authorized the RESPMSG will be "Approved".
					Console.WriteLine("Response Message (RESPMSG) = " + TrxnResponse.RespMsg);
					Console.WriteLine("Authorization (AUTHCODE) = " + TrxnResponse.AuthCode);
					Console.WriteLine("Street Address Match (AVSADDR) = " + TrxnResponse.AVSAddr);
					Console.WriteLine("Streep Zip Match (AVSZIP) = " + TrxnResponse.AVSZip);
					Console.WriteLine("International Card (IAVS) = " + TrxnResponse.IAVS);
					Console.WriteLine("CVV2 Match (CVV2MATCH) = " + TrxnResponse.CVV2Match);
					Console.WriteLine("------------------------------------------------------");
                    // These are all new items returned when VERBOSITY=HIGH.
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
							default:
								Console.WriteLine("Unknown: " + TrxnResponse.CardType); // new or unknown card type
								break;
						}
					}
					Console.WriteLine("Expiration Date (EXPDATE) = " + TrxnResponse.ExpDate);
					Console.WriteLine("Billing Name (FIRSTNAME, LASTNAME) = " + TrxnResponse.FirstName + " " + TrxnResponse.LastName);
					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine("Verbosity Response:");
					Console.WriteLine("Processor AVS (PROCAVS) = " + TrxnResponse.ProcAVS);
					Console.WriteLine("Processor CSC (PROCCVV2) = " + TrxnResponse.ProcCVV2);
					Console.WriteLine("Processor Result (HOSTCODE) = " + TrxnResponse.HostCode);
					Console.WriteLine("Transaction Date/Time (TRANSTIME) = " + TrxnResponse.TransTime);
					
					// For Partial Authorization you will need to check the following 3 items to see if the card was
					// fully authorized or partially authorized.
					//
					// For example, if you send in a request of $120.00 (AMT=120.00) and the card only has $100.00 of available credit on it,
					// the card will be authorized for $100.00, the AMT field will be changed from 120 to 100 (AMT=100.00 to reflect this.
					// The balance of $20.00 which is still due will be returned in the BALAMT (BALAMT=-20.00) field and the ORIGAMT field 
					// will contain the original requested amount (ORIGAMT=120.00).
					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine("Partial Payment Response:");
                    Console.WriteLine("Original Amount (ORIGAMT) = " + TrxnResponse.OrigAmt);
					Console.WriteLine("Amount of Transaction (AMT) = " + TrxnResponse.Amt);
					if (Convert.ToDecimal(TrxnResponse.BalAmt)== 0 & (Convert.ToDecimal(TrxnResponse.OrigAmt) > Convert.ToDecimal(TrxnResponse.Amt))) 
					{
						decimal BalDue = Convert.ToDecimal(TrxnResponse.OrigAmt) - Convert.ToDecimal(TrxnResponse.Amt); 
						if (BalDue > 0) 
						{
							// Seems a balance is still due, collect the difference.
							Console.WriteLine("Please provide additional payment of: " + BalDue.ToString("c", us));
						} 
						else if (BalDue == 0) 
						{
							Console.WriteLine("Transaction is Paid in Full.");
						} 
						else 
						{
							// Card still has available balance on it.
							Console.WriteLine("Balance Amount (BALAMT) = " + TrxnResponse.BalAmt);
						}
					}
					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate);
				}

				// Display the response.
				Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp));	

				// Get the Transaction Context and check for any contained SDK specific errors (optional code).
				Context TransCtx = Resp.TransactionContext;
				if (TransCtx != null && TransCtx.getErrorCount() > 0)
				{
					Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString());
				}
			}
			Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}