package paypal.payflow;



/**
 * Represents RetryState.
 */
abstract class RetryState extends PaymentState {

    /**
     * Copy Constructor for RetryState.
     *
     * @param currentPmtState PaymentState
     */
    public RetryState(PaymentState currentPmtState) {
        super(currentPmtState);
        Logger.getInstance().log("paypal.payflow.RetryState.RetryState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.RetryState.RetryState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Execute function.
     */
    public void execute() {
        Logger.getInstance().log("paypal.payflow.RetryState.Execute(): Entered", PayflowConstants.SEVERITY_DEBUG);
        mConnection.disconnect();
        setStateSuccess();
        Logger.getInstance().log("paypal.payflow.RetryState.Execute(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

}