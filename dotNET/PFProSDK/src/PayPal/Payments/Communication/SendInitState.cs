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
using PayPal.Payments.Common;

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents SendInitState.
	/// </summary>
	internal class SendInitState : InitState
	{
		#region "Properties"

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for SendInitState Object.
		/// </summary>
		/// <param name="Connection">PaymentConnection Object.</param>
		/// <param name="InitialParameterList">Parameter List</param>
		/// <param name="PsmContext">Context Object by reference.</param>
		public SendInitState(PaymentConnection Connection, String InitialParameterList, ref Context PsmContext) : base(Connection, InitialParameterList, ref PsmContext)
		{
		}

		/// <summary>
		/// Copy Constructor for SendInitState
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public SendInitState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion
	}
}