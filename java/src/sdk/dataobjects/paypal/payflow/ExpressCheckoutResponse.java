package paypal.payflow;

import paypal.payflow.ECGetResponse;

import java.util.Hashtable;

/**
 * This  class serves as base class of all ExpressCheckout response classes.
 * <p>Each response object is associated with a particular type of expressCheckout operation.</p>
 * <p>Following are the request objects associated with
 * different operations of ExpressCheckout:</p>
 * <p>
 * ExpressCheckout operation. Request data object
 * SET operation for ExpressCheckout {@link ExpressCheckoutResponse}
 * GET operation for ExpressCheckout {@link ECGetResponse}
 * DO operation for ExpressCheckout {@link ECDoResponse}
 */

public class ExpressCheckoutResponse extends BaseResponseDataObject {
    private String token;

    /**
     * Gets the token parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: TOKEN
     */
    public String getToken() {
        return token;
    }

    protected ExpressCheckoutResponse() {
    }

    protected void setParams(Hashtable ResponseHashTable) {
        token = (String) ResponseHashTable.get(PayflowConstants.PARAM_TOKEN);
        ResponseHashTable.remove(PayflowConstants.PARAM_TOKEN);
    }

}

