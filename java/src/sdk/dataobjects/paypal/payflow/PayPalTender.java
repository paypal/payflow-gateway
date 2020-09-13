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
     *  Maps to Payflow Parameter: TENDER
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
     *  Maps to Payflow Parameter: TENDER
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

