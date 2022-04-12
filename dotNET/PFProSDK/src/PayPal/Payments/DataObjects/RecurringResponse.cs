#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;
using System.Collections;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Container class for all the messages related to
	/// recurring transactions.
	/// </summary>
	/// <remarks>This class contains response messages specific to 
	/// the recurring transactions.
	/// </remarks>
	/// <example>
	/// Following example shows how to obtain and use the recurring 
	/// response.
	/// <code lang="C#" escaped="false">
	///		...................
	///		// Trans is the recurring transaction.
	///		...................
	///		// Submit the transaction.
	///		Response Resp = Trans.SubmitTransaction();
	///		
	///		if (Resp != null)
	///			{
	///			// Get the Transaction Response parameters.
	///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
	///			if (TrxnResponse != null)
	///			{
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///			}
	///
	///			// Get the Recurring Response parameters.
	///			RecurringResponse RecurResponse = Resp.RecurringResponse;
	///			if (RecurResponse != null)
	///			{
	///				Console.WriteLine("RPREF = " + RecurResponse.RPRef);
	///				Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);
	///			}
	///		}
	///		
	///		...................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	            ..........................
	///	            ' Trans is the transaction object
	///	            ..........................
	///
	///	            ' Submit the transaction.
	///	            Dim Resp As Response = Trans.SubmitTransaction()
	///
	///	            If Not Resp Is Nothing Then
	///	                ' Get the Transaction Response parameters.
	///	                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///	                If Not TrxnResponse Is Nothing Then
	///	                    Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///	                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///	                End If
	///
	///	                ' Get the Recurring Response parameters.
	///	                Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
	///	                If Not RecurResponse Is Nothing Then
	///	                    Console.WriteLine("RPREF = " + RecurResponse.RPRef)
	///	                    Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
	///	                End If
	///	            End If
	///
	///	            ..........................
	/// </code>
	/// </example>
	public sealed class RecurringResponse : BaseResponseDataObject
	{
		#region "Member variables"

		/// <summary>
		/// Profile id
		/// </summary>
		private String mProfileId;

		/// <summary>
		/// RPRef
		/// </summary>
		private String mRPRef;

		/// <summary>
		/// TrxPNref
		/// </summary>
		private String mTrxPNRef;

		/// <summary>
		/// Transaction result
		/// </summary>
		private String mTrxResult;

		/// <summary>
		/// Transaction response msg
		/// </summary>
		private String mTrxRespMsg;

		//Additional fields for Inquiry transaction
		/// <summary>
		/// Profile name
		/// </summary>
		private String mProfileName;

		/// <summary>
		/// Start
		/// </summary>
		private String mStart;

		/// <summary>
		/// Term
		/// </summary>
		private String mTerm;

		/// <summary>
		///Payment period
		/// </summary>
		private String mPayPeriod;

		/// <summary>
		/// Status
		/// </summary>
		private String mStatus;

		/// <summary>
		/// Tender type
		/// </summary>
		private String mTenderType;

		/// <summary>
		/// Payments left
		/// </summary>
		private String mPaymentsLeft;

		/// <summary>
		/// Next Payment
		/// </summary>
		private String mNxtPayment;

		/// <summary>
		/// End payment
		/// </summary>
		private String mEnd;

		/// <summary>
		/// Agrregate amount
		/// </summary>
		private String mAggregateAmt;

		/// <summary>
		/// Aggregate optional amount
		/// </summary>
		private String mAggregateOptionalAmt;

		/// <summary>
		/// amount
		/// </summary>
		private String mAmt;

		/// <summary>
		/// account
		/// </summary>
		private String mAcct;

		/// <summary>
		/// Expiry date
		/// </summary>
		private String mExpDate;

		/// <summary>
		/// Max failed payments
		/// </summary>
		private String mMaxFailPayments;

		/// <summary>
		/// Number of fail payments
		/// </summary>
		private String mNumFailPayments;

		/// <summary>
		/// Retry number of days
		/// </summary>
		private String mRetryNumDays;

		/// <summary>
		/// Email
		/// </summary>
		private String mEmail;

		/// <summary>
		/// Company name
		/// </summary>
		private String mCompanyName;

		/// <summary>
		/// Name
		/// </summary>
		private String mName;

		/// <summary>
		/// First name
		/// </summary>
		private String mFirstName;

		/// <summary>
		/// Middle name
		/// </summary>
		private String mMiddleName;

		/// <summary>
		/// Last name
		/// </summary>
		private String mLastName;

		/// <summary>
		/// Street
		/// </summary>
		private String mStreet;

		/// <summary>
		/// City
		/// </summary>
		private String mCity;

		/// <summary>
		/// State
		/// </summary>
		private String mState;

		/// <summary>
		/// Zip
		/// </summary>
		private String mZip;

		/// <summary>
		/// Country
		/// </summary>
		private String mCountry;

		/// <summary>
		/// Phone num
		/// </summary>
		private String mPhoneNum;

		/// <summary>
		/// Ship to first name
		/// </summary>
		private String mShipToFName;

		/// <summary>
		/// Ship to middle name
		/// </summary>
		private String mShipToMName;

		/// <summary>
		/// Ship to last name
		/// </summary>
		private String mShipToLName;

		/// <summary>
		/// Ship to street
		/// </summary>
		private String mShipToStreet;

		/// <summary>
		/// Ship to city
		/// </summary>
		private String mShipToCity;

		/// <summary>
		/// Ship to state
		/// </summary>
		private String mShipToState;

		/// <summary>
		/// Ship to zip
		/// </summary>
		private String mShipToZip;

		/// <summary>
		/// Ship to country
		/// </summary>
		private String mShipToCountry;

		/// <summary>
		/// Inquiry Response Array list.
		/// </summary>
		private Hashtable mInquiryParams;

		/// <summary>
		/// Creation Date
		/// </summary>
		private String mCreationDate;

		/// <summary>
		/// Last Changed Date
		/// </summary>
		private String mLastChangedDate;

		/// <summary>
		/// Recurring Profile State
		/// </summary>
		private String mRPState;

		/// <summary>
		/// Next Payment Number
		/// </summary>
		private String mNextPaymentNumber;

		/// <summary>
		/// Frequency
		/// </summary>
		private String mFrequency;

		/// <summary>
		/// Currency
		/// </summary>
		private String mCurrency;



		#endregion

		#region "Properties"

		/// <summary>
		/// Gets ProfileId
		/// </summary>
		/// <remarks>
		/// The Profile ID of the original profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROFILEID</code>
		/// </remarks>
		public String ProfileId
		{
			get { return mProfileId; }
		}

		/// <summary>
		/// Gets RPRef
		/// </summary>
		/// <remarks>
		/// Reference number to this particular action request.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RPREF</code>
		/// </remarks>
		public String RPRef
		{
			get { return mRPRef; }
		}

		/// <summary>
		/// Gets TrxPNRef
		/// </summary>
		/// <remarks>
		/// PNREF of the optional transaction.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TRXPNREF</code>
		/// </remarks>
		public String TrxPNRef
		{
			get { return mTrxPNRef; }
		}

		/// <summary>
		/// Gets TrxResult
		/// </summary>
		/// <remarks>
		/// RESULT of the optional transaction.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TRXRESULT</code>
		/// </remarks>
		public String TrxResult
		{
			get { return mTrxResult; }
		}

		/// <summary>
		/// Gets TrxRespMsg
		/// </summary>
		/// <remarks>
		/// RESPMSG of the optional transaction
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TRXRESPMSG</code>
		/// </remarks>
		public String TrxRespMsg
		{
			get { return mTrxRespMsg; }
		}

		//Additional fields for Inquiry transaction
		/// <summary>
		/// Gets ProfileName
		/// </summary>
		/// <remarks>
		/// Name for the profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROFILENAME</code>
		/// </remarks>
		public String ProfileName
		{
			get { return mProfileName; }
		}

		/// <summary>
		/// Gets Start
		/// </summary>
		/// <remarks>
		/// Beginning date for the recurring billing cycle.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>START</code>
		/// </remarks>
		public String Start
		{
			get { return mStart; }
		}

		/// <summary>
		/// Gets Term
		/// </summary>
		/// <remarks>
		/// Number of payments to be made over the life of the agreement.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TERM</code>
		/// </remarks>
		public String Term
		{
			get { return mTerm; }
		}

		/// <summary>
		/// Gets PayPeriod
		/// </summary>
		/// <remarks>
		/// Specifies how often the payment occurs.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYPERIOD</code>
		/// </remarks>
		public String PayPeriod
		{
			get { return mPayPeriod; }
		}

		/// <summary>
		/// Gets Status
		/// </summary>
		/// <remarks>
		/// Current status of the profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STATUS</code>
		/// </remarks>
		public String Status
		{
			get { return mStatus; }
		}

		/// <summary>
		/// Gets TenderType
		/// </summary>
		/// <remarks>
		/// Tender Type
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TENDER</code>
		/// </remarks>
		public String Tender
		{
			get { return mTenderType; }
		}

		/// <summary>
		/// Gets PaymentsLeft
		/// </summary>
		/// <remarks>
		/// Number of payments left to be billed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTSLEFT</code>
		/// </remarks>
		public String PaymentsLeft
		{
			get { return mPaymentsLeft; }
		}

		/// <summary>
		/// Gets NxtPayment
		/// </summary>
		/// <remarks>
		/// Date that the next payment is due.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NEXTPAYMENT</code>
		/// </remarks>
		public String NextPayment
		{
			get { return mNxtPayment; }
		}

		/// <summary>
		/// Gets End
		/// </summary>
		/// <remarks>
		/// Date that the last payment is due. Present only if this is
		/// not an unlimited-term subscription.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>END</code>
		/// </remarks>
		public String End
		{
			get { return mEnd; }
		}

		/// <summary>
		/// Gets AggregateAmt
		/// </summary>
		/// <remarks>
		/// Amount collected so far for scheduled payments.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AGGREGATEAMT</code>
		/// </remarks>
		public String AggregateAmt
		{
			get { return mAggregateAmt; }
		}

		/// <summary>
		/// Gets AggregateOptAmt
		/// </summary>
		/// <remarks>
		/// Amount collected through sending optional transactions.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AGGREGATEOPTIONALAMT</code>
		/// </remarks>
		public String AggregateOptionalAmt
		{
			get { return mAggregateOptionalAmt; }
		}

		/// <summary>
		/// Gets Amt
		/// </summary>
		/// <remarks>
		/// Base dollar amount to be billed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMT</code>
		/// </remarks>
		public String Amt
		{
			get { return mAmt; }
		}

		/// <summary>
		/// Gets Acct
		/// </summary>
		/// <remarks>
		/// Masked credit card number.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ACCT</code>
		/// </remarks>
		public String Acct
		{
			get { return mAcct; }
		}

		/// <summary>
		/// Gets ExpDate
		/// </summary>
		/// <remarks>
		/// Expiration date of the credit card account.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EXPDATE</code>
		/// </remarks>
		public String ExpDate
		{
			get { return mExpDate; }
		}

		/// <summary>
		/// Gets MaxFailPayments
		/// </summary>
		/// <remarks>
		/// The number of payment periods (specified by
		/// PAYPERIOD) for which the transaction is allowed to fail
		/// before PayPal cancels a profile.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MAXFAILPAYMENTS</code>
		/// </remarks>
		public String MaxFailPayments
		{
			get { return mMaxFailPayments; }
		}

		/// <summary>
		/// Gets NumFailPayments
		/// </summary>
		/// <remarks>
		/// Number of payments that failed.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NUMFAILPAYMENTS</code>
		/// </remarks>
		public String NumFailPayments
		{
			get { return mNumFailPayments; }
		}

		/// <summary>
		/// Gets RetryNumDays
		/// </summary>
		/// <remarks>
		/// The number of consecutive days that PayPal should
		/// attempt to process a failed transaction until Approved
		/// status is received.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RETRYNUMDAYS</code>
		/// </remarks>
		public String RetryNumDays
		{
			get { return mRetryNumDays; }
		}

		/// <summary>
		/// Gets Email
		/// </summary>
		/// <remarks>
		/// Customer e-mail address.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EMAIL</code>
		/// </remarks>
		public String Email
		{
			get { return mEmail; }
		}

		/// <summary>
		/// Gets CompanyName
		/// </summary>
		/// <remarks>
		/// Recurring Profile Company Name.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COMPANYNAME</code>
		/// </remarks>
		public String CompanyName
		{
			get { return mCompanyName; }
		}

		/// <summary>
		/// Gets Name
		/// </summary>
		/// <remarks>
		/// Name of account holder
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NAME</code>
		/// </remarks>
		public String Name
		{
			get { return mName; }
		}

		/// <summary>
		/// Gets FirstName
		/// </summary>
		/// <remarks>
		/// First name of card holder.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FIRSTNAME</code>
		/// </remarks>
		public String FirstName
		{
			get { return mFirstName; }
		}

		/// <summary>
		/// Gets MiddleName
		/// </summary>
		/// <remarks>
		/// Middle name of card holder
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MIDDLENAME</code>
		/// </remarks>
		public String MiddleName
		{
			get { return mMiddleName; }
		}

		/// <summary>
		/// Gets Lastname
		/// </summary>
		/// <remarks>
		/// Last name of card holder
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>LASTNAME</code>
		/// </remarks>
		public String LastName
		{
			get { return mLastName; }
		}

		/// <summary>
		/// Gets Street
		/// </summary>
		/// <remarks>
		/// Billing address
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STREET</code>
		/// </remarks>
		public String Street
		{
			get { return mStreet; }
		}

		/// <summary>
		/// Gets City
		/// </summary>
		/// <remarks>
		/// Billing city
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CITY</code>
		/// </remarks>
		public String City
		{
			get { return mCity; }
		}

		/// <summary>
		/// Gets State
		/// </summary>
		/// <remarks>
		/// Billing state
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STATE</code>
		/// </remarks>
		public String State
		{
			get { return mState; }
		}

		/// <summary>
		/// Gets Zip
		/// </summary>
		/// <remarks>
		/// Billing zip
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ZIP</code>
		/// </remarks>
		public String Zip
		{
			get { return mZip; }
		}

		/// <summary>
		/// Gets Country
		/// </summary>
		/// <remarks>
		/// Billing country
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COUNTRY</code>
		/// </remarks>
		public String Country
		{
			get { return mCountry; }
		}

		/// <summary>
		/// Gets PhoneNum
		/// </summary>
		/// <remarks>
		/// Billing phonenum
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PHONENUM</code>
		/// </remarks>
		public String PhoneNum
		{
			get { return mPhoneNum; }
		}

		/// <summary>
		/// Gets ShipToFirstName
		/// </summary>
		/// <remarks>
		/// First name of the ship-to person
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOFIRSTNAME</code>
		/// </remarks>
		public String ShipToFirstName
		{
			get { return mShipToFName; }
		}

		/// <summary>
		/// Gets ShipToMiddleName
		/// </summary>
		/// <remarks>
		/// Middle name of the ship-to person
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOMIDDLENAME</code>
		/// </remarks>
		public String ShipToMiddleName
		{
			get { return mShipToMName; }
		}

		/// <summary>
		/// Gets ShipToLastName
		/// </summary>
		/// <remarks>
		/// Last name of the ship-to person
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOLASTNAME</code>
		/// </remarks>
		public String ShipToLastName
		{
			get { return mShipToLName; }
		}

		/// <summary>
		/// Gets ShipToStreet
		/// </summary>
		/// <remarks>
		/// Shipping street
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOSTREET</code>
		/// </remarks>
		public String ShipToStreet
		{
			get { return mShipToStreet; }
		}

		/// <summary>
		/// Gets ShipToCity
		/// </summary>
		/// <remarks>
		/// Shipping city
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOCITY</code>
		/// </remarks>
		public String ShipToCity
		{
			get { return mShipToCity; }
		}

		/// <summary>
		/// Gets ShipToState
		/// </summary>
		/// <remarks>
		/// Shipping state
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOSTATE</code>
		/// </remarks>
		public String ShipToState
		{
			get { return mShipToState; }
		}

		/// <summary>
		/// Gets ShipToZip
		/// </summary>
		/// <remarks>
		/// Shipping zip
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOZIP</code>
		/// </remarks>
		public String ShipToZip
		{
			get { return mShipToZip; }
		}

		/// <summary>
		/// Gets ShipToCountry
		/// </summary>
		/// <remarks>
		/// Shipping country
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOCOUNTRY</code>
		/// </remarks>
		public String ShipToCountry
		{
			get { return mShipToCountry; }
		}

		/// <summary>
		/// Gets Creation Date
		/// </summary>
		/// <remarks>
		/// Creation Date
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CREATIONDATE</code>
		/// </remarks>
		public String CreationDate
		{
			get { return mCreationDate; }
		}

		/// <summary>
		/// Gets Last Changed Date
		/// </summary>
		/// <remarks>
		/// Last Changed Date
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>LASTCHANGED</code>
		/// </remarks>
		public String LastChangedDate
		{
			get { return mLastChangedDate; }
		}

		/// <summary>
		/// Gets Recurring Profile State
		/// </summary>
		/// <remarks>
		/// Recurring Profile State
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RPSTATE</code>
		/// </remarks>
		public String RPState
		{
			get { return mRPState; }
		}

		/// <summary>
		/// Gets Next Payment Number
		/// </summary>
		/// <remarks>
		/// Next Payment Number
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NEXTPAYMENTNUM</code>
		/// </remarks>
		public String NextPaymentNumber
		{
			get { return mNextPaymentNumber; }
		}

		/// <summary>
		/// Gets Frequency
		/// </summary>
		/// <remarks>
		/// Frequency
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FREQUENCY</code>
		/// </remarks>
		public String Frequency
		{
			get { return mFrequency; }
		}

		/// <summary>
		/// Gets Currency
		/// </summary>
		/// <remarks>
		/// Frequency
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CURRENCY</code>
		/// </remarks>
		public String Currency
		{
			get { return mCurrency; }
		}


		/// <summary>
		/// Gets recurring inquiry 
		/// param hash table
		/// </summary>
		/// <remarks>
		/// This hash table contains the response messages 
		/// when the recurring transaction is with 
		/// PAYMENTHISTORY=Y
		/// <para>Maps to following Payflow Parameters:</para>
		/// <code>
		/// <list type="table">
		/// <listheader>
		/// <term>Payflow param</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>P_RESULTn</term>
		/// <description>Result code of the financial transaction.</description>
		/// </item>
		/// <item>
		/// <term>P_PNREFn</term>
		/// <description>PNREF of the particular payment.</description>
		/// </item>
		/// <item>
		/// <term>P_TRANSTATEn</term>
		/// <description>TRANS_STATE of the particular payment.</description>
		/// </item>
		/// <item>
		/// <term>P_TENDERn</term>
		/// <description>Tender type</description>
		/// </item>
		/// <item>
		/// <term>P_TRANSTIMEn</term>
		/// <description>The timestamp for the transaction in the dd-mmm-yy hh:mm AM/PM format.</description>
		/// </item>
		/// <item>
		/// <term>P_AMTn</term>
		/// <description>Dollar amount (US dollars) that was billed. Specifies dollars and cents using a decimal point.</description>
		/// </item>
		/// </list>
		/// </code>
		/// </remarks>
		public Hashtable InquiryParams
		{
			get { return mInquiryParams; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for RecurringResponse
		/// </summary>
		internal RecurringResponse()
		{
			mInquiryParams = new Hashtable();
		}

		#endregion

		#region "Methods"

		/// <summary>
		/// Sets Response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mProfileId = (String)ResponseHashTable[PayflowConstants.PARAM_PROFILEID];
				mRPRef = (String)ResponseHashTable[PayflowConstants.PARAM_RPREF];
				mTrxPNRef = (String)ResponseHashTable[PayflowConstants.PARAM_TRXPNREF];
				mTrxResult = (String)ResponseHashTable[PayflowConstants.PARAM_TRXRESULT];
				mTrxRespMsg = (String)ResponseHashTable[PayflowConstants.PARAM_TRXRESPMSG];

				//Additional fields for Inquiry transaction
				mProfileName = (String)ResponseHashTable[PayflowConstants.PARAM_PROFILENAME];
				mStatus = (String)ResponseHashTable[PayflowConstants.PARAM_STATUS];
				mStart = (String)ResponseHashTable[PayflowConstants.PARAM_START];
				mTerm = (String)ResponseHashTable[PayflowConstants.PARAM_TERM];
				mPayPeriod = (String)ResponseHashTable[PayflowConstants.PARAM_PAYPERIOD];
				mStatus = (String)ResponseHashTable[PayflowConstants.PARAM_STATUS];
				mTenderType = (String)ResponseHashTable[PayflowConstants.PARAM_TENDER];
				mPaymentsLeft = (String)ResponseHashTable[PayflowConstants.PARAM_PAYMENTSLEFT];
				mNxtPayment = (String)ResponseHashTable[PayflowConstants.PARAM_NEXTPAYMENT];
				mCreationDate = (String)ResponseHashTable[PayflowConstants.PARAM_CREATIONDATE];
				mLastChangedDate = (String)ResponseHashTable[PayflowConstants.PARAM_LASTCHANGED];
				mRPState = (String)ResponseHashTable[PayflowConstants.PARAM_RPSTATE];
				mNextPaymentNumber = (String)ResponseHashTable[PayflowConstants.PARAM_NEXTPAYMENTNUM];
				mFrequency = (String)ResponseHashTable[PayflowConstants.PARAM_FREQUENCY];
				mEnd = (String)ResponseHashTable[PayflowConstants.PARAM_END];
				mAggregateAmt = (String)ResponseHashTable[PayflowConstants.PARAM_AGGREGATEAMT];
				mAggregateOptionalAmt = (String)ResponseHashTable[PayflowConstants.PARAM_AGGREGATEOPTIONALAMT];
				mAmt = (String)ResponseHashTable[PayflowConstants.PARAM_AMT];
				mCurrency = (String)ResponseHashTable[PayflowConstants.PARAM_CURRENCY];
				mAcct = (String)ResponseHashTable[PayflowConstants.PARAM_ACCT];
				mExpDate = (String)ResponseHashTable[PayflowConstants.PARAM_EXPDATE];
				mMaxFailPayments = (String)ResponseHashTable[PayflowConstants.PARAM_MAXFAILPAYMENTS];
				mNumFailPayments = (String)ResponseHashTable[PayflowConstants.PARAM_NUMFAILPAYMENTS];
				mRetryNumDays = (String)ResponseHashTable[PayflowConstants.PARAM_RETRYNUMDAYS];
				mEmail = (String)ResponseHashTable["EMAIL"];
				mCompanyName = (String)ResponseHashTable[PayflowConstants.PARAM_COMPANYNAME];
				// mName = (String) ResponseHashTable[PayflowConstants.PARAM_NAME];
				mFirstName = (String)ResponseHashTable[PayflowConstants.PARAM_NAME];
				mMiddleName = (String)ResponseHashTable[PayflowConstants.PARAM_MIDDLENAME];
				mLastName = (String)ResponseHashTable["LASTNAME"];
				mStreet = (String)ResponseHashTable["STREET"];
				mCity = (String)ResponseHashTable["CITY"];
				mState = (String)ResponseHashTable["STATE"];
				mZip = (String)ResponseHashTable["ZIP"];
				mCountry = (String)ResponseHashTable["COUNTRY"];
				mPhoneNum = (String)ResponseHashTable["PHONENUM"];
				mShipToFName = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOFIRSTNAME];
				mShipToMName = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOMIDDLENAME];
				mShipToLName = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOLASTNAME];
				mShipToStreet = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOSTREET];
				mShipToCity = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOCITY];
				mShipToState = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOSTATE];
				mShipToZip = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOZIP];
				mShipToCountry = (String)ResponseHashTable[PayflowConstants.PARAM_SHIPTOCOUNTRY];


				ResponseHashTable.Remove(PayflowConstants.PARAM_PROFILEID);
				ResponseHashTable.Remove(PayflowConstants.PARAM_RPREF);
				ResponseHashTable.Remove(PayflowConstants.PARAM_STATUS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TRXPNREF);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TRXRESULT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TRXRESPMSG);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PROFILENAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_START);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TERM);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PAYPERIOD);
				ResponseHashTable.Remove(PayflowConstants.PARAM_STATUS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TENDER);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTSLEFT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_NEXTPAYMENT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_END);
				ResponseHashTable.Remove(PayflowConstants.PARAM_AGGREGATEAMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_AGGREGATEOPTIONALAMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_AMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_CURRENCY);
				ResponseHashTable.Remove(PayflowConstants.PARAM_ACCT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_EXPDATE);
				ResponseHashTable.Remove(PayflowConstants.PARAM_MAXFAILPAYMENTS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_NUMFAILPAYMENTS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_RETRYNUMDAYS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_EMAIL);
				ResponseHashTable.Remove(PayflowConstants.PARAM_COMPANYNAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_NAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_FIRSTNAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_MIDDLENAME);
				ResponseHashTable.Remove("LASTNAME");
				ResponseHashTable.Remove("STREET");
				ResponseHashTable.Remove("CITY");
				ResponseHashTable.Remove("STATE");
				ResponseHashTable.Remove("ZIP");
				ResponseHashTable.Remove(PayflowConstants.PARAM_COUNTRY);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PHONENUM);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOFIRSTNAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOMIDDLENAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOLASTNAME);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOSTREET);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOCITY);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOSTATE);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOZIP);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SHIPTOCOUNTRY);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_RESULTn);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_PNREFn);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_TRANSTATEn);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_TENDERn);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_TRANSTIMEn);
				ResponseHashTable.Remove(PayflowConstants.PARAM_P_AMTn);
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