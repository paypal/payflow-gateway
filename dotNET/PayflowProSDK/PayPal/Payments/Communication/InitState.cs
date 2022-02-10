#region "Imports"

using System;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary> InitState - PayPal Payment State</summary>
	abstract internal class InitState : PaymentState
	{
		#region "Properties"

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for InitState.
		/// </summary>
		/// <param name="connection">PaymentConnection Object.</param>
		/// <param name="InitialParameterList">Initial Parameter list.</param>
		/// <param name="PsmContext">Context Object by ref</param>
		public InitState(PaymentConnection connection, String InitialParameterList, ref Context PsmContext) : base(connection, InitialParameterList, ref PsmContext)
		{
		}

		/// <summary>
		/// Copy Constructor for InitState.
		/// </summary>
		/// <param name="CurrentPaymentState">PaymentState Object.</param>
		public InitState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion

		/// <summary>
		/// Sets the appropriate server file path for the connection
		/// and initializes the connection uri.
		/// </summary>
		public override void Execute()
		{
			bool IsConnected = false;
			Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Entered.", PayflowConstants.SEVERITY_DEBUG);
			if (!InProgress)
				return;
			try
			{
				Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Initializing Connection.", PayflowConstants.SEVERITY_INFO);
				//Begin Payflow Timeout Check Point 2
				long TimeRemainingMsec;
				bool TimedOut = PayflowUtility.IsTimedOut(mConnection.TimeOut, mConnection.StartTime, out TimeRemainingMsec);
				if (TimedOut)
				{
					String AddlMessage = "Input timeout value in millisec : " + Connection.TimeOut.ToString();
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL, IsXmlPayRequest, AddlMessage);
					if (!CommContext.IsCommunicationErrorContained(Err))
					{
						CommContext.AddError(Err);
					}
				}
				else
				{
					mConnection.TimeOut = TimeRemainingMsec;
				}
				//End Payflow Timeout Check Point 2
				IsConnected = mConnection.ConnectToServer();
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Error occurred While Initializing Connection.", PayflowConstants.SEVERITY_ERROR);
				Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Exception " + Ex.ToString(), PayflowConstants.SEVERITY_ERROR);
				IsConnected = false;
			}
            //catch
            //{
            //    IsConnected = false;
            //}
			finally
			{
				if (IsConnected)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Connection Initialization =  Success", PayflowConstants.SEVERITY_INFO);
					SetStateSuccess();
				}
				else
				{
					Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Initialized Connection = Failure", PayflowConstants.SEVERITY_INFO);
					SetStateFail();
				}

			}

			Logger.Instance.Log("PayPal.Payments.Communication.InitState.Execute(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}
	}
}