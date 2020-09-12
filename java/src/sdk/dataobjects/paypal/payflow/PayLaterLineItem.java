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
 * This class holds the PayPal Pay Later Promotional related information.
 * <p>A promotion code for PayPal Promotional Financing where n is a value from 0 to 9.
 * The first promotion must be specified as L_PROMOCODE0. Combine promotions by
 * using additonal parameters, such as L_PROMOCODE1 and L_PROMOCODE2.</p>
 * <p>Following example shows how to use the Pay Later Promo Code.</p>
 *
 * @paypal.sample .................
 * // setPayLaterLineItem is the PayLaterLineItem object.
 * .................
 * <p/>
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
 * <p/>
 * ..................
 */

public final class PayLaterLineItem extends BaseRequestDataObject {

    private String promoCode;

    /**
     * Gets the Promo Code.
     *
     * @return promoCode
     * @paypal.sample <p>Maps to Payflow Parameter: L_PROMOCODEn</p>
     */
    public String getpromoCode() {
        return promoCode;
    }

    /**
     * Sets the Line item number.
     * <p/>
     * A promotion code for PayPal Promotional Financing.
     *
     * @param promoCode String
     * @paypal.sample <p>Maps to Payflow Parameter: L_PROMOCODEn</p>
     */
    public void setpromoCode(String promoCode) {
        this.promoCode = promoCode;
    }

    /**
     * Constructor.
     * <p>A promotion code for PayPal Promotional Financing where n is a value from 0 to 9.
     * The first promotion must be specified as L_PROMOCODE0. Combine promotions by
     * using additonal parameters, such as L_PROMOCODE1 and L_PROMOCODE2.</p>
     * <p>Following example shows how to use the Pay Later Promo Code.</p>
     *
     * @paypal.sample .................
     * // setPayLaterLineItem is the PayLaterLineItem object.
     * .................
     * <p/>
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
     * <p/>
     * ..................
     */
    public PayLaterLineItem() {
    }

    protected void generateRequest(int Index) {

        try {
            String IndexVal = String.valueOf(Index);
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PROMOCODE + IndexVal, promoCode));
        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }
}