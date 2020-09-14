package paypal.payflow;

/**
 * Used for swipe card information
 *  * <p>
 * Used to pass the Track 1 or Track 2 data (the card's magnetic stripe information) for card-present
 * transactions. Include either Track 1 or Track 2 data'not both. If Track 1 is physically damaged, the
 * POS application can send Track 2 data instead.
 *  * <p>
 * SwipeCard is associated with CardTender. {@link CardTender}
 * </p>
 */

public final class SwipeCard extends PaymentDevice {
    /**
     * Constructor for SwipeCard
     *
     * @param swipe Card Swipe value
     *               * <p>
     *              This is used as Payment Device for the CardTender.
     *  <p>
     * Maps to Payflow Parameter: SWIPE
     *  * <p>
     * //Create the SwipeCard object
     * SwipeCard payDevice = new SwipeCard("XXXXXXXXXXXXXXXXXXXXXXXXXXX");
     */
    public SwipeCard(String swipe) {
        super(swipe);
    }

    /**
     *
     */
    protected void generateRequest() {
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SWIPE, super.getAcct()));
    }
}

