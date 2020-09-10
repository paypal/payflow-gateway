using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.ExpressCheckout
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a normal GET Express Checkout transaction.
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
	public class DOGetEC
	{
		public DOGetEC()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOGetEC.cs");
			Console.WriteLine("------------------------------------------------------");
			
			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
						
			// Create the Payflow  Connection data object with the required connection details.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Calling a GET operation is second step in PayPal Express checkout process. Once the
			// customner has logged into his/her paypal account, selected shipping address and clicked on 
			// "Continue checkout", the PayPal server will redirect the page to the ReturnUrl you have 
			// specified in the previous SET request.  To obtain the shipping details chosen by the 
			// Customer, you will then need to do a GET operation.
			//
			// For more information on Reference Transactions, see the DOSetEC Sample for more details.

			// For Regular Express Checkout or Express Checkout Reference Transaction with Purchase.
			ECGetRequest GetRequest = new ECGetRequest("<TOKEN>");

			// For Express Checkout Reference Transaction without Purchase.  
			//ECGetBARequest GetRequest = new ECGetBARequest("<TOKEN>");
			
			// Create the Tender.
			PayPalTender Tender = new PayPalTender(GetRequest);

			// Create a transaction.
			AuthorizationTransaction Trans = new AuthorizationTransaction
				(User, Connection, null, Tender, PayflowUtility.RequestId);
			
			// Submit the Transaction
			Response Resp = Trans.SubmitTransaction();

			// Display the transaction response parameters.
			if (Resp != null)
			{
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse =  Resp.TransactionResponse;

				if (TrxnResponse != null)
				{
					Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString());
					Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
					// The TOKEN is needed for the DODoEC Sample.
					Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token);
					Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId);
					Console.WriteLine("EMAIL = " + Trans.Response.ExpressCheckoutGetResponse.EMail);
					// The PAYERID is needed for the DODoEC Sample.
					Console.WriteLine("PAYERID = " + Trans.Response.ExpressCheckoutGetResponse.PayerId);
					Console.WriteLine("PAYERSTATUS = " + Trans.Response.ExpressCheckoutGetResponse.PayerStatus);
					// Express Checkout Transactions and Express Checkout Reference Transactions with Purchase
					// begin with EC, while Express Checkout Reference Transactions without Purchase begin with BA.
					// Reference Transactions without Purchase do not return shipping information.
					if (Trans.Response.ExpressCheckoutSetResponse.Token != null) 
					{
						if (Trans.Response.ExpressCheckoutSetResponse.Token.StartsWith("EC")) 
						{
							Console.WriteLine(Environment.NewLine + "Shipping Information:");
							Console.WriteLine("FIRST = " + Trans.Response.ExpressCheckoutGetResponse.FirstName);
							Console.WriteLine("LAST = " + Trans.Response.ExpressCheckoutGetResponse.LastName);
							Console.WriteLine("SHIPTOSREET = " + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet);
							Console.WriteLine("SHIPTOSTREET2 = " + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet2);
							Console.WriteLine("SHIPTOCITY = " + Trans.Response.ExpressCheckoutGetResponse.ShipToCity);
							Console.WriteLine("SHIPTOSTATE = " + Trans.Response.ExpressCheckoutGetResponse.ShipToState);
							Console.WriteLine("SHIPTOZIP = " + Trans.Response.ExpressCheckoutGetResponse.ShipToZip);
							Console.WriteLine("SHIPTOCOUNTRY = " + Trans.Response.ExpressCheckoutGetResponse.ShipToCountry);
							Console.WriteLine("AVSADDR = " + Trans.Response.TransactionResponse.AVSAddr);
						} 
						// BA_Flag is returned with Express Checkout Reference Transaction with Purchase.
						// See the notes in DOSetEC regarding this feature. 
						if (Trans.Response.ExpressCheckoutGetResponse.BA_Flag != null) 
						{
                            Console.WriteLine(Environment.NewLine + "BA_FLAG = " + Trans.Response.ExpressCheckoutGetResponse.BA_Flag);
							if (Trans.Response.ExpressCheckoutGetResponse.BA_Flag == "1") 
							{							
								Console.WriteLine("Buyer Agreement was created.");
							} 
							else 
							{
								Console.WriteLine("Buyer Agreement not was accepted.");
							}
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
			}
			Console.WriteLine("Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}