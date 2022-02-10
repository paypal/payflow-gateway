using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple reference Credit transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DOReferenceCredit
	{
		public DOReferenceCredit()
		{
		}

		public static void Main(string[] Args)
		{
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: DOReferenceCredit.cs");
            Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();
			///////////////////////////////////////////////////////////////////
			
			// If you want to change the amount being credited, you'll need to set the Amount object.
			//Invoice Inv = new Invoice();
			// Set the amount object if you want to change the amount from the original transaction.
			// Currency Code USD is US ISO currency code.  If no code passed, USD is default.
			// See the Developer's Guide for the list of three-character currency codes available.
			//Currency Amt = new Currency(new decimal(10.00));
			//Inv.Amt = Amt;
			//CreditTransaction trans = new CreditTransaction("<ORIGINAL_PNREF>", User, Connection, Inv, PayflowUtility.getRequestId());

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(25.12));
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";

			// Create a new Credit Transaction from the original transaction.  See above if you
			// need to change the amount.
			CreditTransaction Trans = new CreditTransaction("<ORIGINAL_PNREF>", User, Connection, Inv, PayflowUtility.RequestId);

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