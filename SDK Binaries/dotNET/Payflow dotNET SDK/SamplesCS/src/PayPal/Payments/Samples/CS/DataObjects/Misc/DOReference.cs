using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Samples.CS.DataObjects.Recurring;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Misc
{
	/// <summary>
	/// This class uses the Payflow SDK Reference Transaction object to do a Sale transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// The Reference Transaction object should be used be used only in a remote scenario when the user
	/// needs to do a reference transaction type which is not directly supported by the transaction objects 
	/// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
	/// terms of specifying the transaction type (TRXTYPE).
	/// For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction 
	/// base class.
	/// <seealso cref="DOSale_Base"/>
	/// <seealso cref="DORecurring"/>
	/// </summary>
	public class DOReference
	{
		public DOReference()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOReference.cs");
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
            Inv.Recurring = "Y";

            // Create a new Tender - Base Tender data object and set the Tender Type to "C".
            // We do not pass any payment device
            BaseTender Tender = new BaseTender("C",null);
            
            // To modify the expiration date, we will also need to create a CreditCard object
            // without passing the credit card number.
            //CreditCard CC = new CreditCard(null, "1215");
            //CardTender Card = new CardTender(CC);

            // Create a new Reference Transaction.
            ReferenceTransaction Trans = new ReferenceTransaction("A", "<PNREF>",User, Connection, Inv, Tender, PayflowUtility.RequestId);
            // If expiration date is changed too.
            //ReferenceTransaction Trans = new ReferenceTransaction("S", "<PNREF>", User, Connection, Inv, Tender, PayflowUtility.RequestId);

            // You can also change the expiration date of the new reference transaction, by passing the EXPDATE via the ExtendData object.
            //ExtendData ExpDate = new ExtendData("EXPDATE", "1215");
            //Trans.AddToExtendData(ExpDate);

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