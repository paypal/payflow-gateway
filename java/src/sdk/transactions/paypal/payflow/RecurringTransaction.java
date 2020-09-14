package paypal.payflow;

/**
 * <pre>{@code
 * This is the base class of all different recurring action transactions.
 *
 * Each derived class of RecurringTransaction specifies a unique action
 * transaction. This class can also be directly used to perform a recurring
 * transaction. Alternatively, a new class can be extended from this to
 * create a specific recurring action transaction.
 * </p>
 *
 *  ...............
 * // Populate data objects
 * ...............
 *
 * //Set the Recurring related information.
 * recurringInfo recurInfo = new recurringInfo();
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * recurInfo.setStart("01012009");
 * recurInfo.setProfileName ("PayPal");
 * // Specifies how often the payment occurs. All PAYPERIOD values must use
 * // capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
 * // QTER / SMYR / YEAR
 * recurInfo.setPayPeriod ("WEEK");
 * //////////////////////////////////////////////////
 *
 * // Create a new Recurring Transaction.
 * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
 * user, connection, inv, tender, payflowUtility.getRequestId());
 *
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 *
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * }
 *
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * }
 * }
 *
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null & ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.ToString());
 * }
 * }
 * </pre>
 */

public class RecurringTransaction extends BaseTransaction {

    private String action;

    private RecurringInfo recurringInfo;

    /**
     * Constructor
     *
     * @param action                String                - action, type of recurring transaction
     * @param recurringInfo         RecurringInfo         - Recurring Info object.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param requestId             String             - Request Id
     *                               * <p>
     *                              Each derived class of RecurringTransaction specifies a unique action
     *                              transaction. This class can also be directly used to perform a recurring
     *                              transaction. Alternatively, a new class can be extended from this to
     *                              create a specific recurring action transaction.
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user, connection, payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData, String requestId) {
        super(PayflowConstants.TRXTYPE_RECURRING,
                userInfo, payflowConnectionData, requestId);
        if (recurringInfo != null) {
            this.recurringInfo = recurringInfo;
            this.recurringInfo.setContext(super.getContext());
        }
        this.action = action;
    }

    /**
     * Constructor
     *
     * @param action        String        - action, type of recurring transaction
     * @param recurringInfo RecurringInfo - Recurring Info object.
     * @param userInfo      UserInfo      - User Info object populated with user credentials.
     * @param requestId     String     - Request Id
     *                       * <p>
     *                      Each derived class of RecurringTransaction specifies a unique action
     *                      transaction. This class can also be directly used to perform a recurring
     *                      transaction. Alternatively, a new class can be extended from this to
     *                      create a specific recurring action transaction.
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user,  payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */
    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                String requestId) {
        super(PayflowConstants.TRXTYPE_RECURRING,
                userInfo, requestId);
        if (recurringInfo != null) {
            this.recurringInfo = recurringInfo;
            this.recurringInfo.setContext(super.getContext());
        }
        this.action = action;
    }


    /**
     * Constructor
     *
     * @param action                String                - action, type of recurring transaction
     * @param recurringInfo         RecurringInfo         - Recurring Info object.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice              - Invoice Object.
     * @param requestId             String             - Request Id
     *                               * <p>
     *                              Each derived class of RecurringTransaction specifies a unique action
     *                              transaction. This class can also be directly used to perform a recurring
     *                              transaction. Alternatively, a new class can be extended from this to
     *                              create a specific recurring action transaction.
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user, connection, invoice, payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData,
                                Invoice invoice, String requestId) {
        super(PayflowConstants.TRXTYPE_RECURRING,
                userInfo, payflowConnectionData, invoice, requestId);
        if (recurringInfo != null) {
            this.recurringInfo = recurringInfo;
            this.recurringInfo.setContext(super.getContext());
        }
        this.action = action;
    }

    /**
     * Constructor
     *
     * @param action        String        - action, type of recurring transaction
     * @param recurringInfo RecurringInfo - Recurring Info object.
     * @param userInfo      UserInfo      - User Info object populated with user credentials.
     * @param invoice       Invoice       - Invoice Object.
     * @param requestId     String     - Request Id
     *                       * <p>
     *                      Each derived class of RecurringTransaction specifies a unique action
     *                      transaction. This class can also be directly used to perform a recurring
     *                      transaction. Alternatively, a new class can be extended from this to
     *                      create a specific recurring action transaction.
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user, invoice, payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                Invoice invoice, String requestId) {
        this(action, recurringInfo, userInfo, null, invoice, requestId);
    }

    /**
     * Constructor
     *
     * @param action                String                - action, type of recurring transaction
     * @param recurringInfo         RecurringInfo         - Recurring Info object.
     * @param userInfo              UserInfo            - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice               - Invoice object.
     * @param tender                Tender                - Tender
     * @param RequestId             - Request Id
     *                               * <p>
     *                              Each derived class of RecurringTransaction specifies a unique action
     *                              transaction. This class can also be directly used to perform a recurring
     *                              transaction. Alternatively, a new class can be extended from this to
     *                              create a specific recurring action transaction.
     *                              </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user, connection, invoice, tender, payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData,
                                Invoice invoice,
                                BaseTender tender, String RequestId) {
        super(PayflowConstants.TRXTYPE_RECURRING,
                userInfo, payflowConnectionData, invoice,
                tender, RequestId);
        if (recurringInfo != null) {
            this.recurringInfo = recurringInfo;
            this.recurringInfo.setContext(super.getContext());
        }
        this.action = action;
    }

    /**
     * Constructor
     *
     * @param action        String        - action, type of recurring transaction
     * @param recurringInfo RecurringInfo - Recurring Info object.
     * @param userInfo      UserInfo      - User Info object populated with user credentials.
     * @param invoice       Invoice       - Invoice object.
     * @param tender        Tender        - Tender
     * @param requestId     String     - Request Id
     *                       * <p>
     *                      Each derived class of RecurringTransaction specifies a unique action
     *                      transaction. This class can also be directly used to perform a recurring
     *                      transaction. Alternatively, a new class can be extended from this to
     *                      create a specific recurring action transaction.
     *                      </p>
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Recurring Transaction.
     * RecurringTransaction trans = new RecurringTransaction("A", recurInfo,
     * user, invoice, tender, payflowUtility.getRequestId ());
     *  * <p>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringTransaction(String action,
                                RecurringInfo recurringInfo,
                                UserInfo userInfo,
                                Invoice invoice,
                                BaseTender tender, String requestId) {
        this(action, recurringInfo,
                userInfo, null, invoice,
                tender, requestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ACTION, action));
        if (recurringInfo != null) {
            recurringInfo.setRequestBuffer(getRequestBuffer());
            recurringInfo.generateRequest();
        }
    }
}
