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
     *  Maps to Payflow Parameter:
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
