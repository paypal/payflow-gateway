using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Recurring Cancel transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DORecurringCancel
	{
		public DORecurringCancel()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurringCancel.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			RecurringInfo RecurInfo = new RecurringInfo();
			RecurInfo.OrigProfileId = "<PROFILE_ID>";  // RT0000001350

			// Create a new Recurring Cancel Transaction.
			RecurringCancelTransaction Trans = new RecurringCancelTransaction(
				User, Connection, RecurInfo, PayflowUtility.RequestId);

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