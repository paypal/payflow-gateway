package paypal.payflow;




/**
 * Represents Reconnect State.
 */
abstract class ReconnectState extends PaymentState {

    /**
     * Copy Constructor for ReconnectState.
     *
     * @param currentPmtState PaymentState
     */
    public ReconnectState(PaymentState currentPmtState) {
        super(currentPmtState);

        Logger.getInstance().log("paypal.payflow.ReconnectState.ReconnectState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.ReconnectState.ReconnectState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Execute function.
     */
    public void execute() {
        Logger.getInstance().log("paypal.payflow.ReconnectState.Execute(): Entered", PayflowConstants.SEVERITY_DEBUG);

        if (getInProgress()) {

            mAttemptNo++;

            Logger.getInstance().log("paypal.payflow.ReconnectState.Execute(): Current Reconnect Attempt No. = " + mAttemptNo, PayflowConstants.SEVERITY_DEBUG);
            Logger.getInstance().log("paypal.payflow.ReconnectState.Execute(): Maximum Number of Reconnect Attempts Allowed = " + PayflowConstants.MAX_RETRY, PayflowConstants.SEVERITY_DEBUG);
            if (mAttemptNo > PayflowConstants.MAX_RETRY) {
                Logger.getInstance().log("paypal.payflow.ReconnectState.Execute(): Maximum Number of Reconnect Attempts Exceeded.", PayflowConstants.SEVERITY_WARN);
                setStateFail();
            } else {
                //implementing delay between each reconnect attempt
                synchronized (this) {
                    if (this.mAttemptNo > 0) {
                        try {
                            wait(PayflowConstants.RETRY_DELAY);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                }
                setStateSuccess();
            }

            Logger.getInstance().log("paypal.payflow.ReconnectState.Execute() : Exiting", PayflowConstants.SEVERITY_DEBUG);
        }
        Logger.getInstance().log("paypal.payflow.ReconnectState.Execute() : Entered", PayflowConstants.SEVERITY_DEBUG);
    }

}
