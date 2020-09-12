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
