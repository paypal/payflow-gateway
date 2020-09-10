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

using System;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represent Receive State.
	/// </summary>
	abstract internal class ReceiveState : PaymentState
	{
		#region "Constructors"

		/// <summary>
		/// Copy Constructor for RecieveState.
		/// </summary>
		///<param name="CurrentPmtState">Current Payment State.</param>
		public ReceiveState(PaymentState CurrentPmtState) : base(CurrentPmtState)
		{
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Execute function.
		/// </summary>
		public override void Execute()
		{
			bool IsReceiveSuccess = false;
			Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Entered.", PayflowConstants.SEVERITY_DEBUG);
			if (!InProgress)
				return;
			try
			{
				//Begin Payflow Timeout Check Point 4
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
				//End Payflow Timeout Check Point 4
				String ResponseValue = mConnection.ReceiveResponse();
				IsReceiveSuccess = SetReceiveResponse(ResponseValue);
			}
			catch (Exception Ex)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Error occurred While Receiving Response.", PayflowConstants.SEVERITY_ERROR);
				Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Exception " + Ex.ToString(), PayflowConstants.SEVERITY_ERROR);
				IsReceiveSuccess = false;
			}
            //catch
            //{
            //    IsReceiveSuccess = false;
            //}
			finally
			{
				if (IsReceiveSuccess)
				{
					Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Receive Response = Success ", PayflowConstants.SEVERITY_INFO);
					SetStateSuccess();
				}
				else
				{
					Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Receive Response = Failure ", PayflowConstants.SEVERITY_INFO);
					SetStateFail();
				}
			}
			Logger.Instance.Log("PayPal.Payments.Communication.ReceiveState.Execute(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}


		/// <summary>
		/// Abstract declaration of SetReceiveResponse
		/// </summary>
		/// <param name="response">Response String.</param>
		/// <returns>True if response set,false otherwise.</returns>
		public abstract bool SetReceiveResponse(String response);

		#endregion
	}
}