package paypal.payflow;

/**
 * This class is used to perform a recurring transaction with
 * Cancel action.
 * <p/>
 * RecurringCancelTransaction is used to cancel  the recurring profile
 * to deactivate the profile from performing further transactions. The profile is
 * marked as cancelled and the customer is no longer billed. PayPal records the
 * cancellation date.
 * </p>
 *
 *  ...............
 * // Populate data objects
 * ...............
 * <p/>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * recurInfo.setOrigProfileId ("RT0000001350");
 * <p/>
 * // Create a new RecurringCancelTransaction
 * RecurringCancelTransaction trans = new RecurringCancelTransaction(
 * user, connection, recurInfo, PayflowUtility.getRequestId());
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


public class RecurringCancelTransaction extends RecurringTransaction {

    /**
     * Constructor
     *
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param recurringInfo         RecurringInfo   - Recurring Info object.
     * @param requestId             String              - Request Id
     *                              <p/>
     *                              <p/>
     *                              RecurringCancelTransaction is used to cancel  the recurring profile
     *                              to deactivate the profile from performing further transactions. The profile is
     *                              marked as cancelled and the customer is no longer billed. PayPal records the
     *                              cancellation date.
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringCancelTransaction.
     * RecurringCancelTransaction trans = new RecurringCancelTransaction(user, connection, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    //
    public RecurringCancelTransaction(UserInfo userInfo,
                                      PayflowConnectionData payflowConnectionData,
                                      RecurringInfo recurringInfo, String requestId) {
        super(PayflowConstants.RECURRING_ACTION_CANCEL,
                recurringInfo,
                userInfo, payflowConnectionData, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      UserInfo             - User Info object populated with user credentials.
     * @param recurringInfo RecurringInfo   - Recurring Info object.
     * @param requestId     String              - Request Id
     *                      <p/>
     *                      <p/>
     *                      RecurringCancelTransaction is used to cancel  the recurring profile
     *                      to deactivate the profile from performing further transactions. The profile is
     *                      marked as cancelled and the customer is no longer billed. PayPal records the
     *                      cancellation date.
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringCancelTransaction.
     * RecurringCancelTransaction trans = new RecurringCancelTransaction(user, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringCancelTransaction(UserInfo userInfo,
                                      RecurringInfo recurringInfo, String requestId) {
        this(userInfo, null, recurringInfo, requestId);
    }

}
