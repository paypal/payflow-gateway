package paypal.payflow;

/**
 * Used for ExpressCheckout GET operation.
 * {@link ECSetRequest}
 * {@link ECDoRequest}
 */

public class ECGetRequest extends ExpressCheckoutRequest {

    /**
     * Constructor for ECGetRequest
     *
     * @param Token String
     *              <p/>
     *              <p/>
     *              ECGetRequest is used to set the data required for a Express Checkout GET operation.
     *              </p>
     *  .............
     * <p/>
     * Create the ECGetRequest object
     * ECGetRequest getEC = new ECGetRequest("[tokenid]");
     * <p/>
     * .............
     */
    public ECGetRequest(String Token) {
        super(PayflowConstants.PARAM_ACTION_GET, Token);
    }

    protected ECGetRequest(String Token, String Action) {
        super(PayflowConstants.PARAM_ACTION_GETBA, Token);
    }

}

