package paypal.payflow;

/**
 * Used for the type of device the card holder is using.
 * .................
 * //inv is the Invoice object.
 * .................
 *
 * //Set the Shipping Address details.
 * ShipTo ship = new ShipTo();
 * ship.setShipToStreet( "123 Main St.");
 * ship.setShipToZip("12345");
 * inv.setShipTo (ship);
 * .................
 */

public final class Devices extends BaseRequestDataObject {
    private String catType;
    private String contactLess;

    /**
     * Gets the type of terminal
     *
     * @return String
     * <p>Maps to Payflow Parameter: CATTYPE</p>
     */
    public String getCatType() {
        return catType;
    }

    /**
     * Sets the type of terminal
     *
     * @param catType String
     * <p>Maps to Payflow Parameter: CATTYPE</p>
     */
    public void setCatType(String catType) {
        this.catType = catType;
    }

    /**
     * Gets the card input capability
     *
     * @return contactLess String
     *  <p>Maps to Payflow Parameter: CONTACTLESS</p>
     */

    public String getContactLess() {
        return contactLess;
    }

    /**
     * Sets the card input capability
     *
     * @param contactLess String
     *  <p>Maps to Payflow Parameter: CONTACTLESS</p>
     */
    public void setContactLess(String contactLess) {
        this.contactLess = contactLess;
    }

    /**
     * Used for the type of device the card holder is using.
     * .................
     * //inv is the Invoice object.
     * .................
     *
     * //Set the Shipping Address details.
     * ShipTo ship = new ShipTo();
     * ship.setShipToStreet( "123 Main St.");
     * ship.setShipToZip("12345");
     * inv.setShipTo (ship);
     * .................
     */

    public Devices() {
    }

    protected void generateRequest() {
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CATTYPE, catType));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CONTACTLESS, contactLess));
    }

}
