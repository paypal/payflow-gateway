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
 * Used for Purchase card related information
 * PurchaseCard is associated with CardTender. {@link CardTender}
 */
public final class PurchaseCard extends PaymentCard {

    private String commCard;

    /**
     * @param acct     Purchase Card number
     * @param expDate  Card expiry date (format mmyy)
     * @param cardType Purchase Card  type (P - Personal, C - Corprate, B - Business)
     *                 <p/>
     * @paypal.sample Maps to Payflow Parameter:
     * ACCT , EXPDATE , COMMCARD
     * <p/>
     * //Create the PaymentDevice object
     * PurchaseCard payDevice = new PurchaseCard("XXXXXXXXXX","XXXX","C");
     * </p>
     */
    public PurchaseCard(String acct, String expDate, String cardType) {
        super(acct, expDate);
        commCard = cardType;
    }

    /**
     * Generate the Transaction request. Overrides PaymentCard.generateRequest()
     */
    protected void generateRequest() {
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COMMCARD, commCard));
    }


}
