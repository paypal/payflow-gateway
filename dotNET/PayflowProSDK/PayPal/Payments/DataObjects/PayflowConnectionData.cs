#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Payflow Host related information.
	/// </summary>
	/// <remarks>This class stores the information related to connection to the 
	/// PayPal payment gateway. If the empty constructor of this class 
	/// is used to create the object, or 
	/// passed values are empty, then The following values (if empty) are looked for 
	/// as follows:
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
	public sealed class PayflowConnectionData : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Payflow Host address
		/// </summary>
		private String mHostAddress;

		/// <summary>
		/// Payflow Host port
		/// </summary>
		private int mHostPort;

		/// <summary>
		/// Proxy Address
		/// </summary>
		private String mProxyAddress;

		/// <summary>
		/// Proxy Port
		/// </summary>
		private int mProxyPort;

		/// <summary>
		/// Proxy Logon Id
		/// </summary>
		private String mProxyLogon;

		/// <summary>
		/// Proxy Password
		/// </summary>
		private String mProxyPassword;

		/// <summary>
		/// Transaction TimeOut
		/// </summary>
		private int mTimeOut;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets HostAddress. It is PayPal's HostName
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public String HostAddress
		{
			get { return mHostAddress; }
		}

		/// <summary>
		/// Gets HostPort. Use port 443
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public int HostPort
		{
			get { return mHostPort; }
		}

		/// <summary>
		/// Gets Time-out period for the transaction. The minimum recommended
		/// time-out value is 30 seconds. The client begins tracking
		/// from the time that it sends the transaction request to the server.
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public int TimeOut
		{
			get { return mTimeOut; }
		}

		/// <summary>
		/// Gets Proxy server address. Use the PROXY parameters for servers
		/// behind a firewall. Your network administrator can provide the
		/// values.
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public String ProxyAddress
		{
			get { return mProxyAddress; }
		}

		/// <summary>
		/// Gets ProxyPort
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public int ProxyPort
		{
			get { return mProxyPort; }
		}

		/// <summary>
		/// Gets ProxyLogon
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public String ProxyLogon
		{
			get { return mProxyLogon; }
		}

		/// <summary>
		/// Gets ProxyPassword
		/// </summary>
		/// <remarks>Read-only property.</remarks>
		public String ProxyPassword
		{
			get { return mProxyPassword; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>
		public PayflowConnectionData() : this(null, 0, 0, null, 0, null, null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address</param>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>
		public PayflowConnectionData(String HostAddress) : this(HostAddress, 0, 0, null, 0, null, null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address</param>
		/// <param name="HostPort">Payflow Host port</param>
		/// <param name="TimeOut">Transaction time out</param>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>		
		public PayflowConnectionData(String HostAddress, int HostPort, int TimeOut) : this(HostAddress, HostPort, TimeOut, null, 0, null, null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address</param>
		/// <param name="HostPort">>Payflow Host port</param>
		/// <param name="TimeOut">Transaction timeout</param>
		/// <param name="ProxyAddress">Proxy Address</param>
		/// <param name="ProxyPort">Proxy Port</param>
		/// <param name="ProxyLogon">Proxy Logon Id </param>
		/// <param name="ProxyPassword">ProxyPwd</param>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>
		public PayflowConnectionData(String HostAddress, int HostPort, int TimeOut, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword)
		{
			if (Context == null)
			{
				Context = new Context();
			}

			mHostAddress = HostAddress;
			mHostPort = HostPort;
			mTimeOut = TimeOut;
			mProxyAddress = ProxyAddress;
			mProxyPort = ProxyPort;
			mProxyLogon = ProxyLogon;
			mProxyPassword = ProxyPassword;
			InitDefaultValues();
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address</param>
		/// <param name="HostPort">>Payflow Host port</param>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>		
		public PayflowConnectionData(String HostAddress, int HostPort) : this(HostAddress, HostPort, 0, null, 0, null, null)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address</param>
		/// <param name="HostPort">>Payflow Host port</param>
		/// <param name="ProxyAddress">Proxy Address</param>
		/// <param name="ProxyPort">Proxy Port</param>
		/// <param name="ProxyLogon">Proxy Logon Id </param>
		/// <param name="ProxyPassword">ProxyPwd</param>
		/// <remarks>
		/// The following values (if empty) are looked for 
		/// as follows:
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
		/// <term>Transaction timeout</term>
		/// <description>45 seconds</description>
		/// <description>NA</description>
		/// </item>
		/// </list>
		/// </remarks>		
		public PayflowConnectionData(String HostAddress, int HostPort, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword) : this(HostAddress, HostPort, 0, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword)
		{
		}

		#endregion

		/// <summary>
		/// Initializes the default values
		/// </summary>
		private void InitDefaultValues()
		{
			//Check if the values held
			//in the PayPal server
			//connection related params
			//if they are passed null or
			//0 (for int values) then
			//initialize them to appropriate
			//default values.

			//set the timeout to default timeout.
            if (mTimeOut == 0)
            {
                mTimeOut = PayflowConstants.DEFAULT_TIMEOUT;
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
							ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "",RespMessage);
							Context.AddError(Error);
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
						ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "",RespMessage);
						Context.AddError(Error);
					}
				}
			}
			catch (Exception Ex)
			{
				String StackTrace = PayflowConstants.EMPTY_STRING;
				PayflowUtility.InitStackTraceOn();
				if(PayflowConstants.TRACE_ON.Equals(PayflowConstants.TRACE))
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
				ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "",RespMessage);
				Context.AddError(Error);
			}
		}
	}
}