#region "Imports"

using System;
using System.Xml;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.DataObjects;
using System.Collections;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Payment State Driver class.
	/// </summary>
	internal sealed class PaymentStateMachine
	{
		#region "Member Variables"

		/// <summary>
		/// OS Name
		/// </summary>
		private String mVitOSName;

		/// <summary>
		/// OS Architecture.
		/// </summary>
		private String mVitOSArch;

		/// <summary>
		/// OS Version.
		/// </summary>
		private String mVitOSVersion;

		/// <summary>
		/// .NET Version.
		/// </summary>
		private String mVitRuntimeVersion = PayflowConstants.EMPTY_STRING;

		/// <summary>
		/// Proxy Used (Y/N)
		/// </summary>
		private String mVitProxy;

		/// <summary>
		/// Payment State object.
		/// </summary>
		private PaymentState mPaymentState;

		/// <summary>
		/// Connection object.
		/// </summary>
		private PaymentConnection mConnection;

		/// <summary>
		/// Context object.
		/// </summary>
		private Context psmContext;
		/// <summary>
		/// Client information.
		/// </summary>
		private ClientInfo mClientInfo;
		#endregion		

		#region "Properties"

		/// <summary>
		/// Gets the instance of PaymentStateMachine.
		/// </summary>
		public static PaymentStateMachine Instance
		{
			get { return new PaymentStateMachine(); }

		}


		/// <summary>
		/// Gets transaction response.
		/// </summary>
		public String Response
		{
			get
			{
				String RetVal = null;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.TransactionResponse;
				}
				return RetVal;
			}
		}

		/// <summary>
		/// Gets the Request Id
		/// </summary>
		public String RequestId
		{
			get
			{
				String RetVal = null;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.Connection.RequestId;
				}
				return RetVal;
			}
		}

		/// <summary>
		/// Gets the transaction start time.
		/// </summary>
		public long StartTime
		{
			get
			{
				long RetVal = 0;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.Connection.StartTime;
				}
				return RetVal;
			}
		}

		/// <summary>
		/// Gets, Sets the transaction timeout.
		/// </summary>
		public long TimeOut
		{
			get
			{
				long RetVal = 0;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.Connection.TimeOut;
				}
				return RetVal;
			}
			set { mPaymentState.Connection.TimeOut = value; }
		}

		/// <summary>
		/// Gets the context object.
		/// </summary>
		internal Context PsmContext
		{
			get { return psmContext; }
		}

		/// <summary>
		/// Gets XML Pay Request flag.
		/// </summary>
		public bool IsXmlPayRequest
		{
			get
			{
				bool RetVal = false;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.IsXmlPayRequest;
				}
				return RetVal;

			}
		}

		/// <summary>
		/// Gets the Inprogress status of transaction.
		/// </summary>
		public bool InProgress
		{
			get
			{
				bool RetVal = false;
				if (mPaymentState != null)
				{
					RetVal = mPaymentState.InProgress;
				}
				return RetVal;
			}
		}

		/// <summary>
		/// Client information.
		/// </summary>
		public ClientInfo ClientInfo
		{
			get { return mClientInfo;}
			//set { mClientInfo = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Private constructor for PaymentStateMachine
		/// </summary>
		private PaymentStateMachine()
		{
			psmContext = new Context();
			mConnection = new PaymentConnection(ref psmContext);
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Sets the Version Tracking information
		/// in NV Request.
		/// </summary>
		private void SetVersionTracking()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.SetVersionTracking(): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);


			mVitOSVersion = Environment.OSVersion.Version.ToString();
			mVitOSName = Environment.OSVersion.ToString();
			mVitOSArch = Environment.OSVersion.Platform.ToString();
			mVitRuntimeVersion = Environment.Version.ToString();
			if (this.mConnection.IsProxy)
			{
				mVitProxy = "Y";
			}
			else
			{
				mVitProxy = "N";
			}

			//Check whether OS Version string is also present
			// in the Os name string value. If found, remove it 
			//from the string.
			if(mVitOSVersion != null && mVitOSName != null)
			{
				int IndexOfVersion = mVitOSName.IndexOf(mVitOSVersion);
				if(IndexOfVersion > 0)
				{
					mVitOSName = mVitOSName.Remove(IndexOfVersion,mVitOSVersion.Length);
				}
			}

			mClientInfo.OsVersion = mVitOSVersion ;
			mClientInfo.OsName = mVitOSName;
			mClientInfo.OsArchitecture = mVitOSArch;
			mClientInfo.RunTimeVersion = mVitRuntimeVersion;
			mClientInfo.Proxy = mVitProxy;
		}



		/// <summary>
		/// Initializes transaction context.
		/// </summary>
		/// <param name="HostAddress">Payflow Host Address.</param>
		/// <param name="HostPort">Payflow Host Port.</param>
		/// <param name="TimeOut">Transaction timeout.</param>
		/// <param name="ProxyAddress">Proxy Address.</param>
		/// <param name="ProxyPort">Proxy Port.</param>
		/// <param name="ProxyLogon">Proxy Logon Id.</param>
		/// <param name="ProxyPassword">Proxy Password.</param>
		/// <param name="ClientInfo">Client Info</param>
		public void InitializeContext(String HostAddress, int HostPort, int TimeOut, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword,ClientInfo ClientInfo)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.InitializeContext(String, int, int, String, int, String, String): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);
			try
			{
				this.mConnection.InitializeConnection(HostAddress, HostPort, TimeOut, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword);
				if(ClientInfo != null)
				{
					mClientInfo = ClientInfo;
				}
				else
				{
					mClientInfo = new ClientInfo();
				}
				
				this.SetVersionTracking();
				this.mConnection.ClientInfo = mClientInfo;
			}
			catch (Exception Ex)
			{
				ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, Ex,
				                                                 PayflowConstants.SEVERITY_ERROR, mPaymentState.IsXmlPayRequest,
				                                                 null);
				if (!PsmContext.IsCommunicationErrorContained(Err))
				{
					PsmContext.AddError(Err);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.InitializeContext(String,int,int,String, nt,String,String): Exiting.",
				                    PayflowConstants.SEVERITY_DEBUG);
			}
		}


		/// <summary>
		/// Initialized Transaction.
		/// </summary>
		/// <param name="ParamList">Parameter List</param>
		/// <param name="RequestId">Request Id</param>
		public void InitTrans(String ParamList, String RequestId)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.InitTrans(String): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);

			try
			{
				this.mConnection.RequestId = RequestId;
				this.mPaymentState = new SendInitState(this.mConnection, ParamList, ref psmContext);
			}
			catch (Exception Ex)
			{
				ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_CONTXT_INIT_FAILED, Ex,
				                                                 PayflowConstants.SEVERITY_ERROR, mPaymentState.IsXmlPayRequest,
				                                                 null);
				if (!PsmContext.IsCommunicationErrorContained(Err))
				{
					PsmContext.AddError(Err);
				}
			}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.InitTrans(String): Exiting.",
				                    PayflowConstants.SEVERITY_DEBUG);
			}
		}

		/// <summary>
		/// Executes the transaction.
		/// </summary>
		public void Execute()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.Execute(): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);

			try
			{
				if (PsmContext.HighestErrorLvl == PayflowConstants.SEVERITY_FATAL)
				{
					String TrxResponse = mPaymentState.TransactionResponse;
					String Message;
					if (TrxResponse != null && TrxResponse.Length > 0)
					{
						Message = TrxResponse;
					}
					else
					{
						ArrayList ErrorList = psmContext.GetErrors(PayflowConstants.SEVERITY_FATAL);
						ErrorObject FirstFatalError = (ErrorObject) ErrorList[0];
						Message = FirstFatalError.ToString();
					}
					mPaymentState.SetTransactionFail = Message;
				}
				else
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.Execute(): Current State = " + mPaymentState,
						PayflowConstants.SEVERITY_DEBUG);
					mPaymentState.Execute();
				}
			}
			catch (Exception Ex)
			{
				ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, Ex, PayflowConstants.SEVERITY_ERROR,
				                                                 mPaymentState.IsXmlPayRequest,
				                                                 null);
				if (!PsmContext.IsCommunicationErrorContained(Err))
				{
					PsmContext.AddError(Err);
				}
			}
			finally
			{
				// perform state transition
				mPaymentState = GetNextState(mPaymentState);
				mClientInfo = mConnection.ClientInfo;
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.Execute(): Exiting.  Current State = " + mPaymentState.GetType().ToString(),
				                    PayflowConstants.SEVERITY_DEBUG);
			}
		}

		/// <summary>
		/// Changes the Payment States depending upon
		/// the current state status.
		/// </summary>
		/// <param name="CurrentPmtState">Current Payment State.</param>
		/// <returns>Next Payment State</returns>
		private PaymentState GetNextState(PaymentState CurrentPmtState)
		{
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState): Entered.",
			                    PayflowConstants.SEVERITY_DEBUG);

			if (CurrentPmtState.Success && CurrentPmtState.InProgress)
			{ 
				if (CurrentPmtState is TransactionReceiveState)
				{
					// exit state
					CurrentPmtState.SetTransactionSuccess();
				}
				else if (CurrentPmtState is SendInitState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Success): SentInitState Entered.",
						PayflowConstants.SEVERITY_DEBUG);

					CurrentPmtState = new TransactionSendState(CurrentPmtState);
				}
				else if (CurrentPmtState is TransactionSendState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Success): TransactionSentState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new TransactionReceiveState(CurrentPmtState);
				}
				else if (CurrentPmtState is SendRetryState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Success): SendRetryState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new SendReconnectState(CurrentPmtState);
				}
				else if (CurrentPmtState is SendReconnectState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Success): SendReconnectState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new SendInitState(CurrentPmtState);
				}
				// unknown state
				else
				{
					String AddlMessage = "Unknown State, Current State = " + mPaymentState.ToString();
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, null,
					                                                 PayflowConstants.SEVERITY_FATAL, mPaymentState.IsXmlPayRequest,
					                                                 AddlMessage);
					if (!PsmContext.IsCommunicationErrorContained(Err))
					{
						PsmContext.AddError(Err);
					}
				}
			}
			else if (CurrentPmtState.Failed && CurrentPmtState.InProgress)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState): Current Payment State Failed.  Current State = " + mPaymentState.ToString(),
					PayflowConstants.SEVERITY_DEBUG);
				if (CurrentPmtState is ReconnectState)
				{
					// exit state
					if (!PsmContext.IsErrorContained())
					{
						String AddlMessage = "Exceeded Reconnect attempts, check context for error, Current reconnect attempt = " + mPaymentState.AttemptNo.ToString();
						ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null,
						                                                 PayflowConstants.SEVERITY_FATAL, mPaymentState.IsXmlPayRequest,
						                                                 AddlMessage);
						if (!PsmContext.IsCommunicationErrorContained(Err))
						{
							PsmContext.AddError(Err);
						}
					}
					else
					{
						ArrayList ErrList = new ArrayList();
						ErrList.AddRange(PsmContext.GetErrors());
						int HighestSevLevel = PsmContext.HighestErrorLvl;
						
						int ErrorListIndex;
						int ErrorListSize = ErrList.Count;
						for(ErrorListIndex=0;ErrorListIndex<ErrorListSize;ErrorListIndex++)
						{
							ErrorObject Err = (ErrorObject) ErrList[ErrorListIndex];
							if(Err.SeverityLevel == HighestSevLevel)
							{
								int index;
								int size=Err.MessageParams.Count;
								string[] MsgCodeParams = new string[size];
								for (index = 0; index < size; index++)
								{
									MsgCodeParams[index] = (string) Err.MessageParams[index];
								}

								ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, Err.MessageCode, MsgCodeParams);
								ErrList[ErrorListIndex]=Error;
								break;
							}
						}
						
						PsmContext.ClearErrors();
						PsmContext.AddErrors(ErrList);
					}
				}
				else if (CurrentPmtState is SendInitState)
                {
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Failed): SendInitState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new SendReconnectState(CurrentPmtState);
				}
				else if (CurrentPmtState is TransactionSendState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Failed): TransactionSendState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new SendRetryState(CurrentPmtState);
				}
				else if (CurrentPmtState is TransactionReceiveState)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState.Failed): TransactionReceiveState Entered.",
						PayflowConstants.SEVERITY_DEBUG);
					CurrentPmtState = new SendRetryState(CurrentPmtState);
				}
				// unknown state
				else
				{
					String AddlMessage = "Current State = " + mPaymentState.ToString();
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, null,
					                                                 PayflowConstants.SEVERITY_FATAL, mPaymentState.
					                                                 	IsXmlPayRequest, AddlMessage);
					if (!PsmContext.IsCommunicationErrorContained(Err))
					{
						PsmContext.AddError(Err);
					}
				}
			}

			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState): Obtained State = "
				+ mPaymentState.GetType().ToString(),
			                    PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.Communication.PaymentStateMachine.GetNextState(PaymentState): Exiting.",
			                   PayflowConstants.SEVERITY_DEBUG);
			return CurrentPmtState;
		}
		#endregion
	}
}