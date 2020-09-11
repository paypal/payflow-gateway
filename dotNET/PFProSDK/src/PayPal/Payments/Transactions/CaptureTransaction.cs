#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform a capture transaction.
	/// </summary>
	///	<remarks>Capture transaction needs to be performed on a successful 
	///	authorization transaction in order to capture the amount. Therefore, a 
	///	capture transaction always takes the PNRef of a authorization transaction.
	///	</remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///	
	///	// Create a new Capture Transaction.
	///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
	///		User, Connection, PayflowUtility.RequestId);
	///	
	///	// Submit the transaction.
	///	Response Resp = Trans.SubmitTransaction();
	///	
	///	if (Resp != null)
	///	{
	///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
	///		if (TrxnResponse != null)
	///		{
	///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
	///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
	///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
	///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
	///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
	///	' Create a new Capture Transaction.
	///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", User, 
	///									Connection, PayflowUtility.RequestId)
	///
	///	' Submit the transaction.
	///	Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	If Not Resp Is Nothing Then
	///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	    If Not TrxnResponse Is Nothing Then
	///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
	///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
	///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
	public sealed class CaptureTransaction : ReferenceTransaction
	{
		#region "Member variables"
		/// <summary>
		/// Capture Complete. Y or N.
		/// </summary>
		private String mCaptureComplete;
		#endregion

		#region "Properties"
		/// <summary>
		/// Gets, Sets  CaptureComplete.
		/// </summary>
		/// <remarks>
		/// <para>UK Only: Used with Delay Capture transaction
		///  to indicate this is the last capture you intend
		///  to make. 
		///  Values are : Y (default) N
		///  If CaptureComplete is Y, any remaining amount of the
		///  original reauthorized transaction is voided.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CAPTURECOMPLETE</code>
		/// </remarks>
		public String CaptureComplete
		{
			get { return mCaptureComplete; }
			set { mCaptureComplete = value; }
		}
		#endregion
		
		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private CaptureTransaction()
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
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User, Connection, Inv, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction",
		///										 User, Connection, Inv, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, String RequestId) : base(PayflowConstants.TRXTYPE_CAPTURE, OrigId, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User, Inv, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", 
		///										User, Inv, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, String RequestId) : this(OrigId, UserInfo, null, Invoice, RequestId)
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
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User, Connection, Inv, Tender, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", User, Connection,
		///										 Inv, Tender, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, BaseTender Tender, String RequestId) : base(PayflowConstants.TRXTYPE_CAPTURE, OrigId, UserInfo, PayflowConnectionData, Invoice, Tender, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User,  Inv, Tender, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", User, 
		///									 Inv, Tender, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, UserInfo UserInfo, Invoice Invoice, BaseTender Tender, String RequestId) : this(OrigId, UserInfo, null, Invoice, Tender, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User, Connection, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", User, 
		///							Connection, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) : base(PayflowConstants.TRXTYPE_CAPTURE, OrigId, UserInfo, PayflowConnectionData, RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Capture transaction needs to be performed on a successful 
		///	authorization transaction in order to capture the amount. Therefore, a 
		///	capture transaction always takes the PNRef of a authorization transaction.
		///	</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///	
		///	// Create a new Capture Transaction.
		///	CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
		///		User, Connection, PayflowUtility.RequestId);
		///	
		///	// Submit the transaction.
		///	Response Resp = Trans.SubmitTransaction();
		///	
		///	if (Resp != null)
		///	{
		///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///		if (TrxnResponse != null)
		///		{
		///			Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
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
		///	' Create a new Capture Transaction.
		///	Dim Trans As CaptureTransaction = New CaptureTransaction("PNRef of Authorization transaction", User, 
		///									Connection, PayflowUtility.RequestId)
		///
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	        Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///	        Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	        Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///	        Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///	        Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
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
		public CaptureTransaction(String OrigId, 
			UserInfo UserInfo, 
			String RequestId) : base(PayflowConstants.TRXTYPE_CAPTURE, OrigId, UserInfo, RequestId)
		{
		}
		#endregion

		#region "Core functions"
		internal override void GenerateRequest()
		{
			try
			{
				base.GenerateRequest ();
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CAPTURECOMPLETE,mCaptureComplete));
			
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
		}

		#endregion
	}

}