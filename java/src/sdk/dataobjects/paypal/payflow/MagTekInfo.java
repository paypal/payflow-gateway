package paypal.payflow;

/**
 * Used for Magtek related information.
 * <p>
 * Use the MagtekInfo object for the Magtek
 * encrypted card reader related information.
 * <p>
 * Following example shows how to use the MagtekInfo object.
 * <p>
 * // Swipe is the SwipeCard object
 */
public final class MagTekInfo extends BaseRequestDataObject {

    private String encMP;
    private String encryptionBlockType;
    private String encTrack1;
    private String encTrack2;
    private String encTrack3;
    private String ksn;
    private String magtekCardType;
    private String mpStatus;
    private String registeredBy;
    private String swipedECRHost;
    private String deviceSN;
    private String merchantId;
    private String pan4;
    private String pCode;
    private String authValue1;
    private String authValue2;
    private String authValue3;
    private String magtekUserName;
    private String magtekPassword;

    /**
     * Constructor
     * <p>Use this class to set the MagTek related information. Used for encrypted swipe.</p>
     */

    public MagTekInfo() {
    }

    protected void generateRequest() {
        try {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_ENCMP, encMP));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_ENCRYPTIONBLOCKTYPE, encryptionBlockType));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK1, encTrack1));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK2, encTrack2));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK3, encTrack3));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_KSN, ksn));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKCARDTYPE, magtekCardType));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_REGISTEREDBY, registeredBy));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_SWIPEDECRHOST, swipedECRHost));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_DEVICESN, deviceSN));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_MPSTATUS, mpStatus));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_PAN4, pan4));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_MERCHANTID, merchantId));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_PCODE, pCode));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE1, authValue1));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE2, authValue2));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE3, authValue3));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKUSERNAME, magtekUserName));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKPWD, magtekPassword));


        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }

    /**
     * Gets the encrypted MagnePrint information.
     *
     * @return encMP String
     * <p>Maps to Payflow Parameter: ENCMP</p>
     */
    public String getEncMP() {
        return encMP;
    }

    /**
     * Sets the encrypted MagnePrint information.
     *
     * @param encMP String
     * <p>Maps to Payflow Parameter: ENCMP</p>
     */
    public void setEncMP(String encMP) {
        this.encMP = encMP;
    }

    /**
     * Gets the Encryption Block Type
     *
     * @return encryptionBlockType String
     * <p>Maps to Payflow Parameter: ENCRYPTIONBLOCKTYPE</p>
     */
    public String getEncryptionBlockTyp() {
        return encryptionBlockType;
    }

    /**
     * Sets the Encryption Block Type
     *
     * @param encryptionBlockType String
     * <p>Maps to Payflow Parameter: ENCRYPTIONBLOCKTYPE</p>
     */
    public void setEncryptionBlockType(String encryptionBlockType) {
        this.encryptionBlockType = encryptionBlockType;
    }

    /**
     * Gets the Encrypted Track 1
     *
     * @return encTrack1 String
     * <p>Maps to Payflow Parameter: ENCTRACK1</p>
     */
    public String getEncTrack1() {
        return encTrack1;
    }

    /**
     * Sets the Encrypted Track 1
     *
     * @param encTrack1 String
     * <p>Maps to Payflow Parameter: ENCTRACK1</p>
     */
    public void setEncTrack1(String encTrack1) {
        this.encTrack1 = encTrack1;
    }

    /**
     * Gets the Encrypted Track 2
     *
     * @return encTrack2 String
     * <p>Maps to Payflow Parameter: ENCTRACK2</p>
     */
    public String getEncTrack2() {
        return encTrack2;
    }

    /**
     * Sets the Encrypted Track 2
     *
     * @param encTrack2 String
     * <p>Maps to Payflow Parameter: ENCTRACK2</p>
     */
    public void setEncTrack2(String encTrack2) {
        this.encTrack2 = encTrack2;
    }

    /**
     * Gets the Encrypted Track 3
     *
     * @return encTrack3 String
     * <p>Maps to Payflow Parameter: ENCTRACK3</p>
     */
    public String getEncTrack3() {
        return encTrack3;
    }

    /**
     * Sets the Encrypted Track 3
     *
     * @param encTrack3 String
     * <p>Maps to Payflow Parameter: ENCTRACK3</p>
     */
    public void setEncTrack3(String encTrack3) {
        this.encTrack3 = encTrack3;
    }

    /**
     * Gets the KSN.
     *
     * @return ksn String
     * <p>Maps to Payflow Parameter: KSN</p>
     */
    public String getKsn() {
        return ksn;
    }

    /**
     * Sets the KSN.
     *
     * @param ksn String
     * <p>Maps to Payflow Parameter: KSN</p>
     */
    public void setKsn(String ksn) {
        this.ksn = ksn;
    }

    /**
     * Gets the MagTek Card Type
     *
     * @return magtekCardType String
     * <p>Maps to Payflow Parameter: MAGTEKCARDTYPE</p>
     */
    public String getMagtekCardType() {
        return magtekCardType;
    }

    /**
     * Sets the MagTek Card Type.
     *
     * @param magtekCardType String
     * <p>Maps to Payflow Parameter: MAGTEKCARDTYPE</p>
     */
    public void setMagtekCardType(String magtekCardType) {
        this.magtekCardType = magtekCardType;
    }

    /**
     * Gets the MP Status.
     *
     * @return mpStatus String
     * <p>Maps to Payflow Parameter: MPSTATUS</p>
     */
    public String getMpStatus() {
        return mpStatus;
    }

    /**
     * Sets the MP Status.
     *
     * @param mpStatus String
     * <p>Maps to Payflow Parameter: MPSTATUS</p>
     */
    public void setMpStatus(String mpStatus) {
        this.mpStatus = mpStatus;
    }

    /**
     * Gets the Registerd By.
     *
     * @return registeredBy String
     * <p>Maps to Payflow Parameter: REGISTEREDBY</p>
     */
    public String getRegisteredBy() {
        return registeredBy;
    }

    /**
     * Sets the Registered By.
     *
     * @param registeredBy String
     * <p>Maps to Payflow Parameter: REGISTEREDBY</p>
     */
    public void setRegisteredBy(String registeredBy) {
        this.registeredBy = registeredBy;
    }

    /**
     * Gets the Swiped ECR Host.
     *
     * @return swipedECRHost String
     * <p>Maps to Payflow Parameter: SWIPEDECRHOST</p>
     */
    public String getSwipedECRHost() {
        return swipedECRHost;
    }

    /**
     * Sets the Swiped ECR Host.
     *
     * @param swipedECRHost String
     * <p>Maps to Payflow Parameter: SWIPEDECRHOST</p>
     */
    public void setSwipedECRHost(String swipedECRHost) {
        this.swipedECRHost = swipedECRHost;
    }

    /**
     * Gets the Device Serial Number.
     *
     * @return deviceSN String
     * <p>Maps to Payflow Parameter: DEVICESN</p>
     */
    public String getDeviceSN() {
        return deviceSN;
    }

    /**
     * Sets the Device Serial Number.
     *
     * @param deviceSN String
     * <p>Maps to Payflow Parameter: DEVICESN</p>
     */
    public void setDeviceSN(String deviceSN) {
        this.deviceSN = deviceSN;
    }

    /**
     * Gets the Merchant's ID.
     *
     * @return merchantId String
     * <p>Maps to Payflow Parameter: MERCHANTID</p>
     */
    public String getMerchantId() {
        return merchantId;
    }

    /**
     * Sets the Merchant's ID.
     *
     * @param merchantId String
     * <p>Maps to Payflow Parameter: MERCHANTID</p>
     */
    public void setMerchantId(String merchantId) {
        this.merchantId = merchantId;
    }

    /**
     * Gets the last 4-digits of the PAN.
     *
     * @return pan4 String
     * <p>Maps to Payflow Parameter: PAN4</p>
     */
    public String getPan4() {
        return pan4;
    }

    /**
     * Sets the last 4-digits of the PAN.
     *
     * @param pan4 String
     * <p>Maps to Payflow Parameter: PAN4</p>
     */
    public void setPan4(String pan4) {
        this.pan4 = pan4;
    }

    /**
     * Gets the generated Protection Code.
     *
     * @return pCode String
     * <p>Maps to Payflow Parameter: PCODE</p>
     */
    public String getpCode() {
        return pCode;
    }

    /**
     * Sets the generated Protection Code.
     *
     * @param pCode String
     * <p>Maps to Payflow Parameter: PCODE</p>
     */
    public void setpCode(String pCode) {
        this.pCode = pCode;
    }

    /**
     * Gets the Authentication Value 1 generated with the PCode.
     *
     * @return authValue1; String
     * <p>Maps to Payflow Parameter: AUTHVALUE1</p>
     */
    public String getAuthValue1() {
        return authValue1;
    }

    /**
     * Sets the Authentication Value 1 generated with the PCode.
     *
     * @param authValue1; String
     * <p>Maps to Payflow Parameter: AUTHVALUE1</p>
     */
    public void setAuthValue1(String authValue1) {
        this.authValue1 = authValue1;
    }

    /**
     * Gets the Authentication Value 2 generated with the PCode.
     *
     * @return authValue2 String
     * <p>Maps to Payflow Parameter: AUTHVALUE2</p>
     */
    public String getAuthValue2() {
        return authValue2;
    }

    /**
     * Sets the Authentication Value 2 generated with the PCode.
     *
     * @param authValue2 String
     * <p>Maps to Payflow Parameter: AUTHVALUE2</p>
     */
    public void setAuthValue2(String authValue2) {
        this.authValue2 = authValue2;
    }

    /**
     * Gets the Authentication Value 3 generated with the PCode.
     *
     * @return authValue3 String
     * <p>Maps to Payflow Parameter: AUTHVALUE3</p>
     */
    public String getAuthValue3() {
        return authValue3;
    }

    /**
     * Sets the Authentication Value 3 generated with the PCode.
     *
     * @param authValue3 String
     * <p>Maps to Payflow Parameter: AUTHVALUE3</p>
     */
    public void setAuthValue3(String authValue3) {
        this.authValue3 = authValue3;
    }

    /**
     * Gets the MagTek User Name.
     *
     * @return magtekUserName String
     * <p>Maps to Payflow Parameter: MAGTEKUSERNAME</p>
     */
    public String getMagtekUserName() {
        return magtekUserName;
    }

    /**
     * Sets the MagTek User Name.
     *
     * @param magtekUserName String
     * <p>Maps to Payflow Parameter: MAGTEKUSERNAME</p>
     */
    public void setMagtekUserName(String magtekUserName) {
        this.magtekUserName = magtekUserName;
    }

    /**
     * Gets the MagTek Password.
     *
     * @return merchSvc String
     * <p>Maps to Payflow Parameter: MAGTEKPASSWORD</p>
     */
    public String getMagtekPassword() {
        return magtekPassword;
    }

    /**
     * Sets the MagTek Password.
     *
     * @param magtekPassword String
     * <p>Maps to Payflow Parameter: MAGTEKPASSWORD</p>
     */
    public void setMagtekPassword(String magtekPassword) {
        this.magtekPassword = magtekPassword;
    }
}
