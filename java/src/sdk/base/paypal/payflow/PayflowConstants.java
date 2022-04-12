package paypal.payflow;

import java.util.Hashtable;

/**
 * PayflowConstants class contains all the global constants used throughout the SDK.
 */
public final class PayflowConstants {
    /**
     * Private constructor for PayflowConstants
     */
    private PayflowConstants() {
    }

    /**
     * Empty String can reuse this.
     */
    protected static final String EMPTY_STRING = "";

    /**
     * NVP Delimiter (ampersand)
     */
    protected static final String DELIMITER_NVP = "&";

    /**
     * NVP Opening Brace ([)
     */
    protected static final String OPENING_BRACE_NVP = "[";
    /**
     * NVP Closing Brace (])
     */
    protected static final String CLOSING_BRACE_NVP = "]";
    /**
     * NVP Separator (=)
     */
    protected static final String SEPARATOR_NVP = "=";
    /**
     * Numeric values initialize
     */
    protected static final long INVALID_NUMBER = -384783;
    /**
     * Xml Pay Param Result
     */
    protected static final String XML_PARAM_RESULT = "Result";
    /**
     * Xml Pay param Message
     */
    protected static final String XML_PARAM_MESSAGE = "Message";
    /**
     * Default Timeout in seconds (45 sec)
     */
    protected static final int DEFAULT_TIMEOUT = 45;
    /**
     * Default Payflow Host port (443)
     */
    protected static final int DEFAULT_HOSTPORT = 443;
    /**
     * SDK Client Type (J -- JAVA)
     */
    protected static final String CLIENT_TYPE = "J";
    /**
     * SDK Client Version (5000 -- V5 protocol)
     */
    protected static final String CLIENT_VERSION = "501";    // <<<<< UPDATE VERSION AS NEEDED
    /**
     * SDK User Agent (Java SDK)
     */
    protected static final String USER_AGENT = "Payflow SDK for Java";
    /**
     * Payflow Request types
     */
    protected static final String WEAK_ASSEMBLY = "Weak";
    /**
     * Payflow Request types
     */
    protected static final String STRONG_ASSEMBLY = "Strong";
    /**
     * Maximum retry attempts (3)
     */
    protected static final int MAX_RETRY = 3;
    /**
     * XmlPay ID
     */
    protected static final String XML_ID = "<XMLPayRequest";
    /**
     * XmlPay Response ID
     */
    protected static final String XML_RESP_ID = "<XMLPayResponse";
    /**
     * XML Content Type (text/xml)
     */
    protected static final String XML_CONTENT_TYPE = "text/xml";
    /**
     * Name value Content Type (text/namevalue)
     */
    protected static final String NV_CONTENT_TYPE = "text/namevalue";
    /**
     * XML Pay namespace (http://www.paypal.com/XMLPay)
     */
    protected static final String XMLPAY_NAMESPACE = "http://www.paypal.com/XMLPay";
    /**
     * XML Pay request tag (XMLPayRequest)
     */
    protected static final String XMLPAY_REQUEST_TAG = "XMLPayRequest";
    /**
     * Default Logger file Name
     */
    protected static final String LOG_FILE_NAME = "payflow_java_sdk.log";
    /**
     * Payflow server Transaction file path (transaction)
     */
    // 04/23/07 Removed path "transaction" TS
    protected static final String PAYFLOW_SERVER_TRANSACTION_PATH = "";
    /**
     * Error Message static finalant for null or blank param (MSG_1001)
     */
    protected static final String MSG_PARAM_NULL_BLANK = "MSG_1001";
    /**
     * Error Message static finalant for invalid minmax length of param (MSG_1002)
     */
    protected static final String MSG_INVALID_LENGTH_MINMAX = "MSG_1002";
    /**
     * Error Message static finalant for empty param (MSG_1003)
     */
    protected static final String MSG_PARAM_EMPTY = "MSG_1003";
    /**
     * Error Message static finalant for invalid exact length of param (MSG_1004)
     */
    protected static final String MSG_INVALID_LENGTH_EXACT = "MSG_1004";
    /**
     * Delay before each retry
     */
    protected static final long RETRY_DELAY = 1000;
    /**
     * Error Message static finalant for invalid param (MSG_1005)
     */
    protected static final String MSG_PARAM_NOT_VALID = "MSG_1005";
    /**
     * Error Message static finalant for invalid date (MSG_1006)
     */
    protected static final String MSG_INVALID_DATE = "MSG_1006";
    /**
     * Error Message static finalant for invalid month (MSG_1007)
     */
    protected static final String MSG_INVALID_MONTH = "MSG_1007";
    /**
     * Error Message static finalant for invalid greater value of param (MSG_1008)
     */
    protected static final String MSG_INVALID_VALUE_GREATER = "MSG_1008";
    /**
     * Error Message static finalant for non negative value of param (MSG_1009)
     */
    protected static final String MSG_NONNEGATIVE = "MSG_1009";
    /**
     * Error Message static finalant for invalid exact value param (MSG_1010)
     */
    protected static final String MSG_PARAM_INVALID_EXACT = "MSG_1010";
    /**
     * Error Message static finalant for invalid year (MSG_1011)
     */
    protected static final String MSG_INVALID_YEAR_LESS = "MSG_1011";
    /**
     * Error Message static finalant for communication error (MSG_1012)
     */
    protected static final String MSG_COMMUNICATION_ERROR = "MSG_1012";
    /**
     * Error Message static finalant for communication error xml pay (MSG_1005)
     */
    protected static final String MSG_COMMUNICATION_ERROR_XMLPAY = "MSG_1013";
    /**
     * Error Message static finalant for communication error (MSG_1012)
     */
    protected static final String MSG_COMMUNICATION_ERROR_NO_RESPONSE_ID = "MSG_1015";
    /**
     * Error Message static finalant for communication error xml pay (MSG_1005)
     */
    protected static final String MSG_COMMUNICATION_ERROR_XMLPAY_NO_RESPONSE_ID = "MSG_1016";
    /**
     * Check type Personal (P)
     */
    protected static final String CHECK_TYPE_PERSONEL = "P";
    /**
     * Check type Corporate (C)
     */
    protected static final String CHECK_TYPE_CORPORATE = "C";
    /**
     * Communication Error Codes
     */
    protected static Hashtable CommErrorCodes = PopulateErrorCodes();
    /**
     * Communication Error Messages
     */
    protected static Hashtable CommErrorMessages = PopulateErrorMessages();

    /**
     * Populates Error code hash table
     *
     * @return ErrorCodeTable
     */
    private static Hashtable PopulateErrorCodes() {
        Hashtable ErrorCodeTable = new Hashtable();
        ErrorCodeTable.put(E_SOK_CONN_FAILED, "-1");
        ErrorCodeTable.put(E_PARM_NAME, "-6");
        ErrorCodeTable.put(E_PARM_NAME_LEN, "-7");
        ErrorCodeTable.put(E_TIMEOUT_WAIT_RESP, "-12");
        ErrorCodeTable.put(E_NULL_HOST_STRING, "-23");
        ErrorCodeTable.put(E_INVALID_TIMEOUT, "-30");
        ErrorCodeTable.put(E_UNEXPECTED_REQUEST_ID, "-40");
        ErrorCodeTable.put(E_MISSING_SERVER_RESPONSE_ID, "-44");
        ErrorCodeTable.put(E_MISSING_REQUEST_ID, "-41");
        ErrorCodeTable.put(E_EMPTY_PARAM_LIST, "-100");
        ErrorCodeTable.put(E_CONTXT_INIT_FAILED, "-103");
        ErrorCodeTable.put(E_UNKNOWN_STATE, "-104");
        ErrorCodeTable.put(E_INVALID_NVP, "-105");
        ErrorCodeTable.put(E_UNEXPECTED_RESPONSE_ID, "-43");
        ErrorCodeTable.put(E_RESPONSE_FORMAT_ERROR, "-106");
        ErrorCodeTable.put(E_VERSION_NOT_SUPPORTED, "-107");
        ErrorCodeTable.put(E_INIT_ERROR, "-109");
        ErrorCodeTable.put(E_CURRENCY_PROCESS_ERROR, "-113");
        ErrorCodeTable.put(E_INVALID_TRANSACTION_REQUEST, "-114");
        return ErrorCodeTable;
    }

    /**
     * Populates Message code hash table
     *
     * @return ErrorMessageTable
     */
    protected static Hashtable PopulateErrorMessages() {
        Hashtable ErrorMessageTable = new Hashtable();
        ErrorMessageTable.put(E_SOK_CONN_FAILED, "Failed to connect to host");
        ErrorMessageTable.put(E_PARM_NAME, "Parameter list format error: & in name");
        ErrorMessageTable.put(E_PARM_NAME_LEN, "Parameter list format error: invalid [] name length clause");
        ErrorMessageTable.put(E_TIMEOUT_WAIT_RESP, "Timeout waiting for response");
        ErrorMessageTable.put(E_NULL_HOST_STRING, "Host put ress not specified");
        ErrorMessageTable.put(E_INVALID_TIMEOUT, "Invalid timeout value");
        ErrorMessageTable.put(E_UNEXPECTED_REQUEST_ID, "Unexpected Request ID found in request");
        ErrorMessageTable.put(E_MISSING_SERVER_RESPONSE_ID, "Response ID not found in the response received from the Server");
        ErrorMessageTable.put(E_MISSING_REQUEST_ID, "Required Request ID not found in request.");
        ErrorMessageTable.put(E_EMPTY_PARAM_LIST, "Parameter List cannot be empty");
        ErrorMessageTable.put(E_CONTXT_INIT_FAILED, "Context Initialization failed");
        ErrorMessageTable.put(E_UNKNOWN_STATE, "Unexpected transaction state");
        ErrorMessageTable.put(E_INVALID_NVP, "Invalid name value pair request");
        ErrorMessageTable.put(E_UNEXPECTED_RESPONSE_ID, "Unexpected Response ID found in request");
        ErrorMessageTable.put(E_RESPONSE_FORMAT_ERROR, "Invalid response format");
        ErrorMessageTable.put(E_VERSION_NOT_SUPPORTED, "This XMLPay Version is not supported");
        ErrorMessageTable.put(E_INIT_ERROR, INIT_ERROR);
        ErrorMessageTable.put(E_INVALID_TRANSACTION_REQUEST, "The transaction request is invalid");
        ErrorMessageTable.put(E_CURRENCY_PROCESS_ERROR, "Unable to round and truncate the currency value simultaneously. You can set only one of the two properties Round OR Truncate in the Data Object Currency.");
        return ErrorMessageTable;
    }

    /**
     * Http Header PAYFLOW-Request-ID
     */
    protected static final String PAYFLOWHEADER_REQUEST_ID = "X-VPS-Request-ID";

    /**
     * Http Header PAYFLOW-CLIENT-TIMEOUT
     */
    protected static final String PAYFLOWHEADER_TIMEOUT = "X-VPS-CLIENT-TIMEOUT";

    /**
     * Holds the name of the key in the message file that holds the message code.
     */
    protected static final String MESSAGE_ID = "Id";
    /**
     * Holds the name of the key in the message file that holds the message body.
     */
    protected static final String MESSAGE_BODY = "Body";
    /**
     * Holds the name of the key in the message file that holds the message severity.
     */
    protected static final String MESSAGE_SEVERITY = "Severity";

    /**
     * Tag for TRACE in config file
     */
    protected static final boolean TRACE_DEFAULT = false;

    /**
     * Severity for a FATAL level message.
     */
    protected static final String ERROR_FATAL = "FATAL";
    /**
     * Severity for a ERROR level message.
     */
    protected static final String ERROR_ERROR = "ERROR";
    /**
     * Severity for a WARN level message.
     */
    protected static final String ERROR_WARN = "WARN";
    /**
     * Severity for a INFO level message.
     */
    protected static final String ERROR_INFO = "INFO";
    /**
     * Severity for a DEBUG level message.
     */
    protected static final String ERROR_DEBUG = "DEBUG";

    /**
     * Logging Level level OFF no logging at this level.
     */
    public static final int LOGGING_OFF = 6;
    /**
     * Severity for a FATAL level message.
     */
    public static final int SEVERITY_FATAL = 5;
    /**
     * Severity for a ERROR level message.
     */
    public static final int SEVERITY_ERROR = 4;
    /**
     * Severity for a WARN level message.
     */
    public static final int SEVERITY_WARN = 3;
    /**
     * Severity for a INFO level message.
     */
    public static final int SEVERITY_INFO = 2;
    /**
     * Severity for a DEBUG level message.
     */
    public static final int SEVERITY_DEBUG = 1;
    /**
     * represents any error occurring due to improper initialisation of system level properties
     */
    protected static final String INIT_ERROR = "The following error occurred while initialising : ";

    /**
     * Represents the description for error if the message file is not available
     * in the location mentioned in the config file.
     */
    protected static final String MESSAGE_FILE_NOT_FOUND = "XML File {0} does not exist";

    /**
     * Represents the description for error if the format of the message file is incorrect.
     */
    protected static final String MESSAGE_FILE_PARSING_ERROR =
            "Error occurred while parsing the XML file and creating the sorted list";
    /**
     * Represents the description for error if the body for a message code is not found
     * in the message file.
     */
    protected static final String INVALID_MESSAGECODE =
            ".Entry for the message code {0} was not found in {1}";
    /**
     * Represents the description for error occurred during the logging process.
     */
    protected static final String LOGGING_ERROR =
            "The following error occurred while logging the error :";
    /**
     * Represents the description for error occurred while adding the
     * error to the context.
     */
    protected static final String ADD_ERRORTOCONTEXT_ERROR =
            "The following error occurred while adding the error to the context :";

    /**
     * Error occurred while formatting message.
     */
    protected static final String MESSAGE_FORMATTING_ERROR = "Error occurred while formatting the message.";

    /**
     * Format Message Separator (Message)
     */
    protected static final String FORMAT_MSG_SEPERATOR = "Message ";
    /**
     * Format Message Line Separator (---------------------)
     */
    protected final static String FORMAT_MSG_LINESEPERATOR = "::";

    public final static String TENDERTYPE_CARD = "C";

    /**
     * content type of request String
     */
    protected final static String CONTENT_TYPE_NAMEVALUE = "text/namevalue";
    /**
     * content type of request String
     */
    protected final static String CONTENT_TYPE_XML = "text/xml";
    /**
     * Format Message  Open Bracket ([)
     */
    protected static final String FORMAT_MSG_OPENBRACKET = "[";
    /**
     * Format Message  Close Bracket (])
     */
    protected static final String FORMAT_MSG_CLOSEBRACKET = "]";
    /**
     * Format Message Code body Separator (-)
     */
    protected static final String FORMAT_MSG_CODEBODY_SEP = "-";

    /**
     * Communication Error Connection Failed
     */
    protected static final String E_SOK_CONN_FAILED = "E_SOK_CONN_FAILED";
    /**
     * Communication Error Param Name Error
     */
    protected static final String E_PARM_NAME = "E_PARM_NAME";
    /**
     * Communication Error Param Name Length Error
     */
    protected static final String E_PARM_NAME_LEN = "E_PARM_NAME_LEN";
    /**
     * Communication Error Timeout Waiting for Response
     */
    protected static final String E_TIMEOUT_WAIT_RESP = "E_TIMEOUT_WAIT_RESP";
    /**
     * Communication Error Null Host String
     */
    protected static final String E_NULL_HOST_STRING = "E_NULL_HOST_STRING";
    /**
     * Communication Error Invalid Timeout
     */
    protected static final String E_INVALID_TIMEOUT = "E_INVALID_TIMEOUT";
    /**
     * Communication Error Unexpected Request Id
     */
    protected static final String E_UNEXPECTED_REQUEST_ID = "E_UNEXPECTED_REQUEST_ID";
    /**
     * Communication Error Missing Response Id in the response received from the Server.
     */
    protected static final String E_MISSING_SERVER_RESPONSE_ID = "E_MISSING_SERVER_RESPONSE_ID";
    /**
     * Communication Error Missing Request Id
     */
    protected static final String E_MISSING_REQUEST_ID = "E_MISSING_REQUEST_ID";
    /**
     * Communication Error Empty Param List
     */
    protected static final String E_EMPTY_PARAM_LIST = "E_EMPTY_PARAM_LIST";
    /**
     * Communication Error Context Initialization Failed
     */
    protected static final String E_CONTXT_INIT_FAILED = "E_CONTXT_INIT_FAILED";
    /**
     * Communication Error Unknown State
     */
    protected static final String E_UNKNOWN_STATE = "E_UNKNOWN_STATE";
    /**
     * Communication Error Invalid Name Value Pair Request
     */
    protected static final String E_INVALID_NVP = "E_INVALID_NVP";
    /**
     * Communication Error Invalid Name Value Pair Request
     */
    protected static final String E_INVALID_TRANSACTION_REQUEST = "E_INVLID_TRANSACTION_REQUEST";
    /**
     * Communication Error for both round and truncate being true in the currency object.
     */
    protected static final String E_CURRENCY_PROCESS_ERROR = "E_CURRENCY_PROCESS_ERROR";
    /**
     * Communication Error Unexpected Response Id
     */
    protected static final String E_UNEXPECTED_RESPONSE_ID = "E_UNEXPECTED_RESPONSE_ID";
    /**
     * Communication Error Response Format Error
     */
    protected static final String E_RESPONSE_FORMAT_ERROR = "E_RESPONSE_FORMAT_ERROR";
    /**
     * Communication Error Version Not Supported
     */
    protected static final String E_VERSION_NOT_SUPPORTED = "E_VERSION_NOT_SUPPORTED";

    /**
     * protected Error Init Error
     */
    protected static final String E_INIT_ERROR = "E_INIT_ERROR";

    /**
     * protected Param rule
     */
    protected static final String XML_PARAM_RULE = "rule";
    /**
     * protected Param num
     */
    protected static final String XML_PARAM_NUM = "num";
    /**
     * protected Param ruleId
     */
    protected static final String XML_PARAM_RULEID = "ruleId";
    /**
     * protected Param ruleAlias
     */
    protected static final String XML_PARAM_RULEALIAS = "ruleAlias";
    /**
     * protected Param ruleDescription
     */
    protected static final String XML_PARAM_RULEDESCRIPTION = "ruleDescription";
    /**
     * protected Param action
     */
    protected static final String XML_PARAM_ACTION = "action";
    /**
     * protected Param triggeredMessage
     */
    protected static final String XML_PARAM_TRIGGEREDMESSAGE = "triggeredMessage";
    /**
     * protected Param rulevendorparms
     */
    protected static final String XML_PARAM_RULEVENDORPARMS = "rulevendorparms";
    /**
     * protected Param ruleParameter
     */
    protected static final String XML_PARAM_RULEPARAMETER = "ruleParameter";
    /**
     * protected Param name
     */
    protected static final String XML_PARAM_NAME = "name";
    /**
     * protected Param value
     */
    protected static final String XML_PARAM_VALUE = "value";
    /**
     * protected Param type
     */
    protected static final String XML_PARAM_TYPE = "type";
    /**
     * XML Pay Param request_id
     */
    protected static final String XML_PARAM_REQUEST_ID = "request_id";
    /**
     * XML Pay Param response_id
     */
    protected static final String XML_PARAM_RESPONSE_ID = "response_id";
    /**
     * XML Pay Param version
     */
    protected static final String XML_PARAM_VERSION = "version";
    /**
     * XML Pay Param Vendor
     */
    protected static final String XML_PARAM_VENDOR = "Vendor";
    /**
     * XML Pay Param User
     */
    protected static final String XML_PARAM_USER = "User";
    /**
     * XML Pay Param Partner
     */
    protected static final String XML_PARAM_PARTNER = "Partner";
    /**
     * XML Pay Param Password
     */
    protected static final String XML_PARAM_PASSWORD = "Password";
    /**
     * XML Pay Param AcctNum
     */
    protected static final String XML_PARAM_ACCTNUM = "AcctNum";
    /**
     * XML Pay Param CardNum
     */
    protected static final String XML_PARAM_CARDNUM = "CardNum";
    /**
     * XML Pay Param ExpDate
     */
    protected static final String XML_PARAM_EXPDATE = "ExpDate";
    /**
     * XML Pay Param MagData
     */
    protected static final String XML_PARAM_MAGDATA = "MagData";
    /**
     * XML Pay Param MICR
     */
    protected static final String XML_PARAM_MICR = "MICR";
    /**
     * XML Pay Param CVNum
     */
    protected static final String XML_PARAM_CVNUM = "CVNum";
    /**
     * XML Pay Param DL
     */
    protected static final String XML_PARAM_DL = "DL";
    /**
     * XML Pay Param SS
     */
    protected static final String XML_PARAM_SS = "SS";
    /**
     * XML Pay Param DOB
     */
    protected static final String XML_PARAM_DOB = "DOB";
    /**
     * XML Pay Start tag
     */
    protected static final String XML_PARAM_START_TAG = "<?xml version='1.0' encoding='UTF-8'?><XMLPayRequest version ='";
    /**
     * Payflow Param AUTHTYPE
     */
    protected static final String PARAM_AUTHTYPE = "AUTHTYPE";
    /**
     * Payflow Param PRENOTE
     */
    protected static final String PARAM_PRENOTE = "PRENOTE";
    /**
     * Payflow Param TERMCITY
     */
    protected static final String PARAM_TERMCITY = "TERMCITY";
    /**
     * Payflow Param TERMSTATE
     */
    protected static final String PARAM_TERMSTATE = "TERMSTATE";
    /**
     * Payflow Param ABA
     */
    protected static final String PARAM_ABA = "ABA";
    /**
     * Payflow Param ACCTTYPE
     */
    protected static final String PARAM_ACCTTYPE = "ACCTTYPE";
    /**
     * Payflow Param TENDER
     */
    protected static final String PARAM_TENDER = "TENDER";
    /**
     * Payflow Param CHKNUM
     */
    protected static final String PARAM_CHKNUM = "CHKNUM";
    /**
     * Payflow Param CHKTYPE
     */
    protected static final String PARAM_CHKTYPE = "CHKTYPE";
    /**
     * Payflow Param BILLTOSTREET
     */
    protected static final String PARAM_STREET = "BILLTOSTREET";
    /**
     * Payflow Param BILLTOSTREET2
     */
    protected static final String PARAM_STREET2 = "BILLTOSTREET2";
    /**
     * Payflow Param BILLTOCITY
     */
    protected static final String PARAM_CITY = "BILLTOCITY";
    /**
     * Payflow Param BILLTOSTATE
     */
    protected static final String PARAM_STATE = "BILLTOSTATE";
    /**
     * Payflow Param COUNTRY
     */
    protected static final String PARAM_COUNTRY = "COUNTRY";
    // changed from BILLTOCOUNTRY to COUNTRY since Recurring Billing does not
    // handle BILLTOCOUNTRY
    /**
     * Payflow Param BILLTOCOUNTRY
     */
    protected static final String PARAM_BILLTOCOUNTRY = "BILLTOCOUNTRY";
    /**
     * Payflow Param BILLTOZIP
     */
    protected static final String PARAM_ZIP = "BILLTOZIP";
    /**
     * Payflow Param PHONENUM
     */
    protected static final String PARAM_PHONENUM = "PHONENUM";
    /**
     * Payflow Param BILLTOPHONE2
     */
    protected static final String PARAM_BILLTOPHONE2 = "BILLTOPHONE2";
    /**
     * Payflow Param EMAIL
     */
    protected static final String PARAM_EMAIL = "BILLTOEMAIL";
    /**
     * Payflow Param FAX
     */
    protected static final String PARAM_FAX = "BILLTOFAX";
    /**
     * Payflow Param FIRSTNAME
     */
    protected static final String PARAM_FIRSTNAME = "BILLTOFIRSTNAME";
    /**
     * Payflow Param MIDDLENAME
     */
    protected static final String PARAM_MIDDLENAME = "BILLTOMIDDLENAME";
    /**
     * Payflow Param LASTNAME
     */
    protected static final String PARAM_LASTNAME = "BILLTOLASTNAME";
    /**
     * Payflow Param HOMEPHONE
     */
    protected static final String PARAM_HOMEPHONE = "BILLTOHOMEPHONE";
    /**
     * Payflow Param BROWSERTIME
     */
    protected static final String PARAM_BROWSERTIME = "BROWSERTIME";
    /**
     * Payflow Param BROWSERCOUNTRYCODE
     */
    protected static final String PARAM_BROWSERCOUNTRYCODE = "BROWSERCOUNTRYCODE";
    /**
     * Payflow Param BROWSERUSERAGENT
     */
    protected static final String PARAM_BROWSERUSERAGENT = "BROWSERUSERAGENT";
    /**
     * Payflow Param ACSURL
     */
    protected static final String PARAM_ACSURL = "ACSURL";
    /**
     * Payflow Param AUTHENICATION_ID
     */
    protected static final String PARAM_AUTHENTICATION_ID = "AUTHENTICATION_ID";
    /**
     * Payflow Param AUTHENICATION_STATUS
     */
    protected static final String PARAM_AUTHENICATION_STATUS = "AUTHENTICATION_STATUS";
    /**
     * Payflow Param CAVV
     */
    protected static final String PARAM_CAVV = "CAVV";
    /**
     * Payflow Param ECI
     */
    protected static final String PARAM_ECI = "ECI";
    /**
     * Payflow Param MD
     */
    protected static final String PARAM_MD = "MD";
    /**
     * Payflow Param PAREQ
     */
    protected static final String PARAM_PAREQ = "PAREQ";
    /**
     * Payflow Param XID
     */
    protected static final String PARAM_XID = "XID";
    /**
     * Payflow Param MICR
     */
    protected static final String PARAM_MICR = "MICR";
    /**
     * Payflow Param NAME
     */
    protected static final String PARAM_NAME = "NAME";
    /**
     * Payflow Param DL
     */
    protected static final String PARAM_DL = "DL";
    /**
     * Payflow Param SS
     */
    protected static final String PARAM_SS = "SS";
    /**
     * Payflow Param REQNAME
     */
    protected static final String PARAM_REQNAME = "REQNAME";
    /**
     * Payflow Param CUSTCODE
     */
    protected static final String PARAM_CUSTCODE = "CUSTCODE";
    /**
     * Payflow Param CUSTIP
     */
    protected static final String PARAM_CUSTIP = "CUSTIP";
    /**
     * Payflow Param CUSTVATREGNUM
     */
    protected static final String PARAM_CUSTVATREGNUM = "CUSTVATREGNUM";
    /**
     * Payflow Param DOB
     */
    protected static final String PARAM_DOB = "DOB";
    /**
     * Payflow Param CUSTID
     */
    protected static final String PARAM_CUSTID = "CUSTID";
    /**
     * Payflow Param COMPANYNAME
     */
    protected static final String PARAM_COMPANYNAME = "BILLTOCOMPANYNAME";
    /**
     * Payflow Param CORPNAME
     */
    protected static final String PARAM_CORPNAME = "CORPNAME";
    /**
     * Payflow Param MERCHDESCR
     */
    protected static final String PARAM_MERCHDESCR = "MERCHDESCR";
    /**
     * Payflow Param MERCHSVC
     */
    protected static final String PARAM_MERCHSVC = "MERCHSVC";
    /**
     * Payflow Param MERCHANTNAME
     */
    protected static final String PARAM_MERCHANTNAME = "MERCHANTNAME";
    /**
     * Payflow Param MERCHANTSTRET
     */
    protected static final String PARAM_MERCHANTSTREET = "MERCHANTSTREET";
    /**
     * Payflow Param MERCHANTCITY
     */
    protected static final String PARAM_MERCHANTCITY = "MERCHANTCITY";
    /**
     * Payflow Param MERCHANTSTATE
     */
    protected static final String PARAM_MERCHANTSTATE = "MERCHANTSTATE";
    /**
     * Payflow Param MERCHANTZIP
     */
    protected static final String PARAM_MERCHANTZIP = "MERCHANTZIP";
    /**
     * Payflow Param MERCHANTCOUNTRYCODE
     */
    protected static final String PARAM_MERCHANTCOUNTRYCODE = "MERCHANTCOUNTRYCODE";
    /**
     * Payflow Param ADDLMSGS
     */
    protected static final String PARAM_ADDLMSGS = "ADDLMSGS";
    /**
     * Payflow Param PREFPSMSG
     */
    protected static final String PARAM_PREFPSMSG = "PREFPSMSG";
    /**
     * Payflow Param POSTFPSMSG
     */
    protected static final String PARAM_POSTFPSMSG = "POSTFPSMSG";
    /**
     * Payflow Param RESPTEXT
     */
    protected static final String PARAM_RESPTEXT = "RESPTEXT";
    /**
     * Payflow Param PROCAVS
     */
    protected static final String PARAM_PROCAVS = "PROCAVS";
    /**
     * Payflow Param PROCCARDSECURE
     */
    protected static final String PARAM_PROCCARDSECURE = "PROCCARDSECURE";
    /**
     * Payflow Param PROCCVV2
     */
    protected static final String PARAM_PROCCVV2 = "PROCCVV2";
    /**
     * Payflow Param HOSTCODE
     */
    protected static final String PARAM_HOSTCODE = "HOSTCODE";
    /**
     * Payflow Param INVNUM
     */
    protected static final String PARAM_INVNUM = "INVNUM";
    /**
     * Payflow Param AMT
     */
    protected static final String PARAM_AMT = "AMT";
    /**
     * Payflow Param TAXEXEMPT
     */
    protected static final String PARAM_TAXEXEMPT = "TAXEXEMPT";
    /**
     * Payflow Param TAXAMT
     */
    protected static final String PARAM_TAXAMT = "TAXAMT";
    /**
     * Payflow Param DUTYAMT
     */
    protected static final String PARAM_DUTYAMT = "DUTYAMT";
    /**
     * Payflow Param FREIGHTAMT
     */
    protected static final String PARAM_FREIGHTAMT = "FREIGHTAMT";
    /**
     * Payflow Param HANDLINGAMT
     */
    protected static final String PARAM_HANDLINGAMT = "HANDLINGAMT";
    /**
     * Payflow Param DISCOUNT
     */
    protected static final String PARAM_DISCOUNT = "DISCOUNT";
    /**
     * Payflow Param DESC
     */
    protected static final String PARAM_DESC = "DESC";
    /**
     * Payflow Param COMMENT1
     */
    protected static final String PARAM_COMMENT1 = "COMMENT1";
    /**
     * Payflow Param COMMENT2
     */
    protected static final String PARAM_COMMENT2 = "COMMENT2";
    /**
     * Payflow Param DESC1
     */
    protected static final String PARAM_DESC1 = "DESC1";
    /**
     * Payflow Param DESC2
     */
    protected static final String PARAM_DESC2 = "DESC2";
    /**
     * Payflow Param DESC3
     */
    protected static final String PARAM_DESC3 = "DESC3";
    /**
     * Payflow Param DESC4
     */
    protected static final String PARAM_DESC4 = "DESC4";
    /**
     * Payflow Param CUSTREF
     */
    protected static final String PARAM_CUSTREF = "CUSTREF";
    /**
     * Payflow Param PONUM
     */
    protected static final String PARAM_PONUM = "PONUM";
    /**
     * Payflow Param VATREGNUM
     */
    protected static final String PARAM_VATREGNUM = "VATREGNUM";
    /**
     * Payflow Param VATTAXAMT
     */
    protected static final String PARAM_VATTAXAMT = "VATTAXAMT";
    /**
     * Payflow Param LOCALTAXAMT
     */
    protected static final String PARAM_LOCALTAXAMT = "LOCALTAXAMT";
    /**
     * Payflow Param NATIONALTAXAMT
     */
    protected static final String PARAM_NATIONALTAXAMT = "NATIONALTAXAMT";
    /**
     * Payflow Param ALTTAXAMT
     */
    protected static final String PARAM_ALTTAXAMT = "ALTTAXAMT";
    /**
     * Payflow Param COMMCODE
     */
    protected static final String PARAM_COMMCODE = "COMMCODE";
    /**
     * Payflow Param INVOICEDATE
     */
    protected static final String PARAM_INVOICEDATE = "INVOICEDATE";
    /**
     * Payflow Param STARTTIME
     */
    protected static final String PARAM_STARTTIME = "STARTTIME";
    /**
     * Payflow Param ENDTIME
     */
    protected static final String PARAM_ENDTIME = "ENDTIME";
    /**
     * Payflow Param ORDERDATE
     */
    protected static final String PARAM_ORDERDATE = "ORDERDATE";
    /**
     * Payflow Param ORDERTIME
     */
    protected static final String PARAM_ORDERTIME = "ORDERTIME";
    /**
     * Payflow Param L_AMTn
     */
    protected static final String PARAM_L_AMT = "L_AMT";
    /**
     * Payflow Param L_COSTn
     */
    protected static final String PARAM_L_COST = "L_COST";
    /**
     * Payflow Param L_FREIGHTAMTn
     */
    protected static final String PARAM_L_FREIGHTAMT = "L_FREIGHTAMT";
    /**
     * Payflow Param L_HANDLINGAMTn
     */
    protected static final String PARAM_L_HANDLINGAMT = "L_HANDLINGAMT";
    /**
     * Payflow Param L_TAXAMTn
     */
    protected static final String PARAM_L_TAXAMT = "L_TAXAMT";
    /**
     * Payflow Param L_UOMn
     */
    protected static final String PARAM_L_UOM = "L_UOM";
    /**
     * Payflow Param L_PICKUPSTREETn
     */
    protected static final String PARAM_L_PICKUPSTREET = "L_PICKUPSTREET";
    /**
     * Payflow Param L_PICKUPSTATEn
     */
    protected static final String PARAM_L_PICKUPSTATE = "L_PICKUPSTATE";
    /**
     * Payflow Param L_PICKUPCOUNTRYn
     */
    protected static final String PARAM_L_PICKUPCOUNTRY = "L_PICKUPCOUNTRY";
    /**
     * Payflow Param L_PICKUPCITYn
     */
    protected static final String PARAM_L_PICKUPCITY = "L_PICKUPCITY";
    /**
     * Payflow Param L_PICKUPZIPn
     */
    protected static final String PARAM_L_PICKUPZIP = "L_PICKUPZIP";
    /**
     * Payflow Param L_DESCn
     */
    protected static final String PARAM_L_DESC = "L_DESC";
    /**
     * Payflow Param L_DISCOUNTn
     */
    protected static final String PARAM_L_DISCOUNT = "L_DISCOUNT";
    /**
     * Payflow Param L_MANUFACTURERn
     */
    protected static final String PARAM_L_MANUFACTURER = "L_MANUFACTURER";
    /**
     * Payflow Param L_PRODCODEn
     */
    protected static final String PARAM_L_PRODCODE = "L_PRODCODE";
    /**
     * Payflow Param L_QTYn
     */
    protected static final String PARAM_L_QTY = "L_QTY";
    /**
     * Payflow Param L_SKUn
     */
    protected static final String PARAM_L_SKU = "L_SKU";
    /**
     * Payflow Param L_TAXRATEn
     */
    protected static final String PARAM_L_TAXRATE = "L_TAXRATE";
    /**
     * Payflow Param L_TAXTYPEn
     */
    protected static final String PARAM_L_TAXTYPE = "L_TAXTYPE";
    /**
     * Payflow Param L_TYPEn
     */
    protected static final String PARAM_L_TYPE = "L_TYPE";
    /**
     * Payflow Param L_COMMCODEn
     */
    protected static final String PARAM_L_COMMCODE = "L_COMMCODE";
    /**
     * Payflow Param L_TRACKINGNUMn
     */
    protected static final String PARAM_L_TRACKINGNUM = "L_TRACKINGNUM";
    /**
     * Payflow Param L_COSTCENTERNUMn
     */
    protected static final String PARAM_L_COSTCENTERNUM = "L_COSTCENTERNUM";
    /**
     * Payflow Param L_CATALOGNUMn
     */
    protected static final String PARAM_L_CATALOGNUM = "L_CATALOGNUM";
    /**
     * Payflow Param L_UPCn
     */
    protected static final String PARAM_L_UPC = "L_UPC";
    /**
     * Payflow Param
     */
    protected static final String PARAM_L_UNSPSCCODE = "L_UNSPSCCODE";
    /**
     * Payflow Param EXPDATE
     */
    protected static final String PARAM_EXPDATE = "EXPDATE";
    /**
     * Payflow Param CVV2
     */
    protected static final String PARAM_CVV2 = "CVV2";
    /**
     * Payflow Param ACCT
     */
    protected static final String PARAM_ACCT = "ACCT";
    /**
     * Payflow Param COMMCARD
     */
    protected static final String PARAM_COMMCARD = "COMMCARD";
    /**
     * Payflow Param PROFILENAME
     */
    protected static final String PARAM_PROFILENAME = "PROFILENAME";
    /**
     * Payflow Param START
     */
    protected static final String PARAM_START = "START";
    /**
     * Payflow Param TERM
     */
    protected static final String PARAM_TERM = "TERM";
    /**
     * Payflow Param PAYPERIOD
     */
    protected static final String PARAM_PAYPERIOD = "PAYPERIOD";
    /**
     * Payflow Param OPTIONALTRX
     */
    protected static final String PARAM_OPTIONALTRX = "OPTIONALTRX";
    /**
     * Payflow Param OPTIONALTRXAMT
     */
    protected static final String PARAM_OPTIONALTRXAMT = "OPTIONALTRXAMT";
    /**
     * Payflow Param RETRYNUMDAYS
     */
    protected static final String PARAM_RETRYNUMDAYS = "RETRYNUMDAYS";
    /**
     * Payflow Param MAXFAILPAYMENTS
     */
    protected static final String PARAM_MAXFAILPAYMENTS = "MAXFAILPAYMENTS";
    /**
     * Payflow Param NUMFAILPAYMENTS
     */
    protected static final String PARAM_NUMFAILPAYMENTS = "NUMFAILPAYMENTS";
    /**
     * Payflow Param ORIGPROFILEID
     */
    protected static final String PARAM_ORIGPROFILEID = "ORIGPROFILEID";
    /**
     * Payflow Param PAYMENTHISTORY
     */
    protected static final String PARAM_PAYMENTHISTORY = "PAYMENTHISTORY";
    /**
     * Payflow Param PAYMENTNUM
     */
    protected static final String PARAM_PAYMENTNUM = "PAYMENTNUM";
    /**
     * Payflow Param RECURRING
     */
    protected static final String PARAM_RECURRING = "RECURRING";
    /**
     * Payflow Param PROFILEID
     */
    protected static final String PARAM_PROFILEID = "PROFILEID";
    /**
     * Payflow Param RPREF
     */
    protected static final String PARAM_RPREF = "RPREF";
    /**
     * Payflow Param TRXPNREF
     */
    protected static final String PARAM_TRXPNREF = "TRXPNREF";
    /**
     * Payflow Param TRXRESULT
     */
    protected static final String PARAM_TRXRESULT = "TRXRESULT";
    /**
     * Payflow Param TRXRESPMSG
     */
    protected static final String PARAM_TRXRESPMSG = "TRXRESPMSG";
    /**
     * Payflow Param STATUS
     */
    protected static final String PARAM_STATUS = "STATUS";
    /**
     * Payflow Param PAYMENTSLEFT
     */
    protected static final String PARAM_PAYMENTSLEFT = "PAYMENTSLEFT";
    /**
     * Payflow Param NEXTPAYMENT
     */
    protected static final String PARAM_NEXTPAYMENT = "NEXTPAYMENT";
    /**
     * Payflow Param END
     */
    protected static final String PARAM_END = "END";
    /**
     * Payflow Param AGGREGATEAMT
     */
    protected static final String PARAM_AGGREGATEAMT = "AGGREGATEAMT";
    /**
     * Payflow Param AGGREGATEOPTIONALAMT
     */
    protected static final String PARAM_AGGREGATEOPTIONALAMT = "AGGREGATEOPTIONALAMT";
    /**
     * Payflow Param SHIPTOFIRSTNAME
     */
    protected static final String PARAM_SHIPTONAME = "SHIPTONAME";
    /**
     * Payflow Param SHIPTOFIRSTNAME
     */
    protected static final String PARAM_SHIPTOFIRSTNAME = "SHIPTOFIRSTNAME";
    /**
     * Payflow Param SHIPTOMIDDLENAME
     */
    protected static final String PARAM_SHIPTOMIDDLENAME = "SHIPTOMIDDLENAME";
    /**
     * Payflow Param SHIPTOLASTNAME
     */
    protected static final String PARAM_SHIPTOLASTNAME = "SHIPTOLASTNAME";
    /**
     * Payflow Param SHIPTOSTREET
     */
    protected static final String PARAM_SHIPTOSTREET = "SHIPTOSTREET";
    /**
     * Payflow Param SHIPTOSTREET2
     */
    protected static final String PARAM_SHIPTOSTREET2 = "SHIPTOSTREET2";
    /**
     * Payflow Param SHIPTOCITY
     */
    protected static final String PARAM_SHIPTOCITY = "SHIPTOCITY";
    /**
     * Payflow Param SHIPTOSTATE
     */
    protected static final String PARAM_SHIPTOSTATE = "SHIPTOSTATE";
    /**
     * Payflow Param SHIPTOZIP
     */
    protected static final String PARAM_SHIPTOZIP = "SHIPTOZIP";
    /**
     * Payflow Param SHIPTOCOUNTRY
     */
    protected static final String PARAM_SHIPTOCOUNTRY = "SHIPTOCOUNTRY";
    /**
     * Payflow Param P_RESULTn
     */
    protected static final String PARAM_P_RESULTn = "P_RESULTn";
    /**
     * Payflow Param P_PNREFn
     */
    protected static final String PARAM_P_PNREFn = "P_PNREFn";
    /**
     * Payflow Param P_TRANSTATEn
     */
    protected static final String PARAM_P_TRANSTATEn = "P_TRANSTATEn";
    /**
     * Payflow Param P_TENDERn
     */
    protected static final String PARAM_P_TENDERn = "P_TENDERn";
    /**
     * Payflow Param P_TRANSTIMEn
     */
    protected static final String PARAM_P_TRANSTIMEn = "P_TRANSTIMEn";
    /**
     * Payflow Param P_AMOUNTn
     */
    protected static final String PARAM_P_AMOUNTn = "P_AMOUNTn";
    /**
     * Payflow Param FPS_PREXMLDATA
     */
    protected static final String PARAM_FPS_PREXMLDATA = "FPS_PREXMLDATA";
    /**
     * Payflow Param FPS_POSTXMLDATA
     */
    protected static final String PARAM_FPS_POSTXMLDATA = "FPS_POSTXMLDATA";
    /**
     * Payflow Param SHIPTOPHONE
     */
    protected static final String PARAM_SHIPTOPHONE = "SHIPTOPHONE";
    /**
     * Payflow Param SHIPTOPHONE2
     */
    protected static final String PARAM_SHIPTOPHONE2 = "SHIPTOPHONE2";
    /**
     * Payflow Param SHIPTOEMAIL
     */
    protected static final String PARAM_SHIPTOEMAIL = "SHIPTOEMAIL";
    /**
     * Payflow Param SHIPCARRIER
     */
    protected static final String PARAM_SHIPCARRIER = "SHIPCARRIER";
    /**
     * Payflow Param SHIPMETHOD
     */
    protected static final String PARAM_SHIPMETHOD = "SHIPMETHOD";
    /**
     * Payflow Param SHIPFROMZIP
     */
    protected static final String PARAM_SHIPFROMZIP = "SHIPFROMZIP";
    /**
     * Payflow Param SHIPPEDFROMZIP
     */
    protected static final String PARAM_SHIPPEDFROMZIP = "SHIPPEDFROMZIP";
    /**
     * Payflow Param ADDRESSSTATUS
     */
    protected static final String PARAM_ADDRESSSTATUS = "ADDRESSSTATUS";
    /**
     * Payflow Param SWIPE
     */
    protected static final String PARAM_SWIPE = "SWIPE";
    /**
     * Payflow Param RESULT
     */
    protected static final String PARAM_RESULT = "RESULT";
    /**
     * Payflow Param PNREF
     */
    protected static final String PARAM_PNREF = "PNREF";
    /**
     * Payflow Param RESPMSG
     */
    protected static final String PARAM_RESPMSG = "RESPMSG";
    /**
     * Payflow Param AUTHCODE
     */
    protected static final String PARAM_AUTHCODE = "AUTHCODE";
    /**
     * Payflow Param AVSADDR
     */
    protected static final String PARAM_AVSADDR = "AVSADDR";
    /**
     * Payflow Param AVSZIP
     */
    protected static final String PARAM_AVSZIP = "AVSZIP";
    /**
     * Payflow Param CARDSECURE
     */
    protected static final String PARAM_CARDSECURE = "CARDSECURE";
    /**
     * Payflow Param CVV2MATCH
     */
    protected static final String PARAM_CVV2MATCH = "CVV2MATCH";
    /**
     * Payflow Param IAVS
     */
    protected static final String PARAM_IAVS = "IAVS";
    /**
     * Payflow Param ORIGRESULT
     */
    protected static final String PARAM_ORIGRESULT = "ORIGRESULT";
    /**
     * Payflow Param TRANSSTATE
     */
    protected static final String PARAM_TRANSSTATE = "TRANSSTATE";
    /**
     * Payflow Param USER
     */
    protected static final String PARAM_USER = "USER";
    /**
     * Payflow Param VENDOR
     */
    protected static final String PARAM_VENDOR = "VENDOR";
    /**
     * Payflow Param PARTNER
     */
    protected static final String PARAM_PARTNER = "PARTNER";
    /**
     * Payflow Param PWD
     */
    protected static final String PARAM_PWD = "PWD";
    /**
     * Payflow Param TRXTYPE
     */
    protected static final String PARAM_TRXTYPE = "TRXTYPE";
    /**
     * Payflow Param BA_FLAG
     */
    protected static final String PARAM_BA_FLAG = "BA_FLAG";
    /**
     * Payflow Param BAID
     */
    protected static final String PARAM_BAID = "BAID";
    /**
     * Payflow Param BA_STATUS
     */
    protected static final String PARAM_BA_STATUS = "BA_STATUS";
    /**
     * Payflow Param VERBOSITY
     */
    protected static final String PARAM_VERBOSITY = "VERBOSITY";
    /**
     * Payflow Param CAPTURECOMPLETE
     */
    protected static final String PARAM_CAPTURECOMPLETE = "CAPTURECOMPLETE";
    /**
     * Payflow Param DOREAUTHORIZATION
     */
    protected static final String PARAM_DOREAUTHORIZATION = "DOREAUTHORIZATION";
    /**
     * Payflow Param PARES
     */
    protected static final String PARAM_PARES = "PARES";
    /**
     * Payflow Param CURRENCY
     */
    protected static final String PARAM_CURRENCY = "CURRENCY";
    /**
     * Payflow Param PUR_DESC
     */
    protected static final String PARAM_PUR_DESC = "PUR_DESC";
    /**
     * Payflow Param ORIGID
     */
    protected static final String PARAM_ORIGID = "ORIGID";
    /**
     * Payflow Param UPDATEACTION
     */
    protected static final String PARAM_UPDATEACTION = "UPDATEACTION";
    /**
     * Payflow Param ACTION
     */
    protected static final String PARAM_ACTION = "ACTION";

    /**
     * Payflow Param TRACEID
     */
    protected static final String PARAM_TRACEID = "TRACEID";
    /**
     * Payflow Param ACHSTATUS
     */
    protected static final String PARAM_ACHSTATUS = "ACHSTATUS";
    /**
     * Payflow Param TXID
     */
    protected static final String PARAM_TXID = "TXID";
    /**
     * Payflow Param CARDONFILE
     */
    protected static final String PARAM_CARDONFILE = "CARDONFILE";
    /**
     * Payflow Param L_ALTTAXAMT
     */
    protected static final String PARAM_L_ALTTAXAMT = "L_ALTTAXAMT";
    /**
     * Payflow Param L_ALTTAXID
     */
    protected static final String PARAM_L_ALTTAXID = "L_ALTTAXID";
    /**
     * Payflow Param L_ALTTAXRATE
     */
    protected static final String PARAM_L_ALTTAXRATE = "L_ALTTAXRATE";
    /**
     * Payflow Param L_CARRIERSERVICESLEVELCODE
     */
    protected static final String PARAM_L_CARRIERSERVICESLEVELCODE = "L_CARRIERSERVICESLEVELCODE";
    /**
     * Payflow Param L_EXTAMT
     */
    protected static final String PARAM_L_EXTAMT = "L_EXTAMT";
    /**
     * Payflow Param ADDLAMT
     */
    protected static final String PARAM_ADDLAMT = "ADDLAMT";
    /**
     * Payflow Param ADDLAMTTYPE
     */
    protected static final String PARAM_ADDLAMTTYPE = "ADDLAMTTYPE";
    /**
     * Payflow Param CATTYPE
     */
    protected static final String PARAM_CATTYPE = "CATTYPE";
    /**
     * Payflow Param CONTACTLESS
     */
    protected static final String PARAM_CONTACTLESS = "CONTACTLESS";
    /**
     * Payflow Param CUSTDATA
     */
    protected static final String PARAM_CUSTDATA = "CUSTDATA";
    /**
     * Payflow Param CUSTOMERID
     */
    protected static final String PARAM_CUSTOMERID = "CUSTOMERID";
    /**
     * Payflow Param CUSTOMERNUMBER
     */
    protected static final String PARAM_CUSTOMERNUMBER= "CUSTOMERNUMBER";

/// ----------------------------------------------------------------------------

    /**
     * Payflow Param VIT_OSNAME
     */
    protected static final String PARAM_VIT_OSNAME = "VIT_OSNAME";
    /**
     * Payflow Param VIT_OSARCH
     */
    protected static final String PARAM_VIT_OSARCH = "VIT_OSARCH";
    /**
     * Payflow Param VIT_OSVERSION
     */
    protected static final String PARAM_VIT_OSVERSION = "VIT_OSVERSION";
    /**
     * Payflow Param VIT_SDKRUNTIMEVERSION
     */
    protected static final String PARAM_VIT_SDKRUNTIMEVERSION = "VIT_SDKRUNTIMEVERSION";
    /**
     * Payflow Param VIT_PROXY
     */
    protected static final String PARAM_VIT_PROXY = "VIT_PROXY";
    /**
     * Payflow Param VIT_WRAPTYPE
     */
    protected static final String PARAM_VIT_WRAPTYPE = "VIT_WRAPTYPE";
    /**
     * Payflow Param VIT_WRAPVERSION
     */
    protected static final String PARAM_VIT_WRAPVERSION = "VIT_WRAPVERSION";
    /**
     * Payflow Param REQUEST_ID
     */
    protected static final String PARAM_REQUEST_ID = "REQUEST_ID";
    /**
     * Payflow Param RESPONSE_ID
     */
    protected static final String PARAM_RESPONSE_ID = "RESPONSE_ID";
    /**
     * Payflow Param VATTAXPERCENT
     */
    protected static final String PARAM_VATTAXPERCENT = "VATTAXPERCENT";
    /**
     * Payflow Param DUPLICATE
     */
    protected static final String PARAM_DUPLICATE = "DUPLICATE";
    /**
     * Payflow Param DATE_TO_SETTLE
     */
    protected static final String PARAM_DATE_TO_SETTLE = "DATE_TO_SETTLE";
    /**
     * Payflow Param BATCHID
     */
    protected static final String PARAM_BATCHID = "BATCHID";
    /**
     * Payflow Param BILLINGTYPE
     */
    protected static final String PARAM_BILLINGTYPE = "BILLINGTYPE";
    /**
     * Payflow Param BA_DESC
     */
    protected static final String PARAM_BA_DESC = "BA_DESC";
    /**
     * Payflow Param BA_CUSTOM
     */
    protected static final String PARAM_BA_CUSTOM = "BA_CUSTOM";
    /**
     * Payflow Param CARDISSUE
     */
    protected static final String PARAM_CARDISSUE = "CARDISSUE";
    /**
     * Payflow Param CARDSTART
     */
    protected static final String PARAM_CARDSTART = "CARDSTART";
    /**
     * Payflow Param PROMOCODEOVERRIDE
     */
    protected static final String PARAM_PROMOCODEOVERRIDE = "PROMOCODEOVERRIDE";
    /**
     * Payflow Param PROFILEADDRESSCHANGEDATE
     */
    protected static final String PARAM_PROFILEADDRESSCHANGEDATE = "PROFILEADDRESSCHANGEDATE";
    /**
     * Payflow Param PAYPALCHECKOUTBTNTYPE
     */
    protected static final String PARAM_PAYPALCHECKOUTBTNTYPE = "PAYPALCHECKOUTBTNTYPE";
    /**
     * Payflow Param PRODUCTCATEGORY
     */
    protected static final String PARAM_PRODUCTCATEGORY = "PRODUCTCATEGORY";
    /**
     * Payflow Param SHIPPINGMETHOD
     */
    protected static final String PARAM_SHIPPINGMETHOD = "SHIPPINGMETHOD";
    /**
     * Payflow Param PROMOCODE
     */
    protected static final String PARAM_PROMOCODE = "PROMOCODE";
    /**
     * Payflow Param BALAMT
     */
    protected static final String PARAM_BALAMT = "BALAMT";
    /**
     * Payflow Param AMEXID
     */
    protected static final String PARAM_AMEXID = "AMEXID";
    /**
     * Payflow Param AMEXPOSDATA
     */
    protected static final String PARAM_AMEXPOSDATA = "AMEXPOSDATA";
    /**
     * Payflow Param CARDTYPE
     */
    protected static final String PARAM_CARDTYPE = "CARDTYPE";
    /**
     * Payflow Param PARTIALAUTH
     */
    protected static final String PARAM_PARTIALAUTH = "PARTIALAUTH";
    /**
     * Payflow Param ORIGAMT
     */
    protected static final String PARAM_ORIGAMT = "ORIGAMT";
    /**
     * Payflow Param TRANSTIME
     */
    protected static final String PARAM_TRANSTIME = "TRANSTIME";

    /**
     * Payflow Param SECURETOKEN
     */
    protected static final String PARAM_SECURETOKEN = "SECURETOKEN";
    /**
     * Payflow Param SECURETOKENID
     */
    protected static final String PARAM_SECURETOKENID = "SECURETOKENID";
    /**
     * Payflow Param CREATESECURETOKEN
     */
    protected static final String PARAM_CREATESECURETOKEN = "CREATESECURETOKEN";
        /**
     * Payflow Param PHONEMATCH
     */
    protected static final String PARAM_PHONEMATCH = "PHONEMATCH";
            /**
     * Payflow Param EMAILMATCH
     */
    protected static final String PARAM_EMAILMATCH = "EMAILMATCH";
            /**
     * Payflow Param EXTRSPMSG
     */
    protected static final String PARAM_EXTRSPMSG = "EXTRSPMSGE";
    /**
     * Payflow Param ALLOWNOTE
     */
    protected static final String PARAM_ALLOWNOTE = "ALLOWNOTE";
    /**
    * Payflow Param PAYMENTADVICECODE
    */
    protected static final String PARAM_PAYMENTADVICECODE = "PAYMENTADVICECODE";
    /**
     * Payflow Param PAYMENTADVICECODE
     */
    protected static final String PARAM_ASSOCIATIONRESPCODE = "ASSOCIATIONRESPCODE";
    /**
     * Payflow Param TRANSACTIONID
     */
    protected static final String PARAM_TRANSACTIONID = "TRANSACTIONID";
    /**
     * Payflow Param ECHODATA
     */
    protected static final String PARAM_ECHODATA = "ECHODATA";
    /**
     * Payflow Param ORDERID
     */
    protected static final String PARAM_ORDERID = "ORDERID";
    /**
     * Payflow Param USER1
     */
    protected static final String PARAM_USER1 = "USER1";
    /**
     * Payflow Param USERv2
     */
    protected static final String PARAM_USER2 = "USER2";
    /**
     * Payflow Param USER3
     */
    protected static final String PARAM_USER3 = "USER3";
    /**
     * Payflow Param USER4
     */
    protected static final String PARAM_USER4 = "USER4";
    /**
     * Payflow Param USER5
     */
    protected static final String PARAM_USER5 = "USER5";
    /**
     * Payflow Param USER6
     */
    protected static final String PARAM_USER6 = "USER6";
    /**
     * Payflow Param USER7
     */
    protected static final String PARAM_USER7 = "USER7";
    /**
     * Payflow Param USER8
     */
    protected static final String PARAM_USER8 = "USER8";
    /**
     * Payflow Param USER9
     */
    protected static final String PARAM_USER9 = "USER9";
    /**
     * Payflow Param USER10
     */
    protected static final String PARAM_USER10 = "USER10";
    /**
     * Payflow Param TYPE
     */
    protected static final String PARAM_TYPE = "TYPE";
    /**
     * Payflow Param AFFLUENT
     */
    protected static final String PARAM_AFFLUENT = "AFFLUENT";
    /**
     * Payflow Param CCUPDATED
     */
    protected static final String PARAM_CCUPDATED = "CCUPDATED";
    /**
     * Payflow Param THREEDSVERSION
     */
    protected static final String PARAM_THREEDSVERSION= "THREEDSVERSION";
    /**
     * Payflow Param DSTRANSACTIONID
     */
    protected static final String PARAM_DSTRANSACTIONID = "DSTRANSACTIONID";

    /**
     * Payflow Param RRN
     */
    protected static final String PARAM_RRN = "RRN";
    /**
     * Payflow Param STAN
     */
    protected static final String PARAM_STAN = "STAN";
    /**
     * Payflow Param ACI
     */
    protected static final String PARAM_ACI = "ACI";
    /**
     * Payflow Param VALIDATIONCODE
     */
    protected static final String PARAM_VALIDATIONCODE = "VALIDATIONCODE";
    /**
     * Payflow Param MERCHANTLOCATIONID
     */
    protected static final String PARAM_MERCHANTLOCATIONID = "MERCHANTLOCATIONID";
    /**
     * Payflow Param MERCHANTID
     */
    protected static final String PARAM_MERCHANTID = "MERCHANTID";
    /**
     * Payflow Param MERCHANTCONTACTINFO
     */
    protected static final String PARAM_MERCHANTCONTACTINFO = "MERCHANTCONTACTINFO";
    /**
     * Payflow Param CCTRANSID
     */
    protected static final String PARAM_CCTRANSID = "CCTRANSID";
    /**
     * Payflow Param CCTRANS_POSDATA
     */
    protected static final String PARAM_CCTRANS_POSDATA = "CCTRANS_POSDATA";
    /**
     * Payflow Param AUTHDATE
     */
    protected static final String PARAM_AUTHDATE = "AUTHDATE";
    /**
     * Payflow Param MERCHANTURL
     */
    protected static final String PARAM_MERCHANTURL = "MERCHANTURL";
    /**
     * Payflow Param MERCHANTVATNUM
     */
    protected static final String PARAM_MERCHANTVATNUM= "MERCHANTVATNUM";
    /**
     * Payflow Param CUSTHOSTNAME
     */
    protected static final String PARAM_CUSTHOSTNAME= "CUSTHOSTNAME";
    /**
     * Payflow Param CUSTBROWSER
     */
    protected static final String PARAM_CUSTBROWSER= "CUSTBROWSER";
    /**
     * Payflow Param MERCHANTINVOICENUM
     */
    protected static final String PARAM_MERCHANTINVOICENUM= "MERCHANTINVOICENUM";
    /**
     * Payflow Param VATINVNUM
     */
    protected static final String PARAM_VATINVNUM = "VATINVNUM";
    /**
     * Payflow Param VATTAXRATE
     */
    protected static final String PARAM_VATTAXRATE = "VATTAXRATE";
    /**
     * Payflow Param REPORTGROUP
     */
    protected static final String PARAM_REPORTGROUP = "REPORTGROUP";
	 /**
     * Payflow Param MISCDATA
     */
    protected static final String PARAM_MISCDATA = "MISCDATA";

    // added DTPAYFLOW-1691 - March 2022 - v5.02
    /**
     * Payflow Param FREQUENCY
     */
    protected static final String PARAM_FREQUENCY = "FREQUENCY";

    /**
     * Payflow Param CREATIONDATE
     */
    protected static final String PARAM_CREATIONDATE = "CREATIONDATE";

    /**
     * Payflow Param LASTCHANGED
     */
    protected static final String PARAM_LASTCHANGED = "LASTCHANGED";

    /**
     * Payflow Param RPSTATE
     */
    protected static final String PARAM_RPSTATE = "RPSTATE";

    /**
     * Payflow Param NEXTPAYMENTNUM
     */
    protected static final String PARAM_NEXTPAYMENTNUM = "NEXTPAYMENTNUM";

    /**
     * Payflow Param SCAEXEMPTION
     */
    protected static final String PARAM_SCAEXEMPTION = "SCAEXEMPTION";
    /**
     * Payflow Param CITDATE
     */
    protected static final String PARAM_CITDATE = "CITDATE";
    /**
     * Payflow Param VMAID
     */
    protected static final String PARAM_VMAID = "VMAID";
    /**
     * Payflow Param PAR
     */
    protected static final String PARAM_PAR = "PAR";
    /**
     * Payflow Param VMAID
     */
    protected static final String PARAM_PARID = "PARID";















    /**
     * static finalant for PAYFLOW-OS-ARCHITECTURE
     */
    protected static final String PAYFLOWHEADER_OS_ARCHITECTURE = "X-VPS-VIT-OS-ARCHITECTURE";
    /**
     * Recurring Inquiry Response Param Prefix
     */
    protected static final String PREFIX_RECURRING_INQUIRY_RESP = "P_";
    /**
     * static finalant for PAYFLOW-CLIENT-DURATION
     */
    protected static final String PAYFLOWHEADER_CLIENT_DURATION = "X-VPS-VIT-CLIENT-DURATION";
    /**
     * static finalant for PAYFLOW-CLIENT-VERSION
     */
    protected static final String PAYFLOWHEADER_CLIENT_VERSION = "X-VPS-VIT-CLIENT-VERSION";
    /**
     * static finalant for PAYFLOW-OS-NAME
     */
    protected static final String PAYFLOWHEADER_OS_NAME = "X-VPS-VIT-OS-NAME";
    /**
     * static finalant for PAYFLOW-OS-VERSION
     */
    protected static final String PAYFLOWHEADER_OS_VERSION = "X-VPS-VIT-OS-VERSION";
    /**
     * static finalant for PAYFLOW-PROXY
     */
    protected static final String PAYFLOWHEADER_PROXY = "X-VPS-VIT-PROXY";
    /**
     * static finalant for PAYFLOW-RUNTIME-VERSION
     */
    protected static final String PAYFLOWHEADER_RUNTIME_VERSION = "X-VPS-VIT-RUNTIME-VERSION";
    /**
     * static finalant for PAYFLOW-INTEGRATION-PRODUCT
     */
    protected static final String PAYFLOWHEADER_INTEGRATION_PRODUCT = "X-VPS-VIT-INTEGRATION-PRODUCT";
    /**
     * static finalant for PAYFLOW-INTEGRATION-VERSION
     */
    protected static final String PAYFLOWHEADER_INTEGRATION_VERSION = "X-VPS-VIT-INTEGRATION-VERSION";
    /**
     * static finalant for PAYFLOW-CLIENT-TYPE
     */
    protected static final String PAYFLOWHEADER_CLIENT_TYPE = "X-VPS-VIT-CLIENT-TYPE";
    /**
     * static finalant for PAYFLOW-ASSEMBLY
     */
    protected static final String PAYFLOWHEADER_PAYFLOW_ASSEMBLY = "X-VPS-VIT-ASSEMBLY";
    /**
     * max LogFile Size in Bytes; beyond this size the log file will be archived
     */
    protected static final int DEFAULT_MAX_LOG_FILE_SIZE = 10000000;


    protected static final String PARAM_POSTALCODE = "POSTALCODE";
    protected static final String PARAM_TOKEN = "TOKEN";
    protected static final String PARAM_COUNTRYCODE = "COUNTRYCODE";
    protected static final String PARAM_ACTION_SET = "S";
    protected static final String PARAM_ACTION_DO = "D";
    protected static final String PARAM_ACTION_GET = "G";
    protected static final String PARAM_ACTION_UPDATE = "U";
    protected static final String PARAM_ACTION_SETBA = "S";  // Z-S  Z, W, X are deprecated
    protected static final String PARAM_ACTION_GETBA = "G";  // W-G
    protected static final String PARAM_ACTION_DOBA = "X"; // X-D
    protected static final String PARAM_RETURNURL = "RETURNURL";
    protected static final String PARAM_CANCELURL = "CANCELURL";
    protected static final String PARAM_REQCONFIRMSHIPPING = "REQCONFIRMSHIPPING";
    protected static final String PARAM_NOSHIPPING = "NOSHIPPING";
    protected static final String PARAM_ADDROVERRIDE = "ADDROVERRIDE";
    protected static final String PARAM_LOCALECODE = "LOCALECODE";
    protected static final String PARAM_PAGESTYLE = "PAGESTYLE";
    protected static final String PARAM_HDRIMG = "HDRIMG";
    protected static final String PARAM_HDRBORDERCOLOR = "HDRBORDERCOLOR";
    protected static final String PARAM_HDRBACKCOLOR = "HDRBACKCOLOR";
    protected static final String PARAM_PAYFLOWCOLOR = "PAYFLOWCOLOR";
    protected static final String PARAM_MAXAMT = "PARAM_MAXAMT";
    protected static final String PARAM_ITEMAMT = "ITEMAMT";
    protected static final String PARAM_L_ITEMNUMBER = "L_ITEMNUMBER";
    protected static final String PARAM_ORDERDESC = "ORDERDESC";
    protected static final String PARAM_RECURRINGTYPE = "RECURRINGTYPE";
    protected static final String PARAM_REQBILLINGADDRESS = "REQBILLINGADDRESS";

    protected static final String INTL_PARAM_FULLRESPONSE = "FULLRESPONSE";
    protected static final String PARAM_SETTLE_DATE = "SETTLE_DATE";
    protected static final String PARAM_ORIGPNREF = "ORIGPNREF";
    protected static final String PARAM_ORIGPPREF = "ORIGPPREF";
    protected static final String PARAM_PAYERID = "PAYERID";
    protected static final String PARAM_BUTTONSOURCE = "BUTTONSOURCE";
    protected static final String PARAM_NOTIFYURL = "NOTIFYURL";
    protected static final String PARAM_CUSTOM = "CUSTOM";
    protected static final String PARAM_MERCHANTSESSIONID = "MERCHANTSESSIONID";
    protected static final String PARAM_PAYERSTATUS = "PAYERSTATUS";
    protected static final String PARAM_SHIPTOBUSINESS = "SHIPTOBUSINESS";
    //protected static final String PARAM_ADDRSTATUS = "ADDRSTATUS";

    protected static final String PARAM_PPREF = "PPREF";
    protected static final String PARAM_FEEAMT = "FEEAMT";
    protected static final String PARAM_SETTLEAMT = "SETTLEAMT";
    protected static final String PARAM_EXCHANGERATE = "EXCHANGERATE";
    protected static final String PARAM_PENDINGREASON = "PENDINGREASON";
    protected static final String PARAM_PAYMENTDATE = "PAYMENTDATE";
    protected static final String PARAM_PAYMENTSTATUS = "PAYMENTSTATUS";
    protected static final String PARAM_PAYMENTTYPE = "PAYMENTTYPE";
    protected static final String TAG_DUPLICATE = "DUPLIACTE_NAME_KEY";
    protected static final String PARAM_SHIPPINGAMT = "SHIPPINGAMT";
    protected static final String PARAM_CORRELATIONID = "CORRELATIONID";
    protected static final String TENDERTYPE_ACH = "A";
    protected static final String TENDERTYPE_PAYPAL = "P";
    protected static final String TENDERTYPE_TELECHECK = "K";
    protected static final String TRXTYPE_RECURRING = "R";
    protected static final String TRXTYPE_AUTH = "A";
    protected static final String TRXTYPE_BUYERAUTH_VA = "Z";
    protected static final String TRXTYPE_BUYERAUTH_VE = "E";
    protected static final String TRXTYPE_CAPTURE = "D";
    protected static final String TRXTYPE_CREDIT = "C";
    protected static final String TRXTYPE_FRAUDAPPROVE = "U";
    protected static final String TRXTYPE_INQUIRY = "I";
    protected static final String TRXTYPE_SALE = "S";
    protected static final String TRXTYPE_VOID = "V";
    protected static final String TRXTYPE_VOICEAUTH = "F";

    public static final String RECURRING_ACTION_ADD = "A";
    public static final String RECURRING_ACTION_INQUIRY = "I";
    public static final String RECURRING_ACTION_MODIFY = "M";
    public static final String RECURRING_ACTION_REACTIVATE = "R";
    public static final String RECURRING_ACTION_PAYMENT = "P";
    public static final String RECURRING_ACTION_CANCEL = "C";

    // MagTek Encrypted Swipe params constants
    /**
     * Payflow Param ENCMP
     */
    protected static final String MAGTEK_PARAM_ENCMP = "ENCMP";
    /**
     * Payflow Param ENCRYTIONBLOCKTYPE
     */
    protected static final String MAGTEK_PARAM_ENCRYPTIONBLOCKTYPE = "ENCRYPTIONBLOCKTYPE";
    /**
     * Payflow Param ENCTRACK1
     */
    protected static final String MAGTEK_PARAM_ENCTRACK1 = "ENCTRACK1";
    /**
     * Payflow Param ENCTRACK2
     */
    protected static final String MAGTEK_PARAM_ENCTRACK2 = "ENCTRACK2";
    /**
     * Payflow Param ENCTRACK3
     */
    protected static final String MAGTEK_PARAM_ENCTRACK3 = "ENCTRACK3";
    /**
     * Payflow Param KSN
     */
    protected static final String MAGTEK_PARAM_KSN = "KSN";
    /**
     * Payflow Param MAGTEKCARDTYPE
     */
    protected static final String  MAGTEK_PARAM_MAGTEKCARDTYPE = "MAGTEKCARDTYPE";
    /**
     * Payflow Param NPSTATUS
     */
    protected static final String MAGTEK_PARAM_MPSTATUS = "MPSTATUS";
    /**
     * Payflow Param REGISTEREDBY
     */
    protected static final String MAGTEK_PARAM_REGISTEREDBY = "REGISTEREDBY";
    /**
     * Payflow Param SWIPEDECRHOST
     */
    protected static final String MAGTEK_PARAM_SWIPEDECRHOST = "SWIPEDECRHOST";
    /**
     * Payflow Param DEVICESN
     */
    protected static final String MAGTEK_PARAM_DEVICESN = "DEVICESN";
    /**
     * Payflow Param MERCHANTID
     */
    protected static final String MAGTEK_PARAM_MERCHANTID = "MERCHANTID";
    /**
     * Payflow Param PAN4
     */
    protected static final String MAGTEK_PARAM_PAN4 = "PAN4";
    /**
     * Payflow Param PCODE
     */
    protected static final String MAGTEK_PARAM_PCODE = "PCODE";
    /**
     * Payflow Param AUTHVALUE1
     */
    protected static final String MAGTEK_PARAM_AUTHVALUE1 = "AUTHVALUE1";
    /**
     * Payflow Param AUTHVALUE2
     */
    protected static final String MAGTEK_PARAM_AUTHVALUE2 = "AUTHVALUE2";
    /**
     * Payflow Param AUTHVALUE3
     */
    protected static final String MAGTEK_PARAM_AUTHVALUE3 = "AUTHVALUE3";
    /**
     * Payflow Param MAGTEKUSERNAME
     */
    protected static final String MAGTEK_PARAM_MAGTEKUSERNAME = "MAGTEKUSERNAME";
    /**
     * Payflow Param MAGTEKPWD
     */
    protected static final String MAGTEK_PARAM_MAGTEKPWD = "MAGTEKPWD";
    /**
     * Payflow Param MAGTRESPONSE
     */
    protected static final String MAGTEK_PARAM_MAGTRESPONSE = "MAGTRESPONSE";




}

