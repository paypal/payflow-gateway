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