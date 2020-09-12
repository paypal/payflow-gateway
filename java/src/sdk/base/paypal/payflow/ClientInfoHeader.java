package paypal.payflow;



/**
 * This class is used to store the complete information
 * about a client information header.
 */
final class ClientInfoHeader extends BaseRequestDataObject {
    /**
     * Stores Header name
     */
    private String headerName;

    /**
     * Stores Header value
     */
    private Object headerValue;

    /**
     * Contructor
     *
     * @param headerName  String
     * @param headerValue Object
     */
    public ClientInfoHeader(String headerName, Object headerValue) {
        this.headerName = headerName;
        this.headerValue = headerValue;
    }

    /**
     * Gets header name
     *
     * @return mHeaderName String
     */
    public String getHeaderName() {
        return this.headerName;
    }

    /**
     * Gets header value
     *
     * @return mHeaderValue Object
     */
    public Object getHeaderValue() {
        return this.headerValue;
    }
}
