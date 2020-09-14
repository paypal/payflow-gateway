package paypal.payflow;

import java.util.ArrayList;

/**
 * PayPal Pay Later is a new, convenient, and secure service that allows you to offer your
 * customers promotional financing. Buyers that choose the promotional offer can defer
 * payments for purchases on participating merchant web sites, allowing them to shop now and
 * pay later.
 *  * <p>
 * The PayPal Pay Later service allows online merchants to offer promotional financing to
 * buyers at checkout - even if a buyer doesn't have a PayPal account. Promotional offers, such as
 * no payments for 90 days, give merchants new and powerful ways to market to online
 * shoppers.
 *
 *  <p>
 * .................
 * // Following example shows how to use Pay Later.
 * PayLater setPayLater = new PayLater();
 * setPayLater.setshippingMethod("UPSGround");
 * setPayLater.setproductCategory("E"); // Camera and Photos
 * setPayLater.setpromoCodeOverride("1");
 * setPayLater.setpaypalCheckoutBtnType("P");
 * // You can combine up to 10 promotions for PayPal Promotional Financing.
 * // L_PROMOCODE0
 * PayLaterLineItem setPayLaterLineItem = new PayLaterLineItem();
 * setPayLaterLineItem.setpromoCode("101");
 * setPayLater.PayLaterAddLineItem(setPayLaterLineItem);
 * // L_PROMOCODE1
 * PayLaterLineItem setPayLaterLineItem1 = new PayLaterLineItem();
 * setPayLaterLineItem1.setpromoCode("102");
 * setPayLater.PayLaterAddLineItem(setPayLaterLineItem1);
 * .................
 */
public class PayLater extends BaseRequestDataObject {

    private String productCategory;
    private String shippingMethod;
    private String paypalCheckoutBtnType;
    private String profileAddressChangeDate;
    private String promoCodeOverride;
    private ArrayList itemList;

    /**
     * Constructor. This is a default constructor which does not take any parameters.
     * *
     */
    public PayLater() {
        itemList = new ArrayList();
    }

    /**
     * Adds a promo code to promo code list.
     *
     * @param item PayLaterLineItem object
     *             <p>Use this method to add a promo code to the request.  A promotion code for
     *             PayPal Promotional Financing where n is a value from 0 to 9. The first promotion
     *             must be specified as L_PROMOCODE0.
     *             Combine promotions by using additonal parameters, such as L_PROMOCODE1 and L_PROMOCODE2</p>
     *  <p>
     * .................
     * // setPayLaterLineItem is the PayLaterLineItem object.
     * .................
     * // Create new Promo Code or Codes.  You can combine up to 10 promotions.
     * // First promo code, L_PROMOCODE0
     * PayLaterLineItem setPayLaterLineItem = new PayLaterLineItem();
     * setPayLaterLineItem.setpromoCode("101");
     * setPayLater.PayLaterAddLineItem(setPayLaterLineItem);
     * // Additional promo code (if needed), L_PROMOCODE1.  All addtional codes created in
     * // this manner.
     * PayLaterLineItem setPayLaterLineItem1 = new PayLaterLineItem();
     * setPayLaterLineItem1.setpromoCode("102");
     * setPayLater.PayLaterAddLineItem(setPayLaterLineItem1);
     * .................
     */

    public void PayLaterAddLineItem(PayLaterLineItem item) {
        itemList.add(item);
    }

    /**
     * Removes a line item from line item list.
     *
     * @param index Index of promo code to be removed.
     *              <p>Use this method to remove a promo code at a particular index in the requestr.</P>
     *  <p>
     * .................
     * // setPayLater is the PayLater object
     * .................
     * // Remove promo code at index 0
     * setPayLater.PayLaterRemoveLineItem(0);
     * .................
     */
    public void PayLaterRemoveLineItem(int index) {
        itemList.remove(index);
    }

    /**
     * Clears the promo code  list.
     * <p>Use this method to clear all the
     * promo codes added to the request.</p>
     *
     *  <p>
     * .................
     * // setPayLater is the PayLater object
     * .................
     * // Remove all promo codes.
     * setPayLater.PayLaterRemoveAllLineItems();
     * .................
     */
    public void PayLaterRemoveAllLineItems() {
        itemList.clear();
    }

    /**
     *
     *
     */
    private void generateItemRequest() {
        for (int index = 0; index < itemList.size(); index++) {
            PayLaterLineItem item = (PayLaterLineItem) itemList.get(index);
            if (item != null) {
                item.setContext(getContext());
                item.setRequestBuffer(super.getRequestBuffer());
                item.generateRequest(index);
            }
        }
    }


    protected void generateRequest() {
        try {
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPPINGMETHOD, shippingMethod));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PROMOCODEOVERRIDE, promoCodeOverride));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PROFILEADDRESSCHANGEDATE, profileAddressChangeDate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAYPALCHECKOUTBTNTYPE, paypalCheckoutBtnType));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PRODUCTCATEGORY, productCategory));
            if (itemList != null && itemList.size() > 0) {
                generateItemRequest();
            }
        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() == null) {
                getContext().addError(err);
            }
        }
    }

    /**
     * Gets the shippingMethod
     * <p>Use this to get the Shipping method
     * for this transaction.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: SHIPPINGMETHOD</p>
     */
    public String getshippingMethod() {
        return shippingMethod;
    }

    /**
     * Sets the shippingMethod
     * <p>Use this method to set the Shipping method
     * for this transaction.</P>
     *
     * @param shippingMethod String
     *  <p>Maps to Payflow Parameter: SHIPPINGMETHOD</p>
     */
    public void setshippingMethod(String shippingMethod) {
        this.shippingMethod = shippingMethod;
    }

    /**
     * Gets Promo Code Override
     * <p>Value is 0 or 1. Default value is 0.
     * Set to 1 to override promotions from
     * Set Express Checkout request.
     * Otherwise, promotions will not be
     * overridden.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: PROMOCODEOVERRIDE</p>
     */
    public String getpromoCodeOverride() {
        return promoCodeOverride;
    }

    /**
     * Sets Promo Code Override
     * <p>Value is 0 or 1. Default value is 0.
     * Set to 1 to override promotions from
     * Set Express Checkout request.
     * Otherwise, promotions will not be
     * overridden.</P>
     *
     * @param promoCodeOverride String
     *  <p>Maps to Payflow Parameter: PROMOCODEOVERRIDE</p>
     */
    public void setpromoCodeOverride(String promoCodeOverride) {
        this.promoCodeOverride = promoCodeOverride;
    }

    /**
     * Gets Profile Address Change Date
     * <p>The last date that the billing address
     * stored in the customer's profile with
     * the merchant was changed. The date
     * must be in UTC/GMT format. For
     * example, 2007-12-15T17:23:15Z.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: PROFILEADDRESSCHANGEDATE</p>
     */
    public String getprofileAddressChangeDate() {
        return profileAddressChangeDate;
    }

    /**
     * Sets Profile Address Change Date
     * <p>The last date that the billing address
     * stored in the customer's profile with
     * the merchant was changed. The date
     * must be in UTC/GMT format. For
     * example, 2007-12-15T17:23:15Z.</P>
     *
     * @param profileAddressChangeDate String
     *  <p>Maps to Payflow Parameter: PROFILEADDRESSCHANGEDATE</p>
     */
    public void setprofileAddressChangeDate(String profileAddressChangeDate) {
        this.profileAddressChangeDate = profileAddressChangeDate;
    }

    /**
     * Gets the PayPal Checkout Button Type
     * <p>Only for the No payment 90 days
     * button, you must set this variable to P,
     * which allows PayPal to make 90 days
     * no payments the default payment
     * option in the PayPal checkout flow.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: PAYPALCHECKOUTBTNTYPE</p>
     */
    public String getpaypalCheckoutBtnType() {
        return paypalCheckoutBtnType;
    }

    /**
     * Sets the PayPal Checkout Button Type
     * <p>Only for the No payment 90 days
     * button, you must set this variable to P,
     * which allows PayPal to make 90 days
     * no payments the default payment
     * option in the PayPal checkout flow.</P>
     *
     * @param paypalCheckoutBtnType String
     *  <p>Maps to Payflow Parameter: PAYPALCHECKOUTBTNTYPE</p>
     */
    public void setpaypalCheckoutBtnType(String paypalCheckoutBtnType) {
        this.paypalCheckoutBtnType = paypalCheckoutBtnType;
    }

    /**
     * Gets the Product Category.
     * <p>The product category for this order. If
     * the customer's cart contains more
     * than one item, use the product
     * category for the most expensive item.</P>
     *
     * @return String
     *  <p>Maps to Payflow Parameter: PRODUCTCATEGORY</p>
     */
    public String getproductCategory() {
        return productCategory;
    }

    /**
     * Sets the Product Category.
     * <p>The product category for this order. If
     * the customer's cart contains more
     * than one item, use the product
     * category for the most expensive item.</P>
     *
     * @param productCategory String
     *  <p>Maps to Payflow Parameter: PRODUCTCATEGORY</p>
     */
    public void setproductCategory(String productCategory) {
        this.productCategory = productCategory;
    }


}
