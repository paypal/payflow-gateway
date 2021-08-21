#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform a recurring transaction with
	/// modify action.
	/// </summary>
	/// <remarks> 
	/// RecurringModifyTransaction is used to modify any profile value by 
	/// sending any subset of the profile parameters, including an Optional Transaction.
	/// The Modify action is useful, for example, when an inactive customer wishes to
	/// restart payments using a new valid credit card. The Modify action changes a
	/// profile’s STATUS to active but does not change the START date.
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
	///	RecurInfo.ProfileName = "PayPal Inc.";
	///	///////////////////////////////////////////////////////////////////
	///
	///	// Create a new Recurring Modify Transaction.
	///	RecurringModifyTransaction Trans = new RecurringModifyTransaction(
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
	///
	///	</code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	'Set the Recurring related information.
	///	Dim RecurInfo As RecurringInfo = New RecurringInfo
	///	RecurInfo.OrigProfileId = "RT0000001350"
	///	RecurInfo.ProfileName = "PayPal Inc."
	///	'/////////////////////////////////////////////////////////////////
	///
	///	' Create a new Recurring Modify Transaction.
	///	Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User,
	///						Connection, RecurInfo, PayflowUtility.RequestId)
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
	public class RecurringModifyTransaction : RecurringTransaction
	{
		#region "Constructor"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// RecurringModifyTransaction is used to modify any profile value by 
		/// sending any subset of the profile parameters, including an Optional Transaction.
		/// The Modify action is useful, for example, when an inactive customer wishes to
		/// restart payments using a new valid credit card. The Modify action changes a
		/// profile’s STATUS to active but does not change the START date.
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
		///	RecurInfo.ProfileName = "PayPal Inc.";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Modify Transaction.
		///	RecurringModifyTransaction Trans = new RecurringModifyTransaction(
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	RecurInfo.OrigProfileId = "RT0000001350"
		///	RecurInfo.ProfileName = "PayPal Inc."
		///	'/////////////////////////////////////////////////////////////////
		///
		///	' Create a new Recurring Modify Transaction.
		///	Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User,
		///						Connection, RecurInfo, PayflowUtility.RequestId)
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
		public RecurringModifyTransaction(
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			RecurringInfo RecurringInfo, String RequestId)
			: base(PayflowConstants.RECURRING_ACTION_MODIFY,
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
		/// <remarks> 
		/// RecurringModifyTransaction is used to modify any profile value by 
		/// sending any subset of the profile parameters, including an Optional Transaction.
		/// The Modify action is useful, for example, when an inactive customer wishes to
		/// restart payments using a new valid credit card. The Modify action changes a
		/// profile’s STATUS to active but does not change the START date.
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
		///	RecurInfo.ProfileName = "PayPal Inc.";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Modify Transaction.
		///	RecurringModifyTransaction Trans = new RecurringModifyTransaction(
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	RecurInfo.OrigProfileId = "RT0000001350"
		///	RecurInfo.ProfileName = "PayPal Inc."
		///	'/////////////////////////////////////////////////////////////////
		///
		///	' Create a new Recurring Modify Transaction.
		///	Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User,
		///						RecurInfo, PayflowUtility.RequestId)
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
		public RecurringModifyTransaction(
			UserInfo UserInfo,
			RecurringInfo RecurringInfo, String RequestId)
			: this(UserInfo, null, RecurringInfo, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>		
		/// <remarks> 
		/// RecurringModifyTransaction is used to modify any profile value by 
		/// sending any subset of the profile parameters, including an Optional Transaction.
		/// The Modify action is useful, for example, when an inactive customer wishes to
		/// restart payments using a new valid credit card. The Modify action changes a
		/// profile’s STATUS to active but does not change the START date.
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
		///	RecurInfo.ProfileName = "PayPal Inc.";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Modify Transaction.
		///	RecurringModifyTransaction Trans = new RecurringModifyTransaction(
		///		User, Connection, RecurInfo, Inv, Tender, PayflowUtility.RequestId);
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
		///	RecurInfo.OrigProfileId = "RT0000001350"
		///	RecurInfo.ProfileName = "PayPal Inc."
		///	'/////////////////////////////////////////////////////////////////
		///
		///	' Create a new Recurring Modify Transaction.
		///	Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User,
		///						Connection, RecurInfo, Inv, Tender, PayflowUtility.RequestId)
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
		public RecurringModifyTransaction(
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			RecurringInfo RecurringInfo,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: base(PayflowConstants.RECURRING_ACTION_MODIFY,
			       RecurringInfo,
			       UserInfo, PayflowConnectionData,
			       Invoice,
			       Tender, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>		
		/// <remarks> 
		/// RecurringModifyTransaction is used to modify any profile value by 
		/// sending any subset of the profile parameters, including an Optional Transaction.
		/// The Modify action is useful, for example, when an inactive customer wishes to
		/// restart payments using a new valid credit card. The Modify action changes a
		/// profile’s STATUS to active but does not change the START date.
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
		///	RecurInfo.ProfileName = "PayPal Inc.";
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Modify Transaction.
		///	RecurringModifyTransaction Trans = new RecurringModifyTransaction(
		///		User, RecurInfo, Inv, Tender, PayflowUtility.RequestId);
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
		///	RecurInfo.OrigProfileId = "RT0000001350"
		///	RecurInfo.ProfileName = "PayPal Inc."
		///	'/////////////////////////////////////////////////////////////////
		///
		///	' Create a new Recurring Modify Transaction.
		///	Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User,
		///						RecurInfo, Inv, Tender, PayflowUtility.RequestId)
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
		public RecurringModifyTransaction(
			UserInfo UserInfo,
			RecurringInfo RecurringInfo,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: this(UserInfo, null,RecurringInfo,
			Invoice,
			Tender, RequestId)
		{
		}

		#endregion

		
	}
}