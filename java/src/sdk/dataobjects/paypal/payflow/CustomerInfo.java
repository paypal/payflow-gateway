package paypal.payflow;

/**
 * Used for Customer related information.
 * <p>Use this class to set the customer related
 * information.</p>
 *
 *  .................
 * // inv is the Invoice object
 * .................
 * // Set the Customer Info details.
 * CustomerInfo cust = new CustomerInfo();
 * cust.setCustCode ("CustXXXXX");
 * cust.setCustIP ("255.255.255.255");
 * inv.setCustomerInfo (cust);
 * .................
 */
public final class CustomerInfo extends BaseRequestDataObject {

    private String custCode;
    private String custIP;
    private String custVatRegNum;
    private String dob;
    private String custId;
    private String reqName;
    private String custHostName;
    private String custBrowser;

    /**
     * Constructor
     * <p>Use this class to set the customer related
     * information.</p>
     */
    public CustomerInfo() {
    }

    protected void generateRequest() {
        try {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_REQNAME, reqName));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTCODE, custCode));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTIP, custIP));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTVATREGNUM, custVatRegNum));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DOB, dob));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTID, custId));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTHOSTNAME, custHostName));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTBROWSER, custBrowser));
        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }

    /**
     * Gets the CustCode
     * <p>Customer code/customer reference ID.</P>
     *
     * @return custCode String
     *  <p>Maps to Payflow Parameter: CUSTCODE</p>
     */

    public String getCustCode() {
        return custCode;
    }

    /**
     * Sets the CustCode.
     * <p>Customer code/customer reference ID.</P>
     *
     * @param custCode String
     *  <p>Maps to Payflow Parameter: CUSTCODE</p>
     */
    public void setCustCode(String custCode) {
        this.custCode = custCode;
    }

    /**
     * Gets the Customer's Id.
     *
     * @return custId String
     *  <p>Maps to Payflow Parameter: CUSTID</p>
     */

    public String getCustId() {
        return custId;
    }

    /**
     * Sets the Customer's Id.
     *
     * @param custId String
     *  <p>Maps to Payflow Parameter: CUSTID</p>
     */
    public void setCustId(String custId) {
        this.custId = custId;
    }

    /**
     * Gets the Customer's IP address.
     *
     * @return custIP String
     *  <p>Maps to Payflow Parameter: CUSTIP</p>
     */
    public String getCustIP() {
        return custIP;
    }

    /**
     * Sets the Customer's IP address.
     *
     * @param custIP String
     *  <p>Maps to Payflow Parameter: CUSTIP</p>
     */
    public void setCustIP(String custIP) {
        this.custIP = custIP;
    }

    /**
     * Gets the Customer's VAT registrations number.
     *
     * @return custVatRegNum String
     *  <p>Maps to Payflow Parameter: CUSTVATREGNUM</p>
     */
    public String getCustVatRegNum() {
        return custVatRegNum;
    }

    /**
     * Sets the Customer's VAT registrations number.
     *
     * @param custVatRegNum String
     *  <p>Maps to Payflow Parameter: CUSTVATREGNUM</p>
     */

    public void setCustVatRegNum(String custVatRegNum) {
        this.custVatRegNum = custVatRegNum;
    }

    /**
     * Gets the dob.
     * <p>Account holder's date of birth.</p>
     * <p>Format: mmddyyyy.</p>
     * <p>mm - Month, dd - Day, yy - Year.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: DOB</p>
     */
    public String getDob() {
        return dob;
    }

    /**
     * Sets the dob.
     * <p>Account holder's date of birth.</p>
     * <p>Format: mmddyyyy.</p>
     * <p>mm - Month, dd - Day, yy - Year.</P>
     *
     * @param dob String
     *  <p>Maps to Payflow Parameter: DOB</p>
     */
    public void setDob(String dob) {
        this.dob = dob;
    }

    /**
     * Gets the Requester Name.
     * @return String
     *
     * <p>Maps to Payflow Parameter: REQNAME</p>
     */
    /**
     * @return Returns the reqName.
     */
    public String getReqName() {
        return reqName;
    }

    /**
     * Sets the Requester Name.
     * @param String
     *
     * <p>Maps to Payflow Parameter: REQNAME</p>
     */
    /**
     * @param reqName The reqName to set.
     */
    public void setReqName(String reqName) {
        this.reqName = reqName;
    }

    /**
     * Gets the Customer's Host Name.
     * @return String
     *
     * <p>Maps to Payflow Parameter: CUSTHOMENAME</p>
     */
    /**
     * @return Returns the custHostName.
     */
    public String getCustHostName() {
        return custHostName;
    }

    /**
     * Sets the Customer's Host Name.
     * @param String
     *
     * <p>Maps to Payflow Parameter: CUSTHOMENAME</p>
     */
    /**
     * @param custHostName The customer host name to set.
     */
    public void setCustHostName(String custHostName) {
        this.custHostName = custHostName;
    }

    /**
     * Gets the Customer's Browser.
     * @return String
     *
     * <p>Maps to Payflow Parameter: CUSTBROWSER</p>
     */
    /**
     * @return Returns the custBrowser.
     */
    public String getCustBrowser() {
        return custBrowser;
    }

    /**
     * Sets the Customer's Browser.
     * @param String
     *
     * <p>Maps to Payflow Parameter: CUSTBROWSER</p>
     */
    /**
     * @param custBrowser The customers browser.
     */
    public void setCustBrowser(String custBrowser) {
        this.custBrowser = custBrowser;
    }
}
