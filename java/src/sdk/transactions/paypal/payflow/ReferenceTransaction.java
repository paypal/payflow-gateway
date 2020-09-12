package paypal.payflow;

/**
 * This class is used as base class for all reference transactions.
 * <p>This class can be derived to create a new reference transaction
 * or can be used as is to submit a new type of reference transaction.
 * <p>A reference transaction is a transaction which always takes
 * the PNRef of a previously submitted transaction.</p>
 * </p>
 */
public class ReferenceTransaction extends BaseTransaction {
    private String origId;
    private String origPPRef;

    /**
     * gets the OrigPPRef
     *
     * @return origPPRef
     * @paypal.sample <p> maps to PayflowParameter ORIGPPREF</p>
     */
    public String getOrigPPRef() {
        return origPPRef;
    }

    /**
     * sets the OrigPPRef
     *
     * @param origPPRef String
     * @paypal.sample <p> maps to PayflowParameter ORIGPPREF</p>
     */
    public void setOrigPPRef(String origPPRef) {
        this.origPPRef = origPPRef;
    }

    protected ReferenceTransaction() {
    }

    /**
     * Constructor
     *
     * @param trxType               String                - Transaction Type
     * @param origId                String                - Original Transaction Id.
     * @param userInfo              UserInfo             - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData         - Connection credentials object.
     * @param requestId             String          - RequestId
     *                              <p/>
     *                              This class can be derived to create a new reference transaction
     *                              or can be used as is to submit a new type of reference transaction.
     *                              A reference transaction is a transaction which always takes
     *                              the PNRef of a previously submitted transaction.
     *                              </p>
     */
    public ReferenceTransaction(String trxType,
                                String origId,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData,
                                String requestId) {
        super(trxType, userInfo, payflowConnectionData, requestId);
        this.origId = origId;
    }

    /**
     * Constructor
     *
     * @param trxType   String   - Transaction Type
     * @param origId    String   - Original Transaction Id.
     * @param userInfo  UserInfo - User Info object populated with user credentials.
     * @param requestId String   - RequestId
     *                  <p/>
     *                  This class can be derived to create a new reference transaction
     *                  or can be used as is to submit a new type of reference transaction.
     *                  A reference transaction is a transaction which always takes
     *                  the PNRef of a previously submitted transaction.
     *                  </p>
     */
    public ReferenceTransaction(String trxType,
                                String origId,
                                UserInfo userInfo,
                                String requestId) {
        super(trxType, userInfo, requestId);
        this.origId = origId;
    }

    /**
     * Constructor
     *
     * @param trxType               String                - Transaction Type
     * @param origId                String                - Original Transaction Id.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice               - Invoice object.
     * @param requestId             String                - RequestId
     *                              <p/>
     *                              This class can be derived to create a new reference transaction
     *                              or can be used as is to submit a new type of reference transaction.
     *                              A reference transaction is a transaction which always takes
     *                              the PNRef of a previously submitted transaction.
     *                              </p>
     */
    public ReferenceTransaction(String trxType,
                                String origId,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData,
                                Invoice invoice, String requestId) {
        super(trxType, userInfo, payflowConnectionData, invoice, requestId);
        this.origId = origId;
    }

    /**
     * Constructor
     *
     * @param trxType   String   - Transaction Type
     * @param origId    String   - Original Transaction Id.
     * @param userInfo  UserInfo - User Info object populated with user credentials.
     * @param invoice   Invoice  - Invoice object.
     * @param requestId String   - RequestId
     *                  <p/>
     *                  This class can be derived to create a new reference transaction
     *                  or can be used as is to submit a new type of reference transaction.
     *                  A reference transaction is a transaction which always takes
     *                  the PNRef of a previously submitted transaction.
     *                  </p>
     */
    public ReferenceTransaction(String trxType, String origId, UserInfo userInfo, Invoice invoice, String requestId) {
        this(trxType, origId, userInfo, null, invoice, requestId);
    }

    /**
     * Constructor
     *
     * @param trxType               String                - Transaction Type
     * @param origId                String                - Original Transaction Id.
     * @param userInfo              UserInfo              - User Info object populated with user credentials.
     * @param payflowConnectionData PayflowConnectionData - Connection credentials object.
     * @param invoice               Invoice               - Invoice object.
     * @param tender                Tender                - Tender object.
     * @param requestId             String                - RequestId
     *                              <p/>
     *                              This class can be derived to create a new reference transaction
     *                              or can be used as is to submit a new type of reference transaction.
     *                              A reference transaction is a transaction which always takes
     *                              the PNRef of a previously submitted transaction.
     *                              </p>
     */

    public ReferenceTransaction(String trxType,
                                String origId,
                                UserInfo userInfo,
                                PayflowConnectionData payflowConnectionData,
                                Invoice invoice,
                                BaseTender tender, String requestId) {
        super(trxType, userInfo, payflowConnectionData, invoice, tender, requestId);
        this.origId = origId;
    }

    /**
     * Constructor
     *
     * @param trxType   String   - Transaction Type
     * @param origId    String   - Original Transaction Id.
     * @param userInfo  UserInfo - User Info object populated with user credentials.
     * @param invoice   Invoice  - Invoice object.
     * @param tender    Tender   - Tender object.
     * @param requestId String   - RequestId
     *                  <p/>
     *                  This class can be derived to create a new reference transaction
     *                  or can be used as is to submit a new type of reference transaction.
     *                  A reference transaction is a transaction which always takes
     *                  the PNRef of a previously submitted transaction.
     *                  </p>
     */

    public ReferenceTransaction(String trxType, String origId, UserInfo userInfo, Invoice invoice, BaseTender tender, String requestId) {
        this(trxType, origId, userInfo, null, invoice, tender, requestId);
    }

    protected void generateRequest() {
        super.generateRequest();
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGID, origId));
        getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORIGPPREF, origPPRef));
    }

}

