package paypal.payflow;

/**
 * This abstract class serves as base class of all the payment devices.
 * Each Payment Device is associated with a tender type.
 * Following are the Payment Devices associated with different tender types:
 *
 * Payment Device Data Tender Type
 *
 * BankAcct {@link ACHTender}
 * CreditCard, PurchaseCard, SwipeCard {@link CardTender}
 * CheckPayment {@link CheckTender}
 *
 */
abstract class PaymentDevice extends BaseRequestDataObject {

    /**
     * Payment Device number
     */
    private String acct;

    /**
     * Payment Device Holder's name
     */
    private String name;

    /**
     * MagTek Information.
     */
    private String magtek;

    protected PaymentDevice() {
    }

    /**
     * This constructor takes in Payment device Number.
     *
     * @param acct String
     */
    public PaymentDevice(String acct) {
        this.acct = acct;
    }

    /**
     * This constructor takes in Payment device Number and Payment device holder's name.
     *
     * @param acct String
     * @param name String
     */
    public PaymentDevice(String acct, String name) {
        this.acct = acct;
        this.name = name;
    }

    /**
     * gets the Account holder's account number.
     *
     * @return String
     *
     * Maps to Payflow Parameters as follows:
     *
     * ACCT - Transactions with CreditCard, PurchaseCard, BankAcct payment devices
     * MICR - Transactions with CheckPayment
     * SWIPE - Transactions with SwipeCard
     *
     */
    public String getAcct() {
        return acct;
    }

    /**
     * gets the account holder's name.
     *
     * @return String
     *          * <p>
     * Maps to Payflow Parameters as follows: NAME
     * </p>
     */

    public String getName() {
        return name;
    }

    /**
     * gets the account holder's name.
     *
     * @param name  * <p>
     * Maps to Payflow Parameters as follows: NAME
     * </p>
     */
    public void setName(String name) {
        this.name = name;
    }

    public String getMagTek(MagTekInfo mT) {
        return magtek;
    }

    /**
     * gets the MagTek Encrypted Swipe Data.
     *
     * @param magtek Magtek Encrypted Swipe Data
     *
     */
    public void setMagtek(String magtek) {
        this.magtek = magtek;
    }



    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ACCT, acct));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NAME, name));
    }

}

