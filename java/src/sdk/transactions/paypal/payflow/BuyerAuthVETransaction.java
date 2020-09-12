package paypal.payflow;


/**
 * This class is used to create and perform
 * a Verify Enrollment transaction.
 * Verify Enrollment is the first step of Buyer authentication process.
 * <p/>
 * After a successful Verify Enrollment Transaction,
 * you should redirect the user's browser to his/her banks
 * secure authentication server which will authenticate the user.
 * While redirecting to this secure authentication server,
 * you must pass the parameter PaReq obtained in the response of this transaction.
 * For more information, please refer to the Payflow Developers' Guide.
 * </p>
 *
 * @paypal.sample This example shows how to create and perform a Verify Enrollment transaction.
 * <p/>
 * ..........
 * ..........
 * //Populate required data objects.
 * <p/>
 * //Create the Card object.
 * CreditCard card = new CreditCard("XXXXXXXXXXXXXXXX","XXXX");
 * <p/>
 * //Create the currency object.
 * Currency amt = new Currency(new decimal(1.00),"US");
 * ..........
 * ..........
 * <p/>
 * //Create a new Verify Enrollment Transaction.
 * BuyerAuthVETransaction trans = new BuyerAuthVETransaction(
 * UserInfo,
 * PayflowConnectionData,
 * Card,
 * Amt,
 * RequestId);
 * //Submit the transaction.
 * trans.SubmitTransaction();
 * <p/>
 * // Get the Response.
 * Response resp = trans.getResponse();
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
 * <p/>
 * // Get the Buyer auth Response parameters.
 * BuyerAuthResponse bAResponse = resp.getBuyerAuthResponse();
 * if (bAResponse != null)
 * {
 * System.out.println("AUTHENTICATION_STATUS = " + bAResponse.getAuthenticationStatus());
 * System.out.println("AUTHENTICATION_ID = " + bAResponse.getAuthenticationId());
 * System.out.println("ACSURL = " + bAResponse.getAcsUrl());
 * System.out.println("PAREQ = " + bAResponse.getPaReq());
 * }
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null ++ ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + Ctx.ToString());
 * }
 */
public final class BuyerAuthVETransaction extends BuyerAuthTransaction {
    /**
     * Holds the currency value, mandatory for VE.
     */
    private Currency currency;

    /**
     * Holds the Purchase Description.
     */
    private String purDesc;

    private CreditCard creditcard;

    /**
     * Gets, Sets Purchase description.
     * <para>Maps to Payflow Parameter - <code>PUR_DESC</code></para>
     *
     * @return purDesc
     */
    public String getPurDesc() {
        return purDesc;
    }

    /**
     * @param purDesc String
     */
    public void setPurDesc(String purDesc) {
        this.purDesc = purDesc;
    }

    /**
     * Constructor.
     *
     * @param userInfo              - User Info object populated with user credentials.
     * @param creditCard            - Credit card information for the user.
     * @param payflowConnectionData - Connection credentials object.
     * @param currency              - Currency value
     * @param requestId             - String
     *                              <p>After a successful Verify Enrollment Transaction,
     *                              you should redirect the user's browser to his/her banks
     *                              secure authentication server which will authenticate the user.
     *                              While redirecting to this secure authentication server,
     *                              you must pass the parameter PaReq obtained in the response of this transaction.
     *                              </p>
     */
    public BuyerAuthVETransaction(UserInfo userInfo, CreditCard creditCard, PayflowConnectionData payflowConnectionData, Currency currency, String requestId) {
        super(PayflowConstants.TRXTYPE_BUYERAUTH_VE, userInfo, payflowConnectionData, requestId);
        this.currency = currency;
        purDesc = getPurDesc();
        creditcard = creditCard;

    }

    /**
     * Constructor.
     *
     * @param userInfo   UserInfo object populated with user credentials.
     * @param creditCard Credit card information for the user.
     * @param currency   Currency value
     * @param requestId  String
     *                   <p>After a successful Verify Enrollment Transaction,
     *                   you should redirect the user's browser to his/her browser to the
     *                   secure authentication server which will authenticate the user.
     *                   While redirecting to this secure authentication server,
     *                   you must pass the parameter PaReq obtained in the response of this transaction.
     *                   </p>
     */
    public BuyerAuthVETransaction(UserInfo userInfo, CreditCard creditCard, Currency currency, String requestId) {
        this(userInfo, creditCard, null, currency, requestId);
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {

        super.generateRequest();
        if (creditcard != null) {
            creditcard.setRequestBuffer(getRequestBuffer());
            creditcard.generateRequest();
        }

        if (currency != null) {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CURRENCY, currency.getCurrencyCode()));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AMT, currency));
        }
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PUR_DESC, purDesc));

    }

}

