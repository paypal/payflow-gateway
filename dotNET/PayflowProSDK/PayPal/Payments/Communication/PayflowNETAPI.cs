#region "Imports"

using System;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.DataObjects;
using System.Collections;
using System.Text;

#endregion

namespace PayPal.Payments.Communication
{
    /// <summary>
    /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
    /// PayPal payment gateway for online payment processing. The response 
    /// returned is the string value of the response from the PayPal payment 
    /// gateway.
    /// </summary>
    /// <remarks>Instance of PayflowNETAPI initialized with the information related 
    /// to connection to the PayPal payment gateway.
    /// If the empty constructor of this class is used to create the object or 
    /// passed values are empty, then The following values (if empty) 
    /// are looked for as follows:
    /// <list type="table">
    /// <listheader>
    /// <term>Property</term>
    /// <description>From Internal Default</description>
    /// <description>From App.config key</description>
    /// </listheader>
    /// <item>
    /// <term>Payflow Host</term>
    /// <description>NA</description>
    /// <description>PAYFLOW_HOST</description>
    /// </item>
    /// <item>
    /// <term>Payflow Port</term>
    /// <description>443</description>
    /// <description>NA</description>
    /// </item>
    /// <item>
    /// <term>Transaction timeout</term>
    /// <description>45 seconds</description>
    /// <description>NA</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code lang="C#" escaped="false">
    ///	/// ..........
    /// 	// Sample Request. 
    /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
    /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
    ///
    /// 	// Create an instance of PayflowNETAPI.
    /// 	PayflowNETAPI PayflowNetApi = new PayflowNETAPI();
    ///
    /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
    /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
    /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
    /// 	String Response = PayflowNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
    ///
    /// 	// To write the Response on to the console.
    /// 	Console.WriteLine(Environment.NewLine + "Request = " + PayflowNetApi.TransactionRequest);
    /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
    ///
    /// 	// Following lines of code are optional. 
    /// 	// Begin optional code for displaying SDK errors ...
    /// 	// It is used to read any errors that might have occurred in the SDK.
    ///
    ///	    String TransErrors = PayflowNetApi.TransactionContext.ToString();
    ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
    ///	    {
    ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
    ///	    }
    ///	   
    /// </code>
    /// <code lang="Visual Basic" escaped="false">
    ///		' Sample Request. 
    ///		' Please replace user, vendor, password &amp; partner with your merchant information.
    ///		Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
    /// 
    ///		' Create an instance of PayflowNETAPI.
    ///		Dim PayflowNetApi As PayflowNETAPI = new PayflowNETAPI
    /// 
    ///		' RequestId is a unique string that is required for each &amp; every transaction. 
    ///		' The merchant can use her/his own algorithm to generate this unique request id or 
    ///		' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
    ///		Dim Response As String = PayflowNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
    /// 
    ///		' To write the Response on to the console.
    ///		Console.WriteLine(Environment.NewLine + "Request = " + PayflowNetApi.TransactionRequest)
    ///		Console.WriteLine(Environment.NewLine + "Response = " + Response)
    /// 
    ///		' Following lines of code are optional. 
    ///		' Begin optional code for displaying SDK errors ...
    ///		' It is used to read any errors that might have occurred in the SDK.
    /// 
    ///		Dim TransErrors As String = PayflowNetApi.TransactionContext.ToString()
    ///		If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
    ///			Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
    ///		End If
    /// </code>
    ///</example>

    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Runtime.InteropServices.ClassInterface(System.Runtime.InteropServices.ClassInterfaceType.AutoDual)]
    public sealed class PayflowNETAPI
    {
        #region "Member Variables"

        /// <summary>
        /// PaymentStateMachine object.
        /// </summary>
        private PaymentStateMachine mPaymentStateMachine;

        /// <summary>
        /// Request Id
        /// </summary>
        private String mRequestId;

        /// <summary>
        /// Host Address
        /// </summary>
        private String mHostAddress;

        /// <summary>
        /// Host Port
        /// </summary>
        private int mHostPort;

        /// <summary>
        /// TimeOut
        /// </summary>
        private int mTimeOut;

        /// <summary>
        /// Proxy Address
        /// </summary>
        private String mProxyAddress;

        /// <summary>
        /// Proxy Port
        /// </summary>
        private int mProxyPort;

        /// <summary>
        /// Proxy Logon
        /// </summary>
        private String mProxyLogon;

        /// <summary>
        /// Proxy Password
        /// </summary>
        private String mProxyPassword;

        /// <summary>
        /// Transaction Context
        /// </summary>p
        private Context mTransactionContext;

        /// <summary>
        /// Transaction Request 
        /// </summary>
        private String mTransactionRequest;

        /// <summary>
        /// Transaction Response
        /// </summary>
        private String mTransactionResponse;

        /// <summary>
        /// Flag for Strong Assembly Transaction;
        /// </summary>
        private bool mIsStrongAssemblyTransaction;
        /// <summary>
        /// Flag for xml pay request
        /// </summary>
        private bool mIsXmlPayRequest = false;
        /// <summary>
        /// Transaction request withought masking
        /// </summary>
        private String mTransRqst;
        /// <summary>
        /// Client information.
        /// </summary>
        private ClientInfo mClientInfo;
        #endregion

        #region "Constructors"

        /// <summary>
        /// PayflowNETAPI Constructor
        /// </summary>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	   String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	   if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	   {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	   }
        ///	   
        ///    // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI()
            : this(null, 0, 0, null, 0, null, null)
        {
        }

        /// <summary>
        /// PayflowNETAPI Constructor
        /// </summary>
        /// <param name="HostAddress">Payflow Host Address.</param>
        /// <param name="HostPort">Payflow Host Port.</param>
        /// <param name="TimeOut">Transaction Timeout.</param>
        /// <param name="ProxyAddress">Proxy Address.</param>
        /// <param name="ProxyPort">Proxy Port.</param>
        /// <param name="ProxyLogon">Proxy Logon Id.</param>
        /// <param name="ProxyPassword">Proxy Password.</param>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI(String HostAddress, int HostPort, int TimeOut, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword)
        {
            mTransactionContext = new Context();
            SetParameters(HostAddress, HostPort, TimeOut, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword, null, null, null, null, false);
        }

        /// <summary>
        /// PayflowNETAPI Constructor
        /// </summary>
        /// <param name="HostAddress">Payflow Host Address.</param>
        /// <param name="HostPort">Payflow Host Port.</param>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI(String HostAddress, int HostPort)
            : this(HostAddress, HostPort, 0, null, 0, null, null)
        {
        }

        /// <summary>
        /// PayflowNETAPI Constructor
        /// <param name="HostAddress">Payflow Host Address.</param>
        /// <param name="HostPort">Payflow Host Port.</param>
        /// <param name="ProxyAddress">Proxy Address.</param>
        /// <param name="ProxyPort">Proxy Port.</param>
        /// <param name="ProxyLogon">Proxy Logon Id.</param>
        /// <param name="ProxyPassword">Proxy Password.</param>
        ///</summary>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI(String HostAddress, int HostPort, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword)
            : this(HostAddress, HostPort, 0, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword)
        {
        }

        /// <summary>
        /// PayflowNETAPI Constructor
        /// </summary>
        /// <param name="HostAddress">Payflow Host Address.</param>
        /// <param name="HostPort">Payflow Host Port.</param>
        /// <param name="TimeOut">Transaction Timeout.</param>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI(String HostAddress, int HostPort, int TimeOut)
            : this(HostAddress, HostPort, TimeOut, null, 0, null, null)
        {
        }

        /// <summary>
        ///  PayflowNETAPI Constructor
        /// </summary>
        /// <param name="HostAddress">Payflow Host Address.</param>
        /// <summary>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>PAYFLOW_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction timeout</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PfProNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PfProNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	    	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        /// ' Sample Request. 
        /// ' Please replace user, vendor, password &amp; partner with your merchant information.
        /// Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        /// ' Create an instance of PayflowNETAPI.
        /// Dim PfProNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        /// ' RequestId is a unique string that is required for each &amp; every transaction. 
        /// ' The merchant can use her/his own algorithm to generate this unique request id or 
        /// ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        /// Dim Response As String = PfProNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        /// ' To write the Response on to the console.
        /// Console.WriteLine(Environment.NewLine + "Request = " + PfProNetApi.TransactionRequest)
        /// Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        /// ' Following lines of code are optional. 
        /// ' Begin optional code for displaying SDK errors ...
        /// ' It is used to read any errors that might have occurred in the SDK.
        /// 
        /// Dim TransErrors As String = PfProNetApi.TransactionContext.ToString()
        /// If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///   Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        /// End If
        /// 
        /// 'End optional code for displaying SDK errors.
        /// </code>
        ///</example>
        public PayflowNETAPI(String HostAddress)
            : this(HostAddress, 0, 0, null, 0, null, null)
        {
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets the Request Id.
        /// </summary>

            public String RequestId
            {
                get { return mRequestId; }
            }


        /// <summary>
        /// Gets the Transaction Context object.
        /// </summary>

        public Context TransactionContext
        {
            get { return mTransactionContext; }
        }

        /// <summary>
        /// Gets the Transaction response.
        /// </summary>

        public String TransactionResponse
        {
            get { return mTransactionResponse; }
        }

        /// <summary>
        /// Gets the Transaction request.
        /// </summary>


        public String TransactionRequest
        {
            get { return mTransactionRequest; }
        }

        /// <summary>
        /// Gets, Sets flag for Strong Assembly
        /// Transaction.
        /// </summary>

        internal bool IsStrongAssemblyTransaction
        {
            get { return mIsStrongAssemblyTransaction; }
            set { mIsStrongAssemblyTransaction = value; }
        }

        /// <summary>
        /// Gets the PayflowNETAPI Client Version.
        /// </summary>

        public String Version
        {
            get { return PayflowConstants.CLIENT_TYPE + PayflowConstants.CLIENT_VERSION; }
        }

        internal bool IsXmlPayRequest
        {
            get { return mIsXmlPayRequest; }
            set { mIsXmlPayRequest = value; }
        }

        /// <summary>
        /// Client information.
        /// </summary>
        [System.Runtime.InteropServices.ComVisible(false)]
        public ClientInfo ClientInfo
        {
            get { return mClientInfo; }
            set { mClientInfo = value; }
        }

        #endregion

        #region "Functions"
        /// <summary>
        /// SetParameters will be used to initialize the different parameters passed by the user. This has been kept 
        /// as a public function since this needs to be called by the COM implementation. This is an undocumented 
        /// functionionality which the pure dotNET client are not suppose to use.
        /// </summary>
        public void SetParameters(String HostAddress,
            int HostPort,
            int TimeOut,
            String ProxyAddress,
            int ProxyPort,
            String ProxyLogon,
            String ProxyPassword,
            String Trace,
            String LogLevel,
            String LogFileName,
            String LogFileSize,
            bool WrapperIsCOM)
        {
            mTransactionContext.ClearErrors();
            if (WrapperIsCOM)
            {
                PayflowConstants.TRACE = Trace;
                PayflowUtility.TraceInitialized = true;
                Logger.SetInstance(LogLevel, LogFileName, LogFileSize, WrapperIsCOM);
            }

            if (HostAddress != null)
            {
                mHostAddress = HostAddress.Trim();
            }

            mHostPort = HostPort;
            mTimeOut = TimeOut;

            if (ProxyAddress != null)
            {
                mProxyAddress = ProxyAddress.Trim();
            }

            mProxyPort = ProxyPort;

            if (ProxyLogon != null)
            {
                mProxyLogon = ProxyLogon.Trim();
            }

            if (ProxyPassword != null)
            {
                mProxyPassword = ProxyPassword.Trim();
            }

            InitDefaultValues();
        }

        /// <summary>
        /// <para>Submits a transaction to Payflow Server.</para>
        /// PayflowNETAPI is used to submit a Name-value pair or XMLPay request to
        /// PayPal payment gateway for online payment processing. The response 
        /// returned is the string value of the response from the PayPal payment 
        /// gateway.
        /// </summary>
        /// <param name="ParamList">Parameter list.</param>
        /// <param name="RequestId">Request Id</param>
        /// <returns>String value of transaction response.</returns>
        /// <remarks>Instance of PayflowNETAPI initialized with the information related 
        /// to connection to the PayPal payment gateway.
        /// If the empty constructor of this class is used to create the object or 
        /// passed values are empty, then The following values (if empty) 
        /// are looked for as follows:
        /// <list type="table">
        /// <listheader>
        /// <term>Property</term>
        /// <description>From Internal Default</description>
        /// <description>From App.config key</description>
        /// </listheader>
        /// <item>
        /// <term>Payflow Host</term>
        /// <description>NA</description>
        /// <description>Payflow_HOST</description>
        /// </item>
        /// <item>
        /// <term>Payflow Port</term>
        /// <description>443</description>
        /// <description>NA</description>
        /// </item>
        /// <item>
        /// <term>Transaction TimeOut</term>
        /// <description>45 seconds</description>
        /// <description>NA</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	/// ..........
        /// 	// Sample Request. 
        /// 	// Please replace user, vendor, password &amp; partner with your merchant information.
        /// 	String Request = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password";
        ///
        /// 	// Create an instance of PayflowNETAPI.
        /// 	PayflowNETAPI PayflowNetApi = new PayflowNETAPI();
        ///
        /// 	// RequestId is a unique string that is required for each &amp; every transaction. 
        /// 	// The merchant can use her/his own algorithm to generate this unique request id or 
        /// 	// use the SDK provided API to generate this as shown below (PayflowUtility.RequestId).
        /// 	String Response = PayflowNetApi.SubmitTransaction(Request, PayflowUtility.RequestId);
        ///
        /// 	// To write the Response on to the console.
        /// 	Console.WriteLine(Environment.NewLine + "Request = " + PayflowNetApi.TransactionRequest);
        /// 	Console.WriteLine(Environment.NewLine + "Response = " + Response);
        ///
        /// 	// Following lines of code are optional. 
        /// 	// Begin optional code for displaying SDK errors ...
        /// 	// It is used to read any errors that might have occurred in the SDK.
        ///
        ///	    String TransErrors = PayflowNetApi.TransactionContext.ToString();
        ///	    if (TransErrors != null &amp;&amp; TransErrors.Length > 0)	
        ///	    {
        ///	     	Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors);
        ///	    }
        ///	   
        ///     // End optional code for displaying SDK errors.
        ///
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        ///		' Sample Request. 
        ///		' Please replace user, vendor, password &amp; partner with your merchant information.
        ///		Dim Request As String = "TRXTYPE=S&amp;ACCT=5105105105105100&amp;EXPDATE=0115&amp;TENDER=C&amp;INVNUM=INV12345&amp;AMT=25.12&amp;PONUM=PO12345&amp;STREET=123 Main St.&amp;ZIP=12345&amp;USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password"
        /// 
        ///		' Create an instance of PayflowNETAPI.
        ///		Dim PayflowNetApi As PayflowNETAPI = new PayflowNETAPI
        /// 
        ///		' RequestId is a unique string that is required for each &amp; every transaction. 
        ///		' The merchant can use her/his own algorithm to generate this unique request id or 
        ///		' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
        ///		Dim Response As String = PayflowNetApi.SubmitTransaction(Request, PayflowUtility.RequestId)
        /// 
        ///		' To write the Response on to the console.
        ///		Console.WriteLine(Environment.NewLine + "Request = " + PayflowNetApi.TransactionRequest)
        ///		Console.WriteLine(Environment.NewLine + "Response = " + Response)
        /// 
        ///		' Following lines of code are optional. 
        ///		' Begin optional code for displaying SDK errors ...
        ///		' It is used to read any errors that might have occurred in the SDK.
        /// 
        ///		Dim TransErrors As String = PayflowNetApi.TransactionContext.ToString()
        ///		If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
        ///			Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
        ///		End If
        /// 
        ///		'End optional code for displaying SDK errors.
        /// </code>
        ///</example>


        public String SubmitTransaction(String ParamList, String RequestId)
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.SubmitTransaction(String): Entered.", PayflowConstants.SEVERITY_DEBUG);

            String RetVal;
            mRequestId = RequestId;
            GlobalClass.GlobalVar = mRequestId;
            mTransRqst = ParamList;
            mTransactionRequest = PayflowUtility.MaskSensitiveFields(ParamList);

            if (mClientInfo == null)
            {
                mClientInfo = new ClientInfo();
            }

            mClientInfo.SetClientVersion(PayflowConstants.CLIENT_VERSION);
            mClientInfo.SetClientType(PayflowConstants.CLIENT_TYPE);

            if (IsStrongAssemblyTransaction)
            {
                mClientInfo.RequestType = PayflowConstants.STRONG_ASSEMBLY;
            }
            else
            {
                mClientInfo.RequestType = PayflowConstants.WEAK_ASSEMBLY;
            }
            try
            {
                CheckTransactionArgs(ParamList, RequestId);

                if (!IsStrongAssemblyTransaction)
                {
                    mTransactionContext.LoadLoggerErrs = true;
                    ArrayList Errors = PayflowUtility.AlignContext(mTransactionContext, IsXmlPayRequest);
                    mTransactionContext.LoadLoggerErrs = false;
                    mTransactionContext.ClearErrors();
                    mTransactionContext.AddErrors(Errors);
                }

                if (mTransactionContext.HighestErrorLvl == PayflowConstants.SEVERITY_FATAL)
                {
                    ArrayList ErrorList = mTransactionContext.GetErrors(PayflowConstants.SEVERITY_FATAL);
                    ErrorObject FirstFatalError = (ErrorObject)ErrorList[0];
                    RetVal = FirstFatalError.ToString();
                    mTransactionRequest = PayflowUtility.MaskSensitiveFields(ParamList);
                    mTransactionResponse = RetVal;
                    Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.SubmitTransaction(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
                    return RetVal;
                }

                mPaymentStateMachine = PaymentStateMachine.Instance;


                mPaymentStateMachine.InitializeContext(mHostAddress, mHostPort, mTimeOut, mProxyAddress, mProxyPort, mProxyLogon, mProxyPassword, mClientInfo);

                //Initialize transaction
                mPaymentStateMachine.InitTrans(ParamList, RequestId);

                //Begin Payflow Timeout Check Point 1
                long TimeRemainingMsec;

                if (PayflowUtility.IsTimedOut(mPaymentStateMachine.TimeOut, mPaymentStateMachine.StartTime, out TimeRemainingMsec))
                {
                    String AddlMessage = "Input timeout in millsec = " + mPaymentStateMachine.TimeOut.ToString();

                    ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL, mPaymentStateMachine.IsXmlPayRequest, AddlMessage);

                    if (!mPaymentStateMachine.PsmContext.IsCommunicationErrorContained(Err))
                    {
                        mPaymentStateMachine.PsmContext.AddError(Err);
                    }
                }
                else
                {
                    mPaymentStateMachine.TimeOut = TimeRemainingMsec;
                }
                //End Payflow Timeout Check Point 1


                //Begin Toggle through states 
                while (mPaymentStateMachine.InProgress)
                {
                    mPaymentStateMachine.Execute();
                }
                //End Toggle through states 


                mTransactionResponse = mPaymentStateMachine.Response;
                RetVal = mTransactionResponse;
                mClientInfo = mPaymentStateMachine.ClientInfo;
                //Assign the context data 
                mRequestId = mPaymentStateMachine.RequestId;
                mTransactionRequest = PayflowUtility.MaskSensitiveFields(ParamList);
                mTransactionContext.AddErrors(mPaymentStateMachine.PsmContext.GetErrors());
                mPaymentStateMachine = null;
                ArrayList ErrList = PayflowUtility.AlignContext(mTransactionContext, IsXmlPayRequest);
                mTransactionContext.LoadLoggerErrs = false;
                mTransactionContext.ClearErrors();
                mTransactionContext.AddErrors(ErrList);

            }
            catch (Exception Ex)
            {
                RetVal = Ex.ToString();
            }
            finally
            {
                
            }
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.SubmitTransaction(String): RetVal = " + RetVal, PayflowConstants.SEVERITY_DEBUG);
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.SubmitTransaction(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
            return RetVal;

        }


        /// <summary>
        /// Initializes the default connection values
        /// </summary>
        private void InitDefaultValues()
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.InitDefaultValues(): Entered", PayflowConstants.SEVERITY_DEBUG);
            //Check if the values held in the PayPal server connection related params if they are passed null or 0 (for int values) then initialize
            // them to appropriate default values.

            // if timeout value not passed, set the TimeOut to default value.
            if (mTimeOut == 0)
            {
                mTimeOut = PayflowConstants.DEFAULT_TIMEOUT*1000;
            }
            else
            {
                mTimeOut = mTimeOut*1000;
            }
            

            // Set the timeout value.
            /*if (mTimeOut == 0)
            {
                try
                {
                    // Obtain timeout value from .config file, if present.
                    mTimeOut = Convert.ToInt32(PayflowUtility.AppSettings(PayflowConstants.INTL_PARAM_PAYFLOW_TIMEOUT)) * 1000;
                }
                catch (Exception)
                {
                    // Set default if TIMEOUT is not in .config file.
                    mTimeOut = PayflowConstants.DEFAULT_TIMEOUT * 1000;
                    Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.InitDefaultValues(): Timeout set to Default Value: " + mTimeOut.ToString(), PayflowConstants.SEVERITY_DEBUG);
                }
            }
            */
            if (mHostPort == 0)
            {
                mHostPort = PayflowConstants.DEFAULT_HOSTPORT;
            }

            try
            {
                if (mHostAddress == null || mHostAddress.Length == 0)
                {
                    String HostAddress = PayflowUtility.AppSettings(PayflowConstants.INTL_PARAM_PAYFLOW_HOST);
                    if (HostAddress != null && HostAddress.Length > 0)
                    {
                        HostAddress = HostAddress.TrimStart().TrimEnd();
                        if (HostAddress.Length == 0)
                        {
                            String RespMessage = PayflowConstants.PARAM_RESULT
                                + PayflowConstants.SEPARATOR_NVP
                                + (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_CONFIG_ERROR]
                                + PayflowConstants.DELIMITER_NVP
                                + PayflowConstants.PARAM_RESPMSG
                                + PayflowConstants.SEPARATOR_NVP
                                + (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_CONFIG_ERROR]
                                + "Tag "
                                + PayflowConstants.INTL_PARAM_PAYFLOW_HOST +
                                " is not present in the config file or config file is missing.";
                            ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", RespMessage);
                            mTransactionContext.AddError(Error);
                        }
                        else
                        {
                            mHostAddress = HostAddress;
                        }
                    }
                    else
                    {
                        String RespMessage = PayflowConstants.PARAM_RESULT
                            + PayflowConstants.SEPARATOR_NVP
                            + (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_CONFIG_ERROR]
                            + PayflowConstants.DELIMITER_NVP
                            + PayflowConstants.PARAM_RESPMSG
                            + PayflowConstants.SEPARATOR_NVP
                            + (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_CONFIG_ERROR]
                            + "Tag "
                            + PayflowConstants.INTL_PARAM_PAYFLOW_HOST +
                            " is not present in the config file or config file is missing.";
                        ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", RespMessage);
                        mTransactionContext.AddError(Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                String StackTrace = PayflowConstants.EMPTY_STRING;
                PayflowUtility.InitStackTraceOn();
                if (PayflowConstants.TRACE_ON.Equals(PayflowConstants.TRACE))
                {
                    StackTrace = ": " + Ex.Message + Ex.StackTrace;
                }
                String RespMessage = PayflowConstants.PARAM_RESULT
                    + PayflowConstants.SEPARATOR_NVP
                    + (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_CONFIG_ERROR]
                    + PayflowConstants.DELIMITER_NVP
                    + PayflowConstants.PARAM_RESPMSG
                    + PayflowConstants.SEPARATOR_NVP
                    + (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_CONFIG_ERROR]
                    + "Tag "
                    + PayflowConstants.INTL_PARAM_PAYFLOW_HOST +
                    " is not present in the config file or config file is missing."
                    + StackTrace;
                ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", RespMessage);
                mTransactionContext.AddError(Error);
            }
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.InitDefaultValues(): Exiting", PayflowConstants.SEVERITY_DEBUG);
        }

        /// <summary>
        /// Checks the vital transaction arguments
        /// for null or empty and populates context
        /// accordingly.
        /// </summary>
        /// <param name="ParamList">Param list</param>
        /// <param name="RequestId">Request Id</param>
        private void CheckTransactionArgs(String ParamList, String RequestId)
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.CheckTransactionArgs(String,String,String,bool): Entered", PayflowConstants.SEVERITY_DEBUG);
            try
            {
                if (ParamList == null || ParamList.Trim().Length == 0)
                {
                    String RespMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_EMPTY_PARAM_LIST]
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_EMPTY_PARAM_LIST];

                    ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", RespMessage);
                    mTransactionContext.AddError(Error);
                }
                else
                {
                    //Check for XmlPay 1.0
                    //We are not supporting Xml Pay 1.0
                    ParamList = ParamList.TrimStart(new char[1] { ' ' });
                    int Index = ParamList.TrimStart().IndexOf(PayflowConstants.XML_ID);
                    if (Index >= 0 && ParamList.IndexOf("<") == 0)
                    {
                        String Version = PayflowUtility.GetXmlAttribute(ParamList, PayflowConstants.XML_PARAM_VERSION);
                        if (Version != null && Version.Trim().Length > 0)
                        {
                            mIsXmlPayRequest = true;
                            if ("1.0".Equals(Version))
                            {
                                String AddlMessage = " ,Input XMLPay Request Version = " + Version;
                                String[] ErrParams = new String[] { (String)PayflowConstants.CommErrorCodes["E_VERSION_NOT_SUPPORTED"], (String)PayflowConstants.CommErrorMessages["E_VERSION_NOT_SUPPORTED"] + AddlMessage };
                                ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.MSG_COMMUNICATION_ERROR_XMLPAY_NO_RESPONSE_ID, ErrParams);
                                mTransactionContext.AddError(Error);
                            }
                        }
                    }
                    else
                    {
                        if (!mIsStrongAssemblyTransaction)
                        {
                            ParameterListValidator.Validate(ParamList, false, ref mTransactionContext);
                        }
                    }
                }

                if (RequestId == null || RequestId.Trim().Length == 0)
                {
                    String RespMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_MISSING_REQUEST_ID]
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_MISSING_REQUEST_ID];

                    ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", RespMessage);
                    mTransactionContext.AddError(Error);
                }

            }
            catch (Exception Ex)
            {
                String AddlMessage = PayflowConstants.EMPTY_STRING;
                if (Ex is System.Xml.XmlException)
                {
                    IsXmlPayRequest = true;
                    AddlMessage = "Error while parsing the xml request.";
                }
                else
                {
                    IsXmlPayRequest = false;
                }

                ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, Ex, PayflowConstants.SEVERITY_FATAL, IsXmlPayRequest, AddlMessage);
                mTransactionContext.AddError(Error);
            }
            Logger.Instance.Log("PayPal.Payments.Communication.PayflowNETAPI.CheckTransactionArgs(String,String,String,bool): Exiting", PayflowConstants.SEVERITY_DEBUG);
        }


        /*
         This function has been out in place to support generation of requestID from the COM Wrapper.This is
         because a static function cannot be called from COM Wrapper and PayflowUtility is a static class and has 
         a private constructor.
        */
        public String GenerateRequestId()
        {
            return PayflowUtility.RequestId;
        }

        #region "PAYFLOW-HEADERs related methods"
        /// <summary>
        /// Adds a Transaction header
        /// </summary>
        /// <param name="HeaderName">Header Name</param>
        /// <param name="HeaderValue">Header Value</param>
        public void AddTransHeader(String HeaderName, String HeaderValue)
        {
            AddHeader(HeaderName, HeaderValue);
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
            if (mClientInfo != null)
            {
                if (mClientInfo.ClientInfoHash.ContainsKey(HeaderName))
                {
                    mClientInfo.ClientInfoHash.Remove(HeaderName);
                }

            }
        }
        /// <summary>
        /// Adds a header
        /// </summary>
        /// <param name="HeaderName">Header name</param>
        /// <param name="HeaderValue">Header value</param>
        private void AddHeader(String HeaderName, String HeaderValue)
        {
            if (mClientInfo == null)
            {
                mClientInfo = new ClientInfo();
            }

            mClientInfo.AddHeaderToHash(HeaderName, HeaderValue);

        }
        #endregion
        #endregion

        #region "System.Object overides"
        /// <summary>
        /// This function overides the System.Object.Equals function.
        /// </summary>
        /// <param name="obj">Object which needs to be compared.</param>
        /// <returns>Returns the boolean value indicating if the Object passed is equal to the current object.
        /// </returns>
        [System.Runtime.InteropServices.ComVisible(false)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// This function overides the System.Object.GetHashCode function.
        /// </summary>
        /// <returns>Returns the HashCode for the current instance.
        /// </returns>
        [System.Runtime.InteropServices.ComVisible(false)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// This function overides the System.Object.ToString function.
        /// </summary>
        /// <returns>Returns the String representation of the current instance.
        /// </returns>
        [System.Runtime.InteropServices.ComVisible(false)]
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}