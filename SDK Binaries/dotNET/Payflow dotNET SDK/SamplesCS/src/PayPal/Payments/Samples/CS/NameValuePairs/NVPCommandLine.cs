using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;

namespace PayPal.Payments.Samples.CS.NameValuePairs
{
	/// <summary>
	/// This class uses the Payflow SDK API to do a simple Sale transaction from the Command Line.
	/// The request is sent as a Name-Value pair string & the response received is also 
	/// Name-Value Pair string.
	/// </summary>
	public class NVPCommandLine
	{
		public NVPCommandLine()
		{
		}
		
		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: NVPCommandLine.cs");
			Console.WriteLine("------------------------------------------------------");

			String ResponseStr = null;
			if (Args.Length < 4)
			{
				Console.WriteLine(Environment.NewLine + "Incorrect number of arguments. Usage:" + Environment.NewLine 
					+ "SamplesCS <hostAddress> <hostPort> <parmList> <timeOut> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>");
				Console.WriteLine(Environment.NewLine + "Example transaction:" + Environment.NewLine + "SamplesCS pilot-payflowpro.paypal.com 443 \"USER=<user>&TRXTYPE[1]=A&VENDOR=<vendor>&AMT[5]=25.00&PWD=<password>&PARTNER=<partner>&TENDER[1]=C&ACCT[16]=5100000000000008&EXPDATE[4]=0115\" 45");
				Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
				Console.ReadLine();
				System.Environment.Exit(-1);
			}

			PayflowNETAPI PayflowNETAPI;
			if (Args.Length == 4)
			{
				PayflowNETAPI = new PayflowNETAPI(Args[0], 
					System.Convert.ToInt32(Args[1]),
					System.Convert.ToInt32(Args[3]));
			}
			else
			{
				PayflowNETAPI = new PayflowNETAPI(Args[0], 
					System.Convert.ToInt32(Args[1]),
					System.Convert.ToInt32(Args[3]), Args[4], 
					System.Convert.ToInt32(Args[5]), 
					Args[6], Args[7]);
			}

			ResponseStr = PayflowNETAPI.SubmitTransaction(Args[2], 
				PayflowUtility.RequestId);
		
			// To write the Response on to the console.
			Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest);
			Console.WriteLine(Environment.NewLine + "Response = " + ResponseStr);				

			// Following lines of code are optional. 
			// Begin optional code for displaying SDK errors ...
			// It is used to read any errors that might have occured in the SDK.
			// Get the transaction errors.
			String TransErrors = PayflowNETAPI.TransactionContext.ToString();
			if (TransErrors != null && TransErrors.Length > 0)
			{
				Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
			}

			Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(ResponseStr));
			Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}