/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

package paypal.payflow;

import java.util.Hashtable;

public class ECUpdateResponse extends ExpressCheckoutResponse {

    private String ba_Desc;
    private String ba_Status;


    /**
     * Gets the BA_Desc parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_DESC
     */
    public String getba_Desc() {
        return ba_Desc;
    }

    /**
     * Sets the BA_Desc parameter.
     *
     * @param ba_Desc - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_DESC
     */

    public void setba_Desc(String ba_Desc) {
        this.ba_Desc = ba_Desc;
    }

    /**
     * Gets the BA_Status parameter.
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_STATUS
     */
    public String getba_Status() {
        return ba_Status;
    }

    /**
     * Sets the BA_Status parameter.
     *
     * @param BA_Status - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_STATUS
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
