package paypal.payflow;



/**
 * Represents SendReconnectState
 */
class SendReconnectState extends ReconnectState {

    /**
     * Copy Constructor for SendInitState
     *
     * @param currentPaymentState PaymentState
     */
    public SendReconnectState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.SendReconnectState.SendReconnectState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendReconnectState.SendReconnectState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

}
