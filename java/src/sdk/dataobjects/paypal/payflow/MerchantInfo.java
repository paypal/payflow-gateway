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
 * Used for Merchant  related information.
 * <p>Use this class to set the customer related
 * information.</p>
 *
 * @paypal.sample .................
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
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTNAME/p>
     */
    public String getMerchantName() {
        return merchantName;
    }

    /**
     * Sets the Merchant's Name.
     * <p>Merchant/Business Name</P>
     *
     * @param merchantName String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTNAME</p>
     */
    public void setMerchantName(String merchantName) {
        this.merchantName = merchantName;
    }

    /**
     * Gets the Merchant's Street.
     *
     * @return merchantStreet String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTSTREET</p>
     */
    public String getmerchantStreet() {
        return merchantStreet;
    }

    /**
     * Sets the Merchant's Street.
     *
     * @param merchantStreet String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTSTREET</p>
     */
    public void setMerchantStreet(String merchantStreet) {
        this.merchantStreet = merchantStreet;
    }

    /**
     * Gets the Merchant's City.
     *
     * @return merchantCity String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTCITY</p>
     */
    public String getMerchantCity() {
        return merchantCity;
    }

    /**
     * Sets the Merchant's City.
     *
     * @param merchantCity String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTCITY</p>
     */
    public void setMerchantCity(String merchantCity) {
        this.merchantCity = merchantCity;
    }

    /**
     * Gets the Merchant's State.
     *
     * @return merchantState String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTSTATE   </p>
     */
    public String getMerchantState() {
        return merchantState;
    }

    /**
     * Sets the Merchant's State.
     *
     * @param merchantState String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTSTATE</p>
     */
    public void setMerchantState(String merchantState) {
        this.merchantState = merchantState;
    }

    /**
     * Gets the Merchant's Zip.
     *
     * @return merchantZip String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTZIP</p>
     */
    public String getMerchantZip() {
        return merchantZip;
    }

    /**
     * Sets the Merchant's Zip.
     *
     * @param merchantZip String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTZIP</p>
     */
    public void setMerchantZip(String merchantZip) {
        this.merchantZip = merchantZip;
    }

    /**
     * Gets the Merchant Country Code.
     *
     * @return merchantCountyCode String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTCOUNTRYCODE</p>
     */
    public String getMerchantCountryCode() {
        return merchantCountryCode;
    }

    /**
     * Sets the Merchant Country Code.
     * @param merchantCountryCode String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHANTCOUNTRYCODE</p>
     */
    public void setMerchantCountryCode(String merchantCountryCode) {
        this.merchantCountryCode = merchantCountryCode;
    }


    /**
     * Gets the Merchant's description.
     *
     * @return merchDescr String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHDESCR</p>
     */
    public String getMerchDescr() {
        return merchDescr;
    }

    /**
     * Sets the Merchant's description.
     *
     * @param merchDescr String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHDESCR</p>
     */
    public void setMerchDescr(String merchDescr) {
        this.merchDescr = merchDescr;
    }

    /**
     * Gets the Merchant's contact information.
     *
     * @return merchSvc String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHSVC</p>
     */
    public String getMerchSvc() {
        return merchSvc;
    }

    /**
     * Sets the Merchant's contact information.
     *
     * @param merchSvc String
     * @paypal.sample <p>Maps to Payflow Parameter: MERCHSVC</p>
     */
    public void setMerchSvc(String merchSvc) {
        this.merchSvc = merchSvc;
    }
}
