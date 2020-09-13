package paypal.payflow;

/**
 * This class is used to perform a voice authorization transaction.
 * <p/>
 * * This class is used to create and perform a
 * Sale Transaction.
 * </p>
 *
 *  ...............
 * // Populate data objects
 * ...............
 * <p/>
 * // Create a new SaleTransaction.
 * SaleTransaction trans = new SaleTransaction(user,
 * connection, inv, tender, PayflowUtility.RequestId);
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
 * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
 * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
 * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
 * System.out.println("IAVS = " + trxnResponse.getIAVS());
 * }
 * // Get the Fraud Response parameters.
 * FraudResponse fraudResp =  resp.getFraudResponse();
 * if (fraudResp != null)
 * {
 * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
 * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
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


public final class SaleTransaction extends BaseTransaction {

    private String origId;

    /**
     * Gets OrigId. This property is used to perform a
     * reference Sale Transaction.
     * <p>A reference Sale transaction is a sale transaction which copies the transaction data,
     * except the Account Number, Expiration Date and Swipe data from a previous transaction.
     * PNRef of this previous transaction needs to be set in this OrigId property.</p>
     * <p>A successful Sale needs to be captured using a capture transaction.</p>
     *
     * @return return
     */
    public String getOrigId() {
        return origId;
    }

    /**
     * Sets OrigId. This property is used to perform a
     * reference Sale Transaction.
     * <p>A reference Sale transaction is a sale transaction which copies the transaction data,
     * except the Account Number, Expiration Date and Swipe data from a previous transaction.
     * PNRef of this previous transaction needs to be set in this OrigId property.</p>
     * <p>A successful Sale needs to be captured using a capture transaction.</p>
     *
     * @param origId String
     */
    public void setOrigId(String origId) {
        this.origId = origId;
    }

    private String createSecureToken;
    private String secureTokenId;

    /**
     * Gets, Sets CreateSecureToken, SecureTokenId. This property is used to create a SecureToken and SecureTokenId.
     * <p/>
     * Use a secure token to send non-credit card transaction data to the Payflow server for storage in
     * a way that can't be intercepted and manipulated maliciously.The secure token must be used with the hosted
     * checkout pages. The token is good for a one-time transaction and is valid for 30 minutes.
     * <p/>
     * NOTE: Without using a secure token, Payflow Pro merchants can host their own payment page and Payflow Link merchants
     * can use a form post to send transaction data to the hosted checkout pages. However, by not using the secure token,
     * these Payflow gateway users are responsible for the secure handling of data.  To obtain a secure token, pass a unique,
     * 36-character token ID and set CREATESECURETOKEN=Y in a request to the Payflow server. The Payflow server associates your
     * ID with a secure token and returns the token as a string of up to 32 alphanumeric characters.  To pass the transaction
     * data to the hosted checkout page, you pass the secure token and token ID in an HTTP form post. The token and ID trigger
     * the Payflow server to retrieve your data and display it for buyer approval.
     * <p/>
     *
     * @return secureToken String
     *  This example shows how to set the flag to create a secure token.
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     * <p/>
     * // Since we are using the hosted payment pages, you will not be sending the credit card data with the
     * // Secure Token Request.  You just send all other 'sensitive' data within this request and when you
     * // call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
     * // and the SECURETOKENID that was created and used in the request.
     * <p/>
     * // Create a new Secure Token Sale Transaction.  Even though this example is performing
     * // an authorization, you can create a secure token using SaleTransaction too.  Only Authorization and Sale
     * // type transactions are permitted.
     * SaleTransaction Trans = new SaleTransaction(User, Connection, Inv, null, PayflowUtility.RequestId);
     * <p/>
     * // Set the flag to create a Secure Token.
     * Trans.CreateSecureToken = "Y";
     * // The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to
     * // generate a random id, but any means to create an id can be used.
     * Trans.SecureTokenId = PayflowUtility.RequestId;
     * <p/>
     * //Submit the transaction.
     * trans.submitTransaction();
     * <p/>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("SECURETOKEN = " + trxnResponse.getSecureToken());
     * System.out.println("SECURETOKENID = " + trxnResponse.getSecureTokenId());
     * }
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null ++ ctx.getErrorCount() > 0)
     * {
     * System.out.println(Environment.NewLine + "Errors = " + ctx.toString());
     * }
     */
    public String getCreateSecureToken() {
        return createSecureToken;
    }

    public String getSecureTokenId() {
        return secureTokenId;
    }

    /**
     * the createSecureToken is set.
     *
     * @param createSecureToken String
     */
    public void setCreateSecureToken(String createSecureToken) {
        this.createSecureToken = createSecureToken;
    }

    /**
     * the secureTokenId is set.
     *
     * @param secureTokenId String
     */
    public void setSecureTokenId(String secureTokenId) {
        this.secureTokenId = secureTokenId;
    }

    /**
     * Constructor
     *
     * @param userInfo              UserInfo     - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice               - Invoice Object.
     * @param tender                Tender                - Tender object such as  Card Tender.
     * @param requestId             Strung             - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new SaleTransaction.
     * SaleTransaction trans = new SaleTransaction(user,
     * connection, inv, tender, payflowUtility.getRequestId());
     */

    public SaleTransaction(UserInfo userInfo,
                           PayflowConnectionData payflowConnectionData, Invoice invoice,
                           BaseTender tender, String requestId) {
        super(PayflowConstants.TRXTYPE_SALE, userInfo,
                payflowConnectionData, invoice,
                tender, requestId);
    }

    /**
     * Constructor
     *
     * @param userInfo  UserInfo  - User Info object populated with user credentials.
     * @param invoice   Invoice   - Invoice Object.
     * @param tender    Tender    - Tender object such as  Card Tender.
     * @param requestId String  - Request Id
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new SaleTransaction.
     * SaleTransaction trans = new SaleTransaction(user,
     * connection, inv, tender, payflowUtility.getRequestId());
     */

    public SaleTransaction(UserInfo userInfo,
                           Invoice invoice,
                           BaseTender tender, String requestId) {
        this(userInfo,
                null, invoice,
                tender, requestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGID, origId));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CREATESECURETOKEN, createSecureToken));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SECURETOKENID, secureTokenId));
    }

}
