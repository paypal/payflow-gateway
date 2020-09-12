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
 * Used for Billing Address information
 * <p>Billing address is Cardholder's address information.</p>
 * <p>Following example shows how to use BillTo.</p>
 *
 * @paypal.sample .................
 * // inv is the Invoice object.
 * .................
 * <p/>
 * // Set the Billing Address details.
 * BillTo bill = new BillTo();
 * bill.setBillToStreet( "123 Main St.");
 * bill.setBillToZip("12345");
 * inv.setBillTo (bill);
 * .................
 */

public final class BillTo extends Address {

    private String billToHomePhone;
    private String billToCompanyName;

    /**
     * Constructor.
     * <p>Billing address is Cardholder's address information.</p>
     */
    public BillTo() {
    }

    /**
     * Gets the Billing Street.
     * <p>Cardholder's billing street address
     * (used for AVS and reporting).</P>
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTREET</p>
     */
    public String getBillToStreet() {
        return super.getAddressStreet();
    }

    /**
     * Sets the Billing Street.
     * <p>Cardholder's billing street address
     * (used for AVS and reporting).</P>
     *
     * @param billToStreet String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTREET</p>
     */
    public void setBillToStreet(String billToStreet) {
        super.setAddressStreet(billToStreet);
    }

    /**
     * Gets the Billing Street2.
     * <p>Cardholder's billing 2nd line street address.</P>
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTREET2</p>
     */
    public String getBillToStreet2() {
        return super.getAddressStreet2();
    }

    /**
     * Sets the Billing Street.
     * <p>Cardholder's billing 2nd line street address.</P>
     *
     * @param billToStreet2 String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTREET2</p>
     */
    public void setBillToStreet2(String billToStreet2) {
        super.setAddressStreet2(billToStreet2);
    }

    /**
     * Gets the city
     * <p>Cardholder's billing city.</P>
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOCITY</p>
     */
    public String getBillToCity() {
        return super.getAddressCity();
    }

    /**
     * Sets the city
     * <p>Cardholder's billing city.</P>
     *
     * @param billToCity String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOCITY</p>
     */
    public void setBillToCity(String billToCity) {
        super.setAddressCity(billToCity);
    }

    /**
     * Gets the State
     * <p>Cardholder's billing state code.</P>
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTATE</p>
     */
    public String getBillToState() {
        return super.getAddressState();
    }

    /**
     * Sets the State
     * <p>Cardholder's billing state code./P>
     *
     * @param billToState String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOSTATE</p>
     */
    public void setBillToState(String billToState) {
        super.setAddressState(billToState);
    }

    /**
     * Gets the Billing Zip.
     * <p>Account holder's 5- to 9-digit postal code
     * (called ZIP code in the USA).
     * Do not use spaces, dashes,
     * or non-numeric characters.
     * The postal code is verified by the
     * AVS service.</P>
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOZIP</p>
     */
    public String getBillToZip() {
        return super.getAddressZip();
    }

    /**
     * Sets the Billing Zip.
     * <p>UAccount holder's 5- to 9-digit postal code
     * (called ZIP code in the USA).
     * Do not use spaces, dashes,
     * or non-numeric characters.
     * The postal code is verified by the
     * AVS service.</P>
     *
     * @param billToZip String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOZIP</p>
     */
    public void setBillToZip(String billToZip) {
        super.setAddressZip(billToZip);
    }

    /**
     * Gets the first name.
     * <p>Cardholder's first name.</P>
     *
     * @return firstName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOFIRSTNAME</p>
     */
    public String getBillToFirstName() {
        return super.getAddressFirstName();
    }

    /**
     * Sets the first name.
     * <p>Cardholder's first name.</P>
     *
     * @param billToFirstName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOFIRSTNAME</p>
     */
    public void setBillToFirstName(String billToFirstName) {
        super.setAddressFirstName(billToFirstName);
    }

    /**
     * Gets the middle name.
     * <p>Cardholder's middle name.</P>
     *
     * @return billToMiddleName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOMIDDLENAME</p>
     */
    public String getBillToMiddleName() {
        return super.getAddressMiddleName();
    }

    /**
     * Sets the middle name.
     * <p>Cardholder's middle name.</P>
     *
     * @param billToMiddleName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOMIDDLENAME</p>
     */
    public void setBillToMiddleName(String billToMiddleName) {
        super.setAddressMiddleName(billToMiddleName);
    }

    /**
     * Gets the last name.
     * <p>Cardholder's last name.</P>
     *
     * @return BillToLastName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOLASTNAME</p>
     */
    public String getBillToLastName() {
        return super.getAddressLastName();
    }

    /**
     * Sets the last name.
     * <p>Cardholder's last name.</P>
     *
     * @param billToLastName String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOLASTNAME</p>
     */
    public void setBillToLastName(String billToLastName) {
        super.setAddressLastName(billToLastName);
    }

    /**
     * Gets the billing phone number.
     * <p>Cardholder's telephone number.</P>
     *
     * @return billToPhone String
     * @paypal.sample <p>Maps to Payflow Parameter: PHONENUM</p>
     */
    public String getBillToPhone() {
        return super.getAddressPhone();
    }

    /**
     * Sets the billing phone number.
     * <p>Cardholder's telephone number.</P>
     *
     * @param billToPhone String
     * @paypal.sample <p>Maps to Payflow Parameter: PHONENUM</p>
     */
    public void setBillToPhone(String billToPhone) {
        super.setAddressPhone(billToPhone);
    }

    /**
     * Gets the Billing Phone2.
     * <p>Cardholder's 2nd telephone number.</P>
     *
     * @return billToPhone2 String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOPHONE2</p>
     */
    public String getBillToPhone2() {
        return super.getAddressPhone2();
    }

    /**
     * Sets the Billing Phone2.
     * <p>Cardholder's 2nd telephone number./P>
     *
     * @param billToPhone2 String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOPHONE2</p>
     */
    public void setBillToPhone2(String billToPhone2) {
        super.setAddressPhone2(billToPhone2);
    }

    /**
     * Gets the Billing Fax
     * <p>Cardholder's fax address.</P>
     *
     * @return fax String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOFAX</p>
     */
    public String getBillToFax() {
        return super.getAddressFax();
    }

    /**
     * Sets the Billing Fax
     * <p>Cardholder's fax address.</P>
     *
     * @param billToFax String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOFAX</p>
     */
    public void setBillToFax(String billToFax) {
        super.setAddressFax(billToFax);
    }

    /**
     * Gets the Billing Email.
     * <p>Cardholder's e-mail address</P>
     *
     * @return email String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOEMAIL</p>
     */
    public String getBillToEmail() {
        return super.getAddressEmail();
    }

    /**
     * Sets the Billing Email.
     * <p>Cardholder's e-mail address</P>
     *
     * @param billToEmail String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOEMAIL</p>
     */
    public void setBillToEmail(String billToEmail) {
        super.setAddressEmail(billToEmail);
    }

    /**
     * Gets the Billing Country.
     * <p>Cardholder's billing country code</P>
     *
     * @return billToCountry String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOCOUNTRY</p>
     */
    public String getBillToCountry() {
        return super.getAddressCountry();
    }

    /**
     * Sets the Billing Country.
     * <p>Cardholder's billing country code</P>
     *
     * @param billToCountry String
     * @paypal.sample <p>Maps to Payflow Parameter: BILLTOCOUNTRY</p>
     */
    public void setBillToCountry(String billToCountry) {
        super.setAddressCountry(billToCountry);
    }

    /**
     * Gets the Billing HomePhone.
     * <p>Cardholder's home telephone number.</P>
     *
     * @return homePhone String
     * @paypal.sample <p>Maps to Payflow Parameter: HOMEPHONE</p>
     */
    public String getBillToHomePhone() {
        return billToHomePhone;
    }

    /**
     * Sets the Billing HomePhone.
     * <p>Cardholder's home telephone number.</P>
     *
     * @param billToHomePhone String
     * @paypal.sample <p>Maps to Payflow Parameter: HOMEPHONE</p>
     */
    public void setBillToHomePhone(String billToHomePhone) {
        this.billToHomePhone = billToHomePhone;
    }

    /**
     * Gets the Company Name.
     *
     * @return String
     * @paypal.sample <p>Maps to Payflow Parameter: COMPANYNAME</p>
     */

    public String getBillToCompanyName() {
        return billToCompanyName;
    }

    /**
     * Sets the Company Name.
     *
     * @param billToCompanyName String
     * @paypal.sample <p>Maps to Payflow Parameter: COMPANYNAME</p>
     */
    public void setBillToCompanyName(String billToCompanyName) {
        this.billToCompanyName = billToCompanyName;
    }


    /**
     * This method copies the common contents
     * from billing to shipping address.
     * <p>This method can be used to
     * populate the shipping addresses directly
     * from the billing addresses when
     * both are the same.</p>
     *
     * @return shipTo ShipTo
     * @paypal.sample ................
     * //bill is the object of
     * //billTo populated with
     * //the billing addresses.
     * ................
     * <p/>
     * <p/>
     * ShipTo ship;
     * <p/>
     * //Populate shipping addresses
     * //from billing addresses.
     * ship = bill.copy();
     * <p/>
     * ................
     */

    public ShipTo copy() {
        ShipTo copyObject = new ShipTo();
        copyObject.setAddressCity(this.getAddressCity());
        copyObject.setAddressCountry(this.getAddressCountry());
        copyObject.setAddressEmail(this.getAddressEmail());
        copyObject.setAddressFax(this.getAddressFax());
        copyObject.setAddressFirstName(this.getAddressFirstName());
        copyObject.setAddressLastName(this.getAddressLastName());
        copyObject.setAddressMiddleName(this.getAddressMiddleName());
        copyObject.setAddressPhone2(this.getAddressPhone2());
        copyObject.setAddressPhone(this.getAddressPhone());
        copyObject.setAddressState(this.getAddressState());
        copyObject.setAddressStreet(this.getAddressStreet());
        copyObject.setAddressStreet2(this.getAddressStreet2());
        copyObject.setAddressZip(this.getAddressZip());
        return copyObject;
    }

    protected void generateRequest() {
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_STREET, this.getBillToStreet()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_STREET2, this.getBillToStreet2()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CITY, this.getBillToCity()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_STATE, this.getBillToState()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BILLTOCOUNTRY, this.getBillToCountry()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ZIP, this.getBillToZip()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PHONENUM, this.getBillToPhone()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_BILLTOPHONE2, this.getBillToPhone2()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_EMAIL, this.getBillToEmail()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_FAX, this.getBillToFax()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_FIRSTNAME, this.getBillToFirstName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MIDDLENAME, this.getBillToMiddleName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_LASTNAME, this.getBillToLastName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_HOMEPHONE, billToHomePhone));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COMPANYNAME, billToCompanyName));
    }
}
