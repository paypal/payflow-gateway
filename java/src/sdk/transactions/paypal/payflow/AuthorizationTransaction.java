package paypal.payflow;

/**
 * This class is used to create and perform an
 * Authorization Transaction.
 * <p/>
 * A successful authorization needs to be captured using a capture transaction.
 * </p>
 *
 * @paypal.sample This example shows how to create and perform an authorization transaction.
 * <p/>
 * ..........
 * ..........
 * //Populate required data objects.
 * ..........
 * ..........
 * <p/>
 * //Create a new Authorization Transaction.
 * AuthorizationTransaction trans = new AuthorizationTransaction(
 * userInfo,
 * PayflowConnectionData,
 * invoice,
 * Tender,
 * RequestId);
 * //Submit the transaction.
 * trans.submitTransaction();
 * <p/>
 * // Get the Response.
 * Response resp = trans.getResponse();
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  Resp.getTransactionResponse();
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
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null ++ ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.toString());
 * }
 */
public class AuthorizationTransaction extends BaseTransaction {

    /**
     * Original transaction id.
     * The ORIGID is the PNREF no. for a previous transaction.
     * OrigId is used in case Authorization transaction is a Follow-On transaction.
     */
    private String origId;

    public String getOrigId() {
        return origId;
    }

    /**
     * the origId to set.
     *
     * @param origId String
     */
    public void setOrigId(String origId) {
        this.origId = origId;
    }

    /**
     * Gets, Sets OrigId. This property is used to perform a
     * reference Authorization Transaction.
     * <p/>
     * A reference Authorization transaction is an authorization transaction which copies the transaction data,
     * except the Account Number, Expiration Date and Swipe data from a previous trasnaction.
     * PNRef of this previous trasnaction needs to be set in this OrigId property.
     * <p/>
     * A successful authorization needs to be captured using a capture transaction.</p>
     *
     * @return origId String
     * @paypal.sample This example shows how to create and perform a reference authorization transaction.
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     * <p/>
     * //Create a new Authorization Transaction.
     * AuthorizationTransaction trans = new AuthorizationTransaction(
     * userInfo,
     * PayflowConnectionData,
     * invoice,
     * Tender,
     * RequestId);
     * // Set the OrigId to refer to a previous transaction.
     * trans.setOrigId("V64A0A07BD24);
     * // Flag the transactions to allow partial authorizations
     * // of pre-paid credit cards.
     * trans.setPartialAuth("Y");
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
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null ++ ctx.getErrorCount() > 0)
     * {
     * System.out.println(Environment.NewLine + "Errors = " + ctx.toString());
     * }
     */

    /**
     * Partial Authorization flag.
     * Used to notify banks that merchant supports partial authorizations on pre-paid
     * credit cards and to return the partially approved amount.
     */
    private String partialAuth;

    /**
     * Gets, Sets partialAuth. This property is used to notify banks that a partial authorization
     * can be performed for a pre-paid debit/gift card.
     * <p/>
     * Partial Approval is supported for Visa, MasterCard, American Express and Discover (JCB (US Domestic only),
     * and Diners) Prepaid card products such as gift, Flexible Spending Account (FSA) or Healthcare Reimbursement
     * Account (HRA) cards. In addition Discover (JCB (US Domestic only), and Diners) supports partial Approval
     * on their consumer credit card. It is often difficult for the consumer to spend the exact amount available
     * on the prepaid account, as the purchase can be for amounts greater than the value available. This can result
     * in unnecessary declines. Visa, MasterCard, American Express and Discover (JCB (US Domestic only), and Diners)
     * recognize that the prepaid products represent unique opportunities for both merchants and consumers. With
     * Partial Approval issuers may approve a portion of the amount requested. This will enable the residual
     * transaction amount to be paid by other means. The introduction of the partial approval capability will reduce
     * decline frequency and enhance the consumer and merchant experience at the point of sale. Merchants will now
     * have the ability to accept partial approval rather than having the sale declined.
     * <p/>
     *
     * @return partialAuth String
     * @paypal.sample This example shows how to set the flag to support partial authorizations.
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     * <p/>
     * //Create a new Authorization Transaction.
     * AuthorizationTransaction trans = new AuthorizationTransaction(userInfo, PayflowConnectionData,
     * invoice, Tender, RequestId);
     * // Flag the transactions to allow partial authorizations
     * // of pre-paid credit cards.
     * trans.setPartialAuth("Y");
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
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null ++ ctx.getErrorCount() > 0)
     * {
     * System.out.println(Environment.NewLine + "Errors = " + ctx.toString());
     * }
     */
    public String getPartialAuth() {
        return partialAuth;
    }

    /**
     * the partialAuth to set.
     *
     * @param partialAuth String
     */
    public void setPartialAuth(String partialAuth) {
        this.partialAuth = partialAuth;
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
     * @paypal.sample This example shows how to set the flag to create a secure token.
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
     * // Create a new Secure Token Authorization Transaction.  Even though this example is performing
     * // an authorization, you can create a secure token using SaleTransaction too.  Only Authorization and Sale
     * // type transactions are permitted.
     * AuthorizationTransaction Trans = new AuthorizationTransaction(User, Connection, Inv, PayflowUtility.RequestId);
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
     * Constructor.
     *
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param invoice               Invoice object.
     * @param tender                Tender object.
     * @param requestId             Request Id.
     * @paypal.sample This example shows how to create and perform a authorization transaction.
     * <p/>
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     * <p/>
     * //Create a new Authorization Transaction.
     * AuthorizationTransaction Trans = new AuthorizationTransaction(
     * userInfo,
     * PayflowConnectionData,
     * invoice,
     * Tender,
     * RequestId);
     * //Submit the transaction.
     * trans.submitTransaction();
     * <p/>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (Resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.transactionResponse();
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
     * if (FraudResp != null)
     * {
     * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
     * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
     * }
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public AuthorizationTransaction(UserInfo userInfo, PayflowConnectionData payflowConnectionData,
                                    Invoice invoice,
                                    BaseTender tender, String requestId) {
        super(PayflowConstants.TRXTYPE_AUTH, userInfo, payflowConnectionData, invoice, tender, requestId);
    }

    /**
     * Constructor.
     *
     * @param userInfo  User Info object populated with user credentials.</param>
     * @param invoice   Invoice object.
     * @param tender    Tender object
     * @param requestId String Request Id
     * @paypal.sample This example shows how to create and perform
     * a authorization transaction.
     * <p/>
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     * <p/>
     * // Create a new Authorization Transaction.
     * AuthorizationTransaction Trans = new AuthorizationTransaction(
     * userInfo,
     * PayflowConnectionData,
     * Invoice,
     * Tender,
     * RequestId);
     * //Submit the transaction.
     * trans.submitTransaction();
     * <p/>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (Resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.transactionResponse();
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
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */

    public AuthorizationTransaction(UserInfo userInfo, Invoice invoice,
                                    BaseTender tender, String requestId) {
        this(userInfo, null, invoice, tender, requestId);
    }

    /**
     * constructor to be used in case of basic and order auth
     *
     * @param trxType               String
     * @param userInfo              userInfo
     * @param payflowConnectionData PayflowConnectionData
     * @param invoice               String
     * @param tender                String
     * @param requestId             String
     */
    protected AuthorizationTransaction(String trxType, UserInfo userInfo, PayflowConnectionData payflowConnectionData,
                                       Invoice invoice,
                                       BaseTender tender, String requestId) {
        super(trxType, userInfo, payflowConnectionData,
                invoice,
                tender, requestId);
    }

    /**
     * @param trxType   String
     * @param userInfo  userInfo
     * @param invoice   Invoice
     * @param tender    BaseTender
     * @param requestId String
     */
    protected AuthorizationTransaction(String trxType, UserInfo userInfo, Invoice invoice,
                                       BaseTender tender, String requestId) {
        this(trxType, userInfo, null, invoice, tender, requestId);
    }


    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        try {
            super.generateRequest();
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGID, origId));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PARTIALAUTH, partialAuth));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CREATESECURETOKEN, createSecureToken));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SECURETOKENID, secureTokenId));
        } catch (Exception ex) {
            ErrorObject error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, ex, PayflowConstants.SEVERITY_FATAL, false, null);
            getContext().addError(error);
        }
    }


}

