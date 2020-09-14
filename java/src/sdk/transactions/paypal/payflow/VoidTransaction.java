package paypal.payflow;

/**
 * <pre>{@code
 * This class is used to perform a void transaction.
 *
 * The Void transaction prevents a transaction from being settled, but does
 * not release the authorization (hold on funds) on the cardholder's account.
 * Delayed Capture, Sale, Credit, Authorization, and Voice
 * Authorization transactions can be voided. A Void transaction cannot be voided.
 * The Void must occur prior to settlement.
 *
 *  ................
 * // Populate data objects
 * ...............
 *
 * // Create a new Void Transaction.
 * // The ORIGID is the PNREF no. for a previous transaction.
 * VoidTransaction trans = new VoidTransaction("V63A0A07BE5A",
 * user, connection, payflowUtility.getRequestId());
 * // Submit the transaction.
 * Response resp = Trans.submitTransaction();
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse = resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("PNREF = " + trxnResponse.getPnref());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * }
 * }
 *
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null & ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.toString());
 * }
 * }
 * </pre>
 */

public class VoidTransaction extends ReferenceTransaction {

    /**
     * Constructor
     *
     * @param OrigId                -  Original Transaction Id.
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param RequestId             - Request Id
     *                               * <p>
     *                              ...............
     *                              // Populate data objects
     *                              ...............
     *                               * <p>
     *                              // Create a new Void Transaction.
     *                              // The ORIGID is the PNREF no. for a previous transaction.
     *                              VoidTransaction trans = new VoidTransaction("V63A0A07BE5A",
     *                              user, connection, payflowUtility.getRequestId());
     */

    public VoidTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) {
        super(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, PayflowConnectionData, RequestId);
    }

    /**
     * Constructor
     *
     * @param OrigId    - Original Transaction Id.
     * @param UserInfo  - User Info object populated with user credentials.
     * @param RequestId - Request Id
     *                   * <p>
     *                  ...............
     *                  // Populate data objects
     *                  ...............
     *                   * <p>
     *                  // Create a new Void Transaction.
     *                  // The ORIGID is the PNREF no. for a previous transaction.
     *                  VoidTransaction trans = new VoidTransaction("V63A0A07BE5A",
     *                  user, payflowUtility.getRequestId());
     */
    public VoidTransaction(String OrigId, UserInfo UserInfo, String RequestId) {
        super(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, RequestId);
    }

    /**
     * Constructor
     *
     * @param OrigId                String         - OrigId Original Transaction Id.
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param Invoice               - Invoice object.
     * @param RequestId             - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Void Transaction.
     * // The ORIGID is the PNREF no. for a previous transaction.
     * VoidTransaction trans = new VoidTransaction("V63A0A07BE5A",
     * user, connection, inv ,payflowUtility.getRequestId());
     */
    public VoidTransaction(String OrigId, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, Invoice Invoice, String RequestId) {
        super(PayflowConstants.TRXTYPE_VOID, OrigId, UserInfo, PayflowConnectionData, Invoice, RequestId);
    }

    /**
     * Constructor
     *
     * @param origId    String    - OrigId Original Transaction Id.
     * @param userInfo  UserInfo        - User Info object populated with user credentials.
     * @param invoice   Invoice        - Invoice object.
     * @param requestId String     - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Void Transaction.
     * // The ORIGID is the PNREF no. for a previous transaction.
     * VoidTransaction trans = new VoidTransaction("V63A0A07BE5A",
     * user, inv, payflowUtility.getRequestId());
     */
    public VoidTransaction(String origId, UserInfo userInfo, Invoice invoice, String requestId) {
        this(origId, userInfo, null, invoice, requestId);
    }

}

