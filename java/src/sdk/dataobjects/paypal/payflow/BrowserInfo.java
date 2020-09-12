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

public final class BrowserInfo extends BaseRequestDataObject {

    private String browserTime;

    private String browserCountryCode;

    private String browserUserAgent;

    private String custom;

    private String buttonSource;

    private String notifyURL;

    private String merchantSessionId;

    /**
     * Used for Browser related information.
     * <p>Use the BrowserInfo object for the user
     * browser related information.</p>
     *
     * @paypal.sample <p>Following example shows how to use a
     * Browser Info object.</p>
     * .................
     * // inv is the Invoice object
     * .................
     * // Set the Browser Info details.
     * BrowserInfo browser = New BrowserInfo();
     * browser.setBrowserCountryCode ("USA");
     * browser.setBrowserUserAgent ("IE 6.0");
     * inv.setBrowserInfo (browser);
     * .................
     */
    public BrowserInfo() {
    }


    protected void generateRequest() {
        try {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BROWSERTIME, browserTime));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BROWSERCOUNTRYCODE, browserCountryCode));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BROWSERUSERAGENT, browserUserAgent));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BUTTONSOURCE, buttonSource));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTOM, custom));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NOTIFYURL, notifyURL));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MERCHANTSESSIONID, merchantSessionId));
        } catch (Exception ex) {
            ErrorObject error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, ex, PayflowConstants.SEVERITY_FATAL, false, null);
            getContext().addError(error);
        }
    }

    /**
     * Gets the browser's country code.
     *
     * @return browserCountryCode String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERCOUNTRYCODE</p>
     */
    public String getBrowserCountryCode() {
        return browserCountryCode;
    }

    /**
     * Sets the browser's country code.
     *
     * @param browserCountryCode String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERCOUNTRYCODE</p>
     */
    public void setBrowserCountryCode(String browserCountryCode) {
        this.browserCountryCode = browserCountryCode;
    }

    /**
     * Gets the browser time.
     * <p>Browser's local time.</P>
     *
     * @return browserTime String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERTIME</p>
     */
    public String getBrowserTime() {
        return browserTime;
    }

    /**
     * Sets the browser time.
     * <p>Browser's local time.</P>
     *
     * @param browserTime String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERTIME</p>
     */
    public void setBrowserTime(String browserTime) {
        this.browserTime = browserTime;
    }

    /**
     * Gets the browser user agent.
     *
     * @return browserUserAgent String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERUSERAGENT</p>
     */
    public String getBrowserUserAgent() {
        return browserUserAgent;
    }

    /**
     * Sets the browser user agent.
     *
     * @param browserUserAgent String
     * @paypal.sample <p>Maps to Payflow Parameter: BROWSERUSERAGENT</p>
     */
    public void setBrowserUserAgent(String browserUserAgent) {
        this.browserUserAgent = browserUserAgent;
    }

    /**
     * Gets the ButtonSource for Direct Payment and Express checkout.
     *
     * @return buttonSource String
     *         <p>Maps to Payflow Parameter : BUTTONSOURCE</p>
     */
    public String getButtonSource() {
        return buttonSource;
    }

    /**
     * Sets the ButtonSource for Direct Payment and Express Checkout.
     *
     * @param buttonSource String
     *                     <p>Maps to Payflow Parameter : BUTTONSOURCE</p>
     */
    public void setButtonSource(String buttonSource) {
        this.buttonSource = buttonSource;
    }

    /**
     * Gets Custom for Direct Payment and Express Checkout.
     *
     * @return custom String
     *         <p>Maps to Payflow Parameter : CUSTOM</p>
     */
    public String getCustom() {
        return custom;
    }

    /**
     * Sets Custom for Direct Payment and Express Checkout.
     *
     * @param custom String
     *               <p>Maps to Payflow Parameter : CUSTOM</p>
     */
    public void setCustom(String custom) {
        this.custom = custom;
    }

    /**
     * Gets the merchantSessionId for Direct Payment and Express Checkout.
     *
     * @return merchantSessionId String
     *         <p>Maps to Payflow Parameter : MERCHANTSESSIONID</p>
     */
    public String getMerchantSessionId() {
        return merchantSessionId;
    }

    /**
     * Sets the merchantSessionId for Direct Payment and Express Checkout.
     *
     * @param merchantSessionId String
     *                          <p>Maps to Payflow Parameter : MERCHANTSESSIONID</p>
     */
    public void setMerchantSessionId(String merchantSessionId) {
        this.merchantSessionId = merchantSessionId;
    }

    /**
     * Gets the notifyURL String for Direct Payments and Express Checkout.
     *
     * @return notifyURL String
     *         <p>Maps to Payflow Parameter : NOTIFYURL</p>
     */
    public String getNotifyURL() {
        return notifyURL;
    }

    /**
     * Sets the notifyURL for DirectP ayments and Express Checkout.
     *
     * @param notifyURL String
     *                  <p>Maps to Payflow Parameter : NOTIFYURL</p>
     */
    public void setNotifyURL(String notifyURL) {
        this.notifyURL = notifyURL;
    }

}
