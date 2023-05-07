using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple Telecheck - Sale transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DOSale_Telecheck
	{
		public DOSale_Telecheck()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOSale_Telecheck.cs");
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
			Bill.City = "New York";
			Bill.State = "PA";
			Bill.Email = "ivan@test.com";
			Inv.BillTo = Bill;

			// Create a new Payment Device - Check Payment data object.
			// The input parameters is MICR. Magnetic Ink Check Reader. This is the entire line
			// of numbers at the bottom of all checks. It includes the transit number, account 
			// number, and check number.
			CheckPayment ChkPayment = new CheckPayment("1234567804390850001001");
			
			// Name property needs to be set for the Check Payment.
			ChkPayment.Name = "Ivan Smith";

			// Create a new Tender - Check Tender data object.
			CheckTender ChkTender = new CheckTender(ChkPayment);
			// Account holder’s next unused (available) check number. Up to 7 characters.
			ChkTender.ChkNum = "1234";
			
			// DL or SS is required for a TeleCheck transaction.
			// If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
			// If CHKTYPE=C, the Federal Tax ID must be passed as the SS value.
			ChkTender.ChkType = "P";
            ChkTender.AuthType = "P";

      
			// Driver’s License number. If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
			// Format: XXnnnnnnnn
			// XX = State Code
			// nnnnnnnn = DL Number - up to 31 characters.
			ChkTender.DL = "CAN85452345";
          
			// Social Security number.
			//ChkTender.SS = "456765833"

			///////////////////////////////////////////////////////////////////

			// Create a new Telecheck - Sale Transaction.
			SaleTransaction Trans = new SaleTransaction(
				User, Connection, Inv, ChkTender, PayflowUtility.RequestId);

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