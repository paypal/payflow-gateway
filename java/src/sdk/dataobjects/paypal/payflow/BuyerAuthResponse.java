package paypal.payflow;

import java.util.Hashtable;

/**
 * Used for the buyerauth operation
 */
public class BuyerAuthResponse extends BaseResponseDataObject {


    private String acsUrl;
    private String authenticationId;
    private String authenticationStatus;
    private String cavv;
    private String eci;
    private String paReq;
    private String xid;
    private String md;

    protected BuyerAuthResponse() {
    }

    /**
     * Gets the acsurl parameter.
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: ACSURL</p>
     */
    public String getAcsUrl() {
        return acsUrl;
    }

    /**
     * Sets the acsurl parameter.
     *
     * @param acsUrl String
     * @paypal.sample <p>Maps to Payflow Parameter: ACSURL</p>
     */
    public void setAcsUrl(String acsUrl) {
        this.acsUrl = acsUrl;
    }

    /**
     * Gets the authentication_id parameter.
     *
     * @return authenticationId String
     * @paypal.sample <p>Maps to Payflow Parameter: AUTHENTICATION_ID</p>
     */
    public String getAuthenticationId() {
        return authenticationId;
    }

    /**
     * Sets the authentication_id parameter.
     *
     * @param authenticationId String
     * @paypal.sample <p>Maps to Payflow Parameter: AUTHENTICATION_ID</p>
     */
    public void setAuthenticationId(String authenticationId) {
        this.authenticationId = authenticationId;
    }

    /**
     * Gets the authentication_status parameter.
     *
     * @return authenticationStatus String
     * @paypal.sample <p>Maps to Payflow Parameter: AUTHENTICATION_STATUS</p>
     */
    public String getAuthenticationStatus() {
        return authenticationStatus;
    }

    /**
     * Sets the authentication_status parameter.
     *
     * @param authenticationStatus String
     * @paypal.sample <p>Maps to Payflow Parameter: AUTHENTICATION_STATUS</p>
     */
    public void setAuthenticationStatus(String authenticationStatus) {
        this.authenticationStatus = authenticationStatus;
    }

    /**
     * Gets the CAVV parameter.
     *
     * @return cavv String
     * @paypal.sample <p>Maps to Payflow Parameter: CAVV</p>
     */
    public String getCavv() {
        return cavv;
    }

    /**
     * Sets the CAVV parameter.
     *
     * @param cavv String
     * @paypal.sample <p>Maps to Payflow Parameter: CAVV</p>
     */
    public void setCavv(String cavv) {
        this.cavv = cavv;
    }

    /**
     * Gets the ECI parameter.
     *
     * @return eci String
     * @paypal.sample <p>Maps to Payflow Parameter: ECI</p>
     */
    public String getEci() {
        return eci;
    }

    /**
     * Sets the ECI parameter.
     *
     * @param eci String
     * @paypal.sample <p>Maps to Payflow Parameter: ECI</p>
     */
    public void setEci(String eci) {
        this.eci = eci;
    }

    /**
     * Gets the MD parameter.
     *
     * @return md String
     * @paypal.sample <p>Maps to Payflow Parameter: MD</p>
     */
    public String getMd() {
        return md;
    }

    /**
     * Sets the MD parameter.
     *
     * @param md String
     * @paypal.sample <p>Maps to Payflow Parameter: MD</p>
     */
    public void setMd(String md) {
        this.md = md;
    }

    /**
     * Gets the PaReq parameter.
     *
     * @return paReq String
     * @paypal.sample <p>Maps to Payflow Parameter: PAREQ</p>
     */
    public String getPaReq() {
        return paReq;
    }

    /**
     * Sets the PaReq parameter.
     *
     * @param paReq String
     * @paypal.sample <p>Maps to Payflow Parameter: PAREQ</p>
     */
    public void setPaReq(String paReq) {
        this.paReq = paReq;
    }

    /**
     * Gets the XID parameter.
     *
     * @return xid String
     * @paypal.sample <p>Maps to Payflow Parameter: XID</p>
     */
    public String getXid() {
        return xid;
    }

    /**
     * Sets the XID parameter.
     *
     * @param xid String
     * @paypal.sample <p>Maps to Payflow Parameter: XID</p>
     */
    public void setXid(String xid) {
        this.xid = xid;
    }

    protected void setParams(Hashtable ResponseHashTable) {

        acsUrl = (String) ResponseHashTable.get(PayflowConstants.PARAM_ACSURL);
        authenticationId = (String) ResponseHashTable.get(PayflowConstants.PARAM_AUTHENTICATION_ID);
        authenticationStatus = (String) ResponseHashTable.get(PayflowConstants.PARAM_AUTHENICATION_STATUS);
        cavv = (String) ResponseHashTable.get(PayflowConstants.PARAM_CAVV);
        eci = (String) ResponseHashTable.get(PayflowConstants.PARAM_ECI);
        md = (String) ResponseHashTable.get(PayflowConstants.PARAM_MD);
        paReq = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAREQ);
        xid = (String) ResponseHashTable.get(PayflowConstants.PARAM_XID);
        ResponseHashTable.remove(PayflowConstants.PARAM_ACSURL);
        ResponseHashTable.remove(PayflowConstants.PARAM_AUTHENTICATION_ID);
        ResponseHashTable.remove(PayflowConstants.PARAM_AUTHENICATION_STATUS);
        ResponseHashTable.remove(PayflowConstants.PARAM_CAVV);
        ResponseHashTable.remove(PayflowConstants.PARAM_ECI);
        ResponseHashTable.remove(PayflowConstants.PARAM_MD);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAREQ);
        ResponseHashTable.remove(PayflowConstants.PARAM_XID);
    }

}