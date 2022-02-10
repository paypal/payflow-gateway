#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform an inquiry transaction.
	/// </summary>
	///	<remarks>Inquiry transaction gets the status of a previously performed 
	///	transaction. Therefore, inquiry transaction always takes the PNRef of a 
	///	previous transaction.</remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	// Create a new Inquiry Transaction.
	///	InquiryTransaction Trans = new InquiryTransaction("PNRef of a previous transaction",
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
	///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
	///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
	///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
	///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
	///			Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult);
	///			Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
	///			Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef);
	///		}
	///
	///		// Get the Fraud Response parameters.
	///		FraudResponse FraudResp =  Resp.FraudResponse;
	///		if (FraudResp != null)
	///		{
	///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
	///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
	///	' Create a new Inquiry Transaction.
	///	Dim Trans As InquiryTransaction = New InquiryTransaction("PNRef of a previous transaction",
	///			User, Connection, PayflowUtility.RequestId)
	///
	///	' Submit the transaction.
	///	Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	If Not Resp Is Nothing Then
	///	    ' Get the Transaction Response parameters.
	///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	    If Not TrxnResponse Is Nothing Then
	///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
	///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
	///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
	///	        Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
	///	        Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
	///	        Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
	///	        Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef)
	///	    End If
	///
	///	    ' Get the Fraud Response parameters.
	///	    Dim FraudResp As FraudResponse = Resp.FraudResponse
	///	    If Not FraudResp Is Nothing Then
	///	        Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
	///	        Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
	public sealed class InquiryTransaction : ReferenceTransaction
	{
		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private InquiryTransaction()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Inquiry transaction gets the status of a previously performed 
		///	transaction. Therefore, inquiry transaction always takes the PNRef of a 
		///	previous transaction.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Inquiry Transaction.
		///	InquiryTransaction Trans = new InquiryTransaction("PNRef of a previous transaction",
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
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult);
		///			Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
		///			Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef);
		///		}
		///
		///		// Get the Fraud Response parameters.
		///		FraudResponse FraudResp =  Resp.FraudResponse;
		///		if (FraudResp != null)
		///		{
		///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///	' Create a new Inquiry Transaction.
		///	Dim Trans As InquiryTransaction = New InquiryTransaction("PNRef of a previous transaction",
		///			User, Connection, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///	        Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///	        Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
		///	        Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
		///	        Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef)
		///	    End If
		///
		///	    ' Get the Fraud Response parameters.
		///	    Dim FraudResp As FraudResponse = Resp.FraudResponse
		///	    If Not FraudResp Is Nothing Then
		///	        Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///	        Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public InquiryTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) : base(PayflowConstants.TRXTYPE_INQUIRY, OrigId, UserInfo, PayflowConnectionData, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Inquiry transaction gets the status of a previously performed 
		///	transaction. Therefore, inquiry transaction always takes the PNRef of a 
		///	previous transaction.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Inquiry Transaction.
		///	InquiryTransaction Trans = new InquiryTransaction("PNRef of a previous transaction",
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
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult);
		///			Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
		///			Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef);
		///		}
		///
		///		// Get the Fraud Response parameters.
		///		FraudResponse FraudResp =  Resp.FraudResponse;
		///		if (FraudResp != null)
		///		{
		///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///	' Create a new Inquiry Transaction.
		///	Dim Trans As InquiryTransaction = New InquiryTransaction("PNRef of a previous transaction",
		///			User, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///	        Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///	        Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
		///	        Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
		///	        Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef)
		///	    End If
		///
		///	    ' Get the Fraud Response parameters.
		///	    Dim FraudResp As FraudResponse = Resp.FraudResponse
		///	    If Not FraudResp Is Nothing Then
		///	        Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///	        Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public InquiryTransaction(String OrigId, UserInfo UserInfo,String RequestId) : base(PayflowConstants.TRXTYPE_INQUIRY, OrigId, UserInfo, RequestId)
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
		///	<remarks>Inquiry transaction gets the status of a previously performed 
		///	transaction. Therefore, inquiry transaction always takes the PNRef or CustRef of a 
		///	previous transaction.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Inquiry Transaction.
		///	InquiryTransaction Trans = new InquiryTransaction("PNRef of a previous transaction",
		///		User, Connection, Inv, PayflowUtility.RequestId);
		///		
		///	// To use CUSTREF instead of PNREF you need to set the CustRef and include the INVOICE object in your
		/// // request.  Since you will be using CUSTREF instead of PNREF, PNREF will be "" (null).
		/// // Create a new Invoice data object with the Amount, Billing Address etc. details.
		/// //Invoice Inv = new Invoice();
		/// //Inv.CustRef = "TEST1";
		/// //InquiryTransaction Trans = new InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId);
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
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult);
		///			Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
		///			Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef);
		///		}
		///
		///		// Get the Fraud Response parameters.
		///		FraudResponse FraudResp =  Resp.FraudResponse;
		///		if (FraudResp != null)
		///		{
		///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///	' Create a new Inquiry Transaction.
		///	Dim Trans As InquiryTransaction = New InquiryTransaction("PNRef of a previous transaction",
		///			User, Connection, Inv, PayflowUtility.RequestId)
		///			
		///	' To use CUSTREF instead of PNREF you need to set the CustRef and include the INVOICE object in your
		/// ' request.  Since you will be using CUSTREF instead of PNREF, PNREF will be "" (null).
		/// ' Create a new Invoice data object with the Amount, Billing Address etc. details.
		/// 'Dim Inv As Invoice = New Invoice
		/// 'Inv.CustRef = "TEST1"
		/// 'Dim Trans As InquiryTransaction = New InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///	        Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///	        Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
		///	        Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
		///	        Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef)
		///	    End If
		///
		///	    ' Get the Fraud Response parameters.
		///	    Dim FraudResp As FraudResponse = Resp.FraudResponse
		///	    If Not FraudResp Is Nothing Then
		///	        Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///	        Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public InquiryTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, String RequestId) : base(PayflowConstants.TRXTYPE_INQUIRY, OrigId, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Inquiry transaction gets the status of a previously performed 
		///	transaction. Therefore, inquiry transaction always takes the PNRef or CustRef of a 
		///	previous transaction.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Create a new Inquiry Transaction.
		///	InquiryTransaction Trans = new InquiryTransaction("PNRef of a previous transaction",
		///		User, Inv, PayflowUtility.RequestId);
		///		
		///	// To use CUSTREF instead of PNREF you need to set the CustRef and include the INVOICE object in your
		/// // request.  Since you will be using CUSTREF instead of PNREF, PNREF will be "" (null).
		/// // Create a new Invoice data object with the Amount, Billing Address etc. details.
		/// //Invoice Inv = new Invoice();
		/// //Inv.CustRef = "TEST1";
		/// //InquiryTransaction Trans = new InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId);
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
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult);
		///			Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState);
		///			Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef);
		///		}
		///
		///		// Get the Fraud Response parameters.
		///		FraudResponse FraudResp =  Resp.FraudResponse;
		///		if (FraudResp != null)
		///		{
		///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
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
		///	' Create a new Inquiry Transaction.
		///	Dim Trans As InquiryTransaction = New InquiryTransaction("PNRef of a previous transaction",
		///			User, Inv, PayflowUtility.RequestId)
		///			
		///	' To use CUSTREF instead of PNREF you need to set the CustRef and include the INVOICE object in your
		/// ' request.  Since you will be using CUSTREF instead of PNREF, PNREF will be "" (null).
		/// ' Create a new Invoice data object with the Amount, Billing Address etc. details.
		/// 'Dim Inv As Invoice = New Invoice
		/// 'Inv.CustRef = "TEST1"
		/// 'Dim Trans As InquiryTransaction = New InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///	        Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///	        Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
		///	        Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
		///	        Console.WriteLine("CUSTREF = " + TrxnResponse.CustRef)
		///	    End If
		///
		///	    ' Get the Fraud Response parameters.
		///	    Dim FraudResp As FraudResponse = Resp.FraudResponse
		///	    If Not FraudResp Is Nothing Then
		///	        Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///	        Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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
		public InquiryTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, String RequestId) : this(OrigId, UserInfo, null, Invoice, RequestId)
		{
		}


		#endregion
	}

}