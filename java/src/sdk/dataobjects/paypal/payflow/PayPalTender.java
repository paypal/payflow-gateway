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
 * Used for PayPal tender related information.
 * This tender takes in ExpressCheckoutRequest {@link ExpressCheckoutRequest}
 * or a CreditCard {@link CreditCard} depending on the type of transaction.
 * This can be used for ExpressCheckout as well as Direct payments.
 */
public class PayPalTender extends BaseTender {

    private ExpressCheckoutRequest ecRequest = null;

    /**
     * This constructor is used to create a PayPalTender
     * with CreditCard as the payment device
     *
     * @param creditCard CreditCard
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //creditCard is the populated CreditCard object.
     * .............
     * <p/>
     * //Create the Tender object
     * PayPalTender tender = new PayPalTender(creditCard);
     */
    public PayPalTender(CreditCard creditCard) {
        super(PayflowConstants.TENDERTYPE_PAYPAL, creditCard);
    }

    /**
     * This constructor is used to create a PayPalTender
     * with ExpressCheckoutRequest.This is used for a ExpressCheckout transaction.
     *
     * @param ecReq ExpressCheckoutRequest
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //ecReq is the populated ExpressCheckoutRequest object.
     * .............
     * <p/>
     * //Create the Tender object
     * PayPalTender tender = new PayPalTender(ecReq);
     */
    public PayPalTender(ExpressCheckoutRequest ecReq) {
        super(PayflowConstants.TENDERTYPE_PAYPAL, null);
        ecRequest = ecReq;
    }

    protected void generateRequest() {
        super.generateRequest();
        if (ecRequest != null) {
            ecRequest.setRequestBuffer(this.getRequestBuffer());
            ecRequest.generateRequest();
        }
    }

}

