using System;
using System.IO;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;

namespace PayPal.Payments.Samples.CS.XMLPay
{
	/// <summary>
	/// This class uses the Payflow SDK API to run XML Pay transactions by reading the files.
	/// The request is sent as a XMLPay string & the response received 
	/// is also XMLPay string.
	/// </summary>
	public class XMLPayCommandLine_File
	{
		public XMLPayCommandLine_File()
		{
		}
		
		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: XMLPayCommandLine_File.cs");
			Console.WriteLine("------------------------------------------------------");

			if (Args.Length < 4)
			{
				Console.WriteLine(Environment.NewLine + "Incorrect number of arguments. Usage:" + Environment.NewLine + "SamplesCS <hostAddress> <hostPort> <xml filename> <timeout> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>");
				Console.WriteLine(Environment.NewLine + "Example transaction:" + Environment.NewLine + "SamplesCS pilot-payflowpro.paypal.com 443 \"C:" + 
					System.IO.Path.DirectorySeparatorChar + "Sale.xml\" 45");
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

			String XmlFile = ReadFile(Args[2]);
			if (XmlFile != null)
			{
				String ResponseStr = PayflowNETAPI.SubmitTransaction(XmlFile, PayflowUtility.RequestId);
				
				// To write the Response on to the console.
				Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest);
				Console.WriteLine(Environment.NewLine + "Response = " + ResponseStr);				

				// Following lines of code are optional. 
				// Begin optional code for displaying SDK errors ...
				// It is used to read any errors that might have occured in the SDK.
				// Get the transaction errors.
				String TransErrors = PayflowNETAPI. TransactionContext.ToString();
				if (TransErrors != null && TransErrors.Length > 0)
				{
					Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
				}
				Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(ResponseStr));
				Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
				Console.ReadLine();
			}
			else
			{
				Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
				Console.ReadLine();
			}
		}

		// Read the xml file into a string.
		private static String ReadFile(String FilePath)
		{
			String FileString = null;
			if (File.Exists(FilePath))
			{
				StreamReader sr = new StreamReader(new FileStream(FilePath, 
					FileMode.Open, FileAccess.Read)); 
				FileString =  sr.ReadToEnd();
	  
				sr.Close(); 
			}
			else
			{
				Console.WriteLine("<XMLPayResponse><ResponseData><Vendor></Vendor><Partner></Partner><TransactionResults><Result>-100</Result><Message>" +
					"Failed to open XML file at location " + FilePath + "</Message><PNRef>V00000000000</PNRef>" +
					"<AuthCode>000000</AuthCode><HostCode>0</HostCode></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");
			}
			return FileString;
		}
	}
}