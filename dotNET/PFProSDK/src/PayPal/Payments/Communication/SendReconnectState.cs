#region "Imports"

#endregion

namespace PayPal.Payments.Communication
{
	/// <summary>
	/// Represents SendReconnectState
	/// </summary>
	internal class SendReconnectState : ReconnectState
	{
		#region "Construcotrs"

		/// <summary>
		/// Copy Constructor for SendInitState
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public SendReconnectState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion
	}
}