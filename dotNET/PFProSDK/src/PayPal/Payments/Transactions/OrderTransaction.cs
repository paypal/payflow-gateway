#region "Imports"

using System;
using PayPal.Payments.DataObjects ;
#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to create and perform an Order Transaction for Express Checkout.
	/// 
	/// An Order transaction represents an agreement to pay one or more authorized amounts up to 
	/// the specified total over a maximum of 29 days. 
	/// </summary>
	/// <example>This example shows how to create and perform a order transaction as part of Express Checkout.
	/// <code lang="C#" escaped="false">
	///		..........
	///		..........
	///		//Populate required data objects.
	///		..........
	///		..........
	///				
	///		// Create the Tender object.
	///		PayPalTender Tender = new PayPalTender(SetRequest);
	///
	///		// Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
	///		// authorized amounts up to the specified total over a maximum of 29 days. 
	///		OrderTransaction Trans = new OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId);
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
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString());
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token);
	///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId);
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
	///		if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
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
	///		' Create the Tender object. 
	///		Dim Tender As New PayPalTender(SetRequest)
	///		
	///		' Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
	///		' authorized amounts up to the specified total over a maximum of 29 days. 
	///		Dim Trans As New OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)
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
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
	///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
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
	public class OrderTransaction : AuthorizationTransaction
	{
		#region "Constructors"

		/// <summary>
		/// This class is used to create and perform an Order Transaction for Express Checkout.
		/// 
		/// An Order transaction represents an agreement to pay one or more authorized amounts up to 
		/// the specified total over a maximum of 29 days. 
		/// </summary>
		/// <example>This example shows how to create and perform a order transaction as part of Express Checkout.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///				
		///		// Create the Tender object.
		///		PayPalTender Tender = new PayPalTender(SetRequest);
		///
		///		// Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
		///		// authorized amounts up to the specified total over a maximum of 29 days. 
		///		OrderTransaction Trans = new OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId);
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
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString());
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token);
		///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId);
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
		///		if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
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
		///		' Create the Tender object. 
		///		Dim Tender As New PayPalTender(SetRequest)
		///		
		///		' Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
		///		' authorized amounts up to the specified total over a maximum of 29 days. 
		///		Dim Trans As New OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)
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
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
		///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
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
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object </param>
		/// <param name="RequestId">Request Id</param>
		public OrderTransaction (UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice,  PayPalTender Tender, String RequestId) 
			: base("O", UserInfo ,PayflowConnectionData ,Invoice ,Tender ,RequestId)
		{}
		/// <summary>
		/// This class is used to create and perform an Order Transaction for Express Checkout.
		/// 
		/// An Order transaction represents an agreement to pay one or more authorized amounts up to 
		/// the specified total over a maximum of 29 days. 
		/// </summary>
		/// <example>This example shows how to create and perform a order transaction as part of Express Checkout.
		/// <code lang="C#" escaped="false">
		///		..........
		///		..........
		///		//Populate required data objects.
		///		..........
		///		..........
		///				
		///		// Create the Tender object.
		///		PayPalTender Tender = new PayPalTender(SetRequest);
		///
		///		// Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
		///		// authorized amounts up to the specified total over a maximum of 29 days. 
		///		OrderTransaction Trans = new OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId);
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
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString());
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token);
		///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId);
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
		///		if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
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
		///		' Create the Tender object. 
		///		Dim Tender As New PayPalTender(SetRequest)
		///		
		///		' Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
		///		' authorized amounts up to the specified total over a maximum of 29 days. 
		///		Dim Trans As New OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)
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
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
		///				Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
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
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object </param>
		/// <param name="RequestId">Request Id</param>
		public OrderTransaction ( UserInfo UserInfo, Invoice Invoice, PayPalTender Tender, String RequestId) 
			: base("0", UserInfo,Invoice ,Tender ,RequestId)
		{}
		#endregion


	}
}
