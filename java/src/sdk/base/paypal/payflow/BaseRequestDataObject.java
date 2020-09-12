package paypal.payflow;

/**
 * Abstract base Class of all request data objects.
 * This class can be used to create a new request data
 * object.
 */
abstract class BaseRequestDataObject {
    private StringBuffer mRequestBuffer;
    private Context context;

    protected Context getContext() {
        return context;
    }

    protected void setContext(Context context) {
        this.context = context;
    }

    /**
     * Constructor.
     * Abstract class. Instance cannot be created directly.
     */
    protected BaseRequestDataObject() {
        mRequestBuffer = new StringBuffer();
    }


    /**
     * Gets the Requestbuffer used for creating the actual request string.
     *
     * @return mRequestBuffer StringBuffer
     */
    protected StringBuffer getRequestBuffer() {
        return mRequestBuffer;

    }

    /**
     * sets the StringBuffer to hold the request string.
     *
     * @param value StringBuffer
     */
    protected void setRequestBuffer(StringBuffer value) {
        mRequestBuffer = value;
    }

    protected void generateRequest() {
    }

}


