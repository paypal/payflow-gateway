package paypal.payflow;

/**
 * Summary description for BasicAuthorizationTransaction.
 */
class BasicAuthorizationTransaction extends AuthorizationTransaction {

    /**
     * @param tender                PayPalTender
     * @param invoice               Invoice
     * @param userInfo              UserInfo
     * @param payflowConnectionData PayflowConnectionData
     * @param requestId             String
     */
    public BasicAuthorizationTransaction(PayPalTender tender, Invoice invoice, UserInfo userInfo, PayflowConnectionData payflowConnectionData, String requestId) {
        super("B", userInfo, payflowConnectionData, invoice, tender, requestId);
    }

    /**
     * @param tender    PayPalTender
     * @param invoice   Invoice
     * @param userInfo  UserInfo
     * @param requestId String
     */
    public BasicAuthorizationTransaction(PayPalTender tender, Invoice invoice, UserInfo userInfo, String requestId) {
        super("B", userInfo, invoice, tender, requestId);
    }

}

