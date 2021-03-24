package paypal.payflow;


import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.SocketException;
import java.net.*;
import java.util.*;
import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.*;
import java.util.Base64;

/**
 * This is the Connection Class.
 */
final class PaymentConnection {

    /**
     * Holds whether transaction is
     * with or without proxy.
     */
    private boolean mIsProxy = false;

    /**
     * Payflow Host Address
     */
    private String mHostAddress;

    /**
     * Payflow Host Port
     */
    private int mHostPort;

    /**
     * Payflow Server Uri object.
     */
    private URL mServerUri;

    /**
     * Connection object.
     */
    private HttpsURLConnection mServerConnection;

    /**
     * Proxy Address.
     */
    private String mProxyAddress;

    /**
     * Proxy Port
     */
    private int mProxyPort;

    /**
     * Proxy Logon Id
     */
    private String mProxyLogon;

    /**
     * Proxy Password
     */
    private String mProxyPassword;

    /**
     * Connection Timeout Value.
     */
    private long mConnectionTimeout = PayflowConstants.DEFAULT_TIMEOUT;

    /**
     * Transaction start time.
     */
    private long mStartTime;

    /**
     * Request Id
     */
    private String mRequestId;

    /**
     * Param List Content Type
     */
    private String mContentType;

    /**
     * Flag for XmlPay Request Type.
     */
    private boolean mIsXmlPayRequest;

    /**
     * Context object.
     */
    private Context mContext;

    /**
     * Status of proxy connection.
     * False if proxy host address is  not parsed successfully.
     */
    private boolean mProxyStatus = true;
    private ClientInfo mClientInfo;

//	private URL uri = null;

    private HashMap mHeaders = new HashMap();

    /**
     * Gets whether transaction
     * is with or without proxy.
     *
     * @return mIsProxy
     */
    public boolean getIsProxy() {
        return mIsProxy;
    }

    /**
     * Gets, Sets the param list
     * content type.
     *
     * @return mContentType
     */
    public String getContentType() {
        return mContentType;
    }

    /**
     * @param value String
     */
    public void setContentType(String value) {
        mContentType = value;
    }

    /**
     * Gets, Sets Request Id.
     *
     * @return mRequestId
     */
    public String getRequestId() {
        return mRequestId;
    }

    /**
     * sets the requestId
     *
     * @param value String
     */
    public void setRequestId(String value) {
        mRequestId = value;
    }

    /**
     * Gets the StartTime of the
     * transaction.
     *
     * @return mStartTime
     */
    public long getStartTime() {
        if (mStartTime == 0) {
            initTransactionStartTime();
        }
        return mStartTime;
    }

    /**
     * Gets, Sets the timeout
     * value of transaction.
     *
     * @return mConnectionTimeout long
     */
    public long getTimeout() {
        return mConnectionTimeout;
    }

    /**
     * @param value long
     */
    public void setTimeout(long value) {
        mConnectionTimeout = value;
    }

    /**
     * @return ConnContext Context
     */
    public Context getConnContext() {
        return mContext;
    }

    /**
     * @return isXmlPayRequest boolean
     */
    public boolean getIsXmlPayRequest() {
        return mIsXmlPayRequest;
    }

    /**
     * @param value boolean
     */
    public void setIsXmlPayRequest(boolean value) {
        mIsXmlPayRequest = value;
    }

    /**
     * @param value ClientInfo
     */
    public void setClientInfo(ClientInfo value) {
        mClientInfo = value;
    }

    /**
     * Constructor for PaymentConnection.
     *
     * @param psmContext Context
     */
    public PaymentConnection(Context psmContext) {
        mContext = psmContext;
    }

    /**
     *
     */
    private void initTransactionStartTime() {
        mStartTime = new Date().getTime();
    }

    /**
     * Returns a string representation of stacktrace
     *
     * @param e Exception
     * @return ostr.toString
     */
    private String getStackTraceAsString(Exception e) {
        java.io.ByteArrayOutputStream ostr = new java.io.ByteArrayOutputStream();
        e.printStackTrace(new java.io.PrintStream(ostr));
        return (ostr.toString());
    }

    /**
     * -
     * initialises the host
     *
     * @param hostAddress String
     * @param hostPort    int
     * @param timeout     int
     */
    private void initializeHost(String hostAddress, int hostPort, int timeout) {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeHost(String,int,int): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        if (hostAddress != null && hostAddress.length() > 0) {
            mHostAddress = hostAddress;
            Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeHost(String,int,int): HostAddress = " + mHostAddress,
                    PayflowConstants.SEVERITY_INFO);
        } else {
            ErrorObject nullHostError = PayflowUtility.populateCommError(PayflowConstants.E_NULL_HOST_STRING, null,
                    PayflowConstants.SEVERITY_FATAL, getIsXmlPayRequest(),
                    null);
            if (!getConnContext().isCommunicationErrorContained(nullHostError)) {
                getConnContext().addError(nullHostError);
            }
        }

        mHostPort = hostPort;
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeHost(String,int,int): HostPort = " + mHostPort,
                PayflowConstants.SEVERITY_INFO);
        mConnectionTimeout = timeout;
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeHost(String,int,int): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param proxyAddress  String
     * @param proxyPort     int
     * @param proxyLogon    String                  *5
     * @param proxyPassword String
     */
    private void initializeProxy(String proxyAddress, int proxyPort, String proxyLogon, String proxyPassword) {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeProxy(String,int,String, String): Entered", PayflowConstants.SEVERITY_DEBUG);

        mProxyAddress = proxyAddress;
        mProxyPort = proxyPort;
        mProxyLogon = proxyLogon;
        mProxyPassword = proxyPassword;


        if (mProxyAddress != null && mProxyAddress.length() > 0 && mProxyPort > 0) {
            mIsProxy = true;
        }
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitializeProxy(String,int,String, String): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Initializes Connection from Connection Attributes.
     *
     * @param hostAddress   String
     * @param hostPort      int
     * @param timeout       int
     * @param proxyAddress  String
     * @param proxyPort     int
     * @param proxyLogon    String (null if NA)
     * @param proxyPassword String (null if NA)
     */
    public void initializeConnection(String hostAddress, int hostPort,
                                     int timeout, String proxyAddress, int proxyPort,
                                     String proxyLogon, String proxyPassword) {
        initializeHost(hostAddress, hostPort, timeout);
        initializeProxy(proxyAddress, proxyPort, proxyLogon, proxyPassword);
    }

    /**
     * initializes the serverUri object from the available connection attributes
     */
    private void initServerUri() {

        String classname = SDKProperties.getURLStreamHandlerClass();

        try {
            String HostAddress;
            HostAddress = mHostAddress;
            Logger.getInstance().log("paypal.payflow.PaymentConnection.InitServerUri(String): URLStreamHandlerClass: " + classname,
                    PayflowConstants.SEVERITY_DEBUG);
            if (classname != null && classname.length() > 0) {
                URLStreamHandler Handler = (URLStreamHandler) Class.forName(classname).newInstance();
                mServerUri = new URL(null, "https://" + HostAddress + ":" + mHostPort, Handler);
            } else {
                mServerUri = new URL(null, "https://" + HostAddress + ":" + mHostPort);
            }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.InitServerUri(String): Caught Exception: " + getStackTraceAsString(ex),
                    PayflowConstants.SEVERITY_FATAL);
        }
    }

    /**
     * Initializes Proxy Object from available proxy information.
     */
    private void initProxyInfo() {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitProxyInfo(): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        if (mIsProxy) {
            try {
                String pStr = mProxyLogon + ":" + mProxyPassword;
                String auth = "Basic" + " " + Base64.getEncoder().encodeToString(pStr.getBytes());
                mServerConnection.setRequestProperty("Proxy-Authorization", auth);
            } catch (Exception ex) {
                Logger.getInstance().log("paypal.payflow.PaymentConnection.InitProxyInfo(): Caught Exception: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_FATAL);
                String addlMessage = "";
                ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_SOK_CONN_FAILED, ex,
                        PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                        addlMessage);
                if (!getConnContext().isCommunicationErrorContained(initError)) {
                    getConnContext().addError(initError);
                }
            }
        }
        Logger.getInstance().log("paypal.payflow.PaymentConnection.InitProxyInfo(): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Initializes all the connection attributes and creates the connection.
     */
    private void createConnection() {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.CreateConnection(): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        try {
            if (getIsProxy()) {
                if (mIsProxy) {
                    // Add TLS 1.2 support - tsieber 03/17/2017
                    SSLContext sc = SSLContext.getInstance("TLSv1.2");
                    // Init the SSLContext with a TrustManager [] and SecureRandom ()
                    sc.init(null, null, new java.security.SecureRandom());
                    Proxy proxy = new Proxy(Proxy.Type.HTTP, new InetSocketAddress(mProxyAddress, mProxyPort));
                    mServerConnection = (HttpsURLConnection) mServerUri.openConnection(proxy);
                    mServerConnection.setSSLSocketFactory(sc.getSocketFactory());
                    Logger.getInstance().log("paypal.payflow.PaymentConnection.createConnection(String): Initialized. Using Proxy.",
                            PayflowConstants.SEVERITY_INFO);
                }
            } else {
                SSLContext sc = SSLContext.getInstance("TLSv1.2");
                // Init the SSLContext with a TrustManager [] and SecureRandom ()
                sc.init(null, null, new java.security.SecureRandom());
                mServerConnection = (HttpsURLConnection) mServerUri.openConnection();
                mServerConnection.setSSLSocketFactory(sc.getSocketFactory());

                Logger.getInstance().log("paypal.payflow.PaymentConnection.createConnection(String): Initialized.",
                        PayflowConstants.SEVERITY_INFO);
            }
            Logger.getInstance().log("paypal.payflow.PaymentConnection.createConnection(String): openConnection = " +
                    mServerConnection, PayflowConstants.SEVERITY_INFO);

            mServerConnection.setDoOutput(true);
            mServerConnection.setDoInput(true);
            mServerConnection.setRequestMethod("POST");

            if (getIsXmlPayRequest()) {
                mServerConnection.setRequestProperty("Content-Type", PayflowConstants.CONTENT_TYPE_XML);
                mHeaders.put("Content-Type", PayflowConstants.CONTENT_TYPE_XML);
            } else {
                mServerConnection.setRequestProperty("Content-Type", PayflowConstants.CONTENT_TYPE_NAMEVALUE);
                mHeaders.put("Content-Type", PayflowConstants.CONTENT_TYPE_NAMEVALUE);
            }

            mServerConnection.setRequestProperty("User-Agent", PayflowConstants.USER_AGENT);
            mServerConnection.setRequestProperty(PayflowConstants.PAYFLOWHEADER_REQUEST_ID, mRequestId);
            mServerConnection.setRequestProperty(PayflowConstants.PAYFLOWHEADER_TIMEOUT, Long.toString(mConnectionTimeout / 1000));
            mServerConnection.setRequestProperty("Keep-Alive", "false");
            mServerConnection.setRequestProperty("Connection", "close");
            mServerConnection.setUseCaches(false);
            mServerConnection.setInstanceFollowRedirects(false);
            //to print the header values
            mHeaders.put("User-Agent", PayflowConstants.USER_AGENT);
            mHeaders.put(PayflowConstants.PAYFLOWHEADER_REQUEST_ID, mRequestId);
            mHeaders.put(PayflowConstants.PAYFLOWHEADER_TIMEOUT, Long.toString(mConnectionTimeout / 1000));
            mHeaders.put("Keep-Alive", "false");
            if (getIsProxy()) {
                if (mIsProxy) {
                    initProxyInfo();
                }
            }

            //Add VIT Headers
            if (mClientInfo != null) {
                //Get the Hash map.
                Hashtable clientInfoHash = mClientInfo.getClientInfoHash();
                if (clientInfoHash != null && clientInfoHash.size() > 0) {
                    //Iterate through the hash map to add the appropriate headers.
                    for (int i = 0; i < clientInfoHash.size(); i++) {
                        Collection headerKeyValue = clientInfoHash.values();
                        Object valueObj[] = headerKeyValue.toArray();
                        if (valueObj != null) {
                            ClientInfoHeader currHeader = (ClientInfoHeader) valueObj[i];
                            String hdrName = currHeader.getHeaderName();
                            Object hdrValueObj = currHeader.getHeaderValue();
                            String hdrValueStr = null;
                            //Check if Header name is non-null, non-empty string.
                            boolean validHeaderName = (hdrName != null && hdrName.length() > 0);
                            boolean validHeaderValue = (hdrValueObj != null);
                            //Check if Header value object is non-null, object.
                            if (validHeaderValue) {
                                hdrValueStr = currHeader.getHeaderValue().toString();
                                //Check if the header value is non-null, non-empty.
                                validHeaderValue = (hdrValueStr != null && hdrValueStr.length() > 0);
                            }
                            //Valid header is Valid Header Name and Valid header value.
                            if (validHeaderName && validHeaderValue) {
                                mServerConnection.setRequestProperty(hdrName, hdrValueStr);
                                mHeaders.put(hdrName, hdrValueStr);
                            }
                        }
                    }
                }
            }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.CreateConnection(): Caught Exception creating connection: " + getStackTraceAsString(ex),
                    PayflowConstants.SEVERITY_FATAL);
            String addlMessage = "Input Server Uri= " + mServerUri.getProtocol() + "://" + mServerUri.getHost() + ":" + mServerUri.getPort();
            ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_SOK_CONN_FAILED, ex,
                    PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                    addlMessage);
            if (!getConnContext().isCommunicationErrorContained(initError)) {
                getConnContext().addError(initError);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.CreateConnection(): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
    }

    /**
     * @param serverFile String
     * @return retVal boolean
     */
    public boolean connectToServer(String serverFile) {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        boolean retVal = true;

        try {
            //Initialize Server Uri.
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Initializing Server Uri.",
                    PayflowConstants.SEVERITY_INFO);
            initServerUri();
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Initialized Server Uri = "
                            + mServerUri.getProtocol() + "://" + mServerUri.getHost() + ":" + mServerUri.getPort(),
                    PayflowConstants.SEVERITY_INFO);
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Initializing Connection Attributes.",
                    PayflowConstants.SEVERITY_INFO);
            createConnection();
            if (mServerConnection != null) {
                if (mProxyStatus) {
                    retVal = true;
                    Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Connection Created.",
                            PayflowConstants.SEVERITY_INFO);
                } else {
                    retVal = false;
                    Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Connection Creation Failure: Incorrect Proxy Details.",
                            PayflowConstants.SEVERITY_INFO);
                }

            } else {
                retVal = false;
                Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Connection Creation Failure.",
                        PayflowConstants.SEVERITY_INFO);
            }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Caught Exception: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_FATAL);
            String addlMessage = "Input Server Uri = " + mServerUri.getProtocol() + "://" + mServerUri.getHost() + ":" + mServerUri.getPort();
            ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_SOK_CONN_FAILED, ex,
                    PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                    addlMessage);
            if (!getConnContext().isCommunicationErrorContained(initError)) {
                getConnContext().addError(initError);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ConnectToServer(String): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
        return retVal;
    }

    /**
     * Sends the request to the server.
     *
     * @param request String
     * @return true if success false otherwise
     */
    public boolean sendToServer(String request) {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.SendToServer(String): Entered",
                PayflowConstants.SEVERITY_DEBUG);

        boolean retVal = false;

        try {
            mServerConnection.connect();
            if (request != null) {
                byte[] paramListBytes = request.getBytes();
                OutputStream reqStram = mServerConnection.getOutputStream();
                Map loggableHeaders = new HashMap();
                reqStram.write(paramListBytes);
                reqStram.close();
                loggableHeaders.putAll(mHeaders);
                Iterator iter = loggableHeaders.keySet().iterator();
                String key;
                //Dump the headers to the log file
                Logger.getInstance().log("paypal.payflow.PaymentConnection.sendToServer(String request): Headers ",
                        PayflowConstants.SEVERITY_DEBUG);
                while (iter.hasNext()) {
                    StringBuffer headerLog = new StringBuffer();
                    key = iter.next().toString();
                    headerLog.append("HTTP Header : Name = ")
                            .append(key)
                            .append(" | value = ")
                            .append(loggableHeaders.get(key));
                    Logger.getInstance().log("paypal.payflow.PaymentConnection.sendToServer(String request): " + headerLog.toString()
                            , PayflowConstants.SEVERITY_DEBUG);
                }
                //Added VIT Headers to the http request.
                retVal = true;
            } else {
                ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null,
                        PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                        null);
                if (!getConnContext().isCommunicationErrorContained(initError)) {
                    getConnContext().addError(initError);
                }
            }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.SendToServer(String): Caught Exception: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_FATAL);
            String addlMessage = "Input Server Uri = " + mServerUri.getProtocol() + "://" + mServerUri.getHost() + ":" + mServerUri.getPort();
            ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_SOK_CONN_FAILED,
                    ex,
                    PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                    addlMessage);
            if (!getConnContext().isCommunicationErrorContained(initError)) {
                getConnContext().addError(initError);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.SendToServer(String): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
        return retVal;
    }

    /**
     * Receives the transaction response from the server.
     *
     * @return response
     */
    public String receiveResponse() {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.ReceiveResponse(): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        String response = PayflowConstants.EMPTY_STRING;

        try {

            InputStream serverResponse;
            serverResponse = mServerConnection.getInputStream();
            byte[] data = readInputBytes(serverResponse, mServerConnection.getContentLength());
            response = new String(data);
            serverResponse.close();
            disconnect();

        } catch (SocketException ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ReceiveResponse(): Caught SocketException: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_ERROR);
            //Need to put a blank handler for this since there is a problem since the
            //httpurlconnection keeps giving "unexpected end of file" exception intermittently
        } catch (IOException ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ReceiveResponse(): Caught IOException: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_ERROR);
            //Need to put a blank handler for this since there is a problem since the
            //httpurlconnection keeps giving "unexpected end of file" exception intermittently
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ReceiveResponse(): Caught Exception: " + getStackTraceAsString(ex), PayflowConstants.SEVERITY_ERROR);

            String addlMessage = "Input Server Uri = " + mServerUri.getProtocol() + "://" + mServerUri.getHost() + ":" + mServerUri.getPort();

            ErrorObject initError = PayflowUtility.populateCommError(PayflowConstants.E_TIMEOUT_WAIT_RESP,
                    ex,
                    PayflowConstants.SEVERITY_ERROR, getIsXmlPayRequest(),
                    addlMessage);
            if (!getConnContext().isCommunicationErrorContained(initError)) {
                getConnContext().addError(initError);
            }
        } finally {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.ReceiveResponse(): Exiting",
                    PayflowConstants.SEVERITY_DEBUG);
        }
        return response;
    }

    public void disconnect() {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.Disconnect(): Entered",
                PayflowConstants.SEVERITY_DEBUG);
        try {
            if (mServerConnection != null) {
                mServerConnection.disconnect();
                mServerConnection = null;
                }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PaymentConnection.Disconnect(): Caught Exception: " + getStackTraceAsString(ex),
                    PayflowConstants.SEVERITY_FATAL);
        }
        Logger.getInstance().log("paypal.payflow.PaymentConnection.Disconnect(): Exiting",
                PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @param in       InputStream
     * @param totalLen int
     * @return data byte[]
     * @throws IOException Exception
     */
    private byte[] readInputBytes(InputStream in, int totalLen)
            throws IOException {
        Logger.getInstance().log("paypal.payflow.PaymentConnection.readInputBytes(InputStream,int) : Entered",
                PayflowConstants.SEVERITY_DEBUG);
        byte[] data;

        if (totalLen >= 0) {
            data = new byte[totalLen];
            for (int offset = 0; offset < totalLen; ) {
                offset += in.read(data, offset, totalLen - offset);
            }
        } else {
            ByteArrayOutputStream out = new ByteArrayOutputStream();
            while (true) {
                int c = in.read();
                if (c < 0) break;
                out.write(c);
            }
            data = out.toByteArray();
        }
        Logger.getInstance().log("paypal.payflow.PaymentConnection.readInputBytes(InputStream,int) : Exiting",
                PayflowConstants.SEVERITY_DEBUG);
        return data;
    }
}