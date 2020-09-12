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
 * Used for Check Payment related information.
 * CheckPayment is associated with CheckTender. {@link CheckTender}
 */
public final class CheckPayment extends PaymentDevice {

    /**
     * Constructor
     *
     * @param micr MICR Value
     *             This is used as Payment Device for the CheckTender.
     *             <p/>
     * @paypal.sample Maps to Payflow Parameter: MICR
     * //Create the CheckPayment object
     * CheckPayment payDevice = new CheckPayment("XXXXXXXXXX");
     * </p>
     */
    public CheckPayment(String micr) {
        super(micr);
    }

    protected void generateRequest() {
//    	Put the base field Acct as MICR.
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MICR, super.getAcct()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NAME, super.getName()));
    }

}