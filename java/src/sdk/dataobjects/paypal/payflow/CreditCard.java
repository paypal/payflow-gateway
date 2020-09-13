package paypal.payflow;

/**
 * Used for Credit Card related information
 * CreditCard is associated with CardTender. {@link CardTender}
 */
public final class CreditCard extends PaymentCard {
    /**
     * @param acct    Credit card number
     * @param expDate Card expiry date
     *                This is used as Payment Device for the CardTender.
     *                <p/>
     *  Maps to Payflow Parameter: ACCT , EXPDATE
     * //Create the CreditCard object
     * CreditCard payDevice = new CreditCard("XXXXXXXXXX","XXXX");
     * </p>
     */
    public CreditCard(String acct, String expDate) {
        super(acct, expDate);
    }
}

