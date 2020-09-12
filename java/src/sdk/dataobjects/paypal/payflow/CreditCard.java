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
 * Used for Credit Card related information
 * CreditCard is associated with CardTender. {@link CardTender}
 */
public final class CreditCard extends PaymentCard {
    /**
     * @param acct    Credit card number
     * @param expDate Card expiry date
     *                This is used as Payment Device for the CardTender.
     *                <p/>
     * @paypal.sample Maps to Payflow Parameter: ACCT , EXPDATE
     * //Create the CreditCard object
     * CreditCard payDevice = new CreditCard("XXXXXXXXXX","XXXX");
     * </p>
     */
    public CreditCard(String acct, String expDate) {
        super(acct, expDate);
    }
}

