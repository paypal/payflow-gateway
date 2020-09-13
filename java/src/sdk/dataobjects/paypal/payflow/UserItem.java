package paypal.payflow;

/**
 * This class holds the USER1 to USER10 related information.
 * <p>You are able to send up to 10 string type parameters that you can use to store temporary data (for example, variables,
 * session IDs, order numbers, and so on). These parameters enable you to echo back the data to your server either
 * via the Payflow API or as part of the Return or Silent Post if using the hosted checkout page.
 *
 * Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in
 * the PayPal transaction database.</p>
 * <p>Following example shows how to use user item.</p>
 *
 *  .................
 * //inv is the Invoice object.
 * .................
 * // Create a user item.
 * UserItem nUser = new UserItem();
 * // Add first item.
 *
 */

public final class UserItem extends BaseRequestDataObject {

    private String userItem1;
    private String userItem2;
    private String userItem3;
    private String userItem4;
    private String userItem5;
    private String userItem6;
    private String userItem7;
    private String userItem8;
    private String userItem9;
    private String userItem10;

    /**
     * Gets USER1
     *
     * @return userItem1
     *  <p>Maps to Payflow Parameter: USER1</p>
     */
    public String getUserItem1() {
        return userItem1;
    }

    /**
     * Sets USER1
     *
     * @param userItem1 Stringffffffffffffff
     *  <p>Maps to Payflow Parameter: USER1</p>
     */
    public void setUserItem1(String userItem1) {
        this.userItem1 = userItem1;
    }

    /**
     * Gets USER2
     *
     * @return userItem2
     *  <p>Maps to Payflow Parameter: USER2</p>
     */
    public String getUserItem2() {
        return userItem2;
    }

    /**
     * Sets USER2
     *
     * @param userItem2 String
     *  <p>Maps to Payflow Parameter: USER2</p>
     */
    public void setUserItem2(String userItem2) {
        this.userItem2 = userItem2;
    }

    /**
     * Gets USER3
     *
     * @return userItem3
     *  <p>Maps to Payflow Parameter: USER3</p>
     */
    public String getUserItem3() {
        return userItem3;
    }

    /**
     * Sets USER3
     *
     * @param userItem3 String
     *  <p>Maps to Payflow Parameter: USER3</p>
     */
    public void setUserItem3(String userItem3) {
        this.userItem3 = userItem3;
    }

    /**
     * Gets USER4
     *
     * @return userItem4
     *  <p>Maps to Payflow Parameter: USER4</p>
     */
    public String getUserItem4() {
        return userItem4;
    }

    /**
     * Sets USER4
     *
     * @param userItem4 String
     *  <p>Maps to Payflow Parameter: USER4</p>
     */
    public void setUserItem4(String userItem4) {
        this.userItem4 = userItem4;
    }

    /**
     * Gets USER5
     *
     * @return userItem5
     *  <p>Maps to Payflow Parameter: USER5</p>
     */
    public String getUserItem5() {
        return userItem5;
    }

    /**
     * Sets USER5
     *
     * @param userItem5 String
     *  <p>Maps to Payflow Parameter: USER5</p>
     */
    public void setUserItem5(String userItem5) {
        this.userItem5 = userItem5;
    }

    /**
     * Gets USER6
     *
     * @return userItem6
     *  <p>Maps to Payflow Parameter: USER6</p>
     */
    public String getUserItem6() {
        return userItem6;
    }

    /**
     * Sets USER6
     *
     * @param userItem6 String
     *  <p>Maps to Payflow Parameter: USER6</p>
     */
    public void setUserItem6(String userItem6) {
        this.userItem6 = userItem6;
    }

    /**
     * Gets USER7
     *
     * @return userItem7
     *  <p>Maps to Payflow Parameter: USER7</p>
     */
    public String getUserItem7() {
        return userItem7;
    }

    /**
     * Sets USER7
     *
     * @param userItem7 String
     *  <p>Maps to Payflow Parameter: USER7</p>
     */
    public void setUserItem7(String userItem7) {
        this.userItem7 = userItem7;
    }

    /**
     * Gets USER88
     *
     * @return userItem8
     *  <p>Maps to Payflow Parameter: USER8</p>
     */
    public String getUserItem8() {
        return userItem8;
    }

    /**
     * Sets USER8
     *
     * @param userItem8 String
     *  <p>Maps to Payflow Parameter: USER8</p>
     */
    public void setUserItem8(String userItem8) {
        this.userItem8 = userItem8;
    }

    /**
     * Gets USER9
     *
     * @return userItem9
     *  <p>Maps to Payflow Parameter: USER9</p>
     */
    public String getUserItem9() {
        return userItem9;
    }

    /**
     * Sets USER9
     *
     * @param userItem9 String
     *  <p>Maps to Payflow Parameter: USER9</p>
     */
    public void setUserItem9(String userItem9) {
       this.userItem9 = userItem9;
    }

    /**
     * Gets USER10
     *
     * @return userItem10
     *  <p>Maps to Payflow Parameter: USER10</p>
     */
    public String getUserItem10() {
        return userItem10;
    }

    /**
     * Sets USER10
     *
     * @param userItem10 String
     *  <p>Maps to Payflow Parameter: USER10</p>
     */
    public void setUserItem10(String userItem10) {
        this.userItem10 = userItem10;
    }

    /**
     * Constructor.
     * <p>Line item data describes the details of the item purchased and can be can be passed
     * for each transaction. The convention for passing line item data in name/value pairs
     * is that each name/value starts with L_ and ends with n where n is the line item number.
     * For example L_QTY0=1 is the quantity for line item 0 and is equal to 1,
     * with n starting at 0</p>
     * <p>Following example shows how to use line item.</p>
     *
     *  .................
     * //inv is the Invoice object.
     * .................
     * // Create a line item.
     * LineItem item = new LineItem();
     * // Add first item.
     * Currency lnamt = new Currency(new Double(8.95), "USD");
     * item.setAmt(lnamt);
     * item.setDesc("Line 1");
     * item.setQty(1);
     * item.setItemNumber("1");
     * // Add line item to invoice.
     * inv.addLineItem(item);
     * // Create a line item.
     * LineItem item1 = new LineItem();
     * // Add second item.
     * Currency lnamt1 = new Currency(new Double(5.25), "USD");
     * item1.setAmt(lnamt);
     * item1.setDesc("Line 2");
     * item1.setQty(2);
     * item1.setItemNumber("2");
     * // Add line item to invoice.
     * inv.addLineItem(item1);
     * ..................
     */
    public UserItem() {
    }
    protected void generateRequest() {
        try {
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER1, userItem1));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER2, userItem2));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER3, userItem3));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER4, userItem4));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER5, userItem5));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER6, userItem6));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER7, userItem7));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER8, userItem8));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER9, userItem9));
            getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER10, userItem10));
        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }
}