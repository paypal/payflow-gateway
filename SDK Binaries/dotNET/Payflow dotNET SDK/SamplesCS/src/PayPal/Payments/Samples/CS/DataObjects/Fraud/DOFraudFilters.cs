using System;
using System.Collections;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.Fraud
{
	/// <summary>
	/// This class uses the Payflow SDK Data Objects to do a Fraudulent Sale transaction. A pre-requisite 
	/// to this transaction is to set a value of $50 for the "Purchase Price Ceiling Filter". 
	/// An amount of $51 is passed to trigger the filter.
	/// </summary>
	public class DOFraudFilters
	{
		public DOFraudFilters()
		{
		}

		public static void Main(string[] Args)
		{
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Executing Sample from File: DOFraudFilters.cs");
			Console.WriteLine("------------------------------------------------------");

			// Create the Data Objects.
			// Create the User data object with the required user details.
			UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

			// Create the Payflow  Connection data object with the required connection details.
			// The PAYFLOW_HOST property is defined in the App config file.
			PayflowConnectionData Connection = new PayflowConnectionData();

			// Create a new Invoice data object with the Amount, Billing Address etc. details.
			Invoice Inv = new Invoice();

			// Set Amount.
			Currency Amt = new Currency(new decimal(51.00));
			Inv.Amt = Amt;
			Inv.PoNum = "PO12345";
			Inv.InvNum = "INV12345";

			// Set the Billing Address details.
			BillTo Bill = new BillTo();
			Bill.Street = "677 Main St.";
			Bill.Zip = "12345";
			Inv.BillTo = Bill;
			
			CustomerInfo CustInfo = new CustomerInfo();
			CustInfo.CustIP = "10.1.1.1";  // IP Velocity Filter
			Inv.CustomerInfo = CustInfo;

			// Create a new Payment Device - Credit Card data object.
			// The input parameters are Credit Card Number and Expiration Date of the Credit Card.
			CreditCard CC = new CreditCard("5105105105105100", "0115");
			CC.Cvv2 = "444";

			// Create a new Tender - Card Tender data object.
			CardTender Card = new CardTender(CC);
			///////////////////////////////////////////////////////////////////

			// Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
			SaleTransaction Trans = new SaleTransaction(
				User, Connection, Inv, Card, PayflowUtility.RequestId);

			// Set the Verbosity of the transaction to HIGH to get maximum information in the response.
			Trans.Verbosity = "HIGH";
			
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
					Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
					Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
					Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
					Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode);
					Console.WriteLine("PROCAVS = " + TrxnResponse.ProcAVS);
					Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match);
				}

				// Get the Fraud Response parameters.
				FraudResponse FraudResp =  Resp.FraudResponse;

				// Display Fraud Response parameter
				if (FraudResp != null)
				{
					Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
					Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);

					// The following lines of code dealing with PreXmlData and PostXmlData will return all th rules
					// that were triggered by the Fraud Service. For Example, let's assume the both AVS and CSC (CVV2)
					// failed, the FraudResp.PostFpsMsg would something similar to:
					// "Review: More than one rule was triggered for Review".
					//
					// The Fps_PreXmlData is returned as an Xml string. This is converted into Data Objects
					// with the object hierarchy as shown below:
					// FpsXmlData
					// >>>>>>>>> List of Rule objects
					// >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
					FpsXmlData PreXmlData = FraudResp.Fps_PreXmlData;
					if (PreXmlData != null)
					{
						// Get the list of Rules.
						ArrayList RulesList = PreXmlData.Rules;
						if (RulesList != null && RulesList.Count > 0)
						{
							IEnumerator RulesEnum = RulesList.GetEnumerator();
							Rule DORule = null;
							// Loop through the list of Rules.
							while (RulesEnum.MoveNext())
							{
								DORule = (Rule)RulesEnum.Current;
								Console.WriteLine("------------------------------------------------------");
								Console.WriteLine("PRE-XML DATA");
								Console.WriteLine("------------------------------------------------------");
								Console.WriteLine("Rule Number = " + DORule.Num.ToString());
								Console.WriteLine("Rule Id = " + DORule.RuleId);
								Console.WriteLine("Rule Alias = " + DORule.RuleAlias);
								Console.WriteLine("Rule Description = " + DORule.RuleDescription);
								Console.WriteLine("Action = " + DORule.Action);
								Console.WriteLine("Triggered Message = " + DORule.TriggeredMessage);
								
								// Get the list of Rule Vendor Parameters.
								ArrayList RuleVendorParmsList = DORule.RuleVendorParms;

								if (RuleVendorParmsList != null && RuleVendorParmsList.Count > 0)
								{
									IEnumerator RuleParametersEnum = RuleVendorParmsList.GetEnumerator();
									// Loop through the list of Rule Parameters.
									while (RuleParametersEnum.MoveNext())
									{
										RuleParameter DORuleParam = (RuleParameter)RuleParametersEnum.Current;
										Console.WriteLine("Number = " + DORuleParam.Num.ToString());
										Console.WriteLine("Name = " + DORuleParam.Name);
										Console.WriteLine("Type = " + DORuleParam.Type);
										Console.WriteLine("Value = " + DORuleParam.Value);
									}
								}
							}
						}
						// The Fps_PostXmlData is returned as an Xml string. This is converted into Data Objects
						// with the object hierarchy as shown below:
						// FpsXmlData
						// >>>>>>>>> List of Rule objects
						// >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
						FpsXmlData PostXmlData = FraudResp.Fps_PostXmlData;
						if (PostXmlData != null)
						{
							// Get the list of Rules.
							ArrayList PostRulesList = PostXmlData.Rules;
							if (PostRulesList != null && PostRulesList.Count > 0)
							{
								IEnumerator RulesEnum = PostRulesList.GetEnumerator();
								Rule DORule = null;
								// Loop through the list of Rules.
								while (RulesEnum.MoveNext())
								{
									DORule = (Rule)RulesEnum.Current;
									Console.WriteLine("------------------------------------------------------");
									Console.WriteLine("POST-XML DATA");
									Console.WriteLine("------------------------------------------------------");
									Console.WriteLine("Rule Number = " + DORule.Num.ToString());
									Console.WriteLine("Rule Id = " + DORule.RuleId);
									Console.WriteLine("Rule Alias = " + DORule.RuleAlias);
									Console.WriteLine("Rule Description = " + DORule.RuleDescription);
									Console.WriteLine("Action = " + DORule.Action);
									Console.WriteLine("Triggered Message = " + DORule.TriggeredMessage);
								
									// Get the list of Rule Vendor Parameters.
									ArrayList RuleVendorParmsList = DORule.RuleVendorParms;

									if (RuleVendorParmsList != null && RuleVendorParmsList.Count > 0)
									{
										IEnumerator RuleParametersEnum = RuleVendorParmsList.GetEnumerator();
										// Loop through the list of Rule Parameters.
										while (RuleParametersEnum.MoveNext())
										{
											RuleParameter DORuleParam = (RuleParameter)RuleParametersEnum.Current;
											Console.WriteLine("Number = " + DORuleParam.Num.ToString());
											Console.WriteLine("Name = " + DORuleParam.Name);
											Console.WriteLine("Type = " + DORuleParam.Type);
											Console.WriteLine("Value = " + DORuleParam.Value);
										}
									}
								}
							}
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

					Console.WriteLine("Press Enter to Exit ...");
					Console.ReadLine();
				}
			}
		}
	}
}
