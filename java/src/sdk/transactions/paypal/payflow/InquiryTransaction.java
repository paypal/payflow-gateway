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
 * This class is used to perform an inquiry transaction.
 * <p>Inquiry transaction gets the status of a previously performed
 * transaction. Therefore, inquiry transaction always takes the PNRef of a
 * previous transaction.</p>
 *
 * @paypal.sample ...............
 * // Populate data objects
 * ...............
 * <p/>
 * // Create a new Inquiry Transaction.
 * InquiryTransaction trans = new InquiryTransaction("PNRef of a previous transaction",
 * user, uonnection, payflowUtility.getRequestId());
 * <p/>
 * // Submit the transaction.
 * Response resp = trans.submitTransaction();
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse = resp.getTransactionResponse();
 * if (trxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("PNREF = " + trxnResponse.getPnref());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
 * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
 * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
 * System.out.println("IAVS = " + trxnResponse.getIAVS());
 * }
 * // Get the Fraud Response parameters.
 * FraudResponse fraudResp =  resp.getFraudResponse();
 * if (fraudResp != null)
 * {
 * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
 * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
 * }
 * }
 * <p/>
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println("Errors = " + ctx.toString());
 * }
 */

public final class InquiryTransaction extends ReferenceTransaction {

    /**
     * <p/>
     * Private Constructor. This prevents
     * creation of an empty Transaction object.
     * </p>
     */

    /**
     * Constructor
     *
     * @param origId                String                - OrigId, Original Transaction Id.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param requestId             String                - Request Id
     *                              <p>Inquiry transaction gets the status of a previously performed
     *                              transaction. Therefore, inquiry transaction always takes the PNRef of a
     *                              previous transaction.</p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Inquiry Transaction.
     * InquiryTransaction trans = new InquiryTransaction("PNRef of a previous transaction",
     * user, connection, payflowUtility.getRequestId());
     */
    public InquiryTransaction(String origId,
                              UserInfo userInfo,
                              PayflowConnectionData payflowConnectionData,
                              String requestId) {
        super(PayflowConstants.TRXTYPE_INQUIRY, origId, userInfo,
                payflowConnectionData, requestId);
    }

    /**
     * Constructor
     *
     * @param origId    String   - OrigId, Original Transaction Id.
     * @param userInfo  UserInfo - User Info object populated with user credentials.
     * @param requestId String   - Request Id
     *                  <p>Inquiry transaction gets the status of a previously performed
     *                  transaction. Therefore, inquiry transaction always takes the PNRef of a
     *                  previous transaction.</p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Inquiry Transaction.
     * InquiryTransaction trans = new InquiryTransaction("PNRef of a previous transaction",
     * user, payflowUtility.getRequestId());
     */

    public InquiryTransaction(String origId, UserInfo userInfo, String requestId) {
        super(PayflowConstants.TRXTYPE_INQUIRY, origId, userInfo, requestId);
    }

    /**
     * Constructor
     *
     * @param origId                String                - OrigId, Original Transaction Id.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice               - Invoice object.
     * @param requestId             String                - Request Id
     *                              <p>Inquiry transaction gets the status of a previously performed
     *                              transaction. Therefore, inquiry transaction always takes the PNRef of a
     *                              previous transaction.</p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Inquiry Transaction.
     * InquiryTransaction trans = new InquiryTransaction("PNRef of a previous transaction",
     * user, connection, invoice, payflowUtility.getRequestId());
     */


    public InquiryTransaction(String origId,
                              UserInfo userInfo,
                              PayflowConnectionData payflowConnectionData,
                              Invoice invoice,
                              String requestId) {
        super(PayflowConstants.TRXTYPE_INQUIRY, origId, userInfo,
                payflowConnectionData, invoice, requestId);
    }

    /**
     * Constructor
     *
     * @param origId    String   - OrigId, Original Transaction Id.
     * @param userInfo  UserInfo - User Info object populated with user credentials.
     * @param invoice   Invoice  - Invoice object.
     * @param requestId String   - Request Id
     *                  <p>Inquiry transaction gets the status of a previously performed
     *                  transaction. Therefore, inquiry transaction always takes the PNRef of a
     *                  previous transaction.</p>
     * @paypal.sample ...............
     * // Populate data objects
     * ...............
     * <p/>
     * // Create a new Inquiry Transaction.
     * InquiryTransaction trans = new InquiryTransaction("PNRef of a previous transaction",
     * user, connection, invoice, payflowUtility.getRequestId());
     */


    public InquiryTransaction(String origId,
                              UserInfo userInfo,
                              Invoice invoice,
                              String requestId) {
        this(origId, userInfo, null, invoice, requestId);
    }

}
