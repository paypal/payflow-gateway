#region "Imports"

using System;
using System.Xml;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using System.Text;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// This is the abstract Base class for all payment states.
	/// </summary>
	abstract internal class PaymentState
	{
		#region "Member Variables"

		/// <summary>
		/// This is the default XMLPay namespace.
		/// </summary>
		/// <remarks>
		/// <para>Maps to default value:
		/// <code>http://www.paypal.com/XMLPay</code></para>
		/// </remarks>
		private String mDefaultXmlNameSpace;

		/// <summary>
		/// Payflow XMLPay namespace.
		/// </summary>
		private String PFProXmlNameSpace;

		/// <summary>
		/// Param list content type.
		/// </summary>
		/// <remarks>
		/// Allowed content types are:
		/// <list type="table">
		/// <listheader>
		/// <term>Content Type</term>
		/// <description>Expected Value</description>
		/// </listheader>
		/// <item>
		/// <term>Name Value Pair</term>
		/// <description>text/namevalue</description>
		/// </item>
		/// <item>
		/// <term>XML Pay</term>
		/// <description>text/xml</description>
		/// </item>
		/// </list>
		/// <para>Maps to HTTP Header <code>CONTENT-TYPE</code></para>
		/// </remarks>
		private String mContentType;

		/// <summary>
		/// Connection object.
		/// </summary>
		/// <remarks>This connection object takes care of
		/// initializing, connecting, sending and receiving data
		/// from the Payflow server.
		/// <seealso cref="PaymentConnection"/>
		/// </remarks>
		protected internal PaymentConnection mConnection;

		/// <summary>
		/// Parameter List.
		/// </summary>
		/// <remarks>This is the parameter list in Name-Value Pair or XMLPay format.</remarks>
		protected internal String mParameterList;

		/// <summary>
		/// Transaction Request.
		/// </summary>
		/// <remarks>Transaction Request in Name-Value Pair or XMLPay format.</remarks>
		private String mTransactionRequest;

		/// <summary>
		/// Transaction Response.
		/// </summary>
		/// <remarks>Transaction Response in Name-Value Pair or XMLPay format.</remarks>
		private String mTransactionResponse;


		/// <summary>
		/// Retry Attempt number.
		/// </summary>
		/// <remarks>This retry number is the current retry attempt. The maximum number of
		/// retries allowed are given by constant MAX_RETRY in PayflowConstants.</remarks>
		/// <seealso paramref="PayflowConstants.MAX_RETRY"/>
		protected int mAttemptNo;

		/// <summary>
		/// In Progress flag.
		/// </summary>
		/// <remarks>This indicates whether the current transaction is in progress or not.
		/// True indicates in progress, false otherwise.</remarks>
		private bool mInProgress = true;

		/// <summary>
		/// State executed flag.
		/// </summary>
		/// <remarks>This indicates whether the current state has finished its execution.
		/// True indicates executed, false otherwise.</remarks>
		private bool mStateExecuted;

		/// <summary>
		/// State Success flag.
		/// </summary>
		/// <remarks>This indicates whether the current state has succeeded.
		/// True indicates succeeded, false otherwise.</remarks>
		private bool mStateSucceeded;

		/// <summary>
		/// Context object.
		/// </summary>
		/// <remarks>This is the context object which is passed by reference in the constructor. This is to 
		/// maintain a single context across the whole transaction.</remarks>
		private Context mContext;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets the connection object.
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		PaymentConnection Connection = 
		///							CurrentPaymentState.Connection;
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Dim Connection As PaymentConnection = 
		///							CurrentPaymentState.Connection
		/// </code>
		/// </example>
		virtual public PaymentConnection Connection
		{
			get { return this.mConnection; }

		}

		/// <summary>
		/// Gets the param list.
		/// </summary>
		/// <remarks>This is the parameter list in Name-Value Pair or XMLPay format.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		Console.WriteLine("Parameter List = " + CurrentPaymentState.ParameterList);
		///		
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Console.WriteLine("Parameter List = " + CurrentPaymentState.ParameterList)
		///		
		/// </code>
		/// </example>
		virtual public String ParameterList
		{
			get { return this.mParameterList; }

		}

		/// <summary>
		/// Gets, Sets the transaction Request.
		/// </summary>
		/// <remarks>Transaction Request in Name-Value Pair or XMLPay format.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		CurrentPaymentState.TransactionRequest = 
		///			"TRXTYPE[1]=S&amp;ACCT[16]=5105105105105100&amp;EXPDATE[4]=0115&amp;TENDER[1]=C&amp;INVNUM[8]=INV12345&amp;AMT[5]=25.12
		/// 		&amp;PONUM[7]=PO12345&amp;STREET[23]=123 Main St.&amp;ZIP[5]=12345&amp;
		/// 		USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
		///				
		///		Console.WriteLine("Transaction Request = " + CurrentPaymentState.TransactionRequest);
		///				
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		CurrentPaymentState.TransactionRequest = 
		///			"TRXTYPE[1]=S&amp;ACCT[16]=5105105105105100&amp;EXPDATE[4]=0115&amp;TENDER[1]=C&amp;INVNUM[8]=INV12345&amp;AMT[5]=25.12
		/// 		&amp;PONUM[7]=PO12345&amp;STREET[23]=123 Main St.&amp;ZIP[5]=12345&amp;
		/// 		USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
		///				
		///		Console.WriteLine("Transaction Request = " + CurrentPaymentState.TransactionRequest)
		///		
		/// </code>
		/// </example>
		virtual public String TransactionRequest
		{
			get { return this.mTransactionRequest; }
			set { mTransactionRequest = value; }

		}

		/// <summary>
		/// Gets, Sets the transaction response.
		/// </summary>
		/// <remarks>Transaction Response in Name-Value Pair or XMLPay format.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		CurrentPaymentState.TransactionResponse = 
		///			"RESULT=0&amp;PNREF=XXXXXXXXXXXX&amp;RESPMSG=Approved";
		///			
		///		Console.WriteLine("Transaction Response = " + CurrentPaymentState.TransactionResponse);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		CurrentPaymentState.TransactionResponse = 
		///			"RESULT=0&amp;PNREF=XXXXXXXXXXXX&amp;RESPMSG=Approved"
		///			
		///		Console.WriteLine("Transaction Response = " + CurrentPaymentState.TransactionResponse)
		/// </code>
		/// </example>
		virtual public String TransactionResponse
		{
			get { return this.mTransactionResponse; }
			set { this.mTransactionResponse = value; }
		}


		/// <summary>
		/// Gets the retry attempt no.
		/// </summary>
		/// <remarks>This retry number is the current retry attempt. The maximum number of
		/// retries allowed are given by constant MAX_RETRY in PayflowConstants.</remarks>
		/// <seealso paramref="PayflowConstants.MAX_RETRY"/>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		int CurrentAttempt = CurrentPaymentState.AttemptNo;
		///		
		///		Console.WriteLine("Current Attempt Number = {0}",CurrentAttempt);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Dim CurrentAttempt As Integer = CurrentPaymentState.AttemptNo
		///		
		///		Console.WriteLine("Current Attempt Number = " + CurrentAttempt)
		/// </code>
		/// </example>
		virtual public int AttemptNo
		{
			get { return this.mAttemptNo; }

		}

		/// <summary>
		/// Gets the param list content type.
		/// </summary>
		/// <remarks>
		/// Allowed content types are:
		/// <list type="table">
		/// <listheader>
		/// <term>Content Type</term>
		/// <description>Expected Value</description>
		/// </listheader>
		/// <item>
		/// <term>Name Value Pair</term>
		/// <description>text/namevalue</description>
		/// </item>
		/// <item>
		/// <term>XML Pay</term>
		/// <description>text/xml</description>
		/// </item>
		/// </list>
		/// <para>Maps to HTTP Header <code>CONTENT-TYPE</code></para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		Console.WriteLine("Request Content Type = " + CurrentPaymentState.ContentType);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Console.WriteLine("Request Content Type = " + CurrentPaymentState.ContentType)
		/// </code>
		/// </example>
		virtual public String ContentType
		{
			get { return this.mContentType; }

		}

		/// <summary>
		/// Gets the XmlPay Request type flag.
		/// </summary>
		/// <remarks>This indicates whether the transaction request is of type Name-Value pair or
		/// XMLPay request. True if XMLPay request, false if Name-Value pair.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.IsXmlPayRequest)
		///		{
		///			Console.WriteLine("Request Type = XML Pay request");
		///		}
		///		else
		///		{
		///			Console.WriteLine("Request Type = Name-value pair request");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.IsXmlPayRequest)
		///		{
		///			Console.WriteLine("Request Type = XML Pay request")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("Request Type = Name-value pair request")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		virtual public bool IsXmlPayRequest
		{
			get { return mConnection.IsXmlPayRequest; }

		}

		/// <summary>
		/// Gets the Default Xml Namespace.
		/// </summary>
		/// <remarks>
		/// <para>Maps to default value:
		/// <code>http://www.paypal.com/XMLPay</code></para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		
		///		Console.WriteLine("Default Xml Namespace = " + CurrentPaymentState.DefaultXmlNameSpace);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Console.WriteLine("Default Xml Namespace = " + CurrentPaymentState.DefaultXmlNameSpace)
		/// </code>
		/// </example>
		virtual public String DefaultXmlNameSpace
		{
			get { return this.mDefaultXmlNameSpace; }

		}

		/// <summary>
		/// Gets the Context Object.
		/// </summary>
		/// <remarks>This is the context object which is passed by reference in the constructor. This is to 
		/// maintain a single context across the whole transaction.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		
		///		Context CommContext = CurrentPaymentState.CommContext;
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Dim CommContext As Context = CurrentPaymentState.CommContext
		/// </code>
		/// </example>
		internal virtual Context CommContext
		{
			get { return mContext; }
		}

		/// <summary>
		/// Checks if the Request has Request Id value.
		/// </summary>
		/// <returns>True if Request id is Found, False otherwise.</returns>
		/// <remarks>This indicates whether request id is obtained, true if obtained, false otherwise.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.HaveRequestId)
		///		{
		///			Console.WriteLine("RequestId obtained.");
		///		}
		///		else
		///		{
		///			Console.WriteLine("RequestId not obtained.");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.HaveRequestId)
		///		{
		///			Console.WriteLine("RequestId obtained.")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("RequestId not obtained.")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		private bool HaveRequestId
		{
			get
			{
				if (this.mConnection.RequestId == null ||
					this.mConnection.RequestId.Length == 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		/// <summary>
		/// Gets Xml Name Space
		/// </summary>
		/// <returns>Xml Name Space Value.</returns>
		/// <remarks>This gives the Xml namespace value for the current transaction. 
		/// Generally, this is set to default namespace value i.e.
		/// <code>http://www.paypal.com/XMLPay</code>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		
		///		Console.WriteLine("Xml Namespace = " + CurrentPaymentState.XmlNameSpace);
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		' CurrentPaymentState is the
		///		' PaymentState object.
		///		
		///		Console.WriteLine("Xml Namespace = " + CurrentPaymentState.XmlNameSpace)
		/// </code>
		/// </example>
		public virtual String XmlNameSpace
		{
			get { return this.PFProXmlNameSpace; }
		}

		/// <summary>
		/// Checks if Response is obtained.
		/// </summary>
		/// <returns>True if Response if obtained, False otherwise.</returns>
		/// <remarks>This indicates whether response is obtained. True if obtained, false otherwise.</remarks>
		public virtual bool HasResponse
		{
			get { return (this.mTransactionResponse != null); }
		}

		/// <summary>
		/// Indicates if transaction is in progress.
		/// </summary>
		/// <returns>True if in progress, False otherwise.</returns>
		/// <remarks>This indicates whether the current transaction is in progress or not.
		/// True indicates in progress, false otherwise.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.InProgress)
		///		{
		///			Console.WriteLine("Transaction in progress.");
		///		}
		///		else
		///		{
		///			Console.WriteLine("Transaction not in progress.");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.InProgress)
		///		{
		///			Console.WriteLine("Transaction in progress.")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("Transaction not in progress.")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		public virtual bool InProgress
		{
			get { return this.mInProgress; }
		}

		/// <summary>
		/// Indicates current state success..
		/// <remarks>This indicates whether the current state has succeeded.
		/// True indicates succeeded, false otherwise.</remarks>
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.Success)
		///		{
		///			Console.WriteLine("Current state succeeds.");
		///		}
		///		else
		///		{
		///			Console.WriteLine("Current state does not succeed.");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.Success)
		///		{
		///			Console.WriteLine("Current state succeeds.")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("Current state does not succeed.")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		public virtual bool Success
		{
			get { return (this.mStateExecuted && this.mStateSucceeded); }
		}

		/// <summary>
		/// Current state failure.
		/// <remarks>This indicates whether the current state has failed.
		/// True indicates failed, false otherwise.</remarks>
		/// </summary>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.Failed)
		///		{
		///			Console.WriteLine("Current state fails.");
		///		}
		///		else
		///		{
		///			Console.WriteLine("Current state does not fail.");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.Failed)
		///		{
		///			Console.WriteLine("Current state fails.")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("Current state does not fail.")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		public virtual bool Failed
		{
			get { return (this.mStateExecuted && !this.mStateSucceeded); }
		}

		/// <summary>
		/// Returns state executed.
		/// </summary>
		/// <example>
		/// <remarks>This indicates whether the current state has finished its execution.
		/// True indicates executed, false otherwise.</remarks>
		/// <code lang="C#" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		if(CurrentPaymentState.HasExecuted)
		///		{
		///			Console.WriteLine("Current State has finished execution.");
		///		}
		///		else
		///		{
		///			Console.WriteLine("Current State has not finished execution.");
		///		}
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		............
		///		// CurrentPaymentState is the
		///		// PaymentState object.
		///		
		///		If(CurrentPaymentState.HasExecuted)
		///		{
		///			Console.WriteLine("Current State has finished execution.")
		///		}
		///		Else
		///		{
		///			Console.WriteLine("Current State has not finished execution.")
		///		}
		///		EndIf
		/// </code>
		/// </example>
		public virtual bool HasExecuted
		{
			get { return this.mStateExecuted; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>This is an abstract class, creating an object of PaymentState directly is not possible.</remarks>
		protected PaymentState()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(): Entered.", PayflowConstants.SEVERITY_DEBUG);
			mDefaultXmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Connection">PaymentConnection Object</param>
		/// <param name="ParamList">Parameter List</param>
		/// <param name="PsmContext">Context Object by ref</param>
		/// <remarks>This is an abstract class, creating an object of PaymentState directly is not possible.</remarks>		
		public PaymentState(PaymentConnection Connection, String ParamList, ref Context PsmContext) : this()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(PaymentConnection,String,Context): Entered.", PayflowConstants.SEVERITY_DEBUG);

			mContext = PsmContext;
			mConnection = Connection;
			InitializeContentType(ParamList);
			


			if (mContext.HighestErrorLvl < PayflowConstants.SEVERITY_FATAL)
			{
				mConnection.ContentType = mContentType;

				if (ParamList == null || ParamList.Length == 0)
				{
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_FATAL,
					                                                 IsXmlPayRequest, null);
					mContext.AddError(Err);
				}

				this.mTransactionRequest = ParamList;

				ValidateRequestId();
			}
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(PaymentConnection,String,Context): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Copy Constructor
		/// </summary>
		/// <param name="CurrentPmtState">Current PaymentState Object.</param>
		/// <remarks>This is an abstract class, creating an object of PaymentState directly is not possible.</remarks>		
		public PaymentState(PaymentState CurrentPmtState)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(PaymentState CurrentPmtState): Entered.", PayflowConstants.SEVERITY_DEBUG);

			mDefaultXmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;
			this.mConnection = CurrentPmtState.Connection;
			this.mParameterList = CurrentPmtState.ParameterList;
			this.mTransactionRequest = CurrentPmtState.TransactionRequest;
			this.mTransactionResponse = CurrentPmtState.TransactionResponse;
			this.mConnection.RequestId = CurrentPmtState.mConnection.RequestId;
			this.mConnection.IsXmlPayRequest = CurrentPmtState.mConnection.IsXmlPayRequest;
			this.mAttemptNo = CurrentPmtState.AttemptNo;
			this.mDefaultXmlNameSpace = CurrentPmtState.mDefaultXmlNameSpace;
			this.PFProXmlNameSpace = CurrentPmtState.XmlNameSpace;
			this.mContentType = CurrentPmtState.ContentType;
			this.mContext = CurrentPmtState.CommContext;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.PaymentState(PaymentState CurrentPmtState): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		#endregion

		#region "Member Functions"


		/// <summary>
		/// Initializes the Content Type of the Request.
		/// </summary>
		/// <param name="InitialParamList">Param List.</param>
		/// <remarks>This method initializes the content type of the
		/// parameter list in the member mContentType.
		/// <para>Allowed content types are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Content Type</term>
		/// <description>Expected Value</description>
		/// </listheader>
		/// <item>
		/// <term>Name Value Pair</term>
		/// <description>text/namevalue</description>
		/// </item>
		/// <item>
		/// <term>XML Pay</term>
		/// <description>text/xml</description>
		/// </item>
		/// </list>
		/// <para>Maps to HTTP Header <code>CONTENT-TYPE</code></para>
		/// </remarks>
		private void InitializeContentType(String InitialParamList)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.InitializeContentType(String): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);

			if (InitialParamList != null)
			{
				InitialParamList = InitialParamList.TrimStart(new char[1] {' '});
				int Index = InitialParamList.IndexOf(PayflowConstants.XML_ID);
				if (Index >= 0 && InitialParamList.IndexOf("<") == 0)
				{
					mConnection.IsXmlPayRequest = true;
					mContentType = PayflowConstants.XML_CONTENT_TYPE;
					PFProXmlNameSpace = PayflowUtility.GetXmlNameSpace(InitialParamList);
				}
				else
				{
					mConnection.IsXmlPayRequest = false;
					mContentType = PayflowConstants.NV_CONTENT_TYPE;
				}
			}
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.InitializeContentType(String): ContentType = " + mContentType,
			                    PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.InitializeContentType(String): Exiting.",
			                    PayflowConstants.SEVERITY_DEBUG);
		}


		/// <summary>
		/// Sets the transaction complete flag.
		/// </summary>
		/// <remarks>this method sets the value of member mInProgress.
		/// This indicates whether the current transaction is in progress or not.
		/// True indicates in progress, false otherwise.</remarks>
		internal void SetProgressComplete()
		{
			this.mInProgress = false;
		}


		/// <summary>
		/// Sets transaction successful.
		/// </summary>
		/// <remarks>This sets the transaction status to success.</remarks>
		public virtual void SetTransactionSuccess()
		{
			this.SetProgressComplete();
		}


		/// <summary>
		/// Sets transaction failed.
		/// </summary>
		/// <remarks>This sets the transaction status to failed.</remarks>
		public virtual String SetTransactionFail
		{
			set
			{
				mTransactionResponse = value;
				this.SetProgressComplete();
			}
		}

		/// <summary>
		/// Sets the state success.
		/// </summary>
		/// <remarks>This sets the current state to success.</remarks>
		public virtual void SetStateSuccess()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateSuccess(): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);
			SetStateOutCome(true);
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateSuccess(): Exiting.",
			                    PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Sets state outcome.
		/// </summary>
		/// <param name="Value">True if success, false otherwise.</param>
		/// <remarks>This sets the state outcome to a desired value either true or false.</remarks>
		private void SetStateOutCome(bool Value)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateOutCome(bool): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);
			mStateExecuted = true;
			mStateSucceeded = Value;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateOutCome(bool): Exiting.",
			                    PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Sets the state failed.
		/// </summary>
		/// <remarks>This sets the current state to failed.</remarks>
		public virtual void SetStateFail()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateFail(): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);
			SetStateOutCome(false);
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.SetStateFail(): Exiting.",
			                    PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Abstract function declaration
		/// of Execute.
		/// </summary>
		/// <remarks>This is the abstract method definition of Execute. The Execute method
		/// acts as the main important method in these payment state hierarchy. this method is overridden as
		/// per the requirements in the derived classes.</remarks>
		public abstract void Execute();

		/// <summary>
		/// Validates Request Id.
		/// </summary>
		/// <returns>True if valid, false otherwise.</returns>
		private bool ValidateRequestId()
		{
			bool RetValue = false;
            if (!HaveRequestId)
            {
                ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_MISSING_REQUEST_ID, null,
                                                                 PayflowConstants.SEVERITY_FATAL, IsXmlPayRequest,
                                                                 null);
                if (!mContext.IsCommunicationErrorContained(Err))
                {
                    CommContext.AddError(Err);
                }
            }
            else
            {
                RetValue = true;
            }

			return RetValue;
		}

		
		#endregion
	}
}