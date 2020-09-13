package paypal.payflow;

/**
 * Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase GET operation.
 * {@link ECSetBARequest}
 * {@link ECDoBARequest}
 */

public class ECGetBARequest extends ECGetRequest {
    /**
     * Constructor for ECGetBARequest
     *
     * @param Token String
     *              <p/>
     *              <p/>
     *              ECGetBARequest is used to set the data required for a Express Checkout GET operation
     *              with Billing Agreement (Reference Transaction) without Purchase.
     *              </p>
     *  .............
     * <p/>
     * Create the ECGetBARequest object
     * ECGetBARequest getEC = new ECGetBARequest("[tokenid]");
     * <p/>
     * .............
     */

    public ECGetBARequest(String Token) {
        super(Token, PayflowConstants.PARAM_ACTION_GETBA);
    }
}
