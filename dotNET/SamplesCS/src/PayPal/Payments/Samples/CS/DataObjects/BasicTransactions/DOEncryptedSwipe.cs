using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
    /// <summary>
    /// This class uses the Payflow SDK Data Objects to do a simple Authorize transaction using Encrypted Swipe Data 
    /// from card readers by Magtek, http://www.magtek.com.
    /// 
    /// The request is sent as a Data Object and the response received is also a Data Object.
    /// Payflow Pro supports card-present transactions (face-to-face purchases).
    /// 
    /// Follow these guidelines to take advantage of the lower card-present transaction rate:
    /// 
    ///		* Contact your merchant account provider to ensure that they support card-present transactions.
    ///		* Contact PayPal Customer Service to request having your account set up properly for accepting and passing 
    ///		  swipe data.
    ///		* If you plan to process card-present as well as card-not-present transactions, set up two separate Payflow
    ///		  Pro accounts.  Request that one account be set up for card-present transactions, and use it solely for that
    ///		  purpose. Use the other for card-not-present transactions. Using the wrong account may result in downgrades.
    ///		* A Sale is the preferred method to use for card-present transactions. Consult with your acquiring bank for
    ///		  recommendations on other methods.
    ///		
    ///	NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.  This would include Website
    ///	      Payments Pro UK accounts.
    ///	
    ///	See the Payflow Gateway Developer Guide and Reference at https://developer.paypal.com/docs/classic/payflow/integration-guide for more information.
    /// </summary>
    public class DOEncryptedSwipe
	{
		public DOEncryptedSwipe()
		{
		}

		public static void Main(string[] Args)
		{
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: DOEncryptedSwipe.cs");
            Console.WriteLine("------------------------------------------------------");

            // Create the Data Objects.
            // Create the User data object with the required user details.
            UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

            // Create the Payflow Connection data object with the required connection details.
            // The PAYFLOW_HOST property is defined in the App config file.
            PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(1.00));
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";
			Inv.Comment1 = "Magtek Encrypted Swipe Example";

            // Create a new Payment Device - Swipe data object.  The input parameter is Swipe Data.
            // The data passed in this example will be extracted from a Magtek Encrypted Card reader.  Please refer
            // to the Magtek SDK and documentation on how to obtain the data from the reader.
            // The parameter data for the SwipeCard object is usually obtained with a card reader and this shows
            // how to send data obtained from a Magtek Encrypted reader.
            // NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.

            // Create a new Magtek data object with the device serial number, track data, etc.
            MagtekInfo MT = new MagtekInfo();

            // The data below CANNOT be used for Testing. It is only here to show what the data fields look like once you
            // obtain them from the reader itself.  Refer to the Payflow Pro Developers Guide and the Appendix related to processing
            // with Magtek card readers for more information.
            // The Payflow Gateway Developer Guide and Reference found at https://developer.paypal.com/docs/classic/payflow/integration-guide/
            MT.DeviceSN = "B32XXXXXXXXXXAA";
            MT.EncMP = "34F29380E6AFED395472A63063B6XXXXXXXXXXXXXXXXXXXXXXXXXC987D2A1F7A50554DFC4A0D215A8AA0591D82B6DB13516F220C4CB93899";
            MT.EncryptionBlockType = "1";
            MT.EncTrack1 = "80BC13515EF76421FCXXXXXXXXXXXXXXXXXXXXXXXXX02E53C0ECCC83B1787DE05BB5D8C7FA679D0C40CC989F7FAF307FE7FD0B588261DDA0";
            MT.EncTrack2 = "4CDD6BC521B397CD2DB1324199XXXXXXXXXXXXXXXXXXXXXXXXX83A9044B397C1D14AFEE2C0BA1002";
            MT.EncTrack3 = "";
            MT.KSN = "901188XXXXXXXXXX00F4";
            MT.MagtekCardType = "1";
            MT.MPStatus = "61403000";
            MT.RegisteredBy = "PayPal";
            MT.SwipedECRHost = "MAGT";
            
            // When using Encrypted Card Readers you do not populate the SwipeCard object as the data from the Magtek object
            // will be used instead.
            SwipeCard Swipe = new SwipeCard("");
            Swipe.MagtekInfo = MT;
                        
        	// Create a new Tender - Swipe Tender data object.
			CardTender Card = new CardTender(Swipe);

			// Create a new Sale Transaction using Swipe data.
			SaleTransaction Trans = new SaleTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId);

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
                    // Magtek Response will only be available if a failure or error in the request.
                    Console.WriteLine("MAGTRESPONSE = " + TrxnResponse.MagTResponse);
					// If value is true, then the Request ID has not been changed and the original response
                    // of the original transction is returned. 
                    Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate);
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