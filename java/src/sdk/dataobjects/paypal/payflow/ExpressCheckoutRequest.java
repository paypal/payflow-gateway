package paypal.payflow;

/**
 * This  class serves as base class of all ExpressCheckout request classes.
 * <p>Each request object is associated with a particular type of expressChecout operation.</p>
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
 * {@paypal.ltd}{@link ECSetRequest} {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}GET operation for ExpressCheckout.{@paypal.eltd}
 * {@paypal.ltd}{@link ECGetRequest} {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}DO operation for ExpressCheckout.{@paypal.eltd}
 * {@paypal.ltd}{@link ECDoRequest} {@paypal.eltd}
 * {@paypal.eltr}
 */
public class ExpressCheckoutRequest extends BaseRequestDataObject {


    private String token;
    private String countryCode;
    private String postalCode;
    private String action;
    private String doReauthorization;

    /**
     * Gets the token parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: TOKEN
     */
    public String getToken() {
        return token;
    }

    /**
     * Sets the token parameter.
     *
     * @param token - String
     * @paypal.sample <p>Maps to Payflow Parameter: TOKEN
     */
    public void setToken(String token) {
        this.token = token;
    }

    /**
     * Gets the recountryCodeturnurl parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: COUNTRYCODE
     */
    public String getCountryCode() {
        return countryCode;
    }

    /**
     * Sets the countryCode parameter.
     *
     * @param countryCode - String
     * @paypal.sample <p>Maps to Payflow Parameter: COUNTRYCODE
     */
    public void setCountryCode(String countryCode) {
        this.countryCode = countryCode;
    }

    /**
     * Gets the postalCode parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: POSTALCODE
     */
    public String getPostalCode() {
        return postalCode;
    }

    /**
     * Sets the postalCode parameter.
     *
     * @param postalCode - String
     * @paypal.sample <p>Maps to Payflow Parameter: POSTALCODE
     */
    public void setPostalCode(String postalCode) {
        this.postalCode = postalCode;
    }


    /**
     * Gets the doReauthorization parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: DOREAUTHORIZATION
     */
    public String getDoReauthorization() {
        return doReauthorization;
    }

    /**
     * Sets the postalCode parameter.
     *
     * @param doReauthorization - String
     * @paypal.sample <p>Maps to Payflow Parameter: DOREAUTHORIZATION
     */
    public void setDoReauthorization(String doReauthorization) {
        this.doReauthorization = doReauthorization;
    }


    protected ExpressCheckoutRequest(String Action) {
        action = Action;
    }


    protected ExpressCheckoutRequest(String Action, String Token) {
        action = Action;
        token = Token;
    }


    protected void generateRequest() {
        // This function is not called. All the
        //address information is validated and generated
        //in its respective derived classes.
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TOKEN, token));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COUNTRYCODE, countryCode));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_POSTALCODE, postalCode));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ACTION, action));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DOREAUTHORIZATION, doReauthorization));

    }

}
