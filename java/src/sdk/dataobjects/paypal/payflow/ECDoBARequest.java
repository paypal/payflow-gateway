package paypal.payflow;

/**
 * Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase DO operation.
 * {@link ECSetBARequest}
 * {@link ECGetBARequest}
 */

public class ECDoBARequest extends ECDoRequest {

    /**
     *
     * Constructor for ECDoBARequest
     *
     *
     * @param token   String
     * @param payerId String
     *                 * <p>
     *                ECDoBARequest is used to set the data required for a Express Checkout DO operation
     *                with Billing Agreement (Reference Transaction) without Purchase.
     *                </p>
     *  .............
     *  * <p>
     * Create the ECDoBARequest object
     * ECDoBARequest doEC = new ECDoBARequest("[tokenid]","[payerid]");
     *  * <p>
     * .............
     */

    public ECDoBARequest(String token, String payerId) {
        super(token, payerId, PayflowConstants.PARAM_ACTION_DOBA);

    }

}
