package paypal.payflow;

/**
 * <pre>{@code
 * This class is used to perform a recurring transaction with
 * Inquiry action.
 *  * <p>
 * RecurringInquiryTransaction is used to request two different sets of information:
 * To view the full set of payment information for a profile, include the
 * PAYMENTHISTORY=Y name/value pair with the Inquiry action.
 * To view the status of a customer's profile, submit an Inquiry action that does
 * not include the PAYMENTHISTORY parameter (alternatively, submit
 * PAYMENTHISTORY=N).
 * </p>
 *
 *  ...............
 * // Populate data objects
 * ...............
 *  * <p>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * recurInfo.setOrigProfileId ("RT0000001350");
 *  * <p>
 * // Create a new Recurring Inquiry Transaction.
 * RecurringInquiryTransaction trans = new RecurringInquiryTransaction(
 * user, connection, recurInfo, PayflowUtility.getRequestId());
 *  * <p>
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 *  * <p>
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * }
 *  * <p>
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * System.out.println("STATUS = " + recurResponse.getStatus());
 * System.out.println("PROFILENAME = " + recurResponse.getProfileName());
 * System.out.println("START = " + recurResponse.getStart());
 * System.out.println("TERM = " + recurResponse.getTerm());
 * System.out.println("NEXTPAYMENT = " + recurResponse.getNextPayment());
 * System.out.println("PAYPERIOD = " + recurResponse.getPayPeriod());
 * System.out.println("NEXTPAYMENT = " + recurResponse.getNextPayment());
 * System.out.println("TENDER = " + recurResponse.getTender());
 * System.out.println("AMT = " + recurResponse.getAmt());
 * System.out.println("ACCT = " + recurResponse.getAcct());
 * System.out.println("EXPDATE = " + recurResponse.getExpDate());
 * System.out.println("AGGREGATEAMT = " + recurResponse.getAggregateAmt());
 * System.out.println("AGGREGATEOPTIONALAMT = " + recurResponse.getAggregateOptionalAmt());
 * System.out.println("MAXFAILPAYMENTS = " + recurResponse.getMaxFailPayments());
 * System.out.println("NUMFAILPAYMENTS = " + recurResponse.getNumFailPayments());
 * System.out.println("RETRYNUMDAYS = " + recurResponse.getRetryNumDays());
 * System.out.println("STREET = " + recurResponse.getStreet());
 * System.out.println("ZIP = " + recurResponse.getZip());
 * }
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null & ctx.getErrorCount() > 0)
 * {
 * System.out.println("/n" + "Errors = " + Ctx.ToString());
 * }
 * }
 * </pre>
 */

public class RecurringInquiryTransaction extends RecurringTransaction {

    /**
     * Constructor
     *
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param recurringInfo         RecurringInfo   - Recurring Info object.
     * @param requestId             String              - Request Id
     *                               * <p>
     *                              RecurringInquiryTransaction is used to request two different sets of information:
     *                              To view the full set of payment information for a profile, include the
     *                              PAYMENTHISTORY=Y name/value pair with the Inquiry action.
     *                              To view the status of a customer's profile, submit an Inquiry action that does
     *                              not include the PAYMENTHISTORY parameter (alternatively, submit
     *                              PAYMENTHISTORY=N).
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new RecurringInquiryTransaction.
     * RecurringInquiryTransaction trans = new RecurringInquiryTransaction(user, connection, recurInfo,
     * payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringInquiryTransaction(UserInfo userInfo,
                                       PayflowConnectionData payflowConnectionData,
                                       RecurringInfo recurringInfo, String requestId) {
        super(PayflowConstants.RECURRING_ACTION_INQUIRY,
                recurringInfo,
                userInfo, payflowConnectionData, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      UserInfo             - User Info object populated with user credentials.
     * @param recurringInfo RecurringInfo   - Recurring Info object.
     * @param requestId     String              - Request Id
     *                       * <p>
     *                      RecurringInquiryTransaction is used to request two different sets of information:
     *                      To view the full set of payment information for a profile, include the
     *                      PAYMENTHISTORY=Y name/value pair with the Inquiry action.
     *                      To view the status of a customer's profile, submit an Inquiry action that does
     *                      not include the PAYMENTHISTORY parameter (alternatively, submit
     *                      PAYMENTHISTORY=N).
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new RecurringInquiryTransaction.
     * RecurringInquiryTransaction trans = new RecurringInquiryTransaction(user, recurInfo,
     * payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */


    public RecurringInquiryTransaction(UserInfo userInfo,
                                       RecurringInfo recurringInfo, String requestId) {
        this(userInfo, null, recurringInfo, requestId);
    }
}
