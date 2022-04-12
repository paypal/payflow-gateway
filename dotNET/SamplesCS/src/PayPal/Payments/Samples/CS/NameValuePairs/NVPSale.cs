using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;

namespace PayPal.Payments.Samples.CS.NameValuePairs
{
	/// <summary>
	/// This class uses the Payflow SDK API to do a simple Sale transaction.
	/// The request is sent as a Name-Value pair string & the response received
	/// is also Name-Value Pair string.
	/// </summary>
	public class NVPSale
	{
		public NVPSale()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: NVPSale.cs");
			Console.WriteLine("------------------------------------------------------");

            // Sample Request.
            // Please replace <user>, <vendor>, <password> & <partner> with your merchant information.
            String Request = "USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>&TRXTYPE=S&ACCT=5105105105105100&EXPDATE=0125&TENDER=C&INVNUM=INV12345&AMT=25.12&PONUM=PO12345&STREET=123 Main St.&ZIP=12345";

			// Create an instance of PayflowNETAPI.
			PayflowNETAPI PayflowNETAPI = new PayflowNETAPI();
			// Can also pass the values in the constructor itself instead of using .config file.
			PayflowNETAPI.SetParameters("pilot-payflowpro.paypal.com", 443, 45, "", 0, "", "", "enabled", "1", "payflow.log", "10240000", false);

			// RequestId is a unique string that is required for each & every transaction.
			// The merchant can use her/his own algorithm to generate this unique request id or
			// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
			//
			// NOTE: Review the comments in the DoSaleComplete example under BasicTransactions for
			// more information on the Request ID.
			String Response = PayflowNETAPI.SubmitTransaction(Request, PayflowUtility.RequestId);

			// To write the Response on to the console.
			Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest);
			Console.WriteLine(Environment.NewLine + "Response = " + Response);
			// Following lines of code are optional.
			// Begin optional code for displaying SDK errors ...
			// It is used to read any errors that might have occurred in the SDK.
			// Get the transaction errors.
			String TransErrors = PayflowNETAPI. TransactionContext.ToString();
			if (TransErrors != null && TransErrors.Length > 0)
			{
				Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
			}
			Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(Response));
			Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}
