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
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Logging;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents transaction send state.
	/// </summary>
	internal class TransactionSendState : SendState
	{
		#region "Constructors"

		/// <summary>
		/// Copy constructor for TransactionSendState.
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public TransactionSendState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Gets the request to be sent.
		/// </summary>
		/// <returns>Request to be sent.</returns>
		override public String GetSendRequest()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.TransactionSendState.GetSendRequest(): Entered.", PayflowConstants.SEVERITY_DEBUG);

			String LogRequest = base.TransactionRequest;
			LogRequest = PayflowUtility.MaskSensitiveFields(LogRequest);


			Logger.Instance.Log("PayPal.Payments.Communication.TransactionSendState.GetSendRequest(): Request = " + LogRequest, PayflowConstants.SEVERITY_INFO);
			Logger.Instance.Log("PayPal.Payments.Communication.TransactionSendState.GetSendRequest(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
			return base.TransactionRequest;

		}

		#endregion
	}
}