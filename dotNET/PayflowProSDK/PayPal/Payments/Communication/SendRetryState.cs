namespace PayPal.Payments.Communication
{
	internal class SendRetryState : RetryState
	{
		public SendRetryState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}
	}
}