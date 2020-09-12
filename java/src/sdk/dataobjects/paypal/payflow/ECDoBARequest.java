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
 * Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase DO operation.
 * {@link ECSetBARequest}
 * {@link ECGetBARequest}
 */

public class ECDoBARequest extends ECDoRequest {

    /**
     * * <summary>
     * Constructor for ECDoBARequest
     *
     * @param token   String
     * @param payerId String
     *                <p/>
     *                <p/>
     *                ECDoBARequest is used to set the data required for a Express Checkout DO operation
     *                with Billing Agreement (Reference Transaction) without Purchase.
     *                </p>
     * @paypal.sample .............
     * <p/>
     * Create the ECDoBARequest object
     * ECDoBARequest doEC = new ECDoBARequest("[tokenid]","[payerid]");
     * <p/>
     * .............
     */

    public ECDoBARequest(String token, String payerId) {
        super(token, payerId, PayflowConstants.PARAM_ACTION_DOBA);

    }

}
