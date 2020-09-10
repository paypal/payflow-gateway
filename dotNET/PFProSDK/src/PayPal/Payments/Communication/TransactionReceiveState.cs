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
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using System.Collections;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents transaction receive state.
	/// </summary>
	internal class TransactionReceiveState : ReceiveState
	{
		#region "Constructors"

		/// <summary>
		/// Copy constructor for TransactionReceiveState.
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public TransactionReceiveState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion		

		#region "Functions"

		/// <summary>
		/// Sets the received response
		/// </summary>
		/// <param name="Response">response</param>
		/// <returns>true if response set, false otherwise.</returns>
		public override bool SetReceiveResponse(String Response)
		{
			bool RetVal = false;
			Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Entered.", PayflowConstants.SEVERITY_DEBUG);
            if (Response == null)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response = null", PayflowConstants.SEVERITY_WARN);
				RetVal = false;
			}
			else if (Response.Length == 0)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response.Length = 0", PayflowConstants.SEVERITY_WARN);
				RetVal = false;
			}
			else
			{
				TransactionResponse = Response;
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response = " + TransactionResponse, PayflowConstants.SEVERITY_INFO);
				RetVal = true;
			}

            SetProgressComplete();


			Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
			return RetVal;
		}

		#endregion
	}
}