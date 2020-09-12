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