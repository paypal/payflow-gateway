using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.ExpressCheckout
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do an Update Express Checkout transaction. Used
	/// for reference transaction only, see below.
	/// 
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// 
	/// This sample is for reference and for testing purposes only.  See the eStoreFront sample for 
	/// one way to perform an Express Checkout transaction from your web site.
	/// 
	/// Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developer's 
	/// Guide (US, AU) or the Websites Payments Pro Payflow Edition Developer's Guide (UK).
	/// 
	/// Besides doing a standard Express Checkout transactions, you can also do a Express Checkout Reference
	/// Transaction.
	/// 
	/// A reference transaction takes existing billing information already gathered from a previously 
	/// authorized transaction and reuses it to charge the customer in a subsequent transaction. 
	/// Reference transactions, typically used for repeat billing to a merchants PayPal account when 
	/// customers are not present to log in, are now supported through Express Checkout. 
	/// 
	/// NOTE: You must be enabled by PayPal to use reference transactions.  Contact your account manager 
	/// or the sales department for more details.
	/// 
	/// See the DOSetEC Sample for more details on Reference Transations using Express Checkout.
	/// </summary>
	public class DOUpdateEC
	{
		public DOUpdateEC()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOUpdateEC.cs");
			Console.WriteLine("------------------------------------------------------");
			
			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
			
			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// You can use the Update Billing Agreement request to cancel the billing agreement or update
			// the billing agreement description. 
			//
			// For more information on Reference Transactions, see the DOSetEC Sample for more details.

			// For Express Checkout Reference Transaction without Purchase. 
			ECUpdateBARequest UpdateRequest = new ECUpdateBARequest("<BAID>", "<BA_STATUS>", "<BA_DESC>");

			// Create the Tender object.
			PayPalTender Tender = new PayPalTender(UpdateRequest);

			// Create the transaction object.  We do not pass a Transaction Type for an update call.
			BaseTransaction Trans = new BaseTransaction(
				null, User, Connection, null, Tender, PayflowUtility.RequestId);

			// Submit the transaction.
			Response Resp = Trans.SubmitTransaction();

			// Display the transaction response parameters.
			if (Resp != null)
			{
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse =  Resp.TransactionResponse;

				if (TrxnResponse != null)
				{
					// PNREF is not returned with an Update call.
					Console.WriteLine("RESULT = " + TrxnResponse.Result);
					Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);	
					if (TrxnResponse.Result == 0) 
					{
						Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId);
						Console.WriteLine("PAYERID = " + Trans.Response.ExpressCheckoutGetResponse.PayerId);
                        Console.WriteLine("PAYERSTATUS = " + Trans.Response.ExpressCheckoutGetResponse.PayerStatus);
                        Console.WriteLine("FIRST = " + Trans.Response.ExpressCheckoutGetResponse.FirstName);
                        Console.WriteLine("LAST = " + Trans.Response.ExpressCheckoutGetResponse.LastName);
                        Console.WriteLine("EMAIL = " + Trans.Response.ExpressCheckoutGetResponse.EMail);
                        Console.WriteLine("BAID = " + Trans.Response.ExpressCheckoutDoResponse.BAId);
                        Console.WriteLine("BA_STATUS = " + Trans.Response.ExpressCheckoutUpdateResponse.BA_Status);
                        Console.WriteLine("BA_DESC = " + Trans.Response.ExpressCheckoutUpdateResponse.BA_Desc);
					}
				}	

				// If value is true, then the Request ID has not been changed and the original response
				// of the original transction is returned. 
				Console.WriteLine(Environment.NewLine + "DUPLICATE = " + TrxnResponse.Duplicate);
			}

			// Display the response.
			Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp));	
			
			// Get the Transaction Context and check for any contained SDK specific errors (optional code).
			Context TransCtx = Resp.TransactionContext;
			if (TransCtx != null && TransCtx.getErrorCount() > 0)
			{
				Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString());
			}

			Console.WriteLine("Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}