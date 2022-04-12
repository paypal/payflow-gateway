package paypal.payflow;

/**
 * This abstract class serves as base class of all tender objects.
 * Each tender type is associated with a Payment Device.
 * Following are the Payment Devices associated with different tender types:
 *
 * Tender Type Payment Device Data Object
 *
 * ACHTender - {@link BankAcct}
 * CardTender - {@link CreditCard} {@link PurchaseCard} {@link SwipeCard}
 * CheckTender- {@link CheckPayment}
 *
 */
public class BaseTender extends BaseRequestDataObject {
    /**
     * Holds the tender type.
     */
    private String tender;
    /**
     * Holds the associated payment device.
     */
    private PaymentDevice paymentDevice;
    /**
     * Holds Check number
     */
    private String chkNum;
    /**
     * Holds Check type
     */
    private String chkType;
    /**
     * Holds dL Type
     */
    private String dL;
    /**
     * Holds the sS Type
     */
    private String sS;
    /**
     * Holds the authType
     */
    private String authType;
    /**
     * Gets the checkNumber.
     * <p>
     * For ACH - The check serial number. Required for POP, ARC, and RCK.
     * For TeleCheck - Account holder's next unused (available) check number.</p>
     *
     * @return chkNum String
     *
     *  <p> Maps to Payflow Parameter: CHKNUM </p>
     */
    public String getChkNum() {
        return chkNum;
    }

    /**
     * Sets the check Number.
     * <p>
     * For ACH - The check serial number. Required for POP, ARC, and RCK.
     * For TeleCheck - Account holder's next unused (available) check number.</p>
     *
     * @param chkNum String
     *  <p> Maps to Payflow Parameter: CHKNUM </p>
     */
    public void setChkNum(String chkNum) {
        this.chkNum = chkNum;
    }

    /**
     *  Gets the Authtype.
     *   * <p>
     *  Allowed AuthTypes for ACH:
     *  CCD (B2B), PPD (B2C), ARC (Accounts Receivables)
     *  RCK (Re-presentment), WEB (Internet), TEL (Telephone, mailorder), POP (Point of Purchase)
     *   * <p>
     *  Allowed AuthTypes for TeleCheck:
     *  I (Internet), P (Telephone, mailorder), D (Prearranged Deposits)
     * @param authType String
     * <p>Maps to Payflow Parameter: AUTHTYPE</p>
     */
    public void getAuthType(String authType) {this.authType = authType;}

    /**
     * Gets the check Type.
     * <p>Allowed CheckTypes are:
     * Check Type - Description
     *
     * P - Personal
     * C - Company
     * </p>
     * @return chkNum String
     *  <p> Maps to Payflow Parameter: CHKTYPE</p>
     */
    public String getChkType() {
        return chkType;
    }

    /**
     * sets the check type
     *
     * @param chkType String
     * <p>
     * Allowed CheckTypes are:
     *
     * Check Type - Description
     *
     * P - Personal
     * C - Company
     * </p>
     * <p> Maps to Payflow Parameter: CHKTYPE</p>
     */
    public void setChkType(String chkType) {
        this.chkType = chkType;
    }

    /**
     * gets the drivers License Number.
     *
     * @return dL String
     *  <p>Format: XXnnnnnnnn</p>
     * <p>XX = State Code, nnnnnnnn = DL Number</p>
     * <p>Maps to Payflow Parameter: DL </p>
     */
    public String getDL() {
        return dL;
    }

    /**
     * Gets the Tender Type.
     *
     * @return tender
     *
     * <p>Maps to Payflow Parameter: TENDER</p>
     */
    public String getTender() {
        return tender;
    }

    /**
     * gets the drivers License Number.
     *
     * @param dL String
     *  <p>Format: XXnnnnnnnn</p>
     * <p>XX = State Code, nnnnnnnn = DL Number</p>
     * <p>Maps to Payflow Parameter: DL </p>
     */
    public void setDL(String dL) {
        this.dL = dL;
    }

    /**
     * returns the account holders social security number
     *
     * @return sS String
     *  <p>Maps to Payflow Parameter: SS </p>
     */
    public String getSS() {
        return sS;
    }

    /**
     * returns the account holders social security number
     * <p>Maps to Payflow Parameter: SS </p>
     *
     * @param sS String
     */
    public void setSS(String sS) {
        this.sS = sS;
    }

    /**
     * returns the authorization type
     * <p>Maps to Payflow Parameter: AUTHTYPE </p>
     *
     * @param authType String
     */
    public void setAuthType(String authType) {
        this.authType = authType;
    }

    /**
     * Constructor for BaseTender.
     * Abstract class. Instance cannot be created directly.
     *
     * @param tender    String
     * @param payDevice PaymentDevice
     */
    public BaseTender(String tender, PaymentDevice payDevice) {
        this.tender = tender;
        this.paymentDevice = payDevice;

    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        if (paymentDevice != null) {
            paymentDevice.setRequestBuffer(this.getRequestBuffer());
            paymentDevice.generateRequest();
        }

        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TENDER, tender));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CHKNUM, chkNum));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CHKTYPE, chkType));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DL, dL));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SS, sS));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHTYPE, authType));
    }

}
