package paypal.payflow;


/**
 * Used for recurring transaction related information
 * <p>RecurringInfo contains the required and optional parameters
 * specific to all the recurring transactions.</p>
 *
 * @paypal.sample Following examples shows how to use the RecurringInfo.
 * <code lang="C#" escaped="false">
 * ............................
 * //Populate other data objects.
 * ............................
 * <p/>
 * RecurringInfo RecurInfo = new RecurringInfo();
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * RecurInfo.Start = "01012009";
 * RecurInfo.ProfileName = "PayPal";
 * // Specifies how often the payment occurs. All PAYPERIOD values must use
 * // capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
 * // QTER / SMYR / YEAR
 * RecurInfo.PayPeriod = "WEEK";
 * <p/>
 * <p/>
 * // Create a new Recurring Add Transaction.
 * RecurringAddTransaction Trans = new RecurringAddTransaction(
 * User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId);
 * <p/>
 * // Submit the transaction.
 * Response Resp = Trans.SubmitTransaction();
 * <p/>
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse TrxnResponse =  Resp.TransactionResponse;
 * if (TrxnResponse != null)
 * {
 * Console.WriteLine("RESULT = " + TrxnResponse.Result);
 * Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
 * }
 * <p/>
 * // Get the Recurring Response parameters.
 * RecurringResponse RecurResponse = Resp.RecurringResponse;
 * if (RecurResponse != null)
 * {
 * Console.WriteLine("RPREF = " + RecurResponse.RPRef);
 * Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);
 * }
 * }
 * <p/>
 * // Get the Context and check for any contained SDK specific errors.
 * Context Ctx = Resp.TransactionContext;
 * if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
 * {
 * Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
 * }
 * <p/>
 * Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
 * Console.ReadLine();
 * }
 * </code>
 */
public final class RecurringInfo extends BaseRequestDataObject {
    private String profileName;
    private String start;
    private long term = PayflowConstants.INVALID_NUMBER;
    private String payPeriod;
    private String optionalTrx;
    private Currency optionalTrxAmt;
    private long retryNumDays;
    private long maxFailPayments = PayflowConstants.INVALID_NUMBER;
    private String origProfileId;
    private String paymentHistory;
    private String paymentNum;

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PROFILENAME
     */
    public String getProfileName() {
        return profileName;
    }

    /**
     * Sets the profileName parameter.
     *
     * @param profileName - String
     * @paypal.sample <p>Maps to Payflow Parameter: PROFILENAME
     */
    public void setProfileName(String profileName) {
        this.profileName = profileName;
    }

    /**
     * Gets the start parameter.
     * <p>Beginning date for the recurring billing cycle.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: START
     */
    public String getStart() {
        return start;
    }

    /**
     * Sets the start parameter.
     * <p>Beginning date for the recurring billing cycle.</p>
     *
     * @param start - String
     * @paypal.sample <p>Maps to Payflow Parameter: START
     */
    public void setStart(String start) {
        this.start = start;
    }

    /**
     * Gets the term parameter.
     * <p>Number of payments to be made over the life of the agreement.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: TERM
     */
    public long getTerm() {
        return term;
    }

    /**
     * Sets the term parameter.
     * <p>Number of payments to be made over the life of the agreement.</p>
     *
     * @param term - String
     * @paypal.sample <p>Maps to Payflow Parameter: TERM
     */
    public void setTerm(long term) {
        this.term = term;
    }

    /**
     * Gets the payPeriod parameter.
     * <p>Specifies how often the payment occurs.</p>
     *
     * @return - String
     *         <p/>
     *         {@paypal.listtable}
     *         {@paypal.ltr}
     *         {@paypal.lth} Value {@paypal.elth}
     *         {@paypal.lth} Description {@paypal.elth}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} WEEK {@paypal.eltd}
     *         {@paypal.ltd} Weekly - Every week on the same day of the week as the first payment. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} BIWK {@paypal.eltd}
     *         {@paypal.ltd} Every Two Weeks - Every other week on the same day of the week as the first payment. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} SMMO {@paypal.eltd}
     *         {@paypal.ltd} Twice Every Month - The 1st and 15th of the month.Results in 24 payments per year. SMMO can start on 1st to 15th of the month, second payment 15 days later or on the last day of the month. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} FRWK {@paypal.eltd}
     *         {@paypal.ltd} Every Four Weeks - Every 28 days from the previous payment date beginning with the first payment date. Results in 13 payments per year. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} MONT {@paypal.eltd}
     *         {@paypal.ltd} Monthly - Every month on the same date as the first payment. Results in 12 payments per year. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} QTER {@paypal.eltd}
     *         {@paypal.ltd} Quarterly - Every three months on the same date as the first payment. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} SMYR {@paypal.eltd}
     *         {@paypal.ltd} Twice Every Year - Every six months on the same date as the first payment. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} YEAR {@paypal.eltd}
     *         {@paypal.ltd} Yearly - Every twelve months on the same date as the first payment. {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.endlisttable}
     *         </p>
     * @paypal.sample <p>Maps to Payflow Parameter: PAYPERIOD
     */
    public String getPayPeriod() {
        return payPeriod;
    }

    /**
     * Sets the payPeriod parameter.
     * <p>Specifies how often the payment occurs.</p>
     *
     * @param payPeriod - String
     *                  <p/>
     *                  * {@paypal.listtable}
     *                  {@paypal.ltr}
     *                  {@paypal.lth} Value {@paypal.elth}
     *                  {@paypal.lth} Description {@paypal.elth}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} WEEK {@paypal.eltd}
     *                  {@paypal.ltd} Weekly - Every week on the same day of the week as the first payment. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} BIWK {@paypal.eltd}
     *                  {@paypal.ltd} Every Two Weeks - Every other week on the same day of the week as the first payment. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} SMMO {@paypal.eltd}
     *                  {@paypal.ltd} Twice Every Month - The 1st and 15th of the month.Results in 24 payments per year. SMMO can start on 1st to 15th of the month, second payment 15 days later or on the last day of the month. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} FRWK {@paypal.eltd}
     *                  {@paypal.ltd} Every Four Weeks - Every 28 days from the previous payment date beginning with the first payment date. Results in 13 payments per year. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} MONT {@paypal.eltd}
     *                  {@paypal.ltd} Monthly - Every month on the same date as the first payment. Results in 12 payments per year. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} QTER {@paypal.eltd}
     *                  {@paypal.ltd} Quarterly - Every three months on the same date as the first payment. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} SMYR {@paypal.eltd}
     *                  {@paypal.ltd} Twice Every Year - Every six months on the same date as the first payment. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.ltr}
     *                  {@paypal.ltd} YEAR {@paypal.eltd}
     *                  {@paypal.ltd} Yearly - Every twelve months on the same date as the first payment. {@paypal.eltd}
     *                  {@paypal.eltr}
     *                  {@paypal.endlisttable}
     *                  </p>
     * @paypal.sample <p>Maps to Payflow Parameter: PAYPERIOD
     */
    public void setPayPeriod(String payPeriod) {
        this.payPeriod = payPeriod;
    }

    /**
     * Gets the optionalTrx parameter.
     * <p>Defines an optional Authorization for validating the account
     * information or for charging an initial fee. If this transaction
     * fails, then the profile is not generated.
     * OPTIONALTRX=A only applies to credit card transactions.</p>
     * <p>S represents an initial fee.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: OPTIONALTRX
     */
    public String getOptionalTrx() {
        return optionalTrx;
    }

    /**
     * Sets the optionalTrx parameter.
     * <p>Defines an optional Authorization for validating the account
     * information or for charging an initial fee. If this transaction
     * fails, then the profile is not generated.
     * OPTIONALTRX=A only applies to credit card transactions.</p>
     * <p>S represents an initial fee.</p>
     *
     * @param optionalTrx - String
     * @paypal.sample <p>Maps to Payflow Parameter: OPTIONALTRX
     */
    public void setOptionalTrx(String optionalTrx) {
        this.optionalTrx = optionalTrx;
    }

    /**
     * Gets the optionalTrxAmt parameter.
     * <p>Amount of the Optional Transaction. Required only when OPTIONALTRX=S.
     * Optional when OPTIONALTRX=A ($1 Authorization by default)</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: OPTIONALTRXAMT
     */
    public Currency getOptionalTrxAmt() {
        return optionalTrxAmt;
    }

    /**
     * Sets the optionalTrxAmt parameter.
     * <p>Amount of the Optional Transaction. Required only when OPTIONALTRX=S.
     * Optional when OPTIONALTRX=A ($1 Authorization by default)</p>
     *
     * @param optionalTrxAmt - String
     * @paypal.sample <p>Maps to Payflow Parameter: OPTIONALTRXAMT
     */
    public void setOptionalTrxAmt(Currency optionalTrxAmt) {
        this.optionalTrxAmt = optionalTrxAmt;
    }

    /**
     * Gets the retryNumDays parameter.
     * <p>The number of consecutive days that Gateway should
     * attempt to process a failed transaction until Approved
     * status is received.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: RETRYNUMDAYS
     */
    public long getRetryNumDays() {
        return retryNumDays;
    }

    /**
     * Sets the retryNumDays parameter.
     * <p>The number of consecutive days that Gateway should
     * attempt to process a failed transaction until Approved
     * status is received.</p>
     *
     * @param retryNumDays - String
     * @paypal.sample <p>Maps to Payflow Parameter: RETRYNUMDAYS
     */
    public void setRetryNumDays(long retryNumDays) {
        this.retryNumDays = retryNumDays;
    }

    /**
     * Gets the maxFailPayments parameter.
     * <p/>
     * * The number of payment periods (specified by
     * PAYPERIOD) for which the transaction is allowed to fail
     * before PayPal cancels a profile.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: MAXFAILPAYMENTS
     */
    public long getMaxFailPayments() {
        return maxFailPayments;
    }

    /**
     * Sets the maxFailPayments parameter.
     * <p/>
     * * The number of payment periods (specified by
     * PAYPERIOD) for which the transaction is allowed to fail
     * before PayPal cancels a profile.</p>
     *
     * @param maxFailPayments - String
     * @paypal.sample <p>Maps to Payflow Parameter: MAXFAILPAYMENTS
     */
    public void setMaxFailPayments(long maxFailPayments) {
        this.maxFailPayments = maxFailPayments;
    }

    /**
     * Gets the origProfileId parameter.
     * <p>Required for Modify/Cancel/Inquiry/Retry action.
     * Profile IDs for test profiles start with RT.
     * Profile IDs for live profiles start with RP.
     * </p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: ORIGPROFILEID
     */
    public String getOrigProfileId() {
        return origProfileId;
    }

    /**
     * Sets the origProfileId parameter.
     * <p>Required for Modify/Cancel/Inquiry/Retry action.
     * Profile IDs for test profiles start with RT.
     * Profile IDs for live profiles start with RP.
     * </p>
     *
     * @param origProfileId - String
     * @paypal.sample <p>Maps to Payflow Parameter: ORIGPROFILEID
     */
    public void setOrigProfileId(String origProfileId) {
        this.origProfileId = origProfileId;
    }

    /**
     * Gets the paymentHistory parameter.
     * <p/>
     * Used for recurring inquiry.Allowed values are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth} Value {@paypal.elth}
     * {@paypal.lth} Description {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} Y {@paypal.eltd}
     * {@paypal.ltd} To view the full set of payment information for a profile, include the name/value pair with the Inquiry action. {@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} N {@paypal.eltd}
     * {@paypal.ltd} To view the status of a customer's profile, submit an Inquiry action that does not include the PAYMENTHISTORY parameter (alternatively, submit PAYMENTHISTORY=N). {@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTHISTORY
     */
    public String getPaymentHistory() {
        return paymentHistory;
    }

    /**
     * Sets the paymentHistory parameter.
     * <p/>
     * Used for recurring inquiry.Allowed values are:
     * {@paypal.listtable}
     * {@paypal.ltr}
     * {@paypal.lth} Value {@paypal.elth}
     * {@paypal.lth} Description {@paypal.elth}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} Y {@paypal.eltd}
     * {@paypal.ltd} To view the full set of payment information for a profile, include the name/value pair with the Inquiry action. {@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.ltr}
     * {@paypal.ltd} N {@paypal.eltd}
     * {@paypal.ltd} To view the status of a customer's profile, submit an Inquiry action that does not include the PAYMENTHISTORY parameter (alternatively, submit PAYMENTHISTORY=N). {@paypal.eltd}
     * {@paypal.eltr}
     * {@paypal.endlisttable}
     * </p>
     *
     * @param paymentHistory - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTHISTORY
     */
    public void setPaymentHistory(String paymentHistory) {
        this.paymentHistory = paymentHistory;
    }

    /**
     * Gets the paymentNum parameter.
     * <p>Payment number identifying the failed payment to be retried.</p>
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTNUM
     */
    public String getPaymentNum() {
        return paymentNum;
    }

    /**
     * Sets the paymentNum parameter.
     * <p>Payment number identifying the failed payment to be retried.</p>
     *
     * @param paymentNum - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTNUM
     */
    public void setPaymentNum(String paymentNum) {
        this.paymentNum = paymentNum;
    }

    /**
     * constructor
     */
    public RecurringInfo() {
    }


    protected void generateRequest() {
        try {
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PROFILENAME, profileName));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_START, start));

            if (term != PayflowConstants.INVALID_NUMBER) {
                super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TERM, String.valueOf(term)));
            }

            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYPERIOD, payPeriod));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_OPTIONALTRX, optionalTrx));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_OPTIONALTRXAMT, optionalTrxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_RETRYNUMDAYS, String.valueOf(retryNumDays)));
            if (maxFailPayments != PayflowConstants.INVALID_NUMBER) {
                super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MAXFAILPAYMENTS, String.valueOf(maxFailPayments)));
            }
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGPROFILEID, origProfileId));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYMENTHISTORY, paymentHistory));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYMENTNUM, paymentNum));
        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }

        }
    }

}
