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
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //bnkAcct is the populated BankAcct object.
     * .............
     * <p/>
     * //Create the Tender object
     * ACHTender tender = new ACHTender(bnkAcct);
     */
    public ACHTender(BankAcct bankAccount) {
        super(PayflowConstants.TENDERTYPE_ACH, bankAccount);
    }

    /**
     * Gets the Authtype.
     * <p/>
     * The type of authorization received from the payer.
     * Allowed Auth Types are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth}AUTHTYPE {@paypal.elth}
     * {@paypal.lth}Description  {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} CCD {@paypal.eltd}
     * {@paypal.ltd}Default for B2B format accounts{@paypal.eltd}
     * {@paypal.ltr}
     * {@paypal.ltd} PPD {@paypal.eltd}
     * {@paypal.ltd}Standard customer authorization method) for B2C format accounts.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} ARC {@paypal.eltd}
     * {@paypal.ltd}Accounts Receivables check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} RCK {@paypal.eltd}
     * {@paypal.ltd}Re-presented check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} WEB {@paypal.eltd}
     * {@paypal.ltd}The customer authorized the payment over the Internet.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} TEL {@paypal.eltd}
     * {@paypal.ltd}Debit authorization obtained by telephone.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} POP {@paypal.eltd}
     * {@paypal.ltd}Point of Purchase check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @return authType
     * @paypal.sample <p> Maps to Payflow Parameter: AUTHTYPE </p>
     */

    public String getAuthType() {
        return authType;
    }

    /**
     * Sets the Authtype.
     * <p/>
     * The type of authorization received from the payer.
     * Allowed Auth Types are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth}AUTHTYPE {@paypal.elth}
     * {@paypal.lth}Description  {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} CCD {@paypal.eltd}
     * {@paypal.ltd}Default for B2B format accounts{@paypal.eltd}
     * {@paypal.ltr}
     * {@paypal.ltd} PPD {@paypal.eltd}
     * {@paypal.ltd}Standard customer authorization method) for B2C format accounts.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} ARC {@paypal.eltd}
     * {@paypal.ltd}Accounts Receivables check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} RCK {@paypal.eltd}
     * {@paypal.ltd}Re-presented check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} WEB {@paypal.eltd}
     * {@paypal.ltd}The customer authorized the payment over the Internet.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} TEL {@paypal.eltd}
     * {@paypal.ltd}Debit authorization obtained by telephone.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} POP {@paypal.eltd}
     * {@paypal.ltd}Point of Purchase check entry for a single entry debit.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @param authType String
     * @paypal.sample <p> Maps to Payflow Parameter: AUTHTYPE </p>
     */
    public void setAuthType(String authType) {
        this.authType = authType;
    }

    /**
     * Gets the PreNote.
     * <p/>
     * Prenote indicates a prenotification payment with no amount.
     * Used to verify bank account validity. Receiving banks are not required
     * to respond to prenotification payments.
     * Allowed prenote values are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth}PRENOTE {@paypal.elth}
     * {@paypal.lth}Description  {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} N {@paypal.eltd}
     * {@paypal.ltd}Default. AMT needs to be passed.{@paypal.eltd}
     * {@paypal.ltr}
     * {@paypal.ltd} Y {@paypal.eltd}
     * {@paypal.ltd}Default. AMT does not need to be passed.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @return preNote
     * @paypal.sample <p> Maps to Payflow Parameter: PRENOTE </p>
     */
    public String getPreNote() {
        return preNote;
    }

    /**
     * Sets the PreNote.
     * <p/>
     * Prenote indicates a prenotification payment with no amount.
     * Used to verify bank account validity. Receiving banks are not required
     * to respond to prenotification payments.
     * Allowed prenote values are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth}PRENOTE {@paypal.elth}
     * {@paypal.lth}Description  {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} N {@paypal.eltd}
     * {@paypal.ltd}Default. AMT needs to be passed.{@paypal.eltd}
     * {@paypal.ltr}
     * {@paypal.ltd} Y {@paypal.eltd}
     * {@paypal.ltd}Default. AMT does not need to be passed.{@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @param preNote String
     * @paypal.sample <p> Maps to Payflow Parameter: PRENOTE </p>
     */
    public void setPreNote(String preNote) {
        this.preNote = preNote;
    }

    /**
     * Gets the Term City.
     * <p/>
     * City where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @return termCity
     * @paypal.sample <p> Maps to Payflow Parameter: TERMCITY </p>
     */
    public String getTermCity() {
        return termCity;
    }

    /**
     * Gets the Term City.
     * <p/>
     * City where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @param termCity String
     * @paypal.sample <p> Maps to Payflow Parameter: TERMCITY </p>
     */
    public void setTermCity(String termCity) {
        this.termCity = termCity;
    }

    /**
     * Gets the TermState.
     * <p/>
     * State where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @return termState
     * @paypal.sample <p> Maps to Payflow Parameter: TERMSTATE </p>
     */
    public String getTermState() {
        return termState;
    }

    /**
     * Gets the TermState.
     * <p/>
     * State where the merchant's terminal is located.
     * Used only for POP.</p>
     *
     * @param termState String
     * @paypal.sample <p> Maps to Payflow Parameter: TERMSTATE </p>
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