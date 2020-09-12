package paypal.payflow;

/**
 * This class is used to perform a voice authorization transaction.
 * <p/>
 * Some transactions cannot be authorized over the Internet (for example, high dollar
 * amounts)'processing networks generate Referral (Result Code 13) transactions.
 * In these situations, contact the customer service department of the
 * merchant bank and provide the payment information as requested.
 * If the transaction is approved, the bank provides a voice authorization
 * code (AUTHCODE) for the transaction. This must be included as AUTHCODE
 * as part of a Voice Authorization transaction.
 * </p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
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
 * <p/>
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.toString());
 * }
 */
public final class VoiceAuthTransaction extends BaseTransaction {

    private String mAuthCode;

    /**
     * Constructor
     *
     * @param AuthCode              - Required for Voice Authorization.
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param Invoice               - Invoice Object.
     * @param Tender                - Tender object such as  Card Tender.
     * @param RequestId             - Request Id
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
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
     * @param AuthCode  - mandatory for Voice auth transaction.
     * @param UserInfo  - User Info object populated with user credentials.
     * @param Invoice   - Invoice Object.
     * @param Tender    - Tender object such as  Card Tender.
     * @param RequestId - Request Id
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
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
    }

}

