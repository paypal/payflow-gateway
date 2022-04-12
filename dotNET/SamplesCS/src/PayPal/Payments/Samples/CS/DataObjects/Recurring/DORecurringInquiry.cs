using System;
using System.Collections;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Recurring
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Recurring Inquiry transaction.
	/// The request is sent as a Data Object and the response received is also a Data Object.
	/// </summary>
	public class DORecurringInquiry
	{
		public DORecurringInquiry()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DORecurringInquiry.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			RecurringInfo RecurInfo = new RecurringInfo();
			RecurInfo.OrigProfileId = "<PROFILE_ID>";  // RT0000001350
			// To show payment history instead of Profile details, change to "Y".
			// To view "Optional Transactions", use 'O'.
			RecurInfo.PaymentHistory = "N";

			// Create a new Recurring Inquiry Transaction.
			RecurringInquiryTransaction Trans = new RecurringInquiryTransaction(
				User, Connection, RecurInfo, PayflowUtility.RequestId);

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
				}

				// Get the Recurring Response parameters.
				RecurringResponse RecurResponse = Resp.RecurringResponse;
				if (RecurResponse != null)
				{
					Console.WriteLine("RPREF = " + RecurResponse.RPRef);
					Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);
					// Show Profile Details.
					if (RecurResponse.InquiryParams.Count == 0)
					{
						Console.WriteLine("STATUS = " + RecurResponse.Status);
						Console.WriteLine("PROFILENAME = " + RecurResponse.ProfileName);
						Console.WriteLine("CREATIONDATE = " + RecurResponse.CreationDate);
						Console.WriteLine("LASTCHANGED = " + RecurResponse.LastChangedDate);
						Console.WriteLine("START = " + RecurResponse.Start);
						Console.WriteLine("TERM = " + RecurResponse.Term);
						Console.WriteLine("PAYMENTSLEFT = " + RecurResponse.PaymentsLeft);
						Console.WriteLine("NEXTPAYMENT = " + RecurResponse.NextPayment);
						Console.WriteLine("NEXTPAYMENTNUM = " + RecurResponse.NextPaymentNumber);
						Console.WriteLine("PAYPERIOD = " + RecurResponse.PayPeriod);
						Console.WriteLine("RPSTATE = " + RecurResponse.RPState);
						Console.WriteLine("FREQUENCY = " + RecurResponse.Frequency);	
						Console.WriteLine("TENDER = " + RecurResponse.Tender);
						Console.WriteLine("AMT = " + RecurResponse.Amt);
						Console.WriteLine("CURRENCY = " + RecurResponse.Currency);	
						Console.WriteLine("ACCT = " + RecurResponse.Acct);
						Console.WriteLine("EXPDATE = " + RecurResponse.ExpDate);
						Console.WriteLine("AGGREGATEAMT = " + RecurResponse.AggregateAmt);
						Console.WriteLine("AGGREGATEOPTIONALAMT = " + RecurResponse.AggregateOptionalAmt);
						Console.WriteLine("MAXFAILPAYMENTS = " + RecurResponse.MaxFailPayments);
						Console.WriteLine("NUMFAILPAYMENTS = " + RecurResponse.NumFailPayments);
						Console.WriteLine("RETRYNUMDAYS = " + RecurResponse.RetryNumDays);
						Console.WriteLine("END = " + RecurResponse.End);
						Console.WriteLine("FIRSTNAME = " + RecurResponse.FirstName);
						Console.WriteLine("LASTNAME = " + RecurResponse.LastName);
						Console.WriteLine("STREET = " + RecurResponse.Street);
						Console.WriteLine("CITY = " + RecurResponse.City);
						Console.WriteLine("STATE = " + RecurResponse.State);
						Console.WriteLine("ZIP = " + RecurResponse.Zip);
						Console.WriteLine("PHONENUM = " + RecurResponse.PhoneNum);
						Console.WriteLine("EMAIL = " + RecurResponse.Email);
					} 
					else 
					{
						// Display the Payment History instead of Profile data.
						// Payment History is stored in the HASHTABLE RecurResponse.InquiryParams.
						// PAYMENTHISTORY = Y or O
						Console.WriteLine("INQUIRY PARAMS");
						int x = 0;
						char Tab = (char)9;
						while (true) 
						{
							x++;
							if(RecurResponse.InquiryParams["P_PNREF" + x.ToString()] == null)
							{
								break;
							}
							Console.WriteLine("PAYMENT: {0}" + Tab 
								+ "RESULT: {1}" + Tab 
								+ "PNREF: " + "{2}" + Tab 
								+ "AMOUNT: " + "{3}" + Tab
								+ "TRANSTIME: " + "{4}" + Tab
								+ "TRANSTATE: " + "{5}" + Tab
								+ "TENDER: " + "{6}" + Tab, 
								x,
								RecurResponse.InquiryParams["P_RESULT" + x.ToString()],
								RecurResponse.InquiryParams["P_PNREF" + x.ToString()], 
								RecurResponse.InquiryParams["P_AMT" + x.ToString()],
								RecurResponse.InquiryParams["P_TRANSTIME" + x.ToString()],
								RecurResponse.InquiryParams["P_TRANSTATE" + x.ToString()], 
								RecurResponse.InquiryParams["P_TENDER" + x.ToString()]);
						}
					}
				}

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