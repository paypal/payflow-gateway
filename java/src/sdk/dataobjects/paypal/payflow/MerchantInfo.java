package paypal.payflow;

/**
 * Used for Merchant  related information.
 * <p>Use this class to set the customer related
 * information.</p>
 *
 *  .................
 * // inv is the Invoice object
 * .................
 *	// Set the Merchant Info details.
 *	MerchantInfo Merchant = New MerchantInfo();
 *	Merchant.MerchantCode = "MerchantXXXXX";
 *	Merchant.MerchantCity = "Anywhere";
 *	Inv.MerchantInfo = Merchant;
 * .................
 */
public final class MerchantInfo extends BaseRequestDataObject {

    private String merchDescr;
    private String merchSvc;
    private String merchantName;
    private String merchantStreet;
    private String merchantCity;
    private String merchantState;
    private String merchantCountryCode;
    private String merchantZip;
    private String merchantUrl;
    private String merchantVatNum;
    private String merchantInvoiceNum;
    private String merchantLocationId;
    private String merchantId;
    private String merchantContactInfo;

    /**
     * Constructor
     * <p>Use this class to set the Merchant related information. Used for Soft Descriptor.</p>
     */
    public MerchantInfo() {
    }

    protected void generateRequest() {
        try {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTNAME, merchantName));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTSTREET, merchantStreet));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTCITY, merchantCity));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTSTATE, merchantState));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTZIP, merchantZip));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTCOUNTRYCODE, merchantCountryCode));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTURL, merchantUrl));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTVATNUM, merchantVatNum));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTINVOICENUM, merchantInvoiceNum));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTLOCATIONID, merchantLocationId));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTID, merchantId));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTCONTACTINFO, merchantContactInfo));

            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHDESCR, merchDescr));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHSVC, merchSvc));
        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }

    /**
     * Gets the Merchant's Name.
     *
     * @return merchantName String
     *  <p>Maps to Payflow Parameter: MERCHANTNAME</p>
     */
    public String getMerchantName() {
        return merchantName;
    }

    /**
     * Sets the Merchant's Name.
     * <p>Merchant/Business Name</P>
     *
     * @param merchantName String
     *  <p>Maps to Payflow Parameter: MERCHANTNAME</p>
     */
    public void setMerchantName(String merchantName) {
        this.merchantName = merchantName;
    }

    /**
     * Gets the Merchant's Street.
     *
     * @return merchantStreet String
     *  <p>Maps to Payflow Parameter: MERCHANTSTREET</p>
     */
    public String getmerchantStreet() {
        return merchantStreet;
    }

    /**
     * Sets the Merchant's Street.
     *
     * @param merchantStreet String
     *  <p>Maps to Payflow Parameter: MERCHANTSTREET</p>
     */
    public void setMerchantStreet(String merchantStreet) {
        this.merchantStreet = merchantStreet;
    }

    /**
     * Gets the Merchant's City.
     *
     * @return merchantCity String
     *  <p>Maps to Payflow Parameter: MERCHANTCITY</p>
     */
    public String getMerchantCity() {
        return merchantCity;
    }

    /**
     * Sets the Merchant's City.
     *
     * @param merchantCity String
     *  <p>Maps to Payflow Parameter: MERCHANTCITY</p>
     */
    public void setMerchantCity(String merchantCity) {
        this.merchantCity = merchantCity;
    }

    /**
     * Gets the Merchant's State.
     *
     * @return merchantState String
     *  <p>Maps to Payflow Parameter: MERCHANTSTATE   </p>
     */
    public String getMerchantState() {
        return merchantState;
    }

    /**
     * Sets the Merchant's State.
     *
     * @param merchantState String
     *  <p>Maps to Payflow Parameter: MERCHANTSTATE</p>
     */
    public void setMerchantState(String merchantState) {
        this.merchantState = merchantState;
    }

    /**
     * Gets the Merchant's Zip.
     *
     * @return merchantZip String
     *  <p>Maps to Payflow Parameter: MERCHANTZIP</p>
     */
    public String getMerchantZip() {
        return merchantZip;
    }

    /**
     * Sets the Merchant's Zip.
     *
     * @param merchantZip String
     *  <p>Maps to Payflow Parameter: MERCHANTZIP</p>
     */
    public void setMerchantZip(String merchantZip) {
        this.merchantZip = merchantZip;
    }

    /**
     * Gets the Merchant Country Code.
     *
     * @return merchantCountyCode String
     *  <p>Maps to Payflow Parameter: MERCHANTCOUNTRYCODE</p>
     */
    public String getMerchantCountryCode() {
        return merchantCountryCode;
    }

    /**
     * Sets the Merchant Country Code.
     * @param merchantCountryCode String
     *  <p>Maps to Payflow Parameter: MERCHANTCOUNTRYCODE</p>
     */
    public void setMerchantCountryCode(String merchantCountryCode) {
        this.merchantCountryCode = merchantCountryCode;
    }

    /**
     * Gets the Merchant Url.
     *
     * @return merchantUrl String
     *  <p>Maps to Payflow Parameter: MERCHANTURL</p>
     */
    public String getMerchantUrl() {
        return merchantUrl;
    }

    /**
     * Sets the Merchant Url.
     * @param merchantUrl String
     *  <p>Maps to Payflow Parameter: MERCHANTURL</p>
     */
    public void setMerchantUrl(String merchantUrl) {
        this.merchantUrl = merchantUrl;
    }

    /**
     * Gets the Merchant VAT number.
     *
     * @return merchantVatNum String
     *  <p>Maps to Payflow Parameter: MERCHANTVATNUM</p>
     */
    public String getMerchantVatNum() {
        return merchantVatNum;
    }

    /**
     * Sets the Merchant VAT number.
     * @param merchantVatNum String
     *  <p>Maps to Payflow Parameter: MERCHANTVATNUM</p>
     */
    public void setMerchantVatNum(String merchantVatNum) {
        this.merchantVatNum = merchantVatNum;
    }

    /**
     * Gets the Merchant Invoice number.
     *
     * @return merchantInvoiceNum String
     *  <p>Maps to Payflow Parameter: MERCHANTINVOICENUM</p>
     */
    public String getMerchantInvoiceNum() {
        return merchantInvoiceNum;
    }
    /**
     * Sets the Merchant Invoice number.
     * @param merchantInvoiceNum String
     *  <p>Maps to Payflow Parameter: MERCHANTINVOICENUM</p>
     */
    public void setMerchantInvoiceNum(String merchantInvoiceNum) {
        this.merchantInvoiceNum = merchantInvoiceNum;
    }

    /**
     * Gets the Merchant Location Id.
     * Merchant assigned store or location number.
     * @return - String
     *  <p>Maps to Payflow Parameter: MERCHANTLOCATIONID</p>
     */
    public String getMerchantLocationId() {
        return merchantLocationId;
    }
    /**
     * Sets the Merchant Location Id.
     * @param merchantLocationId String
     *  <p>Maps to Payflow Parameter: MERCHANTLOCATIONID</p>
     */
    public void setMerchantLocationId(String merchantLocationId) {
        this.merchantLocationId = merchantLocationId;
    }

    /**
     * Gets the Merchant Id.
     * Processor assigned Id.
     * @return - String
     *  <p>Maps to Payflow Parameter: MERCHANTID
     */
    public String getMerchantId() {
        return merchantId;
    }
    /**
     * Sets the Merchant Id.
     * @param merchantId String
     *  <p>Maps to Payflow Parameter: MERCHANTID</p>
     */
    public void setMerchantId(String merchantId) {
        this.merchantId = merchantId;
    }

    /**
     * Gets the Merchant Contact Information.
     * Merchants telephone, URl or email.
     * @return - String
     *  <p>Maps to Payflow Parameter: MERCHANTCONTACTINFO
     */
    public String getMerchantContactInfo() {
        return merchantContactInfo;
    }
    /**
     * Sets the Merchant Contact Information.
     * @param merchantContactInfo String
     *  <p>Maps to Payflow Parameter: MERCHANTCONTANCTINFO</p>
     */
    public void setMerchantContactInfoId(String merchantContactInfo) {
        this.merchantContactInfo = merchantContactInfo;
    }
















    /**
     * Gets the Merchant's description.
     *
     * @return merchDescr String
     *  <p>Maps to Payflow Parameter: MERCHDESCR</p>
     */
    public String getMerchDescr() {
        return merchDescr;
    }

    /**
     * Sets the Merchant's description.
     *
     * @param merchDescr String
     *  <p>Maps to Payflow Parameter: MERCHDESCR</p>
     */
    public void setMerchDescr(String merchDescr) {
        this.merchDescr = merchDescr;
    }

    /**
     * Gets the Merchant's contact information.
     *
     * @return merchSvc String
     *  <p>Maps to Payflow Parameter: MERCHSVC</p>
     */
    public String getMerchSvc() {
        return merchSvc;
    }

    /**
     * Sets the Merchant's contact information.
     *
     * @param merchSvc String
     *  <p>Maps to Payflow Parameter: MERCHSVC</p>
     */
    public void setMerchSvc(String merchSvc) {
        this.merchSvc = merchSvc;
    }
}
