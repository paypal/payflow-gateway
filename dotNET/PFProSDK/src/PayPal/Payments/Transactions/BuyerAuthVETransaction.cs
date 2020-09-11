#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to create and perform 
	/// a Verify Enrollment transaction.
	/// Verify Enrollment is the first step of Buyer authentication process.
	/// </summary>
	/// <remarks>After a successful Verify Enrollment Transaction, 
	/// you should redirect the user's browser to his/her browser to the 
	/// secure authentication server which will authinticate the user.
	/// While redirecting to this secure authentication server, 
	/// you must pass the parameter PaReq obtained in the response of this transaction.
	/// For more information, please refer to the Payflow Developers' Guide.
	/// </remarks>
	/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
	/// <code lang="C#" escaped="false">
	///		..........
	///		..........
	///		//Populate required data objects.
	///		
	///		//Create the Card object.
	///		CreditCard Card = new CreditCard("XXXXXXXXXXXXXXXX","XXXX");
	///		
	///		//Create the currency object.
	///		Currency Amt = new Currency(new decimal(1.00),"US");
	///		..........
	///		..........
	///		
	///		//Create a new Verify Enrollment Transaction.
	///		 BuyerAuthVETransaction Trans = new BuyerAuthVETransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Card,
	///												Amt, 
	///												RequestId);
	///		//Submit the transaction.
	///		Trans.SubmitTransaction();
	///			
	///		// Get the Response.
	///		Response Resp = Trans.Response;
	///		if (Resp != null)
	///		{
	///			// Get the Transaction Response parameters.
	///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
	///			if (TrxnResponse != null)
	///			{
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///			}
	///			
	///		
	///			// Get the Buyer auth Response parameters.
	///			BuyerAuthResponse BAResponse = Resp.BuyerAuthResponse;
	///			if (BAResponse != null)
	///			{
	///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status);
	///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id);
	///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl);
	///				Console.WriteLine("PAREQ = " + BAResponse.PaReq);
	///			}
	///		}
	///		// Get the Context and check for any contained SDK specific errors.
	///		Context Ctx = Resp.TransactionContext;
	///		if (Ctx != null ++ Ctx.getErrorCount() > 0)
	///		{
	///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
	///		}	
	///</code>
	///<code lang="Visual Basic" escaped="false">
	///		..........
	///		..........
	///		'Populate required data objects.
	///		
	///		//Create the Card object.
	///		Dim Card As CreditCard = new CreditCard("XXXXXXXXXXXXXXXX","XXXX")
	///		
	///		//Create the currency object.
	///		Dim Amt As Currency = new Currency(new decimal(1.00),"US")
	///		..........
	///		..........
	///		
	///		'Create a new Authorization Transaction.
	///		Dim Trans as New BuyerAuthVETransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Card,
	///												Amt, 
	///												RequestId)
	///		' Submit the transaction.
	///		Trans.SubmitTransaction()
	///
	///		' Get the Response.
	///		Dim Resp As Response = Trans.Response
	///		
	///		If Not Resp Is Nothing Then
	///		' Get the Transaction Response parameters.
	///		
	///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///			
	///			If Not TrxnResponse Is Nothing Then
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///			End If
	///
	///			' Get the Buyer auth Response parameters.
	///			Dim BAResponse As BuyerAuthResponse = Resp.BuyerAuthResponse;
	///			If Not BAResponse Is Nothing Then
	///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status)
	///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id)
	///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl)
	///				Console.WriteLine("PAREQ = " + BAResponse.PaReq)
	///			End If
	///		End If
	///
	///		' Get the Context and check for any contained SDK specific errors.
	///		Dim Ctx As Context = Resp.TransactionContext
	///		
	///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
	///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
	///		End If												
	/// </code>
	/// </example>
	public sealed class BuyerAuthVETransaction : BuyerAuthTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Holds the currency value, mandatory for VE.
		/// </summary>
		private Currency mCurrency;

		/// <summary>
		/// Holds the Purchase Description.
		/// </summary>
		private String mPurDesc;

		private CreditCard  mCreditcard;

		#endregion

		#region "Properties"
		/// <summary>
		/// Gets, Sets Purchase description.
		/// <para>Maps to Payflow Parameter: - <code>PUR_DESC</code></para>
		/// </summary>
		public String PurDesc
		{
			get { return mPurDesc; }
			set { mPurDesc = value; }
		}
		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private BuyerAuthVETransaction()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="CreditCard">Credit card information for the user.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Currency">Currency value</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>After a successful Verify Enrollment Transaction, 
		/// you should redirect the user's browser to his/her browser to the 
		/// secure authentication server which will authinticate the user.
		/// While redirecting to this secure authentication server, 
		/// you must pass the parameter PaReq obtained in the response of this transaction.
		/// </remarks>
		/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		
		///		//Create the Card object.
		///		CreditCard Card = new CreditCard("XXXXXXXXXXXXXXXX","XXXX");
		///		
		///		//Create the currency object.
		///		Currency Amt = new Currency(new decimal(1.00),"US");
		///		..........
		///		..........
		///		
		///		//Create a new Verify Enrollment Transaction.
		///		 BuyerAuthVETransaction Trans = new BuyerAuthVETransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Card,
		///												Amt, 
		///												RequestId);
		///		//Submit the transaction.
		///		Trans.SubmitTransaction();
		///			
		///		// Get the Response.
		///		Response Resp = Trans.Response;
		///		if (Resp != null)
		///		{
		///			// Get the Transaction Response parameters.
		///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///			if (TrxnResponse != null)
		///			{
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			}
		///			
		///		
		///			// Get the Buyer auth Response parameters.
		///			BuyerAuthResponse BAResponse = Resp.BuyerAuthResponse;
		///			if (BAResponse != null)
		///			{
		///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status);
		///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id);
		///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl);
		///				Console.WriteLine("PAREQ = " + BAResponse.PaReq);
		///			}
		///		}
		///		// Get the Context and check for any contained SDK specific errors.
		///		Context Ctx = Resp.TransactionContext;
		///		if (Ctx != null ++ Ctx.getErrorCount() > 0)
		///		{
		///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
		///		}	
		///</code>
		///<code lang="Visual Basic" escaped="false">
		///		..........
		///		..........
		///		'Populate required data objects.
		///		
		///		//Create the Card object.
		///		Dim Card As CreditCard = new CreditCard("XXXXXXXXXXXXXXXX","XXXX")
		///		
		///		//Create the currency object.
		///		Dim Amt As Currency = new Currency(new decimal(1.00),"US")
		///		..........
		///		..........
		///		
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New BuyerAuthVETransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Card,
		///												Amt, 
		///												RequestId)
		///		' Submit the transaction.
		///		Trans.SubmitTransaction()
		///
		///		' Get the Response.
		///		Dim Resp As Response = Trans.Response
		///		
		///		If Not Resp Is Nothing Then
		///		' Get the Transaction Response parameters.
		///		
		///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///			
		///			If Not TrxnResponse Is Nothing Then
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///			End If
		///
		///			' Get the Buyer auth Response parameters.
		///			Dim BAResponse As BuyerAuthResponse = Resp.BuyerAuthResponse;
		///			If Not BAResponse Is Nothing Then
		///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status)
		///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id)
		///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl)
		///				Console.WriteLine("PAREQ = " + BAResponse.PaReq)
		///			End If
		///		End If
		///
		///		' Get the Context and check for any contained SDK specific errors.
		///		Dim Ctx As Context = Resp.TransactionContext
		///		
		///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
		///		End If												
		/// </code>
		/// </example>		
		public BuyerAuthVETransaction(UserInfo UserInfo, CreditCard CreditCard, PayflowConnectionData PayflowConnectionData, Currency Currency, String RequestId) 
			: base(PayflowConstants.TRXTYPE_BUYERAUTH_VE, UserInfo, PayflowConnectionData, RequestId)
		{
			mCurrency = Currency;
			mPurDesc = PurDesc;
			mCreditcard = CreditCard;

		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="CreditCard">Credit card information for the user.</param>
		/// <param name="Currency">Currency value</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>After a successful Verify Enrollment Transaction, 
		/// you should redirect the user's browser to his/her browser to the 
		/// secure authentication server which will authinticate the user.
		/// While redirecting to this secure authentication server, 
		/// you must pass the parameter PaReq obtained in the response of this transaction.
		/// </remarks>
		/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		
		///		//Create the Card object.
		///		CreditCard Card = new CreditCard("XXXXXXXXXXXXXXXX","XXXX");
		///		
		///		//Create the currency object.
		///		Currency Amt = new Currency(new decimal(1.00),"US");
		///		..........
		///		..........
		///		
		///		//Create a new Verify Enrollment Transaction.
		///		 BuyerAuthVETransaction Trans = new BuyerAuthVETransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Card,
		///												Amt, 
		///												RequestId);
		///		//Submit the transaction.
		///		Trans.SubmitTransaction();
		///			
		///		// Get the Response.
		///		Response Resp = Trans.Response;
		///		if (Resp != null)
		///		{
		///			// Get the Transaction Response parameters.
		///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///			if (TrxnResponse != null)
		///			{
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			}
		///			
		///		
		///			// Get the Buyer auth Response parameters.
		///			BuyerAuthResponse BAResponse = Resp.BuyerAuthResponse;
		///			if (BAResponse != null)
		///			{
		///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status);
		///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id);
		///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl);
		///				Console.WriteLine("PAREQ = " + BAResponse.PaReq);
		///			}
		///		}
		///		// Get the Context and check for any contained SDK specific errors.
		///		Context Ctx = Resp.TransactionContext;
		///		if (Ctx != null ++ Ctx.getErrorCount() > 0)
		///		{
		///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
		///		}	
		///</code>
		///<code lang="Visual Basic" escaped="false">
		///		..........
		///		..........
		///		'Populate required data objects.
		///		
		///		//Create the Card object.
		///		Dim Card As CreditCard = new CreditCard("XXXXXXXXXXXXXXXX","XXXX")
		///		
		///		//Create the currency object.
		///		Dim Amt As Currency = new Currency(new decimal(1.00),"US")
		///		..........
		///		..........
		///		
		///		'Create a new Verify Enrollment Transaction.
		///		Dim Trans as New BuyerAuthVETransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Card,
		///												Amt, 
		///												RequestId)
		///		' Submit the transaction.
		///		Trans.SubmitTransaction()
		///
		///		' Get the Response.
		///		Dim Resp As Response = Trans.Response
		///		
		///		If Not Resp Is Nothing Then
		///		' Get the Transaction Response parameters.
		///		
		///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///			
		///			If Not TrxnResponse Is Nothing Then
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///			End If
		///
		///			' Get the Buyer auth Response parameters.
		///			Dim BAResponse As BuyerAuthResponse = Resp.BuyerAuthResponse;
		///			If Not BAResponse Is Nothing Then
		///				Console.WriteLine("AUTHENTICATION_STATUS = " + BAResponse.Authentication_Status)
		///				Console.WriteLine("AUTHENTICATION_ID = " + BAResponse.Authentication_Id)
		///				Console.WriteLine("ACSURL = " + BAResponse.AcsUrl)
		///				Console.WriteLine("PAREQ = " + BAResponse.PaReq)
		///			End If
		///		End If
		///
		///		' Get the Context and check for any contained SDK specific errors.
		///		Dim Ctx As Context = Resp.TransactionContext
		///		
		///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
		///		End If												
		/// </code>
		/// </example>		
		public BuyerAuthVETransaction(UserInfo UserInfo, CreditCard CreditCard, Currency Currency,String RequestId) 
			: this(UserInfo, CreditCard ,null, Currency, RequestId)
		{
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				base.GenerateRequest();
				if (mCreditcard != null)
				{
					mCreditcard.RequestBuffer = RequestBuffer ;
					mCreditcard.GenerateRequest ();
				}
					
				if (mCurrency != null)
				{
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CURRENCY, mCurrency.CurrencyCode ));
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AMT, mCurrency));
				}
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PUR_DESC, mPurDesc));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TEx = new TransactionException(Ex);
				throw TEx;
			}
            //catch
            //{
            //    throw new Exception();
            //}
		}


		#endregion
	}

}