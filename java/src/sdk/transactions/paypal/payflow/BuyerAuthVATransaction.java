package paypal.payflow;


/**
 * This class is used to create and perform
 * a Validate Authentication transaction.
 * Validate Authentication is the second step of Buyer authentication process.
 * <p/>
 * When the user authenticates on the secure authentication server, the server
 * returns back a Payer authentication Signature (PaRes). You must send this value of PaRes
 * to validate the authentication to the payment gateway during the Validate Authentication.
 * The gateway will then return the authentication status of the user in the response.
 * You should send this authntication information from the response into you main transaction.
 * For more information, please refer to the Payflow Developers' Guide.
 * </p>
 *
 * @paypal.sample This example shows how to create and perform a Verify Eknrollment transaction.
 * ..........
 * ..........
 * //Populate required data objects.
 * ..........
 * ..........
 * <p/>
 * //Create a new validate Auhtentication Transaction.
 * BuyerAuthVATransaction trans = new BuyerAuthVATransaction(
 * UserInfo,
 * PayflowConnectionData,
 * Pares,
 * RequestId);
 * //Submit the transaction.
 * trans.submitTransaction();
 * <p/>
 * // Get the Response.
 * Response resp = trans.getResponse();
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  Resp.getTransactionResponse();
 * if (TrxnResponse != null)
 * {
 * System.out.println("RESULT = " + TrxnResponse.Result);
 * System.out.println("RESPMSG = " + TrxnResponse.RespMsg);
 * }
 * <p/>
 * <p/>
 * // Get the Buyer auth Response parameters.
 * BuyerAuthResponse bAResponse = resp.BuyerAuthResponse;
 * if (BAResponse != null)
 * {
 * System.out.println("AUTHENTICATION_STATUS = " + bAResponse.Authentication_Status);
 * System.out.println("AUTHENTICATION_ID = " + bAResponse.Authentication_Id);
 * }
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.TransactionContext;
 * if (ctx != null ++ ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.ToString());
 * }
 */

public final class BuyerAuthVATransaction extends BuyerAuthTransaction {
    /**
     * Holds the PaRes value.
     */
    private String mPaRes;


    /**
     * constructor
     *
     * @param userInfo              UserInfo UserInfo object populated with user credentials
     * @param payflowConnectionData PayflowConnectionData
     * @param paRes                 String PaRes value
     * @param requestId             String
     */
    public BuyerAuthVATransaction(UserInfo userInfo,
                                  PayflowConnectionData payflowConnectionData,
                                  String paRes,
                                  String requestId) {
        super(PayflowConstants.TRXTYPE_BUYERAUTH_VA, userInfo,
                payflowConnectionData, requestId);
        mPaRes = paRes;
    }

    /**
     * Constructor.
     *
     * @param userInfo  UserInfo User Info object populated with user credentials.
     * @param paRes     String PaRes Value
     * @param requestId String
     */
    public BuyerAuthVATransaction(UserInfo userInfo,
                                  String paRes,
                                  String requestId) {
        this(userInfo, null, paRes, requestId);
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PARES, mPaRes));
    }
}
