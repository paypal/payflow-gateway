using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a simple Sale transaction with MEDIUM Verbosity.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// 
	/// Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
	/// processor vary in detail level and in format. The Payflow Verbosity parameter enables you to control the kind
	/// and level of information you want returned. 
	///
	/// By default, Verbosity is set to LOW. A LOW setting causes PayPal to normalize the transaction result values. 
	/// Normalizing the values limits them to a standardized set of values and simplifies the process of integrating 
	/// the Payflow SDK.
	/// 
	/// By setting Verbosity to MEDIUM, you can view the processor’s raw response values. This setting is more “verbose”
	/// than the LOW setting in that it returns more detailed, processor-specific information. 
	/// 
	/// Review the chapter in the Payflow Pro Developer's Guide regarding VERBOSITY and the INQUIRY function for more details.
	/// </summary>
	public class DOVerbosity
	{
		public DOVerbosity()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOVerbosity.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

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
				User, Inv, Card, PayflowUtility.RequestId);

			// Set the transaction verbosity to MEDIUM.
			Trans.Verbosity = "MEDIUM";

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
					Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode);
					Console.WriteLine("PROCAVS = " + TrxnResponse.ProcAVS);
					Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
					Console.WriteLine("PROCCVV2 = " + TrxnResponse.ProcCVV2);
					Console.WriteLine("RESPTEXT = " + TrxnResponse.RespText);
					Console.WriteLine("ADDLMSGS = " + TrxnResponse.AddlMsgs);
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