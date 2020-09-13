package paypal.payflow;

/**
 * Used for ExpressCheckout SET operation.
 * {@link ECGetRequest}
 * {@link ECDoRequest}
 */
public class ECSetRequest extends ExpressCheckoutRequest {

    private String returnUrl;
    private String cancelUrl;
    private String reqConfirmShipping;
    private String reqBillingAddress;
    private String noShipping;
    private String addrOverride;
    private String localecode;
    private Currency maxAmt;
    private String pageStyle;
    private String headerImg;           //"cpp-headerimage"
    private String headerBorderColor;   //"cpp-header-border-color";
    private String headerBackColor;     //"cpp-header-back-color";
    private String payFlowColor;        //"cpp-payflow-color";
    private String billingType;
    private String ba_Desc;
    private String paymentType;
    private String ba_Custom;
    private String shiptoName;
    private String allowNote;

    // Transaction PayLater object. Has parameters like PromoCode, ProductCategory, etc.
    private PayLater payLater;

    /**
     * Constructor for ECSetRequest
     *
     * @param ReturnUrl - String
     * @param CancelUrl - String
     *                  <p/>
     *                  ECSetRequest is used to set the data required for a Express Checkout SET operation.
     *                  </p>
     *  .............
     * <p/>
     * //Create the ECSetrequest object
     * ECSetRequest setEC = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com");
     * <p/>
     * .............
     * </code>
     */
    public ECSetRequest(String ReturnUrl, String CancelUrl) {
        super(PayflowConstants.PARAM_ACTION_SET);
        returnUrl = ReturnUrl;
        cancelUrl = CancelUrl;
    }

    /**
     * Constructor for ECSetRequest
     *
     * @param ReturnUrl - String
     * @param CancelUrl - String
     *                  <p/>
     *                  ECSetRequest is used to set the data required for a Express Checkout SET operation.
     *                  </p>
     *  .............
     * <p/>
     * //Create the ECSetrequest object
     * ECSetRequest setEC = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com");
     * <p/>
     * .............
     * </code>
     */
    public ECSetRequest(String ReturnUrl, String CancelUrl, PayLater PayLater) {
        super(PayflowConstants.PARAM_ACTION_SET);
        returnUrl = ReturnUrl;
        cancelUrl = CancelUrl;
        payLater = PayLater;

    }

    /**
     * Constructor for ECSetRequest
     *
     * @param ReturnUrl   - String
     * @param CancelUrl   - String
     * @param BillingType - String
     * @param BA_Desc     - String
     * @param PaymentType - String
     * @param BA_Custom   - String
     *                    <p/>
     *                    <p/>
     *                    ECSetRequest is used to set the data required for a Express Checkout SET operation for
     *                    Reference Transactions with Purchase.
     *                    </p>
     *  .............
     * <p/>
     * //Create the ECSetrequest object
     * ECSetRequest setEC = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com",
     * "MerchantInitiatedBilling", "Test Transaction", "any", "Something");
     * <p/>
     * .............
     * </code>
     */
    public ECSetRequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom) {
        super(PayflowConstants.PARAM_ACTION_SET);
        returnUrl = ReturnUrl;
        cancelUrl = CancelUrl;
        billingType = BillingType;
        ba_Desc = BA_Desc;
        paymentType = PaymentType;
        ba_Custom = BA_Custom;

    }

    protected ECSetRequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom, String Action) {
        super(PayflowConstants.PARAM_ACTION_SETBA);
        returnUrl = ReturnUrl;
        cancelUrl = CancelUrl;
        billingType = BillingType;
        ba_Desc = BA_Desc;
        paymentType = PaymentType;
        ba_Custom = BA_Custom;
    }

    /**
     * Gets the returnurl parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: RETURNURL
     */
    public String getReturnUrl() {
        return returnUrl;
    }

    /**
     * Sets the Returnurl parameter.
     *
     * @param returnUrl - String
     *  <p>Maps to Payflow Parameter: RETURNURL
     */

    public void setReturnUrl(String returnUrl) {
        this.returnUrl = returnUrl;
    }

    /**
     * Gets the cancelUrl parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: CANCELURL
     */
    public String getCancelUrl() {
        return cancelUrl;
    }

    /**
     * Sets the cancelUrl parameter.
     *
     * @param cancelUrl - String
     *  <p>Maps to Payflow Parameter: CANCELURL
     */

    public void setCancelUrl(String cancelUrl) {
        this.cancelUrl = cancelUrl;
    }

    /**
     * Gets the reqConfirmShipping parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: REQCONFIRMSHIPPING
     */
    public String getReqConfirmShipping() {
        return reqConfirmShipping;
    }

    /**
     * Sets the reqBillingAddress parameter.
     *
     * @param reqBillingAddress - String
     *  <p>Maps to Payflow Parameter: REQBILLNGADDRESS
     */

    public void setReqBillingAddress(String reqBillingAddress) {
        this.reqBillingAddress = reqBillingAddress;
    }

    /**
     * Gets the reqBillingAddress parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: REQBILLNGADDRESS
     */
    public String getReqBillingAddress() {
        return reqBillingAddress;
    }

    /**
     * Sets the reqConfirmShipping parameter.
     *
     * @param reqConfirmShipping - String
     *  <p>Maps to Payflow Parameter: REQCONFIRMSHIPPING
     */

    public void setReqConfirmShipping(String reqConfirmShipping) {
        this.reqConfirmShipping = reqConfirmShipping;
    }

    /**
     * Gets the noShipping parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: NOSHIPPING
     */
    public String getNoShipping() {
        return noShipping;
    }

    /**
     * Sets the noShipping parameter.
     *
     * @param noShipping - String
     *  <p>Maps to Payflow Parameter: NOSHIPPING
     */

    public void setNoShipping(String noShipping) {
        this.noShipping = noShipping;
    }

    /**
     * Gets the addrOverride parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: ADDOVERRIDE
     */
    public String getAddrOverride() {
        return addrOverride;
    }

    /**
     * Sets the addrOverride parameter.
     *
     * @param addrOverride - String
     *  <p>Maps to Payflow Parameter: ADDROVERRIDE
     */

    public void setAddrOverride(String addrOverride) {
        this.addrOverride = addrOverride;
    }

    /**
     * Gets the localecode parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: LOCALECODE
     */
    public String getLocalecode() {
        return localecode;
    }

    /**
     * Sets the localecode parameter.
     *
     * @param localecode - String
     *  <p>Maps to Payflow Parameter: LOCALECODE
     */

    public void setLocalecode(String localecode) {
        this.localecode = localecode;
    }

    /**
     * Gets the maxAmt parameter.
     *
     * @return - currency
     *  <p>Maps to Payflow Parameter: MAXAMT
     */
    public Currency getMaxAmt() {
        return maxAmt;
    }

    /**
     * Sets the maxAmt parameter.
     *
     * @param maxAmt - Currency
     *  <p>Maps to Payflow Parameter: MAXAMT
     */

    public void setMaxAmt(Currency maxAmt) {
        this.maxAmt = maxAmt;
    }

    /**
     * Gets the pageStyle parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAGESTYLE
     */
    public String getPageStyle() {
        return pageStyle;
    }

    /**
     * Sets the pageStyle parameter.
     *
     * @param pageStyle - String
     *  <p>Maps to Payflow Parameter: PAGESTYLE
     */

    public void setPageStyle(String pageStyle) {
        this.pageStyle = pageStyle;
    }

    /**
     * Gets the HeaderImg parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: HDRIMG
     */
    public String getHeaderImg() {
        return headerImg;
    }

    /**
     * Sets the HeaderImg parameter.
     *
     * @param headerImg - String
     *  <p>Maps to Payflow Parameter: HDRIMG
     */

    public void setHeaderImg(String headerImg) {
        this.headerImg = headerImg;
    }

    /**
     * Gets the headerBorderColor parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: HDRBORDERCOLOR
     */
    public String getHeaderBorderColor() {
        return headerBorderColor;
    }

    /**
     * Sets the headerBorderColor parameter.
     *
     * @param headerBorderColor - String
     *  <p>Maps to Payflow Parameter: HDRBORDERCOLOR
     */

    public void setHeaderBorderColor(String headerBorderColor) {
        this.headerBorderColor = headerBorderColor;
    }

    /**
     * Gets the headerBackColor parameter.
     *
     * @return - headerBackColor String
     *  <p>Maps to Payflow Parameter: HDRBACKCOLOR
     */
    public String getHeaderBackColor() {
        return headerBackColor;
    }

    /**
     * Sets the headerBackColor parameter.
     *
     * @param headerBackColor - String
     *  <p>Maps to Payflow Parameter: HDRBACKCOLOR
     */

    public void setHeaderBackColor(String headerBackColor) {
        this.headerBackColor = headerBackColor;
    }

    /**
     * Gets the payFlowColor parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAYFLOWCOLOR
     */
    public String getPayFlowColor() {
        return payFlowColor;
    }

    /**
     * Sets the payFlowColor parameter.
     *
     * @param payFlowColor - String
     *  <p>Maps to Payflow Parameter: PAYFLOWCOLOR
     */

    public void setPayFlowColor(String payFlowColor) {
        this.payFlowColor = payFlowColor;
    }

    /**
     * Gets the paymentType parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: BA_CUSTOM
     */
    public String getba_Custom() {
        return ba_Custom;
    }

    /**
     * Sets the paymentType parameter.
     *
     * @param ba_Custom - String
     *  <p>Maps to Payflow Parameter: BA_CUSTOM
     */
    public void setba_Custom(String ba_Custom) {
        this.ba_Custom = ba_Custom;
    }

    /**
     * Gets the paymentType parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: PAYMENTTYPE
     */
    public String getpaymentType() {
        return paymentType;
    }

    /**
     * Sets the paymentType parameter.
     *
     * @param paymentType - String
     *  <p>Maps to Payflow Parameter: PAYMENTTYPE
     */
    public void setpaymentType(String paymentType) {
        this.paymentType = paymentType;
    }

    /**
     * Gets the ba_Desc parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: BA_DESC
     */
    public String getba_Desc() {
        return ba_Desc;
    }

    /**
     * Sets the billingType parameter.
     *
     * @param ba_Desc - String
     *  <p>Maps to Payflow Parameter: BA_DESC
     */
    public void setba_Desc(String ba_Desc) {
        this.ba_Desc = ba_Desc;
    }

    /**
     * Gets the noShipping parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: NOSHIPPING
     */
    public String getbillingType() {
        return billingType;
    }

    /**
     * Sets the billingType parameter.
     *
     * @param billingType - String
     *  <p>Maps to Payflow Parameter: BILLINGTYPE
     */
    public void setbillingType(String billingType) {
        this.billingType = billingType;
    }

    /**
     * Gets the shiptoName parameter.
     *
     * @return - string
     *  <p>Maps to Payflow Parameter: SHIPTONAME
     */
    public String getshiptoName() {
        return shiptoName;
    }

    /**
     * Sets the shiptoName parameter.
     *
     * @param shiptoName - String
     *  <p>Maps to Payflow Parameter: SHIPTONAME
     */

    public void setshiptoName(String shiptoName) {
        this.shiptoName = shiptoName;
    }

        /**
     * Gets the allowNote parameter.
     *
     * @return - string
     *  <p>Maps to Payflow Parameter: ALLOWNOTE
     */
    public String getallowNote() {
        return allowNote;
    }

    /**
     * Sets the allowNote parameter.
     *
     * @param allowNote - String
     *  <p>Maps to Payflow Parameter: ALLOWNOTE
     */

    public void setallowNote(String allowNote) {
        this.allowNote = allowNote;
    }

    protected void generateRequest() {
        // This function is not called. All the
        //address information is validated and generated
        //in its respective derived classes.
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_RETURNURL, returnUrl));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CANCELURL, cancelUrl));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_REQCONFIRMSHIPPING, reqConfirmShipping));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_REQBILLINGADDRESS, reqBillingAddress));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NOSHIPPING, noShipping));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_LOCALECODE, localecode));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MAXAMT, maxAmt));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAGESTYLE, pageStyle));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_HDRIMG, headerImg));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_HDRBORDERCOLOR, headerBorderColor));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_HDRBACKCOLOR, headerBackColor));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYFLOWCOLOR, payFlowColor));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BILLINGTYPE, billingType));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BA_DESC, ba_Desc));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYMENTTYPE, paymentType));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BA_CUSTOM, ba_Custom));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ADDROVERRIDE, addrOverride));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTONAME, shiptoName));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ALLOWNOTE, allowNote));

        if (payLater != null) {
            payLater.setRequestBuffer(getRequestBuffer());
            payLater.generateRequest();
        }
    }
}