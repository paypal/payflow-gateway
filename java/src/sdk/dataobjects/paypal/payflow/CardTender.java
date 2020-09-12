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
 * Used for Card tender related information.
 * CreditCard, PurchaseCard and SwipeCard are the Payment devices associated with this tender type.
 * {@link CreditCard}
 * {@link PurchaseCard}
 * {@link SwipeCard}
 */
public final class CardTender extends BaseTender {

    /**
     * This constructor is used to create a CardTender
     * with CreditCard as the payment device
     *
     * @param card CreditCard
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //card is the populated CreditCard object.
     * .............
     * <p/>
     * //Create the Tender object
     * CardTender tender = new CardTender(card);
     */
    public CardTender(CreditCard card) {
        super(PayflowConstants.TENDERTYPE_CARD, card);
    }

    /**
     * This constructor is used to create a CardTender
     * with PurchaseCard as the payment device
     *
     * @param purCard PurchaseCard
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //purCard is the populated PurchaseCard object.
     * .............
     * <p/>
     * //Create the Tender object
     * CardTender tender = new CardTender(purCard);
     */
    public CardTender(PurchaseCard purCard) {
        super(PayflowConstants.TENDERTYPE_CARD, purCard);
    }

    /**
     * This constructor is used to create a CardTender
     * with SwipeCard as the payment device
     *
     * @param swpCard CardTender
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //swpCard is the populated SwipeCard object.
     * .............
     * <p/>
     * //Create the Tender object
     * CardTender tender = new CardTender(swpCard);
     */
    public CardTender(SwipeCard swpCard) {
        super(PayflowConstants.TENDERTYPE_CARD, swpCard);
    }
}

