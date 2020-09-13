package paypal.payflow;

/**
 * This class is used to perform a recurring transaction with
 * Payment action.
 * <p/>
 * RecurringPaymentTransaction action performs a real-time retry on
 * a transaction that is in the retry state. The response string is similar
 * to the string for Optional transactions, except that, upon approval,
 * the profile is updated to reflect the successful retry.
 * </p>
 *
 *  ...............
 * // Populate data objects
 * ...............
 * <p/>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * recurInfo.setOrigProfileId ("RT0000001350");
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * <p/>
 * RecurInfo.setPaymentNum ("01012009");
 * <p/>
 * <p/>
 * <p/>
 * // Create a new Invoice data object with the Amount, Billing Address etc. details.
 * Invoice inv = new Invoice();
 * <p/>
 * // Set Amount.
 * Currency amt = new Currency(new Double(25.12));
 * inv.setAmt (amt);
 * inv.setPoNum ("PO12345");
 * inv.setInvNum ("INV12345");
 * <p/>
 * // Set the Billing Address details.
 * BillTo bill = new BillTo();
 * bill.setBillToStreet ("123 Main St.");
 * bill.setBillToZip ("12345");
 * inv.setBillTo (bill);
 * <p/>
 * // Create a new RecurringPaymentTransaction.
 * RecurringPaymentTransaction trans = new RecurringPaymentTransaction(
 * user, connection, recurInfo, inv, PayflowUtility.getRequestId());
 * <p/>
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 * <p/>
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * }
 * <p/>
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * }
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println("/n" + "Errors = " + Ctx.ToString());
 * }
 */
public class RecurringPaymentTransaction extends RecurringTransaction {
    /**
     * Constructor
     *
     * @param userInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData - Connection credentials object.
     * @param recurringInfo         - Recurring Info object.
     * @param invoice               - Invoice object.
     * @param requestId             - Request Id
     *                              <p/>
     *                              RecurringPaymentTransaction action performs a real-time retry on
     *                              a transaction that is in the retry state. The response string is similar
     *                              to the string for Optional transactions, except that, upon approval,
     *                              the profile is updated to reflect the successful retry.
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringPaymentTransaction.
     * RecurringPaymentTransaction trans = new RecurringPaymentTransaction(user, connection, recurInfo, inv
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringPaymentTransaction(UserInfo userInfo,
                                       PayflowConnectionData payflowConnectionData,
                                       RecurringInfo recurringInfo,
                                       Invoice invoice, String requestId) {
        super(PayflowConstants.RECURRING_ACTION_PAYMENT,
                recurringInfo,
                userInfo, payflowConnectionData, invoice, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      - User Info object populated with user credentials.
     * @param recurringInfo - Recurring Info object.
     * @param invoice       - Invoice object.
     * @param requestId     - Request Id
     *                      <p/>
     *                      RecurringPaymentTransaction action performs a real-time retry on
     *                      a transaction that is in the retry state. The response string is similar
     *                      to the string for Optional transactions, except that, upon approval,
     *                      the profile is updated to reflect the successful retry.
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringPaymentTransaction.
     * RecurringPaymentTransaction trans = new RecurringPaymentTransaction(user, recurInfo, inv
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringPaymentTransaction(UserInfo userInfo,
                                       RecurringInfo recurringInfo,
                                       Invoice invoice, String requestId) {
        this(userInfo, null, recurringInfo, invoice, requestId);
    }
}
