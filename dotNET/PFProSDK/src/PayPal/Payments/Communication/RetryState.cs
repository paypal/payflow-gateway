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

using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents RetryState.
	/// </summary>
	abstract internal class RetryState : PaymentState
	{
		#region "Constructors"

		/// <summary>
		/// Copy Constructor for RetryState.
		/// </summary>
		/// <param name="CurrentPmtState">Current Payment State.</param>
		public RetryState(PaymentState CurrentPmtState) : base(CurrentPmtState)
		{
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Execute function.
		/// </summary>
		public override void Execute()
		{
			Logger.Instance.Log("PayPal.Payments.Communication.RetryState.Execute(): Entered.", PayflowConstants.SEVERITY_DEBUG);
			mConnection.Disconnect();
			SetStateSuccess();
			Logger.Instance.Log("PayPal.Payments.Communication.RetryState.Execute(): Exiting.", PayflowConstants.SEVERITY_DEBUG);
		}

		#endregion
	}
}