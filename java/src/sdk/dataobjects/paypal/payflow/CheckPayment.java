package paypal.payflow;

/**
 * Used for Check Payment related information.
 * CheckPayment is associated with CheckTender. {@link CheckTender}
 */
public final class CheckPayment extends PaymentDevice {

    /**
     * Constructor
     *
     * @param micr MICR Value
     *             This is used as Payment Device for the CheckTender.
     *              * <p>
     *  Maps to Payflow Parameter: MICR
     * //Create the CheckPayment object
     * CheckPayment payDevice = new CheckPayment("XXXXXXXXXX");
     * </p>
     */
    public CheckPayment(String micr) {
        super(micr);
    }

    protected void generateRequest() {
//    	Put the base field Acct as MICR.
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MICR, super.getAcct()));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NAME, super.getName()));
    }

}