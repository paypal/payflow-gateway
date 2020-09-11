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
	/// This class is used to perform a recurring transaction with
	/// cancel action.
	/// </summary>
	/// <remarks> RecurringCancelTransaction is used to cancel  the recurring profile
	/// to deactivate the profile from performing further transactions. The profile is 
	/// marked as cancelled and the customer is no longer billed. PayPal records the 
	/// cancellation date. 
	/// </remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	//Set the Recurring related information.
	///	RecurringInfo RecurInfo = new RecurringInfo();                                                    
	///	RecurInfo.OrigProfileId = "RT0000001350";                                                          
	///	///////////////////////////////////////////////////////////////////                                     
	///	                                                                                                                        
	///	// Create a new Recurring Cancel Transaction.                                                      
	///	RecurringCancelTransaction Trans = new RecurringCancelTransaction(                   
	///		User, Connection, RecurInfo, PayflowUtility.RequestId);                                    
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
	///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);                
	///		}                                                                                                               
	///	                                                                                                                        
	///		// Get the Recurring Response parameters.                                                  
	///		RecurringResponse RecurResponse = Resp.RecurringResponse;                     
	///		if (RecurResponse != null)                                                                           
	///		{                                                                                                               
	///			Console.WriteLine("RPREF = " + RecurResponse.RPRef);                       
	///			Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);             
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
	///	</code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	'Set the Recurring related information.                                                                                    
	///	   Dim RecurInfo As RecurringInfo = New RecurringInfo                                               
	///	  RecurInfo.OrigProfileId = "RT0000001350"                                                                
	///	  '/////////////////////////////////////////////////////////////////                                           
	///	                                                                                                                               
	///	  ' Create a new Recurring Cancel Transaction.                                                            
	///	  Dim Trans As RecurringCancelTransaction = New RecurringCancelTransaction(User,    
	///						Connection, RecurInfo, PayflowUtility.RequestId)              
	///	                                                                                                                               
	///	  ' Submit the transaction.                                                                                          
	///	  Dim Resp As Response = Trans.SubmitTransaction()                                                 
	///	                                                                                                                               
	///	  If Not Resp Is Nothing Then                                                                                     
	///	      ' Get the Transaction Response parameters.                                                          
	///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse               
	///	      If Not TrxnResponse Is Nothing Then                                                                    
	///	          Console.WriteLine("RESULT = " + TrxnResponse.Result)                                     
	///	          Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                              
	///	      End If                                                                                                                
	///	                                                                                                                               
	///	      ' Get the Recurring Response parameters.                                                            
	///	      Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                   
	///	      If Not RecurResponse Is Nothing Then                                                                  
	///	          Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                       
	///	          Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                            
	///	      End If                                                                                                                
	///	  End If                                                                                                                    
	///	                                                                                                                               
	///	  ' Get the Context and check for any contained SDK specific errors.                             
	///	  Dim Ctx As Context = Resp.TransactionContext                                                        
	///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                         
	///	      Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                    
	///	  End If                                                                                                                    
	///	
	///	</code>
	///	</example>
	public class RecurringCancelTransaction : RecurringTransaction
	{
		#region "Constructor"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> RecurringCancelTransaction is used to cancel  the recurring profile
		/// to deactivate the profile from performing further transactions. The profile is 
		/// marked as cancelled and the customer is no longer billed. PayPal records the 
		/// cancellation date. 
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	//Set the Recurring related information.
		///	RecurringInfo RecurInfo = new RecurringInfo();                                                    
		///	RecurInfo.OrigProfileId = "RT0000001350";                                                          
		///	///////////////////////////////////////////////////////////////////                                     
		///	                                                                                                                        
		///	// Create a new Recurring Cancel Transaction.                                                      
		///	RecurringCancelTransaction Trans = new RecurringCancelTransaction(                   
		///		User, Connection, RecurInfo, PayflowUtility.RequestId);                                    
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
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);                
		///		}                                                                                                               
		///	                                                                                                                        
		///		// Get the Recurring Response parameters.                                                  
		///		RecurringResponse RecurResponse = Resp.RecurringResponse;                     
		///		if (RecurResponse != null)                                                                           
		///		{                                                                                                               
		///			Console.WriteLine("RPREF = " + RecurResponse.RPRef);                       
		///			Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);             
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
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.                                                                                    
		///	   Dim RecurInfo As RecurringInfo = New RecurringInfo                                               
		///	  RecurInfo.OrigProfileId = "RT0000001350"                                                                
		///	  '/////////////////////////////////////////////////////////////////                                           
		///	                                                                                                                               
		///	  ' Create a new Recurring Cancel Transaction.                                                            
		///	  Dim Trans As RecurringCancelTransaction = New RecurringCancelTransaction(User,    
		///						Connection, RecurInfo, PayflowUtility.RequestId)              
		///	                                                                                                                               
		///	  ' Submit the transaction.                                                                                          
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                                 
		///	                                                                                                                               
		///	  If Not Resp Is Nothing Then                                                                                     
		///	      ' Get the Transaction Response parameters.                                                          
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse               
		///	      If Not TrxnResponse Is Nothing Then                                                                    
		///	          Console.WriteLine("RESULT = " + TrxnResponse.Result)                                     
		///	          Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                              
		///	      End If                                                                                                                
		///	                                                                                                                               
		///	      ' Get the Recurring Response parameters.                                                            
		///	      Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                   
		///	      If Not RecurResponse Is Nothing Then                                                                  
		///	          Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                       
		///	          Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                            
		///	      End If                                                                                                                
		///	  End If                                                                                                                    
		///	                                                                                                                               
		///	  ' Get the Context and check for any contained SDK specific errors.                             
		///	  Dim Ctx As Context = Resp.TransactionContext                                                        
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                         
		///	      Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                    
		///	  End If                                                                                                                    
		///	
		///	</code>
		///	</example>
		public RecurringCancelTransaction(
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			RecurringInfo RecurringInfo, String RequestId)
			: base(PayflowConstants.RECURRING_ACTION_CANCEL,
			       RecurringInfo,
			       UserInfo, PayflowConnectionData, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> RecurringCancelTransaction is used to cancel  the recurring profile
		/// to deactivate the profile from performing further transactions. The profile is 
		/// marked as cancelled and the customer is no longer billed. PayPal records the 
		/// cancellation date. 
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	//Set the Recurring related information.
		///	RecurringInfo RecurInfo = new RecurringInfo();                                                    
		///	RecurInfo.OrigProfileId = "RT0000001350";                                                          
		///	///////////////////////////////////////////////////////////////////                                     
		///	                                                                                                                        
		///	// Create a new Recurring Cancel Transaction.                                                      
		///	RecurringCancelTransaction Trans = new RecurringCancelTransaction(                   
		///		User, RecurInfo, PayflowUtility.RequestId);                                    
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
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);                
		///		}                                                                                                               
		///	                                                                                                                        
		///		// Get the Recurring Response parameters.                                                  
		///		RecurringResponse RecurResponse = Resp.RecurringResponse;                     
		///		if (RecurResponse != null)                                                                           
		///		{                                                                                                               
		///			Console.WriteLine("RPREF = " + RecurResponse.RPRef);                       
		///			Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);             
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
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.                                                                                    
		///	   Dim RecurInfo As RecurringInfo = New RecurringInfo                                               
		///	  RecurInfo.OrigProfileId = "RT0000001350"                                                                
		///	  '/////////////////////////////////////////////////////////////////                                           
		///	                                                                                                                               
		///	  ' Create a new Recurring Cancel Transaction.                                                            
		///	  Dim Trans As RecurringCancelTransaction = New RecurringCancelTransaction(User,    
		///						 RecurInfo, PayflowUtility.RequestId)              
		///	                                                                                                                               
		///	  ' Submit the transaction.                                                                                          
		///	  Dim Resp As Response = Trans.SubmitTransaction()                                                 
		///	                                                                                                                               
		///	  If Not Resp Is Nothing Then                                                                                     
		///	      ' Get the Transaction Response parameters.                                                          
		///	      Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse               
		///	      If Not TrxnResponse Is Nothing Then                                                                    
		///	          Console.WriteLine("RESULT = " + TrxnResponse.Result)                                     
		///	          Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                              
		///	      End If                                                                                                                
		///	                                                                                                                               
		///	      ' Get the Recurring Response parameters.                                                            
		///	      Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                   
		///	      If Not RecurResponse Is Nothing Then                                                                  
		///	          Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                       
		///	          Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                            
		///	      End If                                                                                                                
		///	  End If                                                                                                                    
		///	                                                                                                                               
		///	  ' Get the Context and check for any contained SDK specific errors.                             
		///	  Dim Ctx As Context = Resp.TransactionContext                                                        
		///	  If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                         
		///	      Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                    
		///	  End If                                                                                                                    
		///	
		///	</code>
		///	</example>
		public RecurringCancelTransaction(
			UserInfo UserInfo,
			RecurringInfo RecurringInfo, String RequestId)
			: this(UserInfo, null, RecurringInfo,RequestId)
		{
		}
				#endregion
		
	}
}