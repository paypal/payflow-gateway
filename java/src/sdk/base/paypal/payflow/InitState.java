package paypal.payflow;

/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */


/**
 * InitState - PayPal Payment State
 */
abstract class InitState extends PaymentState {

    public abstract String getServerFile();

    /**
     * Constructor for InitState.
     *
     * @param connection           PaymentConnection
     * @param initialParameterList String
     * @param psmContext           Context
     * @throws Exception Exception
     */
    public InitState(PaymentConnection connection, String initialParameterList, Context psmContext) throws Exception {
        super(connection, initialParameterList, psmContext);
        Logger.getInstance().log("paypal.payflow.InitState.InitState(PaymentConnection, String, Context) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.InitState.InitState(PaymentConnection, String, Context) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Copy Constructor for InitState.
     *
     * @param currentPaymentState PaymentState
     */
    public InitState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.InitState.InitState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.InitState.InitState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Sets the appropriate server file path for the connection
     * and initializes the connection uri.
     */
    public void execute() {
        Logger.getInstance().log("paypal.payflow.InitState.Execute(): Entered", PayflowConstants.SEVERITY_DEBUG);
        boolean isConnected = false;
        if (getInProgress()) {
            try {
                Logger.getInstance().log("paypal.payflow.InitState.Execute(): Initializing Connection.", PayflowConstants.SEVERITY_INFO);


                boolean timedOut = PayflowUtility.isTimedOut(mConnection.getTimeout(), mConnection.getStartTime());
                if (timedOut) {
                    String addlMessage = "Input timeout value in millisec : " + mConnection.getTimeout();
                    ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
                    if (!getCommContext().isCommunicationErrorContained(err)) {
                        getCommContext().addError(err);
                    }
                }

                isConnected = mConnection.connectToServer(getServerFile());
            } catch (Exception Ex) {
                Logger.getInstance().log("paypal.payflow.InitState.Execute(): Following Error occurred While Initializing Connection.", PayflowConstants.SEVERITY_ERROR);
                Logger.getInstance().log("paypal.payflow.InitState.Execute(): Exception " + Ex.toString(), PayflowConstants.SEVERITY_ERROR);
                isConnected = false;
            } finally {
                if (isConnected) {
                    Logger.getInstance().log("paypal.payflow.InitState.Execute(): Connection Initialization =  Success", PayflowConstants.SEVERITY_INFO);
                    setStateSuccess();
                } else {
                    Logger.getInstance().log("paypal.payflow.InitState.Execute(): Initialized Connection = Failure", PayflowConstants.SEVERITY_INFO);
                    setStateFail();
                }

            }
        }
        Logger.getInstance().log("paypal.payflow.InitState.Execute(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }
}