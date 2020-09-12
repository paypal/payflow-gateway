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

/**
 * UUsed for ExpressCheckout Do operation.
 * {@link ExpressCheckoutResponse}
 * {@link ECGetResponse}
 */
public class ECDoResponse extends ExpressCheckoutResponse {

    private String amt;
    private String settleAmt;
    private String taxAmt;
    private String exchangeRate;
    private String paymentDate;
    private String paymentStatus;
    private String baId;


    /**
     * Gets the Amt parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: AMT
     */
    public String getAmt() {
        return amt;
    }

    /**
     * Gets the settleamt parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SETTLEAMT
     */
    public String getSettleAmt() {
        return settleAmt;
    }

    /**
     * Gets the tax amt parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: TAXAMT
     */
    public String getTaxAmt() {
        return taxAmt;
    }

    /**
     * Gets the exchange rate parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: EXCHANGERATE
     */
    public String getExchangeRate() {
        return exchangeRate;
    }

    /**
     * Gets the payment date  parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTDATE
     */
    public String getPaymentDate() {
        return paymentDate;
    }

    /**
     * Gets the Payment status  parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYMENTSTATUS
     */
    public String getPaymentStatus() {
        return paymentStatus;
    }

    /**
     * Gets the BAID parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BAID
     */
    public String getbaId() {
        return baId;
    }

    protected ECDoResponse() {
    }

    protected void setParams(Hashtable ResponseHashTable) {

        amt = (String) ResponseHashTable.get(PayflowConstants.PARAM_AMT);
        settleAmt = (String) ResponseHashTable.get(PayflowConstants.PARAM_SETTLEAMT);
        taxAmt = (String) ResponseHashTable.get(PayflowConstants.PARAM_TAXAMT);
        exchangeRate = (String) ResponseHashTable.get(PayflowConstants.PARAM_EXCHANGERATE);
        paymentDate = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYMENTDATE);
        paymentStatus = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYMENTSTATUS);
        baId = (String) ResponseHashTable.get(PayflowConstants.PARAM_BAID);

        ResponseHashTable.remove(PayflowConstants.PARAM_AMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_SETTLEAMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_TAXAMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_EXCHANGERATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYMENTDATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYMENTSTATUS);
        ResponseHashTable.remove(PayflowConstants.PARAM_BAID);
    }
}
