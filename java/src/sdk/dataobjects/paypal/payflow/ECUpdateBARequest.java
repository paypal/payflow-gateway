package paypal.payflow;

/**
 * Used for ExpressCheckout UPDATE operation.
 * {@link ECGetRequest}
 * {@link ECDoRequest}
 */
public class ECUpdateBARequest extends ExpressCheckoutRequest {

    private String baid;
    private String ba_Status;
    private String ba_Desc;

    /**
     * Constructor for ECSetRequest
     *
     * @param BAId - String
     *             <p/>
     *             ECUpdateRequest is used to set the data required for a Express Checkout UPDATE operation.
     *             </p>
     * @paypal.sample .............
     * <p/>
     * //Create the ECUpdateRequest object
     * ECUpdateRequest updateEC = new ECUpdateRequest("baid");
     * <p/>
     * .............
     * </code>
     */
    public ECUpdateBARequest(String BAId) {
        super(PayflowConstants.PARAM_ACTION_UPDATE);
        baid = BAId;
    }

    /**
     * Constructor for ECUpdateRequest
     *
     * @param BAId      - String
     * @param BA_Status - String
     *                  <p/>
     *                  <p/>
     *                  ECSetRequest is used to set the data required for a Express Checkout Update operation for
     *                  Reference Transactions without Purchase.
     *                  </p>
     * @paypal.sample .............
     * <p/>
     * //Create the ECUpdateRequest object
     * ECUpdateRequest updateEC = new ECSetRequest("baid","ba_status");
     * <p/>
     * .............
     * </code>
     */
    public ECUpdateBARequest(String BAId, String BA_Status) {
        super(PayflowConstants.PARAM_ACTION_UPDATE);
        baid = BAId;
        ba_Status = BA_Status;
    }

    /**
     * Constructor for ECUpdateRequest
     *
     * @param BAId      - String
     * @param BA_Status - String
     * @param BA_Desc   - String
     *                  <p/>
     *                  <p/>
     *                  ECSetRequest is used to set the data required for a Express Checkout Update operation for
     *                  Reference Transactions without Purchase.
     *                  </p>
     * @paypal.sample .............
     * <p/>
     * //Create the ECUpdateRequest object
     * ECUpdateRequest updateEC = new ECSetRequest("baid","ba_status", "ba_desc");
     * <p/>
     * .............
     * </code>
     */
    public ECUpdateBARequest(String BAId, String BA_Status, String BA_Desc) {
        super(PayflowConstants.PARAM_ACTION_UPDATE);
        baid = BAId;
        ba_Status = BA_Status;
        ba_Desc = BA_Desc;
    }

    /**
     * Gets the BAId parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BAID
     */
    public String getBAId() {
        return baid;
    }

    /**
     * Sets the BAId parameter.
     *
     * @param BAId - String
     * @paypal.sample <p>Maps to Payflow Parameter: BAID
     */

    public void setBAId(String BAId) {
        this.baid = BAId;
    }

    /**
     * Gets the BA_Status parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_STATUS
     */
    public String getba_Status() {
        return ba_Status;
    }

    /**
     * Sets the BA_Status parameter.
     *
     * @param BA_Status - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_STATUS
     */

    public void setba_Status(String BA_Status) {
        this.ba_Status = BA_Status;
    }

    /**
     * Gets the BA_Desc parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_DESC
     */
    public String getBA_Desc() {
        return ba_Desc;
    }

    /**
     * Sets the BA_Desc parameter.
     *
     * @param BA_Desc - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_DESC
     */

    public void setBA_Desc(String BA_Desc) {
        this.ba_Desc = BA_Desc;
    }

    protected void generateRequest() {
        // This function is not called. All the
        //address information is validated and generated
        //in its respective derived classes.
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BA_STATUS, ba_Status));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BA_DESC, ba_Desc));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BAID, baid));

    }
}

