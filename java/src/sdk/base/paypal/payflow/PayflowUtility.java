package paypal.payflow;

/**
 * This program is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

import java.io.ByteArrayOutputStream;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.rmi.server.UID;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Date;
import java.util.Random;
import java.text.BreakIterator;

import org.apache.xerces.dom.AttrImpl;
import org.apache.xerces.dom.ChildNode;
import org.w3c.dom.*;

// This class is deprecated in Xerces 2.9.0 
//import org.apache.xml.serialize.XMLSerializer;

// Used for DOM Level 3 LSSerializer in maskXMLPayRequest function.
// See comments in that function.
import org.w3c.dom.ls.*;
import org.w3c.dom.bootstrap.DOMImplementationRegistry;

/**
 * This class contains all the utility function's which may be required during a transaction.
 */
public final class PayflowUtility {

    /**
     * This is used to check whether constant for
     * TRACE is initialized already or not.
     */
    private static boolean mTraceInitialized = false;

    /**
     * Generates Request Id. This can be used to generate a random request id.
     *
     * @return strRet
     */
    public static String getRequestId() {
        // get the current time.
        long aTime = new Date().getTime();
        // add a random number to it.
        long rand = new Random().nextLong();

        String myRandString = Long.toString(aTime + Math.abs(rand));
        //Logger.getInstance().log("paypal.payflow.PayflowUtility.getRequestId(String) : myRandString = " + myRandString, PayflowConstants.SEVERITY_DEBUG);
        // get an Internet Address if it is available.
        String myIPString;
        // String mySocketString;
        String toBeHashed;
        // get a new MD5 message digest (outputs a 128 bit hash based on an input).
        //String outputString;

        String strRet;
        // get a Java Unique ID.
        UID uid = new UID();
        //Logger.getInstance().log("paypal.payflow.PayflowUtility.getRequestId(String) : UID = " + uid.toString(), PayflowConstants.SEVERITY_DEBUG);

        try {
            myIPString = InetAddress.getLocalHost().getHostAddress();
        } catch (UnknownHostException e) {
            // myIPString = PayflowConstants.EMPTY_STRING;   Original entry
            myIPString = ""; // Above entry seemed to cause some systems to hang, re (03/16/07)
        }
        //Logger.getInstance().log("paypal.payflow.PayflowUtility.getRequestId(String) : myIPString = " + myIPString, PayflowConstants.SEVERITY_DEBUG);
        //try {
        //    Socket httpSocket = new Socket(InetAddress.getLocalHost(), 80);
        //mySocketString = httpSocket.toString();
        //} catch (UnknownHostException uhe) {
        //    mySocketString = PayflowConstants.EMPTY_STRING;
        //} catch (IOException e) {
        //    mySocketString = PayflowConstants.EMPTY_STRING;
        //}

        //  convert it all to a string.
        // toBeHashed = myRandString + myIPString + mySocketString + uid.toString();
        toBeHashed = myRandString + myIPString + uid.toString();
        // Logger.getInstance().log("paypal.payflow.PayflowUtility.getRequestId(String) : toBeHashed = " + toBeHashed, PayflowConstants.SEVERITY_DEBUG);

        try {
            MessageDigest md = MessageDigest.getInstance("MD5");
            // Modified to work with IBM JDK, 07/03/07 tsieber
            // update the message digest
            md.update(toBeHashed.getBytes());
            // format the input array.
            byte[] in = toBeHashed.getBytes();

            // use the digest to hash the input array to the output array.
            byte[] out = md.digest(in);

            // create the outputString.
            // outputString = new String(out);
            strRet = getStringValue(out, out.length);
        } catch (NoSuchAlgorithmException e) {
            // can't use the MD5, will resort to truncating the toBeHashed String.
            // outputString = toBeHashed.substring(0, 16);
            strRet = toBeHashed.substring(0, 16);
        }
        // strRet = getStringValue(outputString.getBytes(), outputString.getBytes().length);
        // Logger.getInstance().log("paypal.payflow.PayflowUtility.getRequestId(String) : strRet = " + strRet, PayflowConstants.SEVERITY_DEBUG);
        return strRet;
    }

    /**
     * get the string value.
     *
     * @param byteArray byte
     * @param length    int
     * @return strRet String
     */
    protected static String getStringValue(byte[] byteArray, int length) {
        // Modified to work with IBM JDK, 07/03/07 tsieber
        String hexString = "0123456789ABCDEF";
        String strRet = "";
        for (int i = 0; i < length; i++) {
            strRet = strRet + hexString.charAt(byteArray[i] & 0xF);
            strRet = strRet + hexString.charAt((byteArray[i] >> 4) & 0xF);
        }
        return strRet;
    }

    /**
     * Gets, sets mTraceInitialized
     *
     * @return mTraceInitialized
     */
    protected static boolean getTraceInitialized() {
        return mTraceInitialized;
    }

    /**
     * @param value boolean
     */
    protected static void setTraceInitialized(boolean value) {
        mTraceInitialized = value;
    }

    /**
     * Constructor for PayflowUtility
     */
    private PayflowUtility() {
    }

    /**
     * Appends a name value pair to request
     *
     * @param name  String
     * @param value Object
     * @return RetVal String
     */
    protected static String appendToRequest(String name, Object value) {
        String retVal;
        StringBuffer nvPair = new StringBuffer();

        if (null == name || null == value) {
            retVal = PayflowConstants.EMPTY_STRING;
        } else {
            String StringValue = value.toString();
            nvPair.append(name);
            nvPair.append(PayflowConstants.OPENING_BRACE_NVP);
            // nvPair.append(StringValue.length());
            nvPair.append(StringValueLength(StringValue));
            nvPair.append(PayflowConstants.CLOSING_BRACE_NVP);
            nvPair.append(PayflowConstants.SEPARATOR_NVP);
            nvPair.append(StringValue);
            nvPair.append(PayflowConstants.DELIMITER_NVP);

            retVal = nvPair.toString();
        }
        return retVal;

    }

    public static String StringValueLength(String StringValue) {
        BreakIterator it = BreakIterator.getCharacterInstance();
        it.setText(StringValue);
        int count = 0;
        while (it.next() != BreakIterator.DONE) {
            count++;
        }
        // System.out.println("Grapheme length: " + count+ " " + StringValue);
        return String.valueOf(count);
    }

    /**
     * Locates value from name value pair and masks or returns it.
     *
     * @param paramList      String
     * @param name           String
     * @param maskFoundValue boolean
     * @return value String
     */
    public static String locateValueForName(String paramList, String name, boolean maskFoundValue) {
        String value;
        int nameIndex;
        int prevNameIndex;
        if (maskFoundValue) {
            value = paramList;
        } else {
            value = PayflowConstants.EMPTY_STRING;
        }
        if (null != paramList && paramList.length() > 0) {
            nameIndex = paramList.indexOf(name + PayflowConstants.SEPARATOR_NVP);
            if (nameIndex < 0) {
                nameIndex = paramList.indexOf(name + PayflowConstants.OPENING_BRACE_NVP);
            }
            prevNameIndex = nameIndex;
            if (nameIndex > 0) {
                if (paramList.charAt(nameIndex - 1) != '&') {
                    nameIndex = paramList.indexOf(name + PayflowConstants.SEPARATOR_NVP, prevNameIndex);
                    if (nameIndex < 0) {
                        nameIndex = paramList.indexOf(name + PayflowConstants.OPENING_BRACE_NVP, prevNameIndex + 1);
                    }
                }
            }
            if (!(nameIndex < 0 || prevNameIndex < 0)) {
                int nvSeparatorIndex = paramList.indexOf("=", nameIndex);
                if (nvSeparatorIndex > 0) {
                    int nvDelimiterIndex = paramList.indexOf("&", nvSeparatorIndex);
                    boolean iterate = true;
                    while (iterate) {
                        iterate = false;
                        if (!(nvDelimiterIndex < 0)) {
                            if (nvDelimiterIndex + 1 < paramList.length() && paramList.charAt(nvDelimiterIndex + 1) == '&') {
                                nvDelimiterIndex += 2;
                                nvDelimiterIndex = paramList.indexOf("&", nvDelimiterIndex);
                                iterate = true;
                            }
                        } else {
                            nvDelimiterIndex = paramList.length();
                        }
                    }
                    if (maskFoundValue) {
                        int maskIndex;
                        int dontMaskIndex;
                        char[] valueArr = value.toCharArray();
                        for (maskIndex = nvSeparatorIndex + 1; maskIndex < nvDelimiterIndex; maskIndex++) {
                            dontMaskIndex = maskIndex - nvSeparatorIndex;
                            if (name.equals(PayflowConstants.PARAM_ACCT) && (dontMaskIndex < 7 || dontMaskIndex > 12)) {
                                continue;
                            }
                            valueArr[maskIndex] = 'X';
                        }
                        value = new String(valueArr);
                    } else {
                        value = paramList.substring(nvSeparatorIndex + 1, nvDelimiterIndex);
                    }
                }
            }
        }
        return value;
    }


    /**
     * Check if timeout has occurred
     *
     * @param timeoutMsec   long
     * @param startTimeMsec long
     * @return true if timed out false if not.
     */
    protected static boolean isTimedOut(long timeoutMsec, long startTimeMsec) {
        boolean timedOut = false;
        long currentTimeMsec = new Date().getTime();
        long timeElapsedMsec = currentTimeMsec - startTimeMsec;
        long timeRemainingMsec = timeoutMsec - timeElapsedMsec;
        if (timeRemainingMsec < 0) {
            timedOut = true;
        }
        return timedOut;
    }

    /**
     * Retrieves XmlPay version from Xml Pay Request.
     *
     * @param request String
     * @return version String
     * @throws Exception Exception
     */
    protected static String getXmlVersion(String request) throws Exception {
        String version;
        version = getXmlAttribute(request, PayflowConstants.XML_PARAM_VERSION);
        return version;
    }

    /**
     * Retrieves value of given Xml attribute from Xml Pay Request.
     *
     * @param request   String
     * @param attribute String
     * @return attributeValue String
     * @throws Exception Exception
     */
    protected static String getXmlAttribute(String request, String attribute) throws Exception {
        //added JR

        String retVal = PayflowConstants.EMPTY_STRING;
        try {

            if (request != null && request.length() > 0) {
                String attributeValue = null;
                IPXmlReader xmlReader = new IPXmlReader(request);
                Document xmlPayRequest = xmlReader.getXmlDocumentElement();
                Element xmlNode;
                NodeList xmlPayChildNodes = xmlPayRequest.getChildNodes();
                NamedNodeMap xmlPayReqAttributes;
                AttrImpl attributeNode;
                int noOfChildren = xmlPayChildNodes.getLength();
                try {

                    for (int childIndex = 0; childIndex < noOfChildren; childIndex++) {
                        xmlNode = (Element) xmlPayChildNodes.item(childIndex);
                        if (xmlNode.getLocalName().equals(PayflowConstants.XMLPAY_REQUEST_TAG)) {
                            xmlPayReqAttributes = xmlNode.getAttributes();
                            if (xmlPayReqAttributes != null) {
                                attributeNode = (AttrImpl) xmlPayReqAttributes.getNamedItem(attribute);
                                if (attributeNode != null) {
                                    attributeValue = attributeNode.getTextContent();
                                }
                            }
                        }
                    }

                } catch (DOMException e) {
                    e.printStackTrace();
                }
                retVal = attributeValue;

            }

        } catch (DOMException e) {
            e.printStackTrace();
        }
        return retVal;
    }

    /**
     * Gets the Xml Namespace from the XmlPay Request.
     *
     * @param request String
     * @return xmlNameSapce String
     * @throws Exception Exception
     */
    protected static String getXmlNameSpace(String request) throws Exception {

        String xmlNameSpace = PayflowConstants.EMPTY_STRING;
        String xmlPayVersion;
        xmlPayVersion = getXmlVersion(request);
        if (!("1.0".equals(xmlPayVersion))) {
            xmlNameSpace = PayflowConstants.XMLPAY_NAMESPACE;

        }
        return xmlNameSpace;

    }

    /**
     * Gets the inner text from an xml node.
     *
     * @param xmlPayRequest Document
     * @param nodeName      String
     * @return retVal String
     */
    protected static String getXmlNodeValue(Document xmlPayRequest, String nodeName) {
        String retVal = PayflowConstants.EMPTY_STRING;
        if (xmlPayRequest != null && nodeName != null && nodeName.length() > 0) {
            NodeList nodeList = xmlPayRequest.getElementsByTagName(nodeName);
            if (nodeList != null && nodeList.getLength() == 1) {
                ChildNode nodeElement = (ChildNode) nodeList.item(0);
                if (nodeElement != null) {
                    retVal = nodeElement.getTextContent();
                }
            }
        }
        return retVal;
    }

    /**
     * Retrieves request id from param list.
     *
     * @param isXmlPayReq  boolean
     * @param transRequest String
     * @return requestId String
     * @throws Exception Exception
     */
    protected static String requestIdFromParamList(boolean isXmlPayReq, String transRequest) throws Exception {
        String requestId;
        if (isXmlPayReq) {
            requestId = PayflowUtility.getXmlAttribute(transRequest, PayflowConstants.XML_PARAM_REQUEST_ID);
        } else {
            requestId = PayflowUtility.locateValueForName(transRequest, PayflowConstants.PARAM_REQUEST_ID, false);
        }
        return requestId;

    }

    /**
     * Populates Errors from Exceptions.
     *
     * @param commMessageCode String
     * @param ex              Exception
     * @param severityLevel   int
     * @param isXmlPayReq     boolean
     * @param addMessage      String
     * @return initError ErrorObject
     */
    protected static ErrorObject populateCommError(String commMessageCode,
                                                   Exception ex, int severityLevel, boolean isXmlPayReq, String addMessage) {
        Logger.getInstance().log("paypal.payflow.PayflowUtility.populateCommError(String,Exception,int,boolean,String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        String message;
        String messageCode;
        String trace = PayflowConstants.EMPTY_STRING;

        //initStackTraceOn();

        String[] msgParams;

        if (addMessage == null) {
            addMessage = PayflowConstants.EMPTY_STRING;
        } else if (addMessage.length() > 0) {
            addMessage = " " + addMessage;
        }

        if (ex != null && SDKProperties.isStackTraceOn()) {
            trace = " ";
            StackTraceElement[] stackTrace = ex.getStackTrace();
            int size = stackTrace.length;
            for (int i = 0; i < size; i++) {
                trace += "\n" + stackTrace[i].toString();
            }
        }

        message = PayflowConstants.CommErrorMessages.get(commMessageCode)
                + addMessage + trace;

        if (isXmlPayReq) {
            messageCode = PayflowConstants.MSG_COMMUNICATION_ERROR_XMLPAY;
            msgParams = new String[]
                    {(String) PayflowConstants.CommErrorCodes.get(commMessageCode), message};

        } else {
            messageCode = PayflowConstants.MSG_COMMUNICATION_ERROR;
            msgParams = new String[]
                    {(String) PayflowConstants.CommErrorCodes.get(commMessageCode), message};

        }

        ErrorObject InitError = new ErrorObject(severityLevel, messageCode, msgParams);
        Logger.getInstance().log("paypal.payflow.PayflowUtility.populateCommError(String,Exception,int,boolean,String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return InitError;
    }

    /**
     * Masks the sensitive fields in the param list which will be used for logging purpose.
     *
     * @param parmList String
     * @return retVal String
     */
    protected static String maskSensitiveFields(String parmList) {
        Logger.getInstance().log("paypal.payflow.PayflowUtility.maskSensitiveFields(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        String retVal;
        try {
            if (parmList != null && parmList.length() > 0) {
                if (parmList.indexOf(PayflowConstants.XML_ID) >= 0) {
                    retVal = maskXMLPayRequest(parmList);
                } else {
                    retVal = maskNVPRequest(parmList);
                }
            } else {
                retVal = parmList;
            }
        } catch (Exception ex) {
            Logger.getInstance().log("paypal.payflow.PayflowUtility.maskSensitiveFields(String) : XMLPay Request: " + parmList, PayflowConstants.SEVERITY_DEBUG);
            retVal = " The xml pay request is invalid : " + ex.getMessage();
        }
        Logger.getInstance().log("paypal.payflow.PayflowUtility.maskSensitiveFields(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;

    }

    /**
     * Masks XMLPay Request
     *
     * @param parmList String
     * @return maskedRequest String
     * @throws Exception Exception
     */
    protected static String maskXMLPayRequest(final String parmList) throws Exception {
        String retVal;

        IPXmlReader xmlReader = new IPXmlReader(parmList);
        Document xmlPayRequest = xmlReader.getXmlDocumentElement();
        //Mask ACCT if present : Corresponding XmlPay element --> AcctNum or CardNum
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_ACCTNUM);
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_CARDNUM);
        //Mask EXPDATE if present : Corresponding XmlPay element --> ExpDate
        //PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_EXPDATE);
        //Mask SWIPE if present : Corresponding XmlPay element --> MagData
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_MAGDATA);
        //Mask MICR if present : Corresponding XmlPay element --> MICR or MagData
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_MICR);
        //Mask CVV2 if present : Corresponding XmlPay element --> CVNum
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_CVNUM);
        //Mask PWD if present : Corresponding XmlPay element --> Password
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_PASSWORD);
        //Mask DL if present : Corresponding XmlPay element --> DL
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_DL);
        //Mask SS if present : Corresponding XmlPay element --> CVNum
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_SS);
        //Mask DOB if present : Corresponding XmlPay element --> DOB
        PayflowUtility.maskXmlNodeValue(xmlPayRequest, PayflowConstants.XML_PARAM_DOB);

        // This class was deprecated in Xerces 2.9.0.  Replaced with DOM Level 3 LSSerializer.
        // 08/21/07 tsieber
        //XMLSerializer ss = new XMLSerializer();
        //ByteArrayOutputStream xmlOutputStream = new ByteArrayOutputStream();
        //ss.setOutputByteStream(xmlOutputStream);
        //ss.serialize(xmlPayRequest);
        //retVal = xmlOutputStream.toString();

        System.setProperty(DOMImplementationRegistry.PROPERTY, "org.apache.xerces.dom.DOMImplementationSourceImpl");
        DOMImplementationRegistry registry = DOMImplementationRegistry.newInstance();
        DOMImplementation domImpl = registry.getDOMImplementation("LS 3.0");
        DOMImplementationLS implLS = (DOMImplementationLS) domImpl;
        LSSerializer dom3Writer = implLS.createLSSerializer();
        retVal = dom3Writer.writeToString(xmlPayRequest);
        return retVal;
    }

    /**
     * Masks NVP Request
     *
     * @param parmList String
     * @return maskedRequest String
     */
    protected static String maskNVPRequest(final String parmList) {
        String logParmList = parmList;
        //Mask ACCT if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_ACCT, true);
        //Mask EXPDATE if present
        //CR EXPDATE is unmasked
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_EXPDATE, true);
        //Mask SWIPE if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_SWIPE, true);
        //Mask MICR if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_MICR, true);
        //Mask CVV2 if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_CVV2, true);
        //Mask PWD
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_PWD, true);
        //Mask DL if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_DL, true);
        //Mask SS if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_SS, true);
        //Mask DOB if present
        logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_DOB, true);
        //Mask VIT_OSNAME if present
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_VIT_OSNAME, true);
        //Mask VIT_OSARCH if present
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_VIT_OSARCH, true);
        //Mask VIT_OSVERSION if present
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_VIT_OSVERSION, true);
        //Mask VIT_SDKRUNTIMEVERSION if present
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_VIT_SDKRUNTIMEVERSION, true);
        //Mask VIT_PROXY if present
        //logParmList = PayflowUtility.locateValueForName(logParmList, PayflowConstants.PARAM_VIT_PROXY, true);
        return logParmList;
    }

    /**
     * masks an xmlNodeValue
     *
     * @param xmlPayRequest Document
     * @param nodeName      String
     */
    protected static void maskXmlNodeValue(Document xmlPayRequest, String nodeName) {
        String retVal;
        String maskValue = PayflowConstants.EMPTY_STRING;

        if (xmlPayRequest != null && nodeName != null && nodeName.length() > 0) {
            NodeList nodeList = xmlPayRequest.getElementsByTagName(nodeName);

            if (nodeList != null && nodeList.getLength() == 1) {
                ChildNode nodeElement = (ChildNode) nodeList.item(0);

                if (nodeElement != null) {
                    retVal = nodeElement.getTextContent();

                    if (null != retVal) {
                        for (int i = 0; i < retVal.length(); i++) {
                            if (((nodeName.equals(PayflowConstants.XML_PARAM_ACCTNUM)) || (nodeName.equals(PayflowConstants.XML_PARAM_CARDNUM)) && (i < 6 || i > 11))) {
                                maskValue = maskValue + retVal.charAt(i);
                            } else {
                                maskValue = maskValue + "X";
                            }
                        }
                    }
                    nodeElement.setTextContent(maskValue);
                }
            }
        }
    }

    /**
     * Gets the inner text of a node from an XMLPay request
     *
     * @param xmlPayRequest String
     * @param nodeName      String
     * @return retVal String
     */
    protected static String getXmlPayNodeValue(String xmlPayRequest, String nodeName) {
        Logger.getInstance().log("paypal.payflow.PayflowUtility.getXmlPayNodeValue(String,String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        String retVal = null;
        try {
            IPXmlReader xmlReader = new IPXmlReader(xmlPayRequest);
            Document XmlPayDoc = xmlReader.getXmlDocumentElement();
            retVal = getXmlNodeValue(XmlPayDoc, nodeName);
        } catch (Exception ex) {
            Logger.getInstance().log(ex.toString(), PayflowConstants.SEVERITY_WARN);
        }
        Logger.getInstance().log("paypal.payflow.PayflowUtility.getXmlPayNodeValue(String,String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;

    }

    /**
     * Provides the status of the transaction based on the transaction response.
     *
     * @param transactionResponse String
     * @return status String
     */
    public static String getStatus(String transactionResponse) {
        Logger.getInstance().log("paypal.payflow.PayflowUtility.getStatus(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        String status;
        boolean isTrxRespXmlPay = false;
        boolean nullTrxResp = false;
        int index;
        if (transactionResponse != null) {
            index = transactionResponse.indexOf(PayflowConstants.XML_RESP_ID);
            isTrxRespXmlPay = index >= 0;
        } else {
            nullTrxResp = true;
        }

        String trxResult = PayflowConstants.EMPTY_STRING;

        if (!nullTrxResp) {
            if (isTrxRespXmlPay) {
                try {
                    trxResult = getXmlPayNodeValue(transactionResponse, PayflowConstants.XML_PARAM_RESULT);
                } catch (Exception ex) {
                    Logger.getInstance().log(ex.toString(), PayflowConstants.SEVERITY_DEBUG);
                }
            } else {
                trxResult = locateValueForName(transactionResponse, PayflowConstants.PARAM_RESULT, false);
            }
        }


        if ((!nullTrxResp) && ("0".equals(trxResult))) {
            status = "Transaction Successful.";
        } else {
            status = "Transaction Failed.";
        }
        Logger.getInstance().log("paypal.payflow.PayflowUtility.getStatus(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return status;
    }

    /**
     * @param context         Context
     * @param isXmlPayRequest boolean
     * @return errors Arraylist
     */
    protected static ArrayList alignContext(Context context, boolean isXmlPayRequest) {
        Logger.getInstance().log("paypal.payflow.PayflowUtility.alignContext(Context, boolean) : Entered", PayflowConstants.SEVERITY_DEBUG);
        ArrayList errors = context.getErrors();
        ArrayList retVal = new ArrayList();
        int errorCount = errors.size();
        int index;
        for (index = 0; index < errorCount; index++) {
            ErrorObject error = (ErrorObject) errors.get(index);
            String messageCode = error.getMessageCode();
            Logger.getInstance().log("paypal.payflow.PayflowUtility.alignContext(Context,boolean) : messageCode = " + messageCode, PayflowConstants.SEVERITY_DEBUG);
            if (error != null) {
                if (messageCode != null && messageCode.length() > 0) {
                    boolean msg1012 = false;
                    boolean msg1013 = false;
                    boolean msg1015 = false;
                    boolean msg1016 = false;
                    //Logger.getInstance().log("Step 1." + messageCode, PayflowConstants.SEVERITY_DEBUG);

                    if ("MSG_1012".equals(messageCode)) {
                        msg1012 = true;
                    } else if ("MSG_1013".equals(messageCode)) {
                        msg1013 = true;
                    } else if ("MSG_1015".equals(messageCode)) {
                        msg1015 = true;
                    } else if ("MSG_1016".equals(messageCode)) {
                        msg1016 = true;
                    }
                    //Logger.getInstance().log("Step 2." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                    if (isXmlPayRequest) {
                        //Logger.getInstance().log("Step 3." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                        if (msg1013 || msg1016) {
                            retVal.add(error);
                        } else {
                            ErrorObject newError;
                            //Logger.getInstance().log("Step 4." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                            if (msg1012) {
                                ArrayList msgParams = error.getMessageParams();
                                String[] newMsgParams = new String[]{(String) msgParams.get(0),
                                        (String) msgParams.get(1)};
                                newError = new ErrorObject(error.getSeverityLevel(), "MSG_1013", newMsgParams, error.getErrorStackTrace());
                            } else if (msg1015) {
                                ArrayList msgParams = error.getMessageParams();
                                String[] newMsgParams = new String[]{(String) msgParams.get(0),
                                        (String) msgParams.get(1)};
                                newError = new ErrorObject(error.getSeverityLevel(), "MSG_1016", newMsgParams, error.getErrorStackTrace());
                            } else {
                                //Logger.getInstance().log("Step 5." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                                String errMessage = error.toString();
                                newError = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, null, error.getSeverityLevel(), true, errMessage);
                            }
                            if (newError != null) {
                                retVal.add(newError);
                                //Logger.getInstance().log("Step 6." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                            }
                        }
                    } else {
                        if (msg1012 || msg1015) {
                            retVal.add(error);
                        } else {
                            ErrorObject newError;
                            if (msg1013) {
                                ArrayList msgParams = error.getMessageParams();
                                String[] newMsgParams = new String[]{(String) msgParams.get(0),
                                        (String) msgParams.get(1)};
                                newError = new ErrorObject(error.getSeverityLevel(), "MSG_1012", newMsgParams, error.getErrorStackTrace());
                                //Logger.getInstance().log("Step 9" + messageCode, PayflowConstants.SEVERITY_DEBUG);
                            } else if (msg1016) {
                               //Logger.getInstance().log("Step 7." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                                ArrayList msgParams = error.getMessageParams();
                                String[] newMsgParams = new String[]{(String) msgParams.get(1),
                                        (String) msgParams.get(2)};
                                newError = new ErrorObject(error.getSeverityLevel(), "MSG_1015", newMsgParams, error.getErrorStackTrace());

                            } else {
                                //Logger.getInstance().log("Step 8." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                                String errMessage = error.toString();
                                newError = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, null, error.getSeverityLevel(), false, errMessage);
                            }

                            if (newError != null) {
                                retVal.add(newError);
                                //Logger.getInstance().log("Step 10." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                            }
                        }
                    }
                } else {
                    ErrorObject newError = null;
                    //Logger.getInstance().log("Step 11.", PayflowConstants.SEVERITY_DEBUG);

                    String errMessage = error.toString();
                    if (errMessage != null && errMessage.length() > 0) {
                        String result = PayflowConstants.EMPTY_STRING;
                        String respMsg = PayflowConstants.EMPTY_STRING;
                        //Logger.getInstance().log("Step 12." + errMessage, PayflowConstants.SEVERITY_DEBUG);
                        boolean errIsXmlPay = (errMessage.indexOf(PayflowConstants.XML_RESP_ID) >= 0);
                        //Check whether the error string is in nvp format
                        // or xml pay format.
                        if (errIsXmlPay) {
                            //Try to get values in nodes Result, RespMsg
                            try {
                                //Logger.getInstance().log("Step 13." + errMessage, PayflowConstants.SEVERITY_DEBUG);
                                result = PayflowUtility.getXmlPayNodeValue(errMessage, PayflowConstants.XML_PARAM_RESULT);
                                respMsg = PayflowUtility.getXmlPayNodeValue(errMessage, PayflowConstants.XML_PARAM_MESSAGE);
                            } catch (Exception ex) {
                                Logger.getInstance().log(ex.toString(), PayflowConstants.SEVERITY_DEBUG);
                            }
                        } else {
                            //Try to get RESULT , RESPMSG from the error if
                            // available.
                            //Logger.getInstance().log("Step 14." + errMessage, PayflowConstants.SEVERITY_DEBUG);
                            result = PayflowUtility.locateValueForName(errMessage, PayflowConstants.PARAM_RESULT, false);
                            respMsg = PayflowUtility.locateValueForName(errMessage, PayflowConstants.PARAM_RESPMSG, false);
                        }

                        if (result != null && result.length() > 0 && respMsg != null && respMsg.length() > 0) {
                            //Logger.getInstance().log("Step 15." + result, PayflowConstants.SEVERITY_DEBUG);
                            StringBuffer newErrMessage;
                            if (isXmlPayRequest && !errIsXmlPay) {
                                newErrMessage = new StringBuffer("<XMLPayResponse xmlns='http://www.PayPal.com/XMLPay'");
                                newErrMessage.append("><ResponseData><TransactionResults><TransactionResult><Result>");
                                newErrMessage.append(result);
                                newErrMessage.append("</Result><Message>");
                                newErrMessage.append(respMsg);
                                newErrMessage.append("</Message></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");
                                newError = new ErrorObject(error.getSeverityLevel(), PayflowConstants.EMPTY_STRING, newErrMessage.toString());

                            } else if (!isXmlPayRequest && errIsXmlPay) {
                                newErrMessage = new StringBuffer(PayflowConstants.PARAM_RESULT);
                                newErrMessage.append(PayflowConstants.SEPARATOR_NVP);
                                newErrMessage.append(result);
                                newErrMessage.append(PayflowConstants.DELIMITER_NVP);
                                newErrMessage.append(PayflowConstants.PARAM_RESPMSG);
                                newErrMessage.append(PayflowConstants.SEPARATOR_NVP);
                                newErrMessage.append(respMsg);

                                newError = new ErrorObject(error.getSeverityLevel(), PayflowConstants.EMPTY_STRING, newErrMessage.toString());
                            } else {
                                //Logger.getInstance().log("Step 18." + messageCode, PayflowConstants.SEVERITY_DEBUG);
                                newError = new ErrorObject(error.getSeverityLevel(), PayflowConstants.EMPTY_STRING, errMessage);
                            }
                        } else {
                            StringBuffer NewErrMessage;
                            if (isXmlPayRequest) {
                                //Logger.getInstance().log("Step 19.", PayflowConstants.SEVERITY_DEBUG);
                                NewErrMessage = new StringBuffer("<XMLPayResponse xmlns='http://www.paypal.com/XMLPay'");

                                NewErrMessage.append("><ResponseData><TransactionResults><TransactionResult><Result>");
                                NewErrMessage.append((String) PayflowConstants.CommErrorCodes.get(PayflowConstants.E_UNKNOWN_STATE));
                                NewErrMessage.append("</Result><Message>");
                                NewErrMessage.append(PayflowConstants.CommErrorMessages.get(PayflowConstants.E_UNKNOWN_STATE));
                                NewErrMessage.append(" ");
                                NewErrMessage.append(errMessage);
                                NewErrMessage.append("</Message></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");
                            } else {
                                NewErrMessage = new StringBuffer(PayflowConstants.PARAM_RESULT);
                                NewErrMessage.append(PayflowConstants.SEPARATOR_NVP);
                                NewErrMessage.append(PayflowConstants.CommErrorCodes.get(PayflowConstants.E_UNKNOWN_STATE));
                                NewErrMessage.append(PayflowConstants.DELIMITER_NVP);
                                NewErrMessage.append(PayflowConstants.PARAM_RESPMSG);
                                NewErrMessage.append(PayflowConstants.SEPARATOR_NVP);
                                NewErrMessage.append(PayflowConstants.CommErrorMessages.get(PayflowConstants.E_UNKNOWN_STATE));
                                NewErrMessage.append(" ");
                                NewErrMessage.append(errMessage);
                            }
                            //Logger.getInstance().log("Step 21." + errMessage, PayflowConstants.SEVERITY_DEBUG);
                            newError = new ErrorObject(error.getSeverityLevel(), PayflowConstants.EMPTY_STRING, NewErrMessage.toString());
                        }
                    }
                    if (newError != null) {
                        //Logger.getInstance().log("Step 22." + errMessage, PayflowConstants.SEVERITY_DEBUG);
                        retVal.add(newError);
                    }
                }
            }
        }
        Logger.getInstance().log("paypal.payflow.PayflowUtility.alignContext(Context, boolean) : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return retVal;
    }

    /**
     * This function will be used to form the string with the context details.
     *
     * @param msgBody   String
     * @param msgParams String[]
     * @return msgBody String
     */
    protected static String format(String msgBody, String[] msgParams) {

        if (msgBody != null && msgBody.length() != 0) {
            //split the string by {} and replace the parameter recursively
            for (int i = 0; i <= msgParams.length - 1; i++) {
                msgBody = new StringBuffer(msgBody).replace
                        (msgBody.indexOf('{'),
                                msgBody.indexOf('}') + 1,
                                msgParams[i]).toString();
            }
        }
        return msgBody;
    }

    /**
     * Provides the status (as a String) of the transaction based on the transaction response.
     *
     * @param resp - Response obtained from PayPal Payment Gateway.
     * @return - String result for the transaction: If Transaction Result = 0 then 'Transaction Successful.'
     *         else 'Transaction Failed.'
     */
    public static String getStatus(Response resp) {
        String status;
        TransactionResponse trxnResponse = resp.getTransactionResponse();
        if (trxnResponse != null && 0 == (trxnResponse.getResult())) {
            status = "Transaction Successful.";
        } else {
            status = "Transaction Failed.";
        }

        return status;
    }

    /**
     * Returns a boolean value indicating the status of the transaction
     *
     * @param resp - Response obtained from PayPal Payment Gateway.
     * @return - true if transaction was success
     */
    public static boolean getTransactionStatus(Response resp) {
        boolean status = false;
        TransactionResponse trxnResponse = resp.getTransactionResponse();
        if (trxnResponse != null) {
            status = (0 == trxnResponse.getResult());
        }
        return status;
    }

}
