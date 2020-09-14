package paypal.payflow;

/**
 * <pre>{@code
 * This class is used to perform a voice authorization transaction.
 *
 * Some transactions cannot be authorized over the Internet (for example, high dollar
 * amounts)'processing networks generate Referral (Result Code 13) transactions.
 * In these situations, contact the customer service department of the
 * merchant bank and provide the payment information as requested.
 *
 * If the transaction is approved, the bank provides a voice authorization
 * code (AUTHCODE) for the transaction. This must be included as AUTHCODE
 * as part of a Voice Authorization transaction.
 *
 *  ...............
 * // Populate data objects
 * ...............
 *
 * // Create a new Voice Auth Transaction.
 * VoiceAuthTransaction trans = new VoiceAuthTransaction("123PNI",
 * user, connection, inv, card, PayflowUtility.RequestId);
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
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
public final class VoiceAuthTransaction extends BaseTransaction {

    private String mAuthCode;
    private String mAuthDate;

    /**
     * Constructor
     *
     * @param AuthCode              - Required for Voice Authorization.
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param Invoice               - Invoice Object.
     * @param Tender                - Tender object such as  Card Tender.
     * @param RequestId             - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     *  * <p>
     * // Create a new Void Transaction.
     * VoiceAuthTransaction trans = new VoidTransaction("123PNI",
     * user, connection, inv, tender, payflowUtility.getRequestId());
     */

    public VoiceAuthTransaction(String AuthCode, UserInfo UserInfo,
                                PayflowConnectionData PayflowConnectionData, Invoice Invoice,
                                BaseTender Tender, String RequestId) {
        super(PayflowConstants.TRXTYPE_VOICEAUTH, UserInfo,
                PayflowConnectionData, Invoice,
                Tender, RequestId);
        mAuthCode = AuthCode;
    }

    /**
     * Constructor
     *
     * @param AuthCode              - Authorization code obtain via another means; i.e. phone.
     * @param AuthDate              - Date the AuthCode was obtained.
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param Invoice               - Invoice Object.
     * @param Tender                - Tender object such as  Card Tender.
     * @param RequestId             - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     * // Create a new Void Transaction.
     * VoiceAuthTransaction trans = new VoidTransaction("123PNI", "082120", user,
     *  connection, inv, tender, payflowUtility.getRequestId());
     */

    public VoiceAuthTransaction(String AuthCode, String AuthDate, UserInfo UserInfo,
                                PayflowConnectionData PayflowConnectionData, Invoice Invoice,
                                BaseTender Tender, String RequestId) {
        super(PayflowConstants.TRXTYPE_VOICEAUTH, UserInfo,
                PayflowConnectionData, Invoice,
                Tender, RequestId);
        mAuthCode = AuthCode;
        mAuthDate = AuthDate;
    }


    /**
     * Constructor
     *
     * @param AuthCode  - mandatory for Voice auth transaction.
     * @param UserInfo  - User Info object populated with user credentials.
     * @param Invoice   - Invoice Object.
     * @param Tender    - Tender object such as  Card Tender.
     * @param RequestId - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     * // Create a new Void Transaction.
     * VoiceAuthTransaction trans = new VoidTransaction("123PNI",
     * user, inv, tender, payflowUtility.getRequestId());
     */


    public VoiceAuthTransaction(String AuthCode, UserInfo UserInfo,
                                Invoice Invoice,
                                BaseTender Tender, String RequestId) {
        this(AuthCode, UserInfo,
                null, Invoice,
                Tender, RequestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHCODE, mAuthCode));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHDATE, mAuthDate));
    }

}

