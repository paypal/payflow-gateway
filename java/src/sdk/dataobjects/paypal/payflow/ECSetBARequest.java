package paypal.payflow;

/**
 * Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase SET operation.
 * {@link ECGetBARequest}
 * {@link ECDoBARequest}
 */
public class ECSetBARequest extends ECSetRequest {

    /**
     * Constructor for ECSetBARequest
     *
     * @param ReturnUrl   - String
     * @param CancelUrl   - String
     * @param BillingType - String
     * @param BA_Desc     - String
     * @param PaymentType - String
     * @param BA_Custom   - String
     *                    <p/>
     *                    <p/>
     *                    ECSetBARequest is used to set the data required for a Express Checkout Billing Agreement SET operation
     *                    with Billing Agreement (Reference Transaction) without Purchase.
     *                    </p>
     *  .............
     * <p/>
     * Create the ECSetBARequest object
     * ECSetBARequest setEC = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom);
     * <p/>
     * .............
     * </code>
     */
    public ECSetBARequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc,
                          String PaymentType, String BA_Custom) {
        super(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom, PayflowConstants.PARAM_ACTION_SETBA);
    }
}
