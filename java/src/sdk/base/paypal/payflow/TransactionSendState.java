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