package paypal.payflow;

/**
 * This class is used to perform a recurring transaction with
 * modify action.
 * <p/>
 * RecurringModifyTransaction is used to modify any profile value by
 * sending any subset of the profile parameters, including an Optional Transaction.
 * The Modify action is useful, for example, when an inactive customer wishes to
 * restart payments using a new valid credit card. The Modify action changes a
 * profiles STATUS to active but does not change the START date.
 * </p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * recurInfo.setOrigProfileId ("RT0000001350");
 * recurInfo.setProfileName ("PayPal Inc.");
 * ////////////////////////////////////
 * <p/>
 * // Create a new Recurring modify Transaction.
 * RecurringModifyTransaction trans = new RecurringModifyTransaction(
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


public class RecurringModifyTransaction extends RecurringTransaction {

    /**
     * Constructor
     *
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param recurringInfo         RecurringInfo   - Recurring Info object.
     * @param requestId             String              - Request Id
     *                              <p/>
     *                              RecurringModifyTransaction is used to modify any profile value by
     *                              sending any subset of the profile parameters, including an Optional Transaction.
     *                              The Modify action is useful, for example, when an inactive customer wishes to
     *                              restart payments using a new valid credit card. The Modify action changes a
     *                              profile's STATUS to active but does not change the START date.
     *                              </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringModifyTransaction.
     * RecurringModifyTransaction trans = new RecurringModifyTransaction(user, connection, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */


    public RecurringModifyTransaction(UserInfo userInfo,
                                      PayflowConnectionData payflowConnectionData,
                                      RecurringInfo recurringInfo, String requestId) {
        super(PayflowConstants.RECURRING_ACTION_MODIFY,
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
     *                      RecurringModifyTransaction is used to modify any profile value by
     *                      sending any subset of the profile parameters, including an Optional Transaction.
     *                      The Modify action is useful, for example, when an inactive customer wishes to
     *                      restart payments using a new valid credit card. The Modify action changes a
     *                      profile's STATUS to active but does not change the START date.
     *                      </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringModifyTransaction.
     * RecurringModifyTransaction trans = new RecurringModifyTransaction(user,  recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */


    public RecurringModifyTransaction(UserInfo userInfo,
                                      RecurringInfo recurringInfo, String requestId) {
        this(userInfo, null, recurringInfo, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param recurringInfo         RecurringInfo   - Recurring Info object.
     * @param invoice               Invoice               - Invoice object.
     * @param tender                Tender                 - Tender object such as  Card Tender.
     * @param requestId             String              - Request Id
     *                              <p/>
     *                              RecurringModifyTransaction is used to modify any profile value by
     *                              sending any subset of the profile parameters, including an Optional Transaction.
     *                              The Modify action is useful, for example, when an inactive customer wishes to
     *                              restart payments using a new valid credit card. The Modify action changes a
     *                              profile's STATUS to active but does not change the START date.
     *                              </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringModifyTransaction.
     * RecurringModifyTransaction trans = new RecurringModifyTransaction(user, connection, recurInfo, inv, tender
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringModifyTransaction(UserInfo userInfo,
                                      PayflowConnectionData payflowConnectionData,
                                      RecurringInfo recurringInfo,
                                      Invoice invoice,
                                      BaseTender tender, String requestId) {
        super(PayflowConstants.RECURRING_ACTION_MODIFY,
                recurringInfo,
                userInfo, payflowConnectionData,
                invoice,
                tender, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      UserInfo             - User Info object populated with user credentials.
     * @param recurringInfo RecurringInfo   - Recurring Info object.
     * @param invoice       Invoice               - Invoice object.
     * @param tender        Tender                 - Tender object such as  Card Tender.
     * @param requestId     String              - Request Id
     *                      <p/>
     *                      <p/>
     *                      RecurringModifyTransaction is used to modify any profile value by
     *                      sending any subset of the profile parameters, including an Optional Transaction.
     *                      The Modify action is useful, for example, when an inactive customer wishes to
     *                      restart payments using a new valid credit card. The Modify action changes a
     *                      profile's STATUS to active but does not change the START date.
     *                      </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringModifyTransaction.
     * RecurringModifyTransaction trans = new RecurringModifyTransaction(user, recurInfo, inv, tender
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringModifyTransaction(UserInfo userInfo,
                                      RecurringInfo recurringInfo,
                                      Invoice invoice,
                                      BaseTender tender, String requestId) {
        this(userInfo, null, recurringInfo,
                invoice,
                tender, requestId);
    }

}
