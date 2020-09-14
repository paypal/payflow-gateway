package paypal.payflow;

/**
 * Used for Payflow Host related information.
 * <P>This class stores the information related to connection to the
 * PayPal payment gateway. If the empty constructor of this class
 * is used to create the object, or
 * passed values are empty, then The following values (if empty) are looked for
 * as follows:
 *
 * Property From Internal Default From SDK Properties
 * Payflow Host - NA - HostAddress
 * Payflow Port- 443 - HostPort
 * Transaction timeout - 45 seconds - NA
 *
 */
public final class PayflowConnectionData extends BaseRequestDataObject {

    private String hostAddress;
    private int hostPort;
    private String proxyAddress;
    private int proxyPort;
    private String proxyLogon;
    private String proxyPassword;
    private int timeOut;

    /**
     * Gets HostAddress. It is PayPal's HostName
     *
     * @return String
     */
    public String getHostAddress() {
        return hostAddress;
    }

    /**
     * Gets the Host port.Port 443 is used.
     *
     * @return int
     */
    public int getHostPort() {
        return hostPort;
    }

    /**
     * Gets Proxy server address. Use the PROXY parameters for servers
     * behind a firewall. Your network administrator can provide the
     * values.
     *
     * @return String
     */
    public String getProxyAddress() {
        return proxyAddress;
    }

    /**
     * Gets the proxy port.
     *
     * @return int
     */
    public int getProxyPort() {
        return proxyPort;
    }

    /**
     * Gets proxy Logon.
     *
     * @return String
     */
    public String getProxyLogon() {
        return proxyLogon;
    }

    /**
     * Gets the proxy password.
     *
     * @return String
     */
    public String getProxyPassword() {
        return proxyPassword;
    }

    /**
     * Gets Time-out period for the transaction. The minimum recommended
     * time-out value is 30 seconds. The client begins tracking
     * from the time that it sends the transaction request to the server.
     *
     * @return int
     */
    public int getTimeOut() {
        return timeOut;
    }

    /**
     * Constructor
     */
    public PayflowConnectionData() {
        this(null, 0, 0, null, 0, null, null);
    }

    /**
     * Constructor
     *
     * @param HostAddress String
     */
    public PayflowConnectionData(String HostAddress) {
        this(HostAddress, 0, 0, null, 0, null, null);
    }

    /**
     * Constructor
     *
     * @param HostAddress String
     * @param HostPort    Integer
     * @param Timeout     Integer
     */
    public PayflowConnectionData(String HostAddress, int HostPort, int Timeout) {
        this(HostAddress, HostPort, Timeout, null, 0, null, null);
    }

    /**
     * Constructor
     *
     * @param HostAddress   String
     * @param HostPort      Integer
     * @param TimeOut       Integer
     * @param ProxyAddress  String
     * @param ProxyPort     Integer
     * @param ProxyLogon    String
     * @param ProxyPassword String
     */
    public PayflowConnectionData(String HostAddress, int HostPort, int TimeOut, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword) {
        if (getContext() == null) {
            this.setContext(new Context());
        }

        hostAddress = HostAddress;
        hostPort = HostPort;
        timeOut = TimeOut;
        proxyAddress = ProxyAddress;
        proxyPort = ProxyPort;
        proxyLogon = ProxyLogon;
        proxyPassword = ProxyPassword;
        this.initSDKProperties();
    }

    /**
     * Constructor
     *
     * @param HostAddress String
     * @param HostPort    Integer
     */
    public PayflowConnectionData(String HostAddress, int HostPort) {
        this(HostAddress, HostPort, 0, null, 0, null, null);
    }

    /**
     * Constructor
     *
     * @param HostAddress   String
     * @param HostPort      Integer
     * @param ProxyAddress  String
     * @param ProxyPort     Integer
     * @param ProxyLogon    String
     * @param ProxyPassword String
     */
    public PayflowConnectionData(String HostAddress, int HostPort, String ProxyAddress, int ProxyPort, String ProxyLogon, String ProxyPassword) {
        this(HostAddress, HostPort, 0, ProxyAddress, ProxyPort, ProxyLogon, ProxyPassword);
    }

    /**
     * For any value not passed in the constructor the values being set in the properties will be used.
     */
    private void initSDKProperties() {
        Logger.getInstance().log("paypal.payflow.PayflowConnectionData.initSDKProperties(): Entered", PayflowConstants.SEVERITY_DEBUG);
        if (timeOut == 0) {
            timeOut = SDKProperties.getTimeOut();
        }
        if (hostPort == 0) {
            hostPort = SDKProperties.getHostPort();
        }
        if (null == hostAddress || hostAddress.trim().length() == 0) {
            hostAddress = SDKProperties.getHostAddress();
            if (null == hostAddress || hostAddress.trim().length() == 0) {
                String RespMessage = PayflowConstants.PARAM_RESULT
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorCodes.get(PayflowConstants.E_INIT_ERROR)
                        + PayflowConstants.DELIMITER_NVP
                        + PayflowConstants.PARAM_RESPMSG
                        + PayflowConstants.SEPARATOR_NVP
                        + PayflowConstants.CommErrorMessages.get(PayflowConstants.E_INIT_ERROR)
                        + "host Address has not been initialised. Please make sure it is being set.";

                ErrorObject error = new ErrorObject(PayflowConstants.SEVERITY_FATAL, PayflowConstants.EMPTY_STRING, RespMessage);
                getContext().addError(error);
            }
        }

        if (proxyPort == 0) {
            proxyPort = SDKProperties.getProxyPort();
        }
        if (null == proxyAddress || proxyAddress.trim().length() == 0) {
            proxyAddress = SDKProperties.getProxyAddress();
            if (null == proxyAddress) {
                proxyAddress = PayflowConstants.EMPTY_STRING;
            }
        }
        if (null == proxyLogon || proxyLogon.trim().length() == 0) {
            proxyLogon = SDKProperties.getProxyLogin();
            if (null == proxyLogon) {
                proxyLogon = PayflowConstants.EMPTY_STRING;
            }
        }
        if (null == proxyPassword || proxyPassword.trim().length() == 0) {
            proxyPassword = SDKProperties.getProxyPassword();
            if (null == proxyPassword) {
                proxyPassword = PayflowConstants.EMPTY_STRING;
            }
        }
        Logger.getInstance().log("paypal.payflow.PayflowConnectionData.initSDKProperties(): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }
}

