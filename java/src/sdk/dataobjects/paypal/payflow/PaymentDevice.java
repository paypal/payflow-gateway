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

/**
 * This abstract class serves as base class of all the payment devices.
 * Each Payment Device is associated with a tender type.
 * Following are the Payment Devices associated with different tender types:
 * {@paypal.listtable}
 * {@paypal.ltr}
 * {@paypal.lth}Payment Device Data {@paypal.elth}
 * {@paypal.lth}Tender Type {@paypal.elth}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}BankAcct {@paypal.eltd}
 * {@paypal.ltd}{@link ACHTender}{@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd} CreditCard ,PurchaseCard ,SwipeCard{@paypal.eltd}
 * {@paypal.ltd}
 * {@link CardTender}
 * {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd} CheckPayment {@paypal.eltd}
 * {@paypal.ltd} {@link CheckTender}{@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.endlisttable}
 */
abstract class PaymentDevice extends BaseRequestDataObject {

    /**
     * Payment Device number
     */
    private String acct;

    /**
     * Payment Device Holder's name
     */
    private String name;

    protected PaymentDevice() {
    }

    /**
     * This constructor takes in Payment device Number.
     *
     * @param acct String
     */
    public PaymentDevice(String acct) {
        this.acct = acct;
    }

    /**
     * This constructor takes in Payment device Number and Payment device holder's name.
     *
     * @param acct String
     * @param name String
     */
    public PaymentDevice(String acct, String name) {
        this.acct = acct;
        this.name = name;
    }

    /**
     * gets the Account holder's account number.
     *
     * @return String
     *         <p/>
     *         Maps to Payflow Parameters as follows:
     *         {@paypal.listtable}
     *         {@paypal.ltr}
     *         {@paypal.lth} Specific transaction {@paypal.elth}
     *         {@paypal.lth}Payflow Parameter{@paypal.elth}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} Transactions with CreditCard, PurchaseCard, BankAcct payment devices {@paypal.eltd}
     *         {@paypal.ltd} ACCT {@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} Transactions with CheckPayment {@paypal.eltd}
     *         {@paypal.ltd} MICR {@paypal.ltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd} Transactions with SwipeCard {@paypal.eltd}
     *         {@paypal.ltd} SWIPE {@paypal.ltd}
     *         {@paypal.eltr}
     *         {@paypal.endlisttable}
     *         </p>
     */
    public String getAcct() {
        return acct;
    }

    /**
     * gets the account holder's name.
     *
     * @return String
     *         <p/>
     * @paypal.sample Maps to Payflow Parameters as follows: NAME
     * </p>
     */

    public String getName() {
        return name;
    }

    /**
     * gets the account holder's name.
     *
     * @param name <p/>
     * @paypal.sample Maps to Payflow Parameters as follows: NAME
     * </p>
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ACCT, acct));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NAME, name));
    }

}

