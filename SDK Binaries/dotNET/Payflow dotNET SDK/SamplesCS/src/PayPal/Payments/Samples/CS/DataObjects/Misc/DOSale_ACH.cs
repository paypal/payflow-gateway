using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple ACH - Sale transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// 
	/// Refer to the Payflow ACH Payment Service Guide for more information.
	/// 
	/// </summary>
	public class DOSale_ACH
	{
		public DOSale_ACH()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOSale_ACH.cs");
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

			// Create a new Payment Device - Bank Account data object.
			// The input parameters are Account No. and ABA.
			BankAcct BA = new BankAcct("1111111111", "111111118");
			// The Account Type can be "C" for Checking and "S" for Saving.
			BA.AcctType = "C";
			BA.Name = "John Doe";

			// Create a new Tender - ACH Tender data object.
			ACHTender ACH = new ACHTender(BA);
			//ACH.AuthType = "PPD";
			//ACH.ChkNum = "1234";

			// Create a new ACH - Sale Transaction.
			SaleTransaction Trans = new SaleTransaction(
				User, Connection, Inv, ACH, PayflowUtility.RequestId);

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