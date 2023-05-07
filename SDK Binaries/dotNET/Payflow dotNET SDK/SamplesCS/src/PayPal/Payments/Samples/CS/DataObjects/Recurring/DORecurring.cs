using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Samples.CS.DataObjects.Misc;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Recurring Transaction object to do a simple Recurring Add transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// The Recurring Transaction object should be used be used only in a remote scenario when the user
	/// needs to do a recurring transaction type which is not directly supported by the transaction objects 
	/// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
	/// terms of specifying the transaction type (TRXTYPE).
	/// For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction 
	/// base class.
	/// <seealso cref="DOSale_Base"/>
	/// <seealso cref="DOReference"/>
	/// </summary>
	public class DORecurring
	{
		public DORecurring()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurring.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object details.
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
			CreditCard CC = new CreditCard("5105105105105100", "0115");
			CC.Cvv2 = "123";

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);

			RecurringInfo RecurInfo = new RecurringInfo();
			// The date that the first payment will be processed. 
			// This will be of the format mmddyyyy.
			RecurInfo.Start = "01012009";
			RecurInfo.ProfileName = "PayPal";
			// Specifies how often the payment occurs. All PAYPERIOD values must use 
			// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT / 
			// QTER / SMYR / YEAR
			RecurInfo.PayPeriod = "WEEK";
			///////////////////////////////////////////////////////////////////

			// Create a new Recurring Transaction.
			RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
				User, Connection, Inv, Card, PayflowUtility.RequestId);

			// Submit the Transaction
			Response Resp = Trans.SubmitTransaction();

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
			}

			// Display the response.
			Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp));	
			
			// Get the Transaction Context and check for any contained SDK specific errors (optional code).
			Context TransCtx = Resp.TransactionContext;
			if (TransCtx != null && TransCtx.getErrorCount() > 0)
			{
				Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString());
			}
			Console.WriteLine(Environment.NewLine + "Press Enter to Continue ...");						
			Console.ReadLine();
		}

	}
}