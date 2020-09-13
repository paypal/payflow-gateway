package paypal.payflow;

/**
 * Used for shipping address information
 * <p>Shipping address is destination address information.</p>
 * <p>Following example shows how to use BillTo.</p>
 *
 * .................
 * //inv is the Invoice object.
 * .................
 * <p/>
 * //Set the Shipping Address details.
 * ShipTo ship = new ShipTo();
 * ship.setShipToStreet( "123 Main St.");
 * ship.setShipToZip("12345");
 * inv.setShipTo (ship);
 * .................
 */

public final class ShipTo extends Address {
    private String shipMethod;
    private String shipCarrier;
    private String shipFromZip;

    /**
     * Gets the shipping city
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOCITY</p>
     */
    public String getShipToCity() {
        return super.getAddressCity();
    }

    /**
     * Sets the shipping city
     *
     * @param shipToCity String
     *  <p>Maps to Payflow Parameter: SHIPTOCITY</p>
     */
    public void setShipToCity(String shipToCity) {
        super.setAddressCity(shipToCity);
    }

    /**
     * Gets the Shipping Country
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOCOUNTRY</p>
     */
    public String getShipToCountry() {
        return super.getAddressCountry();
    }

    /**
     * Sets the Shipping Country
     *
     * @param shipToCountry String
     *  <p>Maps to Payflow Parameter: SHIPTOCOUNTRY</p>
     */
    public void setShipToCountry(String shipToCountry) {
        super.setAddressCountry(shipToCountry);
    }

    /**
     * Gets the shipping email.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOEMAIL</p>
     */
    public String getShipToEmail() {
        return super.getAddressEmail();
    }

    /**
     * Sets the shipping email.
     *
     * @param shipToEmail String
     *  <p>Maps to Payflow Parameter: SHIPTOEMAIL</p>
     */
    public void setShipToEmail(String shipToEmail) {
        super.setAddressEmail(shipToEmail);
    }

    /**
     * Gets the shipping first name
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOFIRSTNAME</p>
     */
    public String getShipToFirstName() {
        return super.getAddressFirstName();
    }

    /**
     * Sets the shipping first name
     *
     * @param shipToFirstName String
     *  <p>Maps to Payflow Parameter: SHIPTOFIRSTNAME</p>
     */
    public void setShipToFirstName(String shipToFirstName) {
        super.setAddressFirstName(shipToFirstName);
    }

    /**
     * Gets the last name from the shipping address.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOLASTNAME</p>
     */
    public String getShipToLastName() {
        return super.getAddressLastName();
    }

    /**
     * Sets the last name in the shipping address.
     *
     * @param shipToLastName String
     *  <p>Maps to Payflow Parameter: SHIPTOLASTNAME</p>
     */
    public void setShipToLastName(String shipToLastName) {
        super.setAddressLastName(shipToLastName);
    }

    /**
     * Gets the middlename from the shipping address.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOMIDDLENAME</p>
     */
    public String getShipToMiddleName() {
        return super.getAddressMiddleName();
    }

    /**
     * Sets the middlename in the shipping address.
     *
     * @param shipToMiddleName String
     *  <p>Maps to Payflow Parameter: SHIPTOMIDDLENAME</p>
     */
    public void setShipToMiddleName(String shipToMiddleName) {
        super.setAddressMiddleName(shipToMiddleName);
    }

    /**
     * Gets the Phone2 from the shipping address.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOPHONE2</p>
     */
    public String getShipToPhone2() {
        return super.getAddressPhone2();
    }

    /**
     * Sets the Phone2 in the shipping address.
     *
     * @param shipToPhone2 String
     *  <p>Maps to Payflow Parameter: SHIPTOPHONE2</p>
     */
    public void setShipToPhone2(String shipToPhone2) {
        super.setAddressPhone2(shipToPhone2);
    }

    /**
     * Gets the phone number from the shipping address.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOPHONE</p>
     */
    public String getShipToPhone() {
        return super.getAddressPhone();
    }

    /**
     * Sets the phone number in the shipping address.
     *
     * @param shipToPhone String
     *  <p>Maps to Payflow Parameter: SHIPTOPHONE</p>
     */
    public void setShipToPhone(String shipToPhone) {
        super.setAddressPhone(shipToPhone);
    }

    /**
     * Gets the shipping state.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOSTATE</p>
     */
    public String getShipToState() {
        return super.getAddressState();
    }

    /**
     * Sets the shipping state.
     *
     * @param shipToState String
     *  <p>Maps to Payflow Parameter: SHIPTOSTATE</p>
     */
    public void setShipToState(String shipToState) {
        super.setAddressState(shipToState);
    }

    /**
     * Gets the shipping street.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOSTREET</p>
     */
    public String getShipToStreet() {
        return super.getAddressStreet();
    }

    /**
     * Sets the shipping street.
     *
     * @param shipToStreet String
     *  <p>Maps to Payflow Parameter: SHIPTOSTREET</p>
     */
    public void setShipToStreet(String shipToStreet) {
        super.setAddressStreet(shipToStreet);
    }

    /**
     * Gets the shipping street2.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOSTREET2</p>
     */
    public String getShipToStreet2() {
        return super.getAddressStreet2();
    }

    /**
     * Sets the shipping street2.
     *
     * @param shipToStreet2 String
     *  <p>Maps to Payflow Parameter: SHIPTOSTREET2</p>
     */
    public void setShipToStreet2(String shipToStreet2) {
        super.setAddressStreet2(shipToStreet2);
    }

    /**
     * Gets the shipping zip code.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPTOZIP</p>
     */
    public String getShipToZip() {
        return super.getAddressZip();
    }

    /**
     * Sets the shipping zip code.
     *
     * @param shipToZip String
     *  <p>Maps to Payflow Parameter: SHIPTOZIP.</p>
     */
    public void setShipToZip(String shipToZip) {
        super.setAddressZip(shipToZip);
    }

    /**
     * Gets the shipping method.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPMETHOD</p>
     */
    public String getShipMethod() {
        return shipMethod;
    }

    /**
     * Sets the shipping method.
     *
     * @param shipMethod String
     *  <p>Maps to Payflow Parameter: SHIPMETHOD</p>
     */
    public void setShipMethod(String shipMethod) {
        this.shipMethod = shipMethod;
    }

    /**
     * Gets the shipping carrier.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPCARRIER</p>
     */
    public String getShipCarrier() {
        return shipCarrier;
    }

    /**
     * Sets the shipping carrier.
     *
     * @param shipCarrier String
     *  <p>Maps to Payflow Parameter: SHIPCARRIER</p>
     */
    public void setShipCarrier(String shipCarrier) {
        this.shipCarrier = shipCarrier;
    }

    /**
     * Gets the ship from zip.
     * <p>Ship from postal code (called ZIP code in the USA).</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPFROMZIP</p>
     */
    public String getShipFromZip() {
        return shipFromZip;
    }

    /**
     * Sets the ship from zip.
     * <p>Ship from postal code (called ZIP code in the USA).</P>
     *
     * @param shipFromZip String
     *  <p>Maps to Payflow Parameter: SHIPFROMZIP</p>
     */
    public void setShipFromZip(String shipFromZip) {
        this.shipFromZip = shipFromZip;
    }

    /**
     * Constructor
     * <p>Shipping address is destination address information.</p>
     * <p>Following example shows how to use ShipTo.</p>
     *
     *  .................
     * //inv is the Invoice object.
     * .................
     * <p/>
     * //Set the Shipping Address details.
     * ShipTo ship = new ShipTo();
     * ship.setShipToStreet ("685A E. Middlefield Rd.");
     * ship.ShipToZip ("94043");
     * inv.setShipTo( ship);
     * .................
     */
    public ShipTo() {
    }

    /**
     * This method copies the common contents
     * from shipping to billing address.
     *
     * @return BillTo
     *         <p>This method can be used to
     *         populate the shipping addresses directly
     *         from the billing addresses when
     *         both are the same.</p>
     *  ................
     * //ship is the object of
     * //shipTo populated with
     * //the shipping addresses.
     * ................
     * <p/>
     * <p/>
     * BillTo bill;
     * <p/>
     * //Populate billing addresses
     * //from shipping addresses.
     * bill = ship.copy();
     * <p/>
     * ................
     */
    public BillTo copy() {
        BillTo copyObject = new BillTo();
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
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOSTREET, this.getShipToStreet()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOSTREET2, this.getShipToStreet2()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOCITY, this.getShipToCity()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOSTATE, this.getShipToState()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOCOUNTRY, this.getShipToCountry()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOZIP, this.getShipToZip()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOPHONE, this.getShipToPhone()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOPHONE2, this.getShipToPhone2()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOEMAIL, this.getShipToEmail()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOFIRSTNAME, this.getShipToFirstName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOMIDDLENAME, this.getShipToMiddleName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPTOLASTNAME, this.getShipToLastName()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPCARRIER, shipCarrier));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPMETHOD, shipMethod));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPFROMZIP, shipFromZip));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPPEDFROMZIP, shipFromZip));
    }

}
