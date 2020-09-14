package paypal.payflow;

/**
 * This class is used to create and use an ACH( Automatic Clearing House ) Tender type.
 * BankAcct is the Payment device associated with this tender type. {@link BankAcct}
 */

public final class ACHTender extends BaseTender {

    /**
     * ACH Auth Type
     */
    private String authType;
    /**
     * ACH Prenote (Y/N)
     */
    private String preNote;
    /**
     * ACH Term City
     */
    private String termCity;
    /**
     * ACH Term State
     */
    private String termState;

    /**
     * ACHTender should be used to perform the transactions
     * in which the user provides his bank account details for
     * the online payment processing.
     *
     * @param bankAccount String
     *  Maps to Payflow Parameter: TENDER
     *  * <p>
     * .............
     * //bnkAcct is the populated BankAcct object.
     * .............
     *  * <p>
     * //Create the Tender object
     * ACHTender tender = new ACHTender(bnkAcct);
     */
    public ACHTender(BankAcct bankAccount) {
        super(PayflowConstants.TENDERTYPE_ACH, bankAccount);
    }

    /**
     * Gets the Authtype.
     *  * <p>
     * The type of authorization received from the payer.
     * Allowed Auth Types are:
     *
     * AUTHTYPE - Description
     *
     * CCD - Default for B2B format accounts
     * PPD - Standard customer authorization method) for B2C format accounts.
     * ARC - Accounts Receivables check entry for a single entry debit.
     * RCK - Re-presented check entry for a single entry debit.
     * WEB - The customer authorized the payment over the Internet.
     * TEL - Debit authorization obtained by telephone.
     * POP - Point of Purchase check entry for a single entry debit.
     *
     * @return authType
     *  <p> Maps to Payflow Parameter: AUTHTYPE </p>
     */

    public String getAuthType() {
        return authType;
    }

    /**
     * Sets the Authtype.
     *  * <p>
     * The type of authorization received from the payer.
     * Allowed Auth Types are:
     *
     * AUTHTYPE - Description
     *
     * CCD - Default for B2B format accounts
     * PPD - Standard customer authorization method) for B2C format accounts.
     * ARC - Accounts Receivables check entry for a single entry debit.
     * RCK - Re-presented check entry for a single entry debit.
     * WEB - The customer authorized the payment over the Internet.
     * TEL - Debit authorization obtained by telephone.
     * POP - Point of Purchase check entry for a single entry debit.
     *
     * @param authType String
     *  <p> Maps to Payflow Parameter: AUTHTYPE </p>
     */
    public void setAuthType(String authType) {
        this.authType = authType;
    }

    /**
     * Gets the PreNote.
     *  * <p>
     * Prenote indicates a prenotification payment with no amount.
     * Used to verify bank account validity. Receiving banks are not required
     * to respond to prenotification payments.
     * Allowed prenote values are:
     *
     * PRENOTE  - Description
     *
     * N Default. AMT needs to be passed.
     * Y Default. AMT does not need to be passed.
     *
     * @return preNote
     *  <p> Maps to Payflow Parameter: PRENOTE </p>
     */
    public String getPreNote() {
        return preNote;
    }

    /**
     * Sets the PreNote.
     *  * <p>
     * Prenote indicates a prenotification payment with no amount.
     * Used to verify bank account validity. Receiving banks are not required
     * to respond to prenotification payments.
     * Allowed prenote values are:
     *
     * PRENOTE  - Description
     *
     * N Default. AMT needs to be passed.
     * Y Default. AMT does not need to be passed.
     *
     * @param preNote String
     *  <p> Maps to Payflow Parameter: PRENOTE </p>
     */
    public void setPreNote(String preNote) {
        this.preNote = preNote;
    }

    /**
     * Gets the Term City.
     * <p>City where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @return termCity
     *  <p> Maps to Payflow Parameter: TERMCITY </p>
     */
    public String getTermCity() {
        return termCity;
    }

    /**
     * Gets the Term City.
     * <p>City where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @param termCity String
     *  <p> Maps to Payflow Parameter: TERMCITY </p>
     */
    public void setTermCity(String termCity) {
        this.termCity = termCity;
    }

    /**
     * Gets the TermState.
     * <p>State where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @return termState
     *  <p> Maps to Payflow Parameter: TERMSTATE </p>
     */
    public String getTermState() {
        return termState;
    }

    /**
     * Gets the TermState.
     * <p> State where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @param termState String
     *  <p> Maps to Payflow Parameter: TERMSTATE </p>
     */
    public void setTermState(String termState) {
        this.termState = termState;
    }

    protected void generateRequest() {
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHTYPE, authType));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PRENOTE, preNote));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TERMCITY, termCity));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TERMSTATE, termState));
    }


}