package paypal.payflow;

import java.util.ArrayList;


/**
 * This class is the base class for all transaction objects. It has methods for generating the transaction request,
 * sending it to the server and obtaining the response.
 * <p/>
 * <p>This class can be extended to create a new transaction type.</p>
 *
 *  This example shows how to create and perform an Sale transaction using a Basetransaction Object.
 * <p/>
 * ..........
 * ..........
 * //Populate required data objects.
 * ..........
 * ..........
 * <p/>
 * //Create a new Base Transaction.
 * BaseTransaction trans = new BaseTransaction("S",User, Connection, Inv, Card, PayflowUtility.RequestId);
 * <p/>
 * //Submit the transaction.
 * trans.submitTransaction();
 * // Get the Response
 * Response resp = trans.getResponse();
 * <p/>
 * // Display the transaction response parameters.
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * <p/>
 * if (TrxnResponse != null)
 * {
 * System.out.println("RESULT = " + trxnResponse.getResult());
 * System.out.println("PNREF = " + trxnResponse.getPnref());
 * System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
 * System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
 * System.out.println("AVSADDR = " + trxnResponse.getAVSAddr());
 * System.out.println("AVSZIP = " + trxnResponse.getAVSZip());
 * System.out.println("IAVS = " + trxnResponse.getIAVS());
 * }
 * <p/>
 * <p/>
 * // Get the Fraud Response parameters.
 * FraudResponse fraudResp =  resp.getFraudResponse();
 * if (fraudResp != null)
 * {
 * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
 * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
 * }
 * <p/>
 * // Display the response.
 * System.out.println(PayflowUtility.getStatus(Resp));
 * <p/>
 * <p/>
 * // Get the Transaction Context and check for any contained SDK specific errors (optional code).
 * Context transCtx = resp.getTransactionContext();
 * if (transCtx != null &amp;&amp; transCtx.getErrorCount() > 0)
 * {
 * System.out.println(+ "Transaction Errors = " + transCtx.toString());
 * }
 * <p/>
 * }
 */
public class BaseTransaction {
    /**
     * Arraylist of Extend Data objects. The arraylist contains objects of type ExtendData.
     * ExtendData has a parameter name and value and is used for sending any additional parameter currently not
     * supported by the SDK.
     */
    private ArrayList extData;

    /**
     * Type of transaction to perform, indicated by a single character.
     */
    private String trxType;

    /**
     * Connection parameters to connect to the PayPal Payment Server.
     */
    private PayflowConnectionData payflowConnectionData;

    /**
     * Transaction request in Name-Value Pair format.
     */
    private String request;

    /**
     * Tender object for ACH, Credit Card, PINless Debit & eCheck
     */
    private BaseTender tender;

    /**
     * Transaction invoice object. Has parameters like Amt, InvNum, BillTo,
     * ShipTo etc.
     */
    private Invoice invoice;

    /**
     * Response object for the Transaction. Has objects like Transaction Response,
     * Fraud Response, Recurring Response etc.
     */
    private Response response;

    /**
     * Payflow user credentials. Has parameters like User, Vendor, Partner, Password etc.
     */
    private UserInfo userInfo;

    /**
     * Value (LOW, MEDIUM or HIGH) that controls the detail level and format of transaction results.
     * LOW (default) returns normalized values. MEDIUM or HIGH return the processor's raw response values.
     * <p>Maps to Payflow Parameter - VERBOSITY</p>
     */
    private String verbosity;

    /**
     * Context object containing the Error Objects. The context object is available to all the classes in the
     * SDK. The individual classes add their messages in form of Error Objects to the Context object.
     *
     * @see UserInfo
     */
    private Context context;

    /**
     * Unique request id for the transaction.
     * <p>Maps to Payflow Parameter in header - PAYFLOW-REQUEST-ID</p>
     */
    public String requestId;   // removed "static" 02/22/2016 - wasn't thread safe

    /**
     * Request Buffer. This is used to build the request string in Name-Value pair format from Data Objects.
     */
    private StringBuffer requestBuffer;

    /**
     * Client Header Information
     */
    private ClientInfo clientInfo;

    /**
     * Buyer auth status information
     */
    private BuyerAuthStatus buyerAuthStatus;

    /**
     * @return Buyer auth status object
     */
    public BuyerAuthStatus getBuyerAuthStatus() {
        return this.buyerAuthStatus;
    }

    /**
     * Sets buyer
     *
     * @param buyerAuthStatus buyer auth status object
     */
    public void setBuyerAuthStatus(BuyerAuthStatus buyerAuthStatus) {
        this.buyerAuthStatus = buyerAuthStatus;
    }


    public ClientInfo getClientInfo() {
        return clientInfo;
    }


    public void setClientInfo(ClientInfo clientInfo) {
        this.clientInfo = clientInfo;
    }

    /**
     * Gets the extend data list.
     *
     * @return extData ArrayList
     *  ............
     * //Trans is the transaction object.
     * ............
     * ArrayList extDataList = trans.getExtendData();
     */
    public ArrayList getExtData() {
        return extData;
    }

    /**
     * sets extData ArrayList
     *
     * @param extData ArrayList
     */
    public void setExtData(ExtendData extData) {

        if (this.extData == null) {
            this.extData = new ArrayList();
        }
        if (extData != null) {
            extData.setContext(context);
            extData.setRequestBuffer(requestBuffer);
            this.extData.add(extData);
        }
    }

    /**
     * Transaction request in Name-Value Pair format.
     *
     * @return request String
     *  TRXTYPE[1]=S&amp;ACCT[16]=5105105105105100&amp;EXPDATE[4]=0109&amp;TENDER[1]=C&amp;INVNUM[8]=INV12345&amp;AMT[5]=25.12
     * USER=user&amp;VENDOR=vendor&amp;PARTNER=partner&amp;PWD=password
     */
    public String getRequest() {
        return request;
    }

    public String getRequestId() {
        return requestId;
    }

    /**
     * @param requestId String
     *                  ............
     *                  //Trans is the transaction object.
     *                  //A unique RequestId can be generated
     *                  //using the PayflowUtility.getRequestId() property.
     *                  ............
     *                  trans.setRequestId(PayflowUtility.getRequestId();
     *                  System.out.println("Transaction RequestId = " + trans.getRequestId());
     */
    public void setRequestId(String requestId) {
            this.requestId = requestId;
        }

    /**
     * Gets the transaction response object.
     *
     * @return response Response
     *  ............
     * //Trans is the transaction object.
     * ............
     * <p/>
     * //Submit the transaction.
     * trans.submitTransaction();
     * <p/>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.getTransactionResponse();
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
     * FraudResponse fraudResp = resp.getFraudResponse();
     * if (fraudResp != null)
     * {
     * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
     * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
     * }
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null ++ Ctx.getErrorCount() > 0)
     * {
     * System.out.println(Environment.NewLine + "Errors = " + Ctx.ToString());
     * }
     */
    public Response getResponse() {
        return response;
    }

    /**
     * gets the tender object
     *
     * @return tender BaseTender
     */
    public BaseTender getTender() {
        return tender;
    }

    /**
     * Tender object for ACH, Credit Card, PINless Debit &amp; eCheck.
     *
     * @param tender BaseTender
     *               <p/>
     *               Allowed Tender Types are:
     *               </p>
     *               {@paypal.listtable}
     *               {@paypal.ltr}
     *               {@paypal.lth}Tender Type{@paypal.elth}
     *               {@paypal.lth}Tender Name<@paypal.elth}
     *               {@paypal.eltr}
     *               {@paypal.ltr}
     *               {@paypal.ltd}A{@paypal.eltd}
     *               {@paypal.ltd}ACH ( Automatic Clearing House )<@paypal.eltd}
     *               {@paypal.eltr}
     *               {@paypal.ltr}
     *               {@paypal.ltd}C{@paypal.eltd}
     *               {@paypal.ltd}Credit Card{@paypal.eltd}
     *               {@paypal.eltr}
     *               {@paypal.ltr}
     *               {@paypal.ltd}D{@paypal.eltd}
     *               {@paypal.ltd}PINLess Debit{@paypal.eltd}
     *               {@paypal.eltr}
     *               {@paypal.ltr}
     *               {@paypal.ltd}K{@paypal.eltd}
     *               {@paypal.ltd}e-Check ( TeleCheck ){@paypal.eltd}
     *               {@paypal.eltr}
     *               {@paypal.endlisttable}
     *               <p>Each Tender type Maps to Payflow Parameter - TENDER</p>
     * @see ACHTender
     * @see CardTender
     * @see CheckTender
     */
    public void setTender(BaseTender tender) {
        this.tender = tender;
    }

    /**
     * Type of transaction to perform, indicated by a single character.
     * Credit payments require an ORIGID referring to an earlier Debit/Sale payment,
     * and the AMT must be empty or the exact amount of the original Debit/Sale payment.
     *
     * @return trxType String
     *         <p>Maps to Payflow Parameter - TRXTYPE</p>
     *         Allowed TrxType values are:
     *         {@paypal.listtable}
     *         {@paypal.ltr}
     *         {@paypal.lth}Transaction Type{@paypal.elth}
     *         {@paypal.lth}Transaction Name{@paypal.elth}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}S{@paypal.eltd}
     *         {@paypal.ltd}Sale/Debit{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}A{@paypal.eltd}
     *         {@paypal.ltd}Voice Authorization/Force{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}C{@paypal.eltd}
     *         {@paypal.ltd}Credit{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}V{@paypal.eltd}
     *         {@paypal.ltd}Void{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}D{@paypal.eltd}
     *         {@paypal.ltd}Delayed Capture{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}F{@paypal.eltd}
     *         {@paypal.ltd}Force/Voice Authorization{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}I{@paypal.eltd}
     *         {@paypal.ltd}Inquiry{@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.ltr}
     *         {@paypal.ltd}R{@paypal.eltd}
     *         {@paypal.ltd}Recurring billing<@paypal.eltd}
     *         {@paypal.eltr}
     *         {@paypal.endlisttable}
     */
    public String getTrxType() {
        return trxType;
    }


    /**
     * Value (LOW, MEDIUM or HIGH) that controls the detail level and format of transaction results.
     * LOW (default) returns normalized values. MEDIUM or HIGH return the processor's raw response values.
     * <p>Maps to Payflow Parameter - VERBOSITY</p>
     *
     * @return verbosity String
     *  ............
     * //Trans is the transaction object.
     * ............
     * trans.setVerbosity( "HIGH");
     * System.out.println("Transaction Type = " + Trans.getTrxType())
     */
    public String getVerbosity() {
        return verbosity;
    }

    /**
     * Value (LOW, MEDIUM or HIGH) that controls the detail level and format of transaction results.
     * LOW (default) returns normalized values. MEDIUM or HIGH return the processor's raw response values.
     * <p>Maps to Payflow Parameter - VERBOSITY</p>
     *
     * @param verbosity String
     *  ............
     * //Trans is the transaction object.
     * ............
     * trans.setVerbosity( "HIGH");
     * System.out.println("Transaction Type = " + Trans.getTrxType())
     */
    public void setVerbosity(String verbosity) {
        this.verbosity = verbosity;
    }

    /**
     * Gets the context object
     * of the current transaction.
     *
     * @return context Context
     */
    protected Context getContext() {
        return context;
    }


    protected void setContext(Context context) {
        this.context = context;
    }

    /**
     * Gets the StringBuffer object for RequestBuffer.
     *
     * @return requestBuffer StringBuffer
     */
    protected StringBuffer getRequestBuffer() {
        return requestBuffer;
    }

    /**
     * protected Constructor. This prevents
     * creation of an empty Transaction object.
     */
    protected BaseTransaction() {
        requestBuffer = new StringBuffer();
        context = new Context();
        context.setLoadLoggerErrs(true);
    }

    /**
     * @param strTrxType               String transaction type
     * @param objUserInfo              UserInfo : UserInfo object populated with user credentials
     * @param objpayflowConnectionData PayflowConnectionData
     * @param requestId                String
     */
    public BaseTransaction(String strTrxType,
                           UserInfo objUserInfo,
                           PayflowConnectionData objpayflowConnectionData,
                           String requestId) {
        this();
        trxType = strTrxType;
        userInfo = objUserInfo;
        payflowConnectionData = objpayflowConnectionData;
        this.requestId = requestId;
        if (userInfo != null) {
            userInfo.setContext(context);

        }
        if (payflowConnectionData != null) {
            if (payflowConnectionData.getContext() != null && payflowConnectionData.getContext().isErrorContained()) {
                context.addErrors(payflowConnectionData.getContext().getErrors());
            }
        }
    }

    /**
     * @param strTrxType  String
     * @param objUserInfo UserInfo : UserInfo object populated with user credentials
     * @param requestId   String
     */
    public BaseTransaction(String strTrxType,
                           UserInfo objUserInfo,
                           String requestId) {
        this();
        trxType = strTrxType;
        userInfo = objUserInfo;
        //payflowConnectionData = PayflowConnectionData;
        this.requestId = requestId;
        if (userInfo != null) {
            userInfo.setContext(context);
        }

    }

    /**
     * @param strTrxType               String
     * @param objUserInfo              UserInfo : UserInfo object populated with user credentials
     * @param objpayflowConnectionData PayflowConnectionData : Connection credentials object
     * @param objInvoice               Invoice : Invoice object
     * @param requestId                String
     */
    public BaseTransaction(String strTrxType,
                           UserInfo objUserInfo,
                           PayflowConnectionData objpayflowConnectionData,
                           Invoice objInvoice,
                           String requestId) {
        this(strTrxType, objUserInfo, objpayflowConnectionData, requestId);
        invoice = objInvoice;
        if (invoice != null) {
            invoice.setContext(context);
        }

    }

    /**
     * @param strTrxType  String : transaction type
     * @param objUserInfo UserInfo : UserInfo object populated with user credentials
     * @param objInvoice  Invoice : Invoice Object
     * @param requestId   String
     */
    public BaseTransaction(String strTrxType,
                           UserInfo objUserInfo,
                           Invoice objInvoice,
                           String requestId) {
        this(strTrxType, objUserInfo, null, objInvoice, requestId);
    }

    /**
     * @param strTrxType               String : Transaction type
     * @param objUserInfo              UserInfo : UserInfo object populated with user credentials
     * @param objpayflowConnectionData PayflowConnectionData : Connection credentials object
     * @param objInvoice               Invoice : Invoice object
     * @param objTender                BaseTender : Tender object such as CardTender
     * @param requestId                String
     */
    public BaseTransaction(String strTrxType, UserInfo objUserInfo,
                           PayflowConnectionData objpayflowConnectionData, Invoice objInvoice,
                           BaseTender objTender, String requestId) {
        this(strTrxType, objUserInfo, objpayflowConnectionData, objInvoice, requestId);
        tender = objTender;
        if (tender != null) {
            tender.setContext(context);
            tender.setRequestBuffer(requestBuffer);
        }

    }

    /**
     * @param strTrxType  String : Transaction type
     * @param objUserInfo UserInfo : UserInfo object populated with user credentials
     * @param objInvoice  : Invoice object
     * @param objTender   BaseTender : Tender object such as CardTender
     * @param requestId   String
     */
    public BaseTransaction(String strTrxType, UserInfo objUserInfo,
                           Invoice objInvoice,
                           BaseTender objTender, String requestId) {
        this(strTrxType, objUserInfo, null, objInvoice, objTender, requestId);
    }


    /**
     * This method submits the transaction
     * to the PayPal Payment Gateway.
     * The response is obtained from the gateway
     * and response object is populated with the
     * response values along with the sdk specific
     * errors in context, if any.
     *
     * @return response String
     *  ............
     * //Trans is the transaction object.
     * ............
     * <p/>
     * //Submit the transaction.
     * trans.submitTransaction();
     * <p/>
     * // Get the Response.
     * Response resp = trans.getResponse();
     * if (Resp != null)
     * {
     * // Get the Transaction Response parameters.
     * TransactionResponse trxnResponse =  resp.transactionResponse();
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
     * if (FraudResp != null)
     * {
     * System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
     * System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
     * }
     * }
     * // Get the Context and check for any contained SDK specific errors.
     * Context ctx = resp.getTransactionContext();
     * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
     * {
     * System.out.println("Errors = " + ctx.ToString());
     * }
     */
    public Response submitTransaction() {

        PayflowAPI objPayflowApi = null;
        String responseValue = null;
        boolean fatal = false;
        //Logger.getInstance().log("########### BEGIN TRANSACTION ###########", PayflowConstants.SEVERITY_INFO);
        Logger.getInstance().log("paypal.payflow.BaseTransaction.SubmitTransaction(): Entered", PayflowConstants.SEVERITY_DEBUG);
        try {
            if (clientInfo == null) {
                clientInfo = new ClientInfo();
            }
            //Check for the errors in the context now.
            ArrayList errors = PayflowUtility.alignContext(context, false);
            context.setLoadLoggerErrs(false);
            context.clearErrors();
            context.addErrors(errors);
            generateRequest();
            if (context.getHighestErrorLvl()
                    == PayflowConstants.SEVERITY_FATAL) {
                Logger.getInstance().log("paypal.payflow.BaseTransaction.SubmitTransaction(): Exiting", PayflowConstants.SEVERITY_DEBUG);
                fatal = true;
            }
            if (!fatal) {
                generateRequest();
                request = requestBuffer.toString();
                //Remove the trailing PayflowConstants.DELIMITER_NVP;
                int parmListLen = request.length();
                if (parmListLen > 0 && request.charAt(parmListLen - 1) == '&') {
                    request = request.substring(0, parmListLen - 1);
                }
                //Call the api from here and submit transaction

                if (payflowConnectionData != null) {
                    objPayflowApi = new PayflowAPI(payflowConnectionData.getHostAddress(),
                            payflowConnectionData.getHostPort(),
                            payflowConnectionData.getTimeOut(),
                            payflowConnectionData.getProxyAddress(),
                            payflowConnectionData.getProxyPort(),
                            payflowConnectionData.getProxyLogon(),
                            payflowConnectionData.getProxyPassword());
                } else {
                    objPayflowApi = new PayflowAPI();
                }

                objPayflowApi.isStrongAssemblyTransaction = true;
                objPayflowApi.setClientInfo(clientInfo);
                responseValue = objPayflowApi.submitTransaction(request, requestId);

                Logger.getInstance().log("paypal.payflow.BaseTransaction.SubmitTransaction(): Exiting", PayflowConstants.SEVERITY_DEBUG);
            }
        }
        catch (Exception ex) {
            ErrorObject Error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, ex, PayflowConstants.SEVERITY_FATAL, false, null);
            context.addError(Error);
        }
        finally {
            if (objPayflowApi != null) {
                request = objPayflowApi.getTransactionRequest();
                context.addErrors(objPayflowApi.getTransactionContext().getErrors());
                requestId = objPayflowApi.getRequestId();
                clientInfo = objPayflowApi.getClientInfo();
            } else {
                //There is some error due to which the return
                //is called even before payflownetapi object is
                //created.
                //Check the first fatal error in context and
                //put its response value to string.
                if (request != null && request.length() > 0) {
                    request = PayflowUtility.maskSensitiveFields(request);
                }
                ArrayList errorList = context.getErrors(PayflowConstants.SEVERITY_FATAL);
                ErrorObject firstFatalError = (ErrorObject) errorList.get(0);
                responseValue = firstFatalError.toString();
            }

            response = new Response(requestId, context);

            //If the response string is populated from the
            //context and if response id is not obtained, then
            //response string ends with RESPONSE_ID=.
            //We don't require this. so if we find response
            //ending with RESPONSE_ID= we will remove the same.
            if (responseValue != null && responseValue.endsWith("&RESPONSE_ID=")) {
                responseValue = responseValue.substring(0, responseValue.length() - 13);
            }

            response.setRequestString(request);
            response.setParams(responseValue);

            //Log the context
            if (context.isErrorContained()) {
                context.logErrors();
            }
        }
        //Logger.getInstance().log("########### END TRANSACTION ###########", PayflowConstants.SEVERITY_INFO);
        return response;
    }

    /**
     * Generates the transaction request.
     */
    protected void generateRequest() {

        Logger.getInstance().log("paypal.payflow.BaseTransaction.generateRequest(): Entered", PayflowConstants.SEVERITY_DEBUG);
        requestBuffer = new StringBuffer();
        requestBuffer.append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TRXTYPE, trxType));
        requestBuffer.append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VERBOSITY, verbosity));

        if (extData != null && extData.size() > 0) {
            ExtendData objExtendData;
            for (int i = 0; i < extData.size(); i++) {
                if (extData.get(i) != null) {
                    objExtendData = (ExtendData) extData.get(i);
                    objExtendData.setRequestBuffer(getRequestBuffer());
                    objExtendData.generateRequest();
                }
            }
        }

        if (tender != null) {
            tender.setRequestBuffer(requestBuffer);
            tender.generateRequest();
        }
        if (invoice != null) {
            invoice.setRequestBuffer(requestBuffer);
            invoice.generateRequest();
        }
        if (userInfo != null) {
            userInfo.setRequestBuffer(requestBuffer);
            userInfo.generateRequest();
        }
        if (buyerAuthStatus != null) {
            buyerAuthStatus.setRequestBuffer(requestBuffer);
            buyerAuthStatus.generateRequest();
        }
        Logger.getInstance().log("paypal.payflow.BaseTransaction.generateRequest(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Clears the Extend Data list held by
     * transaction object.
     */
    public void clearExtendData() {

        if (extData != null) {
            extData.clear();
        }
    }


    /**
     * @param headerName  String
     * @param headerValue String
     */
    public void addHeader(String headerName, String headerValue) {
        if (clientInfo == null) {
            clientInfo = new ClientInfo();
        }
        clientInfo.addHeaderToHash(headerName, headerValue);
    }


    /**
     * @param headerName String
     */
    public void RemoveTransHeader(String headerName) {
        RemoveHeader(headerName);
    }

    /**
     * @param headerName String
     */
    private void RemoveHeader(String headerName) {

        if (clientInfo != null) {
            if (clientInfo.getClientInfoHash().containsKey(headerName)) {
                clientInfo.getClientInfoHash().remove(headerName);
            }

        }
    }

}
