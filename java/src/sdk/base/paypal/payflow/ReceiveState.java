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
 * Represent Receive State.
 */
abstract class ReceiveState extends PaymentState {

    /**
     * Copy Constructor for ReceiveState.
     *
     * @param currentPmtState PaymentState
     */
    public ReceiveState(PaymentState currentPmtState) {
        super(currentPmtState);
        Logger.getInstance().log("paypal.payflow.ReceiveState.ReceiveState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.ReceiveState.ReceiveState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Execute function.
     */
    public void execute() {
        boolean isReceiveSuccess = false;
        Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Entered", PayflowConstants.SEVERITY_DEBUG);
        if (getInProgress()) {
            try {
                //Begin Payflow Timeout Check Point 4
                if (PayflowUtility.isTimedOut(mConnection.getTimeout(), mConnection.getStartTime())) {
                    String addlMessage = "Input timeout value in millisec = " + getConnection().getTimeout();
                    ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
                    if (!getCommContext().isCommunicationErrorContained(err)) {
                        getCommContext().addError(err);
                    }
                }
                //End Payflow Timeout Check Point 4
                String responseValue = mConnection.receiveResponse();
                isReceiveSuccess = setReceiveResponse(responseValue);
             } catch (Exception Ex) {
                Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Following Error occurred While Receiving Response.", PayflowConstants.SEVERITY_ERROR);
                Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Exception " + Ex.toString(), PayflowConstants.SEVERITY_ERROR);
                isReceiveSuccess = false;
            } finally {
                if (isReceiveSuccess) {
                    Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Receive Response = Success ", PayflowConstants.SEVERITY_INFO);
                    setStateSuccess();
                } else {
                    Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Receive Response = Failure ", PayflowConstants.SEVERITY_INFO);
                    setStateFail();
                }
            }
        }
        Logger.getInstance().log("paypal.payflow.ReceiveState.Execute(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }


    /**
     * Abstract declaration of SetReceiveResponse
     *
     * @param response String
     * @return boolean
     */
    public abstract boolean setReceiveResponse(String response);

}