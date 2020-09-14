package paypal.payflow;


/**
 * <pre> {@code
 * Used for recurring transaction related information
 * <p>RecurringInfo contains the required and optional parameters
 * specific to all the recurring transactions.</p>
 *
 *  Following examples shows how to use the RecurringInfo.
 * ............................
 * //Populate other data objects.
 * ............................
 * RecurringInfo RecurInfo = new RecurringInfo();
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * RecurInfo.Start = "01012009";
 * RecurInfo.ProfileName = "PayPal";
 * // Specifies how often the payment occurs. All PAYPERIOD values must use
 * // capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
 * // QTER / SMYR / YEAR
 * RecurInfo.PayPeriod = "WEEK";
 *
 * // Create a new Recurring Add Transaction.
 * RecurringAddTransaction Trans = new RecurringAddTransaction(
 * User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId);
 *
 * // Submit the transaction.
 * Response Resp = Trans.SubmitTransaction();
 *
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse TrxnResponse =  Resp.TransactionResponse;
 * if (TrxnResponse != null)
 * {
 * Console.WriteLine("RESULT = " + TrxnResponse.Result);
 * Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
 * }
 *
 * // Get the Recurring Response parameters.
 * RecurringResponse RecurResponse = Resp.RecurringResponse;
 * if (RecurResponse != null)
 * {
 * Console.WriteLine("RPREF = " + RecurResponse.RPRef);
 * Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId);
 * }
 * }
 *
 * // Get the Context and check for any contained SDK specific errors.
 * Context Ctx = Resp.TransactionContext;
 * if (Ctx != null & Ctx.getErrorCount() > 0)
 * {
 * Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
 * }
 *
 * Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
 * Console.ReadLine();
 * }
 * }
 * </pre>
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
    private String frequency;

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PROFILENAME</p>
     */
    public String getProfileName() {
        return profileName;
    }

    /**
     * Sets the profileName parameter.
     *
     * @param profileName - String
     *  <p>Maps to Payflow Parameter: PROFILENAME</p>
     */
    public void setProfileName(String profileName) {
        this.profileName = profileName;
    }

    /**
     * Gets the start parameter.
     * <p>Beginning date for the recurring billing cycle.</p>
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: START</p>
     */
    public String getStart() {
        return start;
    }

    /**
     * Sets the start parameter.
     * <p>Beginning date for the recurring billing cycle.</p>
     *
     * @param start - String
     *  <p>Maps to Payflow Parameter: START</p>
     */
    public void setStart(String start) {
        this.start = start;
    }

    /**
     * Gets the term parameter.
     * <p>Number of payments to be made over the life of the agreement.</p>
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: TERM</p>
     */
    public long getTerm() {
        return term;
    }

    /**
     * Sets the term parameter.
     * <p>Number of payments to be made over the life of the agreement.</p>
     *
     * @param term - String
     *  <p>Maps to Payflow Parameter: TERM</p>
     */
    public void setTerm(long term) {
        this.term = term;
    }

    /**
     * Gets the payPeriod parameter.
     * <p>Specifies how often the payment occurs.</p>
     *
     * @return - String
     *
     * <pre>
     *  Value - Description
     *  WEEK  - Weekly - Every week on the same day of the week as the first payment.
     *  BIWK  - Every Two Weeks - Every other week on the same day of the week as the first payment.
     *  SMMO  - Twice Every Month - The 1st and 15th of the month.Results in 24 payments per year. SMMO can start on 1st to 15th of the month, second payment 15 days later or on the last day of the month.
     *  FRWK  - Every Four Weeks - Every 28 days from the previous payment date beginning with the first payment date. Results in 13 payments per year.
     *  MONT  - Monthly - Every month on the same date as the first payment. Results in 12 payments per year.
     *  QTER  - Quarterly - Every three months on the same date as the first payment.
     *  SMYR  - Twice Every Year - Every six months on the same date as the first payment.
     *  YEAR  - Yearly - Every twelve months on the same date as the first payment.
     *
     *  Maps to Payflow Parameter: PAYPERIOD
     *  </pre>
     */
    public String getPayPeriod() {
        return payPeriod;
    }

    /**
     * Sets the payPeriod parameter.
     * <p>Specifies how often the payment occurs.</p>
     *
     * @param payPeriod - String
     * <pre>
     *  Value - Description
     *  WEEK  - Weekly - Every week on the same day of the week as the first payment.
     *  BIWK  - Every Two Weeks - Every other week on the same day of the week as the first payment.
     *  SMMO  - Twice Every Month - The 1st and 15th of the month.Results in 24 payments per year. SMMO can start on 1st to 15th of the month, second payment 15 days later or on the last day of the month.
     *  FRWK  - Every Four Weeks - Every 28 days from the previous payment date beginning with the first payment date. Results in 13 payments per year.
     *  MONT  - Monthly - Every month on the same date as the first payment. Results in 12 payments per year.
     *  QTER  - Quarterly - Every three months on the same date as the first payment.
     *  SMYR  - Twice Every Year - Every six months on the same date as the first payment.
     *  YEAR  - Yearly - Every twelve months on the same date as the first payment.
     *
     *  Maps to Payflow Parameter: PAYPERIOD
     *  </pre>
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
     *  <p>Maps to Payflow Parameter: OPTIONALTRX</p>
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
     *  <p>Maps to Payflow Parameter: OPTIONALTRX</p>
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
     *  <p>Maps to Payflow Parameter: OPTIONALTRXAMT</p>
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
     *  <p>Maps to Payflow Parameter: OPTIONALTRXAMT</p>
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
     *  <p>Maps to Payflow Parameter: RETRYNUMDAYS</p>
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
     *  <p>Maps to Payflow Parameter: RETRYNUMDAYS</p>
     */
    public void setRetryNumDays(long retryNumDays) {
        this.retryNumDays = retryNumDays;
    }

    /**
     * Gets the maxFailPayments parameter.
     *  * <p>
     * * The number of payment periods (specified by
     * PAYPERIOD) for which the transaction is allowed to fail
     * before PayPal cancels a profile.</p>
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: MAXFAILPAYMENTS</p>
     */
    public long getMaxFailPayments() {
        return maxFailPayments;
    }

    /**
     * Sets the maxFailPayments parameter.
     *  * <p>
     * * The number of payment periods (specified by
     * PAYPERIOD) for which the transaction is allowed to fail
     * before PayPal cancels a profile.</p>
     *
     * @param maxFailPayments - String
     *  <p>Maps to Payflow Parameter: MAXFAILPAYMENTS</p>
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
     *  <p>Maps to Payflow Parameter: ORIGPROFILEID</p>
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
     *  <p>Maps to Payflow Parameter: ORIGPROFILEID</p>
     */
    public void setOrigProfileId(String origProfileId) {
        this.origProfileId = origProfileId;
    }

    /**
     * Gets the paymentHistory parameter.
     *
     * Used for recurring inquiry.Allowed values are:
     * Value Description
     *
     *   Y - To view the full set of payment information for a profile, include the name/value pair with the Inquiry action.
     *   N - To view the status of a customer's profile, submit an Inquiry action that does not include the PAYMENTHISTORY parameter (alternatively, submit PAYMENTHISTORY=N).
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAYMENTHISTORY</p>
     */
    public String getPaymentHistory() {
        return paymentHistory;
    }

    /**
     * Sets the paymentHistory parameter.
     *
     * Used for recurring inquiry.Allowed values are:
     * Value Description
     *
     *   Y - To view the full set of payment information for a profile, include the name/value pair with the Inquiry action.
     *   N - To view the status of a customer's profile, submit an Inquiry action that does not include the PAYMENTHISTORY parameter (alternatively, submit PAYMENTHISTORY=N).
     *
     * @param paymentHistory - String
     * <p>Maps to Payflow Parameter: PAYMENTHISTORY</p>
     */
    public void setPaymentHistory(String paymentHistory) {
        this.paymentHistory = paymentHistory;
    }

    /**
     * Gets the paymentNum parameter.
     * <p>Payment number identifying the failed payment to be retried.</p>
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAYMENTNUM</p>
     */
    public String getPaymentNum() {
        return paymentNum;
    }

    /**
     * Sets the paymentNum parameter.
     * <p>Payment number identifying the failed payment to be retried.</p>
     *
     * @param paymentNum - String
     *  <p>Maps to Payflow Parameter: PAYMENTNUM</p>
     */
    public void setPaymentNum(String paymentNum) {
        this.paymentNum = paymentNum;
    }

    /**
     * Gets the frequency parameter.
     * <p>Number of days (frequency) between payment. Returned if <code>PAYPERIOD=DAYS</code></p>
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: FREQUENCY</p>
     */
    public String getFrequency() {
        return frequency;
    }

    /**
     * Gets the frequency parameter.
     * <p>Number of days (frequency) between payment. Returned if <code>PAYPERIOD=DAYS</code></p>
     *
     * @param frequency - String
     *  <p>Maps to Payflow Parameter: FREQUENCY</p>
     */
    public void setFrequency(String frequency)  {
        this.frequency= frequency;
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
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_FREQUENCY, frequency));
        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }

        }
    }

}
