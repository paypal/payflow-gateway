package paypal.payflow;

/**
 * Used for ExpressCheckout DO operation.
 * {@link ECSetRequest}
 * {@link ECGetRequest}
 */
public class ECDoRequest extends ExpressCheckoutRequest {

    private String payerId;

    /**
     * * <summary>
     * Constructor for ECDoRequest
     *
     * @param token   - String
     * @param payerId String
     *                <p/>
     *                ECDoRequest is used to set the data required for a Express Checkout DO operation.
     *                </p>
     *  .............
     * <p/>
     * Create the ECDoRequest object
     * ECDoRequest doEC = new ECDoRequest("[tokenid]","[payerid]");
     * <p/>
     * .............
     */
    public ECDoRequest(String token, String payerId) {
        super(PayflowConstants.PARAM_ACTION_DO, token);
        this.payerId = payerId;
    }

    protected ECDoRequest(String token, String payerId, String Action) {
        super(PayflowConstants.PARAM_ACTION_DOBA, token);
        this.payerId = payerId;
    }

    /**
     * Gets the payerid parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAYERID
     */
    public String getPayerId() {
        return payerId;
    }

    /**
     * Sets the payerid parameter.
     *
     * @param payerId - String
     *  <p>Maps to Payflow Parameter: PAYERID
     */

    public void setPayerId(String payerId) {
        this.payerId = payerId;
    }

    protected void generateRequest() {
        // This function is not called. All the
        //address information is validated and generated
        //in its respective derived classes.
        super.generateRequest();

        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYERID, payerId));

    }
}

