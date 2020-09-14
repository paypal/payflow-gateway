package paypal.payflow;



import org.xml.sax.SAXException;

import java.io.IOException;
import java.util.ArrayList;

/**
 * PayflowAPI is used to submit a Name-value pair or XMLPay request to
 * PayPal payment gateway for online payment processing. The response
 * returned is the string value of the response from the PayPal payment
 * gateway.
 *
 * <pre>{@code
 *  // Create an instance of PayflowAPI.
 * PayflowAPI pa = new PayflowAPI();
 * //Sample Request.
 * // Please replace <user>, <vendor>, <password> & <partner>with your merchant information.
 * String request = "TRXTYPE=S&ACCT=5100000000000008&EXPDATE=0109&TENDER=C&INVNUM=INV12345&PONUM=PO12345&STREET=123 Main St.&ZIP=12345&AMT=12.25&USER=[user]&VENDOR=[vendor]&PARTNER=[partner]&PWD=[password]";
 * // RequestId is a unique string that is required for each and every transaction.
 * // The merchant can use her/his own algorithm to generate this unique request id or
 * // use the SDK provided API to generate this as shown below (PayflowAPI.generateRequestId).
 * String requestId = pa.generateRequestId();
 * String response = pa.submitTransaction(request,requestId);
 * * <p>
 * // Following lines of code are optional.
 * // Begin optional code for displaying SDK errors ...
 * // It is used to read any errors that might have occurred in the SDK.
 * // Get the transaction errors.
 *  * <p>
 * String transErrors = pa.getTransactionContext().toString();
 * if (transErrors != null & transErrors.length() > 0)
 * {
 * System.out.println("Transaction Errors from SDK = \n" + transErrors);
 * }
 * .........................
 * }
 * </pre>
 */
public class PayflowAPI {

    /**
     * Host Address
     */
    private String mHostAddress;

    /**
     * Host Port
     */
    private int mHostPort;

    /**
     * Timeout
     */
    private int mTimeout;

    /**
     * Proxy Address
     */
    private String mProxyAddress;

    /**
     * Proxy Port
     */
    private int mProxyPort;

    /**
     * Proxy Logon
     */
    private String mProxyLogon;

    /**
     * Proxy Password
     */
    private String mProxyPassword;

    /**
     * Request id
     */
    private String mRequestId;

    /**
     * Transaction Context
     */
    private Context mTransactionContext;

    /**
     * Transaction Request
     */
    private String mTransactionRequest;

    /**
     * Transaction Response
     */
    private String mTransactionResponse;


    /**
     * Flag for xml pay request
     */
    private boolean mIsXmlPayRequest = false;

    /**
     * Client information.
     */
    private ClientInfo mClientInfo;
    /**
     * Flag for Strong Assembly Transaction;
     */
    public boolean isStrongAssemblyTransaction = false;

    /**
     * Default Constructor.
     * All the values will be picked up from the SDkProperties ,if specified.
     * If this is not specified then the default values will be used.
     */

    public PayflowAPI() {
        this(null, 0, 0, null, 0, null, null);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI() : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param hostAddress   String
     * @param hostPort      int
     * @param timeout       int
     * @param proxyAddress  String
     * @param proxyPort     int
     * @param proxyLogon    String
     * @param proxyPassword String
     */
    public PayflowAPI(String hostAddress, int hostPort, int timeout, String proxyAddress, int proxyPort, String proxyLogon, String proxyPassword) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,int,String,int,String,String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        mTransactionContext = new Context();
        setParameters(hostAddress, hostPort, timeout, proxyAddress, proxyPort, proxyLogon, proxyPassword);

        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,int,String,int,String,String,String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param hostAddress String
     * @param hostPort    String
     */
    public PayflowAPI(String hostAddress, int hostPort) {
        this(hostAddress, hostPort, 0, null, 0, null, null);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param hostAddress   String
     * @param hostPort      int
     * @param proxyAddress  String
     * @param proxyPort     int
     * @param proxyLogon    String
     * @param proxyPassword String
     */
    public PayflowAPI(String hostAddress, int hostPort, String proxyAddress, int proxyPort, String proxyLogon, String proxyPassword) {
        this(hostAddress, hostPort, 0, proxyAddress, proxyPort, proxyLogon, proxyPassword);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,String,int,String,String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,String,int,String,String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param hostAddress String
     * @param hostPort    int
     * @param timeout     int
     */
    public PayflowAPI(String hostAddress, int hostPort, int timeout) {
        this(hostAddress, hostPort, timeout, null, 0, null, null);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,int) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String,int,intg) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param hostAddress String
     */
    public PayflowAPI(String hostAddress) {
        this(hostAddress, 0, 0, null, 0, null, null);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.PayflowAPI(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Returns the RequestId passed to the gateway.
     *
     * @return requestId String
     */
    public String getRequestId() {
        return mRequestId;
    }

    /**
     * Returns the Transaction Context.This will have the errors generated during the transaction.
     *
     * @return transactionContext Context
     */
    public Context getTransactionContext() {
        return mTransactionContext;
    }

    /**
     * Returns the response string for a Transaction.
     *
     * @return transactionResponse String
     */
    public String getTransactionResponse() {
        return mTransactionResponse;
    }

    /**
     * Returns the request string for a Transaction.
     *
     * @return transactionRequest String
     */
    public String getTransactionRequest() {
        return mTransactionRequest;
    }


    /**
     * Returns the version for the client.
     *
     * @return version String
     */
    public String getVersion() {
        return PayflowConstants.CLIENT_TYPE + PayflowConstants.CLIENT_VERSION;
    }

    /**
     * @return isXmlpayRequest boolean
     */
    protected boolean getIsXmlPayRequest() {
        return mIsXmlPayRequest;
    }

    /**
     * @param value boolean
     */
    protected void setIsXmlPayRequest(boolean value) {
        mIsXmlPayRequest = value;
    }

    /**
     * Returns the ClientInfo contained by the class.
     *
     * @return clientInfo ClientInfo
     */
    public ClientInfo getClientInfo() {
        return mClientInfo;
    }

    /**
     * Sets the ClientInfo Object.
     *
     * @param value ClientInfo
     */
    public void setClientInfo(ClientInfo value) {
        mClientInfo = value;
    }

    /**
     * if any parameter has not already been set, set it to the appropriate values.
     *
     * @param hostAddress   String
     * @param hostPort      Integer
     * @param timeout       Integer
     * @param proxyAddress  String
     * @param proxyPort     Integer
     * @param proxyLogon    String
     * @param proxyPassword String
     */
    private void setParameters(String hostAddress, int hostPort, int timeout, String proxyAddress, int proxyPort, String proxyLogon, String proxyPassword) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.setParameters(String,int,int,String,int,String,String,String): Entered", PayflowConstants.SEVERITY_DEBUG);
        mTransactionContext.clearErrors();

        if (hostAddress != null) {
            mHostAddress = hostAddress.trim();
        }
        mHostPort = hostPort;
        mTimeout = timeout;
         if (proxyAddress != null) {
            mProxyAddress = proxyAddress.trim();
        }
        mProxyPort = proxyPort;
                  if (proxyLogon != null) {
            mProxyLogon = proxyLogon.trim();
        }

        if (proxyPassword != null) {
            mProxyPassword = proxyPassword.trim();
        }

        initSDKProperties();

        Logger.getInstance().log("paypal.payflow.PayflowAPI.setParameters(String,int,int,String,int,String,String,String): Exiting", PayflowConstants.SEVERITY_DEBUG);

    }

    /**
     * Submits a transaction to Payflow Server.
     * PayflowAPI is used to submit a Name-value pair or XMLPay request to
     * PayPal payment gateway for online payment processing. The response
     * returned is the string value of the response from the PayPal payment
     * gateway.
     *
     * @param paramList String
     * @param requestId String
     * @return response String
     */
    public String submitTransaction(String paramList, String requestId) {
        if (!isStrongAssemblyTransaction) {
            Logger.getInstance().log("########### BEGIN TRANSACTION request id : " + requestId + " ###########", PayflowConstants.SEVERITY_INFO);
        }
        Logger.getInstance().log("paypal.payflow.PayflowAPI.submitTransaction(String,String): Entered", PayflowConstants.SEVERITY_DEBUG);

        String retVal = null;
        mRequestId = requestId;
        //masked Transaction Requests will be used for logging
        mTransactionRequest = PayflowUtility.maskSensitiveFields(paramList);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.submitTransaction(String,String): Host " + mHostAddress, PayflowConstants.SEVERITY_DEBUG);
        try {
            checkTransactionArgs(paramList, requestId);
            //Logger.getInstance().log("paypal.payflow.PayflowAPI.submitTransaction(String,String): parmList " + paramList, PayflowConstants.SEVERITY_DEBUG);
            mTransactionContext.setLoadLoggerErrs(true);
            ArrayList errors = PayflowUtility.alignContext(mTransactionContext, getIsXmlPayRequest());
            mTransactionContext.setLoadLoggerErrs(false);
            mTransactionContext.clearErrors();
            mTransactionContext.addErrors(errors);
            //Logger.getInstance().log("submitTransaction()START", PayflowConstants.SEVERITY_DEBUG);
            if (mTransactionContext.getHighestErrorLvl() == PayflowConstants.SEVERITY_FATAL) {
                ArrayList errorList = mTransactionContext.getErrors(PayflowConstants.SEVERITY_FATAL);
                ErrorObject firstFatalError = (ErrorObject) errorList.get(0);
                retVal = firstFatalError.toString();
                //mTransactionRequest = PayflowUtility.maskSensitiveFields(ParamList);
                mTransactionResponse = retVal;
            } else {
                PaymentStateMachine mPaymentStateMachine = PaymentStateMachine.getInstance();
                if (mClientInfo == null) {
                    mClientInfo = new ClientInfo();
                }
                mClientInfo.setClientVersion(PayflowConstants.CLIENT_VERSION);
                mClientInfo.setClientType(PayflowConstants.CLIENT_TYPE);
                if (isStrongAssemblyTransaction) {
                    mClientInfo.setPayflowAssembly(PayflowConstants.STRONG_ASSEMBLY);
                } else {
                    mClientInfo.setPayflowAssembly(PayflowConstants.WEAK_ASSEMBLY);
                }
                mPaymentStateMachine.initializeContext(mHostAddress, mHostPort, mTimeout, mProxyAddress, mProxyPort, mProxyLogon, mProxyPassword, mClientInfo);

                //Initialize transaction
                mPaymentStateMachine.initTrans(paramList, requestId);
                if (PayflowUtility.isTimedOut(mPaymentStateMachine.getTimeout(), mPaymentStateMachine.getStartTime())) {
                    String addlMessage = "Input timeout in millsec = " + mPaymentStateMachine.getTimeout();
                    ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP, null, PayflowConstants.SEVERITY_FATAL,
                            mPaymentStateMachine.getIsXmlPayRequest(), addlMessage);
                    if (!mPaymentStateMachine.getPsmContext().isCommunicationErrorContained(err)) {
                        mPaymentStateMachine.getPsmContext().addError(err);
                    }
                }
                //End Payflow Timeout Check Point 1

                //Begin Toggle through states
                while (mPaymentStateMachine.getInProgress()) {
                    mPaymentStateMachine.execute();
                }
                //End Toggle through states

                mTransactionResponse = mPaymentStateMachine.getResponse();
                retVal = mTransactionResponse;
                mClientInfo = mPaymentStateMachine.getClientInfo();
                mRequestId = mPaymentStateMachine.getRequestId();
                mTransactionContext.addErrors(mPaymentStateMachine.getPsmContext().getErrors());
                ArrayList errList = PayflowUtility.alignContext(mTransactionContext, getIsXmlPayRequest());
                mTransactionContext.setLoadLoggerErrs(false);
                mTransactionContext.clearErrors();
                mTransactionContext.addErrors(errList);
            }
        } catch (Exception ex) {
            retVal = ex.toString();
        } finally {
            Logger.getInstance().log("paypal.payflow.PayflowAPI.SubmitTransaction(String,String): Exiting", PayflowConstants.SEVERITY_DEBUG);
        }
        if (!isStrongAssemblyTransaction) {
            Logger.getInstance().log("########### END TRANSACTION request id : " + requestId + "###########", PayflowConstants.SEVERITY_INFO);
        }

        // added debug logging statements for SDK errors, ie negative errors.
        // 08/23/07 tsieber
        // If there is some error due to which the return is called even before mPaymentStateMachine.initTrans object is
        // created.  Check the first fatal error in context and put its response value to string.
        //if (retVal != null && retVal.length() > 0) {
        //    retVal = PayflowUtility.maskSensitiveFields(retVal);
        // }
        //Log the context
        if (mTransactionContext.isErrorContained()) {
            mTransactionContext.logErrors();
        }
        return retVal;
    }

    /**
     * For any value not passed in the constructor the values being set in the properties will
     * be used.
     */
    private void initSDKProperties() {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.initSDKProperties(): Entered", PayflowConstants.SEVERITY_DEBUG);
        if (mTimeout == 0) {
            mTimeout = SDKProperties.getTimeOut() * 1000;
        } else {
            mTimeout = mTimeout * 1000;
        }
        if (mHostPort == 0) {
            mHostPort = SDKProperties.getHostPort();
        }
        if (null == mHostAddress || mHostAddress.trim().length() == 0) {
            mHostAddress = SDKProperties.getHostAddress();
            if (null == mHostAddress || mHostAddress.trim().length() == 0) {
                String RespMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorCodes.get(PayflowConstants.E_INIT_ERROR)
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorMessages.get(PayflowConstants.E_INIT_ERROR)
                        + "host Address has not been initialised. Please make sure it is being set.";

                ErrorObject error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.EMPTY_STRING, RespMessage);
                mTransactionContext.addError(error);
            }
            Logger.getInstance().log("paypal.payflow.PayflowAPI.initSDKProperties(): host set: " + mHostAddress, PayflowConstants.SEVERITY_DEBUG);
        }
        if (mProxyPort == 0) {
            mProxyPort = SDKProperties.getProxyPort();
        }
        if (null == mProxyAddress || mProxyAddress.trim().length() == 0) {
            mProxyAddress = SDKProperties.getProxyAddress();
            if (null == mProxyAddress) {
                mProxyAddress = PayflowConstants.EMPTY_STRING;
            }
        }
        if (null == mProxyLogon || mProxyLogon.trim().length() == 0) {
            mProxyLogon = SDKProperties.getProxyLogin();
            if (null == mProxyLogon) {
                mProxyLogon = PayflowConstants.EMPTY_STRING;
            }
        }
        if (null == mProxyPassword || mProxyPassword.trim().length() == 0) {
            mProxyPassword = SDKProperties.getProxyPassword();
            if (null == mProxyPassword) {
                mProxyPassword = PayflowConstants.EMPTY_STRING;
            }
        }
        Logger.getInstance().log("paypal.payflow.PayflowAPI.initSDKProperties(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Checks the vital transaction arguments
     * for null or empty and populates context
     * accordingly.
     *
     * @param paramList String
     * @param requestId String
     */
    private void checkTransactionArgs(String paramList, String requestId) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.CheckTransactionArgs(String, String): Entered", PayflowConstants.SEVERITY_DEBUG);
        try {
            Context tempContext = null;
            if (paramList == null || paramList.trim().length() == 0) {
                //Logger.getInstance().log("paypal.payflow.PayflowAPI.CheckTransactionArgs(String, String): 1.", PayflowConstants.SEVERITY_DEBUG);
                String respMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorCodes.get(PayflowConstants.E_EMPTY_PARAM_LIST)
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorMessages.get(PayflowConstants.E_EMPTY_PARAM_LIST);
                ErrorObject error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.EMPTY_STRING, respMessage);
                tempContext.addError(error);
            } else {
                //Logger.getInstance().log("paypal.payflow.PayflowAPI.CheckTransactionArgs(String, String): 2.", PayflowConstants.SEVERITY_DEBUG);
                //Check for XmlPay 1.0
                //We are not supporting Xml Pay 1.0
                int index = paramList.trim().indexOf(PayflowConstants.XML_ID);
                if (index >= 0) {
                    String version;
                    version = PayflowUtility.getXmlAttribute(paramList, PayflowConstants.XML_PARAM_VERSION);

                    if (version != null && version.trim().length() > 0) {
                        mIsXmlPayRequest = true;
                        if ("1.0".equals(version)) {
                            String addlMessage = ", Input XMLPay Request Version = " + version;
                            String[] errParams = new String[]{(String) PayflowConstants.CommErrorCodes.get("E_VERSION_NOT_SUPPORTED"), PayflowConstants.CommErrorMessages.get("E_VERSION_NOT_SUPPORTED") + addlMessage};
                            ErrorObject error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.MSG_COMMUNICATION_ERROR_XMLPAY_NO_RESPONSE_ID, errParams);
                            tempContext.addError(error);
                        }
                    }
                } else {
                    if (!isStrongAssemblyTransaction) {
                        ParameterListValidator.validate(paramList, false, mTransactionContext);
                    }
                }
            }
            if (requestId == null || requestId.trim().length() == 0) {
                String respMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorCodes.get(PayflowConstants.E_MISSING_REQUEST_ID)
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorMessages.get(PayflowConstants.E_MISSING_REQUEST_ID);

                ErrorObject error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.EMPTY_STRING, respMessage);
                tempContext.addError(error);
            }
        } catch (SAXException exp) {
            String addlMessage;
            setIsXmlPayRequest(true);
            addlMessage = "Error while parsing the xml request.";
            ErrorObject Error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, exp, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
            mTransactionContext.addError(Error);
        } catch (IOException exp) {
            String addlMessage;
            setIsXmlPayRequest(true);
            addlMessage = "Error while parsing the xml request.";
            ErrorObject error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, exp, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
            mTransactionContext.addError(error);
        } catch (Exception exp) {
            String addlMessage;
            setIsXmlPayRequest(false);
            addlMessage = "Error while parsing NVP request.";
            ErrorObject error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, exp, PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(), addlMessage);
            mTransactionContext.addError(error);
        }
        Logger.getInstance().log("paypal.payflow.PayflowAPI.CheckTransactionArgs(String, String): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * This function has been out in place to support generation of requestID from the COM Wrapper.
     *
     * @return requestId String
     */
    public String generateRequestId() {
        /*This is required
         because a static function cannot be called from COM Wrapper and PayflowUtility is a static class and has
         a private constructor.
         */
        Logger.getInstance().log("paypal.payflow.PayflowAPI.generateRequestId() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.generateRequestId() : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return PayflowUtility.getRequestId();
    }

    /**
     * Removes a Transaction header
     *
     * @param headerName String
     */
    public void removeTransHeader(String headerName) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.removeTransHeader(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        removeHeader(headerName);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.removeTransHeader(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Removes a header
     *
     * @param headerName String
     */
    private void removeHeader(String headerName) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.removeHeader(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        if (mClientInfo != null) {
            if (mClientInfo.getClientInfoHash().containsKey(headerName)) {
                mClientInfo.getClientInfoHash().remove(headerName);
            }

        }
        Logger.getInstance().log("paypal.payflow.PayflowAPI.removeHeader(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Adds a header to the transaction
     *
     * @param headerName  String
     * @param headerValue String
     */
    public void addHeader(String headerName, String headerValue) {
        Logger.getInstance().log("paypal.payflow.PayflowAPI.addHeader(String,String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        if (mClientInfo == null) {
            mClientInfo = new ClientInfo();
        }

        mClientInfo.addHeaderToHash(headerName, headerValue);
        Logger.getInstance().log("paypal.payflow.PayflowAPI.addHeader(String,String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }
}