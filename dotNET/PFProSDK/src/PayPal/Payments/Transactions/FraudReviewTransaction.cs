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
	/// This class is used to perform a fraud review transaction.
	/// </summary>
	///	<remarks>Fraud Review can be used as alternative to manually
	///	 approving transactions under fraud on PayPal manager.</remarks>
	///	<example>
	///	<code lang="C#" escaped="false">
	///	...............
	///	// Populate data objects
	///	...............
	///
	///	// Ensure that Purchase price ceiling filter is set to $50.
	///	// Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
	///	// Submit the sale transaction and get the PNRef number from this.
	///	FraudReviewTransaction Trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
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
	///		}
	///	}
	///
	///	// Get the Context and check for any contained SDK specific errors (optional code).
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
	///	' Ensure that Purchase price ceiling filter is set to $50.
	///	' Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
	///	' Submit the sale transaction and get the PNRef number from this.
	///	Dim Trans As FraudReviewTransaction = New FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
	///							User, Connection, PayflowUtility.RequestId)
	///	' Submit the transaction.
	///	Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	If Not Resp Is Nothing Then
	///	    ' Get the Transaction Response parameters.
	///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	    If Not TrxnResponse Is Nothing Then
	///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	    End If
	///	End If
	///
	///	' Get the Context and check for any contained SDK specific errors (optional code).
	///	Dim Ctx As Context = Resp.TransactionContext
	///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
	///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
	///	End If
	///
	///
	///	</code>
	///	</example>
	public sealed class FraudReviewTransaction : ReferenceTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Holds the update action. Mandatory for this transaction.
		/// </summary>
		String mUpdateAction;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		private FraudReviewTransaction()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UpdateAction">Update Action RMS_APPROVE or RMS_MERCHANT_DECLINE</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Fraud Review can be used as alternative to manually
		///	 approving transactions under fraud on PayPal manager.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Ensure that Purchase price ceiling filter is set to $50.
		///	// Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
		///	// Submit the sale transaction and get the PNRef number from this.
		///	FraudReviewTransaction Trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
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
		///		}
		///	}
		///
		///	// Get the Context and check for any contained SDK specific errors (optional code).
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
		///	' Ensure that Purchase price ceiling filter is set to $50.
		///	' Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
		///	' Submit the sale transaction and get the PNRef number from this.
		///	Dim Trans As FraudReviewTransaction = New FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
		///							User, Connection, PayflowUtility.RequestId)
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors (optional code).
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///
		///	</code>
		///	</example>
		public FraudReviewTransaction(
			String OrigId,
			String UpdateAction,
			UserInfo UserInfo,
			PayflowConnectionData PayflowConnectionData,
			String RequestId)
			: base(PayflowConstants.TRXTYPE_FRAUDAPPROVE, OrigId, UserInfo, PayflowConnectionData, RequestId)
		{
			mUpdateAction = UpdateAction;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="OrigId">Original Transaction Id</param>
		/// <param name="UpdateAction">Update Action RMS_APPROVE or RMS_MERCHANT_DECLINE</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		///	<remarks>Fraud Review can be used as alternative to manually
		///	 approving transactions under fraud on PayPal manager.</remarks>
		///	<example>
		///	<code lang="C#" escaped="false">
		///	...............
		///	// Populate data objects
		///	...............
		///
		///	// Ensure that Purchase price ceiling filter is set to $50.
		///	// Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
		///	// Submit the sale transaction and get the PNRef number from this.
		///	FraudReviewTransaction Trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
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
		///		}
		///	}
		///
		///	// Get the Context and check for any contained SDK specific errors (optional code).
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
		///	' Ensure that Purchase price ceiling filter is set to $50.
		///	' Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
		///	' Submit the sale transaction and get the PNRef number from this.
		///	Dim Trans As FraudReviewTransaction = New FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
		///							User, PayflowUtility.RequestId)
		///	' Submit the transaction.
		///	Dim Resp As Response = Trans.SubmitTransaction()
		///
		///	If Not Resp Is Nothing Then
		///	    ' Get the Transaction Response parameters.
		///	    Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///	    If Not TrxnResponse Is Nothing Then
		///	        Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///	    End If
		///	End If
		///
		///	' Get the Context and check for any contained SDK specific errors (optional code).
		///	Dim Ctx As Context = Resp.TransactionContext
		///	If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///	    Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString())
		///	End If
		///
		///
		///	</code>
		///	</example>
		public FraudReviewTransaction(
			String OrigId,
			String UpdateAction,
			UserInfo UserInfo,
			String RequestId)
			: this(OrigId, UpdateAction, UserInfo, null, RequestId)
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
				//Add UPDATEACTION
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_UPDATEACTION, mUpdateAction));
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