package paypal.payflow;

/**
 * Interface for all response data objects.
 * <p/>
 * This interface can be used to create a new response data object.
 * </p>
 */

public interface IResponseDataObject {

    /**
     * Sets response params.
     * <p/>
     * When implemented in the derived class, this method should be preferred to be made as an protected method.
     * </p>
     */
    void SetParams();


}
