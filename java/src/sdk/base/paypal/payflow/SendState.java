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
 * Represents SendState.
 */
abstract class SendState extends PaymentState {

    /**
     * Copy constructor for SendState.
     *
     * @param currentPaymentState PaymentState
     */

    public SendState(PaymentState currentPaymentState) {
        super(currentPaymentState);
        Logger.getInstance().log("paypal.payflow.SendState(PaymentState) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.SendState(PaymentState) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }


    /**
     * Abstract Declaration of
     * GetSendRequest
     *
     * @return Return
     */

    public abstract String getSendRequest();

    /**
     * Execute function
     */
    public void execute() {
        boolean isSendSuccess = false;

        Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Entered", PayflowConstants.SEVERITY_DEBUG);
        if (getInProgress()) {
            try {
                //Begin Payflow Timeout Check Point 3
                if (PayflowUtility.isTimedOut(mConnection.getTimeout(), mConnection.getStartTime())) {
                    String addlMessage = "Input timeout value in millisec = " + getConnection().getTimeout();
                    ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
                    if (!getCommContext().isCommunicationErrorContained(err)) {
                        getCommContext().addError(err);
                    }
                }
                //End Payflow Timeout Check Point 3
                isSendSuccess = mConnection.sendToServer(getSendRequest());
            } catch (Exception ex) {
                Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Following Error occurred While Initializing Connection.", PayflowConstants.SEVERITY_ERROR);
                Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Exception " + ex.toString(), PayflowConstants.SEVERITY_ERROR);
                isSendSuccess = false;
            } finally {
                if (isSendSuccess) {
                    Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Send Data =  Success ", PayflowConstants.SEVERITY_INFO);
                    setStateSuccess();
                } else {
                    Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Send Data =  Failure ", PayflowConstants.SEVERITY_INFO);
                    setStateFail();
                }
            }
        }

        Logger.getInstance().log("paypal.payflowCommunication.SendState.Execute(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }


}
