package paypal.payflow;

/**
 * /// Used for Extended param information
 * /// <p>Extended data are the Payflow parameters which are
 * /// not mapped through the data objects.
 * /// This class can be used to send such extended parameter information
 * /// in the transaction request.</p>
 * /// @paypal.sample
 * /// Following example shows how to use this class.
 * ///		.............
 * ///		// trans is the transaction object.
 * ///		.............
 * ///
 * ///		// Set the extended data value.
 * ///		ExtendData extData = new ExtendData("PAYFLOW_PARAM_NAME","Param Value");
 * ///
 * ///		// Add extended data to transaction.
 * ///		trans.setExtData(extData);
 */
public final class ExtendData extends BaseRequestDataObject {
    private String paramName;
    private String paramValue;

    /**
     * Constructor
     *
     * @param paramName  String
     * @param paramValue String
     */
    public ExtendData(String paramName, String paramValue) {
        this.paramName = paramName;
        this.paramValue = paramValue;
    }

    protected void generateRequest() {
        this.getRequestBuffer().append(PayflowUtility.appendToRequest(paramName, paramValue));
    }
}
