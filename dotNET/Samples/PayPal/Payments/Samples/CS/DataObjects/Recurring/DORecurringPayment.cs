using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Recurring Payment transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DORecurringPayment
	{
		public DORecurringPayment()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurringPayment.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			RecurringInfo RecurInfo = new RecurringInfo();
			RecurInfo.OrigProfileId = "<PROFILE_ID>";  // RT0000001350
			RecurInfo.PaymentNum = "2";  // The failed payment to be retried.

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
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
			Inv.BillTo = Bill;
			///////////////////////////////////////////////////////////////////

			// Create a new Recurring Payment Transaction.
			RecurringPaymentTransaction Trans = new RecurringPaymentTransaction(
				User, Connection, RecurInfo, Inv, PayflowUtility.RequestId);

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