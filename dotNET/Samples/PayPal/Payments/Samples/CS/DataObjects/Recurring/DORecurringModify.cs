using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Recurring Modify transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DORecurringModify
	{
		public DORecurringModify()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurringModify.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			RecurringInfo RecurInfo = new RecurringInfo();
			RecurInfo.OrigProfileId = "<PROFILE_ID>";  // RT0000001350
			RecurInfo.ProfileName = "<PROFILE_NAME>";  // Test_Profile 
			
			// Create a new Invoice data object with the Amount, Billing Address etc. details for the data you 
            // want to change.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(25.12));
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";
			
			// Set the Billing Address details.
			BillTo Bill = new BillTo();
			Bill.BillToStreet = "123 Main St.";
			Bill.BillToZip = "12345";
			Bill.BillToEmail = "abc@abc.com";
			Bill.BillToPhone = "123-123-1234";
			Inv.BillTo = Bill;

			// If you want to modify the credit card information, create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0115");

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);

			// If NO card details available and want to modify only information like E-Mail or Phone Number, use following:
			//RecurringModifyTransaction Trans = new RecurringModifyTransaction(User, Connection, RecurInfo, Inv, null, PayflowUtility.RequestId);
			
			// If you want to modify the RecurringInfo information only, use the following:
			//RecurringModifyTransaction Trans = new RecurringModifyTransaction(User, Connection, RecurInfo, PayflowUtility.RequestId);

			// Create a new Recurring Modify Transaction.
			RecurringModifyTransaction Trans = new RecurringModifyTransaction(User, Connection, RecurInfo, Inv, Card, PayflowUtility.RequestId);
			
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
					Console.WriteLine("RPREF = " + RecurResponse.RPRef);
					Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);
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