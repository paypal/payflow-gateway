package paypal.payflow;



/**
 * Represents transaction send state.
 */
class TransactionSendState extends SendState {
    /**
     * Copy constructor for TransactionSendState.
     * Current Payment State object.
     *
     * @param currentPaymentState PaymentState
     */
    public TransactionSendState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.TransactionSendState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.TransactionSendState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Gets the request to be sent.
     */
    public String getSendRequest() {
        Logger.getInstance().log("paypal.payflow.TransactionSendState.GetSendRequest(): Entered", PayflowConstants.SEVERITY_DEBUG);
        String logRequest = super.getTransactionRequest();
        logRequest = PayflowUtility.maskSensitiveFields(logRequest);


        Logger.getInstance().log("paypal.payflow.TransactionSendState.GetSendRequest(): TransactionRequest = " + logRequest, PayflowConstants.SEVERITY_INFO);
        Logger.getInstance().log("paypal.payflow.TransactionSendState.GetSendRequest(): Exiting", PayflowConstants.SEVERITY_DEBUG);
        return super.getTransactionRequest();

    }

}