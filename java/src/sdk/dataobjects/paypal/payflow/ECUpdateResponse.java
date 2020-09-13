package paypal.payflow;

import java.util.Hashtable;

public class ECUpdateResponse extends ExpressCheckoutResponse {

    private String ba_Desc;
    private String ba_Status;


    /**
     * Gets the BA_Desc parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: BA_DESC
     */
    public String getba_Desc() {
        return ba_Desc;
    }

    /**
     * Sets the BA_Desc parameter.
     *
     * @param ba_Desc - String
     *  <p>Maps to Payflow Parameter: BA_DESC
     */

    public void setba_Desc(String ba_Desc) {
        this.ba_Desc = ba_Desc;
    }

    /**
     * Gets the BA_Status parameter.
     *
     * @return - String
     *  <p>Maps to Payflow Parameter: BA_STATUS
     */
    public String getba_Status() {
        return ba_Status;
    }

    /**
     * Sets the BA_Status parameter.
     *
     * @param BA_Status - String
     *  <p>Maps to Payflow Parameter: BA_STATUS
     */

    public void setba_Status(String BA_Status) {
        this.ba_Status = BA_Status;
    }

    protected ECUpdateResponse() {
    }

    protected void setParams(Hashtable ResponseHashTable) {

        ba_Desc = (String) ResponseHashTable.get(PayflowConstants.PARAM_BA_DESC);
        ba_Status = (String) ResponseHashTable.get(PayflowConstants.PARAM_BA_STATUS);

        ResponseHashTable.remove(PayflowConstants.PARAM_BA_DESC);
        ResponseHashTable.remove(PayflowConstants.PARAM_BA_STATUS);
    }


}
