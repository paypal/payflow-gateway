#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform a recurring transaction with
	/// add action.
	/// </summary>
	/// <remarks> RecurringAddTransaction is used to add a new recurring profile 
	/// either by submitting the data that defines the profile or by converting an 
	/// existing transaction into a profile. Upon successful creation of a profile,
	/// PayPal activates the profile, performs the Optional Transaction if specified,
	/// initiates the payment cycle, and returns a Profile ID (a 12-character string that 
	/// uniquely identifies the profile for searching and reporting). Upon failure, PayPal 
	/// does not generate the profile and returns an error message.
	/// </remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	//Set the Recurring related information.
	///	RecurringInfo RecurInfo = new RecurringInfo();
	///	// The date that the first payment will be processed.
	///	// This will be of the format mmddyyyy.
	///	RecurInfo.Start = "01012009";
	///	RecurInfo.ProfileName = "PayPal";
	///	// Specifies how often the payment occurs. All PAYPERIOD values must use
	///	// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
	///	// QTER / SMYR / YEAR
	///	RecurInfo.PayPeriod = "WEEK";
	///	///////////////////////////////////////////////////////////////////
	///
	///	// Create a new Recurring Add Transaction.
	///	RecurringAddTransaction Trans = new RecurringAddTransaction(
	///		User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId);
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
	///
	///	</code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	'Set the Recurring related information.                                                                                    
	///	Dim RecurInfo As RecurringInfo = New RecurringInfo                                                               
	///	' The date that the first payment will be processed.                                                                  
	///	' This will be of the format mmddyyyy.                                                                                    
	///	RecurInfo.Start = "01012009"                                                                                                
	///	RecurInfo.ProfileName = "PayPal"                                                                                        
	///	' Specifies how often the payment occurs. All PAYPERIOD values must use                                 
	///	' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /                                  
	///	' QTER / SMYR / YEAR                                                                                                            
	///	RecurInfo.PayPeriod = "WEEK"                                                                                               
	///	'/////////////////////////////////////////////////////////////////                                                         
	///	                                                                                                                                           
	///	' Create a new Recurring Add Transaction.                                                                              
	///	Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Connection, Inv,   
	///						Card, RecurInfo, PayflowUtility.RequestId)                                     
	///	                                                                                                                                           
	///	' Submit the transaction.                                                                                                        
	///	Dim Resp As Response = Trans.SubmitTransaction()                                                                
	///	                                                                                                                                           
	///	If Not Resp Is Nothing Then                                                                                                    
	///	    ' Get the Transaction Response parameters.                                                                        
	///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse                              
	///	    If Not TrxnResponse Is Nothing Then                                                                                  
	///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)                                                   
	///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                                            
	///	    End If                                                                                                                               
	///	                                                                                                                                           
	///	    ' Get the Recurring Response parameters.                                                                           
	///	    Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                                  
	///	    If Not RecurResponse Is Nothing Then                                                                                 
	///	        Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                                    
	///	        Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                                          
	///	    End If                                                                                                                               
	///	End If                                                                                                                                   
	///	                                                                                                                                           
	///	' Get the Context and check for any contained SDK specific errors.                                            
	///	Dim Ctx As Context = Resp.TransactionContext                                                                       
	///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                                     
	///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                                
	///	End If                                                                                                                                   
	///	
	///	
	///	</code>
	///	</example>
	public class RecurringAddTransaction : RecurringTransaction
	{
		/// <summary>
		/// Used for original transaction id.
		/// </summary>
		private String mOrigId;

		#region "Properties"

		/// <summary>
		/// Gets, Sets OrigId
		/// </summary>
		public virtual String OrigId
		{
			get { return mOrigId; }
			set { mOrigId = value; }
		}

		#endregion

		#region "Constructor"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RecurringInfo">RecurringInfo object .</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> RecurringAddTransaction is used to add a new recurring profile 
		/// either by submitting the data that defines the profile or by converting an 
		/// existing transaction into a profile. Upon successful creation of a profile,
		/// PayPal activates the profile, performs the Optional Transaction if specified,
		/// initiates the payment cycle, and returns a Profile ID (a 12-character string that 
		/// uniquely identifies the profile for searching and reporting). Upon failure, PayPal 
		/// does not generate the profile and returns an error message.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	//Set the Recurring related information.
		///	RecurringInfo RecurInfo = new RecurringInfo();
		///	// The date that the first payment will be processed.
		///	// This will be of the format mmddyyyy.
		///	RecurInfo.Start = "01012009";
		///	RecurInfo.ProfileName = "PayPal";
		///	// Specifies how often the payment occurs. All PAYPERIOD values must use
		///	// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	// QTER / SMYR / YEAR
		///	RecurInfo.PayPeriod = "WEEK";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Add Transaction.
		///	RecurringAddTransaction Trans = new RecurringAddTransaction(
		///		User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId);
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.                                                                                    
		///	Dim RecurInfo As RecurringInfo = New RecurringInfo                                                               
		///	' The date that the first payment will be processed.                                                                  
		///	' This will be of the format mmddyyyy.                                                                                    
		///	RecurInfo.Start = "01012009"                                                                                                
		///	RecurInfo.ProfileName = "PayPal"                                                                                        
		///	' Specifies how often the payment occurs. All PAYPERIOD values must use                                 
		///	' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /                                  
		///	' QTER / SMYR / YEAR                                                                                                            
		///	RecurInfo.PayPeriod = "WEEK"                                                                                               
		///	'/////////////////////////////////////////////////////////////////                                                         
		///	                                                                                                                                           
		///	' Create a new Recurring Add Transaction.                                                                              
		///	Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Connection, Inv,   
		///						Card, RecurInfo, PayflowUtility.RequestId)                                     
		///	                                                                                                                                           
		///	' Submit the transaction.                                                                                                        
		///	Dim Resp As Response = Trans.SubmitTransaction()                                                                
		///	                                                                                                                                           
		///	If Not Resp Is Nothing Then                                                                                                    
		///	    ' Get the Transaction Response parameters.                                                                        
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse                              
		///	    If Not TrxnResponse Is Nothing Then                                                                                  
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)                                                   
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                                            
		///	    End If                                                                                                                               
		///	                                                                                                                                           
		///	    ' Get the Recurring Response parameters.                                                                           
		///	    Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                                  
		///	    If Not RecurResponse Is Nothing Then                                                                                 
		///	        Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                                    
		///	        Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                                          
		///	    End If                                                                                                                               
		///	End If                                                                                                                                   
		///	                                                                                                                                           
		///	' Get the Context and check for any contained SDK specific errors.                                            
		///	Dim Ctx As Context = Resp.TransactionContext                                                                       
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                                     
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                                
		///	End If                                                                                                                                   
		///	
		///	
		///	</code>
		///	</example>
		public RecurringAddTransaction(
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			Invoice Invoice,
			BaseTender Tender,
			RecurringInfo RecurringInfo,
			String RequestId)
			: base(PayflowConstants.RECURRING_ACTION_ADD,
			       RecurringInfo,
			       UserInfo, PayflowConnectionData, Invoice, Tender, RequestId)
		{
		}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RecurringInfo">RecurringInfo object .</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> RecurringAddTransaction is used to add a new recurring profile 
		/// either by submitting the data that defines the profile or by converting an 
		/// existing transaction into a profile. Upon successful creation of a profile,
		/// PayPal activates the profile, performs the Optional Transaction if specified,
		/// initiates the payment cycle, and returns a Profile ID (a 12-character string that 
		/// uniquely identifies the profile for searching and reporting). Upon failure, PayPal 
		/// does not generate the profile and returns an error message.
		/// </remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	//Set the Recurring related information.
		///	RecurringInfo RecurInfo = new RecurringInfo();
		///	// The date that the first payment will be processed.
		///	// This will be of the format mmddyyyy.
		///	RecurInfo.Start = "01012009";
		///	RecurInfo.ProfileName = "PayPal";
		///	// Specifies how often the payment occurs. All PAYPERIOD values must use
		///	// capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	// QTER / SMYR / YEAR
		///	RecurInfo.PayPeriod = "WEEK";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Add Transaction.
		///	RecurringAddTransaction Trans = new RecurringAddTransaction(
		///		User, Inv, Card, RecurInfo, PayflowUtility.RequestId);
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.                                                                                    
		///	Dim RecurInfo As RecurringInfo = New RecurringInfo                                                               
		///	' The date that the first payment will be processed.                                                                  
		///	' This will be of the format mmddyyyy.                                                                                    
		///	RecurInfo.Start = "01012009"                                                                                                
		///	RecurInfo.ProfileName = "PayPal"                                                                                        
		///	' Specifies how often the payment occurs. All PAYPERIOD values must use                                 
		///	' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /                                  
		///	' QTER / SMYR / YEAR                                                                                                            
		///	RecurInfo.PayPeriod = "WEEK"                                                                                               
		///	'/////////////////////////////////////////////////////////////////                                                         
		///	                                                                                                                                           
		///	' Create a new Recurring Add Transaction.                                                                              
		///	Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Inv,   
		///						Card, RecurInfo, PayflowUtility.RequestId)                                     
		///	                                                                                                                                           
		///	' Submit the transaction.                                                                                                        
		///	Dim Resp As Response = Trans.SubmitTransaction()                                                                
		///	                                                                                                                                           
		///	If Not Resp Is Nothing Then                                                                                                    
		///	    ' Get the Transaction Response parameters.                                                                        
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse                              
		///	    If Not TrxnResponse Is Nothing Then                                                                                  
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)                                                   
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)                                            
		///	    End If                                                                                                                               
		///	                                                                                                                                           
		///	    ' Get the Recurring Response parameters.                                                                           
		///	    Dim RecurResponse As RecurringResponse = Resp.RecurringResponse                                  
		///	    If Not RecurResponse Is Nothing Then                                                                                 
		///	        Console.WriteLine("RPREF = " + RecurResponse.RPRef)                                                    
		///	        Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)                                          
		///	    End If                                                                                                                               
		///	End If                                                                                                                                   
		///	                                                                                                                                           
		///	' Get the Context and check for any contained SDK specific errors.                                            
		///	Dim Ctx As Context = Resp.TransactionContext                                                                       
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then                                                     
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())                                
		///	End If                                                                                                                                   
		///	
		///	
		///	</code>
		///	</example>
		public RecurringAddTransaction(
			UserInfo UserInfo,
			Invoice Invoice,
			BaseTender Tender,
			RecurringInfo RecurringInfo,
			String RequestId)
			: this(UserInfo, null, Invoice, Tender, RecurringInfo, RequestId)
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