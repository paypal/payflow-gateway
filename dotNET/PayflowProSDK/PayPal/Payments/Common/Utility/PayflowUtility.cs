#region "Imports"

using System;
using System.Collections;
using System.Text;
using System.Xml;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.DataObjects;
using System.Configuration;

#endregion

namespace PayPal.Payments.Common.Utility
{
    /// <summary>
    /// Utility class
    /// </summary>
    public sealed class PayflowUtility
    {

        /// <summary>
        /// This is used to check whether constant for 
        /// TRACE is intialized already or not.
        /// </summary>
        private static bool mTraceInitialized = false;

        #region "Properties"

        /// <summary>
        /// Generates Request Id
        /// </summary>
        public static String RequestId
        {
            get
            {
                String RequestId;
                Guid GuidValue = Guid.NewGuid();
                RequestId = GuidValue.ToString("N");
                return RequestId;
            }
        }

        /// <summary>
        /// Gets, sets mTraceInitialized
        /// </summary>
        internal static bool TraceInitialized
        {
            get { return mTraceInitialized; }
            set { mTraceInitialized = value; }
        }

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor for PayflowUtility
        /// </summary>
        private PayflowUtility()
        {
        }

        #endregion

        #region "Functions"

        /// <summary>
        /// Appends a name value pair to request
        /// </summary>
        /// <param name="Name">Payflow  param name</param>
        /// <param name="Value">Value</param>
        /// <returns>Formatted name value pair string</returns>
        internal static String AppendToRequest(String Name, Object Value)
        {
            String RetVal = null;
            StringBuilder NVPair = new StringBuilder();

            if (Name == null || Value == null)
            {
                return PayflowConstants.EMPTY_STRING;
            }

            /*if(Value != null && Value.ToString().Length == 0)
            {
                return "";
            }*/

            String StringValue = Value.ToString();
            NVPair.Append(Name);
            NVPair.Append(PayflowConstants.OPENING_BRACE_NVP);
            NVPair.Append(StringValue.Length);
            NVPair.Append(PayflowConstants.CLOSING_BRACE_NVP);
            NVPair.Append(PayflowConstants.SEPARATOR_NVP);
            NVPair.Append(StringValue);
            NVPair.Append(PayflowConstants.DELIMITER_NVP);

            RetVal = NVPair.ToString();

            return RetVal;

        }

        /// <summary>
        /// Locates value from name value pair and masks or
        /// returns it.
        /// </summary>
        /// <param name="ParamList">Paramalist</param>
        /// <param name="Name">Payflow  Param name</param>
        /// <param name="MaskFoundValue">true if sensitive fields from the param list need to be masked,
        ///  false if need to extract a param value from param list</param>
        /// <returns>Param Value if MaskFoundValue is false, Masked param list if MaskFoundValue is true</returns>
        public static String LocateValueForName(String ParamList, String Name, bool MaskFoundValue)
        {
            String Value;
            if (MaskFoundValue)
            {
                Value = ParamList;
            }
            else
            {
                Value = PayflowConstants.EMPTY_STRING;
            }

            if (ParamList != null && ParamList.Length > 0)
            {
                int NameIndex = ParamList.IndexOf(Name + PayflowConstants.SEPARATOR_NVP);
                if (NameIndex < 0)
                {
                    NameIndex = ParamList.IndexOf(Name + PayflowConstants.OPENING_BRACE_NVP);
                    if (NameIndex < 0)
                    {
                        return Value;
                    }
                }
                int PrevNameIndex = NameIndex;
                if (NameIndex > 0)
                {
                    if (ParamList[NameIndex - 1] != '&')
                    {
                        NameIndex = ParamList.IndexOf(Name + PayflowConstants.SEPARATOR_NVP, PrevNameIndex);
                        if (NameIndex < 0)
                        {
                            NameIndex = ParamList.IndexOf(Name + PayflowConstants.OPENING_BRACE_NVP, PrevNameIndex + 1);
                            if (NameIndex < 0)
                            {
                                return Value;
                            }
                        }
                    }
                }

                int NVSeparatorIndex = ParamList.IndexOf("=", NameIndex);
                if (NVSeparatorIndex > 0)
                {
                    int NVDelimiterIndex = ParamList.IndexOf("&", NVSeparatorIndex);
                    if (NVDelimiterIndex + 1 < ParamList.Length && ParamList[NVDelimiterIndex + 1] == '&')
                    {
                        NVDelimiterIndex += 2;
                        NVDelimiterIndex = ParamList.IndexOf("&", NVDelimiterIndex);
                    }

                    if (NVDelimiterIndex < 0)
                    {
                        NVDelimiterIndex = ParamList.Length;
                    }

                    if (MaskFoundValue)
                    {
                        int MaskIndex;
                        char[] ValueArr = Value.ToCharArray();
                        if (Name == PayflowConstants.PARAM_ACCT)
                        {
                            for (MaskIndex = NVSeparatorIndex + 7; MaskIndex < NVDelimiterIndex - 4; MaskIndex++)
                            {
                                ValueArr[MaskIndex] = 'X';
                            }
                        }
                        else
                        {
                            for (MaskIndex = NVSeparatorIndex + 1; MaskIndex < NVDelimiterIndex; MaskIndex++)
                            {
                                ValueArr[MaskIndex] = 'X';
                            }
                        }
                        Value = new String(ValueArr);
                    }
                    else
                    {
                        Value = ParamList.Substring(NVSeparatorIndex + 1, (NVDelimiterIndex) - (NVSeparatorIndex + 1));
                    }
                }
            }
            return Value;
        }


        /// <summary>
        /// Check if timeout has occurred
        /// </summary>
        /// <param name="TimeOutMsec">Time out in Msec</param>
        /// <param name="StartTimeMsec">Start time in Msec</param>
        /// <param name="TimeRemainingMsec">out Time remaining in Msec</param>
        /// <returns>True if Timed out, false otherwise</returns>
        internal static bool IsTimedOut(long TimeOutMsec, long StartTimeMsec, out long TimeRemainingMsec)
        {
            long CurrentTimeMsec = DateTime.Now.Ticks / 10000;
            long TimeElapsedMsec = CurrentTimeMsec - StartTimeMsec;
            TimeRemainingMsec = TimeOutMsec - TimeElapsedMsec;
            Logger.Instance.Log("Time Remaining = " + TimeRemainingMsec.ToString(), PayflowConstants.SEVERITY_INFO);
            if (TimeRemainingMsec >= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Retrieves XmlPay version from Xml Pay Request.
        /// </summary>
        /// <param name="Request">Xml Pay Request.</param>
        /// <returns>String Value of version</returns>
        internal static String GetXmlVersion(String Request)
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.GetXmlVersion(String): Entered.", PayflowConstants.SEVERITY_DEBUG);
            String Version;
            Version = GetXmlAttribute(Request, PayflowConstants.XML_PARAM_VERSION);
            Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.GetXmlVersion(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
            return Version;
        }

        /// <summary>
        /// Retrieves value of given Xml attribute from Xml Pay Request.
        /// </summary>
        /// <param name="Request">Xml Pay Request</param>
        /// <param name="Attribute">Attribute Tag Name</param>
        /// <returns></returns>
        internal static String GetXmlAttribute(String Request, String Attribute)
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.GetXmlAttribute(String,String): Entered.", PayflowConstants.SEVERITY_DEBUG);

            String RetVal = PayflowConstants.EMPTY_STRING;
            if (Request != null && Request.Length > 0)
            {
                String AttributeValue = null;
                XmlDocument XmlPayRequest = new XmlDocument();
                XmlPayRequest.LoadXml(Request);
                XmlNodeList XmlPayChildNodes = XmlPayRequest.ChildNodes;
                foreach (XmlNode XmlPayNode in XmlPayChildNodes)
                {
                    if (XmlPayNode.LocalName.Equals(PayflowConstants.XMLPAY_REQUEST_TAG))
                    {
                        XmlAttributeCollection XmlPayReqAttributes = XmlPayNode.Attributes;
                        if (XmlPayReqAttributes != null)
                        {
                            XmlNode AttributeNode = XmlPayReqAttributes.GetNamedItem(Attribute);
                            if (AttributeNode != null)
                            {
                                AttributeValue = AttributeNode.InnerText;
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                RetVal = AttributeValue;
            }
            return RetVal;
        }

        /// <summary>
        /// Gets the Xml Namespace from the XmlPay Request.
        /// </summary>
        /// <param name="Request">Xml Pay Request.</param>
        /// <returns>String Value of Xml Namespace.</returns>
        internal static String GetXmlNameSpace(String Request)
        {
            Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.GetXmlNameSpace(String): Entered.", PayflowConstants.SEVERITY_DEBUG);

            String XmlNameSpace = "";
            String XmlPayVersion = null;
            XmlPayVersion = GetXmlVersion(Request);
            if (!("1.0".Equals(XmlPayVersion)))
            {
                XmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;
            }
            Logger.Instance.Log("PayPal.Payments.Communication.PaymentState.GetXmlNameSpace(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
            return XmlNameSpace;

        }

        /// <summary>
        /// Gets the inner text from an xml node.
        /// </summary>
        /// <param name="XmlPayRequest">XmlPay Request loaded in System.Xml.XmlDocument.</param>
        /// <param name="NodeName">Node Name</param>
        /// <returns>Inner text in node.</returns>
        internal static String GetXmlNodeValue(XmlDocument XmlPayRequest, String NodeName)
        {
            String RetVal = PayflowConstants.EMPTY_STRING;
            if (XmlPayRequest != null && NodeName != null && NodeName.Length > 0)
            {
                XmlNodeList NodeList = XmlPayRequest.GetElementsByTagName(NodeName);
                if (NodeList != null && NodeList.Count == 1)
                {
                    XmlNode NodeElement = NodeList[0];
                    if (NodeElement != null)
                    {
                        RetVal = NodeElement.InnerText;
                    }
                }
            }
            return RetVal;
        }



        /// <summary>
        /// Populates Errors from Exceptions.
        /// </summary>
        /// <param name="CommMessageCode">Error Message Code</param>
        /// <param name="Ex">Occurred Exception, pass null if no Exception.</param>
        /// <param name="AddMessage">Additional Message</param>
        /// <param name="IsXmlPayReq">True if request is xml pay request, false otherwise</param>  
        /// <param name="SeverityLevel">Severity Level</param>
        /// <returns>Populated ErrorObject.</returns>
        internal static ErrorObject PopulateCommError(String CommMessageCode,
                                                      Exception Ex, int SeverityLevel, bool IsXmlPayReq, String AddMessage)
        {
            String Message;
            String MessageCode;
            String Trace = PayflowConstants.EMPTY_STRING;

            InitStackTraceOn();

            string[] MsgParams = null;

            if (AddMessage == null)
            {
                AddMessage = PayflowConstants.EMPTY_STRING;
            }
            else if (AddMessage.Length > 0)
            {
                AddMessage = " " + AddMessage;
            }
            if (Ex != null && 0 == String.Compare(PayflowConstants.TRACE_ON, PayflowConstants.TRACE, true))
            {
                Trace = " " + Ex.ToString();
            }

            Message = (String)PayflowConstants.CommErrorMessages[CommMessageCode]
                + AddMessage + Trace;

            if (IsXmlPayReq)
            {
                MessageCode = PayflowConstants.MSG_COMMUNICATION_ERROR_XMLPAY;
                MsgParams = new string[] { (String)PayflowConstants.CommErrorCodes[CommMessageCode], Message };

            }
            else
            {
                MessageCode = PayflowConstants.MSG_COMMUNICATION_ERROR;
                MsgParams = new string[] { (String)PayflowConstants.CommErrorCodes[CommMessageCode], Message };

            }


            ErrorObject InitError = new ErrorObject(SeverityLevel, MessageCode, MsgParams);
            return InitError;
        }

        /// <summary>
        /// Masks the sensitive fields in the
        /// param list which will be used for
        /// logging purpose.
        /// </summary>
        /// <param name="ParmList">Paramlist to be masked.</param>
        /// <returns>Masked param list.</returns>
        internal static String MaskSensitiveFields(String ParmList)
        {
            String RetVal;
            if (ParmList != null && ParmList.Length > 0)
            {
                if (ParmList.IndexOf(PayflowConstants.XML_ID) >= 0)
                {
                    RetVal = MaskXMLPayRequest(ParmList);
                }
                else
                {
                    RetVal = MaskNVPRequest(ParmList);
                }
            }
            else
            {
                RetVal = ParmList;
            }
            return RetVal;
        }

        /// <summary>
        /// Masks XMLPay Request
        /// </summary>
        /// <param name="ParmList">XMLPay request to be masked</param>
        /// <returns>Masked XMLPay Request</returns>
        internal static String MaskXMLPayRequest(String ParmList)
        {
            String RetVal;
            try
            {
                XmlDocument XmlPayRequest = new XmlDocument();
                XmlPayRequest.LoadXml(ParmList);
                //Mask ACCT if present : Corresponding XmlPay element --> AcctNum or CardNum
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_ACCTNUM);
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_CARDNUM);
                //Mask EXPDATE if present : Corresponding XmlPay element --> ExpDate
                //PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_EXPDATE);
                //Mask SWIPE if present : Corresponding XmlPay element --> MagData
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_MAGDATA);
                //Mask MICR if present : Corresponding XmlPay element --> MICR or MagData
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_MICR);
                //Mask CVV2 if present : Corresponding XmlPay element --> CVNum
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_CVNUM);
                //Mask PWD if present : Corresponding XmlPay element --> Password
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_PASSWORD);
                //Mask DL if present : Corresponding XmlPay element --> DL
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_DL);
                //Mask SS if present : Corresponding XmlPay element --> CVNum
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_SS);
                //Mask DOB if present : Corresponding XmlPay element --> DOB
                PayflowUtility.MaskXmlNodeValue(ref XmlPayRequest, PayflowConstants.XML_PARAM_DOB);

                RetVal = XmlPayRequest.InnerXml;
            }
            catch
            {
                RetVal = ParmList;
            }
            return RetVal;
        }

        /// <summary>
        /// Masks the NVP request
        /// </summary>
        /// <param name="ParmList">Param List to be masked</param>
        /// <returns>Masked Param List</returns>
        internal static String MaskNVPRequest(String ParmList)
        {
            String LogParmList = ParmList;
            //Mask ACCT if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_ACCT, true);
            //Mask EXPDATE if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_EXPDATE, true);
            //Mask SWIPE if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_SWIPE, true);
            //Mask MICR if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_MICR, true);
            //Mask CVV2 if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_CVV2, true);
            //Mask PWD 
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_PWD, true);
            //Mask DL if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_DL, true);
            //Mask SS if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_SS, true);
            //Mask DOB if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_DOB, true);
            //Mask MAGTEKPWD if present
            LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.MAGTEK_PARAM_MAGTEKPWD, true);
            //Mask VIT_OSNAME if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_VIT_OSNAME, true);
            //Mask VIT_OSARCH if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_VIT_OSARCH, true);
            //Mask VIT_OSVERSION if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_VIT_OSVERSION, true);
            //Mask VIT_SDKRUNTIMEVERSION if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_VIT_SDKRUNTIMEVERSION, true);
            //Mask VIT_PROXY if present
            //LogParmList = PayflowUtility.LocateValueForName(LogParmList, PayflowConstants.PARAM_VIT_PROXY, true);
            return LogParmList;
        }

        /// <summary>
        /// This method replaces the inner text of the node NodeName in the XMLPayRequest xml document with XXXXX
        /// </summary>
        /// <param name="XmlPayRequest">This is the XML Document</param>
        /// <param name="NodeName">This is the node name whose inner text is to be masked</param>
        internal static void MaskXmlNodeValue(ref XmlDocument XmlPayRequest, String NodeName)
        {
            String RetVal = "";
            String MaskValue = "";
            if (XmlPayRequest != null && NodeName != null && NodeName.Length > 0)
            {
                XmlNodeList NodeList = XmlPayRequest.GetElementsByTagName(NodeName);
                if (NodeList != null && NodeList.Count > 0)
                {
                    int n = 0;
                    do
                    {
                        XmlNode NodeElement = NodeList[n];
                        if (NodeElement != null)
                        {
                            RetVal = NodeElement.InnerText;
                            for (int i = 0; i < RetVal.Length; i++)
                            {
                                MaskValue = MaskValue + "X";
                            }
                            NodeElement.InnerText = MaskValue;
                            n++; MaskValue = "";
                        }
                    } while (n < NodeList.Count);
                }
            }
        }

        internal static void InitStackTraceOn()
        {

            if (!mTraceInitialized)
            {
                try
                {
                    String StackTraceOn;
                    StackTraceOn = PayflowUtility.AppSettings(PayflowConstants.TRACE_TAG);
                    if (0 == String.Compare(PayflowConstants.TRACE_ON, StackTraceOn, true))
                    {
                        PayflowConstants.TRACE = PayflowConstants.TRACE_ON;
                    }
                }
                catch
                {
                    PayflowConstants.TRACE = PayflowConstants.TRACE_DEFAULT;
                }
            }
            mTraceInitialized = true;
        }

        /// <summary>
        /// Provides the status of the transaction based on the transaction response.
        /// </summary>
        /// <param name="Resp">Response obtained from PayPal Payment Gateway.</param>
        /// <returns>String result for the transaction:
        /// <list type="bullet">
        /// <item>If Transaction Result = 0  then Transaction Successful.</item>
        /// <item>If Transaction Result != 0 then Transaction Failed.</item>
        /// </list>
        /// </returns>
        public static String GetStatus(Response Resp)
        {
            String Status = null;

            if (Resp.TransactionResponse != null && 0 == Resp.TransactionResponse.Result)
            {
                Status = "Transaction Successful.";
            }
            else
            {
                Status = "Transaction Failed.";
            }
            return Status;
        }

        /// <summary>
        /// Provides the status of the transaction based on the transaction responses.
        /// </summary>
        /// <param name="TransactionResponse">Transaction response string obtained from PayPal Payment Gateway.</param>
        /// <returns>String result for the transaction:
        /// <list type="bullet">
        /// <item>If Transaction Result = 0 Transaction Successful.</item>
        /// <item>If Transaction Result != 0 then Transaction Failed.</item>
        /// </list>
        /// </returns>
        public static String GetStatus(String TransactionResponse)
        {
            String Status = PayflowConstants.EMPTY_STRING;
            bool IsTrxRespXmlPay = false;
            bool NullTrxResp = false;
            int Index;
            if (TransactionResponse != null)
            {
                Index = TransactionResponse.IndexOf(PayflowConstants.XML_RESP_ID);
                if (Index >= 0)
                {
                    IsTrxRespXmlPay = true;
                }
                else
                {
                    IsTrxRespXmlPay = false;
                }
            }
            else
            {
                NullTrxResp = true;
            }


            String TrxResult = PayflowConstants.EMPTY_STRING;

            if (!NullTrxResp)
            {
                if (IsTrxRespXmlPay)
                {
                    TrxResult = GetXmlPayNodeValue(TransactionResponse, PayflowConstants.XML_PARAM_RESULT);
                }
                else
                {
                    TrxResult = LocateValueForName(TransactionResponse, PayflowConstants.PARAM_RESULT, false);
                }
            }

            if ((!NullTrxResp))
            {
                if ("0".Equals(TrxResult))
                {
                    Status = "Transaction Successful.";
                }
                else
                {
                    Status = "Transaction Failed.";
                }
            }
            return Status;
        }
        /// <summary>
        /// Returns a boolean value indicating the status of the transaction
        /// </summary>
        /// <param name="Resp">Response obtained from PayPal Payment Gateway.</param>
        /// <returns>true if transaction was success</returns>
        public static bool GetTransactionStatus(Response Resp)
        {
            return (Resp.TransactionResponse != null && 0 == Resp.TransactionResponse.Result);
        }

        /// <summary>
        /// Gets the inner text of a node from an XMLPay request
        /// </summary>
        /// <param name="XmlPayRequest">XMLPay request string</param>
        /// <param name="NodeName">Node name</param>
        /// <returns>Inner text string</returns>
        public static String GetXmlPayNodeValue(String XmlPayRequest, String NodeName)
        {
            String RetVal = null;
            try
            {
                XmlDocument XmlPayDoc = new XmlDocument();
                XmlPayDoc.LoadXml(XmlPayRequest);
                RetVal = GetXmlNodeValue(XmlPayDoc, NodeName);
            }
            catch
            {
                RetVal = null;
            }
            return RetVal;
        }


        internal static ArrayList AlignContext(Context Context, bool IsXmlPayRequest)
        {
            ArrayList Errors = Context.GetErrors();
            ArrayList RetVal = new ArrayList();
            int ErrorCount = Errors.Count;
            int Index;
            for (Index = 0; Index < ErrorCount; Index++)
            {
                ErrorObject Error = (ErrorObject)Errors[Index];
                String MessageCode = Error.MessageCode;
                if (Error != null)
                {
                    if (MessageCode != null && MessageCode.Length > 0)
                    {
                        bool Msg1012 = false;
                        bool Msg1013 = false;
                        bool Msg1015 = false;
                        bool Msg1016 = false;

                        if ("MSG_1012".Equals(MessageCode))
                        { Msg1012 = true; }
                        else if ("MSG_1013".Equals(MessageCode))
                        { Msg1013 = true; }
                        else if ("MSG_1015".Equals(MessageCode))
                        { Msg1015 = true; }
                        else if ("MSG_1016".Equals(MessageCode))
                        { Msg1016 = true; }

                        if (IsXmlPayRequest)
                        {
                            if (Msg1013 || Msg1016)
                            {
                                RetVal.Add(Error);
                            }
                            else
                            {
                                ErrorObject NewError = null;
                                try
                                {

                                    if (Msg1012)
                                    {
                                        ArrayList MsgParams = Error.MessageParams;
                                        String[] NewMsgParams = new String[] { (String)MsgParams[0],
                                                                                 (String)MsgParams[1]};
                                        NewError = new ErrorObject(Error.SeverityLevel, "MSG_1013", NewMsgParams, Error.ErrorStackTrace);
                                    }
                                    else if (Msg1015)
                                    {
                                        ArrayList MsgParams = Error.MessageParams;
                                        String[] NewMsgParams = new String[] {   (String)MsgParams[0],
                                                                                 (String)MsgParams[1]};
                                        NewError = new ErrorObject(Error.SeverityLevel, "MSG_1016", NewMsgParams, Error.ErrorStackTrace);

                                    }
                                    else
                                    {
                                        String ErrMessage = Error.ToString();
                                        NewError = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, null, Error.SeverityLevel, true, ErrMessage);
                                    }
                                }
                                catch
                                {
                                    NewError = null;
                                }

                                if (NewError != null)
                                {
                                    RetVal.Add(NewError);
                                }
                            }
                        }
                        else
                        {
                            if (Msg1012 || Msg1015)
                            {
                                RetVal.Add(Error);
                            }
                            else
                            {
                                ErrorObject NewError = null;
                                try
                                {
                                    if (Msg1013)
                                    {
                                        ArrayList MsgParams = Error.MessageParams;
                                        String[] NewMsgParams = new String[] {(String)MsgParams[2],
                                                                                 (String)MsgParams[3]};
                                        NewError = new ErrorObject(Error.SeverityLevel, "MSG_1012", NewMsgParams, Error.ErrorStackTrace);
                                    }
                                    else if (Msg1016)
                                    {
                                        ArrayList MsgParams = Error.MessageParams;
                                        String[] NewMsgParams = new String[] {(String)MsgParams[1],
                                                                                 (String)MsgParams[2]};
                                        NewError = new ErrorObject(Error.SeverityLevel, "MSG_1015", NewMsgParams, Error.ErrorStackTrace);
                                    }
                                    else
                                    {
                                        String ErrMessage = Error.ToString();
                                        NewError = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE, null, Error.SeverityLevel, false, ErrMessage);
                                    }
                                }
                                catch
                                {
                                    NewError = null;
                                }

                                if (NewError != null)
                                {
                                    RetVal.Add(NewError);
                                }
                            }
                        }
                    }
                    else
                    {
                        ErrorObject NewError = null;
                        try
                        {
                            String ErrMessage = Error.ToString();
                            if (ErrMessage != null && ErrMessage.Length > 0)
                            {
                                String Result = PayflowConstants.EMPTY_STRING;
                                String RespMsg = PayflowConstants.EMPTY_STRING;
                                bool ErrIsXmlPay = (ErrMessage.IndexOf(PayflowConstants.XML_RESP_ID) >= 0);
                                //Check whether the error string is in nvp format
                                // or xml pay format.
                                if (ErrIsXmlPay)
                                {
                                    //Try to get values in nodes Result, RespMsg
                                    Result = PayflowUtility.GetXmlPayNodeValue(ErrMessage, PayflowConstants.XML_PARAM_RESULT);
                                    RespMsg = PayflowUtility.GetXmlPayNodeValue(ErrMessage, PayflowConstants.XML_PARAM_MESSAGE);
                                }
                                else
                                {
                                    //Try to get RESULT , RESPMSG from the error if 
                                    // available.
                                    Result = PayflowUtility.LocateValueForName(ErrMessage, PayflowConstants.PARAM_RESULT, false);
                                    RespMsg = PayflowUtility.LocateValueForName(ErrMessage, PayflowConstants.PARAM_RESPMSG, false);
                                }

                                if (Result != null && Result.Length > 0 && RespMsg != null && RespMsg.Length > 0)
                                {
                                    StringBuilder NewErrMessage = new StringBuilder("");
                                    if (IsXmlPayRequest && !ErrIsXmlPay)
                                    {
                                        NewErrMessage = new StringBuilder("<XMLPayResponse xmlns='http://www.paypal.com/XMLPay'");

                                        NewErrMessage.Append("><ResponseData><TransactionResults><TransactionResult><Result>");
                                        NewErrMessage.Append(Result);
                                        NewErrMessage.Append("</Result><Message>");
                                        NewErrMessage.Append(RespMsg);
                                        NewErrMessage.Append("</Message></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");
                                        NewError = new ErrorObject(Error.SeverityLevel, "", NewErrMessage.ToString());

                                    }
                                    else if (!IsXmlPayRequest && ErrIsXmlPay)
                                    {
                                        NewErrMessage = new StringBuilder(PayflowConstants.PARAM_RESULT);
                                        NewErrMessage.Append(PayflowConstants.SEPARATOR_NVP);
                                        NewErrMessage.Append(Result);
                                        NewErrMessage.Append(PayflowConstants.DELIMITER_NVP);
                                        NewErrMessage.Append(PayflowConstants.PARAM_RESPMSG);
                                        NewErrMessage.Append(PayflowConstants.SEPARATOR_NVP);
                                        NewErrMessage.Append(RespMsg);

                                        NewError = new ErrorObject(Error.SeverityLevel, "", NewErrMessage.ToString());
                                    }
                                    else
                                    {
                                        NewError = new ErrorObject(Error.SeverityLevel, "", ErrMessage);
                                    }
                                }
                                else
                                {
                                    StringBuilder NewErrMessage = new StringBuilder("");
                                    if (IsXmlPayRequest)
                                    {
                                        NewErrMessage = new StringBuilder("<XMLPayResponse xmlns='http://www.paypal.com/XMLPay'");

                                        NewErrMessage.Append("><ResponseData><TransactionResults><TransactionResult><Result>");
                                        NewErrMessage.Append((String)PayflowConstants.CommErrorCodes[PayflowConstants.E_UNKNOWN_STATE]);
                                        NewErrMessage.Append("</Result><Message>");
                                        NewErrMessage.Append((String)PayflowConstants.CommErrorMessages[PayflowConstants.E_UNKNOWN_STATE] + " " + ErrMessage);
                                        NewErrMessage.Append("</Message></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");

                                    }
                                    else
                                    {
                                        NewErrMessage = new StringBuilder(PayflowConstants.PARAM_RESULT);
                                        NewErrMessage.Append(PayflowConstants.SEPARATOR_NVP);
                                        NewErrMessage.Append((String)PayflowConstants.CommErrorCodes[PayflowConstants.E_UNKNOWN_STATE]);
                                        NewErrMessage.Append(PayflowConstants.DELIMITER_NVP);
                                        NewErrMessage.Append(PayflowConstants.PARAM_RESPMSG);
                                        NewErrMessage.Append(PayflowConstants.SEPARATOR_NVP);
                                        NewErrMessage.Append((String)PayflowConstants.CommErrorMessages[PayflowConstants.E_UNKNOWN_STATE] + " " + ErrMessage);

                                    }

                                    NewError = new ErrorObject(Error.SeverityLevel, "", NewErrMessage.ToString());

                                }

                            }
                        }
                        catch
                        {
                            NewError = null;
                        }

                        if (NewError != null)
                        {
                            RetVal.Add(NewError);
                        }
                    }
                }
            }

            return RetVal;
        }

        /// <summary>
        /// Returns AppSettings
        /// </summary>
        /// <param name="AppSettingsKey"></param>
        /// <returns></returns>
        public static String AppSettings(String AppSettingsKey)
        {
			/// Uncomment the line below for .NET Core to be able to read the app.config file.
			var mPFProAPPSettingsReader = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings;
            AppSettingsReader mPFProAppSettingsReader;
            mPFProAppSettingsReader = new AppSettingsReader();
            return (String)mPFProAppSettingsReader.GetValue(AppSettingsKey, typeof(String));
        }

        #endregion
    }
}