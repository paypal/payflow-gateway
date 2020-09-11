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
	/// a Validate Authentication transaction.
	/// Validate Authentication is the second step of Buyer authentication process.
	/// </summary>
	/// <remarks>When the user authenticates on the secure authentication server, the server
	/// returns back a Payer authentication Signature (PaRes). You must send this value of PaRes 
	/// to validate the authentication to the payment gateway during the Validate Authentication.
	/// The gateway will then return the authentication status of the user in the response. 
	/// You should send this authntication information from the response into you main transaction.
	/// For more information, please refer to the Payflow Developers' Guide.
	/// </remarks>
	/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
	/// <code lang="C#" escaped="false">
	///		..........
	///		..........
	///		//Populate required data objects.
	///		..........
	///		..........
	///		
	///		//Create a new validate Auhtentication Transaction.
	///		 BuyerAuthVATransaction Trans = new BuyerAuthVATransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Pares,
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
	///		..........
	///		..........
	///		
	///		'Create a new Validate Authentication Transaction.
	///		Dim Trans as New BuyerAuthVATransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Pares,
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
	public sealed class BuyerAuthVATransaction : BuyerAuthTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Holds the PaRes value.
		/// </summary>
		private String mPaRes;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private BuyerAuthVATransaction()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="PaRes">PaRes Value</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>When the user authenticates on the secure authentication server, the server
		/// returns back a Payer authentication Signature (PaRes). You must send this value of PaRes 
		/// to validate the authentication to the payment gateway during the Validate Authentication.
		/// The gateway will then return the authentication status of the user in the response. 
		/// You should send this authntication information from the response into you main transaction.
		/// For more information, please refer to the Payflow Developers' Guide.
		/// </remarks>
		/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new validate Auhtentication Transaction.
		///		 BuyerAuthVATransaction Trans = new BuyerAuthVATransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Pares,
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
		///		..........
		///		..........
		///		
		///		'Create a new Validate Authentication Transaction.
		///		Dim Trans as New BuyerAuthVATransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Pares,
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
		public BuyerAuthVATransaction(UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String PaRes, String RequestId) : base(PayflowConstants.TRXTYPE_BUYERAUTH_VA, UserInfo, PayflowConnectionData, RequestId)
		{
			mPaRes = PaRes;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PaRes">PaRes Value</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>When the user authenticates on the secure authentication server, the server
		/// returns back a Payer authentication Signature (PaRes). You must send this value of PaRes 
		/// to validate the authentication to the payment gateway during the Validate Authentication.
		/// The gateway will then return the authentication status of the user in the response. 
		/// You should send this authntication information from the response into you main transaction.
		/// For more information, please refer to the Payflow Developers' Guide.
		/// </remarks>
		/// <example>This example shows how to create and perform a Verify Eknrollment transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new validate Auhtentication Transaction.
		///		 BuyerAuthVATransaction Trans = new BuyerAuthVATransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Pares,
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
		///		..........
		///		..........
		///		
		///		'Create a new Validate Authentication Transaction.
		///		Dim Trans as New BuyerAuthVATransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Pares,
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
		public BuyerAuthVATransaction(UserInfo UserInfo, String PaRes, String RequestId) : this(UserInfo, null, PaRes,RequestId)
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PARES, mPaRes));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TE = new TransactionException(Ex);
				throw TE;
			}
            //catch
            //{
            //    throw new Exception();
            //}
		}

		#endregion

	}

}