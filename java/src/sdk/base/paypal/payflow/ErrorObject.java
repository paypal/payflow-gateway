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
 * This class contains the error message along with the message code, severity level
 * of the error and the stack trace. This class represents the format of an error message.
 */
public final class ErrorObject {

    /**
     * Holds the message code for the Error.
     */
    private String mMsgCode;

    /**
     * Holds the context parameters for the place holders.These parameters will be used
     * in conjunction with the message body to get the formatted message for the error.
     */
    private ArrayList mMsgCodeParams;

    /**
     * Holds the Severity Level for the error. Sets this to debug by default.
     */
    private int mSeverity;

    /**
     * Holds the stack trace, if applicable. This is helpful in case the error is an
     * Exception.
     */
    private String mStackTrace;

    /**
     * Holds the message body for the Error.
     */
    private String mMsgBody;

    /**
     * Return the message body for the error.
     *
     * @return messageBody String
     */
    protected String getMessageBody() {
        return mMsgBody;
    }

    /**
     * Return the message Code for the error.
     *
     * @return messgeCode String
     */
    public String getMessageCode() {
        return mMsgCode;
    }

    /**
     * Return the stack trace for the error.
     *
     * @return stackTrace String
     */
    public String getErrorStackTrace() {
        return mStackTrace;
    }

    /**
     * Return the severity level for the error.
     *
     * @return severityLevel int
     */
    public int getSeverityLevel() {
        return mSeverity;
    }


    /**
     * Return the message params for the error.
     *
     * @return messageParams ArrayList
     */
    public ArrayList getMessageParams() {
        return mMsgCodeParams;
    }

    /**
     * This function formats the error message by filling the place holders with the
     * context parameters
     *
     * @return formattedMessage String
     */
    public String toString() {
        String formattedMessage;
        if (mMsgCodeParams != null) {
            String[] msgParams = new String[mMsgCodeParams.size()];
            for (int i = 0; i <= mMsgCodeParams.size() - 1; i++) {
                msgParams[i] = (String) mMsgCodeParams.get(i);
            }

            try {
                formattedMessage = PayflowUtility.format(mMsgBody, msgParams);
            } catch (Exception Ex) {
                String StackTrace = PayflowConstants.EMPTY_STRING;
                //PayflowUtility.initStackTraceOn();

                if (SDKProperties.isStackTraceOn()) {
                    StackTrace = " " + Ex.toString();
                }

                formattedMessage = PayflowConstants.MESSAGE_FORMATTING_ERROR + StackTrace;
            }
        } else {
            formattedMessage = mMsgBody;
        }
        return formattedMessage;
    }

    /**
     * Used for Validation Errors which don't have a stack trace.
     *
     * @param severity      int
     * @param msgCode       String
     * @param msgCodeParams String[]
     */
    protected ErrorObject(int severity, String msgCode, String[] msgCodeParams) {
        this.mSeverity = severity;
        this.mMsgCode = msgCode;
        this.mMsgCodeParams = new ArrayList();
        //need to check this code
        for (int i = 0; i <= msgCodeParams.length - 1; i++) {
            this.mMsgCodeParams.add(msgCodeParams[i]);
        }
    }


    /**
     * Used for populating error message from the Message xml file.
     *
     * @param severity int
     * @param msgCode  String
     * @param msgBody  String
     */
    protected ErrorObject(int severity, String msgCode, String msgBody) {
        this.mSeverity = severity;
        this.mMsgCode = msgCode;
        this.mMsgBody = msgBody;
        this.mStackTrace = PayflowConstants.EMPTY_STRING;
        this.mMsgCodeParams = new ArrayList();
    }

    /**
     * Used for Exception objects, which have a stack trace.
     *
     * @param severity      int
     * @param msgCode       String
     * @param msgCodeParams String
     * @param stackTrace    String
     */
    protected ErrorObject(int severity, String msgCode, String[] msgCodeParams, String stackTrace) {
        this(severity, msgCode, msgCodeParams);
        this.mStackTrace = stackTrace;
    }

    /**
     * Used for copying the error object in the logger class.
     *
     * @param severity      int
     * @param msgCode       String
     * @param msgBody       String
     * @param msgCodeParams String[]
     * @param stackTrace    String
     */
    protected ErrorObject(int severity, String msgCode, String msgBody, String[] msgCodeParams, String stackTrace) {
        this(severity, msgCode, msgCodeParams);
        this.mMsgBody = msgBody;
        this.mStackTrace = stackTrace;
    }

    /**
     * Used for Exception objects without any message code.
     *
     * @param msgBody    String
     * @param stackTrace String
     */
    protected ErrorObject(String msgBody, String stackTrace) {
        this.mSeverity = PayflowConstants.SEVERITY_FATAL;
        this.mMsgBody = msgBody;
        this.mStackTrace = stackTrace;
        this.mMsgCode = PayflowConstants.EMPTY_STRING;
        this.mMsgCodeParams = new ArrayList();
    }

    /**
     * Used for Exception objects without any message code and stack trace.
     *
     * @param msgBody String
     */
    protected ErrorObject(String msgBody) {
        this.mMsgBody = msgBody;
        this.mMsgCode = PayflowConstants.EMPTY_STRING;
        this.mMsgCodeParams = new ArrayList();
        this.mStackTrace = PayflowConstants.EMPTY_STRING;
        this.mSeverity = PayflowConstants.SEVERITY_FATAL;
    }

    /**
     * returns true if the passed object is of type ErrorObject and all members are
     * equal to this members.
     *
     * @param obj Object
     * @return isEqual boolean
     */
    public boolean equals(Object obj) {
        boolean isEqual = false;
        ErrorObject err;
        if (obj instanceof ErrorObject) {
            err = (ErrorObject) obj;
            isEqual = (null != this.mMsgCode && this.mMsgCode.equals(err.mMsgCode))
                    && (null != this.mMsgBody && this.mMsgBody.equals(err.mMsgBody))
                    && (null != this.mMsgCodeParams && this.mMsgCodeParams.equals(err.mMsgCodeParams))
                    && this.mSeverity == err.mSeverity;
        }
        return isEqual;
    }


}