package paypal.payflow;



class SendRetryState extends RetryState {
    /**
     * @param currentPaymentState PaymentState
     */
    public SendRetryState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.SendRetryState.SendRetryState(PaymentSate) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendRetryState.SendRetryState(PaymentSate) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }
}
