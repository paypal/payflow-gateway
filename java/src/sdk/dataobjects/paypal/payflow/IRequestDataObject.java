package paypal.payflow;

/**
 * Interface for all request data objects.
 * <p/>
 * This interface can be used to create a new request data object.
 * </p>
 */

public interface IRequestDataObject {

    /**
     * /// Generates the transaction request.
     * /// <p>When implemented in the derived class, this method
     * /// should be preferred to be made as an internal method.</p>
     */
    void generateRequest();

}

