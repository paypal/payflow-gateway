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
	/// This is the base class of all different recurring action transactions.
	/// </summary> 
	/// <remarks>
	/// Each derived class of RecurringTransaction specifies a unique action
	/// transaction. This class can also be directly used to perform a recurring
	/// transaction. Alternatively, a new class can be extended from this to
	/// create a specific recurring action transaction.
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
	///	// Create a new Recurring Transaction.
	///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
	///		User, Connection, Inv, Tender, PayflowUtility.RequestId);
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
	///
	/// </code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	'Set the Recurring related information.
	///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
	///	  ' The date that the first payment will be processed.
	///	  ' This will be of the format mmddyyyy.
	///	  RecurInfo.Start = "01012009"
	///	  RecurInfo.ProfileName = "PayPal"
	///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
	///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
	///	  ' QTER / SMYR / YEAR
	///	  RecurInfo.PayPeriod = "WEEK"
	///	  '/////////////////////////////////////////////////////////////////
	///
	///	  ' Create a new Recurring Transaction.
	///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
	///	 	User, Connection, Inv, Tender, PayflowUtility.RequestId)
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
	///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
	///	  End If
	///
	///
	///	</code>
	///	</example>
	public class RecurringTransaction : PayPal.Payments.Transactions.BaseTransaction
	{
		#region "Member Variables"

		private String mAction;

		/// <summary>
		/// Holds the Recurring Info object
		/// </summary>
		private RecurringInfo mRecurringInfo;

		#endregion

		#region "Constructors"

		/// <summary>
		/// private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private RecurringTransaction()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, Connection, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData, String RequestId)
			: base(PayflowConstants.TRXTYPE_RECURRING,
			       UserInfo, PayflowConnectionData, RequestId)
		{
			if (RecurringInfo != null)
			{
				mRecurringInfo = RecurringInfo;
				mRecurringInfo.Context = base.Context;
			}
			mAction = Action;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			String RequestId)
			: base(PayflowConstants.TRXTYPE_RECURRING,
			UserInfo, RequestId)
		{
			if (RecurringInfo != null)
			{
				mRecurringInfo = RecurringInfo;
				mRecurringInfo.Context = base.Context;
			}
			mAction = Action;
		}


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice Object</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, Connection, Inv, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			Invoice Invoice, String RequestId)
			: base(PayflowConstants.TRXTYPE_RECURRING,
			       UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
			if (RecurringInfo != null)
			{
				mRecurringInfo = RecurringInfo;
				mRecurringInfo.Context = base.Context;
			}
			mAction = Action;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice Object</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
		///		User, Inv, PayflowUtility.RequestId);
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, Inv, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			Invoice Invoice, String RequestId)
			: this(Action, RecurringInfo,UserInfo, null, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender" >Tender</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
		///		User, Connection, Inv, Tender, PayflowUtility.RequestId);
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, Connection, Inv, Tender, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: base(PayflowConstants.TRXTYPE_RECURRING,
			       UserInfo, PayflowConnectionData, Invoice,
			       Tender, RequestId)
		{
			if (RecurringInfo != null)
			{
				mRecurringInfo = RecurringInfo;
				mRecurringInfo.Context = base.Context;
			}
			mAction = Action;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Action" >Action, type of recurring transaction</param>
		/// <param name="RecurringInfo">Recurring Info object.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender" >Tender</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>
		/// Each derived class of RecurringTransaction specifies a unique action
		/// transaction. This class can also be directly used to perform a recurring
		/// transaction. Alternatively, a new class can be extended from this to
		/// create a specific recurring action transaction.
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
		///	// Create a new Recurring Transaction.
		///	RecurringTransaction Trans = new RecurringTransaction("A", RecurInfo,
		///		User, Inv, Tender, PayflowUtility.RequestId);
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
		///
		/// </code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	  Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	  ' The date that the first payment will be processed.
		///	  ' This will be of the format mmddyyyy.
		///	  RecurInfo.Start = "01012009"
		///	  RecurInfo.ProfileName = "PayPal"
		///	  ' Specifies how often the payment occurs. All PAYPERIOD values must use
		///	  ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
		///	  ' QTER / SMYR / YEAR
		///	  RecurInfo.PayPeriod = "WEEK"
		///	  '/////////////////////////////////////////////////////////////////
		///
		///	  ' Create a new Recurring Transaction.
		///	  Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo,
		///	 	User, Inv, Tender, PayflowUtility.RequestId)
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
		///		Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	  End If
		///
		///
		///	</code>
		///	</example>
		public RecurringTransaction(
			String Action,
			RecurringInfo RecurringInfo,
			UserInfo UserInfo,
			Invoice Invoice,
			BaseTender Tender, String RequestId)
			: this(Action,RecurringInfo,
			UserInfo, null, Invoice,
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ACTION, mAction));
				if (mRecurringInfo != null)
				{
					mRecurringInfo.RequestBuffer = RequestBuffer;
					mRecurringInfo.GenerateRequest();
				}
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