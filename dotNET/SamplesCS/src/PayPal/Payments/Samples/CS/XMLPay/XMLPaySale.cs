using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;

namespace PayPal.Payments.Samples.CS.XMLPay
{
	/// <summary>
	/// This class uses the Payflow SDK API to do a simple Sale transaction.
	/// The request is sent as a XML Pay string & the response received 
	/// is also XML Pay string.
	/// </summary>
	public class XMLPaySale
	{
		public XMLPaySale()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: XMLPaySale.cs");
			Console.WriteLine("------------------------------------------------------");

            // Credentials: env vars take priority; App.config (PayflowUser/Vendor/Partner/Password) is the fallback.
            String mUser     = Environment.GetEnvironmentVariable("PAYFLOW_USER")     ?? PayflowUtility.AppSettings("PayflowUser");
            String mVendor   = Environment.GetEnvironmentVariable("PAYFLOW_VENDOR")   ?? PayflowUtility.AppSettings("PayflowVendor");
            String mPartner  = Environment.GetEnvironmentVariable("PAYFLOW_PARTNER")  ?? PayflowUtility.AppSettings("PayflowPartner");
            String mPassword = Environment.GetEnvironmentVariable("PAYFLOW_PASSWORD") ?? PayflowUtility.AppSettings("PayflowPassword");

			// Sample Request.
			String Request = "<?xml version=\"1.0\"?><XMLPayRequest Timeout=\"45\" version=\"2.0\"><RequestData><Partner>" + mPartner + "</Partner><Vendor>" + mVendor + "</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency=\"USD\">25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>203001</ExpDate></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>" + mUser + "</User><Password>" + mPassword + "</Password></UserPass></RequestAuth></XMLPayRequest>";

            // Create an instance of PayflowNETAPI.
            PayflowNETAPI PayflowNETAPI = new PayflowNETAPI();
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
			String TransErrors = PayflowNETAPI.TransactionContext.ToString();
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
