#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;
using PayPal.Payments.Common;


#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to create and perform an 
	/// Authorization Transaction.
	/// </summary>
	/// <remarks>A successful authorization needs to be captured using a capture transaction.</remarks>
	/// <example>This example shows how to create and perform a authorization transaction.
	/// <code lang="C#" escaped="false">
	///		..........
	///		..........
	///		//Populate required data objects.
	///		..........
	///		..........
	///		
	///		//Create a new Authorization Transaction.
	///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Invoice,
	///												Tender, 
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
	///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
	///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
	///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
	///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
	///			}
	///			// Get the Fraud Response parameters.
	///			FraudResponse FraudResp =  Resp.FraudResponse;
	///			if (FraudResp != null)
	///			{
	///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
	///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
	///		'Create a new Authorization Transaction.
	///		Dim Trans as New AuthorizationTransaction(
	///												UserInfo,
	///												PayflowConnectionData,
	///												Invoice,
	///												Tender, 
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
	///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
	///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
	///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
	///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
	///			End If
	///
	///			' Get the Fraud Response parameters.
	///			Dim FraudResp As FraudResponse = Resp.FraudResponse
	///			If Not FraudResp Is Nothing Then
	///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
	///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
	public class AuthorizationTransaction : BaseTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Original transaction id.
		/// The ORIGID is the PNREF no. from a previous transaction.
		/// OrigId is used to create a new Authorization transaction using the details of a previous
		/// transaction.
		/// </summary>
		private String mOrigId;

		/// <summary>
		/// Partial authorization request.
		/// Notifies processor that partial authorizations are supported.
		/// </summary>
		private String mPartialAuth;

		/// <summary>
		/// Secure token request.
		/// Used to store sensitive data prior to making a call to the hosted page.
		/// </summary>
		private String mCreateSecureToken;

		/// <summary>
		/// Secure token id.
		/// Id used to generate a secure token.  Must be sent with the token when calling the hosted pages.
		/// This can be any random GUID but must be unique.
		/// </summary>
		private String mSecureTokenId;


		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets OrigId. This property is used to perform a reference Authorization Transaction.
		/// </summary>
		/// <remarks>A reference Authorization transaction is an authorization transaction which copies the transaction data,
		///  except the Account Number, Expiration Date and Swipe data from a previous trasnaction.
		///  PNRef of this previous trasnaction needs to be set in this OrigId property.</remarks>
		/// <remarks>A successful authorization needs to be captured using a capture transaction.</remarks>
		/// <example>This example shows how to create and perform a reference authorization transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new Authorization Transaction.
		///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
		///												RequestId);
		///		// Set the OrigId to refer to 
		///		// a previous trasncation.
		///		Trans.OrigId = "V64A0A07BD24";
		///		
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
		///												RequestId)
		///		' Set the OrigId to refer to 
		///		' a previous trasncation.
		///		Trans.OrigId = "V64A0A07BD24"
		///		
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public String OrigId
		{
			get { return mOrigId; }
			set { mOrigId = value; }
		}
		#endregion

		#region "Properties"

		/// <summary>
        /// Gets, Sets PartialAuth. This property is used to notify banks that a partial authorization can be performed for a pre-paid debit/gift card.
		/// </summary>
		/// <remarks>Partial Approval is supported for Visa, MasterCard, American Express and Discover (JCB (US Domestic only), 
		/// and Diners) Prepaid card products such as gift, Flexible Spending Account (FSA) or Healthcare Reimbursement Account 
		/// (HRA) cards. In addition Discover (JCB (US Domestic only), and Diners) supports partial Approval on their consumer 
		/// credit card. It is often difficult for the consumer to spend the exact amount available on the prepaid account, as 
		/// the purchase can be for amounts greater than the value available. This can result in unnecessary declines. Visa, 
		/// MasterCard, American Express and Discover (JCB (US Domestic only), and Diners) recognize that the prepaid products 
		/// represent unique opportunities for both merchants and consumers. With Partial Approval issuers may approve a portion 
		/// of the amount requested. This will enable the residual transaction amount to be paid by other means. The introduction 
		/// of the partial approval capability will reduce decline frequency and enhance the consumer and merchant experience at 
		/// the point of sale. Merchants will now have the ability to accept partial approval rather than having the sale declined. </remarks>
		/// <example>This example shows how to submit the Partial Authorization flag.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new Authorization Transaction.
		///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
		///												RequestId);
		///		// Set the flag to allow partial authorizations.
		///		Trans.PartialAuth = "Y";
		///		
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
		///												RequestId)
		///		'Set the flag to allow partial authorizations.
		///		Trans.PartialAuth = "Y"
		///		
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public String PartialAuth
		{
			get { return mPartialAuth; }
			set { mPartialAuth = value; }
		}

        #endregion

        #region "Properties"

        /// <remarks>Use a secure token to send non-credit card transaction data to the Payflow server for storage in
        /// a way that can’t be intercepted and manipulated maliciously.The secure token must be used with the hosted 
        /// checkout pages. The token is good for a one-time transaction and is valid for 30 minutes.
        /// 
        /// NOTE: Without using a secure token, Payflow Pro merchants can host their own payment page and Payflow Link merchants 
        /// can use a form post to send transaction data to the hosted checkout pages. However, by not using the secure token, 
        /// these Payflow gateway users are responsible for the secure handling of data.  To obtain a secure token, pass a unique, 
        /// 36-character token ID and set CREATESECURETOKEN=Y in a request to the Payflow server. The Payflow server associates your 
        /// ID with a secure token and returns the token as a string of up to 32 alphanumeric characters.  To pass the transaction 
        /// data to the hosted checkout page, you pass the secure token and token ID in an HTTP form post. The token and ID trigger 
        /// the Payflow server to retrieve your data and display it for buyer approval. 
        /// 
        /// See the DOSecureTokenAuth sample for more information.
        /// <code lang="C#" escaped="false">
        ///		..........
        ///		..........
        ///		//Populate required data objects.
        ///		..........
        ///		..........
        ///		
        /// 	// Since we are using the hosted payment pages, you will not be sending the credit card data with the 
        ///     // Secure Token Request.  You just send all other 'sensitive' data within this request and when you
        ///     // call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
        ///     // and the SECURETOKENID that was created and used in the request.
        ///
        ///     // Create a new Secure Token Authorization Transaction.  Even though this example is performing
        ///     // an authorization, you can create a secure token using SaleTransction too.  Only Authorization and Sale
        ///     // type transactions are permitted.
        ///		//Create a new Authorization Transaction.
        ///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
        ///												UserInfo,
        ///												PayflowConnectionData,
        ///												Invoice,
        ///												Tender, 
        ///												RequestId);
        ///		// Set the flag to create a Secure Token.
        ///		Trans.CreateSecureToken = "Y";
        ///		// The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to generate 
        ///		// a random id, but any means to create an id can be used.
        ///		Trans.SecureTokenId = PayflowUtility.RequestId;
        ///		
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
        ///		{
        ///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
        ///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
        ///			Console.WriteLine("SECURETOKEN = " + TrxnResponse.SecureToken);
        ///			Console.WriteLine("SECURETOKENID = " + TrxnResponse.SecureTokenId);
        ///			// If value is true, then the Request ID has not been changed and the original response
        ///			// of the original transaction is returned. 
        ///			Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate);
        ///		}
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
        ///     ' Since we are using the hosted payment pages, you will not be sending the credit card data with the 
        ///     ' Secure Token Request.  You just send all other 'sensitive' data within this request and when you
        ///     ' call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
        ///     ' and the SECURETOKENID that was created and used in the request.
        ///     
        ///     ' Create a new Secure Token Authorization Transaction.  Even though this example is performing
        ///     ' an authorization, you can create a secure token using SaleTransction too.  Only Authorization and Sale
        ///     ' type transactions are permitted.
        ///		'Create a new Authorization Transaction.
        ///		Dim Trans as New AuthorizationTransaction(UserInfo, PayflowConnectionData, Invoice, Tender, RequestId)
        ///		' See the CreateSecureToken parameter to yes "Y", to flag this transaction request to create a secure token.
        ///		Trans.CreateSecureToken = "Y"
        ///		
        ///     ' The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to 
        ///     ' generate a random id, but any means to create an id can be used.
        ///     Trans.SecureTokenId = PayflowUtility.RequestId
        ///		
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
        ///            Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
        ///            Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
        ///            Console.WriteLine("SECURETOKEN = " + TrxnResponse.SecureToken)
        ///            Console.WriteLine("SECURETOKENID = " + TrxnResponse.SecureTokenId)
        ///            ' If value is true, then the Request ID has not been changed and the original response
        ///            ' of the original transaction is returned. 
        ///            Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate)
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
        /// </remarks>

        /// <summary>
        /// Gets, Sets CreateSecureToken. This property is used to create a SecureToken.
        /// </summary>
        public String CreateSecureToken
		{
			get { return mCreateSecureToken; }
			set { mCreateSecureToken = value; }
		}

        /// <summary>
        /// Gets, Sets SecureTokenId. This property is used while calling the hosted page.
        /// </summary>
        public String SecureTokenId
		{
			get { return mSecureTokenId; }
			set { mSecureTokenId = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private AuthorizationTransaction()
		{}

		/// <summary>
		/// Constructor. 
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object </param>
		/// <param name="RequestId">Request Id</param>
		/// <example>This example shows how to create and perform a authorization transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new Authorization Transaction.
		///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public AuthorizationTransaction(UserInfo UserInfo, PayflowConnectionData PayflowConnectionData,
		                                Invoice Invoice,
		                                BaseTender Tender, String RequestId)
			: base(PayflowConstants.TRXTYPE_AUTH, UserInfo, PayflowConnectionData,
			       Invoice,
			       //PaymentDevice ,
			       Tender, RequestId)
		{
		}

		/// <summary>
		/// Constructor. 
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <example>This example shows how to create and perform a authorization transaction.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		//Create a new Authorization Transaction.
		///		 AuthorizationTransaction Trans = new AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public AuthorizationTransaction(UserInfo UserInfo, PayflowConnectionData PayflowConnectionData,
			Invoice Invoice, String RequestId)
			: base(PayflowConstants.TRXTYPE_AUTH, UserInfo, PayflowConnectionData,
			Invoice, RequestId)
		{
		}
		
		/// <summary>
		/// Constructor. 
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object </param>
		/// <param name="RequestId">Request Id</param>
		/// <example>This example shows how to create and perform
		/// a authorization transaction.
		///<code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///		
		///		// Create a new Authorization Transaction.
		///		AuthorizationTransaction Trans = new AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///		'Create a new Authorization Transaction.
		///		Dim Trans as New AuthorizationTransaction(
		///												UserInfo,
		///												PayflowConnectionData,
		///												Invoice,
		///												Tender, 
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
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public AuthorizationTransaction(UserInfo UserInfo, Invoice Invoice,
			BaseTender Tender, String RequestId)
			: this(UserInfo, null,Invoice,Tender, RequestId)
		{
		}

		//constructor to be used in case of basic and order auth
			/// <summary>
			/// 
			/// </summary>
			/// <param name="TrxType"></param>
			/// <param name="UserInfo"></param>
			/// <param name="PayflowConnectionData"></param>
			/// <param name="Invoice"></param>
			/// <param name="Tender"></param>
			/// <param name="RequestId"></param>
		internal AuthorizationTransaction(String TrxType , UserInfo UserInfo, PayflowConnectionData PayflowConnectionData,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: base(TrxType, UserInfo, PayflowConnectionData,
			Invoice,
			//PaymentDevice ,
			Tender, RequestId)
		{
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="TrxType"></param>
		/// <param name="UserInfo"></param>
		/// <param name="Invoice"></param>
		/// <param name="Tender"></param>
		/// <param name="RequestId"></param>
		internal AuthorizationTransaction(String TrxType ,UserInfo UserInfo, Invoice Invoice,
			BaseTender Tender, String RequestId)
			: this(TrxType ,UserInfo, null,Invoice,Tender, RequestId)
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORIGID, mOrigId));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PARTIALAUTH, mPartialAuth));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CREATESECURETOKEN, mCreateSecureToken));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SECURETOKENID, mSecureTokenId));
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