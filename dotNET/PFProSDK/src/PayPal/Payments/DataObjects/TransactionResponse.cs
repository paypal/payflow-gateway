#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using System.Collections;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for transaction response.
	/// </summary>
	/// <remarks>
	/// TransactionResponse object is contained in the main response 
	/// object Response of the transaction.	
	/// </remarks>
	/// <example>
	/// Following is the example of how to get the transaction response
	/// after the transaction.
	/// <code lang="C#" escaped="false">
	///  ...................
	///  //Trans is the transaction object.
	///  ...................
	/// 
	/// // Submit the transaction.
	///	Response Resp = Trans.SubmitTransaction();
	///			
	///	if (Resp != null)
	/// {
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
	///		}
	///	}
	///	 ................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	.........................
	///	' Trans is the transaction object.
	///	.........................
	///
	///	' Submit the transaction.
	///	Dim Resp As Response = Trans.SubmitTransaction()
	///	
	///	If Not Resp Is Nothing Then
	///		' Get the Transaction Response parameters.
	///		Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	
	///		If Not TrxnResponse Is Nothing Then
	///			Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///			Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///			Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///			Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
	///			Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
	///			Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
	///			Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
	///		End If
	///	End If
	///
	///	.........................
	/// </code>
	/// </example>
	public sealed class TransactionResponse : BaseResponseDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Result
		/// </summary>
		private int mResult;

		/// <summary>
		/// Pnref
		/// </summary>
		private String mPnref;

		/// <summary>
		/// Resp msg
		/// </summary>
		private String mRespMsg;

		/// <summary>
		/// Authcode
		/// </summary>
		private String mAuthCode;

		/// <summary>
		/// Avs Addr
		/// </summary>
		private String mAvsAddr;

		/// <summary>
		/// Avs zip
		/// </summary>
		private String mAvsZip;

		/// <summary>
		/// Card Secure
		/// </summary>
		private String mCardSecure;

		/// <summary>
		/// Cvv2 match
		/// </summary>
		private String mCVV2Match;

		/// <summary>
		/// Iavs
		/// </summary>
		private String mIavs;		

		/// <summary>
		/// Inquiry OrigResult
		/// </summary>
		private String mOrigResult;

		//Expose OrigPnref param 28-12-2005
		/// <summary>
		/// Inquiry OrigPnref
		/// </summary>
		private String mOrigPnref;
		/// <summary>
		/// Inquiry Trans state
		/// </summary>
		private String mTransState;

		/// <summary>
		/// Inquiry cust ref
		/// </summary>
		private String mCustRef;

		/// <summary>
		/// Inquiry start time
		/// </summary>
		private String mStartTime;

		/// <summary>
		/// Inquiry end time
		/// </summary>
		private String mEndTime;

		/// <summary>
		/// Duplicate
		/// </summary>
		private String mDuplicate;

		/// <summary>
		/// Inquiry Date to settle
		/// </summary>
		private String mDateToSettle;

		/// <summary>
		/// Inquiry Batch Id
		/// </summary>
		private String mBatchId;

		/// <summary>
		/// Holds AddlMsgs
		/// </summary>
		private String mAddlMsgs;

		/// <summary>
		/// Holds RespText
		/// </summary>
		private String mRespText;

		/// <summary>
		/// Holds ProcAvs
		/// </summary>
		private String mProcAvs;

		/// <summary>
		/// Holds ProcCardSecure
		/// </summary>
		private String mProcCardSecure;

		/// <summary>
		/// Holds ProcCvv2
		/// </summary>
		private String mProcCVV2;

		/// <summary>
		/// Holds HostCode
		/// </summary>
		private String mHostCode;
		//Added a SETTLE_DATE param is also available when VERBOSITY= MEDIUM
		//2005-12-10
		/// <summary>
		/// Inquiry SettleDate
		/// </summary>
		private String mSettleDate;
		/// <summary>
		/// PPref
		/// </summary>
		private String mPPRef;
		/// <summary>
		/// Holds the CorrelationId
		/// </summary>
		private String mCorrelationId;
		/// <summary>
		/// Holds FeeAmt
		/// </summary>
		private String mFeeAmt;
		/// <summary>
		/// Pending reason
		/// </summary>
		private String mPendingReason;
		/// <summary>
		/// Payment Type
		/// </summary>
		private String mPaymentType;
		// Added STATUS param is also available when VERBOSITY = MEDIUM
		/// <summary>
		/// Inquiry Status
		/// </summary>
		private String mStatus;
		// Added BALAMT param, AMEX CAPN 05/31/07
		/// <summary>
		/// BalAmt
		/// </summary>
		private String mBalAmt;
		// Added AMEXID param, AMEX CAPN 05/31/07 VERBOSITY = MEDIUM
		/// <summary>
		/// AmexID
		/// </summary>
		private String mAmexID;
		// Added AMEXPOSDATA param, AMEX CAPN 11/07/07 VERBOSITY = MEDIUM
		/// <summary>
		/// AmexPosData
		/// </summary>
		private String mAmexPosData;
		/// <summary>
		/// TransTime
		/// </summary>
		private String mTransTime;
		/// <summary>
		/// CardType
		/// </summary>
		private String mCardType;
		/// <summary>
		/// OrigAmt
		/// </summary>
		private String mOrigAmt;
		/// <summary>
		/// Acct
		/// </summary>
		private String mAcct;
		/// <summary>
		/// LastName
		/// </summary>
		private String mLastName;
		/// <summary>
		/// FirstName
		/// </summary>
		private String mFirstName;
		/// <summary>
		/// Amt
		/// </summary>
		private String mAmt;
		/// <summary>
		/// EmailMatch
		/// </summary>
		private String mEmailMatch;
		/// <summary>
		/// PhoneMatch
		/// </summary>
		private String mPhoneMatch;
		/// <summary>
		/// ExpDate
		/// </summary>
		private String mExpDate;
		/// <summary>
		/// ExtRspMsg
		/// </summary>
		private String mExtRspMsg;
		/// <summary>
		/// SecureToken
		/// </summary>
		private String mSecureToken;
		/// <summary>
		/// SecureTokenId
		/// </summary>
		private String mSecureTokenId;
        /// <summary>
        /// MagTResponse
        /// </summary>
        private String mMagTResponse;
        /// <summary>
        /// TraceId
        /// </summary>
        private String mTraceId;
        /// <summary>
        /// AchStatus
        /// </summary>
        private String mAchStatus;
        /// <summary>
        /// TxId
        /// </summary>
        private String mTxId;
        /// <summary>
        /// PaymentAdviceCode
        /// </summary>
        private String mPaymentAdviceCode;
        /// <summary>
        /// AssociationResponseCode
        /// </summary>
        private String mAssociationResponseCode;
        /// <summary>
        /// Type
        /// </summary>
        private String mType;
        /// <summary>
        /// Affluent
        /// </summary>
        private String mAffluent;
        /// <summary>
        /// CCUpdated
        /// </summary>
        private String mCCUpdated;
		/// <summary>
        /// Rrn
        /// </summary>
        private String mRrn;
		/// <summary>
        /// Stan
        /// </summary>
        private String mStan;
		/// <summary>
		/// Aci
		/// </summary>
		private String mAci;
        /// <summary>
        /// ValidationCode
        /// </summary>
        private String mValidationCode;
        /// <summary>
        /// CCTransId
        /// </summary>
        private String mCCTransId;
		/// <summary>
		/// CCTrans_POSData
		/// </summary>
		private String mCCTrans_POSData;
		/// <summary>
		/// ParId
		/// </summary>
		private String mParId;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets Result
		/// </summary>
		/// <remarks>
		/// The outcome of the attempted transaction. A
		/// result of 0 (zero) indicates the transaction was
		/// approved. Any other number indicates a
		/// decline or error.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RESULT</code>
		/// </remarks>
		public int Result
		{
			get { return mResult; }
		}

        /// <summary>
        /// Gets Pnref
        /// </summary>
        /// <remarks>
        /// PayPal Reference ID, a unique number that
        /// identifies the transaction.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>PNREF</code>
        /// </remarks>
        public String Pnref
		{
			get { return mPnref; }
		}

		/// <summary>
		/// Gets RespMsg
		/// </summary>
		/// <remarks>
		/// <para>
		/// The response message returned with the
		/// transaction result. Exact wording varies.
		///	Sometimes a colon appears after the initial
		///	RESPMSG followed by more detailed
		/// information.
		/// </para>
		/// <code>APPROVED</code>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RESPMSG</code>
		/// </remarks>
		public String RespMsg
		{
			get { return mRespMsg; }
		}

		/// <summary>
		/// Gets AuthCode
		/// </summary>
		/// <remarks>
		/// Returned for Sale, Authorization, and Voice
		/// Authorization transactions. AUTHCODE is the
		///	approval code obtained over the phone from
		///	the processing network.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AUTHCODE</code>
		/// </remarks>
		public String AuthCode
		{
			get { return mAuthCode; }
		}

		/// <summary>
		/// Gets AVSAddr
		/// </summary>
		/// <remarks>
		/// AVS address responses are for advice only.
		/// This process does not affect the outcome of the
		///	authorization.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AVSADDR</code>
		/// </remarks>
		public String AVSAddr
		{
			get { return mAvsAddr; }
		}

		/// <summary>
		/// Gets AVSZip
		/// </summary>
		/// <remarks>
		/// AVS ZIP code responses are for advice only.
		/// This process does not affect the outcome of the
		///	authorization.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AVSZIP</code>
		/// </remarks>
		public String AVSZip
		{
			get { return mAvsZip; }
		}

		/// <summary>
		/// Gets CardSecure
		/// </summary>
		/// <remarks>
		/// Obtained for Visa cards.
		/// CAVV validity.
		/// Y=valid, N=Not valid, X=cannot determine
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CARDSECURE</code>
		/// </remarks>
		public String CardSecure
		{
			get { return mCardSecure; }
		}

		/// <summary>
		/// Gets CVV2Match
		/// </summary>
		/// <remarks>
		/// Result of the card security code (CVV2) check.
		///	This value does not affect the outcome of the
		///	transaction.
		///	<list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>Y</term>
		/// <description>The submitted value matches the data on file for the card.</description>
		/// </item>
		/// <item>
		/// <term>N</term>
		/// <description>The submitted value does not match the data on file for the card.</description>
		/// </item>
		/// <item>
		/// <term>X</term>
		/// <description>The cardholder’s bank does not support this service.</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CVV2MATCH</code>
		/// </remarks>
		public String CVV2Match
		{
			get { return mCVV2Match; }
			//set { mCVV2Match = value; }
		}

		/// <summary>
		/// Gets EMailMatch
		/// </summary>
		/// <remarks>
		/// Result of the e-mail check.
		///	This value does not affect the outcome of the
		///	transaction.
		///	<list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>Y</term>
		/// <description>The submitted value matches the data on file for the card holder.</description>
		/// </item>
		/// <item>
		/// <term>N</term>
		/// <description>The submitted value does not match the data on file for the card holder.</description>
		/// </item>
		/// <item>
		/// <term>X</term>
		/// <description>The cardholder’s bank does not support this service.</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EMAILMATCH</code>
		/// </remarks>
		public String EmailMatch
		{
			get { return mEmailMatch; }
			//set { mCVV2Match = value; }
		}

		/// <summary>
		/// Gets PhoneMatch
		/// </summary>
		/// <remarks>
		/// Result of the phone check.
		///	This value does not affect the outcome of the
		///	transaction.
		///	<list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>Y</term>
		/// <description>The submitted value matches the data on file for the card holder.</description>
		/// </item>
		/// <item>
		/// <term>N</term>
		/// <description>The submitted value does not match the data on file for the card holder.</description>
		/// </item>
		/// <item>
		/// <term>X</term>
		/// <description>The cardholder’s bank does not support this service.</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PHONEMATCH</code>
		/// </remarks>
		public String PhoneMatch
		{
			get { return mPhoneMatch; }
			//set { mCVV2Match = value; }
		}

		/// <summary>
		/// Gets IAVS
		/// </summary>
		/// <remarks>
		/// International AVS address responses are for
		/// advice only. This value does not affect the
		/// outcome of the transaction.
		/// Indicates whether AVS response is
		/// international (Y), US (N), or cannot be
		///	determined (X).
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>IAVS</code>
		/// </remarks>
		public String IAVS
		{
			get { return mIavs; }
		}

		

		/// <summary>
		/// Gets inquiry OrigResult
		/// </summary>
		/// <remarks>
		/// Gets the Original transaction result for which
		/// inquiry transaction is performed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORIGRESULT</code>
		/// </remarks>
		public String OrigResult
		{
			get { return mOrigResult; }
		}

		//Expose OrigPnref param 28-12-2005
		/// <summary>
		/// Gets inquiry OrigPnref
		/// </summary>
		/// <remarks>
		/// Gets the Original PNREF for which
		/// inquiry transaction is performed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORIGPNREF</code>
		/// </remarks>
		public String OrigPnref
		{
			get { return mOrigPnref; }
		}

		/// <summary>
		/// Gets inquiry TransState
		/// </summary>
		/// <remarks>
		/// Gets the Transaction state of the transaction for 
		/// which inquiry transaction is performed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TRANSSTATE</code>
		/// </remarks>
		public String TransState
		{
			get { return mTransState; }
		}

		/// <summary>
		/// Gets inquiry Custref
		/// </summary>
		/// <remarks>
		/// Merchant-defined identifier for reporting and
		/// auditing purposes. For example, you can set
		/// CUSTREF to the invoice number.
		/// You can use CUSTREF when performing Inquiry
		/// transactions. To ensure that you can always
		///  access the correct transaction when performing
		///  an Inquiry, you must provide a unique CUSTREF																																						   when submitting any transaction, including retries.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CUSTREF</code>
		/// </remarks>
		public String CustRef
		{
			get { return mCustRef; }
		}

		/// <summary>
		/// Gets inquiry StartTime
		/// </summary>
		/// <remarks>
		/// Gets the Start time of the transaction for 
		/// which inquiry transaction is performed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STARTTIME</code>
		/// </remarks>
		public String StartTime
		{
			get { return mStartTime; }
		}

		/// <summary>
		/// Gets inquiry EndTime
		/// </summary>
		/// <remarks>
		/// Gets the End time of the transaction for 
		/// which inquiry transaction is performed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ENDTIME</code>
		/// </remarks>
		public String EndTime
		{
			get { return mEndTime; }
		}

		/// <summary>
		/// Gets Duplicate
		/// </summary>
		/// <remarks>
		/// Indicates transactions sent with duplicate identifier.
		/// If a transaction is performed with the request id that has
		/// been previously used for another transaction, Duplicate is 
		/// returned as 1.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DUPLICATE</code>
		/// </remarks>
		public String Duplicate
		{
			get { return mDuplicate; }
		}

		/// <summary>
		/// Gets inquiry DateToSettle
		/// </summary>
		/// <remarks>
		/// Gets the settle date of the transaction for which 
		/// inquiry transaction is performed.
		/// Value available only before settlement has started
		/// Value obtained when Payflow Verbosity paramter = MEDIUM 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DATE_TO_SETTLE</code>
		/// </remarks>
		public String DateToSettle
		{
			get { return mDateToSettle; }
		}

		/// <summary>
		/// Gets inquiry BatchId
		/// </summary>
		/// <remarks>
		/// Gets the batch id of the transaction for which the
		/// inquiry transaction is performed.
		/// Value available only after settlement has assigned a BatchId 
		/// Value obtained when Payflow Verbosity paramter = MEDIUM 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BATCHID</code>
		/// </remarks>
		public String BatchId
		{
			get { return mBatchId; }
		}

		/// <summary>
		/// Gets, Sets  AddlMsgs
		/// </summary>
		/// <remarks>
		/// Additional error message that indicates that the
		/// merchant used a feature that is disabled.
		/// Value obtained when Payflow Verbosity paramter = MEDIUM 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ADDLMSGS</code>
		/// </remarks>
		public String AddlMsgs
		{
			get { return mAddlMsgs; }
		}

		/// <summary>
		/// Gets, Sets  HostCode
		/// </summary>
		/// <remarks>
		/// Response code returned by the processor. This
		/// value is not normalized by PayPal.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>HOSTCODE</code>
		/// </remarks>
		public String HostCode
		{
			get { return mHostCode; }

		}

		/// <summary>
		/// Gets, Sets  ProcAVS
		/// </summary>
		/// <remarks>
		/// AVS (Address Verification Service) response
		/// from the processor.
		/// Value obtained when Payflow Verbosity paramter = MEDIUM 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROCAVS</code>
		/// </remarks>
		public String ProcAVS
		{
			get { return mProcAvs; }
		}

		/// <summary>
		/// Gets, Sets  ProcCardSecure
		/// </summary>
		/// <remarks>
		/// VPAS/SPA response from the processor.
		/// Value obtained when Payflow Verbosity paramter = MEDIUM 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROCCARDSECURE</code>
		/// </remarks>
		public String ProcCardSecure
		{
			get { return mProcCardSecure; }
		}

		/// <summary>
		/// Gets, Sets  ProcCVV2
		/// </summary>
		/// <remarks>
		/// CVV2 (buyer authentication) response from the processor.
		/// Its a 3- or 4-digit code that is printed (not imprinted) on
		/// the back of a credit card. Used as partial assurance
		/// that the card is in the buyer’s possession.
		/// Value obtained when Payflow Verbosity paramter = MEDIUM
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROCCVV2</code>
		/// </remarks>
		public String ProcCVV2
		{
			get { return mProcCVV2; }
		}

		/// <summary>
		/// Gets, Sets  RespText
		/// </summary>
		/// <remarks>
		/// Text corresponding to the response code
		/// returned by the processor. This text is not
		///	normalized by Gateway server.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RESPTEXT</code>
		/// </remarks>
		public String RespText
		{
			get { return mRespText; }
		}

		//Added as SETTLE_DATE parameter is also available when VERBOSITY= MEDIUM
		//2005-12-10
		/// <summary>
		/// Gets inquiry SettleDate
		/// </summary>
		/// <remarks>
		/// Date when the settlement is completed
		/// Value obtained when Payflow Verbosity paramter = MEDIUM
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SETTLE_DATE</code>
		/// </remarks>
		public String SettleDate
		{
			get { return mSettleDate; }
		}
		/// <summary>
		/// Gets the PPref parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PPREF</code>
		/// </remarks>
		public String PPref
		{
			get {return mPPRef;}
		}
		/// <summary>
		/// Gets the CorrelationId parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CORRELATIONID</code>
		/// </remarks>
		public String CorrelationId
		{
			get {return mCorrelationId;}
		}

		/// <summary>
		/// Gets the feeamt parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FEEAMT</code>
		/// </remarks>
		public String FeeAmt
		{
			get {return mFeeAmt;}
		}

		/// <summary>
		/// Gets the PendingReason parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PENDINGREASON</code>
		/// </remarks>
		public String PendingReason
		{
			get {return mPendingReason;}
		}
		/// <summary>
		/// Gets the PaymentType parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTTYPE</code>
		/// </remarks>
		public String PaymentType
		{
			get {return mPaymentType;}
		}

		//Added as STATUS param is also available when VERBOSITY= MEDIUM
		//2006-09-18
		/// <summary>
		/// Gets inquiry Status
		/// </summary>
		/// <remarks>
		/// Status of transaction
		/// Value obtained when Payflow Verbosity parameter = MEDIUM
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STATUS</code>
		/// </remarks>
		public String Status
		{
			get { return mStatus; }
		}
		// Added BALAMT param 2007-05-31
		/// <summary>
		/// Gets the BalAmt parameter
		/// </summary>
		/// <remarks>
		/// American Express CAPN transactions only:
		/// Balance on a pre-paid store value card. The value includes a decimal and
		/// the exact amount to the cent (42.00, not 42).
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BALAMT</code>
		/// </remarks>
		public String BalAmt
		{
			get { return mBalAmt; }
		}
		// Added AMEXID param 2007-05-31
		/// <summary>
		/// Gets the AmexID parameter
		/// </summary>
		/// <remarks>
		/// American Express CAPN transactions only:
		/// Unique transaction ID returned when VERBOSITY = MEDIUM.
		/// Used to track American Express CAPN transactions.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMEXID</code>
		/// </remarks>
		public String AmexID
		{
			get { return mAmexID; }
		}
		// Added AMEXPOSDATA param 2007-11-05
		/// <summary>
		/// Gets the AmexPosData parameter
		/// </summary>
		/// <remarks>
		/// American Express CAPN transactions only:
		/// Unique field returned when VERBOSITY = MEDIUM.
		/// Used by merchants who authorize transactions through
		/// the payflow gateway but settle through a third-party solution.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMEXPOSDATA</code>
		/// </remarks>
		public String AmexPosData
		{
			get { return mAmexPosData; }
		}
		/// <summary>
		/// Gets the TransTime parameter
		/// </summary>
		/// <remarks>
		/// Returns the transaction time in the format of:
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TRANSTIME</code>
		/// </remarks>
		public String TransTime
		{
			get { return mTransTime; }
		}
		/// <summary>
		/// Gets the CardType parameter
		/// </summary>
		/// <remarks>
		/// Returns a value which represents the card type used.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CARDTYPE</code>
		/// </remarks>
		public String CardType
		{
			get { return mCardType; }
		}
		/// <summary>
		/// Gets the OrigAmt parameter
		/// </summary>
		/// <remarks>
		/// Returns the original amount sent for processing.  Used
		/// with PARTIALAUTH parameter.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORIGAMT</code>
		/// </remarks>
		public String OrigAmt
		{
			get { return mOrigAmt; }
		}
		/// <summary>
		/// Gets the Acct parameter
		/// </summary>
		/// <remarks>
		/// Returns the last 4-digits of the credit card number used.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ACCT</code>
		/// </remarks>
		public String Acct
		{
			get { return mAcct; }
		}
		/// <summary>
		/// Gets the LastName parameter
		/// </summary>
		/// <remarks>
		/// Returns the last name.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>LASTNAME</code>
		/// </remarks>
		public String LastName
		{
			get { return mLastName; }
		}
		/// <summary>
		/// Gets the FirstName parameter
		/// </summary>
		/// <remarks>
		/// Returns the first name.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FIRSTNAME</code>
		/// </remarks>
		public String FirstName
		{
			get { return mFirstName; }
		}
		/// <summary>
		/// Gets the amt parameter
		/// </summary>
		/// <remarks>
		/// Returns the amount of the transaction that was
		/// authorized.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMT</code>
		/// </remarks>
		public String Amt
		{
			get { return mAmt; }
		}
		/// <summary>
		/// Gets the ExpDate parameter
		/// </summary>
		/// <remarks>
		/// Returns the expiration date of the credit card used.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EXPDATE</code>
		/// </remarks>
		public String ExpDate
		{
			get { return mExpDate; }
		}
		/// <summary>
		/// Gets the ExtRspMsg parameter
		/// </summary>
		/// <remarks>
		/// Returns additional (extra) response messages from processor.
		/// Not supported by all processors.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EXTRSPMSG</code>
		/// </remarks>
		public String ExtRspMsg
		{
			get { return mExtRspMsg; }
		}
		/// <summary>
		/// Gets the SecureToken parameter
        /// </summary>
		/// <remarks>
		/// Returns the secure token that was sent in the original transaction.
		/// Used with secure token id to call the hosted payment pages.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SECURETOKEN</code>
		/// </remarks>
		public String SecureToken
		{
			get { return mSecureToken; }
		}
		/// <summary>
		/// Gets the SecureTokenId parameter
        /// </summary>
        /// <remarks>
		/// Returns the secure token id that was sent in the original transaction.
		/// Used with secure token to call the hosted payment pages.
		/// 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SECURETOKENID</code>
		/// </remarks>
		public String SecureTokenId
		{
			get { return mSecureTokenId; }
		}
        /// <summary>
        /// Gets the MagTResponse parameter
        /// </summary>
        /// <remarks>
        /// This only appears in the response if a data validation error occurs or 
        /// if the MagTek service throws an error.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MAGTRESPONSE</code>
        /// </remarks>
        public String MagTResponse
        {
            get { return mMagTResponse; }
        }
        /// <summary>
        /// Gets the Trace Id parameter
        /// </summary>
        /// <remarks>
        /// Returns the Trace Id returned by TeleCheck.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>TRACEID</code>
        /// </remarks>
        public String TraceId
        {
            get { return mTraceId; }
        }
        /// <summary>
        /// Gets the AchStatus parameter
        /// </summary>
        /// <remarks>
        /// Returns the ACH Status returned by TeleCheck.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ACHSTATUS</code>
        /// </remarks>
        public String AchStatus
        {
            get { return mAchStatus; }
        }

        /// <summary>
        /// Gets the TXId parameter
        /// </summary>
        /// <remarks>
        /// Returns the Transaction Id for Card on File
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>TXID</code>
        /// </remarks>
        public String TxId
        {
            get { return mTxId; }
        }
        /// <summary>
        /// Gets the Payment Advice Code
        /// </summary>
        /// <remarks>
        /// Returns the Payment Advice Code for supported processors.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>PAYMENTADVICECODE</code>
        /// </remarks>
        public String PaymentAdviceCode
        {
            get { return mPaymentAdviceCode; }
        }
        /// <summary>
        /// Gets the Association Response Code parameter
        /// </summary>
        /// <remarks>
        /// Returns the Association Response Code for supported processors.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ASSOCIATIONRESPONSECODE</code>
        /// </remarks>
        public String AssociationResponseCode
        {
            get { return mAssociationResponseCode; }
        }
        /// <summary>
        /// Gets the Type parameter
        /// </summary>
        /// <remarks>
        /// Returns the yype of account used in the transaction. 
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>TYPE</code>
        /// </remarks>
        public String Type
        {
            get { return Type; }
        }
        /// <summary>
        /// Gets the Affluent parameter
        /// </summary>
        /// <remarks>
        /// Returns the status (affluent) of the card holder.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>AFFLUENT</code>
        /// </remarks>
        public String Affluent
        {
            get { return mAffluent; }
        }

        /// <summary>
        /// Gets the CC Updated parameter
        /// </summary>
        /// <remarks>
        /// Returns the status if the card was updated.
        /// 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CCUPDATED</code>
        /// </remarks>
        public String CCUpdated
        {
            get { return mCCUpdated; }
        }

		/// <summary>
        /// Gets the Retrieve Reference transaction.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>RRN</code>
        /// </remarks>
        public String Rrn
        {
            get { return mRrn; }
        }
		/// <summary>
        /// Gets the System Trace Audit number.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>STAN</code>
        /// </remarks>
        public String Stan
        {
            get { return mStan; }
        }
		/// <summary>
        /// Gets the Authorization Characteristics Indicator.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>Aci</code>
        /// </remarks>
        public String Aci
        {
            get { return mAci; }
        }
		/// <summary>
        /// Gets the Transaction Identifier.
        /// </summary>
		/// The transaction identifier associated with the transaction being settled.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>VALIDATIONCODE</code>
        /// </remarks>
        public String ValidationCode
        {
            get { return mValidationCode; }
        }

		/// <summary>
        /// Gets the Credit Card Transaction Id.
        /// </summary>
		/// Unique transaction ID returned by some processors for all credit card transactions.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CCTRANSID</code>
        /// </remarks>
        public String CCTransId
        {
            get { return mCCTransId; }
        }
		/// <summary>
        /// Gets the Credit Card Transaction POS Data
        /// </summary>
		/// Value returned by some processors for all credit card transactions.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CCTRAN_POSDATA</code>
        /// </remarks>
        public String CCTrans_POSData
        {
            get { return mCCTrans_POSData; }
        }

		/// <summary>
		/// Gets the Payment Account Reference
		/// </summary>
		/// Value returned by some processors that is a non-financial reference number assigned to each unique 
		/// Primary Account Number (PAN) and mapped to all its affiliated Payment Tokens.
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PARID</code>
		/// </remarks>
		public String ParId
		{
			get { return mParId; }
		}
		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for Transaction response.
		/// </summary>
		internal TransactionResponse ()
		{

		}


		#endregion

		#region "Functions"

		/// <summary>
		/// Sets response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal void SetParams(ref Hashtable ResponseHashTable)
		{
			//			mResponse = (String) ResponseHashTable[PayflowConstants.INTL_PARAM_FULLRESPONSE];
			mResult = int.Parse( (String)ResponseHashTable[PayflowConstants.PARAM_RESULT]);
			mPnref = (String) ResponseHashTable[PayflowConstants.PARAM_PNREF];
			mRespMsg = (String) ResponseHashTable[PayflowConstants.PARAM_RESPMSG];
			mAuthCode = (String) ResponseHashTable[PayflowConstants.PARAM_AUTHCODE];
			mAvsAddr = (String) ResponseHashTable[PayflowConstants.PARAM_AVSADDR];
			mAvsZip = (String) ResponseHashTable[PayflowConstants.PARAM_AVSZIP];
			mCardSecure = (String) ResponseHashTable[PayflowConstants.PARAM_CARDSECURE];
			mCVV2Match = (String) ResponseHashTable[PayflowConstants.PARAM_CVV2MATCH];
			mIavs = (String) ResponseHashTable[PayflowConstants.PARAM_IAVS];
			mOrigResult = (String) ResponseHashTable[PayflowConstants.PARAM_ORIGRESULT];
			mTransState = (String) ResponseHashTable[PayflowConstants.PARAM_TRANSSTATE];
			mCustRef = (String) ResponseHashTable[PayflowConstants.PARAM_CUSTREF];
			mStartTime = (String) ResponseHashTable[PayflowConstants.PARAM_STARTTIME];
			mEndTime = (String) ResponseHashTable[PayflowConstants.PARAM_ENDTIME];
			mDuplicate = (String) ResponseHashTable[PayflowConstants.PARAM_DUPLICATE];
			mDateToSettle = (String) ResponseHashTable[PayflowConstants.PARAM_DATE_TO_SETTLE];
			mBatchId = (String) ResponseHashTable[PayflowConstants.PARAM_BATCHID];
			mAddlMsgs = (String) ResponseHashTable[PayflowConstants.PARAM_ADDLMSGS];
			mRespText = (String) ResponseHashTable[PayflowConstants.PARAM_RESPTEXT];
			mProcAvs = (String) ResponseHashTable[PayflowConstants.PARAM_PROCAVS];
			mProcCardSecure = (String) ResponseHashTable[PayflowConstants.PARAM_PROCCARDSECURE];
			mProcCVV2 = (String) ResponseHashTable[PayflowConstants.PARAM_PROCCVV2];
			mHostCode = (String) ResponseHashTable[PayflowConstants.PARAM_HOSTCODE];
			mSettleDate = (String) ResponseHashTable[PayflowConstants.PARAM_SETTLE_DATE];
			mOrigPnref = (String) ResponseHashTable[PayflowConstants.PARAM_ORIGPNREF];
			mPPRef = (String) ResponseHashTable[PayflowConstants.PARAM_PPREF];
			mCorrelationId = (String) ResponseHashTable[PayflowConstants.PARAM_CORRELATIONID];
			mFeeAmt = (String) ResponseHashTable[PayflowConstants.PARAM_FEEAMT];
			mPendingReason = (String) ResponseHashTable[PayflowConstants.PARAM_PENDINGREASON];
			mPaymentType  = (String) ResponseHashTable[PayflowConstants.PARAM_PAYMENTTYPE];
			mStatus = (String)ResponseHashTable[PayflowConstants.PARAM_STATUS];
			mBalAmt = (String)ResponseHashTable[PayflowConstants.PARAM_BALAMT];
			mAmexID = (String)ResponseHashTable[PayflowConstants.PARAM_AMEXID];
			mAmexPosData = (String)ResponseHashTable[PayflowConstants.PARAM_AMEXPOSDATA];
			mAcct = (String)ResponseHashTable[PayflowConstants.PARAM_ACCT];
			mLastName = (String)ResponseHashTable[PayflowConstants.PARAM_LASTNAME];
            // due to issue where ACH doesn't support BILLTOFIRSTNAME we have to use legacy FIRSTNAME to get response value.
            if (ResponseHashTable["FIRSTNAME"] == null)
                mFirstName = (String)ResponseHashTable[PayflowConstants.PARAM_FIRSTNAME];
            else
                mFirstName = (String)ResponseHashTable["FIRSTNAME"];
            mAmt = (String)ResponseHashTable[PayflowConstants.PARAM_AMT];
			mExpDate = (String)ResponseHashTable[PayflowConstants.PARAM_EXPDATE];
			mTransTime = (String)ResponseHashTable[PayflowConstants.PARAM_TRANSTIME];
			mCardType = (String)ResponseHashTable[PayflowConstants.PARAM_CARDTYPE];
			mOrigAmt = (String)ResponseHashTable[PayflowConstants.PARAM_ORIGAMT];
			mEmailMatch = (String)ResponseHashTable[PayflowConstants.PARAM_EMAILMATCH];
			mPhoneMatch = (String)ResponseHashTable[PayflowConstants.PARAM_PHONEMATCH];
			mExtRspMsg = (String)ResponseHashTable[PayflowConstants.PARAM_EXTRSPMSG];
			mSecureToken = (String)ResponseHashTable[PayflowConstants.PARAM_SECURETOKEN];
			mSecureTokenId = (String)ResponseHashTable[PayflowConstants.PARAM_SECURETOKENID];
            mMagTResponse = (String)ResponseHashTable[PayflowConstants.MAGTEK_PARAM_MAGTRESPONSE];
            mTraceId = (String)ResponseHashTable[PayflowConstants.PARAM_TRACEID];
            mAchStatus = (String)ResponseHashTable[PayflowConstants.PARAM_ACHSTATUS];
            mTxId = (String)ResponseHashTable[PayflowConstants.PARAM_TXID];
            mPaymentAdviceCode = (String)ResponseHashTable[PayflowConstants.PARAM_PAYMENTADVICECODE];
            mAssociationResponseCode = (String)ResponseHashTable[PayflowConstants.PARAM_ASSOCIATIONRESPCODE];
            mType = (String)ResponseHashTable[PayflowConstants.PARAM_TYPE];
			mCCUpdated = (String)ResponseHashTable[PayflowConstants.PARAM_CCUPDATED];
			mAffluent= (String)ResponseHashTable[PayflowConstants.PARAM_AFFLUENT];
            mRrn= (String)ResponseHashTable[PayflowConstants.PARAM_RRN];
            mStan = (String)ResponseHashTable[PayflowConstants.PARAM_STAN];
			mAci = (String)ResponseHashTable[PayflowConstants.PARAM_ACI];
			mValidationCode = (String)ResponseHashTable[PayflowConstants.PARAM_VALIDATIONCODE];
			mCCTransId = (String)ResponseHashTable[PayflowConstants.PARAM_CCTRANSID];
			mCCTrans_POSData = (String)ResponseHashTable[PayflowConstants.PARAM_CCTRANS_POSDATA];
			mParId = (String)ResponseHashTable[PayflowConstants.PARAM_PARID];

			// Remove the used response params from hash table.
			// ResponseHashTable.Remove(PayflowConstants.INTL_PARAM_FULLRESPONSE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_RESULT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PNREF);
			ResponseHashTable.Remove(PayflowConstants.PARAM_RESPMSG);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AUTHCODE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AVSADDR);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AVSZIP);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CARDSECURE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CVV2MATCH);
			ResponseHashTable.Remove(PayflowConstants.PARAM_IAVS);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ORIGRESULT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_TRANSSTATE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CUSTREF);
			ResponseHashTable.Remove(PayflowConstants.PARAM_STARTTIME);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ENDTIME);
			ResponseHashTable.Remove(PayflowConstants.PARAM_DUPLICATE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_DATE_TO_SETTLE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_BATCHID);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ADDLMSGS);
			ResponseHashTable.Remove(PayflowConstants.PARAM_RESPTEXT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PROCAVS);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PROCCARDSECURE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PROCCVV2);
			ResponseHashTable.Remove(PayflowConstants.PARAM_HOSTCODE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_SETTLE_DATE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ORIGPNREF);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PPREF);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CORRELATIONID);
			ResponseHashTable.Remove(PayflowConstants.PARAM_FEEAMT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PENDINGREASON);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTTYPE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_BALAMT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AMEXID);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AMEXPOSDATA);
            // This is here to deal with FIRSTNAME returned in ACH, not BILLTOFIRSTNAME.
            ResponseHashTable.Remove("FIRSTNAME");
			ResponseHashTable.Remove(PayflowConstants.PARAM_TRANSTIME);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CARDTYPE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ORIGAMT);
			ResponseHashTable.Remove(PayflowConstants.PARAM_EMAILMATCH);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PHONEMATCH);
			ResponseHashTable.Remove(PayflowConstants.PARAM_EXTRSPMSG);
			ResponseHashTable.Remove(PayflowConstants.PARAM_SECURETOKEN);
			ResponseHashTable.Remove(PayflowConstants.PARAM_SECURETOKENID);
            ResponseHashTable.Remove(PayflowConstants.MAGTEK_PARAM_MAGTRESPONSE);
            ResponseHashTable.Remove(PayflowConstants.PARAM_TRACEID);
            ResponseHashTable.Remove(PayflowConstants.PARAM_ACHSTATUS);
            ResponseHashTable.Remove(PayflowConstants.PARAM_TXID);
            ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTADVICECODE);
            ResponseHashTable.Remove(PayflowConstants.PARAM_ASSOCIATIONRESPCODE);
            ResponseHashTable.Remove(PayflowConstants.PARAM_TYPE);
            ResponseHashTable.Remove(PayflowConstants.PARAM_AFFLUENT);
            ResponseHashTable.Remove(PayflowConstants.PARAM_CCUPDATED);
			ResponseHashTable.Remove(PayflowConstants.PARAM_RRN);
			ResponseHashTable.Remove(PayflowConstants.PARAM_STAN);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ACI);
			ResponseHashTable.Remove(PayflowConstants.PARAM_VALIDATIONCODE);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CCTRANSID);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CCTRANS_POSDATA);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PARID);

			// Commented lines below to reserve Status for Recurring Inquiry
			// ResponseHashTable.Remove(PayflowConstants.PARAM_STATUS);
			// ResponseHashTable.Remove(PayflowConstants.PARAM_AMT);
			// ResponseHashTable.Remove(PayflowConstants.PARAM_EXPDATE);
			// ResponseHashTable.Remove(PayflowConstants.PARAM_ACCT);
			// ResponseHashTable.Remove(PayflowConstants.PARAM_LASTNAME);
			// ResponseHashTable.Remove(PayflowConstants.PARAM_FIRSTNAME);
		}

		#endregion
	}
}