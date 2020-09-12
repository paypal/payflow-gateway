/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
package paypal.payflow;

/**
 * Used for BuyerAuth Status information.
 * <p>Use this class to set the BuyerAuth Status related information.</p>
 */
public class BuyerAuthStatus extends BaseRequestDataObject {

    private String authenticationId;
    private String authenticationStatus;
    private String cavv;
    private String xid;
    private String eci;
    // added 12/21/2009 tsieber
    private String authstatus3ds;
    private String mpivendor3ds;
    private String version;

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
     * @return authenticationId String
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
     * Constructor
     */
    public BuyerAuthStatus() {
    }


    protected void generateRequest() {

        this.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHENTICATION_ID, this.authenticationId));
        this.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AUTHENICATION_STATUS, this.authenticationStatus));
        this.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CAVV, this.cavv));
        this.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_XID, this.xid));
        this.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ECI, this.eci));

    }

}
