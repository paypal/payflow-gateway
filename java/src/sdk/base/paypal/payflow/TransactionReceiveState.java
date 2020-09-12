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
