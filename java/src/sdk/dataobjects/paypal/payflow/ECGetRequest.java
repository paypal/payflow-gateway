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
 * Used for ExpressCheckout GET operation.
 * {@link ECSetRequest}
 * {@link ECDoRequest}
 */

public class ECGetRequest extends ExpressCheckoutRequest {

    /**
     * Constructor for ECGetRequest
     *
     * @param Token String
     *              <p/>
     *              <p/>
     *              ECGetRequest is used to set the data required for a Express Checkout GET operation.
     *              </p>
     * @paypal.sample .............
     * <p/>
     * Create the ECGetRequest object
     * ECGetRequest getEC = new ECGetRequest("[tokenid]");
     * <p/>
     * .............
     */
    public ECGetRequest(String Token) {
        super(PayflowConstants.PARAM_ACTION_GET, Token);
    }

    protected ECGetRequest(String Token, String Action) {
        super(PayflowConstants.PARAM_ACTION_GETBA, Token);
    }

}

