package paypal.payflow;

/**
 * This program is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

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