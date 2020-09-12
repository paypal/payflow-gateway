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
 * This class is used to perform a recurring transaction with
 * add action.
 * <p/>
 * RecurringAddTransaction is used to add a new recurring profile
 * either by submitting the data that defines the profile or by converting an
 * existing transaction into a profile. Upon successful creation of a profile,
 * PayPal activates the profile, performs the Optional Transaction if specified,
 * initiates the payment cycle, and returns a Profile ID (a 12-character string that
 * uniquely identifies the profile for searching and reporting). Upon failure, PayPal
 * does not generate the profile and returns an error message.
 * </p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
 * //Set the Recurring related information.
 * RecurringInfo recurInfo = new RecurringInfo();
 * // The date that the first payment will be processed.
 * // This will be of the format mmddyyyy.
 * recurInfo.setStart("01012009");
 * recurInfo.setProfileName ("PayPal");
 * <p/>
 * <p/>
 * // Specifies how often the payment occurs. All PAYPERIOD values must use
 * // capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
 * // QTER / SMYR / YEAR
 * recurInfo.setPayPeriod ("WEEK");
 * <p/>
 * // Create a new RecurringAddTransaction
 * RecurringAddTransaction trans = new RecurringAddTransaction(
 * user, connection, inv, card, recurInfo, PayflowUtility.getRequestId());
 * <p/>
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 * <p/>
 * if (Resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * }
 * <p/>
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * }
 * }
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println("/n" + "Errors = " + Ctx.ToString());
 * }
 */

public class RecurringAddTransaction extends RecurringTransaction {


    private String origId;

    /**
     * Gets the OrigId.
     *
     * @return String
     */
    public String getOrigId() {
        return origId;
    }

    /**
     * Sets the orig Id.
     *
     * @param origId String
     */
    public void setOrigId(String origId) {
        this.origId = origId;
    }

    /**
     * Constructor
     *
     * @param UserInfo              - User Info object populated with user credentials.
     * @param PayflowConnectionData - Connection credentials object.
     * @param Invoice               - Invoice object.
     * @param Tender                - Tender object such as  Card Tender object.
     * @param RecurringInfo         - Recurring Info object.
     * @param RequestId             - Request Id
     *                              <p/>
     *                              RecurringAddTransaction is used to add a new recurring profile
     *                              either by submitting the data that defines the profile or by converting an
     *                              existing transaction into a profile. Upon successful creation of a profile,
     *                              PayPal activates the profile, performs the Optional Transaction if specified,
     *                              initiates the payment cycle, and returns a Profile ID (a 12-character string that
     *                              uniquely identifies the profile for searching and reporting). Upon failure, PayPal
     *                              does not generate the profile and returns an error message.
     *                              </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringCancelTransaction.
     * RecurringCancelTransaction trans = new RecurringCancelTransaction(user, connection, inv, tender, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringAddTransaction(UserInfo UserInfo,
                                   PayflowConnectionData PayflowConnectionData,
                                   Invoice Invoice,
                                   BaseTender Tender,
                                   RecurringInfo RecurringInfo,
                                   String RequestId) {
        super(PayflowConstants.RECURRING_ACTION_ADD,
                RecurringInfo,
                UserInfo, PayflowConnectionData, Invoice, Tender, RequestId);
    }

    /**
     * Constructor
     *
     * @param UserInfo      - User Info object populated with user credentials.
     * @param Invoice       - Invoice object.
     * @param Tender        - Tender object such as  Card Tender object.
     * @param RecurringInfo - Recurring Info object.
     * @param RequestId     - Request Id
     *                      <p/>
     *                      RecurringAddTransaction is used to add a new recurring profile
     *                      either by submitting the data that defines the profile or by converting an
     *                      existing transaction into a profile. Upon successful creation of a profile,
     *                      PayPal activates the profile, performs the Optional Transaction if specified,
     *                      initiates the payment cycle, and returns a Profile ID (a 12-character string that
     *                      uniquely identifies the profile for searching and reporting). Upon failure, PayPal
     *                      does not generate the profile and returns an error message.
     *                      </p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * <p/>
     * // Create a new RecurringCancelTransaction.
     * RecurringCancelTransaction trans = new RecurringCancelTransaction(user, inv, tender, recurInfo,
     * payflowUtility.getRequestId ());
     * <p/>
     * // Submit the transaction.
     * Response resp = trans.submitTransaction();
     */

    public RecurringAddTransaction(UserInfo UserInfo,
                                   Invoice Invoice,
                                   BaseTender Tender,
                                   RecurringInfo RecurringInfo,
                                   String RequestId) {
        this(UserInfo, null, Invoice, Tender, RecurringInfo, RequestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGID, origId));
    }
}
