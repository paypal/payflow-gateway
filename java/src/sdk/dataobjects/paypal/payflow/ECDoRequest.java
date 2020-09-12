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

package paypal.payflow;

/**
 * Used for ExpressCheckout DO operation.
 * {@link ECSetRequest}
 * {@link ECGetRequest}
 */
public class ECDoRequest extends ExpressCheckoutRequest {

    private String payerId;

    /**
     * * <summary>
     * Constructor for ECDoRequest
     *
     * @param token   - String
     * @param payerId String
     *                <p/>
     *                ECDoRequest is used to set the data required for a Express Checkout DO operation.
     *                </p>
     * @paypal.sample .............
     * <p/>
     * Create the ECDoRequest object
     * ECDoRequest doEC = new ECDoRequest("[tokenid]","[payerid]");
     * <p/>
     * .............
     */
    public ECDoRequest(String token, String payerId) {
        super(PayflowConstants.PARAM_ACTION_DO, token);
        this.payerId = payerId;
    }

    protected ECDoRequest(String token, String payerId, String Action) {
        super(PayflowConstants.PARAM_ACTION_DOBA, token);
        this.payerId = payerId;
    }

    /**
     * Gets the payerid parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYERID
     */
    public String getPayerId() {
        return payerId;
    }

    /**
     * Sets the payerid parameter.
     *
     * @param payerId - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYERID
     */

    public void setPayerId(String payerId) {
        this.payerId = payerId;
    }

    protected void generateRequest() {
        // This function is not called. All the
        //address information is validated and generated
        //in its respective derived classes.
        super.generateRequest();

        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYERID, payerId));

    }
}

