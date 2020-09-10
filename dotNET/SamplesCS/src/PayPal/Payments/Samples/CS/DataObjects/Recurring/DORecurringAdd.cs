using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Recurring Add transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DORecurringAdd
	{
		public DORecurringAdd()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurringAdd.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Creating a profile where our customer is paying three installments of $25.75 with a shipping
			// charge of $9.95.  So, our first payment will be $25.75 + 9.95 with two more payments of $25.75 due.
			//
			// This is just one example of how you might create a new profile.

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(25.75), "USD");
			Inv.Amt = Amt;
			//Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";

			// Set the Billing Address details.
			// Only Street and Zip are set below for AVS check; however, you would probably want
			// to include full name and address information.
			BillTo Bill = new BillTo();
			Bill.BillToStreet = "123 Main St.";
			Bill.BillToZip = "12345";
			Bill.BillToCountry = "US";
			Inv.BillTo = Bill;

			// Create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0115");
			// CVV2 is used for Optional Transaction (Sale or Authorization) Only.  It is not stored as
			// part of the profile, nor is it sent when payments are made.
			CC.Cvv2 = "123";
            
			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);

			RecurringInfo RecurInfo = new RecurringInfo();
			// The date that the first payment will be processed. 
			// This will be of the format mmddyyyy.
			RecurInfo.Start = "07152008";
			RecurInfo.ProfileName = "Test_Profile"; // User provided Profile Name.

			// Specifies how often the payment occurs. All PAYPERIOD values must use 
			// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT / 
			// QTER / SMYR / YEAR
			RecurInfo.PayPeriod = "WEEK";
			RecurInfo.Term = 2; // Number of payments

			// Peform an Optional Transaction.
			RecurInfo.OptionalTrx = "S";  // S = Sale, A = Authorization
			// Set the amount if doing a "Sale" for the Optional Transaction.
			Currency oTrxAmt = new Currency(new decimal(25.75 + 9.95), "USD");  
			RecurInfo.OptionalTrxAmt = oTrxAmt;

			// Create a new Recurring Add Transaction.
			RecurringAddTransaction Trans = new RecurringAddTransaction(
				User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId);

			// Use ORIGID to create a profile based on the details of another transaction. See Reference Transaction. 
			//Trans.OrigId = "<ORIGINAL_PNREF>";

			// Submit the Transaction
			Response Resp = Trans.SubmitTransaction();

			// Display the transaction response parameters.
			if (Resp != null)
			{
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse =  Resp.TransactionResponse;

				if (TrxnResponse != null)
				{
					Console.WriteLine("RESULT = " + TrxnResponse.Result);
					Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
				}

				// Get the Recurring Response parameters.
				RecurringResponse RecurResponse = Resp.RecurringResponse;
				if (RecurResponse != null)
				{
					String ProfileMsg;
					if (TrxnResponse.Result == 0)
					{
						ProfileMsg = "Profile Created.";
					} 
					else 
					{
						ProfileMsg = "Error, Profile Not Created.";
					}
					Console.WriteLine("------------------------------------------------------");
					Console.WriteLine(("Profile Status: " + ProfileMsg));
					Console.WriteLine("Recurring Profile Reference (RPREF) = " + RecurResponse.RPRef);
					Console.WriteLine("Recurring Profile ID (PROFILEID) = " + RecurResponse.ProfileId);
	
					// Was an Optional Transaction processed?
					if (RecurResponse.TrxResult != null) 
					{
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Optional Transaction Details:");
						Console.WriteLine("Transaction PNREF (TRXPNREF) = " + RecurResponse.TrxPNRef);
						Console.WriteLine("Transaction Result (TRXRESULT) = " + RecurResponse.TrxResult);
						Console.WriteLine("Transaction Message (TRXRESPMSG) = " + RecurResponse.TrxRespMsg);
						Console.WriteLine(("Authorization (AUTHCODE) = " + TrxnResponse.AuthCode));
						Console.WriteLine(("Security Code Match (CVV2MATCH) = " + TrxnResponse.CVV2Match));
						Console.WriteLine(("Street Address Match (AVSADDR) = " + TrxnResponse.AVSAddr));
						Console.WriteLine(("Streep Zip Match (AVSZIP) = " + TrxnResponse.AVSZip));
						Console.WriteLine(("International Card (IAVS) = " + TrxnResponse.IAVS));

						// Was this a duplicate transaction?
						// If this value is true, you will probably receive a result code 19, Original transaction ID not found.
						Console.WriteLine("------------------------------------------------------");
						Console.WriteLine("Duplicate Response:");
						String DupMsg;
						if (TrxnResponse.Duplicate == "1")
						{

							DupMsg = "Duplicate Transaction";
						}
						else 
						{
							DupMsg = "Not a Duplicate Transaction";
						}
						Console.WriteLine("Duplicate Transaction (DUPLICATE) = " + DupMsg);
					}
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
			Console.WriteLine("Press Enter to Exit ...");
			Console.ReadLine();
		}

				
	}
}