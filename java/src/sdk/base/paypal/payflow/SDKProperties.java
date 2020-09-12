package paypal.payflow;

import java.io.File;

/**
 * This class is used to set the SDK level properties.
 */
public class SDKProperties {

    private static boolean stackTraceOn = PayflowConstants.TRACE_DEFAULT;
    private static int loggingLevel = PayflowConstants.LOGGING_OFF;
    private static String hostAddress = null;
    private static int timeOut = PayflowConstants.DEFAULT_TIMEOUT;
    private static int hostPort = PayflowConstants.DEFAULT_HOSTPORT;
    private static String logFileName = PayflowConstants.LOG_FILE_NAME;
    private static boolean logFileNameSet = false;
    private static String proxyAddress = null;
    private static int proxyPort = 0;
    private static String proxyLogin = null;
    private static String proxyPassword = null;
    private static int maxLogFileSize = PayflowConstants.DEFAULT_MAX_LOG_FILE_SIZE;
    private static boolean maxlogFileSizeSet = false;

    /**
     * Modified 09/20/06: To retrieve application server specific URLStreamHandler class name using
     * SDKProperties. getURLStreamHandlerClass() [ if set by user code ]. If the handler class is set,
     * the code uses it in the new URL call;
     * Used in PaymentConnection.java
     */
    private static String urlStreamHandlerClass = null;

    /**
     * @return Returns the maxLogFileSize in Bytes.
     */
    public static int getMaxLogFileSize() {
        return maxLogFileSize;
    }

    /**
     * the max log file size in Bytes
     *
     * @param maxLogFileSize The maxLogFileSize to set.
     */
    public static void setMaxLogFileSize(int maxLogFileSize) {
        if (maxLogFileSize > 0) {
            SDKProperties.maxLogFileSize = maxLogFileSize;
            SDKProperties.maxlogFileSizeSet = true;
        }
    }

    /**
     * @return Returns the proxyLogin.
     */
    public static String getProxyLogin() {
        return proxyLogin;
    }

    /**
     * @param proxyLogin The proxyLogin to set.
     */
    public static void setProxyLogin(String proxyLogin) {
        SDKProperties.proxyLogin = proxyLogin;
    }

    /**
     * @return Returns the proxyPassword.
     */
    protected static String getProxyPassword() {
        return proxyPassword;
    }

    /**
     * @param proxyPassword The proxyPassword to set.
     */
    public static void setProxyPassword(String proxyPassword) {
        SDKProperties.proxyPassword = proxyPassword;
    }

    /**
     * @return Returns the proxyPort.
     */
    public static int getProxyPort() {
        return proxyPort;
    }

    /**
     * @param proxyPort The proxyPort to set.
     */
    public static void setProxyPort(int proxyPort) {
        SDKProperties.proxyPort = proxyPort;
    }

    /**
     * @return Returns the stackTraceOn.
     */
    public static boolean isStackTraceOn() {
        return stackTraceOn;
    }

    /**
     * @param stackTraceOn The stackTraceOn to set.
     */
    public static void setStackTraceOn(boolean stackTraceOn) {
        SDKProperties.stackTraceOn = stackTraceOn;
    }

    /**
     * @return Returns the timeOut in seconds.
     */
    public static int getTimeOut() {
        return timeOut;
    }

    /**
     * @param timeOut The timeOut to set in seconds.
     */
    public static void setTimeOut(int timeOut) {
        SDKProperties.timeOut = timeOut;
    }

    /**
     * @return Returns the hostAddress.
     */
    public static String getHostAddress() {
        return hostAddress;
    }

    /**
     * @param hostAddress The hostAddress to set.
     */
    public static void setHostAddress(String hostAddress) {
        SDKProperties.hostAddress = hostAddress;
    }

    /**
     * @return Returns the hostPort.
     */
    public static int getHostPort() {
        return hostPort;
    }

    /**
     * @param hostPort The hostPort to set.
     */
    public static void setHostPort(int hostPort) {
        SDKProperties.hostPort = hostPort;
    }

    /**
     * @return Returns the logFileName.
     */
    public static String getLogFileName() {
        return logFileName;
    }

    /**
     * @param logFileName The logFileName to set.
     */
    public static void setLogFileName(String logFileName) {

        if (null != logFileName && logFileName.length() > 0) {
            if (logFileName.endsWith(File.separator)) {
                SDKProperties.logFileName = logFileName
                        .concat(SDKProperties.logFileName);
            } else {
                SDKProperties.logFileName = logFileName;
            }
            SDKProperties.logFileNameSet = true;
        }
    }

    /**
     * @return Returns the loggingLevel.
     */
    public static int getLoggingLevel() {
        return loggingLevel;
    }

    /**
     * sets the logging level.
     *
     * @param loggingLevel int - Possible values for loggingLevel in descending order:
     *                     <ol >
     *                     <li> PayflowConstants.LOGGING_OFF </li>
     *                     <li> PayflowConstants.SEVERITY_FATAL </li>
     *                     <li> PayflowConstants.SEVERITY_ERROR </li>
     *                     <li> PayflowConstants.SEVERITY_WARN </li>
     *                     <li> PayflowConstants.SEVERITY_INFO </li>
     *                     <li> PayflowConstants.SEVERITY_DEBUG </li>
     *                     </ol>.
     */
    public static void setLoggingLevel(int loggingLevel) {
        if (loggingLevel > 0) {
            SDKProperties.loggingLevel = loggingLevel;
        }
    }

    /**
     * @return Returns the proxyAddress.
     */
    public static String getProxyAddress() {
        return proxyAddress;
    }

    /**
     * @param proxyAddress The proxyAddress to set.
     */
    public static void setProxyAddress(String proxyAddress) {
        SDKProperties.proxyAddress = proxyAddress;
    }

    protected static boolean isLogFileNameSet() {
        return logFileNameSet;
    }

    protected static boolean isMaxlogFileSizeSet() {
        return maxlogFileSizeSet;
    }

    /**
     * Modified 09/20/2006
     *
     * @return Returns the application server specific URLStreamHandler class, if set.
     */
    public static String getURLStreamHandlerClass() {
        return urlStreamHandlerClass;
    }

    /**
     * Modified 09/20/2006
     *
     * @param urlStreamHandlerClass Application server specific urlStreamHandlerClass to set.
     */
    public static void setURLStreamHandlerClass(String urlStreamHandlerClass) {
        SDKProperties.urlStreamHandlerClass = urlStreamHandlerClass;
    }
}
