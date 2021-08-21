using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Samples.CS.DataObjects.Recurring;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Base Transaction object to do a simple Sale transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// The Base Transaction object should be used be used only in a remote scenario when the user
	/// needs to do a transaction type which is not directly supported by the transaction objects 
	/// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
	/// terms of specifying the transaction type (TRXTYPE).
	/// For Reference transactions, please use ReferenceTransaction class and for Recurring use 
	/// RecurringTransaction base class.
	/// <seealso cref="DOReference"/>
	/// <seealso cref="DORecurring"/>
	/// </summary>
	public class DOSale_Base
	{
		public DOSale_Base()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOSale_Base.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// Values of connection details can also be passed in the constructor of 
			// PayflowConnectionData. This will override the values passed in the App config file.
			// Example values passed below are as follows:
			// Payflow Pro Host address : pilot-payflowpro.paypal.com 
			// Payflow Pro Host Port : 443
			// Timeout : 45 ( in seconds )
			PayflowConnectionData Connection = new PayflowConnectionData("pilot-payflowpro.paypal.com",443,45);

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(25.1256));
			Inv.Amt = Amt;
			// Truncate the Amount value using the truncate feature of 
			// the Currency Data Object.
			// Note: Currency Data Object also has the Round feature
			// which will round the amount value to desired number of decimal
			// digits ( default 2 ). However, round and truncate cannot be used 
			// at the same time. You can set one of round or truncate true.
			Inv.Amt.Truncate = true;
			// Set the truncation decimal digit to 2.
			Inv.Amt.NoOfDecimalDigits = 2;

			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";

			// Set the Billing Address details.
			BillTo Bill = new BillTo();
			Bill.BillToStreet = "123 Main St.";
			Bill.BillToZip = "12345";
			Inv.BillTo = Bill;

			// Create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0115");
			CC.Cvv2 = "123";

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);
			///////////////////////////////////////////////////////////////////

			// Create a new Base Transaction.
			BaseTransaction Trans = new BaseTransaction("S",
				User, Connection, Inv, Card, PayflowUtility.RequestId);

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