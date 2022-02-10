#region "Imports"

using System;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents SendState.
	/// </summary>
	abstract internal class SendState : PaymentState
	{
		#region "Constructors"

		/// <summary>
		/// Copy constructor for SendState.
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public SendState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion		

		#region "Functions"

		/// <summary>
		/// Abstract Declaration of 
		/// GetSendRequest
		/// </summary>
		/// <returns>request to be sent</returns>
		public abstract String GetSendRequest();

		/// <summary>
		/// Execute function
		/// </summary>
		public override void Execute()
		{
			bool IsSendSuccess = false;

			Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Entered.", PayflowConstants.SEVERITY_DEBUG);
			if (!InProgress)
				return;
			try
			{
				//Begin Payflow Timeout Check Point 3
				long TimeRemainingMsec;
				if (PayflowUtility.IsTimedOut(mConnection.TimeOut, mConnection.StartTime, out TimeRemainingMsec))
				{
					String AddlMessage = "Input timeout value in millisec = " + Connection.TimeOut.ToString();
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
				//End Payflow Timeout Check Point 3
				IsSendSuccess = mConnection.SendToServer(GetSendRequest());
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Error occurred While Initializing Connection.", PayflowConstants.SEVERITY_ERROR);
				Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Exception " + Ex.ToString(), PayflowConstants.SEVERITY_ERROR);
				IsSendSuccess = false;
			}
            //catch
            //{
            //    IsSendSuccess = false;
            //}
			finally
			{
				if (IsSendSuccess)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Send Data =  Success ", PayflowConstants.SEVERITY_INFO);
					SetStateSuccess();
				}
				else
				{
					Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Send Data =  Failure ", PayflowConstants.SEVERITY_INFO);
					SetStateFail();
				}
			}
			Logger.Instance.Log("PayPal.Payments.Communication.SendState.Execute(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		#endregion
	}
}