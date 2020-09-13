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
	/// This class is used to perform a voice authorization transaction.
	/// </summary>
	/// <remarks> 
	/// Some transactions cannot be authorized over the Internet (for example, high dollar
	/// amounts)用rocessing networks generate Referral (Result Code 13) transactions.
	/// In these situations, contact the customer service department of the 
	/// merchant bank and provide the payment information as requested. 
	/// If the transaction is approved, the bank provides a voice authorization 
	/// code (AUTHCODE) for the transaction. This must be included as AUTHCODE 
	/// as part of a Voice Authorization transaction.
	/// </remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	// Create a new Voice Auth Transaction.                                                           
	///	VoiceAuthTransaction Trans = new VoiceAuthTransaction("123PNI",                    
	///		User, Connection, Inv, Card, PayflowUtility.RequestId);                                
	///	                                                                                                                    
	///	// Submit the transaction.                                                                                
	///	Response Resp = Trans.SubmitTransaction();                                                   
	///	                                                                                                                    
	///	if (Resp != null)                                                                                              
	///	{                                                                                                                   
	///		// Get the Transaction Response parameters.                                            
	///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;            
	///		if (TrxnResponse != null)                                                                         
	///		{                                                                                                           
	///			Console.WriteLine("RESULT = " + TrxnResponse.Result);                   
	///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);                      
	///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);            
	///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);        
	///		}                                                                                                           
	///	}                                                                                                                   
	///	                                                                                                                    
	///	// Get the Context and check for any contained SDK specific errors.                   
	///	Context Ctx = Resp.TransactionContext;                                                          
	///	if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)                                                       
	///	{                                                                                                                   
	///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());    
	///	}                                                                                                                   
	///
	///
	/// </code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	 ' Create a new Voice Auth Transaction.                                                                
	///	 Dim Trans As VoiceAuthTransaction = New VoiceAuthTransaction("123PNI", User,    
	///		Connection, Inv, Card, PayflowUtility.RequestId)                                          
	///	                                                                                                                         
	///	 ' Submit the transaction.                                                                                     
	///	 Dim Resp As Response = Trans.SubmitTransaction()                                             
	///	                                                                                                                         
	///	 If Not Resp Is Nothing Then                                                                                 
	///	     ' Get the Transaction Response parameters.                                                     
	///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse           
	///	     If Not TrxnResponse Is Nothing Then                                                               
	///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)                                
	///	         Console.WriteLine("PNREF = " + TrxnResponse.Pnref)                                   
	///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                         
	///	         Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)                      
	///	     End If                                                                                                            
	///	 End If                                                                                                                
	///	                                                                                                                         
	///	 ' Get the Context and check for any contained SDK specific errors.                         
	///	 Dim Ctx As Context = Resp.TransactionContext                                                    
	///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                  
	///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())             
	///	 End If                                                                                                                
	///
	///	</code>
	///	</example>
	public sealed class VoiceAuthTransaction : BaseTransaction
	{
		#region "Member variables"

		/// <summary>
		/// Holds AuthCode, Authorization code obtain via another means; i.e. phone.
		/// </summary>
		private String mAuthCode;
		/// <summary>
		/// Holds AuthDate, Date the AuthCode was obtained.
		/// </summary>
		private String mAuthDate;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents creation of an empty Transaction object. 
		/// </summary>
		private VoiceAuthTransaction()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="AuthCode">Authorization code obtain via another means; i.e. phone.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// Some transactions cannot be authorized over the Internet (for example, high dollar
		/// amounts)用rocessing networks generate Referral (Result Code 13) transactions.
		/// In these situations, contact the customer service department of the 
		/// merchant bank and provide the payment information as requested. 
		/// If the transaction is approved, the bank provides a voice authorization 
		/// code (AUTHCODE) for the transaction. This must be included as AUTHCODE 
		/// as part of a Voice Authorization transaction.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Voice Authorization Transaction.                                                           
		///	VoiceAuthTransaction Trans = new VoiceAuthTransaction("123PNI",                    
		///		User, Connection, Inv, Card, PayflowUtility.RequestId);                                
		///	                                                                                                                    
		///	// Submit the transaction.                                                                                
		///	Response Resp = Trans.SubmitTransaction();                                                   
		///	                                                                                                                    
		///	if (Resp != null)                                                                                              
		///	{                                                                                                                   
		///		// Get the Transaction Response parameters.                                            
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;            
		///		if (TrxnResponse != null)                                                                         
		///		{                                                                                                           
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);                   
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);                      
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);            
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);        
		///		}                                                                                                           
		///	}                                                                                                                   
		///	                                                                                                                    
		///	// Get the Context and check for any contained SDK specific errors.                   
		///	Context Ctx = Resp.TransactionContext;                                                          
		///	if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)                                                       
		///	{                                                                                                                   
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());    
		///	}                                                                                                                   
		///
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	 ' Create a new Voice Authorization Transaction.                                                                
		///	 Dim Trans As VoiceAuthTransaction = New VoiceAuthTransaction("123PNI", User,    
		///		Connection, Inv, Card, PayflowUtility.RequestId)                                          
		///	                                                                                                                         
		///	 ' Submit the transaction.                                                                                     
		///	 Dim Resp As Response = Trans.SubmitTransaction()                                             
		///	                                                                                                                         
		///	 If Not Resp Is Nothing Then                                                                                 
		///	     ' Get the Transaction Response parameters.                                                     
		///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse           
		///	     If Not TrxnResponse Is Nothing Then                                                               
		///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)                                
		///	         Console.WriteLine("PNREF = " + TrxnResponse.Pnref)                                   
		///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                         
		///	         Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)                      
		///	     End If                                                                                                            
		///	 End If                                                                                                                
		///	                                                                                                                         
		///	 ' Get the Context and check for any contained SDK specific errors.                         
		///	 Dim Ctx As Context = Resp.TransactionContext                                                    
		///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                  
		///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())             
		///	 End If                                                                                                                
		///
		///	</code>
		///	</example>
		public VoiceAuthTransaction(String AuthCode, UserInfo UserInfo,
		                            PayflowConnectionData PayflowConnectionData, Invoice Invoice,
		                            BaseTender Tender, String RequestId)
			: base(PayflowConstants.TRXTYPE_VOICEAUTH, UserInfo,
			       PayflowConnectionData, Invoice,
			       Tender, RequestId)
		{
			mAuthCode = AuthCode;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="AuthCode">Authorization code obtain via another means; i.e. phone.</param>
		/// <param name="AuthDate">Date the AuthCode was obtained.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// Some transactions cannot be authorized over the Internet (for example, high dollar
		/// amounts)用rocessing networks generate Referral (Result Code 13) transactions.
		/// In these situations, contact the customer service department of the 
		/// merchant bank and provide the payment information as requested. 
		/// If the transaction is approved, the bank provides a voice authorization 
		/// code (AUTHCODE) for the transaction. This must be included as AUTHCODE 
		/// as part of a Voice Authorization transaction.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Voice Authorization Transaction.                                                           
		///	VoiceAuthTransaction Trans = new VoiceAuthTransaction("123PNI", "08102020",                 
		///		User, Connection, Inv, Card, PayflowUtility.RequestId);                                
		///	                                                                                                                    
		///	// Submit the transaction.                                                                                
		///	Response Resp = Trans.SubmitTransaction();                                                   
		///	                                                                                                                    
		///	if (Resp != null)                                                                                              
		///	{                                                                                                                   
		///		// Get the Transaction Response parameters.                                            
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;            
		///		if (TrxnResponse != null)                                                                         
		///		{                                                                                                           
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);                   
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);                      
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);            
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);        
		///		}                                                                                                           
		///	}                                                                                                                   
		///	                                                                                                                    
		///	// Get the Context and check for any contained SDK specific errors.                   
		///	Context Ctx = Resp.TransactionContext;                                                          
		///	if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)                                                       
		///	{                                                                                                                   
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());    
		///	}                                                                                                                   
		///
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	 ' Create a new Voice Authorization Transaction.                                                                
		///	 Dim Trans As VoiceAuthTransaction = New VoiceAuthTransaction("123PNI", "08102020",
		///	 User, Connection, Inv, Card, PayflowUtility.RequestId)                                          
		///	                                                                                                                         
		///	 ' Submit the transaction.                                                                                     
		///	 Dim Resp As Response = Trans.SubmitTransaction()                                             
		///	                                                                                                                         
		///	 If Not Resp Is Nothing Then                                                                                 
		///	     ' Get the Transaction Response parameters.                                                     
		///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse           
		///	     If Not TrxnResponse Is Nothing Then                                                               
		///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)                                
		///	         Console.WriteLine("PNREF = " + TrxnResponse.Pnref)                                   
		///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                         
		///	         Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)                      
		///	     End If                                                                                                            
		///	 End If                                                                                                                
		///	                                                                                                                         
		///	 ' Get the Context and check for any contained SDK specific errors.                         
		///	 Dim Ctx As Context = Resp.TransactionContext                                                    
		///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                  
		///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())             
		///	 End If                                                                                                                
		///
		///	</code>
		///	</example>
		public VoiceAuthTransaction(String AuthCode, String AuthDate, UserInfo UserInfo,
		                            PayflowConnectionData PayflowConnectionData, Invoice Invoice,
		                            BaseTender Tender, String RequestId)
			: base(PayflowConstants.TRXTYPE_VOICEAUTH, UserInfo,
			       PayflowConnectionData, Invoice,
			       Tender, RequestId)
		{
			mAuthCode = AuthCode;
			mAuthDate = AuthDate;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="AuthCode">Authorization code obtain via another means; i.e. phone.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// Some transactions cannot be authorized over the Internet (for example, high dollar
		/// amounts)用rocessing networks generate Referral (Result Code 13) transactions.
		/// In these situations, contact the customer service department of the 
		/// merchant bank and provide the payment information as requested. 
		/// If the transaction is approved, the bank provides a voice authorization 
		/// code (AUTHCODE) for the transaction. This must be included as AUTHCODE 
		/// as part of a Voice Authorization transaction.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Voice Authorization Transaction.                                                           
		///	VoiceAuthTransaction Trans = new VoiceAuthTransaction("123PNI",                    
		///		User, Inv, Card, PayflowUtility.RequestId);                                
		///	                                                                                                                    
		///	// Submit the transaction.                                                                                
		///	Response Resp = Trans.SubmitTransaction();                                                   
		///	                                                                                                                    
		///	if (Resp != null)                                                                                              
		///	{                                                                                                                   
		///		// Get the Transaction Response parameters.                                            
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;            
		///		if (TrxnResponse != null)                                                                         
		///		{                                                                                                           
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);                   
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);                      
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);            
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);        
		///		}                                                                                                           
		///	}                                                                                                                   
		///	                                                                                                                    
		///	// Get the Context and check for any contained SDK specific errors.                   
		///	Context Ctx = Resp.TransactionContext;                                                          
		///	if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)                                                       
		///	{                                                                                                                   
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());    
		///	}                                                                                                                   
		///
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	 ' Create a new Voice Auth Transaction.                                                                
		///	 Dim Trans As VoiceAuthTransaction = New VoiceAuthTransaction("123PNI", User,    
		///		Inv, Card, PayflowUtility.RequestId)                                          
		///	                                                                                                                         
		///	 ' Submit the transaction.                                                                                     
		///	 Dim Resp As Response = Trans.SubmitTransaction()                                             
		///	                                                                                                                         
		///	 If Not Resp Is Nothing Then                                                                                 
		///	     ' Get the Transaction Response parameters.                                                     
		///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse           
		///	     If Not TrxnResponse Is Nothing Then                                                               
		///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)                                
		///	         Console.WriteLine("PNREF = " + TrxnResponse.Pnref)                                   
		///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                         
		///	         Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)                      
		///	     End If                                                                                                            
		///	 End If                                                                                                                
		///	                                                                                                                         
		///	 ' Get the Context and check for any contained SDK specific errors.                         
		///	 Dim Ctx As Context = Resp.TransactionContext                                                    
		///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                  
		///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())             
		///	 End If                                                                                                                
		///
		///	</code>
		///	</example>
		public VoiceAuthTransaction(String AuthCode, UserInfo UserInfo,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: this(AuthCode,UserInfo,
			null, Invoice,
			Tender, RequestId)
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHCODE, mAuthCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHDATE, mAuthDate));
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