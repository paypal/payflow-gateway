package paypal.payflow;

/**
 * This abstract class serves as base class for
 * Buyer auth transactions.
 */
public class BuyerAuthTransaction extends BaseTransaction {

    /**
     * @param trxType               Transaction type
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param requestId             String
     */
    protected BuyerAuthTransaction(String trxType, UserInfo userInfo, PayflowConnectionData payflowConnectionData, String requestId) {
        super(trxType, userInfo, payflowConnectionData, requestId);
    }

    /**
     * @param trxType   Transaction type
     * @param userInfo  User Info object populated with user credentials.
     * @param requestId String
     */
    protected BuyerAuthTransaction(String trxType, UserInfo userInfo, String requestId) {
        this(trxType, userInfo, null, requestId);
    }
}

