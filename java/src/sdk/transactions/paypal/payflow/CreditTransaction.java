package paypal.payflow;

/**
 * This class is used to create and perform an
 * Credit Transaction.
 * <p>Reference credit transaction can be performed on successful
 * transactions in order to credit the amount. Therefore, a
 * reference credit transaction takes the PNRef of a previous transaction.
 * </p>
 *
 * @paypal.sample ...............<br>
 * // Populate data objects<br>
 * ...............<br>
 * <br>
 * // Create a new Credit Transaction.<br>
 * // Following is an example of a reference credit type of transaction.<br>
 * CreditTransaction Trans = new CreditTransaction("PNRef of a previous<br>
 * // transaction.",<br>
 * User, Connection, Inv, PayflowUtility.getRequestId());<br>
 * <br>
 * // Submit the transaction.<br>
 * Response resp = Trans.submitTransaction();<br>
 * <br>
 * if (resp != null)<br>
 * {<br>
 * // Get the Transaction Response parameters.<br>
 * TransactionResponse trxnResponse = resp.getTransactionResponse();<br>
 * if (trxnResponse != null)<br>
 * {<br>
 * System.out.println("RESULT = " + trxnResponse.getResult());<br>
 * System.out.println("PNREF = " + trxnResponse.getPnref());<br>
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
 * }<br>
 * }<br>
 * <br>
 * // Get the Context and check for any contained SDK specific errors.<br>
 * Context ctx = resp.getTransactionContext();<br>
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
 * {<br>
 * System.out.println("Errors = " + ctx.toString());<br>
 * }<br>
 * <br>
 */

public final class CreditTransaction extends BaseTransaction {

    /**
     * Original transaction id.
     */
    private String origId;

    private String origPPRef;

    /**
     * gets the OrigPPRef
     *
     * @return origPPRef
     * @paypal.sample <p> maps to PayflowParameter ORIGPPREF</p>
     */
    public String getOrigPPRef() {
        return origPPRef;
    }

    /**
     * sets the OrigPPRef
     *
     * @param origPPRef String
     * @paypal.sample <p> maps to PayflowParameter ORIGPPREF</p>
     */
    public void setOrigPPRef(String origPPRef) {
        this.origPPRef = origPPRef;
    }

    /**
     * Constructor.
     *
     * @param origId                Original Transaction Id.
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param invoice               Invoice object.
     * @param requestId             Request Id.
     *                              <p>Reference credit transaction can be performed on successful.
     *                              transactions in order to credit the amount. Therefore, a
     *                              reference credit transaction takes the PNRef of a previous
     *                              // transaction.</p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * // transaction.<br>
     * CreditTransaction trans = new CreditTransaction("PNRef of a<br>
     * // previous transaction.",<br>
     * User, Connection, Inv, PayflowUtility.getRequestId());<br>
     * <br>
     * // Submit the transaction.<br>
     * Response resp = trans.SubmitTransaction();<br>
     * <br>
     * if (resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse trxnResponse = resp.getTransactionResponse();<br>
     * if (trxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + TrxnResponse.Result);<br>
     * System.out.println("PNREF = " + TrxnResponse.Pnref);<br>
     * System.out.println("RESPMSG = " + TrxnResponse.RespMsg);<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context ctx = resp.getTransactionContext();<br>
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.ToString());<br>
     * }<br>
     */
    public CreditTransaction(String origId,
                             UserInfo userInfo,
                             PayflowConnectionData payflowConnectionData,
                             Invoice invoice,
                             String requestId) {
        super(PayflowConstants.TRXTYPE_CREDIT, userInfo, payflowConnectionData,
                invoice, requestId);
        this.origId = origId;
    }

    /**
     * Constructor.
     *
     * @param origId    Original Transaction Id.
     * @param userInfo  UserInfo object populated with user credentials.
     * @param invoice   Invoice object.
     * @param requestId Request Id.
     *                  <p>Reference credit transaction can be performed on successful
     *                  transactions in order to credit the amount. Therefore, a
     *                  reference credit transaction takes the PNRef of a previous transaction.
     *                  </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * // transaction.<br>
     * CreditTransaction trans = new CreditTransaction("PNRef of a<br>
     * // previous transaction.",<br>
     * User, Inv, PayflowUtility.getRequestId());<br>
     * <br>
     * // Submit the transaction.<br>
     * Response resp = Trans.submitTransaction();<br>
     * <br>
     * if (resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse trxnResponse = resp.getTransactionResponse();<br>
     * if (trxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + trxnResponse.getResult());<br>
     * System.out.println("PNREF = " + trxnResponse.getPnref());<br>
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context ctx = Resp.getTransactionContext();<br>
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.toString());<br>
     * }<br>
     * <br>
     */
    public CreditTransaction(String origId,
                             UserInfo userInfo,
                             Invoice invoice,
                             String requestId) {
        this(origId, userInfo, null, invoice, requestId);
    }

    /**
     * Constructor.
     *
     * @param origId                Original Transaction Id.
     * @param userInfo              UserInfo object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param invoice               Invoice object.
     * @param tender                tender object.
     * @param requestId             Request Id.
     *                              <p>Reference credit transaction can be performed on successful
     *                              transactions in order to credit the amount. Therefore, a
     *                              reference credit transaction takes the PNRef of a previous transaction.
     *                              </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * transaction.<br>
     * CreditTransaction trans = new CreditTransaction("PNRef of a<br>
     * previous transaction.",<br>
     * User, Connection, Inv, tender, PayflowUtility.getRequestId());<br>
     * <br>
     * // Submit the transaction.<br>
     * Response resp = trans.submitTransaction();<br>
     * <br>
     * if (resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse trxnResponse = resp.getTransactionResponse();<br>
     * if (trxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + trxnResponse.getResult());<br>
     * System.out.println("PNREF = " + trxnResponse.getPnref());<br>
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context ctx = resp.getTransactionContext();<br>
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.toString());<br>
     * }<br>
     * <br>
     */
    public CreditTransaction(String origId,
                             UserInfo userInfo,
                             PayflowConnectionData payflowConnectionData,
                             Invoice invoice,
                             BaseTender tender,
                             String requestId) {
        super(PayflowConstants.TRXTYPE_CREDIT, userInfo, payflowConnectionData,
                invoice, tender, requestId);
        this.origId = origId;
    }

    /**
     * Constructor.
     *
     * @param origId    Original Transaction Id
     * @param userInfo  UserInfo object populated with user credentials.
     * @param invoice   Invoice object.
     * @param tender    tender object.
     * @param requestId Request Id.
     *                  <p>Reference credit transaction can be performed on successful
     *                  transactions in order to credit the amount. Therefore, a
     *                  reference credit transaction takes the PNRef of a previous transaction.
     *                  </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * // transaction.<br>
     * CreditTransaction trans = new CreditTransaction("PNRef of a<br>
     * // previous transaction.",<br>
     * User, Inv, tender, PayflowUtility.getRequestId());<br>
     * <br>
     * // Submit the transaction.<br>
     * Response Resp = trans.submitTransaction();<br>
     * <br>
     * if (Resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse trxnResponse = resp.getTransactionResponse();<br>
     * if (TrxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + trxnResponse.getResult());<br>
     * System.out.println("PNREF = " + trxnResponse.getPnref());<br>
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context ctx = Resp.TransactionContext;<br>
     * if (ctx != null &amp;&amp;ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.ToString());<br>
     * }<br>
     * <br>
     * <br>
     */
    public CreditTransaction(String origId,
                             UserInfo userInfo,
                             Invoice invoice,
                             BaseTender tender,
                             String requestId) {
        this(origId, userInfo, null, invoice, tender, requestId);
    }

    /**
     * Constructor.
     *
     * @param origId                Original Transaction Id
     * @param userInfo              User Info object populated with user credentials.
     * @param PayflowConnectionData Connection credentials object.
     * @param requestId             Request Id.
     *                              <p>Reference credit transaction can be performed on
     *                              // successful
     *                              transactions in order to credit the amount. Therefore, a
     *                              reference credit transaction takes the PNRef of a previous
     *                              // transaction.
     *                              </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * // transaction.<br>
     * CreditTransaction Trans = new CreditTransaction("PNRef of a<br>
     * // previous transaction.",<br>
     * User, Connection, PayflowUtility.getRequestId());<br>
     * <br>
     * // Submit the transaction.<br>
     * Response resp = Trans.submitTransaction();<br>
     * <br>
     * if (resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse trxnResponse = Resp.getTransactionResponse();<br>
     * if (trxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + trxnResponse.getResult());<br>
     * System.out.println("PNREF = " + trxnResponse.getPnref());<br>
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context ctx = resp.getTransactionContext();<br>
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.ToString());<br>
     * }<br>
     * <br>
     */
    public CreditTransaction(String origId,
                             UserInfo userInfo,
                             PayflowConnectionData PayflowConnectionData,
                             String requestId) {
        super(PayflowConstants.TRXTYPE_CREDIT, userInfo, PayflowConnectionData,
                null, requestId);
        this.origId = origId;
    }

    /**
     * Constructor.
     * </summary>
     *
     * @param origId    Original Transaction Id
     * @param userInfo  User Info object populated with user credentials.
     * @param requestId Request Id
     *                  <p>Reference credit transaction can be performed on successful
     *                  transactions in order to credit the amount. Therefore, a
     *                  reference credit transaction takes the PNRef of a previous transaction.
     *                  </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a reference credit type of<br>
     * // transaction.<br>
     * CreditTransaction Trans = new CreditTransaction("PNRef of a<br>
     * // previous transaction.", PayflowUtility.requestId);<br>
     * <br>
     * // Submit the transaction.<br>
     * Response Resp = Trans.SubmitTransaction();<br>
     * <br>
     * if (Resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse TrxnResponse = Resp.TransactionResponse;<br>
     * if (TrxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + TrxnResponse.Result);<br>
     * System.out.println("PNREF = " + TrxnResponse.Pnref);<br>
     * System.out.println("RESPMSG = " + TrxnResponse.RespMsg);<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context Ctx = Resp.TransactionContext;<br>
     * if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)<br>
     * {<br>
     * System.out.println("Errors = " + ctx.ToString());<br>
     * }<br>
     * <br>
     */
    public CreditTransaction(String origId, UserInfo userInfo, String requestId) {
        super(PayflowConstants.TRXTYPE_CREDIT, userInfo, requestId);
        this.origId = origId;
    }

    /**
     * Constructor.
     *
     * @param userInfo              User Info object populated with user credentials.
     * @param PayflowConnectionData Connection credentials object.
     * @param invoice               Invoice object.
     * @param tender                tender object such as Card tender.
     * @param requestId             Request Id.
     *                              <p>This class is used for a stand alone credit transaction.
     *                              </p>
     * @paypal.sample ...............<br>
     * // Populate data objects<br>
     * ...............<br>
     * <br>
     * // Create a new Credit Transaction.<br>
     * // Following is an example of a stand alone credit type of<br>
     * // transaction.<br>
     * CreditTransaction Trans = new CreditTransaction(User, Inv,<br>
     * // Connection,<br>
     * tender, PayflowUtility.requestId);<br>
     * <br>
     * // Submit the transaction.<br>
     * Response Resp = Trans.SubmitTransaction();<br>
     * <br>
     * if (Resp != null)<br>
     * {<br>
     * // Get the Transaction Response parameters.<br>
     * TransactionResponse TrxnResponse = Resp.TransactionResponse;<br>
     * if (TrxnResponse != null)<br>
     * {<br>
     * System.out.println("RESULT = " + TrxnResponse.Result);<br>
     * System.out.println("PNREF = " + TrxnResponse.Pnref);<br>
     * System.out.println("RESPMSG = " + TrxnResponse.RespMsg);<br>
     * }<br>
     * }<br>
     * <br>
     * // Get the Context and check for any contained SDK specific errors.<br>
     * Context Ctx = Resp.TransactionContext;<br>
     * if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)<br>
     * {<br>
     * Console.WriteLine(Environment.NewLine + "Errors = " +<br>
     * // Ctx.ToString());<br>
     * }<br>
     * <br>
     */
    public CreditTransaction(UserInfo userInfo,
                             PayflowConnectionData PayflowConnectionData,
                             Invoice invoice,
                             BaseTender tender,
                             String requestId) {
        super(PayflowConstants.TRXTYPE_CREDIT, userInfo, PayflowConnectionData,
                invoice, tender, requestId);
    }

    /**
     * Constructor.
     * </summary>
     *
     * @param userInfo  User Info object populated with user credentials.
     * @param invoice   Invoice object.
     * @param tender    tender object such as Card tender.
     * @param requestId Request Id.
     *                  <p>This class is used for a stand alone credit transaction.
     *                  </p>
     *                  ...............<br>
     *                  // Populate data objects<br>
     *                  ...............<br>
     *                  <br>
     *                  // Create a new Credit Transaction.<br>
     *                  // Following is an example of a stand alone type of transaction.<br>
     *                  CreditTransaction trans = new CreditTransaction(User, Inv,<br>
     *                  tender, PayflowUtility.getRequestId());<br>
     *                  <br>
     *                  // Submit the transaction.<br>
     *                  Response resp = trans.submitTransaction();<br>
     *                  <br>
     *                  if (resp != null)<br>
     *                  {<br>
     *                  // Get the Transaction Response parameters.<br>
     *                  TransactionResponse trxnResponse = resp.TransactionResponse;<br>
     *                  if (trxnResponse != null)<br>
     *                  {<br>
     *                  System.out.println("RESULT = " + trxnResponse.getResult());<br>
     *                  System.out.println("PNREF = " + trxnResponse.getPnref());<br>
     *                  System.out.println("RESPMSG = " + trxnResponse.getRespMsg());<br>
     *                  }<br>
     *                  }<br>
     *                  <br>
     *                  // Get the Context and check for any contained SDK specific errors.<br>
     *                  Context ctx = resp.getTransactionContext();<br>
     *                  if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)<br>
     *                  {<br>
     *                  System.out.println("Errors = " + ctx.ToString());<br>
     *                  }<br>
     *                  <p/>
     *                  <br>
     */
    public CreditTransaction(UserInfo userInfo,
                             Invoice invoice,
                             BaseTender tender,
                             String requestId) {
        this(userInfo, null, invoice, tender, requestId);
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGID, origId));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGPPREF, origPPRef));
    }

}
