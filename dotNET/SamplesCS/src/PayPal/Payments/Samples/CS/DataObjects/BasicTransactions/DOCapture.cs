using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple Capture transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DOCapture
	{
		public DOCapture()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOCapture.cs");
			Console.WriteLine("------------------------------------------------------");

            // Create the Data Objects.
            // Create the User data object with the required user details.
            UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
 
            // Create the Payflow  Connection data object with the required connection details.
            // The PAYFLOW_HOST property is defined in the App config file.
            PayflowConnectionData Connection = new PayflowConnectionData();
			///////////////////////////////////////////////////////////////////
			
			// If you want to change the amount being captured, you'll need to set the Amount object.
			// Invoice Inv = new Invoice();
			// Set the amount object if you want to change the amount from the original authorization.
			// Currency Code USD is US ISO currency code.  If no code passed, USD is default.
			// See the Developer//s Guide for the list of three-character currency codes available.
			// Currency Amt = new Currency(new decimal(25.12));
			// Inv.Amt = Amt;
			// CaptureTransaction Trans = new CaptureTransaction("<ORIGINAL_PNREF>", User, Connection, Inv, PayflowUtility.RequestId);

			// Create a new Capture Transaction for the original amount of the authorization.  See above if you
			// need to change the amount.
			CaptureTransaction Trans = new CaptureTransaction("<ORIGINAL_PNREF>", User, Connection, PayflowUtility.RequestId);

			// Indicates if this Delayed Capture transaction is the last capture you intend to make.
			// The values are: Y (default) / N
			// NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original reauthorized transaction
			// is automatically voided.  Also, this is only used for UK and US accounts where PayPal is acting
			// as your bank.
			// Trans.CaptureComplete = "N";
            
            // Set the transaction verbosity to HIGH to display most details.
            Trans.Verbosity = "HIGH";
         
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
					// If value is true, then the Request ID has not been changed and the original response
					// of the original transction is returned. 
					Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate);
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