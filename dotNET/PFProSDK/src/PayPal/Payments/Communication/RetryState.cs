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