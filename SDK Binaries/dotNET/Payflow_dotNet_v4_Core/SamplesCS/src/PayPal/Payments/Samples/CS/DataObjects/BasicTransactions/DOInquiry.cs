using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
	// <summary>
	// This class uses the Payflow SDK Data Objects to do an Inquiry transaction.
	//
	// You perform an inquiry using a reference to an original transaction—either the PNREF
	// value returned for the original transaction or the CUSTREF value that you specified for the original
	// transaction.
	//
	// While the amount of information returned in an Inquiry transaction depends upon the VERBOSITY setting, 
	// Inquiry responses mimic the verbosity level of the original transaction as much as possible.
	// 
	// Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
	// processor vary in detail level and in format. The Payflow Pro Verbosity parameter enables you to control
	// the kind and level of information you want returned.  By default, Verbosity is set to LOW.
	// A LOW setting causes PayPal to normalize the transaction result values. Normalizing the values limits
	// them to a standardized set of values and simplifies the process of integrating Payflow Pro.
	// By setting Verbosity to MEDIUM, you can view the processor?s raw response values. This setting is more
	// "verbose" than the LOW setting in that it returns more detailed, processor-specific information.   
	//
	// The request is sent as a Data Object and the response received is also a Data Object.
	// </summary>
	public class DOInquiry
	{
		public DOInquiry()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOInquiry.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Inquiry Transaction.
			//Replace <PNREF> with a previous transaction ID that you processed on your account.
			InquiryTransaction Trans = new InquiryTransaction("<PNREF>",User, Connection, PayflowUtility.RequestId);

			// To use CUSTREF instead of PNREF you need to set the CustRef and include the INVOICE object in your
			// request.  Since you will be using CUSTREF instead of PNREF, PNREF will be "" (null).
			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			//Invoice Inv = new Invoice();
			//Inv.CustRef = "A54321";
			//InquiryTransaction Trans = new InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId);

			// Refer to the Payflow Pro Developer's Guide for more information regarding the parameters returned
			// when VERBOSITY is set.
			Trans.Verbosity = "HIGH"; // Set to HIGH to see all available data available.

			// Submit the Transaction
			Response Resp = Trans.SubmitTransaction();

			// Display the transaction response parameters.
			if (Resp != null)
			{
				// Get the Transaction Response parameters.
				TransactionResponse TrxnResponse =  Resp.TransactionResponse;

				// Display the transaction response parameters. Refer to the Payflow Pro Developer's Guide for explanations.
				if (TrxnResponse != null)
				{
					Console.WriteLine("RESULT = " + TrxnResponse.Result);
					Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
					Console.WriteLine("--------------------------------------------");
					Console.WriteLine("Original Response Data");
					Console.WriteLine("--------------------------------------------");
					switch (Trans.Verbosity.ToUpper())
					{
						case "LOW":
							Console.WriteLine("RESULT = " + TrxnResponse.OrigResult);
							Console.WriteLine("PNREF = " + TrxnResponse.OrigPnref);
							Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
							Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
							Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
							Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
							Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
							Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
							Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
							break;
						case "MEDIUM":
							Console.WriteLine("RESULT = " + TrxnResponse.OrigResult);
							Console.WriteLine("PNREF = " + TrxnResponse.OrigPnref);
							Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
							Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
							Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
							Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
							Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
							Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
							Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode);
							Console.WriteLine("RESPTEXT = " + TrxnResponse.RespText);
							Console.WriteLine("PROCAVS = " + TrxnResponse.ProcAVS);
							Console.WriteLine("PROCCVV2 = " + TrxnResponse.ProcCVV2);
							Console.WriteLine("PROCCARDSECURE = " + TrxnResponse.ProcCardSecure);
							Console.WriteLine("ADDLMSGS = " + TrxnResponse.AddlMsgs);
							Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
							Console.WriteLine("DATE_TO_SETTLE = " + TrxnResponse.DateToSettle);
							Console.WriteLine("BATCHID = " + TrxnResponse.BatchId);
							Console.WriteLine("SETTLE_DATE = " + TrxnResponse.SettleDate);
							break;
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
			}
			Console.WriteLine("Press Enter to Exit ...");
			Console.ReadLine();
		}
	}
}