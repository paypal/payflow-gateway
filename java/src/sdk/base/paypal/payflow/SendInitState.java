package paypal.payflow;




/**
 * Represents SendInitState.
 */
class SendInitState extends InitState {
    /**
     * Gets the Server file path.
     */
    public String getServerFile() {
        Logger.getInstance().log("paypal.payflow.SendInitState.getServerFile() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendInitState.getServerFile() : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return PayflowConstants.PAYFLOW_SERVER_TRANSACTION_PATH;

    }

    /**
     * Constructor for SendInitState Object.
     *
     * @param connection           PaymentConnection
     * @param initialParameterList String
     * @param psmContext           Context
     * @throws Exception Exception
     */
    public SendInitState(PaymentConnection connection, String initialParameterList, Context psmContext) throws Exception {
        super(connection, initialParameterList, psmContext);
        Logger.getInstance().log("paypal.payflow.SendInitState.SendInitState(PaymentConnection,String,Context) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendInitState.SendInitState(PaymentConnection,String,Context) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Copy Constructor for SendInitState
     *
     * @param currentPaymentState PaymentState
     */
    public SendInitState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.SendInitState.SendInitState(PaymentState)", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendInitState.SendInitState(PaymentState)", PayflowConstants.SEVERITY_DEBUG);
    }


}