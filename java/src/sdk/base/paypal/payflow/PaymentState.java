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

abstract class PaymentState {
    /**
     * This is the default XMLPay namespace.
     */
    private String mDefaultXmlNameSpace;

    /**
     * Payflow XMLPay namespace.
     */
    private String mPayflowXmlNameSpace;

    /**
     * Param list content type.
     */
    private String mContentType;

    /**
     * Connection object.
     */
    protected PaymentConnection mConnection;

    /**
     * Parameter List.
     */
    protected String mParameterList;

    /**
     * Transaction Request.
     */
    private String mTransactionRequest;

    /**
     * Transaction Response.
     */
    private String mTransactionResponse;

    /**
     * Retry Attempt number.
     */
    protected int mAttemptNo;

    /**
     * In Progress flag.
     */
    private boolean mInProgress = true;

    /**
     * State executed flag.
     */
    private boolean mStateExecuted;

    /**
     * State Success flag.
     */
    private boolean mStateSucceeded;

    /**
     * Context object.
     */
    private Context mContext;

    /**
     * Gets the connection object.
     *
     * @return mConnection PaymentConnection
     */
    public PaymentConnection getConnection() {
        return this.mConnection;

    }

    /**
     * Gets the param list.
     *
     * @return Parameter
     */
    public String getParameterList() {
        return this.mParameterList;

    }

    /**
     * Gets, Sets the transaction Request.
     *
     * @return transactionRequest String
     */
    public String getTransactionRequest() {
        return this.mTransactionRequest;
    }

    /**
     * @param value String
     */
    public void setTransactionRequest(String value) {
        mTransactionRequest = value;
    }

    /**
     * Gets, Sets the transaction response.
     *
     * @return mTransactionResponse String
     */
    public String getTransactionResponse() {
        return this.mTransactionResponse;
    }

    /**
     * @param value String
     */
    public void setTransactionResponse(String value) {
        this.mTransactionResponse = value;
    }

    /**
     * Gets the retry attempt no.
     *
     * @return attemptNo int
     */
    public int getAttemptNo() {
        return this.mAttemptNo;
    }

    /**
     * Gets the param list content type.
     *
     * @return contentType String
     */
    public String getContentType() {
        return this.mContentType;
    }

    /**
     * Gets the XmlPay Request type flag.
     *
     * @return isXmlPayRequest boolean
     */
    public boolean getIsXmlPayRequest() {
        return mConnection.getIsXmlPayRequest();
    }

    /**
     * Gets the Default Xml Namespace.
     *
     * @return defaultXmlNameSpace String
     */
    public String getDefaultXmlNameSpace() {
        return this.mDefaultXmlNameSpace;
    }

    /**
     * Gets the Context Object.
     *
     * @return commContext Context
     */
    public Context getCommContext() {
        return mContext;
    }

    /**
     * Gets Xml Name Space
     *
     * @return xmlNameSpace String
     */
    public String getXmlNameSpace() {
        return this.mPayflowXmlNameSpace;
    }

    /**
     * Checks if Response is obtained.
     *
     * @return hasResponse boolean
     */
    public boolean getHasResponse() {
        return (this.mTransactionResponse != null);
    }

    /**
     * Indicates if transaction is in progress.
     *
     * @return inProgress boolean
     */
    public boolean getInProgress() {
        return this.mInProgress;
    }

    /**
     * Indicates current state success.
     * This indicates whether the current state has succeeded.
     * True indicates succeeded, false otherwise.
     *
     * @return success boolean
     */
    public boolean getSuccess() {
        return (this.mStateExecuted && this.mStateSucceeded);
    }

    /**
     * Current state failure.
     * This indicates whether the current state has failed.
     * True indicates failed, false otherwise.
     *
     * @return mStateExecuted boolean
     */
    public boolean getFailed() {
        return (this.mStateExecuted && !this.mStateSucceeded);
    }

    /**
     * Returns state executed.
     *
     * @return stateExecuted boolean
     */
    public boolean getHasExecuted() {
        return this.mStateExecuted;
    }

    /**
     * Constructor
     */
    protected PaymentState() {
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(): Entered", PayflowConstants.SEVERITY_DEBUG);
        mDefaultXmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param connection PaymentConnection
     * @param paramList  String
     * @param psmContext Context
     * @throws Exception Exception
     */
    public PaymentState(PaymentConnection connection, String paramList, Context psmContext) throws Exception {
        this();
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(PaymentConnection,String,Context): Entered", PayflowConstants.SEVERITY_DEBUG);

        mContext = psmContext;
        mConnection = connection;

        initializeContentType(paramList);

        if (mContext.getHighestErrorLvl() < PayflowConstants.SEVERITY_FATAL) {
            mConnection.setContentType(mContentType);

            if (paramList == null || paramList.length() == 0) {
                ErrorObject Err = PayflowUtility.populateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_FATAL,
                        getIsXmlPayRequest(), null);
                mContext.addError(Err);
            }
            this.mTransactionRequest = paramList;
        }
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(PaymentConnection,String,Context): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Copy Constructor
     *
     * @param currentPmtState PaymentState
     */
    public PaymentState(PaymentState currentPmtState) {
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(PaymentState ) : Entered", PayflowConstants.SEVERITY_DEBUG);

        mDefaultXmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;
        this.mConnection = currentPmtState.getConnection();
        this.mParameterList = currentPmtState.getParameterList();
        this.mTransactionRequest = currentPmtState.getTransactionRequest();
        this.mTransactionResponse = currentPmtState.getTransactionResponse();
        this.mConnection.setRequestId(currentPmtState.mConnection.getRequestId());
        this.mConnection.setIsXmlPayRequest(currentPmtState.mConnection.getIsXmlPayRequest());
        this.mAttemptNo = currentPmtState.getAttemptNo();
        /*
			if (mAttemptNo > 0)
			{
				try {
					this.wait(PayflowConstants.RETRY_DELAY);
				} catch (InterruptedException e) {
					// interrupted :: just continue do nothing.
				}
			}*/
        this.mDefaultXmlNameSpace = currentPmtState.mDefaultXmlNameSpace;
        this.mPayflowXmlNameSpace = currentPmtState.getXmlNameSpace();

        this.mContentType = currentPmtState.getContentType();
        this.mContext = currentPmtState.getCommContext();
        Logger.getInstance().log("paypal.payflow.PaymentState.PaymentState(PaymentState ) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Initializes the Content Type of the Request.
     *
     * @param initialParamList String
     * @throws Exception Exception
     */
    private void initializeContentType(String initialParamList) throws Exception {
        Logger.getInstance().log("paypal.payflow.PaymentState.InitializeContentType(String): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        if (initialParamList != null) {
            int index = initialParamList.indexOf(PayflowConstants.XML_ID);
            if (index >= 0) {
                mConnection.setIsXmlPayRequest(true);
                mContentType = PayflowConstants.XML_CONTENT_TYPE;
                mPayflowXmlNameSpace = PayflowUtility.getXmlNameSpace(initialParamList);
            } else {
                mConnection.setIsXmlPayRequest(false);
                mContentType = PayflowConstants.NV_CONTENT_TYPE;
            }
        }
        Logger.getInstance().log("paypal.payflow.PaymentState.InitializeContentType(String): ContentType = " + mContentType,
                PayflowConstants.SEVERITY_INFO);
        Logger.getInstance().log("paypal.payflow.PaymentState.InitializeContentType(String): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Sets the transaction complete flag.
     */
    public void setProgressComplete() {
        this.mInProgress = false;
    }

    /**
     * Sets transaction successful.
     */
    public void setTransactionSuccess() {
        this.setProgressComplete();
    }

    /**
     * Sets transaction failed.
     *
     * @param value String
     */
    public void setTransactionFail(String value) {
        mTransactionResponse = value;
        this.setProgressComplete();
    }

    /**
     * Sets the state success.
     */
    public void setStateSuccess() {
        setStateOutCome(true);
    }

    /**
     * Sets state outcome.
     *
     * @param value boolean
     */
    private void setStateOutCome(boolean value) {
        mStateExecuted = true;
        mStateSucceeded = value;
    }

    /**
     * Sets the state failed.
     */
    public void setStateFail() {
        setStateOutCome(false);
    }

    /**
     * Abstract function declaration
     * of Execute.
     * <p/>
     * This is the abstract method definition of Execute. The Execute method
     * acts as the main important method in these payment state hierarchy. this method is overridden as
     * per the requirements in the derived classes.
     */
    public abstract void execute();


}