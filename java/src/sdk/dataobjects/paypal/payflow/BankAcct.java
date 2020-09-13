package paypal.payflow;

/**
 * Used for BankAcct information.
 * BankAcct is associated with ACHTender. {@link ACHTender}
 */
public final class BankAcct extends PaymentDevice {

    private String aba;
    private String acctType;

    /**
     * Constructor
     *
     * @param acct Bank Account number
     * @param aba  Aba number
     *             BankAcct should be used to perform the transactions
     *             in which the user provides his bank account details for
     *             the online payment processing.
     *             <p/>
     *  //Create the BankAcct object
     * BankAcct account = new BankAcct("XXXXXXXXXXX","XXXXXXXXXXX");
     * </p>
     */
    public BankAcct(String acct, String aba) {
        super(acct);
        this.aba = aba;
    }

    protected void generateRequest() {
        super.generateRequest();
        //Add ABA and ACCTTYPE to parameter list.
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ABA, aba));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ACCTTYPE, acctType));
    }

    /**
     * Gets the aba value.
     * Target Bank's transit ABA routing number.Appies only to ACH transactions.(8-digit number)
     *
     * @return String
     *         <p/>
     *  Maps to Payflow Parameters as follows: ABA
     * </p>
     */
    public String getAba() {
        return aba;
    }

    /**
     * Gets the Customer's bank account type.
     *
     * @return String
     *         <p/>
     *         Allowed AcctType values are:
     *         {@paypal.listtable}
     *         {@paypal.ltr}
     *         {@paypal.lth} ACCTTYPE {@paypal.elth}
     *         {@paypal.lth}Description{@paypal.elth}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} C {@paypal.eltd}
     *         {@paypal.ltd} Checking account {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} S {@paypal.eltd}
     *         {@paypal.ltd} Savings account {@paypal.ltd}
     *         {@paypal.eltr}
     *         {@paypal.endlisttable}
     *         </p>
     *         <p/>
     *  Maps to Payflow Parameters as follows: ACCTTYPE
     * </p>
     */
    public String getAcctType() {
        return acctType;
    }

    /**
     * Sets the Customer's bank account type.
     *
     * @param acctType <p/>
     *                 Allowed AcctType values are:
     *                 {@paypal.listtable}
     *                 {@paypal.ltr}
     *                 {@paypal.lth} ACCTTYPE {@paypal.elth}
     *                 {@paypal.lth}Description{@paypal.elth}
     *                 {@paypal.eltr}
     *                 {@paypal.ltr}
     *                 {@paypal.ltd} C {@paypal.eltd}
     *                 {@paypal.ltd} Checking account {@paypal.eltd}
     *                 {@paypal.eltr}
     *                 {@paypal.ltr}
     *                 {@paypal.ltd} S {@paypal.eltd}
     *                 {@paypal.ltd} Savings account {@paypal.ltd}
     *                 {@paypal.eltr}
     *                 {@paypal.endlisttable}
     *                 </p>
     *                 <p/>
     *  Maps to Payflow Parameters as follows: ACCTTYPE
     * </p>
     */
    public void setAcctType(String acctType) {
        this.acctType = acctType;
    }

}