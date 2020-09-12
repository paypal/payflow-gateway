package paypal.payflow;




/**
 * Represents transaction receive state.
 */
class TransactionReceiveState extends ReceiveState {

    /**
     * Copy constructor for TransactionReceiveState.
     *
     * @param currentPaymentState PaymentState
     */
    public TransactionReceiveState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.TransactionReceiveState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.TransactionReceiveState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Sets the received response
     *
     * @param response String
     */
    public boolean setReceiveResponse(String response) {
        boolean retVal;
        Logger.getInstance().log("paypal.payflow.TransactionReceiveState.SetReceiveResponse(String): Entered", PayflowConstants.SEVERITY_DEBUG);
        if (response == null) {
            Logger.getInstance().log("paypal.payflow.TransactionReceiveState.SetReceiveResponse(String): Response = null", PayflowConstants.SEVERITY_WARN);
            retVal = false;
        } else if (response.length() == 0) {
            Logger.getInstance().log("paypal.payflow.TransactionReceiveState.SetReceiveResponse(String): Response.Length = 0", PayflowConstants.SEVERITY_WARN);
            retVal = false;
        } else {
            //Get proper response
            setTransactionResponse(response);
            Logger.getInstance().log("paypal.payflow.TransactionReceiveState.SetReceiveResponse(String): Response = " + getTransactionResponse(), PayflowConstants.SEVERITY_INFO);
            retVal = true;
            setProgressComplete();
        }


        Logger.getInstance().log("paypal.payflow.TransactionReceiveState.SetReceiveResponse(String): Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

}
