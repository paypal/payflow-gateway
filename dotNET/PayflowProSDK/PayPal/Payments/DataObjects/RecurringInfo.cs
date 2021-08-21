#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for recurring transaction related information
	/// </summary>
	/// <remarks>RecurringInfo contains the required and optional parameters 
	/// specific to all the recurring transactions.</remarks>
	/// <example>Following examples shows how to use the 
	/// RecurringInfo.
	/// <code lang="C#" escaped="false">
	///	............................
	///	//Populate other data objects.
	///	............................
	///	
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
	///	Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
	///	Console.ReadLine();
	///	}
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	............................
	///	'Populate other data objects.
	///	............................
	///	
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
	///	Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId)
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
	/// </code>
	/// </example>
	public sealed class RecurringInfo : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Profile name
		/// </summary>
		private String mProfileName;

		/// <summary>
		/// Start Date
		/// </summary>
		private String mStart;

		/// <summary>
		/// Payment Term
		/// </summary>
		private long mTerm = PayflowConstants.INVALID_NUMBER;

		/// <summary>
		/// Payment Period
		/// </summary>
		private String mPayPeriod;

		/// <summary>
		/// Optional transaction type
		/// </summary>
		private String mOptionalTrx;

		/// <summary>
		/// Optional transaction amount
		/// </summary>
		private Currency mOptionalTrxAmt;

		/// <summary>
		/// Retry number of days
		/// </summary>
		private long mRetryNumDays;

		/// <summary>
		/// Max failed payments
		/// </summary>
		private long mMaxFailPayments = PayflowConstants.INVALID_NUMBER;

		/// <summary>
		/// Profile id of the original profile.
		/// </summary>
		private String mOrigProfileId;

		/// <summary>
		/// Payment history
		/// </summary>
		private String mPaymentHistory;

		/// <summary>
		/// Payment number
		/// </summary>
		private String mPaymentNum;

        /// <summary>
        /// Frequency
        /// </summary>
        private String mFrequency;

        //private String mRecurring = "Y";

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor for RecurringInfo
        /// </summary>
        /// <remarks>RecurringInfo contains the required and optional parameters 
        /// specific to all the recurring transactions.</remarks>
        /// <example>Following examples shows how to use the 
        /// RecurringInfo.
        /// <code lang="C#" escaped="false">
        ///	............................
        ///	//Populate other data objects.
        ///	............................
        ///	
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
        ///	Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
        ///	Console.ReadLine();
        ///	}
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        ///	............................
        ///	'Populate other data objects.
        ///	............................
        ///	
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
        ///	Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId)
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
        /// </code>
        /// </example>
        public RecurringInfo()
		{
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets ProfileName 
		/// </summary>
		/// <remarks>
		/// Name for the profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROFILENAME</code>
		/// </remarks>
		public String ProfileName
		{
			get { return mProfileName; }
			set { mProfileName = value; }
		}

		/// <summary>
		/// Gets, Sets Start
		/// </summary>
		/// <remarks>
		/// Beginning date for the recurring billing cycle.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>START</code>
		/// </remarks>
		public String Start
		{
			get { return mStart; }
			set { mStart = value; }
		}

		/// <summary>
		/// Gets, Sets Term
		/// </summary>
		/// <remarks>
		/// Number of payments to be made over the life of the agreement.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TERM</code>
		/// </remarks>
		public long Term
		{
			get { return mTerm; }
			set { mTerm = value; }
		}

		/// <summary>
		/// Gets, Sets PayPeriod
		/// </summary>
		/// <remarks>
		/// Specifies how often the payment occurs.
		/// <para>Allowed PayPeriods are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item><term>WEEK</term><description>Weekly - Every week on the same day of the week as the first payment.</description></item>
		/// <item><term>BIWK</term><description>Every Two Weeks - Every other week on the same day of the week as the first payment.</description></item>
		/// <item><term>SMMO</term><description>Twice Every Month - The 1st and 15th of the month.Results in 24 payments per year. SMMO can start on 1st to 15th of the month, second payment 15 days later or on the last day of the month.</description></item>
		/// <item><term>FRWK</term><description>Every Four Weeks - Every 28 days from the previous payment date beginning with the first payment date. Results in 13 payments per year.</description></item>
		/// <item><term>MONT</term><description>Monthly - Every month on the same date as the first payment. Results in 12 payments per year.</description></item>
		/// <item><term>QTER</term><description>Quarterly - Every three months on the same date as the first payment.</description></item>
		/// <item><term>SMYR</term><description>Twice Every Year - Every six months on the same date as the first payment.</description></item>
		/// <item><term>YEAR</term><description>Yearly - Every twelve months on the same date as the first payment.</description></item>
		///</list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYPERIOD</code>
		/// </remarks>
		public String PayPeriod
		{
			get { return mPayPeriod; }
			set { mPayPeriod = value; }
		}

		/// <summary>
		/// Gets, Sets OptionalTrx
		/// </summary>
		/// <remarks>
		/// Defines an optional Authorization for validating the account
		/// information or for charging an initial fee. If this transaction
		/// fails, then the profile is not generated.
		/// <para> A represents an optional Authorization transaction ($1 by
		/// default). OPTIONALTRX=A only applies to credit card transactions.</para>
		/// <para>S represents an initial fee.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>OPTIONALTRX</code>
		/// </remarks>
		public String OptionalTrx
		{
			get { return mOptionalTrx; }
			set { mOptionalTrx = value; }
		}

		/// <summary>
		/// Gets, Sets OptionalTrxAmt
		/// </summary>
		/// <remarks>
		/// Amount of the Optional Transaction. Required only when OPTIONALTRX=S.
		/// Optional when OPTIONALTRX=A ($1 Authorization by default)
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>OPTIONALTRXAMT</code>
		/// </remarks>
		public Currency OptionalTrxAmt
		{
			get { return mOptionalTrxAmt; }
			set { mOptionalTrxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets RetryNumDays
		/// </summary>
		/// <remarks>
		/// The number of consecutive days that Gateway should
		/// attempt to process a failed transaction until Approved
		/// status is received.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RETRYNUMDAYS</code>
		/// </remarks>
		public long RetryNumDays
		{
			get { return mRetryNumDays; }
			set { mRetryNumDays = value; }
		}

		/// <summary>
		/// Gets, Sets MaxFailPayments
		/// </summary>
		/// <remarks>
		/// The number of payment periods (specified by
		/// PAYPERIOD) for which the transaction is allowed to fail
		/// before PayPal cancels a profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MAXFAILPAYMENTS</code>
		/// </remarks>
		public long MaxFailPayments
		{
			get { return mMaxFailPayments; }
			set { mMaxFailPayments = value; }
		}

		/// <summary>
		/// Gets, Sets OrigProfileId
		/// </summary>
		/// <remarks>Required for Modify/Cancel/Inquiry/Retry action.
		/// Profile IDs for test profiles start with RT.
		/// Profile IDs for live profiles start with RP.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORIGPROFILEID</code>
		/// </remarks>
		public String OrigProfileId
		{
			get { return mOrigProfileId; }
			set { mOrigProfileId = value; }
		}

		/// <summary>
		/// Gets, Sets PaymentHistory
		/// </summary>
		/// <remarks>Used for recurring inquiry.
		/// <para>Allowed values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item><term>Y</term><description>To view the full set of payment information for a profile, include the name/value pair with the Inquiry action.</description></item>
		/// <item><term>N</term><description>To view the status of a customer’s profile, submit an Inquiry action that does not include the PAYMENTHISTORY parameter (alternatively, submit PAYMENTHISTORY=N).</description></item>
		///</list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTHISTORY</code>
		/// </remarks>
		public String PaymentHistory
		{
			get { return mPaymentHistory; }
			set { mPaymentHistory = value; }
		}

		/// <summary>
		/// Gets, Sets PaymentNum
		/// </summary>
		/// <remarks>
		/// Payment number identifying the failed payment to be retried.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTNUM</code>
		///</remarks>
		public String PaymentNum
		{
			get { return mPaymentNum; }
			set { mPaymentNum = value; }
		}

        /// <summary>
        /// Gets, Sets Frequency
        /// </summary>
        /// <remarks>
        /// Set the number of days between payments.  Used with PAYPERIOD=DAYS.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>FREQUENCY</code>
        ///</remarks>
        public String Frequency
        {
            get { return mFrequency; }
            set { mFrequency = value; }
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PROFILENAME, mProfileName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_START, mStart));

				if (mTerm != PayflowConstants.INVALID_NUMBER)
				{
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TERM, mTerm));
				}

				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYPERIOD, mPayPeriod));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_OPTIONALTRX, mOptionalTrx));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_OPTIONALTRXAMT, mOptionalTrxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_RETRYNUMDAYS, mRetryNumDays));
				if (mMaxFailPayments != PayflowConstants.INVALID_NUMBER)
				{
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MAXFAILPAYMENTS, mMaxFailPayments));
				}
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORIGPROFILEID, mOrigProfileId));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYMENTHISTORY, mPaymentHistory));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYMENTNUM, mPaymentNum));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_FREQUENCY, mFrequency));
				//RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_RECURRING, mRecurring));
			}              
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}

		#endregion
	}
}