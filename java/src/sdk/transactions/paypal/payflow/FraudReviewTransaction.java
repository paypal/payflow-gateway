package paypal.payflow;

/**
 * This class is used to perform a fraud review transaction.
 * <p>Fraud Review can be used as alternative to manually
 * approving transactions under fraud on PayPal manager.</p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
 * // Ensure that Purchase price ceiling filter is set to $50.
 * // Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
 * // Submit the sale transaction and get the PNRef number from this.
 * FraudReviewTransaction trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
 * user, connection, PayflowUtility.getRequestId());
 * <p/>
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 * <p/>
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * }
 * }
 * <p/>
 * // Get the Context and check for any contained SDK specific errors (optional code).
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println("/n" + "Errors = " + ctx.toString());
 * }
 */

public final class FraudReviewTransaction extends ReferenceTransaction {

    private String updateAction;

    protected String getUpdateAction() {
        return updateAction;
    }

    protected void setUpdateAction(String updateAction) {
        this.updateAction = updateAction;
    }

    /**
     * Constructor
     *
     * @param origId                String                - Original Transaction Id.
     * @param updateAction          String                - Update Action RMS_APPROVE or RMS_MERCHANT_DECLINE.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param requestId             String                - Request Id.
     *                              <p/>
     *                              <p/>
     *                              Fraud Review can be used as alternative to manually
     *                              approving transactions under fraud.
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Ensure that Purchase price ceiling filter is set to $50.
     * // Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
     * // Submit the sale transaction and get the PNRef number from this.
     * FraudReviewTransaction trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
     * user, connection, PayflowUtility.getRequestId());
     */


    public FraudReviewTransaction(String origId,
                                  String updateAction,
                                  UserInfo userInfo,
                                  PayflowConnectionData payflowConnectionData,
                                  String requestId) {
        super(PayflowConstants.TRXTYPE_FRAUDAPPROVE, origId, userInfo,
                payflowConnectionData, requestId);
        this.updateAction = updateAction;
    }

    /**
     * Constructor
     *
     * @param origId       String   - Original Transaction Id.
     * @param updateAction String   - Update Action RMS_APPROVE or RMS_MERCHANT_DECLINE.
     * @param userInfo     UserInfo - User Info object populated with user credentials.
     * @param requestId    String   - Request Id.
     *                     <p/>
     *                     <p/>
     *                     Fraud Review can be used as alternative to manually
     *                     approving transactions under fraud.
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Ensure that Purchase price ceiling filter is set to $50.
     * // Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
     * // Submit the sale transaction and get the PNRef number from this.
     * FraudReviewTransaction trans = new FraudReviewTransaction("PNRef of Fraud Sale", "RMS_APPROVE",
     * user,  PayflowUtility.getRequestId());
     */

    public FraudReviewTransaction(String origId,
                                  String updateAction,
                                  UserInfo userInfo,
                                  String requestId) {
        this(origId, updateAction, userInfo, null, requestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        //Add UPDATEACTION
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_UPDATEACTION,
                updateAction));
    }

}
