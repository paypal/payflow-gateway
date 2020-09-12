package paypal.payflow;

/**
 * This class is used to perform a recurring transaction with
 * reactivate action.
 * <p/>
 * RecurringReactivatetransaction reactivates a profile with inactive STATUS.
 * (Profiles can be deactivated for the following reasons: the term has completed,
 * the profile reached maximum allowable payment failures, or the profile is canceled.)
 * Reactivation gives the option to alter any profile parameter, including an
 * Optional Transaction and a new start date must be specified .
 * </p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * recurInfo.setOrigProfileId ("RT0000001350");
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * recurInfo.setStart ("01012009");
 * ////////////////////////////////////
 * <p/>
 * // Create a new Recurring ReActivate Transaction.
 * RecurringReActivateTransaction trans = new RecurringReActivateTransaction(
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

public class RecurringReActivateTransaction extends RecurringTransaction {

    /**
     * Constructor
     *
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData  - Connection credentials object.
     * @param recurringInfo         RecurringInfo        - Recurring Info object.
     * @param requestId             String            - Request Id
     *                              <p/>
     *                              Each derived class of RecurringTransaction specifies a unique action
     *                              transaction. This class can also be directly used to perform a recurring
     *                              transaction. Alternatively, a new class can be extended from this to
     *                              create a specific recurring action transaction.
     *                              </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringReActivateTransaction.
     * RecurringReActivateTransaction trans = new RecurringReActivateTransaction(user, connection, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringReActivateTransaction(UserInfo userInfo,
                                          PayflowConnectionData payflowConnectionData,
                                          RecurringInfo recurringInfo,
                                          String requestId) {
        super(PayflowConstants.RECURRING_ACTION_REACTIVATE, recurringInfo,
                userInfo, payflowConnectionData, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      UserInfo      - User Info object populated with user credentials.
     * @param recurringInfo RecurringInfo - Recurring Info object.
     * @param requestId     String     - Request Id
     *                      <p/>
     *                      Each derived class of RecurringTransaction specifies a unique action
     *                      transaction. This class can also be directly used to perform a recurring
     *                      transaction. Alternatively, a new class can be extended from this to
     *                      create a specific recurring action transaction.
     *                      </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringReActivateTransaction.
     * RecurringReActivateTransaction trans = new RecurringReActivateTransaction(user, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */


    public RecurringReActivateTransaction(UserInfo userInfo,
                                          RecurringInfo recurringInfo,
                                          String requestId) {
        this(userInfo, null, recurringInfo, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param recurringInfo         RecurringInfo         - Recurring Info object.
     * @param invoice               Invoice               - Invoice object.
     * @param tender                Tender                - Tender object such as  Card Tender.
     * @param requestId             String             - Request Id
     *                              <p/>
     *                              Each derived class of RecurringTransaction specifies a unique action
     *                              transaction. This class can also be directly used to perform a recurring
     *                              transaction. Alternatively, a new class can be extended from this to
     *                              create a specific recurring action transaction.
     *                              </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringReActivateTransaction.
     * RecurringReActivateTransaction trans = new RecurringReActivateTransaction(user, connection, recurInfo,
     * inv, tender, payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringReActivateTransaction(UserInfo userInfo,
                                          PayflowConnectionData payflowConnectionData,
                                          RecurringInfo recurringInfo,
                                          Invoice invoice,
                                          BaseTender tender,
                                          String requestId) {
        super(PayflowConstants.RECURRING_ACTION_REACTIVATE, recurringInfo,
                userInfo, payflowConnectionData, invoice, tender, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo      UserInfo      - User Info object populated with user credentials.
     * @param recurringInfo RecurringInfo - Recurring Info object.
     * @param invoice       Invoice       - Invoice object.
     * @param tender        Tender        - Tender object such as  Card Tender.
     * @param requestId     String     - Request Id
     *                      <p/>
     *                      Each derived class of RecurringTransaction specifies a unique action
     *                      transaction. This class can also be directly used to perform a recurring
     *                      transaction. Alternatively, a new class can be extended from this to
     *                      create a specific recurring action transaction.
     *                      </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringReActivateTransaction.
     * RecurringReActivateTransaction trans = new RecurringReActivateTransaction(user, recurInfo,
     * inv, tender, payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */


    public RecurringReActivateTransaction(UserInfo userInfo,
                                          RecurringInfo recurringInfo,
                                          Invoice invoice,
                                          BaseTender tender,
                                          String requestId) {
        this(userInfo, null, recurringInfo, invoice, tender, requestId);
    }

}
