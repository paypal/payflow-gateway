package paypal.payflow;

/**
 * This class is used to create and perform an Order Transaction for Express Checkout.
 *  * <p>
 * An Order transaction represents an agreement to pay one or more authorized amounts up to
 * the specified total over a maximum of 29 days.
 *  * <p>
 *
 *  This example shows how to create and perform a order transaction as part of Express Checkout.
 *  * <p>
 * ..........
 * ..........
 * //Populate required data objects.
 * ..........
 * ..........
 *  * <p>
 * // Create a new Order Transaction.
 * OrderTransaction Trans = new OrderTransaction(
 * userInfo,
 * PayflowConnectionData,
 * Invoice,
 * Tender,
 * RequestId);
 * //Submit the transaction.
 * trans.submitTransaction();
 *  * <p>
 * // Get the Response.
 * Response resp = trans.getResponse();
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.transactionResponse();
 * // Display the transaction response parameters.
 * if (Resp != null) {
 * // Get the Transaction Response parameters.
 * TransactionResponse TrxnResponse = Resp.getTransactionResponse();
 * if (TrxnResponse != null) {
 * System.out.println("RESULT = " + TrxnResponse.getResult());
 * System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
 * System.out.println("TOKEN = " + Trans.getResponse().getEcSetResponse().getToken());
 * System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
 * // If value is true, then the Request ID has not been changed and the original response
 * // of the original transction is returned.
 * System.out.println("DUPLICATE = " + TrxnResponse.getDuplicate());
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() %3E 0)
 * {
 * System.out.println("Errors = " + ctx.ToString());
 * }
 */

public class OrderTransaction extends AuthorizationTransaction {
    /**
     * Constructor.
     *
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection object.
     * @param invoice               Invoice object.
     * @param tender                Tender object
     * @param requestId             String Request Id
     *  This example shows how to create and perform
     * a authorization transaction.
     *  * <p>
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     *  * <p>
     * // Create a new Order Transaction.
     * OrderTransaction Trans = new OrderTransaction(
     * userInfo,
     * PayflowConnectionData,
     * Invoice,
     * Tender,
     * RequestId);
     * //Submit the transaction.
     * trans.submitTransaction();
     *  * <p>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (Resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.transactionResponse();
     * // Display the transaction response parameters.
     * if (Resp != null) {
     * // Get the Transaction Response parameters.
     * TransactionResponse TrxnResponse = Resp.getTransactionResponse();
     * if (TrxnResponse != null) {
     * System.out.println("RESULT = " + TrxnResponse.getResult());
     * System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
     * System.out.println("TOKEN = " + Trans.getResponse().getEcSetResponse().getToken());
     * System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
     * // If value is true, then the Request ID has not been changed and the original response
     * // of the original transction is returned.
     * System.out.println("DUPLICATE = " + TrxnResponse.getDuplicate());
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() %3E 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public OrderTransaction(UserInfo userInfo,
                            PayflowConnectionData payflowConnectionData,
                            Invoice invoice,
                            PayPalTender tender,
                            String requestId) {
        super("O", userInfo, payflowConnectionData, invoice, tender, requestId);
    }

    /**
     * Constructor.
     *
     * @param userInfo  User Info object populated with user credentials.
     * @param invoice   Invoice object.
     * @param tender    Tender object
     * @param requestId String Request Id
     *  This example shows how to create and perform
     * a authorization transaction.
     *  * <p>
     * ..........
     * ..........
     * //Populate required data objects.
     * ..........
     * ..........
     *  * <p>
     * // Create a new Order Transaction.
     * OrderTransaction Trans = new OrderTransaction(
     * userInfo,
     * Invoice,
     * Tender,
     * RequestId);
     * //Submit the transaction.
     * trans.submitTransaction();
     *  * <p>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (Resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.transactionResponse();
     * // Display the transaction response parameters.
     * if (Resp != null) {
     * // Get the Transaction Response parameters.
     * TransactionResponse TrxnResponse = Resp.getTransactionResponse();
     * if (TrxnResponse != null) {
     * System.out.println("RESULT = " + TrxnResponse.getResult());
     * System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
     * System.out.println("TOKEN = " + Trans.getResponse().getEcSetResponse().getToken());
     * System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
     * // If value is true, then the Request ID has not been changed and the original response
     * // of the original transction is returned.
     * System.out.println("DUPLICATE = " + TrxnResponse.getDuplicate());
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() %3E 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public OrderTransaction(UserInfo userInfo,
                            Invoice invoice,
                            PayPalTender tender,
                            String requestId) {
        super("0", userInfo, invoice, tender, requestId);
    }
}
