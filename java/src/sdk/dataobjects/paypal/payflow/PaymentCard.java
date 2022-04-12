package paypal.payflow;

/**
 * This abstract class serves as base class for Card Payment devices.
 * This class can be extended to create a new payment device type.
 */
abstract class PaymentCard extends PaymentDevice {
    /**
     * Card Expiry Date
     */
    private String expDate;
    /**
     * Card CVV2 code
     */
    private String cvv2;
    /**
     * Card Sart used for Swicth/Solo cards.
     */
    private String cardStart;
    /**
     * Card Issue used for Swicth/Solo cards.
     */
    private String cardIssue;
    /**
     * Flag card as stored credential (card on file).
     */
    private String cardOnFile;
    /**
     * Transaction Id for stored credential (card on file).
     */
    private String txId;
    /**
     * Payment Account Reference
     */
    private String par;


    /**
     * Constructor
     *
     * @param acct    Card number
     * @param expDate Card expiry date
     */
    protected PaymentCard(String acct, String expDate) {
        super(acct);
        this.expDate = expDate;
    }

    /**
     * Gets the CVV2 value.
     * Card validation code. This is the 3 or 4 digit code present at the back side of the card.
     *
     * @return CVV2 value
     *          * <p>
     *  Maps to Payflow Parameters as follows: CVV2
     * </p>
     */
    public String getCvv2() {
        return cvv2;
    }

    /**
     * Sets the CVV2 value.
     * Card validation code. This is the 3 or 4 digit code present at the back side of the card.
     *
     * @param cvv2 CVV2 value
     *              * <p>
     *  Maps to Payflow Parameters as follows: CVV2
     * </p>
     */
    public void setCvv2(String cvv2) {
        this.cvv2 = cvv2;
    }

    /**
     * Gets the cardIssue
     * <p> Used in Switch/Solo cards </p>
     *
     * @return cardIssue String
     *          * <p>
     *  Maps to Payflow Parameter : CARDISSUE
     * </p>
     */
    public String getCardIssue() {
        return cardIssue;
    }

    /**
     * Sets the cardIssue
     * <p> Used in Switch/Solo cards </p>
     *
     * @param cardIssue String
     *                   * <p>
     *  Maps to Payflow Parameter : CARDISSUE
     * </p>
     */
    public void setCardIssue(String cardIssue) {
        this.cardIssue = cardIssue;
    }

    /**
     * Gets the cardStart
     * <p> Used in Switch/Solo cards </p>
     *
     * @return cardStart String
     *          * <p>
     *  Maps to Payflow Parameter : CARDSTART
     * </p>
     */
    public String getCardStart() {
        return cardStart;
    }

    /**
     * Sets the cardStart
     * <p> Used in Switch/Solo cards </p>
     *
     * @param cardStart String
     *                   * <p>
     *  Maps to Payflow Parameter : CARDSTART
     * </p>
     */
    public void setCardStart(String cardStart) {
        this.cardStart = cardStart;
    }

    /**
     * Gets the cardOnFile
     * <p> Used to store credit card (stored credential)  </p>
     *
     * @return cardOnFile String
     *          * <p>
     *  Maps to Payflow Parameter : CARDONFILE
     * </p>
     */
    public String getCardOnFile() {
        return cardOnFile;
    }

    /**
     * Sets the cardOnFile
     * <p> Used to store credit card (stored credential) </p>
     *
     * @param cardOnFile String
     *                   * <p>
     *  Maps to Payflow Parameter : CARDONFILE
     * </p>
     */
    public void setCardOnFile(String cardOnFile) {
        this.cardOnFile= cardOnFile;
    }

    /**
     * Gets the TxId
     * <p> The transaction Id to reference a stored credential.</p>
     *
     * @return txId String
     *          * <p>
     *  Maps to Payflow Parameter : TXID
     * </p>
     */
    public String getTxId() {
        return txId;
    }
    /**
     * Sets the Transaction Id (stored credential).
     * <p> The transaction Id to reference a stored credential.</p>
     *
     * @param txId String
     *                   * <p>
     *  Maps to Payflow Parameter : TXID
     * </p>
     */
    public void setTxId(String txId) {
        this.txId = txId;
    }


    /**
     * Gets the par
     * <p>unique Primary Account Number (PAN)</p>
     *
     * @return par String
     *          * <p>
     *  Maps to Payflow Parameter : PAR
     * </p>
     */
    public String getParId() {
        return par;
    }
    /**
     * Sets the Payment Account Reference.
     * <p>A non-financial reference number assigned to each unique Primary Account Number (PAN) and mapped to all its affiliated Payment Tokens.</p>
     *
     * @param par String
     *                   * <p>
     *  Maps to Payflow Parameter : PAR
     * </p>
     */
    public void setPar(String par) {
        this.par = par;
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_EXPDATE, expDate));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CVV2, cvv2));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CARDSTART, cardStart));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CARDISSUE, cardIssue));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CARDONFILE, cardOnFile));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TXID, txId));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAR, par));
    }
}
