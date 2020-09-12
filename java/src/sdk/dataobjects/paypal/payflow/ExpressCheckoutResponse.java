package paypal.payflow;

import paypal.payflow.ECGetResponse;

import java.util.Hashtable;

/**
 * This  class serves as base class of all ExpressCheckout response classes.
 * <p>Each response object is associated with a particular type of expressCheckout operation.</p>
 * <p>Following are the request objects associated with
 * different operations of ExpressCheckout:</p>
 * <p/>
 * {@paypal.listtable}
 * {@paypal.ltr}
 * {@paypal.ltd}ExpressCheckout operation.{@paypal.eltd}
 * {@paypal.ltd}Request data object{@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}SET operation for ExpressCheckout.{@paypal.eltd}
 * {@paypal.ltd}{@link ExpressCheckoutResponse} {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}GET operation for ExpressCheckout.{@paypal.eltd}
 * {@paypal.ltd}{@link ECGetResponse} {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}DO operation for ExpressCheckout.{@paypal.eltd}
 * {@paypal.ltd}{@link ECDoResponse} {@paypal.eltd}
 * {@paypal.eltr}
 */


public class ExpressCheckoutResponse extends BaseResponseDataObject {
    private String token;

    /**
     * Gets the token parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: TOKEN
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

