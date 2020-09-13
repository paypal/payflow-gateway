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
     *  Maps to Payflow Parameter: TENDER
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
     *  Maps to Payflow Parameter: TENDER
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
     *  Maps to Payflow Parameter: TENDER
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

