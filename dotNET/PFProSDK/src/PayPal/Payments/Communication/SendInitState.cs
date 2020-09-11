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