using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to create and perform an 
	/// Credit Transaction.
	/// </summary>
	///	<remarks>Reference credit transaction can be performed on successful
	///	transactions in order to credit the amount. Therefore, a
	///	reference credit transaction takes the PNRef of a previous transaction.
	///	</remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	// Create a new Credit Transaction.
	///	// Following is an example of a reference credit type of transaction.
	///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
	///	' Create a new Credit Transaction.
	///	' Following is an example of a reference credit type of transaction.
	///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
	///						Connection, Inv, PayflowUtility.RequestId)
	///		' Submit the transaction.
	///	Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	If Not Resp Is Nothing Then
	///	    ' Get the Transaction Response parameters.
	///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	    If Not TrxnResponse Is Nothing Then
	///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///	    End If
	///	End If
	///
	///	' Get the Context and check for any contained SDK specific errors.
	///	Dim Ctx As Context = Resp.TransactionContext
	///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
	///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
	///	End If
	///
	///	</code>
	///	</example>


	public sealed class CreditTransaction : BaseTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Original transaction id.
		/// </summary>
		private String mOrigId;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private CreditTransaction()
		{
		}


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
		///						Connection, Inv, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, String RequestId) : base(PayflowConstants.TRXTYPE_CREDIT, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
		///						 Inv, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, String RequestId) : this(OrigId, UserInfo, null,Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
		///						Connection, Inv, Tender, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, BaseTender Tender, String RequestId) : base(PayflowConstants.TRXTYPE_CREDIT, UserInfo, PayflowConnectionData, Invoice, Tender, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
		///						 Inv, Tender, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, BaseTender Tender, String RequestId) : this(OrigId, UserInfo, null,Invoice, Tender, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.",
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User,
		///						Connection, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData,String RequestId) : base(PayflowConstants.TRXTYPE_CREDIT, UserInfo, PayflowConnectionData, null, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Reference credit transaction can be performed on successful
		///	transactions in order to credit the amount. Therefore, a
		///	reference credit transaction takes the PNRef of a previous transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a reference credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction("PNRef of a previous transaction.", PayflowUtility.RequestId);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a reference credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction("PNRef of a previous transaction.", User, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(String OrigId, UserInfo UserInfo, String RequestId) : base(PayflowConstants.TRXTYPE_CREDIT,UserInfo, RequestId)
		{
			mOrigId = OrigId;
		}


		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>This class is used for a stand alone credit transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a stand alone credit type of transaction.
		///	CreditTransaction Trans = new CreditTransaction(User, Inv, Connection,
		///							Tender, PayflowUtility.RequestId);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a stand alone credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction(User, Connection,
		///						 Inv, Tender, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(UserInfo UserInfo,
		                         PayflowConnectionData PayflowConnectionData,
		                         Invoice Invoice,
		                         BaseTender Tender,
		                         String RequestId)
			: base(PayflowConstants.TRXTYPE_CREDIT, UserInfo,
			       PayflowConnectionData,
			       Invoice,
			       Tender,
			       RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>This class is used for a stand alone credit transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Credit Transaction.
		///	// Following is an example of a stand alone type of transaction.
		///	CreditTransaction Trans = new CreditTransaction(User, Inv, 
		///							Tender, PayflowUtility.RequestId);
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
		///	' Create a new Credit Transaction.
		///	' Following is an example of a stand alone credit type of transaction.
		///	Dim Trans As CreditTransaction = New CreditTransaction(User,
		///						 Inv, Tender, PayflowUtility.RequestId)
		///		' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors.
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///	</code>
		///	</example>
		public CreditTransaction(UserInfo UserInfo,
			Invoice Invoice,
			BaseTender Tender,
			String RequestId)
			: this(UserInfo,
			null,
			Invoice,
			Tender,
			RequestId)
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