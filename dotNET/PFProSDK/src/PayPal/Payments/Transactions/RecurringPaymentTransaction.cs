#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used to perform a recurring transaction with
	/// payment action.
	/// </summary>
	/// <remarks> 
	/// RecurringPaymentTransaction action performs a real-time retry on
	/// a transaction that is in the retry state. The response string is similar 
	/// to the string for Optional transactions, except that, upon approval, 
	/// the profile is updated to reflect the successful retry.
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
	///	RecurInfo.PaymentNum = "01012009";
	///
	///	// Create a new Invoice data object with the Amount, Billing Address etc. details.
	///	Invoice Inv = new Invoice();
	///
	///	// Set Amount.
	///	Currency Amt = new Currency(new decimal(25.12));
	///	Inv.Amt = Amt;
	///	Inv.PoNum = "PO12345";
	///	Inv.InvNum = "INV12345";
	///
	///	// Set the Billing Address details.
	///	BillTo Bill = new BillTo();
	///	Bill.BillToStreet = "123 Main St.";
	///	Bill.BillToZip = "12345";
	///	Inv.BillTo = Bill;
	///	///////////////////////////////////////////////////////////////////
	///
	///	// Create a new Recurring Payment Transaction.
	///	RecurringPaymentTransaction Trans = new RecurringPaymentTransaction(
	///		User, Connection, RecurInfo, Inv, PayflowUtility.RequestId);
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
	///
	///	</code>
	///	<code lang="Visual Basic" escaped="false">
	///	...............
	///	' Populate data objects
	///	...............
	///	'Set the Recurring related information.
	///	 Dim RecurInfo As RecurringInfo = New RecurringInfo
	///	 RecurInfo.OrigProfileId = "RT0000001350"
	///	 RecurInfo.PaymentNum = "01012009"
	///
	///	 ' Create a new Invoice data object with the Amount, Billing Address etc. details.
	///	 Dim Inv As Invoice = New Invoice
	///
	///	 ' Set Amount.
	///	 Dim Amt As Currency = New Currency(New Decimal(25.12))
	///	 Inv.Amt = Amt
	///	 Inv.PoNum = "PO12345"
	///	 Inv.InvNum = "INV12345"
	///
	///	 ' Set the Billing Address details.
	///	 Dim Bill As BillTo = New BillTo
	///	 Bill.BillToStreet = "123 Main St."
	///	 Bill.BillToZip = "12345"
	///	 Inv.BillTo = Bill
	///	 '/////////////////////////////////////////////////////////////////
	///
	///	 ' Create a new Recurring Payment Transaction.
	///	 Dim Trans As RecurringPaymentTransaction = New RecurringPaymentTransaction(User,
	///	 	Connection, RecurInfo, Inv, PayflowUtility.RequestId)
	///
	///	 ' Submit the transaction.
	///	 Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	 If Not Resp Is Nothing Then
	///	     ' Get the Transaction Response parameters.
	///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	     If Not TrxnResponse Is Nothing Then
	///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///	     End If
	///
	///	     ' Get the Recurring Response parameters.
	///	     Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
	///	     If Not RecurResponse Is Nothing Then
	///	         Console.WriteLine("RPREF = " + RecurResponse.RPRef)
	///	         Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
	///	     End If
	///	 End If
	///
	///	 ' Get the Context and check for any contained SDK specific errors.
	///	 Dim Ctx As Context = Resp.TransactionContext
	///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
	///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
	///	 End If
	///
	///
	///	</code>
	///	</example>
	public class RecurringPaymentTransaction : RecurringTransaction
	{
		#region "Constructor"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// RecurringPaymentTransaction action performs a real-time retry on
		/// a transaction that is in the retry state. The response string is similar 
		/// to the string for Optional transactions, except that, upon approval, 
		/// the profile is updated to reflect the successful retry.
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
		///	RecurInfo.PaymentNum = "01012009";
		///
		///	// Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	Invoice Inv = new Invoice();
		///
		///	// Set Amount.
		///	Currency Amt = new Currency(new decimal(25.12));
		///	Inv.Amt = Amt;
		///	Inv.PoNum = "PO12345";
		///	Inv.InvNum = "INV12345";
		///
		///	// Set the Billing Address details.
		///	BillTo Bill = new BillTo();
		///	Bill.BillToStreet = "123 Main St.";
		///	Bill.BillToZip = "12345";
		///	Inv.BillTo = Bill;
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Payment Transaction.
		///	RecurringPaymentTransaction Trans = new RecurringPaymentTransaction(
		///		User, Connection, RecurInfo, Inv, PayflowUtility.RequestId);
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	 Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	 RecurInfo.OrigProfileId = "RT0000001350"
		///	 RecurInfo.PaymentNum = "01012009"
		///
		///	 ' Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	 Dim Inv As Invoice = New Invoice
		///
		///	 ' Set Amount.
		///	 Dim Amt As Currency = New Currency(New Decimal(25.12))
		///	 Inv.Amt = Amt
		///	 Inv.PoNum = "PO12345"
		///	 Inv.InvNum = "INV12345"
		///
		///	 ' Set the Billing Address details.
		///	 Dim Bill As BillTo = New BillTo
		///	 Bill.BillToStreet = "123 Main St."
		///	 Bill.BillToZip = "12345"
		///	 Inv.BillTo = Bill
		///	 '/////////////////////////////////////////////////////////////////
		///
		///	 ' Create a new Recurring Payment Transaction.
		///	 Dim Trans As RecurringPaymentTransaction = New RecurringPaymentTransaction(User,
		///	 	Connection, RecurInfo, Inv, PayflowUtility.RequestId)
		///
		///	 ' Submit the transaction.
		///	 Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	 If Not Resp Is Nothing Then
		///	     ' Get the Transaction Response parameters.
		///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	     If Not TrxnResponse Is Nothing Then
		///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	     End If
		///
		///	     ' Get the Recurring Response parameters.
		///	     Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
		///	     If Not RecurResponse Is Nothing Then
		///	         Console.WriteLine("RPREF = " + RecurResponse.RPRef)
		///	         Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
		///	     End If
		///	 End If
		///
		///	 ' Get the Context and check for any contained SDK specific errors.
		///	 Dim Ctx As Context = Resp.TransactionContext
		///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	 End If
		///
		///
		///	</code>
		///	</example>
		public RecurringPaymentTransaction(
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			RecurringInfo RecurringInfo,
			Invoice Invoice, String RequestId)
			: base(PayflowConstants.RECURRING_ACTION_PAYMENT,
			       RecurringInfo,
			       UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RecurringInfo">RecurringInfo object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks> 
		/// RecurringPaymentTransaction action performs a real-time retry on
		/// a transaction that is in the retry state. The response string is similar 
		/// to the string for Optional transactions, except that, upon approval, 
		/// the profile is updated to reflect the successful retry.
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
		///	RecurInfo.PaymentNum = "01012009";
		///
		///	// Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	Invoice Inv = new Invoice();
		///
		///	// Set Amount.
		///	Currency Amt = new Currency(new decimal(25.12));
		///	Inv.Amt = Amt;
		///	Inv.PoNum = "PO12345";
		///	Inv.InvNum = "INV12345";
		///
		///	// Set the Billing Address details.
		///	BillTo Bill = new BillTo();
		///	Bill.BillToStreet = "123 Main St.";
		///	Bill.BillToZip = "12345";
		///	Inv.BillTo = Bill;
		///	///////////////////////////////////////////////////////////////////
		///
		///	// Create a new Recurring Payment Transaction.
		///	RecurringPaymentTransaction Trans = new RecurringPaymentTransaction(
		///		User, RecurInfo, Inv, PayflowUtility.RequestId);
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
		///
		///	</code>
		///	<code lang="Visual Basic" escaped="false">
		///	...............
		///	' Populate data objects
		///	...............
		///	'Set the Recurring related information.
		///	 Dim RecurInfo As RecurringInfo = New RecurringInfo
		///	 RecurInfo.OrigProfileId = "RT0000001350"
		///	 RecurInfo.PaymentNum = "01012009"
		///
		///	 ' Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	 Dim Inv As Invoice = New Invoice
		///
		///	 ' Set Amount.
		///	 Dim Amt As Currency = New Currency(New Decimal(25.12))
		///	 Inv.Amt = Amt
		///	 Inv.PoNum = "PO12345"
		///	 Inv.InvNum = "INV12345"
		///
		///	 ' Set the Billing Address details.
		///	 Dim Bill As BillTo = New BillTo
		///	 Bill.BillToStreet = "123 Main St."
		///	 Bill.BillToZip = "12345"
		///	 Inv.BillTo = Bill
		///	 '/////////////////////////////////////////////////////////////////
		///
		///	 ' Create a new Recurring Payment Transaction.
		///	 Dim Trans As RecurringPaymentTransaction = New RecurringPaymentTransaction(User,
		///	 	RecurInfo, Inv, PayflowUtility.RequestId)
		///
		///	 ' Submit the transaction.
		///	 Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	 If Not Resp Is Nothing Then
		///	     ' Get the Transaction Response parameters.
		///	     Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	     If Not TrxnResponse Is Nothing Then
		///	         Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	         Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///	     End If
		///
		///	     ' Get the Recurring Response parameters.
		///	     Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
		///	     If Not RecurResponse Is Nothing Then
		///	         Console.WriteLine("RPREF = " + RecurResponse.RPRef)
		///	         Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
		///	     End If
		///	 End If
		///
		///	 ' Get the Context and check for any contained SDK specific errors.
		///	 Dim Ctx As Context = Resp.TransactionContext
		///	 If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	     Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	 End If
		///
		///
		///	</code>
		///	</example>
		public RecurringPaymentTransaction(
			UserInfo UserInfo,
			RecurringInfo RecurringInfo,
			Invoice Invoice, String RequestId)
			: this(UserInfo, null, RecurringInfo,Invoice, RequestId)
		{
		}

		#endregion

		
	}
}