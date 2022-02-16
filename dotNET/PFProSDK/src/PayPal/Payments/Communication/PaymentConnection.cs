#region "Imports"

using System;
using System.Net;
using PayPal.Payments.Common.Utility;
using System.IO;
using System.Text;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using System.Security.Permissions;
using PayPal.Payments.DataObjects;
using System.Collections;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// This is the Connection Class.
	/// </summary>
	internal class PaymentConnection
	{
		#region "Member Variables"

		/// <summary>
		/// Holds whether transaction is
		/// with or without proxy.
		/// </summary>
		private bool mIsProxy;

		/// <summary>
		/// Payflow  Host Address
		/// </summary>
		private String mHostAddress;

		/// <summary>
		/// Payflow  Host Port
		/// </summary>
		private int mHostPort;

		/// <summary>
		/// Payflow  Server Uri object.
		/// </summary>
		private Uri mServerUri;

		/// <summary>
		/// Connection object.
		/// </summary>
		private HttpWebRequest mServerConnection;

		/// <summary>
		/// Proxy Address.
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
		/// Connection TimeOut Value.
		/// </summary>
        private long mConnectionTimeOut;

		/// <summary>
		/// Transaction start time.
		/// </summary>
		private long mStartTime;

		/// <summary>
		/// Request Id
		/// </summary>
		private String mRequestId;

		/// <summary>
		/// Param List Content Type
		/// </summary>
		private String mContentType;

		/// <summary>
		/// Proxy Object.
		/// </summary>
		private WebProxy mProxyInfo;

		/// <summary>
		/// Flag for XmlPay Request Type.
		/// </summary>
		private bool mIsXmlPayRequest;

		/// <summary>
		/// Context object.
		/// </summary>
		private Context mContext;
		/// <summary>
		/// Client information.
		/// </summary>
		private ClientInfo mClientInfo;
		/// <summary>
		/// Status of proxy connection. 
		/// False if proxy host address is  not parsed successfully.
		/// </summary>
		private bool mProxyStatus = true;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets whether transaction
		/// is with or without proxy.
		/// </summary>
		public bool IsProxy
		{
			get { return mIsProxy; }
		}

		/// <summary>
		/// Gets, Sets the param list
		/// content type.
		/// </summary>
		public String ContentType
		{
			get { return mContentType; }
			set { mContentType = value; }
		}

		/// <summary>
		/// Gets, Sets Request Id.
		/// </summary>
		public String RequestId
		{
			get { return mRequestId; }
			set { mRequestId = value; }
		}

		/// <summary>
		/// Gets the StartTime of the
		/// transaction.
		/// </summary>
		public long StartTime
		{
			get
			{
				if (mStartTime == 0)
				{
					InitTransactionStartTime();
				}
				return mStartTime;
			}
		}

		/// <summary>
		/// Gets, Sets the timeout
		/// value of transaction.
		/// </summary>
		public long TimeOut
		{
			get { return mConnectionTimeOut; }
			set { mConnectionTimeOut = value; }
		}

		/// <summary>
		/// Gets the Connection
		/// context object.
		/// </summary>
		internal Context ConnContext
		{
			get { return mContext; }
		}

		/// <summary>
		/// Gets, Sets XmlPay Request type flag.
		/// </summary>
		public bool IsXmlPayRequest
		{
			get { return mIsXmlPayRequest; }
			set { mIsXmlPayRequest = value; }
		}

		/// <summary>
		/// Client information.
		/// </summary>
		public ClientInfo ClientInfo
		{
			get { return mClientInfo; }
			set { mClientInfo = value; }
		}
		#endregion

		#region "Constructor"

		/// <summary>
		/// Constructor for PaymentConnection.
		/// </summary>
		/// <param name="PsmContext">Context object by reference.</param>
		public PaymentConnection(ref Context PsmContext)
		{
			mContext = PsmContext;
		}

		#endregion

		#region "Init functions"

		private void InitTransactionStartTime()
		{
			//Start time in mill seconds.
			mStartTime = DateTime.Now.Ticks/10000;
		}
		
		/// <summary>
		/// Initializes Connection Host Attributes.
		/// </summary>
		/// <param name="HostAddress">String Value of Host Address.</param>
		/// <param name="HostPort">Host port as positive integer.</param>
		/// <param name="TimeOut">Connection Timeout in Seconds.</param>
		private void InitializeHost(String HostAddress, int HostPort, int TimeOut)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeHost(String,int,int): Entered.",
				PayflowConstants.SEVERITY_DEBUG);

			if (HostAddress != null && HostAddress.Length > 0)
			{
				mHostAddress = HostAddress;
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeHost(String,int,int): HostAddress = " + mHostAddress,
					PayflowConstants.SEVERITY_INFO);
			}
			else
			{
				ErrorObject NullHostError = PayflowUtility.PopulateCommError(PayflowConstants.E_NULL_HOST_STRING, null,
					PayflowConstants.SEVERITY_FATAL, IsXmlPayRequest,
					null);
				if (!ConnContext.IsCommunicationErrorContained(NullHostError))
				{
					ConnContext.AddError(NullHostError);
				}
			}

			mHostPort = HostPort;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeHost(String,int,int): HostPort = " + mHostPort.ToString(),
				PayflowConstants.SEVERITY_INFO);
			mConnectionTimeOut = TimeOut;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeHost(String,int,int): Exiting.",
				PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Initializes proxy Attributes
		/// </summary>
		/// <param name="ProxyAddress">String Value of Proxy Address.</param>
		/// <param name="ProxyPort">Proxy port as positive integer.</param>
		/// <param name="ProxyLogon">String Value of Proxy User Id.</param>
		/// <param name="ProxyPassword">String Value of Proxy Password.</param>
		private void InitializeProxy(String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeProxy(String,int,String, String): Entered.", PayflowConstants.SEVERITY_DEBUG);

			mProxyAddress = ProxyAddress;
			mProxyPort = ProxyPort;
			mProxyLogon = ProxyLogon;
			mProxyPassword = ProxyPassword;

			if (mProxyAddress != null && mProxyAddress.Length > 0 && mProxyPort > 0)
			{
				mIsProxy = true;
			}

			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeProxy(String,int,String, String): Exiting.",
				PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Initializes Connection from Connection Attributes.
		/// </summary>
		/// <param name="HostAddress">String Value of Host Address.</param>
		/// <param name="HostPort">Host port as positive integer.</param>
		/// <param name="TimeOut">Connection Timeout in Seconds.</param>
		/// <param name="ProxyAddress">String Value of Proxy Address. Pass null if not applicable.</param>
		/// <param name="ProxyPort">Proxy port as positive integer.Pass 0 if not applicable.</param>
		/// <param name="ProxyLogon">String Value of Proxy User Id.Pass null if not applicable.</param>
		/// <param name="ProxyPassword">String Value of Proxy Password.Pass null if not applicable.</param>
		public void InitializeConnection(String HostAddress, int HostPort,
			int TimeOut, String ProxyAddress, int ProxyPort,
			String ProxyLogon, String ProxyPassword)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeConnection(String,int,int,String,int,String,String): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			InitializeHost(HostAddress, HostPort, TimeOut);
			InitializeProxy(ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword);
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitializeConnection(String,int,int,String,int,String,String): Exiting.",
				PayflowConstants.SEVERITY_DEBUG);
		}


		/// <summary>
		/// Initialized the Server Uri object from
		/// available connection attributes.
		/// </summary>
		private void InitServerUri()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitServerUri(String): Entered.",
				PayflowConstants.SEVERITY_DEBUG);

			UriBuilder ServerUriBuilder = new UriBuilder();

			try
			{
				ServerUriBuilder.Host = mHostAddress;
				ServerUriBuilder.Scheme = "https";
				ServerUriBuilder.Port = mHostPort;			
				mServerUri = ServerUriBuilder.Uri;
			}
			catch (Exception Ex)
			{
				String AddlMessage = "Input Server Uri = " + ServerUriBuilder.Scheme+"://"+ServerUriBuilder.Host+":"+ServerUriBuilder.Port;
				if(Ex is System.UriFormatException && IsProxy)
				{
					AddlMessage += " Input Proxy info = http://" + mProxyAddress;
					mProxyStatus = false;
				}
				else if (IsProxy)
				{
					AddlMessage += " Input Proxy info = " + mProxyInfo.Address.ToString();
				}
				ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_SOK_CONN_FAILED, Ex,
					PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
					AddlMessage);
				if (!ConnContext.IsCommunicationErrorContained(InitError))
				{
					ConnContext.AddError(InitError);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitServerUri(String): Exiting.",
					PayflowConstants.SEVERITY_DEBUG);
			}
		}

		/// <summary>
		/// Initializes Proxy Object from
		/// available proxy information.
		/// </summary>
		private void InitProxyInfo()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitProxyInfo(): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			if (mIsProxy)
			{
				mProxyInfo = new WebProxy();
				UriBuilder ProxyUriBuilder = new UriBuilder();
				ProxyUriBuilder.Host = mProxyAddress;
				ProxyUriBuilder.Port = mProxyPort;
				ProxyUriBuilder.Scheme = "http";
				Uri ProxyUri = ProxyUriBuilder.Uri;
                //NetworkCredential ProxyCredential = new NetworkCredential(mProxyLogon, mProxyPassword);
				//CredentialCache ProxyCredentialCache = new CredentialCache();
				//ProxyCredentialCache.Add(ProxyUri, "Basic", ProxyCredential);
				//mProxyInfo = new WebProxy();
				mProxyInfo.Address = ProxyUri;
				//mProxyInfo.Credentials = ProxyCredentialCache;
                mProxyInfo.Credentials = new NetworkCredential(mProxyLogon, mProxyPassword);
				//mProxyInfo.BypassProxyOnLocal = true;
                //mProxyInfo.UseDefaultCredentials = false;
                mServerConnection.Proxy = mProxyInfo;
                Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitProxyInfo(): Using Proxy Info: ", PayflowConstants.SEVERITY_DEBUG);
			} 

			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.InitProxyInfo(): Exiting.",
				PayflowConstants.SEVERITY_DEBUG);
		}

		/// <summary>
		/// Initializes all the connection attributes and creates the connection.
		/// </summary>
		private void CreateConnection()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.CreateConnection(): Entered.",
				PayflowConstants.SEVERITY_DEBUG);

			try
			{
                //Create Connection Object.

                // 03/06/2017 Added TLS 1.2 support for .NET 4.5 support.  Only TLS 1.2 is supported going forward.
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;  // | SecurityProtocolType.Tls11;
                mServerConnection = (HttpWebRequest) WebRequest.Create(mServerUri);
                // Create a new request to the above mentioned URL.    
                // WebRequest mServerConnection = WebRequest.Create(mServerUri);

                //Set Connection Properties
                mServerConnection.Method = "POST";
				mServerConnection.KeepAlive = false;
				mServerConnection.UserAgent = PayflowConstants.USER_AGENT;
				mServerConnection.ContentType = mContentType;
				mServerConnection.Timeout = (int) mConnectionTimeOut;
				// Add request id in the header.
				mServerConnection.Headers.Add(PayflowConstants.PAYFLOWHEADER_REQUEST_ID, mRequestId);
				long TimeOut = mConnectionTimeOut/1000;
				mServerConnection.Headers.Add(PayflowConstants.PAYFLOWHEADER_TIMEOUT, TimeOut.ToString());

				if (IsProxy)
				{
					if (mProxyInfo == null)
					{
						InitProxyInfo();
					}

					//mServerConnection.Proxy = mProxyInfo;
				} 
				else 
				{
                    // added 09/02/2009, v4.33
                    // reference: http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.proxy.aspx
                    // sets the the global proxy to an empty proxy.
                    // mServerConnection.Proxy = GlobalProxySelection.GetEmptyWebProxy();
                    // GlobalProxySelection is deprecated, replaced with WebRequest.DefaultWebProxy v4.50 0-3/15/2016
                    WebRequest.DefaultWebProxy = null;
                    mServerConnection.Proxy = WebRequest.DefaultWebProxy;
                }

				//Add VIT Headers
				if(mClientInfo != null)
				{
					//Get the Hash map.
					Hashtable ClientInfoHash = mClientInfo.ClientInfoHash;
					if(ClientInfoHash != null && ClientInfoHash.Count > 0)
					{
						//Iterate through the hash map to add the 
						//appropriate headers.
						foreach(DictionaryEntry HeaderKeyValue in ClientInfoHash)
						{
							Object ValueObj = HeaderKeyValue.Value;
							if(ValueObj != null)
							{
								ClientInfoHeader CurrHeader = (ClientInfoHeader)ValueObj;
								String HdrName = CurrHeader.HeaderName;
								Object HdrValueObj = CurrHeader.HeaderValue;
								String HdrValueStr  = null; 
								//Check if Header name is non-null, non-empty string.
								bool ValidHeaderName = (HdrName!= null && HdrName.Length > 0);
								bool ValidHeaderValue = (HdrValueObj != null);
								//Check if Header value object is non-null, object.
								if(ValidHeaderValue)
								{
									HdrValueStr = CurrHeader.HeaderValue.ToString();
									//Check if the header value is non-null, non-empty.
									ValidHeaderValue = (HdrValueStr != null && HdrValueStr.Length > 0);
								}	
								
								//If all conditions are satisfied, then add header to request.
								if(ValidHeaderName && ValidHeaderValue)
								{
									try
									{
										mServerConnection.Headers.Add(HdrName,HdrValueStr);
									}
									catch(Exception Ex)
									{
										string AddlMessage = "Invalid Client(Wrapper) Header: "+ HdrName; 
										ErrorObject HeaderError = PayflowUtility.PopulateCommError(PayflowConstants.MESSAGE_WRAPPERHEADER_ERROR, Ex,
											PayflowConstants.SEVERITY_WARN , IsXmlPayRequest,
											AddlMessage);
										if (!ConnContext.IsCommunicationErrorContained(HeaderError))
										{
											ConnContext.AddError(HeaderError);
										}
									}
								}
							}
						}
					}
				}
				//Added VIT Headers to the http request.
			}
			catch (Exception Ex)
			{
				String AddlMessage = "Input Server Uri = " + mServerUri.AbsoluteUri;
				
				if(Ex is System.UriFormatException && IsProxy)
				{
					AddlMessage += " Input Proxy info = http://" + mProxyAddress;
					mProxyStatus = false;
				}
				else if (IsProxy)
				{
					AddlMessage += " Input Proxy info = " + mProxyInfo.Address.ToString();
				}
				ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_SOK_CONN_FAILED, Ex,
					PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
					AddlMessage);
				if (!ConnContext.IsCommunicationErrorContained(InitError))
				{
					ConnContext.AddError(InitError);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.CreateConnection(): Exiting.",
					PayflowConstants.SEVERITY_DEBUG);
			}
		}

		#endregion

		#region "Connection Functions"

		/// <summary>
		/// Initializes the Server Connection.
		/// </summary>
		/// <returns>True if success, False otherwise.</returns>
		public bool ConnectToServer()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			bool RetVal = false;

			try
			{
				//Initialize Server Uri.
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Initializing Server Uri.",
					PayflowConstants.SEVERITY_INFO);
				InitServerUri();
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Initialized Server Uri = " + mServerUri.AbsoluteUri,
					PayflowConstants.SEVERITY_INFO);

				//Create Connection object & Set Connection Attributes
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Initializing Connection Attributes.",
					PayflowConstants.SEVERITY_INFO);
				CreateConnection();
				if (mServerConnection != null)
				{
					if (mProxyStatus)
					{
						RetVal = true;
						Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Connection Created.",
							PayflowConstants.SEVERITY_INFO);
					}
					else
					{
						RetVal= false;
						Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Connection Creation Failure: Incorrect Proxy Details.",
							PayflowConstants.SEVERITY_INFO);
					}
				}
				else
				{
					RetVal = false;
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Connection Creation Failure.",
						PayflowConstants.SEVERITY_INFO);
				}
			}
			catch (Exception Ex)
			{
				String AddlMessage = "Input Server Uri = " + mServerUri.AbsoluteUri;
				if (IsProxy)
				{
					AddlMessage += " Input Proxy info = " + mProxyInfo.Address.ToString();
				}
				ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_SOK_CONN_FAILED, Ex,
					PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
					AddlMessage);
				if (!ConnContext.IsCommunicationErrorContained(InitError))
				{
					ConnContext.AddError(InitError);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ConnectToServer(String): Exiting.",
					PayflowConstants.SEVERITY_DEBUG);
			}
			return RetVal;
		}

		/// <summary>
		/// Sends the request to the server.
		/// </summary>
		/// <param name="Request">String Value of request.</param>
		/// <returns>True if success, False otherwise.</returns>
		public bool SendToServer(String Request)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.SendToServer(String): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			bool RetVal = false;

			// Uncomment this line to test this SDK in QA.  This will override the certificate check where the
			// host URL does not match the server certificate causing the exception:
			//
			// "The underlying connection was closed: Could not establish trust relationship with remote server."
			//
			// See notes in LocalPolicy.cs in the Utility directory.
			//
			//System.Net.ServicePointManager.CertificatePolicy = new LocalPolicy(ref mContext,IsXmlPayRequest);

			try
			{
				ASCIIEncoding Encoding = new ASCIIEncoding();
				if (Request != null)
				{
					Byte[] ParamListBytes = Encoding.GetBytes(Request);
					mServerConnection.ContentLength = ParamListBytes.Length;
					Stream ReqStram = mServerConnection.GetRequestStream();
					ReqStram.Write(ParamListBytes, 0, ParamListBytes.Length);
					ReqStram.Close();
					RetVal = true;

					String[] HeaderKeys = mServerConnection.Headers.AllKeys;
					if(HeaderKeys != null)
					{
						
						int KeysLen = HeaderKeys.GetLength(0);
						int index;
						Logger.Instance.Log("++++++++++++++++++++++", PayflowConstants.SEVERITY_DEBUG);
						for(index=0;index<KeysLen;index++)
						{
							//if (!(HeaderKeys[index].Equals(PayflowConstants.PAYFLOWHEADER_CLIENT_VERSION)))
							//	 || HeaderKeys[index].Equals(PayflowConstants.PAYFLOWHEADER_CLIENT_TYPE)))
							//{
								Logger.Instance.Log("HTTP Header: " + HeaderKeys[index]+ ": " + mServerConnection.Headers.Get(HeaderKeys[index]) , PayflowConstants.SEVERITY_DEBUG);
							//}
						}
						Logger.Instance.Log("++++++++++++++++++++++", PayflowConstants.SEVERITY_DEBUG);
					}
				}
				else
				{
					ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null,
						PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
						null);
					if (!ConnContext.IsCommunicationErrorContained(InitError))
					{
						ConnContext.AddError(InitError);
					}
				}
			}
			catch (Exception Ex)
			{
				String AddlMessage = "Input Server Uri = " + mServerUri.AbsoluteUri;
				if (IsProxy)
				{
					AddlMessage += " Input Proxy info = " + mProxyInfo.Address.ToString();
				}
				ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_SOK_CONN_FAILED, Ex,
					PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
					AddlMessage);
				if (!ConnContext.IsCommunicationErrorContained(InitError))
				{
					ConnContext.AddError(InitError);
				}
                Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.SendToServer(String): InitError: " + Ex.Message, PayflowConstants.SEVERITY_DEBUG);
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.SendToServer(String): Exiting.",
					PayflowConstants.SEVERITY_DEBUG);
			}
			return RetVal;
		}

		/// <summary>
		/// Receives the transaction response from
		/// the server. 
		/// </summary>
		/// <returns>String Value of Response.</returns>
		public String ReceiveResponse()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ReceiveResponse(): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			String Response = PayflowConstants.EMPTY_STRING;

			try
			{
				HttpWebResponse ServerResponse = (HttpWebResponse) mServerConnection.GetResponse();
				Stream ResponseStream = ServerResponse.GetResponseStream();
				mRequestId = ServerResponse.Headers.Get(PayflowConstants.PAYFLOWHEADER_REQUEST_ID);
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ReceiveResponse(): Obtained RequestId = " + mRequestId,
					PayflowConstants.SEVERITY_INFO);

				// v4.3.1 - changed stream handling due to issue with code below not returning a complete
				// stream.//read the stream in bytes
				//long RespLen = ServerResponse.ContentLength ;
				//Byte[] RespByteBuffer = new byte[RespLen];
				//ResponseStream.Read (RespByteBuffer,0,Convert.ToInt32 (RespLen));
				//UTF8Encoding UtfEncoding = new UTF8Encoding ();
				//Response = UtfEncoding.GetString(RespByteBuffer);

				Response = new StreamReader(ServerResponse.GetResponseStream()).ReadToEnd();

				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ReceiveResponse(): Obtained Response.",
					PayflowConstants.SEVERITY_INFO);
				ResponseStream.Close();
				mServerConnection = null;
			}
			catch (Exception Ex)
			{
				String AddlMessage = "Input Server Uri = " + mServerUri.AbsoluteUri;
				if (IsProxy)
				{
					AddlMessage += " Input Proxy info = " + mProxyInfo.Address.ToString();
				}
                ErrorObject InitError = PayflowUtility.PopulateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, Ex,
					PayflowConstants.SEVERITY_ERROR, IsXmlPayRequest,
					AddlMessage);
				if (!ConnContext.IsCommunicationErrorContained(InitError))
				{
					ConnContext.AddError(InitError);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.ReceiveResponse(): Exiting.",
					PayflowConstants.SEVERITY_DEBUG);
			}
			return Response;
		}

		/// <summary>
		/// Disconnects from the server.
		/// </summary>
		public void Disconnect()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.Disconnect(): Entered.",
				PayflowConstants.SEVERITY_DEBUG);
			mServerConnection = null;
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentConnection.Disconnect(): Exiting.",
				PayflowConstants.SEVERITY_DEBUG);
		}

		#endregion
	}
}
