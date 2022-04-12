#region "Imports"

using System;
using System.Collections;

#endregion

namespace PayPal.Payments.Common.Utility
{
    /// <summary>
    /// Summary description for PayflowConstants.
    /// </summary>
    public sealed class PayflowConstants
    {
        #region "Private Constructor"

        /// <summary>
        /// Private constructor
        /// for PayflowConstants
        /// </summary>
        private PayflowConstants()
        {
        }

        #endregion

        // Stores the Client Version - Update as needed.
        #region "Communication Objects Related Constants"

        //Default timeout in seconds
        /// <summary>
        /// Default Timeout in seconds (45 sec)
        /// </summary>
        internal const int DEFAULT_TIMEOUT = 45;
        /// <summary>
        /// Default Connection reconnect Time span in seconds (3 sec)
        /// </summary>
        internal const int DEFAULT_RETRYCONNECTIONTIME = 3000;
        /// <summary>
        /// Default Payflow Host port (443)
        /// </summary>
        internal const int DEFAULT_HOSTPORT = 443;
        /// <summary>
        /// SDK Client Prefix
        /// </summary>
        internal const String CLIENT_PREFIX = "PNCLIENT";
        /// <summary>
        /// SDK Client Type (N --> .NET)
        /// </summary>
        internal const String CLIENT_TYPE = "N";
        // if you change the SDK Client Version (CLIENT_VERSION) below, remember to 
        // change the assembly version in the AssemblyInfo.cs to match.
        /// <summary>
        /// SDK Client Version (400 --> V4 protocol)
        /// </summary>
        internal const String CLIENT_VERSION = "502";
        /// <summary>
        /// SDK User Agent (Payflow SDK for .NET)
        /// </summary>
        internal const String USER_AGENT = "Payflow SDK for .NET";
        /// <summary>
        /// SDK Request Type
        /// </summary>
        internal const String STRONG_ASSEMBLY = "Strong";
        /// <summary>
        /// SDK Request Type
        /// </summary>
        internal const String WEAK_ASSEMBLY = "Weak";
        /// <summary>
        /// Maximum retry attempts (3)
        /// </summary>
        internal const int MAX_RETRY = 3;
        /// <summary>
        /// XmlPay ID
        /// </summary>
        internal const String XML_ID = "<XMLPayRequest";
        /// <summary>
        /// XmlPay Response ID
        /// </summary>
        internal const String XML_RESP_ID = "<XMLPayResponse";
        /// <summary>
        /// XML Content Type (text/xml) 
        /// </summary>
        internal const String XML_CONTENT_TYPE = "text/xml";
        /// <summary>
        /// Name value Content Type (text/namevalue)
        /// </summary>
        internal const String NV_CONTENT_TYPE = "text/namevalue";
        /// <summary>
        /// XML Pay namespace (http://www.paypal.com/XMLPay)
        /// </summary>
        internal const String XMLPAY_NAMESPACE = "http://www.paypal.com/XMLPay";
        /// <summary>
        /// XML Pay request tag (XMLPayRequest)
        /// </summary>
        internal const String XMLPAY_REQUEST_TAG = "XMLPayRequest";

        #endregion

        #region "General Constants"

        /// <summary>
        /// Empty String 
        /// </summary>
        public const String EMPTY_STRING = "";
        /// <summary>
        /// Default Country Code 
        /// </summary>
        internal const String CURRENCYCODE_DEFAULT = CURRENCYCODE_USD;
        /// <summary>
        /// Currency code for USD
        /// </summary>
        internal const String CURRENCYCODE_USD = "USD";  
        /// <summary>
        /// NVP Delimiter (&amp;)
        /// </summary>
        internal const String DELIMITER_NVP = "&";
        /// <summary>
        /// NVP Opening Brace ([)
        /// </summary>
        internal const String OPENING_BRACE_NVP = "[";
        /// <summary>
        /// NVP Closing Brace (])
        /// </summary>
        internal const String CLOSING_BRACE_NVP = "]";
        /// <summary>
        /// Constant Underscore
        /// </summary>
        internal const String UNDERSCORE = "_";
        /// <summary>
        /// Constant DOT
        /// </summary>
        internal const String DOT = ".";
        /// <summary>
        /// NVP Separator (=)
        /// </summary>
        internal const String SEPARATOR_NVP = "=";
        /// <summary>
        /// Numeric values initialize
        /// </summary>
        internal const long INVALID_NUMBER = -384783;
        /// <summary>
        /// Duplicate tag
        /// </summary>
        internal const String TAG_DUPLICATE = "DUPLIACTE_NAME_KEY";
        /// <summary>
        /// Xml Pay Param Result
        /// </summary>
        internal const String XML_PARAM_RESULT = "Result";
        /// <summary>
        /// Xml Pay param Message
        /// </summary>
        internal const String XML_PARAM_MESSAGE = "Message";
        #endregion

        #region "Tender Related Constants"

        /// <summary>
        /// Card Tender (C)
        /// </summary>
        internal const String TENDERTYPE_CARD = "C";
        /// <summary>
        /// ACH Tender (A)
        /// </summary>
        internal const String TENDERTYPE_ACH = "A";
        /// <summary>
        /// Telecheck Tender (K)
        /// </summary>
        internal const String TENDERTYPE_TELECHECK = "K";
        /// <summary>
        /// PayPal Tender (P)
        /// </summary>
        internal const String TENDERTYPE_PAYPAL = "P";

        #region "ACH Tender Related Constants"

        /// <summary>
        /// ACH Authtype CCD
        /// </summary>
        internal const String AchAuthTypeCCD = "CCD";
        /// <summary>
        /// ACH Authtype PPD
        /// </summary>
        internal const String AchAuthTypePPD = "PPD";
        /// <summary>
        /// ACH Authtype POP
        /// </summary>
        internal const String AchAuthTypePOP = "POP";
        /// <summary>
        /// ACH Authtype WEB
        /// </summary>
        internal const String AchAuthTypeWEB = "WEB";
        /// <summary>
        /// ACH Authtype RCK
        /// </summary>
        internal const String AchAuthTypeRCK = "RCK";
        /// <summary>
        /// ACH Authtype ARC
        /// </summary>
        internal const String AchAuthTypeARC = "ARC";
        /// <summary>
        /// ACH Authtype TEL
        /// </summary>
        internal const String AchAuthTypeTEL = "TEL";

        #endregion

        #endregion

        #region "Transaction Type Related Constants"

        /// <summary>
        /// Authorization TrxType (A)
        /// </summary>
        internal const String TRXTYPE_AUTH = "A";
        /// <summary>
        /// Sale TrxType (S)
        /// </summary>
        internal const String TRXTYPE_SALE = "S";
        /// <summary>
        /// Credit Trxtype (C)
        /// </summary>
        internal const String TRXTYPE_CREDIT = "C";
        /// <summary>
        /// Voice Authorization Trxtype (F)
        /// </summary>
        internal const String TRXTYPE_VOICEAUTH = "F";
        /// <summary>
        /// Capture Trxtype (D)
        /// </summary>
        internal const String TRXTYPE_CAPTURE = "D";
        /// <summary>
        /// Inquiry Trxtype (I)
        /// </summary>
        internal const String TRXTYPE_INQUIRY = "I";
        /// <summary>
        /// Void Trxtype (V)
        /// </summary>
        internal const String TRXTYPE_VOID = "V";
        /// <summary>
        /// Recurring Trxtype (R)
        /// </summary>
        internal const String TRXTYPE_RECURRING = "R";
        /// <summary>
        /// Fraud Review Trxtype (U)
        /// </summary>
        internal const String TRXTYPE_FRAUDAPPROVE = "U";
        /// <summary>
        /// Buyer auth Verify Enrollment Trxtype (E)
        /// </summary>
        internal const String TRXTYPE_BUYERAUTH_VE = "E";
        /// <summary>
        /// Buyer auth Validate Authentication Trxtype (Z)
        /// </summary>
        internal const String TRXTYPE_BUYERAUTH_VA = "Z";

        #endregion

        #region "RMS Related Constants"

        /// <summary>
        /// RMS Update Action Approve
        /// </summary>
        internal const String RMS_UPDATEACTION_APPROVE = "RMS_APPROVE";
        /// <summary>
        /// RMS Update Action Decline
        /// </summary>
        internal const String RMS_UPDATEACTION_DECLINE = "RMS_MERCHANT_DECLINE";

        #endregion

        #region "Recurring Transaction Related Constants"

        #region "Action Related Constants"

        /// <summary>
        /// Recurring Action Add (A)
        /// </summary>
        internal const String RECURRING_ACTION_ADD = "A";
        /// <summary>
        /// Recurring Action Modify (M)
        /// </summary>
        internal const String RECURRING_ACTION_MODIFY = "M";
        /// <summary>
        /// Recurring Action Reactivate (R)
        /// </summary>
        internal const String RECURRING_ACTION_REACTIVATE = "R";
        /// <summary>
        /// Recurring Action Cancel (C)
        /// </summary>
        internal const String RECURRING_ACTION_CANCEL = "C";
        /// <summary>
        /// Recurring Action Inquiry (I)
        /// </summary>
        internal const String RECURRING_ACTION_INQUIRY = "I";
        /// <summary>
        /// Recurring Action Payment (P)
        /// </summary>
        internal const String RECURRING_ACTION_PAYMENT = "P";

        #endregion

        #region "Payment Period Related Constants"

        /// <summary>
        /// Recurring PayPeriod Every Week (WEEK)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_WEEK = "WEEK";
        /// <summary>
        /// Recurring PayPeriod Every Two Weeks (BIWK)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_BIWK = "BIWK";
        /// <summary>
        /// Recurring PayPeriod Twice Every Month (SMMO)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_SMMO = "SMMO";
        /// <summary>
        /// Recurring PayPeriod Every Four Weeks (FRWK)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_FRWK = "FRWK";
        /// <summary>
        /// Recurring PayPeriod Every Month (MONT)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_MONT = "MONT";
        /// <summary>
        /// Recurring PayPeriod Every Quarter (QTER)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_QTER = "QTER";
        /// <summary>
        /// Recurring PayPeriod Twice Every Year (SMYR)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_SMYR = "SMYR";
        /// <summary>
        /// Recurring PayPeriod Every Year (YEAR)
        /// </summary>
        internal const String RECURRING_PAYPERIOD_YEAR = "YEAR";

        #endregion

        #endregion

        #region "Constants for Message Code"
        /// <summary>
        /// Error Message Constant for communication error (MSG_1012)
        /// </summary>
        internal const string MSG_COMMUNICATION_ERROR = "MSG_1012";
        /// <summary>
        /// Error Message Constant for communication error xml pay (MSG_1005)
        /// </summary>
        internal const string MSG_COMMUNICATION_ERROR_XMLPAY = "MSG_1013";
        /// <summary>
        /// Error Message Constant for communication error (MSG_1012)
        /// </summary>
        internal const string MSG_COMMUNICATION_ERROR_NO_RESPONSE_ID = "MSG_1015";
        /// <summary>
        /// Error Message Constant for communication error xml pay (MSG_1005)
        /// </summary>
        internal const string MSG_COMMUNICATION_ERROR_XMLPAY_NO_RESPONSE_ID = "MSG_1016";
        #endregion

        #region "Check Type"

        /// <summary>
        /// Check type Personal (P)
        /// </summary>
        internal const String CHECK_TYPE_PERSONEL = "P";
        /// <summary>
        /// Check type Corporate (C)
        /// </summary>
        internal const String CHECK_TYPE_CORPORATE = "C";

        #endregion

        #region "Communication Error HashTable"

        /// <summary>
        /// Communication Error Codes
        /// </summary>
        internal static Hashtable CommErrorCodes = PopulateErrorCodes();

        /// <summary>
        /// Communication Error Messages
        /// </summary>
        internal static Hashtable CommErrorMessages = PopulateErrorMessages();

        #endregion

        /// <summary>
        /// Populates Error code hash table
        /// </summary>
        /// <returns>Error code hash table</returns>
        private static Hashtable PopulateErrorCodes()
        {
            Hashtable ErrorCodeTable = new Hashtable();
            ErrorCodeTable.Add(E_SOK_CONN_FAILED, "-1");
            ErrorCodeTable.Add(E_PARM_NAME, "-6");
            ErrorCodeTable.Add(E_PARM_NAME_LEN, "-7");
            ErrorCodeTable.Add(E_TIMEOUT_WAIT_RESP, "-12");
            ErrorCodeTable.Add(E_NULL_HOST_STRING, "-23");
            ErrorCodeTable.Add(E_INVALID_TIMEOUT, "-30");
            ErrorCodeTable.Add(E_COMMON_NAME, "-32");
            ErrorCodeTable.Add(E_MISSING_REQUEST_ID, "-41");
            ErrorCodeTable.Add(E_EMPTY_PARAM_LIST, "-100");
            ErrorCodeTable.Add(E_CONTXT_INIT_FAILED, "-103");
            ErrorCodeTable.Add(E_UNKNOWN_STATE, "-104");
            ErrorCodeTable.Add(E_INVALID_NVP, "-105");
            ErrorCodeTable.Add(E_RESPONSE_FORMAT_ERROR, "-106");
            ErrorCodeTable.Add(E_VERSION_NOT_SUPPORTED, "-107");
            ErrorCodeTable.Add(E_CONFIG_ERROR, "-109");
            ErrorCodeTable.Add(E_LOG_ERROR, "-110");
            ErrorCodeTable.Add(E_MSGFILE_INIT_ERROR, "-111");
            ErrorCodeTable.Add(E_CURRENCY_PROCESS_ERROR, "-113");
            return ErrorCodeTable;
        }

        /// <summary>
        /// Populates Message code hash table
        /// </summary>
        /// <returns>Message code hash table</returns>
        private static Hashtable PopulateErrorMessages()
        {
            Hashtable ErrorMessageTable = new Hashtable();
            ErrorMessageTable.Add(E_SOK_CONN_FAILED, "Failed to connect to host");
            ErrorMessageTable.Add(E_PARM_NAME, "Parameter list format error: & in name");
            ErrorMessageTable.Add(E_PARM_NAME_LEN, "Parameter list format error: invalid [] name length clause");
            ErrorMessageTable.Add(E_TIMEOUT_WAIT_RESP, "Timeout waiting for response");
            ErrorMessageTable.Add(E_NULL_HOST_STRING, "Host address not specified");
            ErrorMessageTable.Add(E_INVALID_TIMEOUT, "Invalid timeout value");
            ErrorMessageTable.Add(E_MISSING_REQUEST_ID, "Required Request ID not found in request.");
            ErrorMessageTable.Add(E_EMPTY_PARAM_LIST, "Parameter List cannot be empty");
            ErrorMessageTable.Add(E_CONTXT_INIT_FAILED, "Context Initialization failed");
            ErrorMessageTable.Add(E_UNKNOWN_STATE, "Unexpected transaction state");
            ErrorMessageTable.Add(E_INVALID_NVP, "Invalid name value pair request");
            ErrorMessageTable.Add(E_RESPONSE_FORMAT_ERROR, "Invalid response format");
            ErrorMessageTable.Add(E_VERSION_NOT_SUPPORTED, "This XMLPay Version is not supported");
            ErrorMessageTable.Add(E_CONFIG_ERROR, CONFIG_ERROR);
            ErrorMessageTable.Add(E_LOG_ERROR, LOGGING_ERROR);
            ErrorMessageTable.Add(E_MSGFILE_INIT_ERROR, "Could not initialize from message file.");
            ErrorMessageTable.Add(E_CURRENCY_PROCESS_ERROR, "Unable to round and truncate the currency value simultaneously. You can set only one of the two properties Round OR Truncate in the Data Object Currency.");
            ErrorMessageTable.Add(E_COMMON_NAME, "The certificate chain did not validate, common name did not match URL.");
            return ErrorMessageTable;
        }

        #region "Communication Header Related constants"

        /// <summary>
        /// HTTP Header PAYFLOW-Request-ID
        /// </summary>
        internal const String PAYFLOWHEADER_REQUEST_ID = "X-VPS-Request-ID";
        /// <summary>
        /// HTTP Header PAYFLOW-CLIENT-TIMEOUT
        /// </summary>
        internal const String PAYFLOWHEADER_TIMEOUT = "X-VPS-CLIENT-TIMEOUT";

        #endregion

        //Constants for Exception Framework

        #region "Config Constants"

        /// <summary>
        /// Holds the name of the key used to get the message file name. 
        /// </summary>
        internal const String MESSAGE_FILE_NAME = "MSG_FILE";
        /// <summary>
        /// Holds the key name which holds the Log file name 
        /// </summary>
        internal const String CONFIG_LOGFILE_NAME = "LOG_FILE";

        /// <summary>
        /// Holds the key name which holds the limit for Log file size
        /// </summary>
        internal const String CONFIG_LOGFILE_SIZE = "LOGFILE_SIZE";

        /// <summary>
        /// Holds the key name which holds the Logging level
        /// </summary>
        internal const String CONFIG_LOG_LEVEL = "LOG_LEVEL";
        /// <summary>
        /// Holds the default Log file name 
        /// </summary>
        //internal static String LOGFILE_NAME = AppDomain.CurrentDomain.BaseDirectory + "PayflowSDK.log";
        internal static String LOGFILE_NAME = "PayflowSDK.log";

        /// <summary>
        /// Holds the default limit for Log file size
        /// </summary>
        internal const int LOGFILE_SIZE = 10230000;

        /// <summary>
        /// Logging Level OFF
        /// </summary>
        public const int LOGGING_OFF = 0;

        #endregion

        #region "Message file constants"

        /// <summary>
        /// Holds the name of the key in the message file that holds the message code.
        /// </summary>
        internal const String MESSAGE_ID = "Id";
        /// <summary>
        /// Holds the name of the key in the message file that holds the message body.
        /// </summary>
        internal const String MESSAGE_BODY = "Body";
        /// <summary>
        /// Holds the name of the key in the message file that holds the message severity.
        /// </summary>
        internal const String MESSAGE_SEVERITY = "Severity";
        /// <summary>
        /// Tag for TRACE in config file
        /// </summary>
        internal const String TRACE_TAG = "TRACE";
        /// <summary>
        /// Default value of Trace
        /// </summary>
        internal const String TRACE_DEFAULT = TRACE_OFF;
        /// <summary>
        /// On value for Trace
        /// </summary>
        internal const String TRACE_ON = "ON";
        /// <summary>
        /// Off value for Trace
        /// </summary>
        internal const String TRACE_OFF = "OFF";
        /// <summary>
        /// Trace value
        /// </summary>
        internal static String TRACE = TRACE_DEFAULT;

        #endregion

        #region "Severity Level constants"

        //--------------------------------------------------------
        //Holds the constants defining the error severity levels
        /// <summary>
        /// Severity for a FATAL level message.
        /// </summary>
        internal const String ERROR_FATAL = "FATAL";
        /// <summary>
        /// Severity for a ERROR level message.
        /// </summary>
        internal const String ERROR_ERROR = "ERROR";
        /// <summary>
        /// Severity for a WARN level message.
        /// </summary>
        internal const String ERROR_WARN = "WARN";
        /// <summary>
        /// Severity for a INFO level message.
        /// </summary>
        internal const String ERROR_INFO = "INFO";
        /// <summary>
        /// Severity for a DEBUG level message.
        /// </summary>
        internal const String ERROR_DEBUG = "DEBUG";
        //--------------------------------------------------------

        //--------------------------------------------------------
        //Holds the integer constants defining the error severity levels
        /// <summary>
        /// Severity for a FATAL level message.
        /// </summary>
        public const int SEVERITY_FATAL = 5;
        /// <summary>
        /// Severity for a ERROR level message.
        /// </summary>
        public const int SEVERITY_ERROR = 4;
        /// <summary>
        /// Severity for a WARN level message.
        /// </summary>
        public const int SEVERITY_WARN = 3;
        /// <summary>
        /// Severity for a INFO level message.
        /// </summary>
        public const int SEVERITY_INFO = 2;
        /// <summary>
        /// Severity for a DEBUG level message.
        /// </summary>
        public const int SEVERITY_DEBUG = 1;
        //--------------------------------------------------------

        #endregion

        #region "Messages description"

        //Constants for the Exception
        /// <summary>
        /// Represents the description for error in the configuration file.
        /// </summary>
        internal const String CONFIG_ERROR = "Unable to read from the configuration file. ";
        /// <summary>
        /// Represents the description for error occurred during the logging process.
        /// </summary>
        internal const String LOGGING_ERROR = "Log error: ";
        /// <summary>
        /// Error occurred while formatting message.
        /// </summary>
        internal const String MESSAGE_FORMATTING_ERROR = "Error occurred while formatting the message. ";
        /// <summary>
        /// Error occurred while Adding invalid client(Wrapper) header.
        /// </summary>
        internal const String MESSAGE_WRAPPERHEADER_ERROR = "Error occurred while Adding invalid client(Wrapper) header.";
        /// <summary>
        /// Error occurred while Writting in to Log file
        /// </summary>
        internal const String MESSAGE_LOG_ERROR = "Unable to log messages. ";
        /// <summary>
        /// Error occurred while KEYs are not present in config file for Log
        /// </summary>
        internal const String MESSAGE_CONFIG_LOG_ERROR = "Key does not exist in config file:";
        #endregion

        #region "String formation constants"

        //Constants used for Formatting the message string
        /// <summary>
        /// Format Message Separator (Message)
        /// </summary>
        internal const String FORMAT_MSG_SEPERATOR = "Message ";
        /// <summary>
        /// Format Message Line Separator (---------------------)
        /// </summary>
        internal static String FORMAT_MSG_LINESEPERATOR = Environment.NewLine;
        /// <summary>
        /// Format Message  Open Bracket ([)
        /// </summary>
        internal const String FORMAT_MSG_OPENBRACKET = "[";
        /// <summary>
        /// Format Message  Close Bracket (])
        /// </summary>
        internal const String FORMAT_MSG_CLOSEBRACKET = "]";
        /// <summary>
        /// Format Message Code body Separator (-)
        /// </summary>
        internal const String FORMAT_MSG_CODEBODY_SEP = "-";
        //

        #endregion

        #region "Communication Errors Constants"

        /// <summary>
        /// Communication Error Connection Failed
        /// </summary>
        internal const String E_SOK_CONN_FAILED = "E_SOK_CONN_FAILED";
        /// <summary>
        /// Communication Error Param Name Error
        /// </summary>
        internal const String E_PARM_NAME = "E_PARM_NAME";
        /// <summary>
        /// Communication Error Param Name Length Error
        /// </summary>
        internal const String E_PARM_NAME_LEN = "E_PARM_NAME_LEN";
        /// <summary>
        /// Communication Error Timeout Waiting for Response
        /// </summary>
        internal const String E_TIMEOUT_WAIT_RESP = "E_TIMEOUT_WAIT_RESP";
        /// <summary>
        /// Communication Error Null Host String
        /// </summary>
        internal const String E_NULL_HOST_STRING = "E_NULL_HOST_STRING";
        /// <summary>
        /// Communication Error Invalid Timeout
        /// </summary>
        internal const String E_INVALID_TIMEOUT = "E_INVALID_TIMEOUT";
        /// <summary>
        /// Communication Error Missing Request Id
        /// </summary>
        internal const String E_MISSING_REQUEST_ID = "E_MISSING_REQUEST_ID";
        /// <summary>
        /// Communication Error Empty Param List
        /// </summary>
        internal const String E_EMPTY_PARAM_LIST = "E_EMPTY_PARAM_LIST";
        /// <summary>
        /// Communication Error Context Initialization Failed
        /// </summary>
        internal const String E_CONTXT_INIT_FAILED = "E_CONTXT_INIT_FAILED";
        /// <summary>
        /// Communication Error Unknown State
        /// </summary>
        internal const String E_UNKNOWN_STATE = "E_UNKNOWN_STATE";
        /// <summary>
        /// Communication Error Invalid Name Value Pair Request
        /// </summary>
        internal const String E_INVALID_NVP = "E_INVALID_NVP";
        /// <summary>
        /// Communication Error Response Format Error
        /// </summary>
        internal const String E_RESPONSE_FORMAT_ERROR = "E_RESPONSE_FORMAT_ERROR";
        /// <summary>
        /// Communication Error Version Not Supported
        /// </summary>
        internal const String E_VERSION_NOT_SUPPORTED = "E_VERSION_NOT_SUPPORTED";
        /// <summary>
        /// Internal Error Configuration Error.
        /// </summary>
        internal const String E_CONFIG_ERROR = "E_CONFIG_ERROR";
        /// <summary>
        /// Internal Error Log error.
        /// </summary>
        internal const String E_LOG_ERROR = "E_LOG_ERROR";
        /// <summary>
        /// Internal Error Log4net initialization error.
        /// </summary>
        internal const String E_MSGFILE_INIT_ERROR = "E_MSGFILE_INIT_ERROR";
        /// <summary>
        /// Internal Error currency Process error.
        /// </summary>
		internal const String E_CURRENCY_PROCESS_ERROR = "E_CURRENCY_PROCESS_ERROR";
        /// <summary>
        /// Internal Error currency Process error.
        /// </summary>
        internal const String E_COMMON_NAME = "E_COMMON_NAME";

        #endregion

        #region "Payflow params constants"

        /// <summary>
        /// Internal Param REQUEST
        /// </summary>
        internal const String INTL_PARAM_REQUEST = "REQUEST";
        /// <summary>
        /// Internal Param FULLRESPONSE
        /// </summary>
        internal const String INTL_PARAM_FULLRESPONSE = "FULLRESPONSE";
        /// <summary>
        /// Internal Param PAYFLOW_HOST
        /// </summary>
        internal const String INTL_PARAM_PAYFLOW_HOST = "PAYFLOW_HOST";
        /// <summary>
        /// Internal Param PAYFLOW_PORT
        /// </summary>
        internal const String INTL_PARAM_PAYFLOW_PORT = "PAYFLOW_PORT";
        /// <summary>
        /// Internal Param PAYFLOW_TIMEOUT
        /// </summary>
        internal const String INTL_PARAM_PAYFLOW_TIMEOUT = "PAYFLOW_TIMEOUT";
        /// <summary>
        /// Internal Param rule
        /// </summary>
        internal const String XML_PARAM_RULE = "rule";
        /// <summary>
        /// Internal Param num
        /// </summary>
        internal const String XML_PARAM_NUM = "num";
        /// <summary>
        /// Internal Param ruleId
        /// </summary>
        internal const String XML_PARAM_RULEID = "ruleId";
        /// <summary>
        /// Internal Param ruleAlias
        /// </summary>
        internal const String XML_PARAM_RULEALIAS = "ruleAlias";
        /// <summary>
        /// Internal Param ruleDescription
        /// </summary>
        internal const String XML_PARAM_RULEDESCRIPTION = "ruleDescription";
        /// <summary>
        /// Internal Param action
        /// </summary>
        internal const String XML_PARAM_ACTION = "action";
        /// <summary>
        /// Internal Param triggeredMessage
        /// </summary>
        internal const String XML_PARAM_TRIGGEREDMESSAGE = "triggeredMessage";
        /// <summary>
        /// Internal Param rulevendorparms
        /// </summary>
        internal const String XML_PARAM_RULEVENDORPARMS = "rulevendorparms";
        /// <summary>
        /// Internal Param ruleParameter
        /// </summary>
        internal const String XML_PARAM_RULEPARAMETER = "ruleParameter";
        /// <summary>
        /// Internal Param name
        /// </summary>
        internal const String XML_PARAM_NAME = "name";
        /// <summary>
        /// Internal Param value
        /// </summary>
        internal const String XML_PARAM_VALUE = "value";
        /// <summary>
        /// Internal Param type
        /// </summary>
        internal const String XML_PARAM_TYPE = "type";
        /// <summary>
        /// XML Pay Param version
        /// </summary>
        internal const String XML_PARAM_VERSION = "version";
        /// <summary>
        /// XML Pay Param Vendor
        /// </summary>
        internal const String XML_PARAM_VENDOR = "Vendor";
        /// <summary>
        /// XML Pay Param User
        /// </summary>
        internal const String XML_PARAM_USER = "User";
        /// <summary>
        /// XML Pay Param Partner
        /// </summary>
        internal const String XML_PARAM_PARTNER = "Partner";
        /// <summary>
        /// XML Pay Param Password
        /// </summary>
        internal const String XML_PARAM_PASSWORD = "Password";
        /// <summary>
        /// XML Pay Param AcctNum
        /// </summary>
        internal const String XML_PARAM_ACCTNUM = "AcctNum";
        /// <summary>
        /// XML Pay Param CardNum
        /// </summary>
        internal const String XML_PARAM_CARDNUM = "CardNum";
        /// <summary>
        /// XML Pay Param ExpDate
        /// </summary>
        internal const String XML_PARAM_EXPDATE = "ExpDate";
        /// <summary>
        /// XML Pay Param MagData
        /// </summary>
        internal const String XML_PARAM_MAGDATA = "MagData";
        /// <summary>
        /// XML Pay Param MICR
        /// </summary>
        internal const String XML_PARAM_MICR = "MICR";
        /// <summary>
        /// XML Pay Param CVNum
        /// </summary>
        internal const String XML_PARAM_CVNUM = "CVNum";
        /// <summary>
        /// XML Pay Param DL
        /// </summary>
        internal const String XML_PARAM_DL = "DL";
        /// <summary>
        /// XML Pay Param SS
        /// </summary>
        internal const String XML_PARAM_SS = "SS";
        /// <summary>
        /// XML Pay Param DOB
        /// </summary>
        internal const String XML_PARAM_DOB = "DOB";
        /// <summary>
        /// XML Pay Start tag 
        /// </summary>
        internal const String XML_PARAM_START_TAG = "<?xml version='1.0' encoding='UTF-8'?><XMLPayRequest version ='";
        /// <summary>
        /// Payflow Param AUTHTYPE
        /// </summary>
        internal const String PARAM_AUTHTYPE = "AUTHTYPE";
        /// <summary>
        /// Payflow Param PRENOTE
        /// </summary>
        internal const String PARAM_PRENOTE = "PRENOTE";
        /// <summary>
        /// Payflow Param TERMCITY
        /// </summary>
        internal const String PARAM_TERMCITY = "TERMCITY";
        /// <summary>
        /// Payflow Param TERMSTATE
        /// </summary>
        internal const String PARAM_TERMSTATE = "TERMSTATE";
        /// <summary>
        /// Payflow Param ABA
        /// </summary>
        internal const String PARAM_ABA = "ABA";
        /// <summary>
        /// Payflow Param ACCTTYPE
        /// </summary>
        internal const String PARAM_ACCTTYPE = "ACCTTYPE";
        /// <summary>
        /// Payflow Param TENDER
        /// </summary>
        internal const String PARAM_TENDER = "TENDER";
        /// <summary>
        /// Payflow Param CHKNUM
        /// </summary>
        internal const String PARAM_CHKNUM = "CHKNUM";
        /// <summary>
        /// Payflow Param CHKTYPE
        /// </summary>
        internal const String PARAM_CHKTYPE = "CHKTYPE";
        /// <summary>
        /// Payflow Param STREET
        /// </summary>
        internal const String PARAM_STREET = "BILLTOSTREET";
        /// <summary>
        /// Payflow Param BILLTOSTREET2
        /// </summary>
        internal const String PARAM_BILLTOSTREET2 = "BILLTOSTREET2";
        /// <summary>
        /// Payflow Param CITY
        /// </summary>
        internal const String PARAM_CITY = "BILLTOCITY";
        /// <summary>
        /// Payflow Param STATE
        /// </summary>
        internal const String PARAM_STATE = "BILLTOSTATE";
        /// <summary>
        /// Payflow Param COUNTRY
        /// </summary>
        internal const String PARAM_COUNTRY = "COUNTRY";
        // Changed from BILLTOCOUNTRY to COUNTRY since Recurring
        // Billing does not map BILLTOCOUNTRY correctly.
        /// <summary>
        /// Payflow Param BILLTOCOUNTRY
        /// </summary>
        internal const String PARAM_BILLTOCOUNTRY = "BILLTOCOUNTRY";
        /// <summary>
        /// Payflow Param ZIP
        /// </summary>
        internal const String PARAM_ZIP = "BILLTOZIP";
        /// <summary>
        /// Payflow Param PHONENUM
        /// </summary>
        internal const String PARAM_PHONENUM = "BILLTOPHONENUM";
        /// <summary>
        /// Payflow Param BILLTOPHONE2
        /// </summary>
        internal const String PARAM_BILLTOPHONE2 = "BILLTOPHONE2";
        /// <summary>
        /// Payflow Param EMAIL
        /// </summary>
        internal const String PARAM_EMAIL = "BILLTOEMAIL";
        /// <summary>
        /// Payflow Param FAX
        /// </summary>
        internal const String PARAM_FAX = "BILLTOFAX";
        /// <summary>
        /// Payflow Param FIRSTNAME
        /// </summary>
        internal const String PARAM_FIRSTNAME = "BILLTOFIRSTNAME";
        /// <summary>
        /// Payflow Param MIDDLENAME
        /// </summary>
        internal const String PARAM_MIDDLENAME = "BILLTOMIDDLENAME";
        /// <summary>
        /// Payflow Param LASTNAME
        /// </summary>
        internal const String PARAM_LASTNAME = "BILLTOLASTNAME";
        /// <summary>
        /// Payflow Param HOMEPHONE
        /// </summary>
        internal const String PARAM_HOMEPHONE = "HOMEPHONE";
        /// <summary>
        /// Payflow Param BROWSERTIME
        /// </summary>
        internal const String PARAM_BROWSERTIME = "BROWSERTIME";
        /// <summary>
        /// Payflow Param BROWSERCOUNTRYCODE
        /// </summary>
        internal const String PARAM_BROWSERCOUNTRYCODE = "BROWSERCOUNTRYCODE";
        /// <summary>
        /// Payflow Param ECHODATA
        /// </summary>
        internal const String PARAM_ECHODATA = "ECHODATA";
        /// <summary>
        /// Payflow Param BROWSERUSERAGENT
        /// </summary>
        internal const String PARAM_BROWSERUSERAGENT = "BROWSERUSERAGENT";
        /// <summary>
        /// Payflow Param ACSURL
        /// </summary>
        internal const String PARAM_ACSURL = "ACSURL";
        /// <summary>
        /// Payflow Param AUTHENICATION_ID
        /// </summary>
        internal const String PARAM_AUTHENICATION_ID = "AUTHENTICATION_ID";
        /// <summary>
        /// Payflow Param AUTHENICATION_STATUS
        /// </summary>
        internal const String PARAM_AUTHENICATION_STATUS = "AUTHENTICATION_STATUS";
        /// <summary>
        /// Payflow Param CAVV
        /// </summary>
        internal const String PARAM_CAVV = "CAVV";
        /// <summary>
        /// Payflow Param ECI
        /// </summary>
        internal const String PARAM_ECI = "ECI";
        /// <summary>
        /// Payflow Param DSTRANSACTIONID 
        /// </summary>
        internal const String PARAM_DSTRANSACTIONID = "DSTRANSACTIONID";
        /// <summary>
        /// Payflow Param THREEDSVERSION
        /// </summary>
        internal const String PARAM_THREEDSVERSION = "THREEDSVERSION";
        /// <summary>
        /// Payflow Param MD
        /// </summary>
        internal const String PARAM_MD = "MD";
        /// <summary>
        /// Payflow Param PAREQ
        /// </summary>
        internal const String PARAM_PAREQ = "PAREQ";
        /// <summary>
        /// Payflow Param XID
        /// </summary>
        internal const String PARAM_XID = "XID";
        /// <summary>
        /// Payflow Param MICR
        /// </summary>
        internal const String PARAM_MICR = "MICR";
        /// <summary>
        /// Payflow Param NAME
        /// </summary>
        internal const String PARAM_NAME = "NAME";
        /// <summary>
        /// Payflow Param DL
        /// </summary>
        internal const String PARAM_DL = "DL";
        /// <summary>
        /// Payflow Param SS
        /// </summary>
        internal const String PARAM_SS = "SS";
        /// <summary>
        /// Payflow Param REQNAME
        /// </summary>
        internal const String PARAM_REQNAME = "REQNAME";
        /// <summary>
        /// Payflow Param CUSTCODE
        /// </summary>
        internal const String PARAM_CUSTCODE = "CUSTCODE";
        /// <summary>
        /// Payflow Param CUSTIP
        /// </summary>
        internal const String PARAM_CUSTIP = "CUSTIP";
        /// <summary>
        /// Payflow Param CUSTHOSTNAME
        /// </summary>
        internal const String PARAM_CUSTHOSTNAME = "CUSTHOSTNAME";
        /// <summary>
        /// Payflow Param CUSTBROWSER
        /// </summary>
        internal const String PARAM_CUSTBROWSER = "CUSTBROWSER";
        /// <summary>
        /// Payflow Param CUSTVATREGNUM
        /// </summary>
        internal const String PARAM_CUSTVATREGNUM = "CUSTVATREGNUM";
        /// <summary>
        /// Payflow Param DOB
        /// </summary>
        internal const String PARAM_DOB = "DOB";
        /// <summary>
        /// Payflow Param CUSTID
        /// </summary>
        internal const String PARAM_CUSTID = "CUSTID";
        /// <summary>
        /// Payflow Param COMPANYNAME
        /// </summary>
        internal const String PARAM_COMPANYNAME = "COMPANYNAME";
        /// <summary>
        /// Payflow Param CORPNAME
        /// </summary>
        internal const String PARAM_CORPNAME = "CORPNAME";
        /// <summary>
        /// Payflow Param MERCHDESCR
        /// </summary>
        internal const String PARAM_MERCHDESCR = "MERCHDESCR";
        /// <summary>
        /// Payflow Param MERCHSVC
        /// </summary>
        internal const String PARAM_MERCHSVC = "MERCHSVC";
        /// <summary>
        /// Payflow Param ADDLMSGS
        /// </summary>
        internal const String PARAM_ADDLMSGS = "ADDLMSGS";
        /// <summary>
        /// Payflow Param PREFPSMSG
        /// </summary>
        internal const String PARAM_PREFPSMSG = "PREFPSMSG";
        /// <summary>
        /// Payflow Param POSTFPSMSG
        /// </summary>
        internal const String PARAM_POSTFPSMSG = "POSTFPSMSG";
        /// <summary>
        /// Payflow Param RESPTEXT
        /// </summary>
        internal const String PARAM_RESPTEXT = "RESPTEXT";
        /// <summary>
        /// Payflow Param PROCAVS
        /// </summary>
        internal const String PARAM_PROCAVS = "PROCAVS";
        /// <summary>
        /// Payflow Param PROCCARDSECURE
        /// </summary>
        internal const String PARAM_PROCCARDSECURE = "PROCCARDSECURE";
        /// <summary>
        /// Payflow Param PROCCVV2
        /// </summary>
        internal const String PARAM_PROCCVV2 = "PROCCVV2";
        /// <summary>
        /// Payflow Param HOSTCODE
        /// </summary>
        internal const String PARAM_HOSTCODE = "HOSTCODE";
        /// <summary>
        /// Payflow Param INVNUM
        /// </summary>
        internal const String PARAM_INVNUM = "INVNUM";
        /// <summary>
        /// Payflow Param AMT
        /// </summary>
        internal const String PARAM_AMT = "AMT";
        /// <summary>
        /// Payflow Param TAXEXEMPT
        /// </summary>
        internal const String PARAM_TAXEXEMPT = "TAXEXEMPT";
        /// <summary>
        /// Payflow Param TAXAMT
        /// </summary>
        internal const String PARAM_TAXAMT = "TAXAMT";
        /// <summary>
        /// Payflow Param DUTYAMT
        /// </summary>
        internal const String PARAM_DUTYAMT = "DUTYAMT";
        /// <summary>
        /// Payflow Param FREIGHTAMT
        /// </summary>
        internal const String PARAM_FREIGHTAMT = "FREIGHTAMT";
        /// <summary>
        /// Payflow Param HANDLINGAMT
        /// </summary>
        internal const String PARAM_HANDLINGAMT = "HANDLINGAMT";
        /// <summary>
        /// Payflow Param SHIPPINGAMT
        /// </summary>
        internal const String PARAM_SHIPPINGAMT = "SHIPPINGAMT";
        ///<summary>
        /// Payflow Param DISCOUNT
        /// </summary>
        internal const String PARAM_DISCOUNT = "DISCOUNT";
        /// <summary>
        /// Payflow Param DESC
        /// </summary>
        internal const String PARAM_DESC = "DESC";
        /// <summary>
        /// Payflow Param COMMENT1
        /// </summary>
        internal const String PARAM_COMMENT1 = "COMMENT1";
        /// <summary>
        /// Payflow Param COMMENT2
        /// </summary>
        internal const String PARAM_COMMENT2 = "COMMENT2";
        /// <summary>
        /// Payflow Param DESC1
        /// </summary>
        internal const String PARAM_DESC1 = "DESC1";
        /// <summary>
        /// Payflow Param DESC2
        /// </summary>
        internal const String PARAM_DESC2 = "DESC2";
        /// <summary>
        /// Payflow Param DESC3
        /// </summary>
        internal const String PARAM_DESC3 = "DESC3";
        /// <summary>
        /// Payflow Param DESC4
        /// </summary>
        internal const String PARAM_DESC4 = "DESC4";
        /// <summary>
        /// Payflow Param CUSTREF
        /// </summary>
        internal const String PARAM_CUSTREF = "CUSTREF";
        /// <summary>
        /// Payflow Param PONUM
        /// </summary>
        internal const String PARAM_PONUM = "PONUM";
        /// <summary>
        /// Payflow Param VATREGNUM
        /// </summary>
        internal const String PARAM_VATREGNUM = "VATREGNUM";
        /// <summary>
        /// Payflow Param VATTAXAMT
        /// </summary>
        internal const String PARAM_VATTAXAMT = "VATTAXAMT";
        /// <summary>
        /// Payflow Param LOCALTAXAMT
        /// </summary>
        internal const String PARAM_LOCALTAXAMT = "LOCALTAXAMT";
        /// <summary>
        /// Payflow Param NATIONALTAXAMT
        /// </summary>
        internal const String PARAM_NATIONALTAXAMT = "NATIONALTAXAMT";
        /// <summary>
        /// Payflow Param ALTTAXAMT
        /// </summary>
        internal const String PARAM_ALTTAXAMT = "ALTTAXAMT";
        /// <summary>
        /// Payflow Param COMMCODE
        /// </summary>
        internal const String PARAM_COMMCODE = "COMMCODE";
        /// <summary>
        /// Payflow Param INVOICEDATE
        /// </summary>
        internal const String PARAM_INVOICEDATE = "INVOICEDATE";
        /// <summary>
        /// Payflow Param STARTTIME
        /// </summary>
        internal const String PARAM_STARTTIME = "STARTTIME";
        /// <summary>
        /// Payflow Param ENDTIME
        /// </summary>
        internal const String PARAM_ENDTIME = "ENDTIME";
        /// <summary>
        /// Payflow Param ORDERDATE
        /// </summary>
        internal const String PARAM_ORDERDATE = "ORDERDATE";
        /// <summary>
        /// Payflow Param ORDERTIME
        /// </summary>
        internal const String PARAM_ORDERTIME = "ORDERTIME";
        /// <summary>
        /// Payflow Param L_AMTn
        /// </summary>
        internal const String PARAM_L_AMT = "L_AMT";
        /// <summary>
        /// Payflow Param L_COSTn
        /// </summary>
        internal const String PARAM_L_COST = "L_COST";
        /// <summary>
        /// Payflow Param L_FREIGHTAMTn
        /// </summary>
        internal const String PARAM_L_FREIGHTAMT = "L_FREIGHTAMT";
        /// <summary>
        /// Payflow Param L_HANDLINGAMTn
        /// </summary>
        internal const String PARAM_L_HANDLINGAMT = "L_HANDLINGAMT";
        /// <summary>
        /// Payflow Param L_TAXAMTn
        /// </summary>
        internal const String PARAM_L_TAXAMT = "L_TAXAMT";
        /// <summary>
        /// Payflow Param L_UOMn
        /// </summary>
        internal const String PARAM_L_UOM = "L_UOM";
        /// <summary>
        /// Payflow Param L_PICKUPSTREETn
        /// </summary>
        internal const String PARAM_L_PICKUPSTREET = "L_PICKUPSTREET";
        /// <summary>
        /// Payflow Param L_PICKUPSTATEn
        /// </summary>
        internal const String PARAM_L_PICKUPSTATE = "L_PICKUPSTATE";
        /// <summary>
        /// Payflow Param L_PICKUPCOUNTRYn
        /// </summary>
        internal const String PARAM_L_PICKUPCOUNTRY = "L_PICKUPCOUNTRY";
        /// <summary>
        /// Payflow Param L_PICKUPCITYn
        /// </summary>
        internal const String PARAM_L_PICKUPCITY = "L_PICKUPCITY";
        /// <summary>
        /// Payflow Param L_PICKUPZIPn
        /// </summary>
        internal const String PARAM_L_PICKUPZIP = "L_PICKUPZIP";
        /// <summary>
        /// Payflow Param L_DESCn
        /// </summary>
        internal const String PARAM_L_DESC = "L_DESC";
        /// <summary>
        /// Payflow Param L_DISCOUNTn
        /// </summary>
        internal const String PARAM_L_DISCOUNT = "L_DISCOUNT";
        /// <summary>
        /// Payflow Param L_MANUFACTURERn
        /// </summary>
        internal const String PARAM_L_MANUFACTURER = "L_MANUFACTURER";
        /// <summary>
        /// Payflow Param L_PRODCODEn
        /// </summary>
        internal const String PARAM_L_PRODCODE = "L_PRODCODE";
        /// <summary>
        /// Payflow Param ITEMAMT
        /// </summary>
        internal const String PARAM_ITEMAMT = "ITEMAMT";
        /// <summary>
        /// Payflow Param L_ITEMNUMBERn
        /// </summary>
        internal const String PARAM_L_ITEMNUMBER = "L_ITEMNUMBER";
        /// <summary>
        /// Payflow Param L_QTYn
        /// </summary>
        internal const String PARAM_L_QTY = "L_QTY";
        /// <summary>
        /// Payflow Param L_SKUn
        /// </summary>
        internal const String PARAM_L_SKU = "L_SKU";
        /// <summary>
        /// Payflow Param L_TAXRATEn
        /// </summary>
        internal const String PARAM_L_TAXRATE = "L_TAXRATE";
        /// <summary>
        /// Payflow Param L_TAXTYPEn
        /// </summary>
        internal const String PARAM_L_TAXTYPE = "L_TAXTYPE";
        /// <summary>
        /// Payflow Param L_TYPEn
        /// </summary>
        internal const String PARAM_L_TYPE = "L_TYPE";
        /// <summary>
        /// Payflow Param L_COMMCODEn
        /// </summary>
        internal const String PARAM_L_COMMCODE = "L_COMMCODE";
        /// <summary>
        /// Payflow Param L_TRACKINGNUMn
        /// </summary>
        internal const String PARAM_L_TRACKINGNUM = "L_TRACKINGNUM";
        /// <summary>
        /// Payflow Param L_COSTCENTERNUMn
        /// </summary>
        internal const String PARAM_L_COSTCENTERNUM = "L_COSTCENTERNUM";
        /// <summary>
        /// Payflow Param L_CATALOGNUMn
        /// </summary>
        internal const String PARAM_L_CATALOGNUM = "L_CATALOGNUM";
        /// <summary>
        /// Payflow Param L_UPCn
        /// </summary>
        internal const String PARAM_L_UPC = "L_UPC";
        /// <summary>
        /// Payflow Param L_UNSPSCCODE
        /// </summary>
        internal const String PARAM_L_UNSPSCCODE = "L_UNSPSCCODE";
        /// <summary>
        /// Payflow Param L_NAME
        /// </summary>
        internal const String PARAM_L_NAME = "L_NAME";
        /// <summary>
        /// Payflow Param EXPDATE
        /// </summary>
        internal const String PARAM_EXPDATE = "EXPDATE";
        /// <summary>
        /// Payflow Param CVV2
        /// </summary>
        internal const String PARAM_CVV2 = "CVV2";
        /// <summary>
        /// Payflow Param ACCT
        /// </summary>
        internal const String PARAM_ACCT = "ACCT";
        /// <summary>
        /// Payflow Param COMMCARD
        /// </summary>
        internal const String PARAM_COMMCARD = "COMMCARD";
        /// <summary>
        /// Payflow Param PROFILENAME
        /// </summary>
        internal const String PARAM_PROFILENAME = "PROFILENAME";
        /// <summary>
        /// Payflow Param START
        /// </summary>
        internal const String PARAM_START = "START";
        /// <summary>
        /// Payflow Param TERM
        /// </summary>
        internal const String PARAM_TERM = "TERM";
        /// <summary>
        /// Payflow Param PAYPERIOD
        /// </summary>
        internal const String PARAM_PAYPERIOD = "PAYPERIOD";
        /// <summary>
        /// Payflow Param OPTIONALTRX
        /// </summary>
        internal const String PARAM_OPTIONALTRX = "OPTIONALTRX";
        /// <summary>
        /// Payflow Param OPTIONALTRXAMT
        /// </summary>
        internal const String PARAM_OPTIONALTRXAMT = "OPTIONALTRXAMT";
        /// <summary>
        /// Payflow Param RETRYNUMDAYS
        /// </summary>
        internal const String PARAM_RETRYNUMDAYS = "RETRYNUMDAYS";
        /// <summary>
        /// Payflow Param MAXFAILPAYMENTS
        /// </summary>
        internal const String PARAM_MAXFAILPAYMENTS = "MAXFAILPAYMENTS";
        /// <summary>
        /// Payflow Param NUMFAILPAYMENTS
        /// </summary>
        internal const String PARAM_NUMFAILPAYMENTS = "NUMFAILPAYMENTS";
        /// <summary>
        /// Payflow Param ORIGPROFILEID
        /// </summary>
        internal const String PARAM_ORIGPROFILEID = "ORIGPROFILEID";
        /// <summary>
        /// Payflow Param PAYMENTHISTORY
        /// </summary>
        internal const String PARAM_PAYMENTHISTORY = "PAYMENTHISTORY";
        /// <summary>
        /// Payflow Param PAYMENTNUM
        /// </summary>
        internal const String PARAM_PAYMENTNUM = "PAYMENTNUM";
        /// <summary>
		/// Payflow Param PAYMENTNUM
		/// </summary>
		internal const String PARAM_FREQUENCY = "FREQUENCY";
        /// <summary>
		/// Payflow Param RECURRING
		/// </summary>
		internal const String PARAM_RECURRING = "RECURRING";
        /// <summary>
        /// Payflow Param PROFILEID
        /// </summary>
        internal const String PARAM_PROFILEID = "PROFILEID";
        /// <summary>
        /// Payflow Param RPREF
        /// </summary>
        internal const String PARAM_RPREF = "RPREF";
        /// <summary>
        /// Payflow Param TRXPNREF
        /// </summary>
        internal const String PARAM_TRXPNREF = "TRXPNREF";
        /// <summary>
        /// Payflow Param TRXRESULT
        /// </summary>
        internal const String PARAM_TRXRESULT = "TRXRESULT";
        /// <summary>
        /// Payflow Param TRXRESPMSG
        /// </summary>
        internal const String PARAM_TRXRESPMSG = "TRXRESPMSG";
        /// <summary>
        /// Payflow Param STATUS
        /// </summary>
        internal const String PARAM_STATUS = "STATUS";
        /// <summary>
        /// Payflow Param PAYMENTSLEFT
        /// </summary>
        internal const String PARAM_PAYMENTSLEFT = "PAYMENTSLEFT";
        /// <summary>
        /// Payflow Param NEXTPAYMENT
        /// </summary>
        internal const String PARAM_NEXTPAYMENT = "NEXTPAYMENT";
        /// <summary>
        /// Payflow Param END
        /// </summary>
        internal const String PARAM_END = "END";
        /// <summary>
        /// Payflow Param AGGREGATEAMT
        /// </summary>
        internal const String PARAM_AGGREGATEAMT = "AGGREGATEAMT";
        /// <summary>
        /// Payflow Param AGGREGATEOPTIONALAMT
        /// </summary>
        internal const String PARAM_AGGREGATEOPTIONALAMT = "AGGREGATEOPTIONALAMT";
        /// <summary>
        /// Payflow Param SHIPTOFIRSTNAME
        /// </summary>
        internal const String PARAM_SHIPTOFIRSTNAME = "SHIPTOFIRSTNAME";
        /// <summary>
        /// Payflow Param SHIPTOMIDDLENAME
        /// </summary>
        internal const String PARAM_SHIPTOMIDDLENAME = "SHIPTOMIDDLENAME";
        /// <summary>
        /// Payflow Param SHIPTOLASTNAME
        /// </summary>
        internal const String PARAM_SHIPTOLASTNAME = "SHIPTOLASTNAME";
        /// <summary>
        /// Payflow Param SHIPTOSTREET
        /// </summary>
        internal const String PARAM_SHIPTOSTREET = "SHIPTOSTREET";
        /// <summary>
        /// Payflow Param SHIPTOCITY
        /// </summary>
        internal const String PARAM_SHIPTOCITY = "SHIPTOCITY";
        /// <summary>
        /// Payflow Param SHIPTOSTATE
        /// </summary>
        internal const String PARAM_SHIPTOSTATE = "SHIPTOSTATE";
        /// <summary>
        /// Payflow Param SHIPTOZIP
        /// </summary>
        internal const String PARAM_SHIPTOZIP = "SHIPTOZIP";
        /// <summary>
        /// Payflow Param SHIPTOCOUNTRY
        /// </summary>
        internal const String PARAM_SHIPTOCOUNTRY = "SHIPTOCOUNTRY";
        /// <summary>
        /// Payflow Param P_RESULTn
        /// </summary>
        internal const String PARAM_P_RESULTn = "P_RESULTn";
        /// <summary>
        /// Payflow Param P_PNREFn
        /// </summary>
        internal const String PARAM_P_PNREFn = "P_PNREFn";
        /// <summary>
        /// Payflow Param P_TRANSTATEn
        /// </summary>
        internal const String PARAM_P_TRANSTATEn = "P_TRANSTATEn";
        /// <summary>
        /// Payflow Param P_TENDERn
        /// </summary>
        internal const String PARAM_P_TENDERn = "P_TENDERn";
        /// <summary>
        /// Payflow Param P_TRANSTIMEn
        /// </summary>
        internal const String PARAM_P_TRANSTIMEn = "P_TRANSTIMEn";
        /// <summary>
        /// Payflow Param P_AMOUNTn
        /// </summary>
        internal const String PARAM_P_AMTn = "P_AMTn";
        /// <summary>
        /// Payflow Param FPS_PREXMLDATA
        /// </summary>
        internal const String PARAM_FPS_PREXMLDATA = "FPS_PREXMLDATA";
        /// <summary>
        /// Payflow Param FPS_POSTXMLDATA
        /// </summary>
        internal const String PARAM_FPS_POSTXMLDATA = "FPS_POSTXMLDATA";
        /// <summary>
        /// Payflow Param SHIPTOSTREET2
        /// </summary>
        internal const String PARAM_SHIPTOSTREET2 = "SHIPTOSTREET2";
        /// <summary>
        /// Payflow Param SHIPTOPHONE
        /// </summary>
        internal const String PARAM_SHIPTOPHONE = "SHIPTOPHONE";
        /// <summary>
        /// Payflow Param SHIPTOPHONE2
        /// </summary>
        internal const String PARAM_SHIPTOPHONE2 = "SHIPTOPHONE2";
        /// <summary>
        /// Payflow Param SHIPTOEMAIL
        /// </summary>
        internal const String PARAM_SHIPTOEMAIL = "SHIPTOEMAIL";
        /// <summary>
        /// Payflow Param SHIPCARRIER
        /// </summary>
        internal const String PARAM_SHIPCARRIER = "SHIPCARRIER";
        /// <summary>
        /// Payflow Param SHIPMETHOD
        /// </summary>
        internal const String PARAM_SHIPMETHOD = "SHIPMETHOD";
        /// <summary>
        /// Payflow Param SHIPFROMZIP
        /// </summary>
        internal const String PARAM_SHIPFROMZIP = "SHIPFROMZIP";
        /// <summary>
        /// Payflow Param SHIPPEDFROMZIP
        /// </summary>
        internal const String PARAM_SHIPPEDFROMZIP = "SHIPPEDFROMZIP";
        /// <summary>
        /// Payflow Param SWIPE
        /// </summary>
        internal const String PARAM_SWIPE = "SWIPE";
        /// <summary>
        /// Payflow Param RESULT
        /// </summary>
        internal const String PARAM_RESULT = "RESULT";
        /// <summary>
        /// Payflow Param PNREF
        /// </summary>
        internal const String PARAM_PNREF = "PNREF";
        /// <summary>
        /// Payflow Param RESPMSG
        /// </summary>
        internal const String PARAM_RESPMSG = "RESPMSG";
        /// <summary>
        /// Payflow Param AUTHCODE
        /// </summary>
        internal const String PARAM_AUTHCODE = "AUTHCODE";
        /// <summary>
        /// Payflow Param AVSADDR
        /// </summary>
        internal const String PARAM_AVSADDR = "AVSADDR";
        /// <summary>
        /// Payflow Param AVSZIP
        /// </summary>
        internal const String PARAM_AVSZIP = "AVSZIP";
        /// <summary>
        /// Payflow Param CARDSECURE
        /// </summary>
        internal const String PARAM_CARDSECURE = "CARDSECURE";
        /// <summary>
        /// Payflow Param CVV2MATCH
        /// </summary>
        internal const String PARAM_CVV2MATCH = "CVV2MATCH";
        /// <summary>
        /// Payflow Param EMAILMATCH
        /// </summary>
        internal const String PARAM_EMAILMATCH = "EMAILMATCH";
        /// <summary>
        /// Payflow Param PHONEMATCH
        /// </summary>
        internal const String PARAM_PHONEMATCH = "PHONEMATCH";
        /// <summary>
        /// Payflow Param IAVS
        /// </summary>
        internal const String PARAM_IAVS = "IAVS";
        /// <summary>
        /// Payflow Param ORIGRESULT
        /// </summary>
        internal const String PARAM_ORIGRESULT = "ORIGRESULT";
        /// <summary>
        /// Payflow Param TRANSSTATE
        /// </summary>
        internal const String PARAM_TRANSSTATE = "TRANSSTATE";
        /// <summary>
        /// Payflow Param USER
        /// </summary>
        internal const String PARAM_USER = "USER";
        /// <summary>
        /// Payflow Param VENDOR
        /// </summary>
        internal const String PARAM_VENDOR = "VENDOR";
        /// <summary>
        /// Payflow Param PARTNER
        /// </summary>
        internal const String PARAM_PARTNER = "PARTNER";
        /// <summary>
        /// Payflow Param PWD
        /// </summary>
        internal const String PARAM_PWD = "PWD";
        /// <summary>
        /// Payflow Param TRXTYPE
        /// </summary>
        internal const String PARAM_TRXTYPE = "TRXTYPE";
        /// <summary>
        /// Payflow Param VERBOSITY
        /// </summary>
        internal const String PARAM_VERBOSITY = "VERBOSITY";
        /// <summary>
        /// Payflow Param PARES
        /// </summary>
        internal const String PARAM_PARES = "PARES";
        /// <summary>
        /// Payflow Param CURRENCY
        /// </summary>
        internal const String PARAM_CURRENCY = "CURRENCY";
        /// <summary>
        /// Payflow Param PUR_DESC
        /// </summary>
        internal const String PARAM_PUR_DESC = "PUR_DESC";
        /// <summary>
        /// Payflow Param ORIGID
        /// </summary>
        internal const String PARAM_ORIGID = "ORIGID";
        /// <summary>
        /// Payflow Param UPDATEACTION
        /// </summary>
        internal const String PARAM_UPDATEACTION = "UPDATEACTION";
        /// <summary>
        /// Payflow Param ACTION
        /// </summary>
        internal const String PARAM_ACTION = "ACTION";
        /// <summary>
        /// Payflow Param VIT_OSNAME
        /// </summary>
        internal const String PARAM_VIT_OSNAME = "VIT_OSNAME";
        /// <summary>
        /// Payflow Param VIT_OSARCH
        /// </summary>
        internal const String PARAM_VIT_OSARCH = "VIT_OSARCH";
        /// <summary>
        /// Payflow Param VIT_OSVERSION
        /// </summary>
        internal const String PARAM_VIT_OSVERSION = "VIT_OSVERSION";
        /// <summary>
        /// Payflow Param VIT_SDKRUNTIMEVERSION
        /// </summary>
        internal const String PARAM_VIT_SDKRUNTIMEVERSION = "VIT_SDKRUNTIMEVERSION";
        /// <summary>
        /// Payflow Param VIT_PROXY
        /// </summary>
        internal const String PARAM_VIT_PROXY = "VIT_PROXY";
        /// <summary>
        /// Payflow Param VIT_WRAPTYPE
        /// </summary>
        internal const String PARAM_VIT_WRAPTYPE = "VIT_WRAPTYPE";
        /// <summary>
        /// Payflow Param VIT_WRAPVERSION
        /// </summary>
        internal const String PARAM_VIT_WRAPVERSION = "VIT_WRAPVERSION";
        /// <summary>
        /// Payflow Param REQUEST_ID
        /// </summary>
        internal const String PARAM_REQUEST_ID = "REQUEST_ID";
        /// <summary>
        /// Payflow Param VATTAXPERCENT
        /// </summary>
        internal const String PARAM_VATTAXPERCENT = "VATTAXPERCENT";
        /// <summary>
        /// Payflow Param DUPLICATE
        /// </summary>
        internal const String PARAM_DUPLICATE = "DUPLICATE";
        /// <summary>
        /// Payflow Param DATE_TO_SETTLE
        /// </summary>
        internal const String PARAM_DATE_TO_SETTLE = "DATE_TO_SETTLE";
        /// <summary>
        /// Payflow Param BATCHID
        /// </summary>
        internal const String PARAM_BATCHID = "BATCHID";
        /// <summary>
        /// Recurring Inquiry Response Param Prefix 
        /// </summary>
        internal const String PREFIX_RECURRING_INQUIRY_RESP = "P_";
        /// <summary>
        /// Payflow Param SETTLE_DATE
        /// </summary>
        internal const String PARAM_SETTLE_DATE = "SETTLE_DATE";
        /// <summary>
        /// Payflow Param ORIGPNREF
        /// </summary>
        internal const String PARAM_ORIGPNREF = "ORIGPNREF";
        /// <summary>
        /// Payflow Param TOKEN
        /// </summary>
        internal const String PARAM_TOKEN = "TOKEN";
        /// <summary>
        /// Payflow Param MAXAMT
        /// </summary>
        internal const String PARAM_MAXAMT = "MAXAMT";
        /// <summary>
        /// Payflow Param RETURNURL
        /// </summary>
        internal const String PARAM_RETURNURL = "RETURNURL";
        /// <summary>
        /// Payflow Param CANCELURL
        /// </summary>
        internal const String PARAM_CANCELURL = "CANCELURL";
        /// <summary>
        /// Payflow Param REQCONFIRMSHIPPING
        /// </summary>
        internal const String PARAM_REQCONFIRMSHIPPING = "REQCONFIRMSHIPPING";
        /// <summary>
        /// Payflow Param NOSHIPPING
        /// </summary>
        internal const String PARAM_NOSHIPPING = "NOSHIPPING";
        /// <summary>
        /// Payflow Param ADDROVERRIDE
        /// </summary>
        internal const String PARAM_ADDROVERRIDE = "ADDROVERRIDE";
        /// <summary>
        /// Payflow Param LOCALECODE
        /// </summary>
        internal const String PARAM_LOCALECODE = "LOCALECODE";
        /// <summary>
        /// Payflow Param PAGESTYLE
        /// </summary>
        internal const String PARAM_PAGESTYLE = "PAGESTYLE";
        /// <summary>
        /// Payflow Param HDRIMG
        /// </summary>
        internal const String PARAM_HDRIMG = "HDRIMG";
        /// <summary>
        /// Payflow Param HDRBORDERCOLOR
        /// </summary>
        internal const String PARAM_HDRBORDERCOLOR = "HDRBORDERCOLOR";
        /// <summary>
        /// Payflow Param HDRBACKCOLOR
        /// </summary>
        internal const String PARAM_HDRBACKCOLOR = "HDRBACKCOLOR";
        /// <summary>
        /// Payflow Param PAYFLOWCOLOR
        /// </summary>
        internal const String PARAM_PAYFLOWCOLOR = "PAYFLOWCOLOR";
        /// <summary>
        /// Payflow Param POSTALCODE
        /// </summary>
        internal const String PARAM_POSTALCODE = "POSTALCODE";
        /// <summary>
        /// Payflow Param COUNTRYCODE
        /// </summary>
        internal const String PARAM_COUNTRYCODE = "COUNTRYCODE";
        /// <summary>
        /// Payflow Param PAYERID
        /// </summary>
        internal const String PARAM_PAYERID = "PAYERID";
        /// <summary>
        /// Payflow Param NOTIFYURL
        /// </summary>
        internal const String PARAM_NOTIFYURL = "NOTIFYURL";
        /// <summary>
        /// Payflow Param L_XXXXn
        /// </summary>
        internal const String PARAM_ITEMNUMBER = "L_XXXXn";
        /// <summary>
        /// Payflow Param BUTTONSOURCE
        /// </summary>
        internal const String PARAM_BUTTONSOURCE = "BUTTONSOURCE";
        /// <summary>
        /// Payflow Param PAYERSTATUS
        /// </summary>
        internal const String PARAM_PAYERSTATUS = "PAYERSTATUS";
        /// <summary>
        /// Payflow Param SHIPTOCOUNTRYCODE
        /// </summary>
        internal const String PARAM_SHIPTOCOUNTRYCODE = "SHIPTOCOUNTRYCODE";
        /// <summary>
        /// Payflow Param SHIPTOBUSINESS
        /// </summary>
        internal const String PARAM_SHIPTOBUSINESS = "SHIPTOBUSINESS";
        /// <summary>
        /// Payflow Param ADDRSTATUS
        /// </summary>
        internal const String PARAM_ADDRSTATUS = "ADDRSTATUS";
        /// <summary>
        /// Payflow Param PPREF
        /// </summary>
        internal const String PARAM_PPREF = "PPREF";
        /// <summary>
        /// Payflow Param FEEAMT
        /// </summary>
        internal const String PARAM_FEEAMT = "FEEAMT";
        /// <summary>
        /// Payflow Param SETTLEAMT
        /// </summary>
        internal const String PARAM_SETTLEAMT = "SETTLEAMT";
        /// <summary>
        /// Payflow Param EXCHANGERATE
        /// </summary>
        internal const String PARAM_EXCHANGERATE = "EXCHANGERATE";
        /// <summary>
        /// Payflow Param PENDINGREASON
        /// </summary>
        internal const String PARAM_PENDINGREASON = "PENDINGREASON";
        /// <summary>
        /// Payflow Param PAYMENTTYPE
        /// </summary>
        internal const String PARAM_PAYMENTTYPE = "PAYMENTTYPE";
        /// <summary>
        /// Payflow Param PAYMENTDATE
        /// </summary>
        internal const String PARAM_PAYMENTDATE = "PAYMENTDATE";
        /// <summary>
        /// Payflow Param PAYMENTSTATUS
        /// </summary>
        internal const String PARAM_PAYMENTSTATUS = "PAYMENTSTATUS";
        /// <summary>
        /// Payflow Param CUSTOM
        /// </summary>
        internal const String PARAM_CUSTOM = "CUSTOM";
        /// <summary>
        /// Payflow Param MERCHANTSESSIONID
        /// </summary>
        internal const String PARAM_MERCHANTSESSIONID = "MERCHANTSESSIONID";
        /// <summary>
        /// Payflow Param ORDERDESC
        /// </summary>
        internal const String PARAM_ORDERDESC = "ORDERDESC";
        /// <summary>
        /// Payflow Param ORIGPPREF
        /// </summary>
        internal const String PARAM_ORIGPPREF = "ORIGPPREF";
        /// <summary>
        /// Payflow Param CARDSTART
        /// </summary>
        internal const String PARAM_CARDSTART = "CARDSTART";
        /// <summary>
        /// Payflow Param CARDISSUE
        /// </summary>
        internal const String PARAM_CARDISSUE = "CARDISSUE";
        /// <summary>
        /// Payflow Param CORRELATIONID
        /// </summary>
        internal const String PARAM_CORRELATIONID = "CORRELATIONID";
        /// <summary>
        /// Payflow Param CAPTURECOMPLETE
        /// </summary>
        internal const String PARAM_CAPTURECOMPLETE = "CAPTURECOMPLETE";
        /// <summary>
        /// Payflow Param RECURRINGTYPE
        /// </summary>
        internal const String PARAM_RECURRINGTYPE = "RECURRINGTYPE";
        /// <summary>
        /// Payflow Param NOTE
        /// </summary>
        internal const String PARAM_NOTE = "NOTE";
        /// <summary>
        /// Payflow Param MEMO
        /// </summary>
        internal const String PARAM_MEMO = "MEMO";
        /// <summary>
        /// Payflow Param BALAMT
        /// </summary>
        internal const String PARAM_BALAMT = "BALAMT";
        /// <summary>
        /// Payflow Param AMEXID
        /// </summary>
        internal const String PARAM_AMEXID = "AMEXID";
        /// <summary>
        /// Payflow Param AMEXPOSDATA
        /// </summary>
        internal const String PARAM_AMEXPOSDATA = "AMEXPOSDATA";
        /// <summary>
        /// Payflow Param BILLINGTYPE
        /// </summary>
        internal const String PARAM_BILLINGTYPE = "BILLINGTYPE";
        /// <summary>
        /// Payflow Param BA_DESC
        /// </summary>
        internal const String PARAM_BA_DESC = "BA_DESC";
        /// <summary>
        /// Payflow Param BA_CUSTOM
        /// </summary>
        internal const String PARAM_BA_CUSTOM = "BA_CUSTOM";
        /// <summary>
        /// Payflow Param BA_FLAG
        /// </summary>
        internal const String PARAM_BA_FLAG = "BA_FLAG";
        /// <summary>
        /// Payflow Param BAID
        /// </summary>
        internal const String PARAM_BAID = "BAID";
        /// <summary>
        /// Payflow Param BA_STATUS
        /// </summary>
        internal const String PARAM_BA_STATUS = "BA_STATUS";
        /// <summary>
        /// Payflow Param MERCHANTNAME
        /// </summary>
        internal const String PARAM_MERCHANTNAME = "MERCHANTNAME";
        /// <summary>
        /// Payflow Param MERCHANTSTREET
        /// </summary>
        internal const String PARAM_MERCHANTSTREET = "MERCHANTSTREET";
        /// <summary>
        /// Payflow Param MERCHANTCITY
        /// </summary>
        internal const String PARAM_MERCHANTCITY = "MERCHANTCITY";
        /// <summary>
        /// Payflow Param MERCHANTSTATE
        /// </summary>
        internal const String PARAM_MERCHANTSTATE = "MERCHANTSTATE";
        /// <summary>
        /// Payflow Param MERCHANTCOUNTRYCODE
        /// </summary>
        internal const String PARAM_MERCHANTCOUNTRYCODE = "MERCHANTCOUNTRYCODE";
        /// <summary>
        /// Payflow Param MERCHANTZIP
        /// </summary>
        internal const String PARAM_MERCHANTZIP = "MERCHANTZIP";
        /// <summary>
        /// Payflow Param DOREAUTHORIZATION
        /// </summary>
        internal const String PARAM_DOREAUTHORIZATION = "DOREAUTHORIZATION";
        /// <summary>
        /// Payflow Param SHIPPINGMETHOD
        /// </summary>
        internal const String PARAM_SHIPPINGMETHOD = "SHIPPINGMETHOD";
        /// <summary>
        /// Payflow Param PROMOCODEOVERRIDE
        /// </summary>
        internal const String PARAM_PROMOCODEOVERRIDE = "PROMOCODEOVERRIDE";
        /// <summary>
        /// Payflow Param PROFILEADDRESSCHANGEDATE
        /// </summary>
        internal const String PARAM_PROFILEADDRESSCHANGEDATE = "PROFILEADDRESSCHANGEDATE";
        /// <summary>
        /// Payflow Param PAYPALCHECKOUTBTNTYPE
        /// </summary>
        internal const String PARAM_PAYPALCHECKOUTBTNTYPE = "PAYPALCHECKOUTBTNTYPE";
        /// <summary>
        /// Payflow Param PRODUCTCATEGORY
        /// </summary>
        internal const String PARAM_PRODUCTCATEGORY = "PRODUCTCATEGORY";
        /// <summary>
        /// Payflow Param PROMOCODE
        /// </summary>
        internal const String PARAM_PROMOCODE = "PROMOCODE";
        /// <summary>
        /// Payflow Param TRANSTIME
        /// </summary>
        internal const String PARAM_TRANSTIME = "TRANSTIME";
        /// <summary>
        /// Payflow Param CARDTYPE
        /// </summary>
        internal const String PARAM_CARDTYPE = "CARDTYPE";
        /// <summary>
        /// Payflow Param ORIGAMT
        /// </summary>
        internal const String PARAM_ORIGAMT = "ORIGAMT";
        /// <summary>
        /// Payflow Param PARTIALAUTH
        /// </summary>
        internal const String PARAM_PARTIALAUTH = "PARTIALAUTH";
        /// <summary>
        /// Payflow Param EXTRSPMSG
        /// </summary>
        internal const String PARAM_EXTRSPMSG = "EXTRSPMSG";
        /// <summary>
        /// Payflow Param SECURETOKEN
        /// </summary>
        internal const String PARAM_SECURETOKEN = "SECURETOKEN";
        /// <summary>
        /// Payflow Param SECURETOKENID
        /// </summary>
        internal const String PARAM_SECURETOKENID = "SECURETOKENID";
        /// <summary>
        /// Payflow Param CREATESECURETOKEN
        /// </summary>
        internal const String PARAM_CREATESECURETOKEN = "CREATESECURETOKEN";
        /// <summary>
        /// Payflow Param VISACARDLEVEL
        /// </summary>
        internal const String PARAM_VISACARDLEVEL = "VISACARDLEVEL";
        /// <summary>
        /// Payflow Param ALLOWNOTE
        /// </summary>
        internal const String PARAM_ALLOWNOTE = "ALLOWNOTE";
        /// <summary>
        /// Payflow Param REQBILLINGADDRESS
        /// </summary>
        internal const String PARAM_REQBILLINGADDRESS = "REQBILLINGADDRESS";
        /// <summary>
        /// Payflow Param SHIPTONAME
        /// </summary>
        internal const String PARAM_SHIPTONAME = "SHIPTONAME";
        /// <summary>
        /// Payflow Param ORDERID
        /// </summary>
        internal const String PARAM_ORDERID = "ORDERID";
        /// <summary>
        /// Payflow Param USER1
        /// </summary>
        internal const String PARAM_USER1 = "USER1";
        /// <summary>
        /// Payflow Param USER2
        /// </summary>
        internal const String PARAM_USER2 = "USER2";
        /// <summary>
        /// Payflow Param USER3
        /// </summary>
        internal const String PARAM_USER3 = "USER3";
        /// <summary>
        /// Payflow Param USER4
        /// </summary>
        internal const String PARAM_USER4 = "USER4";
        /// <summary>
        /// Payflow Param USER5
        /// </summary>
        internal const String PARAM_USER5 = "USER5";
        /// <summary>
        /// Payflow Param USER6
        /// </summary>
        internal const String PARAM_USER6 = "USER6";
        /// <summary>
        /// Payflow Param USER7
        /// </summary>
        internal const String PARAM_USER7 = "USER7";
        /// <summary>
        /// Payflow Param USER8
        /// </summary>
        internal const String PARAM_USER8 = "USER8";
        /// <summary>
        /// Payflow Param USER9
        /// </summary>
        internal const String PARAM_USER9 = "USER9";
        /// <summary>
        /// Payflow Param USER10
        /// </summary>
        internal const String PARAM_USER10 = "USER10";
        /// <summary>
        /// Payflow Param TRACEID
        /// </summary>
        internal const String PARAM_TRACEID = "TRACEID";
        /// <summary>
        /// Payflow Param ACHSTATUS
        /// </summary>
        internal const String PARAM_ACHSTATUS = "ACHSTATUS";
        /// <summary>
        /// Payflow Param CARDONFILE
        /// </summary>
        internal const String PARAM_CARDONFILE = "CARDONFILE";
        /// <summary>
        /// Payflow Param TXID
        /// </summary>
        internal const String PARAM_TXID = "TXID";
        /// <summary>
        /// Payflow Param PAYMENTADVICECODE
        /// </summary>
        internal const String PARAM_PAYMENTADVICECODE = "PAYMENTADVICECODE";
        /// <summary>
        /// Payflow Param ASSOCIATIONRESPCODE
        /// </summary>
        internal const String PARAM_ASSOCIATIONRESPCODE = "ASSOCIATIONRESPCODE";
        /// <summary>
        /// Payflow Param TYPE
        /// </summary>
        internal const String PARAM_TYPE = "TYPE";
        /// <summary>
        /// Payflow Param AFFLUENT
        /// </summary>
        internal const String PARAM_AFFLUENT = "AFFLUENT";
        /// <summary>
        /// Payflow Param CCUPDATED
        /// </summary>
        internal const String PARAM_CCUPDATED = "CCUPDATED";
        /// <summary>
        /// Payflow Param RRN
        /// </summary>
        internal const String PARAM_RRN = "RRN";  
        /// <summary>
        /// Payflow Param STAN
        /// </summary>
        internal const String PARAM_STAN = "STAN"; 
        /// <summary>
        /// Payflow Param ACI
        /// </summary>
        internal const String PARAM_ACI = "ACI";
        /// <summary>
        /// Payflow Param VALIDATIONCODE
        /// </summary>
        internal const String PARAM_VALIDATIONCODE = "VALIDATIONCODE";
        /// <summary>
        /// Payflow Param MERCHANTLOCATIONID
        /// </summary>
        internal const String PARAM_MERCHANTLOCATIONID = "MERCHANTLOCATIONID";
        /// <summary>
        /// Payflow Param MERCHANTID
        /// </summary>
        internal const String PARAM_MERCHANTID = "MERCHANTID";
        /// <summary>
        /// Payflow Param MERCHANTCONTACTINFO
        /// </summary>
        internal const String PARAM_MERCHANTCONTACTINFO = "MERCHANTCONTACTINFO";
        /// <summary>
        /// Payflow Param CCTRANSID
        /// </summary>
        internal const String PARAM_CCTRANSID = "CCTRANSID";
        /// <summary>
        /// Payflow Param CCTRANS_POSDATA
        /// </summary>
        internal const String PARAM_CCTRANS_POSDATA= "CCTRANS_POSDATA";
        /// <summary>
        /// Payflow Param AUTHDATE
        /// </summary>
        internal const String PARAM_AUTHDATE= "AUTHDATE";
        /// <summary>
        /// Payflow Param MERCHANTURL
        /// </summary>
        internal const String PARAM_MERCHANTURL = "MERCHANTURL";
        /// <summary>
        /// Payflow Param MERCHANTVATNUM
        /// </summary>
        internal const String PARAM_MERCHANTVATNUM = "MERCHANTVATNUM";
        /// <summary>
        /// Payflow Param MERCHANTINVNUM
        /// </summary>
        internal const String PARAM_MERCHANTINVNUM = "MERCHANTINVNUM";
        /// <summary>
        /// Payflow Param VATINVNUM
        /// </summary>
        internal const String PARAM_VATINVNUM = "VATINVNUM";
        /// <summary>
        /// Payflow Param VATTAXRATE
        /// </summary>
        internal const String PARAM_VATTAXRATE = "VATTAXRATE";
         /// <summary>
        /// Payflow Param REPORTGROUP
        /// </summary>
        internal const String PARAM_REPORTGROUP = "REPORTGROUP";
        /// <summary>
        /// Payflow Param L_ALTTAXAMT
        /// </summary>
        internal const String PARAM_L_ALTTAXAMT = "L_ALTTAXAMT";
        /// <summary>
        /// Payflow Param L_ALTTAXID
        /// </summary>
        internal const String PARAM_L_ALTTAXID = "L_ALTTAXID";
        /// <summary>
        /// Payflow Param L_ALTTAXRATE
        /// </summary>
        internal const String PARAM_L_ALTTAXRATE = "L_ALTTAXRATE";
        /// <summary>
        /// Payflow Param L_CARRIERSERVICELEVELCODE
        /// </summary>
        internal const String PARAM_L_CARRIERSERVICELEVELCODE = "L_CARRIERSERVICELEVELCODE";
        /// <summary>
        /// Payflow Param L_EXTAMT
        /// </summary>
        internal const String PARAM_L_EXTAMT = "L_EXTAMT";
                /// <summary>
        /// Payflow Param LADDLAMT
        /// </summary>
        internal const String PARAM_ADDLAMT = "ADDLAMT";
        /// <summary>
        /// Payflow Param ADDLAMTTYPE
        /// </summary>
        internal const String PARAM_ADDLAMTTYPE= "ADDLAMTTYPE";
        /// <summary>
        /// Payflow Param CATTYPE
        /// </summary>
        internal const String PARAM_CATTYPE = "CATTYPE";
        /// <summary>
        /// Payflow Param CONTACTLESS
        /// </summary>
        internal const String PARAM_CONTACTLESS = "CONTACTLESS";
        /// <summary>
        /// Payflow Param CUSTDATA
        /// </summary>
        internal const String PARAM_CUSTDATA = "CUSTDATA";
        /// <summary>
        /// Payflow Param CUSTOMERID
        /// </summary>
        internal const String PARAM_CUSTOMERID = "CUSTOMERID";
        /// <summary>
        /// Payflow Param CUSTOMERNUMBER
        /// </summary>
        internal const String PARAM_CUSTOMERNUMBER = "CUSTOMERNUMBER";
        /// <summary>
        /// Payflow Param MISCDATA
        /// </summary>
        internal const String PARAM_MISCDATA = "MISCDATA";

        // added DTPAYFLOW-1691 - March 2022 - v5.02
        /// <summary>
        /// Payflow Param CREATIONDATE
        /// </summary>
        internal const String PARAM_CREATIONDATE = "CREATIONDATE";
        /// <summary>
        /// Payflow Param LASTCHANGED
        /// </summary>
        internal const String PARAM_LASTCHANGED = "LASTCHANGED";
        /// <summary>
        /// Payflow Param RPSTATE
        /// </summary>
        internal const String PARAM_RPSTATE = "RPSTATE";
        /// <summary>
        /// Payflow Param NEXTPAYMENTNUM
        /// </summary>
        internal const String PARAM_NEXTPAYMENTNUM = "NEXTPAYMENTNUM";
        /// <summary>
        /// Payflow Param SCAEXEMPTION
        /// </summary>
        internal const String PARAM_SCAEXEMPTION = "SCAEXEMPTION";
        /// <summary>
        /// Payflow Param CITDATE
        /// </summary>
        internal const String PARAM_CITDATE = "CITDATE";
        /// <summary>
        /// Payflow Param VMAID
        /// </summary>
        internal const String PARAM_VMAID = "VMAID";
        /// <summary>
        /// Payflow Param VMAID
        /// </summary>
        internal const String PARAM_PAR = "PAR";
        /// <summary>
        /// Payflow Param VMAID
        /// </summary>
        internal const String PARAM_PARID = "PARID";






        #endregion

        #region "MagTek Encrypted Swipe params constants"
        /// <summary>
        /// Magtek Param ENCMP
        /// </summary>
        internal const String MAGTEK_PARAM_ENCMP = "ENCMP";
        /// <summary>
        /// Magtek Param ENCRYPTIONBLOCKTYPE
        /// </summary>
        internal const String MAGTEK_PARAM_ENCRYPTIONBLOCKTYPE = "ENCRYPTIONBLOCKTYPE";
        /// <summary>
        /// Magtek Param ENCTRACK1
        /// </summary>
        internal const String MAGTEK_PARAM_ENCTRACK1 = "ENCTRACK1";
        /// <summary>
        /// Magtek Param ENCTRACK2
        /// </summary>
        internal const String MAGTEK_PARAM_ENCTRACK2 = "ENCTRACK2";
        /// <summary>
        /// Magtek Param ENCTRACK3
        /// </summary>
        internal const String MAGTEK_PARAM_ENCTRACK3 = "ENCTRACK3";
        /// <summary>
        /// Magtek Param KSN
        /// </summary>
        internal const String MAGTEK_PARAM_KSN = "KSN";
        /// <summary>
        /// Magtek Param MAGTEKCARDTYPE
        /// </summary>
        internal const String MAGTEK_PARAM_MAGTEKCARDTYPE = "MAGTEKCARDTYPE";
        /// <summary>
        /// Magtek Param MPSTATUS
        /// </summary>
        internal const String MAGTEK_PARAM_MPSTATUS = "MPSTATUS";
        /// <summary>
        /// Magtek Param REGISTEREDBY
        /// </summary>
        internal const String MAGTEK_PARAM_REGISTEREDBY = "REGISTEREDBY";
        /// <summary>
        /// Magtek Param SWIPEDECRHOST
        /// </summary>
        internal const String MAGTEK_PARAM_SWIPEDECRHOST = "SWIPEDECRHOST";
        /// <summary>
        /// Magtek Param DEVICESN
        /// </summary>
        internal const String MAGTEK_PARAM_DEVICESN = "DEVICESN";
        /// <summary>
        /// Magtek Param MERCHANTID
        /// </summary>
        internal const String MAGTEK_PARAM_MERCHANTID = "MERCHANTID";
        /// <summary>
        /// Magtek Param PAN4
        /// </summary>
        internal const String MAGTEK_PARAM_PAN4 = "PAN4";
        /// <summary>
        /// Magtek Param PCODE
        /// </summary>
        internal const String MAGTEK_PARAM_PCODE = "PCODE";
        /// <summary>
        /// Magtek Param AUTHVALUE1
        /// </summary>
        internal const String MAGTEK_PARAM_AUTHVALUE1 = "AUTHVALUE1";
        /// <summary>
        /// Magtek Param AUTHVALUE2
        /// </summary>
        internal const String MAGTEK_PARAM_AUTHVALUE2 = "AUTHVALUE2";
        /// <summary>
        /// Magtek Param AUTHVALUE3
        /// </summary>
        internal const String MAGTEK_PARAM_AUTHVALUE3 = "AUTHVALUE3";
        /// <summary>
        /// Magtek Param MAGTEKUSERNAME
        /// </summary>
        internal const String MAGTEK_PARAM_MAGTEKUSERNAME = "MAGTEKUSERNAME";
        /// <summary>
        /// Magtek Param MAGTEKUSERPWD
        /// </summary>
        internal const String MAGTEK_PARAM_MAGTEKPWD = "MAGTEKPWD";
        /// <summary>
        /// Magtek Param MAGTRESPONSE
        /// </summary>
        internal const String MAGTEK_PARAM_MAGTRESPONSE = "MAGTRESPONSE";

        #endregion

        #region "Client Information Constants"
        /// <summary>
        /// Constant for PAYFLOW-CLIENT-DURATION
        /// </summary>
        internal const String PAYFLOWHEADER_CLIENT_DURATION = "X-VPS-VIT-CLIENT-DURATION";
        /// <summary>
        /// Constant for PAYFLOW-CLIENT-VERSION
        /// </summary>
        internal const String PAYFLOWHEADER_CLIENT_VERSION = "X-VPS-VIT-CLIENT-VERSION";
        /// <summary>
        /// Constant for PAYFLOW-OS-ARCHITECTURE
        /// </summary>
        internal const String PAYFLOWHEADER_OS_ARCHITECTURE = "X-VPS-VIT-OS-ARCHITECTURE";
        /// <summary>
        /// Constant for PAYFLOW-OS-NAME
        /// </summary>
        internal const String PAYFLOWHEADER_OS_NAME = "X-VPS-VIT-OS-NAME";
        /// <summary>
        /// Constant for PAYFLOW-OS-VERSION
        /// </summary>
        internal const String PAYFLOWHEADER_OS_VERSION = "X-VPS-VIT-OS-VERSION";
        /// <summary>
        /// Constant for PAYFLOW-PROXY
        /// </summary>
        internal const String PAYFLOWHEADER_PROXY = "X-VPS-VIT-PROXY";
        /// <summary>
        /// Constant for PAYFLOW-RUNTIME-VERSION
        /// </summary>
        internal const String PAYFLOWHEADER_RUNTIME_VERSION = "X-VPS-VIT-RUNTIME-VERSION";
        /// <summary>
        /// Constant for PAYFLOW-INTEGRATION-PRODUCT
        /// </summary>
        internal const String PAYFLOWHEADER_INTEGRATION_PRODUCT = "X-VPS-VIT-INTEGRATION-PRODUCT";
        /// <summary>
        /// Constant for PAYFLOW-INTEGRATION-VERSION
        /// </summary>
        internal const String PAYFLOWHEADER_INTEGRATION_VERSION = "X-VPS-VIT-INTEGRATION-VERSION";
        /// <summary>
        /// Constant for PAYFLOW-CLIENT-TYPE
        /// </summary>
        internal const String PAYFLOWHEADER_CLIENT_TYPE = "X-VPS-VIT-CLIENT-TYPE";
        /// <summary>
        /// Constant for PAYFLOW-CLIENT-TYPE
        /// </summary>
        internal const String PAYFLOWHEADER_ASSEMBLY = "X-VPS-VIT-ASSEMBLY";
        #endregion

        #region "ActionRelated Constants"

        /// <summary>
        /// Set Action (S)
        /// </summary>
        internal const String ACTIONTYPE_SET = "S";
        /// <summary>
        /// Get Action (G)
        /// </summary>
        internal const String ACTIONTYPE_GET = "G";
        /// <summary>
        /// Do Action (D)
        /// </summary>
        internal const String ACTIONTYPE_DO = "D";
        /// <summary>
        /// Update Action (U)
        /// </summary>
        internal const String ACTIONTYPE_UPDATEBA = "U";
        /// <summary>
        /// SetBA Action (Z)
        /// </summary>
        internal const String ACTIONTYPE_SETBA = "Z";
        /// <summary>
        /// GETBA Action (W)
        /// </summary>
        internal const String ACTIONTYPE_GETBA = "W";
        /// <summary>
        /// DOBA Action (X)
        /// </summary>
        internal const String ACTIONTYPE_DOBA = "X";

        #endregion

    }
}
