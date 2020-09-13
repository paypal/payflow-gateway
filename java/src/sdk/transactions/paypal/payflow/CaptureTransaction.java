package paypal.payflow;

/**
 * This class is used to perform a capture transaction.
 *
 *  <p>
 * Capture transaction needs to be performed on a successful
 * authorization transaction in order to capture the amount. Therefore, a
 * capture transaction always takes the PNRef of a authorization transaction.
 * </p>
 * ...............
 * // Populate data objects
 * ...............
 * <p/>
 * // Create a new Capture Transaction.
 * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
 * User, Connection, PayflowUtility.getrequestId();
 * <p/>
 * // Submit the transaction.
 * Response resp = trans.SubmitTransaction();
 * <p/>
 * if (Resp != null)
 * {
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (TrxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("PNREF = " + trxnResponse.getPnref());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
 * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
 * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
 * }
 * }
 * <p/>
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println( "Errors = " + ctx.ToString());
 * }
 */
public final class CaptureTransaction extends ReferenceTransaction {

    /**
     * Complete type for a capture. Y or N.
     */
    public String captureComplete;

    /**
     * Gets the captureComplete for a capture. Possible values can be Y/N.
     *
     * @return captureComplete String
     *         <p> Maps to Payflow Parameter: CAPTURECOMPLETE</p>
     */
    public String getcaptureComplete() {
        return captureComplete;
    }

    /**
     * Indicates if this Delayed Capture transaction is the last capture you intend to make.
     * The values are: Y (default) / N
     * NOTE: If CAPTURECOMPLETE is Y, any remaining amount of the original reauthorized transaction
     * is automatically voided.
     *
     * @param captureComplete String
     *                        <p> Maps to Payflow Parameter: CAPTURECOMPLETE</p>
     */
    public void setcaptureComplete(String captureComplete) {
        this.captureComplete = captureComplete;
    }

    /**
     * @param origId                String Original Transaction Id
     * @param userInfo              UserInfo object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData Connection credentials object.
     * @param Invoice               Invoice object.
     * @param requestId             Request Id.
     *  <p>
     * Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     * <p/>
     * ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User, Connection, Inv, PayflowUtility.requestId);
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.SubmitTransaction();
     * <p/>
     * if (resp != null)
     * {
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
     * }
     * }
     * <p/>
     * Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public CaptureTransaction(String origId, UserInfo userInfo, PayflowConnectionData payflowConnectionData, Invoice Invoice, String requestId) {
        super(PayflowConstants.TRXTYPE_CAPTURE, origId, userInfo, payflowConnectionData, Invoice, requestId);
    }

    /**
     * @param origId    Original Transaction Id.
     * @param userInfo  UserInfo object populated with user credentials.
     * @param invoice   Invoice object.
     * @param requestId Request Id.
     *  <p>
     * Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     *  ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction Trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User, Inv, PayflowUtility.requestId);
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     * <p/>
     * if (resp != null)
     * {
     * TransactionResponse trxnResponse =  Resp.TransactionResponse;
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
     * }
     * }
     * <p/>
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + Ctx.ToString());
     * }
     */
    public CaptureTransaction(String origId, UserInfo userInfo, Invoice invoice, String requestId) {
        this(origId, userInfo, null, invoice, requestId);
    }

    /**
     * @param origId                Original Transaction Id.
     * @param userInfo              User Info object populated with user credentials.
     * @param PayflowConnectionData Connection credentials object.
     * @param invoice               Invoice object.
     * @param tender                BaseTender object.
     * @param requestId             Request Id.
     *  <p>Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     * ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User, Connection, Inv, tender, PayflowUtility.requestId);
     * <p/>
     * // Submit the transaction.
     * Response Resp = Trans.submitTransaction();
     * <p/>
     * if (resp != null)
     * {
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
     * }
     * }
     * <p/>
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public CaptureTransaction(String origId, UserInfo userInfo, PayflowConnectionData PayflowConnectionData, Invoice invoice, BaseTender tender, String requestId) {
        super(PayflowConstants.TRXTYPE_CAPTURE, origId, userInfo, PayflowConnectionData, invoice, tender, requestId);
    }

    /**
     * @param origId    Original Transaction Id.
     * @param userInfo  User Info object populated with user credentials.
     * @param invoice   Invoice object.
     * @param tender    BaseTender object.
     * @param requestId Request Id.
     *  <p>Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     * ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User,  Inv, tender, PayflowUtility.requestId);
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     * <p/>
     * if (Resp != null)
     * {
     * TransactionResponse trxnResponse =  resp.getTransactionResponse;
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
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
    public CaptureTransaction(String origId, UserInfo userInfo, Invoice invoice, BaseTender tender, String requestId) {
        this(origId, userInfo, null, invoice, tender, requestId);
    }

    /**
     * @param origId                Original Transaction Id.
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param requestId             Request Id.
     *  <p>Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     * ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User, Connection, PayflowUtility.getrequestId());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     * <p/>
     * if (Resp != null)
     * {
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
     * if (TrxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
     * }
     * }
     * <p/>
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public CaptureTransaction(String origId, UserInfo userInfo, PayflowConnectionData payflowConnectionData, String requestId) {
        super(PayflowConstants.TRXTYPE_CAPTURE, origId, userInfo, payflowConnectionData, requestId);
    }

    /**
     * @param origId    Original Transaction Id.
     * @param userInfo  UserInfo object populated with user credentials.
     * @param requestId Request Id.
     *  <p>Capture transaction needs to be performed on a successful
     * authorization transaction in order to capture the amount. Therefore, a
     * capture transaction always takes the PNRef of a authorization transaction.
     * </p>
     * ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Capture Transaction.
     * CaptureTransaction trans = new CaptureTransaction("PNRef of Authorization transaction",
     * User, Connection, PayflowUtility.getrequestId());
     * <p/>
     * // Submit the transaction.
     * Response Resp = trans.submitTransaction();
     * <p/>
     * if (Resp != null)
     * {
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
     * if (trxnResponse != null)
     * {
     * System.out.println("RESULT = " + trxnResponse.getResult());
     * System.out.println("PNREF = " + trxnResponse.getPnref());
     * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
     * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
     * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
     * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
     * }
     * }
     * <p/>
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = Resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println(Environment.NewLine + "Errors = " + ctx.toString());
     * }
     */
    public CaptureTransaction(String origId,
                              UserInfo userInfo,
                              String requestId) {
        super(PayflowConstants.TRXTYPE_CAPTURE, origId, userInfo, requestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CAPTURECOMPLETE, captureComplete));

    }


}

