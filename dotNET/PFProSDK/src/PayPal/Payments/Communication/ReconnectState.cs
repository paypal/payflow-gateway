#region "Copyright"

//PayPal Payflow Pro .NET SDK
//Copyright (C) 2014  PayPal, Inc.
//
//This file is part of the Payflow Pro .NET SDK
//
//The Payflow .NET SDK is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//any later version.
//
//The Payflow .NET SDK is is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with the Payflow .NET SDK.  If not, see <http://www.gnu.org/licenses/>.


#endregion

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