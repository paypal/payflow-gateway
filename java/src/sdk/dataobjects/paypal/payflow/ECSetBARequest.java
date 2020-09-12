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
 * Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase SET operation.
 * {@link ECGetBARequest}
 * {@link ECDoBARequest}
 */
public class ECSetBARequest extends ECSetRequest {

    /**
     * Constructor for ECSetBARequest
     *
     * @param ReturnUrl   - String
     * @param CancelUrl   - String
     * @param BillingType - String
     * @param BA_Desc     - String
     * @param PaymentType - String
     * @param BA_Custom   - String
     *                    <p/>
     *                    <p/>
     *                    ECSetBARequest is used to set the data required for a Express Checkout Billing Agreement SET operation
     *                    with Billing Agreement (Reference Transaction) without Purchase.
     *                    </p>
     * @paypal.sample .............
     * <p/>
     * Create the ECSetBARequest object
     * ECSetBARequest setEC = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom);
     * <p/>
     * .............
     * </code>
     */
    public ECSetBARequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc,
                          String PaymentType, String BA_Custom) {
        super(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom, PayflowConstants.PARAM_ACTION_SETBA);
    }
}
