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
 * Used for Check tender related information.
 * CheckPayment the Payment devices associated with this tender type.
 * {@link CheckPayment}
 */
public final class CheckTender extends BaseTender {
    /**
     * This constructor is used to create a CheckTender
     * with CheckPayment as the payment device
     *
     * @param check CheckTender
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //check is the populated CheckPaymentobject.
     * .............
     * <p/>
     * //Create the Tender object
     * CheckTender tender = new CardTender(check);
     */
    public CheckTender(CheckPayment check) {
        super(PayflowConstants.TENDERTYPE_TELECHECK, check);
    }

}