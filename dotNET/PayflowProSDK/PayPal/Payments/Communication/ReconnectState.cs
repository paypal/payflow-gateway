#region "Imports"

using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Logging;
using System.Threading;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents Reconnect State.
	/// </summary>
	abstract internal class ReconnectState : PaymentState
	{
		#region "Constructors"

		/// <summary>
		/// Copy Constructor for ReconnectState.
		/// </summary>
		/// <param name="CurrentPmtState">Current Payment State.</param>
		public ReconnectState(PaymentState CurrentPmtState) : base(CurrentPmtState)
		{
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Execute function.
		/// </summary>
		public override void Execute()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.ReconnectState.Execute(): Entered.", PayflowConstants.SEVERITY_DEBUG);

			if (!InProgress)
				return;

			mAttemptNo++;
            bool IsConnected = false;
			Logger.Instance.Log("PayPal.Payments.Communication.ReconnectState.Execute(): Current Reconnect Attempt No. = " + mAttemptNo.ToString(), PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.Communication.ReconnectState.Execute(): Maximum Number of Reconnect Attempts Allowed = " + PayflowConstants.MAX_RETRY.ToString(), PayflowConstants.SEVERITY_INFO);
			if (mAttemptNo > PayflowConstants.MAX_RETRY)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.ReconnectState.Execute(): Maximum Number of Reconnect Attempts Exceeded.", PayflowConstants.SEVERITY_WARN);
				SetStateFail();
			}
			else
			{
                mConnection.Disconnect();
                IsConnected = mConnection.ConnectToServer();
				Thread.Sleep(PayflowConstants.DEFAULT_RETRYCONNECTIONTIME);
				SetStateSuccess();
			}
			Logger.Instance.Log("PayPal.Payments.Communication.ReconnectState.Execute(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		#endregion
	}
}