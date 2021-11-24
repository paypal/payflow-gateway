using System;
using System.Diagnostics;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do create a Secure Token used with the 
    /// hosted checkout page.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DOSecureTokenAuth
	{
		public DOSecureTokenAuth()
		{
		}

		public static void Main(string[] Args)
		{
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: DOSecureTokenAuth.cs");
            Console.WriteLine("------------------------------------------------------");
			
			// Create the Data Objects.
			// Create the User data object with the required user details.
		//	UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");
            //UserInfo User = new UserInfo("toddprov22", "toddprov22", "ChannelSales", "toddprov226");
            UserInfo User = new UserInfo("jkarthikeyanTestNew1", "jkarthikeyanTestNew1", "ChannelSales", "test12345");

			// Create the Payflow  Connection data object with the required connection details.
            PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.  The amount cannot be changed once submitted.
			Currency Amt = new Currency(new decimal(25.00), "USD");
			Inv.Amt = Amt;
			Inv.InvNum = "INV12345";

			// Set the Billing Address details.  You can also send the shipping information.  Both the Billing
			// and Shipping information can be changed if the functionality is allowed in the Configuration section
			// of Manager.  No other information submitted using a secure token call can be changed.
			BillTo Bill = new BillTo();
			Bill.FirstName = "Sam";
			Bill.LastName = "Smith";
			Bill.Street = "123 Main St.";
            Bill.City = "Anytown";
            Bill.State = "CA";
		    Bill.Zip = "12345";
            Bill.PhoneNum = "408-123-1234";
            Bill.Email = "test@myemail.com";
            Bill.Country = "124";
			Inv.BillTo = Bill;

            // Create a new Payment Device - Credit Card data object.
            // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
            CreditCard CC = new CreditCard("5105105105105100", "0110");
            CC.Cvv2 = "023";

            // Create a new Tender - Card Tender data object.
            CardTender Card = new CardTender(CC);
            ///////////////////////////////////////////////////////////////////

			// Since we are using the hosted payment pages, you will not be sending the credit card data with the 
			// Secure Token Request.  You just send all other 'sensitive' data within this request and when you
			// call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
            // and the SECURETOKENID that was created and used in the request.
            //
			// Create a new Secure Token Authorization Transaction.  Even though this example is performing
			// an authorization, you can create a secure token using SaleTransaction too.  Only Authorization and Sale
			// type transactions are permitted.
            //
            // Remember, all data submitted as part of the Secure Token call cannot be modified at a later time.  The only exception
            // is the billing and shipping information if these items are selection in the Setup section in PayPal Manager.
            AuthorizationTransaction Trans = new AuthorizationTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId);

            // Set VERBOSITY to High
            Trans.Verbosity = "High";

            // Set the flag to create a Secure Token.
			Trans.CreateSecureToken = "Y";
			// The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to 
			// generate a random id, but any means to create an id can be used.
			Trans.SecureTokenId = PayflowUtility.RequestId;

            // Set the extended data value.
            ExtendData ExtData = new ExtendData("SILENTRANS", "True");
            // Add extended data to transaction.
            Trans.AddToExtendData(ExtData);

            // IMPORTANT NOTE:
            // 
            // Remember, the Secure Token can only be used once.  Once it is redeemed by a valid transaction it cannot be used again and you will 
            // need to generate a new token.  Also, the token has a life time of 30 minutes.

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
					Console.WriteLine("SECURETOKEN = " + TrxnResponse.SecureToken);
					Console.WriteLine("SECURETOKENID = " + TrxnResponse.SecureTokenId);
					// If value is true, then the Request ID has not been changed and the original response
					// of the original transction is returned. 
					Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate);
				}

                if (TrxnResponse.Result == 0)
                {
                    Console.WriteLine(Environment.NewLine + "Transaction was successful.");
                    Console.WriteLine(Environment.NewLine + "The next step would be to redirect to PayPal to display the hosted");
                    Console.WriteLine("checkout page to allow your customer to select and enter payment.");
                    Console.WriteLine(Environment.NewLine + "This is only a simple example, which does not take into account things like");
                    Console.WriteLine(Environment.NewLine + "RETURN or SILENT POST URL, etc.");
                    Console.WriteLine(Environment.NewLine + "Press <Enter> to redirect to PayPal.");
                    Console.ReadLine();
                    // Simple way to pass token data to Payflow Link Servers.
                    String PayPalUrl = "https://payflowlink.paypal.com?securetoken=" + TrxnResponse.SecureToken + "&securetokenid=" + TrxnResponse.SecureTokenId + "&MODE=test&USER1=testuser1&ACCT=5105105105105100&EXPDATE=1212&CVV2=123";
                    //Process.Start(PayPalUrl);  // Open default browser.
                    Process.Start("iexplore.exe", PayPalUrl);
                    //Process.Start("C:\\Program Files\\Mozilla Firefox\\firefox.exe", PayPalUrl);
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