#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform a void transaction.
	/// </summary>
	/// <remarks> 
	/// The Void transaction prevents a transaction from being settled, but does
	/// not release the authorization (hold on funds) on the cardholder’s account. 
	/// Delayed Capture, Sale, Credit, Authorization, and Voice
	/// Authorization transactions can be voided. A Void transaction cannot be voided.
	/// The Void must occur prior to settlement.
	/// </remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	// Create a new Void Transaction.                                                                     
	///	// The ORIGID is the PNREF no. for a previous transaction.                                 
	///	VoidTransaction Trans = new VoidTransaction("V63A0A07BE5A",                         
	///		User, Connection, PayflowUtility.RequestId);                                                 
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
	///		}                                                                                                            
	///	}                                                                                                                    
	///	                                                                                                                     
	///	// Get the Context and check for any contained SDK specific errors.                    
	///	Context Ctx = Resp.TransactionContext;                                                           
	///	if (Ctx != null  &amp;  &amp;  Ctx.getErrorCount() > 0)                                                        
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
	///	  ' Create a new Void Transaction.                                                                    
	///	  ' The ORIGID is the PNREF no. for a previous transaction.                                 
	///		 Dim Trans As VoidTransaction = New VoidTransaction("V63A0A07BE5A",           
	///	 User, Connection, PayflowUtility.RequestId)                                                    
	///	                                                                                                                     
	///	  ' Submit the transaction.                                                                                
	///	  Dim Resp As Response = Trans.SubmitTransaction()                                        
	///	                                                                                                                     
	///	  If Not Resp Is Nothing Then                                                                            
	///	      ' Get the Transaction Response parameters.                                                
	///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse      
	///	      If Not TrxnResponse Is Nothing Then                                                          
	///	          Console.WriteLine("RESULT = "  +  TrxnResponse.Result)                           
	///	          Console.WriteLine("PNREF = "  +  TrxnResponse.Pnref)                              
	///	          Console.WriteLine("RESPMSG = "  +  TrxnResponse.RespMsg)                    
	///	      End If                                                                                                       
	///	  End If                                                                                                           
	///	                                                                                                                     
	///	  ' Get the Context and check for any contained SDK specific errors.                    
	///	  Dim Ctx As Context = Resp.TransactionContext                                               
	///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                             
	///	      Console.WriteLine(Environment.NewLine  +  "Errors = "  +  Ctx.ToString())        
	///	  End If                                                                                                           
	///
	///	</code>
	///	</example>
	public class VoidTransaction : ReferenceTransaction
	{
		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private VoidTransaction()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// The Void transaction prevents a transaction from being settled, but does
		/// not release the authorization (hold on funds) on the cardholder’s account. 
		/// Delayed Capture, Sale, Credit, Authorization, and Voice
		/// Authorization transactions can be voided. A Void transaction cannot be voided.
		/// The Void must occur prior to settlement.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Void Transaction.                                                                     
		///	// The ORIGID is the PNREF no. for a previous transaction.                                 
		///	VoidTransaction Trans = new VoidTransaction("V63A0A07BE5A",                         
		///		User, Connection, PayflowUtility.RequestId);                                                 
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
		///		}                                                                                                            
		///	}                                                                                                                    
		///	                                                                                                                     
		///	// Get the Context and check for any contained SDK specific errors.                    
		///	Context Ctx = Resp.TransactionContext;                                                           
		///	if (Ctx != null  &amp;  &amp;  Ctx.getErrorCount() > 0)                                                        
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
		///	  ' Create a new Void Transaction.                                                                    
		///	  ' The ORIGID is the PNREF no. for a previous transaction.                                 
		///		 Dim Trans As VoidTransaction = New VoidTransaction("V63A0A07BE5A",           
		///	 User, Connection, PayflowUtility.RequestId)                                                    
		///	                                                                                                                     
		///	  ' Submit the transaction.                                                                                
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                        
		///	                                                                                                                     
		///	  If Not Resp Is Nothing Then                                                                            
		///	      ' Get the Transaction Response parameters.                                                
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse      
		///	      If Not TrxnResponse Is Nothing Then                                                          
		///	          Console.WriteLine("RESULT = "  +  TrxnResponse.Result)                           
		///	          Console.WriteLine("PNREF = "  +  TrxnResponse.Pnref)                              
		///	          Console.WriteLine("RESPMSG = "  +  TrxnResponse.RespMsg)                    
		///	      End If                                                                                                       
		///	  End If                                                                                                           
		///	                                                                                                                     
		///	  ' Get the Context and check for any contained SDK specific errors.                    
		///	  Dim Ctx As Context = Resp.TransactionContext                                               
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                             
		///	      Console.WriteLine(Environment.NewLine  +  "Errors = "  +  Ctx.ToString())        
		///	  End If                                                                                                           
		///
		///	</code>
		///	</example>
		public VoidTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) : base(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, PayflowConnectionData, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// The Void transaction prevents a transaction from being settled, but does
		/// not release the authorization (hold on funds) on the cardholder’s account. 
		/// Delayed Capture, Sale, Credit, Authorization, and Voice
		/// Authorization transactions can be voided. A Void transaction cannot be voided.
		/// The Void must occur prior to settlement.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Void Transaction.                                                                     
		///	// The ORIGID is the PNREF no. for a previous transaction.                                 
		///	VoidTransaction Trans = new VoidTransaction("V63A0A07BE5A",                         
		///		User, PayflowUtility.RequestId);                                                 
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
		///		}                                                                                                            
		///	}                                                                                                                    
		///	                                                                                                                     
		///	// Get the Context and check for any contained SDK specific errors.                    
		///	Context Ctx = Resp.TransactionContext;                                                           
		///	if (Ctx != null  &amp;  &amp;  Ctx.getErrorCount() > 0)                                                        
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
		///	  ' Create a new Void Transaction.                                                                    
		///	  ' The ORIGID is the PNREF no. for a previous transaction.                                 
		///		 Dim Trans As VoidTransaction = New VoidTransaction("V63A0A07BE5A",           
		///	 User, PayflowUtility.RequestId)                                                    
		///	                                                                                                                     
		///	  ' Submit the transaction.                                                                                
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                        
		///	                                                                                                                     
		///	  If Not Resp Is Nothing Then                                                                            
		///	      ' Get the Transaction Response parameters.                                                
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse      
		///	      If Not TrxnResponse Is Nothing Then                                                          
		///	          Console.WriteLine("RESULT = "  +  TrxnResponse.Result)                           
		///	          Console.WriteLine("PNREF = "  +  TrxnResponse.Pnref)                              
		///	          Console.WriteLine("RESPMSG = "  +  TrxnResponse.RespMsg)                    
		///	      End If                                                                                                       
		///	  End If                                                                                                           
		///	                                                                                                                     
		///	  ' Get the Context and check for any contained SDK specific errors.                    
		///	  Dim Ctx As Context = Resp.TransactionContext                                               
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                             
		///	      Console.WriteLine(Environment.NewLine  +  "Errors = "  +  Ctx.ToString())        
		///	  End If                                                                                                           
		///
		///	</code>
		///	</example>
		public VoidTransaction(String OrigId, UserInfo UserInfo, String RequestId) : base(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// The Void transaction prevents a transaction from being settled, but does
		/// not release the authorization (hold on funds) on the cardholder’s account. 
		/// Delayed Capture, Sale, Credit, Authorization, and Voice
		/// Authorization transactions can be voided. A Void transaction cannot be voided.
		/// The Void must occur prior to settlement.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Void Transaction.                                                                     
		///	// The ORIGID is the PNREF no. for a previous transaction.                                 
		///	VoidTransaction Trans = new VoidTransaction("V63A0A07BE5A",                         
		///		User, Connection, PayflowUtility.RequestId);                                                 
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
		///		}                                                                                                            
		///	}                                                                                                                    
		///	                                                                                                                     
		///	// Get the Context and check for any contained SDK specific errors.                    
		///	Context Ctx = Resp.TransactionContext;                                                           
		///	if (Ctx != null  &amp;  &amp;  Ctx.getErrorCount() > 0)                                                        
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
		///	  ' Create a new Void Transaction.                                                                    
		///	  ' The ORIGID is the PNREF no. for a previous transaction.                                 
		///		 Dim Trans As VoidTransaction = New VoidTransaction("V63A0A07BE5A",           
		///	 User, Connection, PayflowUtility.RequestId)                                                    
		///	                                                                                                                     
		///	  ' Submit the transaction.                                                                                
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                        
		///	                                                                                                                     
		///	  If Not Resp Is Nothing Then                                                                            
		///	      ' Get the Transaction Response parameters.                                                
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse      
		///	      If Not TrxnResponse Is Nothing Then                                                          
		///	          Console.WriteLine("RESULT = "  +  TrxnResponse.Result)                           
		///	          Console.WriteLine("PNREF = "  +  TrxnResponse.Pnref)                              
		///	          Console.WriteLine("RESPMSG = "  +  TrxnResponse.RespMsg)                    
		///	      End If                                                                                                       
		///	  End If                                                                                                           
		///	                                                                                                                     
		///	  ' Get the Context and check for any contained SDK specific errors.                    
		///	  Dim Ctx As Context = Resp.TransactionContext                                               
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                             
		///	      Console.WriteLine(Environment.NewLine  +  "Errors = "  +  Ctx.ToString())        
		///	  End If                                                                                                           
		///
		///	</code>
		///	</example>
		public VoidTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, String RequestId) : base(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// The Void transaction prevents a transaction from being settled, but does
		/// not release the authorization (hold on funds) on the cardholder’s account. 
		/// Delayed Capture, Sale, Credit, Authorization, and Voice
		/// Authorization transactions can be voided. A Void transaction cannot be voided.
		/// The Void must occur prior to settlement.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Void Transaction.                                                                     
		///	// The ORIGID is the PNREF no. for a previous transaction.                                 
		///	VoidTransaction Trans = new VoidTransaction("V63A0A07BE5A",                         
		///		User, Connection, Inv, PayflowUtility.RequestId);                                                 
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
		///		}                                                                                                            
		///	}                                                                                                                    
		///	                                                                                                                     
		///	// Get the Context and check for any contained SDK specific errors.                    
		///	Context Ctx = Resp.TransactionContext;                                                           
		///	if (Ctx != null  &amp;  &amp;  Ctx.getErrorCount() > 0)                                                        
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
		///	  ' Create a new Void Transaction.                                                                    
		///	  ' The ORIGID is the PNREF no. for a previous transaction.                                 
		///		 Dim Trans As VoidTransaction = New VoidTransaction("V63A0A07BE5A",           
		///	 User, Connection, Inv, PayflowUtility.RequestId)                                                    
		///	                                                                                                                     
		///	  ' Submit the transaction.                                                                                
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                        
		///	                                                                                                                     
		///	  If Not Resp Is Nothing Then                                                                            
		///	      ' Get the Transaction Response parameters.                                                
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse      
		///	      If Not TrxnResponse Is Nothing Then                                                          
		///	          Console.WriteLine("RESULT = "  +  TrxnResponse.Result)                           
		///	          Console.WriteLine("PNREF = "  +  TrxnResponse.Pnref)                              
		///	          Console.WriteLine("RESPMSG = "  +  TrxnResponse.RespMsg)                    
		///	      End If                                                                                                       
		///	  End If                                                                                                           
		///	                                                                                                                     
		///	  ' Get the Context and check for any contained SDK specific errors.                    
		///	  Dim Ctx As Context = Resp.TransactionContext                                               
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                             
		///	      Console.WriteLine(Environment.NewLine  +  "Errors = "  +  Ctx.ToString())        
		///	  End If                                                                                                           
		///
		///	</code>
		///	</example>
		public VoidTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, String RequestId) : this(OrigId, UserInfo, null, Invoice, RequestId)
		{
		}
		#endregion
	}

}