#region "Imports"

using System;
using System.Collections;
using System.Text;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Communication;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is the base class for all transaction objects. It has methods for generating the transaction request,
	/// sending it to the server and obtaining the response.
	/// For an usage of this class, please see the examples in SamplesCS + SamplesVB folders namely DOSale_Base.cs
	/// and DOSale_Base.vb.
	/// </summary>
	/// <remarks>This class can be extended to create a new transaction type.</remarks>
	/// <example>This example shows how to create and perform an Sale transaction using a Basetransaction Object.
	/// <code lang="C#" escaped="false">
	///		..........
	///		..........
	///		//Populate required data objects.
	///		..........
	///		..........
	///		
	/// //Create a new Base Transaction.
	///	BaseTransaction Trans = new BaseTransaction("S",
	///		User, Connection, Inv, Card, PayflowUtility.RequestId);
	///
	///	//Submit the transaction.
	///	Trans.SubmitTransaction();
	///	// Get the Response
	///	Response Resp = Trans.Response;
	///
	///
	///	// Display the transaction response parameters.
	///	if (Resp != null)
	///	{
	///		// Get the Transaction Response parameters.
	///		TransactionResponse TrxnResponse =  Resp.TransactionResponse;
	///
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
	///
	///		// Get the Fraud Response parameters.
	///		FraudResponse FraudResp =  Resp.FraudResponse;
	///		if (FraudResp != null)
	///		{
	///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
	///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
	///		}
    ///
    ///		// Get the Transaction Context and check for any contained SDK specific errors (optional code).
	///		Context TransCtx = Resp.TransactionContext;
	///		if (TransCtx != null &amp;&amp; TransCtx.getErrorCount() > 0)
	///		{
	///			Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString());
	///		}
	///
	///	}
	///</code>
	///<code lang="Visual Basic" escaped="false">
	///		..........
	///		..........
	///		'Populate required data objects.
	///		..........
	///		..........
	///		
	///		' Create a new Base Transaction.
	///		Dim Trans As BaseTransaction = New BaseTransaction("S", User, Connection, Inv, Card, PayflowUtility.RequestId)
	///
	///		' Submit the transaction.
	///		Trans.SubmitTransaction()
	///
	///		' Get the Response
	///		Dim Resp As Response = Trans.Response
	///
	///		If Not Resp Is Nothing Then
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
	///
	///		' Get the Fraud Response parameters.
	///		Dim FraudResp As FraudResponse = Resp.FraudResponse
	///		If Not FraudResp Is Nothing Then
	///			Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
	///			Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
	///		End If
	///
	///
	///		' Display the response.
	///		Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))
	///
	///		' Get the Transaction Context and check for any contained SDK specific errors (optional code).
	///		Dim TransCtx As Context = Resp.TransactionContext
	///		If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
	///			Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
	///		End If
	///
	///	End If
	/// </code>
	/// </example>

	public class BaseTransaction
	{
		#region "Member Variables"
		/// <summary>
		/// Arraylist of Extend Data objects. The arraylist contains objects of type ExtendData.
		/// ExtendData has a parameter name and value and is used for sending any additional parameter currently not 
		/// supported by the SDK.
		/// <seealso cref="ExtendData"/>
		/// </summary>
		private ArrayList mExtData;

		/// <summary>
		/// Type of transaction to perform, indicated by a single character.
		/// Credit payments require an ORIGID referring to an earlier Debit/Sale payment, 
		/// and the AMT must be empty or the exact amount of the original Debit/Sale payment.
		/// </summary>
		/// <remarks>
		/// Allowed TrxType values are:
		/// <list type="table">
		/// <listheader>
		/// <term>Transaction Type</term>
		/// <description>Transaction Name</description>
		/// </listheader>
		/// <item>
		/// <term>S</term>
		/// <description>Sale/Debit</description>
		/// </item>
		/// <item>
		/// <term>A</term>
		/// <description>Voice Authorization/Force</description>
		/// </item>
		/// <item>
		/// <term>C</term>
		/// <description>Credit</description>
		/// </item>
		/// <item>
		/// <term>V</term>
		/// <description>Void</description>
		/// </item>
		/// <item>
		/// <term>D</term>
		/// <description>Delayed Capture</description>
		/// </item>
		/// <item>
		/// <term>F</term>
		/// <description>Force/Voice Authorization</description>
		/// </item>
		/// <item>
		/// <term>I</term>
		/// <description>Inquiry</description>
		/// </item>
		/// <item>
		/// <term>R</term>
		/// <description>Recurring billing</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter: - <code>TRXTYPE</code></para>
		/// </remarks>
		private String mTrxType;

		/// <summary>
		/// Connection parameters to connect to the PayPal Payment Server.
		/// <seealso cref="PayflowConnectionData"/>
		/// </summary>
		private PayflowConnectionData mPayflowConnectionData;

		/// <summary>
		/// Transaction request in Name-Value Pair format.
		/// <example><code>
		/// TRXTYPE[1]=S&amp;ACCT[16]=5105105105105100&amp;EXPDATE[4]=0115&amp;TENDER[1]=C&amp;INVNUM[8]=INV12345&amp;AMT[5]=25.12
		/// &amp;PONUM[7]=PO12345&amp;STREET[23]=123 Main St.&amp;ZIP[5]=12345&amp;
		/// USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password
		/// </code>
		/// </example>
		/// </summary>
		private String mRequest;

		/// <summary>
		/// Tender object for ACH, Credit Card, PINless Debit &amp; eCheck.
		/// <remarks>
		/// Allowed Tender Types are:
		/// <list type="table">
		/// <listheader>
		/// <term>Tender Type</term>
		/// <description>Tender Name</description>
		/// </listheader>
		/// <item>
		/// <term>A</term>
		/// <description>ACH ( Automatic Clearing House )</description>
		/// </item>
		/// <item>
		/// <term>C</term>
		/// <description>Credit Card</description>
		/// </item>
		/// <item>
		/// <term>D</term>
		/// <description>PINLess Debit</description>
		/// </item>
		/// <item>
		/// <term>K</term>
		/// <description>e-Check ( TeleCheck )</description>
		/// </item>
		/// </list>
		/// <para>Each Tender type Maps to Payflow Parameter: - <code>TENDER</code></para>
		/// </remarks>
		/// <seealso cref="ACHTender"/>
		/// <seealso cref="CardTender"/>
		/// <seealso cref="CheckTender"/>
		/// </summary>
		private BaseTender mTender;

		/// <summary>
		/// Transaction invoice object. Has parameters like Amt, InvNum, BillTo, ShipTo etc.
		/// <seealso cref="Invoice"/>
		/// </summary>
		private Invoice mInvoice;

		/// <summary>
		/// Response object for the Transaction. Has objects like Transaction Response, Fraud Response, 
		/// Recurring Response etc.
		/// <seealso cref="Response"/>
		/// </summary>
		private Response mResponse;

		/// <summary>
		/// Payflow user credentials. Has parameters like User, Vendor, Partner, Password etc.
		/// <seealso cref="UserInfo"/>
		/// </summary>
		private UserInfo mUserInfo;

        /// <summary>
        /// Holds  USER1 to USER10 fields.
        /// <seealso cref="UserItem"/>
        /// </summary>
        private UserInfo mUserItem;

		/// <summary>
		/// Value (LOW, MEDIUM or HIGH) that controls the detail level and format of transaction results.
		/// LOW (default) returns normalized values. MEDIUM or HIGH return the processor's raw response values.
		/// <remarks>
		/// <para>Maps to Payflow Parameter: - <code>VERBOSITY</code></para>
		/// </remarks>
		/// </summary>
		private String mVerbosity;

		/// <summary>
		/// Context object containing the Error Objects. The context object is available to all the classes in the 
		/// SDK. The individual classes add their messages in form of Error Objects to the Context object.
		/// <seealso cref="UserInfo"/>
		/// </summary>
		private Context mContext;

		/// <summary>
		/// Unique request id for the transaction.
		/// <para>Maps to Payflow Parameter: in header - <code>PAYFLOW-REQUEST-ID</code></para>
		/// </summary>
		public String mRequestId;

		/// <summary>
		/// Request Buffer. This is used to build the request string in Name-Value pair format from Data Objects.
		/// </summary>
		private StringBuilder mRequestBuffer;

		/// <summary>
		/// Client Header Information
		/// </summary>
		private ClientInfo mClientInfo;
		/// <summary>
		/// Transaction BuyerAuthStatus object. Has parameters like Authentication_ID, AuthenticatonStatus, CAVV,XID etc.
		/// <seealso cref="BuyerAuthStatus"/>
		/// </summary>
		private BuyerAuthStatus mBuyerAuthStatus;
		
		#endregion

		#region "Properties"

		/// <summary>
		/// Gets the StringBuilder object for RequestBuffer.
		/// </summary>
		internal virtual StringBuilder RequestBuffer
		{
			get { return mRequestBuffer; }
		}


		/// <summary>
		/// Type of transaction to perform, indicated by a single character.
		/// Credit payments require an ORIGID referring to an earlier Debit/Sale payment, 
		/// and the AMT must be empty or the exact amount of the original Debit/Sale payment.
		/// Allowed TrxType values are:
		/// <list type="table">
		/// <listheader>
		/// <term>Transaction Type</term>
		/// <description>Transaction Name</description>
		/// </listheader>
		/// <item>
		/// <term>S</term>
		/// <description>Sale/Debit</description>
		/// </item>
		/// <item>
		/// <term>A</term>
		/// <description>Voice Authorization/Force</description>
		/// </item>
		/// <item>
		/// <term>C</term>
		/// <description>Credit</description>
		/// </item>
		/// <item>
		/// <term>V</term>
		/// <description>Void</description>
		/// </item>
		/// <item>
		/// <term>D</term>
		/// <description>Delayed Capture</description>
		/// </item>
		/// <item>
		/// <term>F</term>
		/// <description>Force/Voice Authorization</description>
		/// </item>
		/// <item>
		/// <term>I</term>
		/// <description>Inquiry</description>
		/// </item>
		/// <item>
		/// <term>R</term>
		/// <description>Recurring billing</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter: - <code>TRXTYPE</code></para>
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		Console.WriteLine("Transaction Type = " + Trans.TrxType);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		Console.WriteLine("Transaction Type = " + Trans.TrxType);
		/// </code>
		/// </example>
		public virtual String TrxType
		{
			get { return mTrxType; }
		}

		/// <summary>
		/// Value (LOW, MEDIUM or HIGH) that controls the detail level and format of transaction results.
		/// LOW (default) returns normalized values. MEDIUM or HIGH return the processor's raw response values.
		/// <para>Maps to Payflow Parameter: - <code>VERBOSITY</code></para>
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		Trans.Verbosity = "HIGH";
		///		Console.WriteLine("Transaction Type = " + Trans.TrxType);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		Trans.Verbosity = "HIGH"
		///		Console.WriteLine("Transaction Type = " + Trans.TrxType)
		/// </code>
		/// </example>		
		public virtual String Verbosity
		{
			get { return mVerbosity; }
			set { mVerbosity = value; }
		}

		/// <summary>
		/// Gets/sets the context object
		/// of the current transaction.
		/// </summary>
		internal virtual Context Context
		{
			get { return mContext; }
			set { mContext = value; }
		}

		/// <summary>
		/// Gets the transaction response object.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		//Submit the transaction.
		///		Trans.SubmitTransaction();
		///		
		///		// Get the Response.
		///		Response Resp = Trans.Response;
		///		if (Resp != null)
		///		{
		///			// Get the Transaction Response parameters.
		///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///			if (TrxnResponse != null)
		///			{
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
		///			}
		///		}
		///		// Get the Context and check for any contained SDK specific errors.
		///		Context Ctx = Resp.TransactionContext;
		///		if (Ctx != null ++ Ctx.getErrorCount() > 0)
		///		{
		///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
		///		}	
		///</code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		' Submit the transaction.
		///		Trans.SubmitTransaction()
		///
		///		' Get the Response.
		///		Dim Resp As Response = Trans.Response
		///		
		///		If Not Resp Is Nothing Then
		///		' Get the Transaction Response parameters.
		///		
		///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///			
		///			If Not TrxnResponse Is Nothing Then
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
		///			End If
		///		End If
		///
		///		' Get the Context and check for any contained SDK specific errors.
		///		Dim Ctx As Context = Resp.TransactionContext
		///		
		///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
		///		End If												
		/// </code>
		/// </example>		
		public virtual Response Response
		{
			get { return mResponse; }
		}

		/// <summary>
		/// Gets the extend data list.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		ArrayList ExtDataList = Trans.ExtendData;
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		Dim ExtDataList as ArrayList = Trans.ExtendData
		/// </code>
		/// </example>
		public virtual ArrayList ExtendData
		{
			get { return mExtData; }
		}

		/// <summary>
		/// Gets the transaction request.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		Console.WriteLine("Transaction Request = " + Trans.Request);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		Console.WriteLine("Transaction Request = " + Trans.Request)
		/// </code>
		/// </example>
		public virtual String Request
		{
			get { return mRequest; }
		}

		/// <summary>
		/// Gets the Tender Object.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		BaseTender Tender = Trans.Tender;
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		Dim Tender as BaseTender = Trans.Tender
		/// </code>
		/// </example>
		public virtual BaseTender Tender
		{
			get { return mTender; }
		}

		/// <summary>
		/// Gets,Sets the RequestId for
		/// the transaction.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		//A unique RequestId can be generated
		///		//using the 
		///		<see cref="PayflowUtility.RequestId">PayflowUtility.RequestId</see>
		///		//property. 
		///		............
		///		Trans.RequestId = PayflowUtility.RequestId;
		///		Console.WriteLine("Transaction RequestId = " + Trans.RequestId);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		'A unique RequestId can be generated
		///		'using the 
		///		<see cref="PayflowUtility.RequestId">PayflowUtility.RequestId</see>
		///		'property. 
		///		............
		///		Trans.RequestId = PayflowUtility.RequestId
		///		Console.WriteLine("Transaction RequestId = " + Trans.RequestId)
		/// </code>
		/// </example>		
		public virtual String RequestId
		{
			get { return mRequestId; }
			set { mRequestId = value; }
		}

		/// <summary>
		/// Gets , sets Client Information object.
		/// </summary>
		public ClientInfo ClientInfo
		{
			get { return mClientInfo; }
			set { mClientInfo = value; }
		}

		/// <summary>
        /// Gets, sets BuyerAuthStatus object.
		/// </summary>
        public BuyerAuthStatus BuyerAuthStatus
		{
			get {return mBuyerAuthStatus;}
			set {mBuyerAuthStatus = value;}
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// protected Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		protected BaseTransaction()
		{
			mRequestBuffer = new StringBuilder();
			mContext = new Context();
			mContext.LoadLoggerErrs = true; 
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, 
			UserInfo UserInfo, 
			PayflowConnectionData PayflowConnectionData, 
			String RequestId) : this()
		{
			mTrxType = TrxType;
			mUserInfo = UserInfo;
			mPayflowConnectionData = PayflowConnectionData;
			mRequestId = RequestId;
			if (mUserInfo != null)
			{
				mUserInfo.Context = mContext;

			}
			if (mPayflowConnectionData != null)
			{
				if (mPayflowConnectionData.Context != null && mPayflowConnectionData.Context.IsErrorContained())
				{
					mContext.AddErrors(mPayflowConnectionData.Context.GetErrors());
				}
			}
		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, 
			UserInfo UserInfo, 
			String RequestId) : this()
		{
			mTrxType = TrxType;
			mUserInfo = UserInfo;
			mRequestId = RequestId;
			if (mUserInfo != null)
			{
				mUserInfo.Context = mContext;

			}
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, 
			UserInfo UserInfo, 
			PayflowConnectionData PayflowConnectionData, 
			Invoice Invoice, 
			String RequestId) : this(TrxType, UserInfo, PayflowConnectionData, RequestId)
		{
			mInvoice = Invoice;
			if (mInvoice != null)
			{
				mInvoice.Context = mContext;
			}

		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, 
			UserInfo UserInfo, 
			Invoice Invoice, 
			String RequestId) : this(TrxType,UserInfo, null,Invoice,RequestId)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, UserInfo UserInfo,
		                       PayflowConnectionData PayflowConnectionData, Invoice Invoice,
		                       BaseTender Tender, String RequestId) : this(TrxType, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
			mTender = Tender;
			if (mTender != null)
			{
				mTender.Context = mContext;
				mTender.RequestBuffer = mRequestBuffer;
			}
		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object such as  Card Tender.</param>
		/// <param name="RequestId">Request Id</param>
		public BaseTransaction(String TrxType, UserInfo UserInfo,
			Invoice Invoice,
			BaseTender Tender, String RequestId) : this(TrxType, UserInfo, null, Invoice, Tender, RequestId)
		{
		}


		#endregion

		#region "Core functions"
		/// <summary>
		/// This method submits the transaction
		/// to the PayPal Payment Gateway.
		/// The response is obtained from the gateway
		/// and response object is populated with the
		/// response values along with the sdk specific
		/// errors in context, if any.
		/// </summary>
		/// <returns>Returns response object for Strong assembly transactions</returns>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		//Submit the transaction.
		///		Trans.SubmitTransaction();
		///		
		///		// Get the Response.
		///		Response Resp = Trans.Response;
		///		if (Resp != null)
		///		{
		///			// Get the Transaction Response parameters.
		///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
		///			if (TrxnResponse != null)
		///			{
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
		///			}
		///			// Get the Fraud Response parameters.
		///			FraudResponse FraudResp =  Resp.FraudResponse;
		///			if (FraudResp != null)
		///			{
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
		///			}
		///		}
		///		// Get the Context and check for any contained SDK specific errors.
		///		Context Ctx = Resp.TransactionContext;
		///		if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
		///		{
		///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
		///		}	
		///</code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		' Submit the transaction.
		///		Trans.SubmitTransaction()
		///
		///		' Get the Response.
		///		Dim Resp As Response = Trans.Response
		///		
		///		If Not Resp Is Nothing Then
		///		' Get the Transaction Response parameters.
		///		
		///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
		///			
		///			If Not TrxnResponse Is Nothing Then
		///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
		///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
		///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
		///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
		///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
		///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
		///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
		///			End If
		///
		///			' Get the Fraud Response parameters.
		///			Dim FraudResp As FraudResponse = Resp.FraudResponse
		///			If Not FraudResp Is Nothing Then
		///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
		///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
		///			End If
		///		End If
		///
		///		' Get the Context and check for any contained SDK specific errors.
		///		Dim Ctx As Context = Resp.TransactionContext
		///		
		///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
		///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
		///		End If												
		/// </code>
		/// </example>
		public virtual Response SubmitTransaction()
		{
			PayflowNETAPI PfProNetApi=null;
			String ResponseValue=null;
			bool Fatal= false;
			Logger.Instance.Log("##### BEGIN TRANSACTION ##### -- " + mRequestId, PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.Transactions.BaseTransaction.SubmitTransaction(): Entered", PayflowConstants.SEVERITY_DEBUG);
			try
			{
				if(mClientInfo == null)
				{
					mClientInfo = new ClientInfo();
				}
				//Check for the errors in the context now.
				ArrayList Errors = PayflowUtility.AlignContext(mContext,false);
				mContext.LoadLoggerErrs = false;
				mContext.ClearErrors();
				mContext.AddErrors(Errors);

				if (mContext.HighestErrorLvl
					== PayflowConstants.SEVERITY_FATAL)
				{
					Logger.Instance.Log("PayPal.Payments.Transactions.BaseTransaction.SubmitTransaction(): Exiting", PayflowConstants.SEVERITY_DEBUG);
					Fatal = true;
				}
				if (!Fatal)
				{
					GenerateRequest();

					mRequest = RequestBuffer.ToString();


					//Remove the trailing PayflowConstants.DELIMITER_NVP;
					int ParmListLen = mRequest.Length;
					if( ParmListLen > 0 && mRequest[ParmListLen - 1] == '&')
					{
						mRequest = mRequest.Substring(0,ParmListLen -1);
					}


					//Call the api from here and submit transaction
				
					if (mPayflowConnectionData != null)
					{
						PfProNetApi = new PayflowNETAPI(mPayflowConnectionData.HostAddress,
							mPayflowConnectionData.HostPort,
							mPayflowConnectionData.TimeOut,
							mPayflowConnectionData.ProxyAddress,
							mPayflowConnectionData.ProxyPort,
							mPayflowConnectionData.ProxyLogon,
							mPayflowConnectionData.ProxyPassword);
					}
					else
					{
						PfProNetApi = new PayflowNETAPI();
					}

					PfProNetApi.IsStrongAssemblyTransaction = true;
					PfProNetApi.ClientInfo = mClientInfo;
					ResponseValue = PfProNetApi.SubmitTransaction(mRequest, mRequestId);
				
					Logger.Instance.Log("PayPal.Payments.Transactions.BaseTransaction.SubmitTransaction(): Exiting", PayflowConstants.SEVERITY_DEBUG);
					Logger.Instance.Log("##### END TRANSACTION ##### -- " + mRequestId, PayflowConstants.SEVERITY_INFO);
				}
			}
			catch (BaseException BaseEx)
			{
				ErrorObject Error = BaseEx.GetFirstErrorInExceptionContext();
				//ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE,BaseEx,PayflowConstants.SEVERITY_FATAL,false, null);
				mContext.AddError(Error);
			}
			catch (Exception Ex)
			{
				TransactionException TransEx = new TransactionException(Ex);
				ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE,TransEx,PayflowConstants.SEVERITY_FATAL,false, null);
				mContext.AddError(Error);
			}
			finally
			{
				if(PfProNetApi != null)
				{
					mRequest = PfProNetApi.TransactionRequest;
					mContext.AddErrors(PfProNetApi.TransactionContext.GetErrors());
					mRequestId = PfProNetApi.RequestId;
					mClientInfo = PfProNetApi.ClientInfo;
				}
				else
				{
					//There is some error due to which the return
					//is called even before pfpronetapi object is
					//created.
					//Check the first fatal error in context and
					//put its response value to string.
					if(mRequest != null && mRequest.Length > 0 )
					{
						mRequest = PayflowUtility.MaskSensitiveFields(mRequest);
					}
					ArrayList ErrorList = mContext.GetErrors(PayflowConstants.SEVERITY_FATAL);
					ErrorObject FirstFatalError = (ErrorObject)ErrorList[0];
					ResponseValue = FirstFatalError.ToString();
				}
				
				mResponse = new Response(mRequestId ,mContext);
				mResponse.setRequestString(mRequest);
				mResponse.SetParams(ResponseValue);
				

				//Log the context
				if (mContext.IsErrorContained())
				{
					mContext.LogErrors();
				}
				PfProNetApi = null;
			}
			return mResponse;
		}

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal virtual void GenerateRequest()
		{
			Logger.Instance.Log("PayPal.Payments.Transactions.BaseTransaction.GenerateRequest(): Entered", PayflowConstants.SEVERITY_DEBUG);
			try
			{
				mRequestBuffer = new StringBuilder();
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TRXTYPE, mTrxType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VERBOSITY, mVerbosity));
				if (mExtData != null && mExtData.Count > 0)
					foreach (ExtendData Ed in mExtData)
					{
						if (Ed != null)
						{
							Ed.RequestBuffer = mRequestBuffer;
							Ed.GenerateRequest();
						}
					}
				if (mTender != null)
				{
					mTender.RequestBuffer = mRequestBuffer;
					mTender.GenerateRequest();
				}
				if (mInvoice != null)
				{
					mInvoice.RequestBuffer = mRequestBuffer;
					mInvoice.GenerateRequest();
				}
				if (mUserInfo != null)
				{
					mUserInfo.RequestBuffer = mRequestBuffer;
					mUserInfo.GenerateRequest();
				}
                if (mUserItem != null)
                {
                    mUserItem.RequestBuffer = mRequestBuffer;
                    mUserItem.GenerateRequest();
                }
				if (mBuyerAuthStatus != null)
				{
					mBuyerAuthStatus.RequestBuffer = mRequestBuffer;
					mBuyerAuthStatus.GenerateRequest();
				}
				Logger.Instance.Log("PayPal.Payments.Transactions.BaseTransaction.GenerateRequest(): Exiting", PayflowConstants.SEVERITY_DEBUG);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TE = new TransactionException(Ex);
				throw TE;
			}
		}

		#endregion

		#region "Extend Data Related Methods"

		/// <summary>
		/// Adds an Extend Data object to 
		/// the extend data list held by transaction
		/// object.
		/// </summary>
		/// <param name="ExtData">Extend Data object to be added.</param>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		//Create an object of <see cref="PayPal.Payments.DataObjects.ExtendData">ExtendData</see>
		///		ExtendData ExtData = new ExtendData("PFPRO_PARAM_NAME","Param Value");
		///		
		///		//Add to Transaction Extend Data list.
		///		Trans.AddToExtendData(ExtData);
		///		
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		
		///		'Create an object of <see cref="PayPal.Payments.DataObjects.ExtendData">ExtendData</see>
		///		Dim ExtData as ExtendData = new ExtendData("PFPRO_PARAM_NAME","Param Value")
		///		
		///		'Add to Transaction Extend Data list.
		///		Trans.AddToExtendData(ExtData)
		///		
		/// </code>
		/// </example>
		public virtual void AddToExtendData(ExtendData ExtData)
		{
			if (mExtData == null)
			{
				mExtData = new ArrayList();
			}
			if (ExtData != null)
			{
				ExtData.Context = Context;
				ExtData.RequestBuffer = mRequestBuffer;
				mExtData.Add(ExtData);
			}
		}

		/// <summary>
		/// Clears the Extend Data list held by 
		/// transaction object.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		//Trans is the transaction object.
		///		............
		///		
		///		//Clear Transaction Extend Data list.
		///		Trans.ClearExtendData();
		///		
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		'Trans is the transaction object.
		///		............
		///		
		///		'Clear Transaction Extend Data list.
		///		Trans.ClearExtendData()
		///		
		/// </code>
		/// </example>
		public virtual void ClearExtendData()
		{
			if (mExtData != null)
			{
				mExtData.Clear();
			}
		}

		#endregion


		#region "Client Header related methods"
		/// <summary>
		/// Adds a transaction header
		/// </summary>
		/// <param name="HeaderName">Header name</param>
		/// <param name="HeaderValue">Header value</param>
		public void AddTransHeader(String HeaderName,String HeaderValue)
		{
			AddHeader(HeaderName,HeaderValue);
		}

		/// <summary>
		/// Adds a header
		/// </summary>
		/// <param name="HeaderName">Header name</param>
		/// <param name="HeaderValue">Header value</param>
		private void AddHeader(String HeaderName,String HeaderValue)
		{
			if(mClientInfo == null)
			{
				mClientInfo = new ClientInfo();
			}

			mClientInfo.AddHeaderToHash(HeaderName,HeaderValue);

		}

		/// <summary>
		/// Removes a Transaction header
		/// </summary>
		/// <param name="HeaderName">Header Name</param>
		public void RemoveTransHeader(String HeaderName)
		{
			RemoveHeader(HeaderName);
		}


		/// <summary>
		/// Removes a header
		/// </summary>
		/// <param name="HeaderName">Header Name</param>
		private void RemoveHeader(String HeaderName)
		{
			if(mClientInfo != null)
			{
				if(mClientInfo.ClientInfoHash.ContainsKey(HeaderName))
				{
					mClientInfo.ClientInfoHash.Remove(HeaderName);
				}

			}
		}
		#endregion
	}
}