using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple Sale transaction.
	/// This class also shows how to add/remove custom client information header in a transaction
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DOAdditionalHeaders
	{
		public DOAdditionalHeaders()
		{
		}

		public static void Main(string[] Args)
		{
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: DOAdditionalHeaders.cs");
            Console.WriteLine("------------------------------------------------------");
			
			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(25.12));
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";

			// Set the Billing Address details.
			BillTo Bill = new BillTo();
			Bill.Street = "123 Main St.";
			Bill.Zip = "12345";
			Inv.BillTo = Bill;

			// Create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0109");
			CC.Cvv2 = "123";

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);
			///////////////////////////////////////////////////////////////////

			// Create a new Sale Transaction.
			SaleTransaction Trans = new SaleTransaction(
				User, Connection, Inv, Card, PayflowUtility.RequestId);

			// Add a new custom client informartion header 
			// to the transaction.
			Trans.AddTransHeader("X-VPS-VIT-WRAPPER-TYPE","VRSN-CS-SAMPLE");

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
					Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
					Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
					Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
					Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
					Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
					Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
					Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
				}

				// Get the Fraud Response parameters.
				FraudResponse FraudResp =  Resp.FraudResponse;
				// Display Fraud Response parameter
				if (FraudResp != null)
				{
					Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
					Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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