package paypal.payflow;

/**
 * Used for Check tender related information.
 * CheckPayment the Payment devices associated with this tender type.
 * {@link CheckPayment}
 */
public final class CheckTender extends BaseTender {
    /**
     * This constructor is used to create a CheckTender
     * with CheckPayment as the payment device
     *
     * @param check CheckTender
     * @paypal.sample Maps to Payflow Parameter: TENDER
     * <p/>
     * .............
     * //check is the populated CheckPaymentobject.
     * .............
     * <p/>
     * //Create the Tender object
     * CheckTender tender = new CardTender(check);
     */
    public CheckTender(CheckPayment check) {
        super(PayflowConstants.TENDERTYPE_TELECHECK, check);
    }

}