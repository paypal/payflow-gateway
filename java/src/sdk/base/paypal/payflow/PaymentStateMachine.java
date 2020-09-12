package paypal.payflow;

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

import java.util.ArrayList;


/**
 * Payment State Driver class.
 */
final class PaymentStateMachine {

    /**
     * Payment State object.
     */
    private PaymentState mPaymentState;

    /**
     * Connection object.
     */
    private PaymentConnection mConnection;

    /**
     * Context object.
     */
    private Context psmContext;

    /**
     * Client information.
     */
    private ClientInfo mClientInfo;

    /**
     * Gets the instance of PaymentStateMachine.
     *
     * @return PaymentStateMachine
     */
    public static PaymentStateMachine getInstance() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getInstance() :Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getInstance() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return new PaymentStateMachine();
    }

    /**
     * @return clientInfo ClientInfo
     */
    public ClientInfo getClientInfo() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getClientInfo() :Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getClientInfo() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return mClientInfo;
    }

    /**
     * @param value ClientInfo
     */
    public void setClientInfo(ClientInfo value) {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.setClientInfo(ClientInfo) :Entered", PayflowConstants.SEVERITY_DEBUG);
        mClientInfo = value;
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.setClientInfo(ClientInfo) :Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Gets transaction response.
     *
     * @return retVal
     */
    public String getResponse() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getResponse() :Entered", PayflowConstants.SEVERITY_DEBUG);
        String retVal = null;
        if (mPaymentState != null) {
            retVal = mPaymentState.getTransactionResponse();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getResponse() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Gets transaction request.
     *
     * @return return
     */
    public String getTransactionRequest() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getTransactionRequest() :Entered", PayflowConstants.SEVERITY_DEBUG);
        String retVal = null;
        if (mPaymentState != null) {
            retVal = mPaymentState.getTransactionRequest();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getTransactionRequest() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Gets the Request Id
     *
     * @return retVal String
     */
    public String getRequestId() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getRequestId() :Entered", PayflowConstants.SEVERITY_DEBUG);
        String retVal = null;
        if (mPaymentState != null) {
            retVal = mPaymentState.getConnection().getRequestId();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getRequestId() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Gets the transaction start time.
     *
     * @return retVal long
     */
    public long getStartTime() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getStartTime() :Entered", PayflowConstants.SEVERITY_DEBUG);
        long retVal = 0;
        if (mPaymentState != null) {
            retVal = mPaymentState.getConnection().getStartTime();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getStartTime() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Gets, Sets the transaction timeout.
     *
     * @return retVal long
     */
    public long getTimeout() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getTimeout() :Entered", PayflowConstants.SEVERITY_DEBUG);
        long retVal = 0;
        if (mPaymentState != null) {
            retVal = mPaymentState.getConnection().getTimeout();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getTimeout() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * @param value long
     */
    public void setTimeout(long value) {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.setTimeout(long) :Entered", PayflowConstants.SEVERITY_DEBUG);
        mPaymentState.getConnection().setTimeout(value);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.setTimeout(long) :Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Gets the context object.
     *
     * @return psmContext Context
     */
    public Context getPsmContext() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getPsmContext() :Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getPsmContext() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return psmContext;
    }

    /**
     * Gets XML Pay Request flag.
     *
     * @return retVal boolean
     */
    public boolean getIsXmlPayRequest() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getIsXmlPayRequest() :Entered", PayflowConstants.SEVERITY_DEBUG);
        boolean retVal = false;
        if (mPaymentState != null) {
            retVal = mPaymentState.getIsXmlPayRequest();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getIsXmlPayRequest() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Gets the Inprogress status of transaction.
     *
     * @return retVal boolean
     */
    public boolean getInProgress() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getInProgress() :Entered", PayflowConstants.SEVERITY_DEBUG);
        boolean retVal = false;
        if (mPaymentState != null) {
            retVal = mPaymentState.getInProgress();
        }
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.getInProgress() :Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * Private constructor for PaymentStateMachine
     */
    private PaymentStateMachine() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.PaymentStateMachine() :Entered", PayflowConstants.SEVERITY_DEBUG);
        psmContext = new Context();
        mConnection = new PaymentConnection(psmContext);
        Logger.getInstance().log("paypal.payflowPaymentStateMachine.PaymentStateMachine() :Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Sets the Version Tracking information
     * in NV Request.
     */
    private void setVersionTracking() {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.SetVersionTracking(): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        // Commented by CRT
        String mVitOSVersion = System.getProperty("os.version");
        String mVitOSName = System.getProperty("os.name");
        String mVitOSArch = System.getProperty("os.arch");
        String mVitRuntimeVersion = System.getProperty("java.vm.version");

        String mVitProxy;
        if (this.mConnection.getIsProxy()) {
            mVitProxy = "Y";
        } else {
            mVitProxy = "N";
        }

        //Check whether OS Version string is also present
        // in the Os name string value. If found, remove it
        //from the string.
        if (mVitOSVersion != null && mVitOSName != null) {
            int indexOfVersion = mVitOSName.indexOf(mVitOSVersion);
            if (indexOfVersion > 0) {
                mVitOSName = mVitOSName.substring(0, indexOfVersion);
            }
        }
        mClientInfo.setOsVersion(mVitOSVersion);
        mClientInfo.setOsName(mVitOSName);
        mClientInfo.setOsArchitecture(mVitOSArch);
        mClientInfo.setRunTimeVersion(mVitRuntimeVersion);
        mClientInfo.setProxy(mVitProxy);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.SetVersionTracking(): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }


    /**
     * Initializes transaction context.
     *
     * @param HostAddress   String
     * @param HostPort      Integer
     * @param Timeout       Integer
     * @param ProxyAddress  String
     * @param ProxyPort     Integer
     * @param ProxyLogon    String
     * @param ProxyPassword String
     * @param clientInfo    String
     */
    public void initializeContext(String HostAddress, int HostPort, int Timeout, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword, ClientInfo clientInfo) {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.InitializeContext(String,int,int,String,int,String,String): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        try {
            this.mConnection.initializeConnection(HostAddress, HostPort, Timeout, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword);
            if (clientInfo != null) {
                this.setClientInfo(clientInfo);
            } else {
                this.setClientInfo(new ClientInfo());
            }

            this.setVersionTracking();
            this.mConnection.setClientInfo(mClientInfo);
        } catch (Exception ex) {
            ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, ex,
                    PayflowConstants.SEVERITY_ERROR, mPaymentState.getIsXmlPayRequest(),
                    null);
            if (!getPsmContext().isCommunicationErrorContained(err)) {
                getPsmContext().addError(err);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentStateMachine.InitializeContext(String,int,int,String,int,String,String): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
    }

    /**
     * Initialized Transaction.
     *
     * @param paramList String
     * @param requestId String
     */
    public void initTrans(String paramList, String requestId) {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.InitTrans(String,String): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        try {
            this.mConnection.setRequestId(requestId);
            this.mPaymentState = new SendInitState(this.mConnection, paramList, psmContext);
        } catch (Exception ex) {
            ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_CONTXT_INIT_FAILED, ex,
                    PayflowConstants.SEVERITY_ERROR, mPaymentState.getIsXmlPayRequest(),
                    null);
            if (!getPsmContext().isCommunicationErrorContained(err)) {
                getPsmContext().addError(err);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentStateMachine.InitTrans(String,String): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
    }


    /**
     * Executes the transaction.
     *
     * @throws Exception Exception
     */
    public void execute() throws Exception {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.Execute(): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        try {
            if (getPsmContext().getHighestErrorLvl() == PayflowConstants.SEVERITY_FATAL) {
                String trxResponse = mPaymentState.getTransactionResponse();
                String message;
                if (trxResponse != null && trxResponse.length() > 0) {
                    message = trxResponse;
                } else {
                    ArrayList errorList = psmContext.getErrors(PayflowConstants.SEVERITY_FATAL);
                    ErrorObject firstFatalError = (ErrorObject) errorList.get(0);
                    message = firstFatalError.toString();
                }
                mPaymentState.setTransactionFail(message);
            } else {
                mPaymentState.execute();
            }
        } catch (Exception ex) {
            ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, ex, PayflowConstants.SEVERITY_ERROR,
                    mPaymentState.getIsXmlPayRequest(),
                    null);
            if (!getPsmContext().isCommunicationErrorContained(err)) {
                getPsmContext().addError(err);
            }
        } finally {
            // perform state transition
            mPaymentState = getNextState(mPaymentState);
            Logger.getInstance().log("paypal.payflow.PaymentStateMachine.Execute(): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
    }

    /**
     * Changes the Payment States depending upon
     * the current state status.
     *
     * @param currentPmtState PaymentState
     * @return CurrentPmtState PaymentState
     * @throws Exception Exception
     */
    private PaymentState getNextState(PaymentState currentPmtState) throws Exception {
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.GetNextState(PaymentState): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        if (currentPmtState.getSuccess() && currentPmtState.getInProgress()) {
            if (currentPmtState instanceof SendInitState) {
                currentPmtState = new TransactionSendState(currentPmtState);
            } else if (currentPmtState instanceof TransactionSendState) {
                currentPmtState = new TransactionReceiveState(currentPmtState);
            } else if (currentPmtState instanceof SendRetryState) {
                currentPmtState = new SendReconnectState(currentPmtState);
            } else if (currentPmtState instanceof SendReconnectState) {
                currentPmtState = new SendInitState(currentPmtState);
            } else {
                String AddlMessage = "Current State = " + mPaymentState.toString();
                ErrorObject Err = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE,
                        null,
                        PayflowConstants.SEVERITY_FATAL, mPaymentState.getIsXmlPayRequest(),
                        AddlMessage);
                if (!getPsmContext().isCommunicationErrorContained(Err)) {
                    getPsmContext().addError(Err);
                }
            }
        } else if (currentPmtState.getFailed() && currentPmtState.getInProgress()) {
            if (currentPmtState instanceof ReconnectState) {
                if (!getPsmContext().isErrorContained()) {
                    String AddlMessage = "Exceeded Reconnect attempts, check context for error, Current reconnect attempt = " + mPaymentState.getAttemptNo();
                    ErrorObject Err = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP,
                            null,
                            PayflowConstants.SEVERITY_FATAL,
                            mPaymentState.getIsXmlPayRequest(),
                            AddlMessage);
                    if (!getPsmContext().isCommunicationErrorContained(Err)) {
                        getPsmContext().addError(Err);
                    }
                } else {
                    ArrayList ErrList = new ArrayList();
                    ErrList.addAll(getPsmContext().getErrors());
                    int HighestSevLevel = getPsmContext().getHighestErrorLvl();

                    int ErrorListIndex;
                    int ErrorListSize = ErrList.size();
                    for (ErrorListIndex = 0; ErrorListIndex < ErrorListSize; ErrorListIndex++) {
                        ErrorObject Err = (ErrorObject) ErrList.get(ErrorListIndex);
                        if (Err.getSeverityLevel() == HighestSevLevel) {
                            int index;
                            int size = Err.getMessageParams().size();
                            String[] MsgCodeParams = new String[size];
                            for (index = 0; index < size; index++) {
                                MsgCodeParams[index] = (String) Err.getMessageParams().get(index);
                            }

                            ErrorObject Error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, Err.getMessageCode(), MsgCodeParams);
                            ErrList.add(ErrorListIndex, Error);
                            ErrList.remove(ErrorListIndex + 1);
                            break;
                        }
                    }

                    getPsmContext().clearErrors();
                    getPsmContext().addErrors(ErrList);
                }
            } else if (currentPmtState instanceof SendInitState) {
                currentPmtState = new SendReconnectState(currentPmtState);
            } else if (currentPmtState instanceof TransactionSendState) {
                currentPmtState = new SendRetryState(currentPmtState);
            } else if (currentPmtState instanceof TransactionReceiveState) {
                currentPmtState = new SendRetryState(currentPmtState);
            }
            // unknown state
            else {
                String addlMessage = "Current State = " + mPaymentState.toString();
                ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, null,
                        PayflowConstants.SEVERITY_FATAL, mPaymentState.
                                getIsXmlPayRequest(), addlMessage);
                if (!getPsmContext().isCommunicationErrorContained(err)) {
                    getPsmContext().addError(err);
                }
            }
        }

        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.GetNextState(PaymentState): Obtained State = "
                + mPaymentState.getClass(),
                PayflowConstants.SEVERITY_INFO);
        Logger.getInstance().log("paypal.payflow.PaymentStateMachine.GetNextState(PaymentState): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
        return currentPmtState;
    }

}