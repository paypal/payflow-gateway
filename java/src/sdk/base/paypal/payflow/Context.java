package paypal.payflow;



import java.util.ArrayList;
import java.util.Iterator;

/**
 * This class contains all error messages generated for the class containing
 * the context.This also contains the highest severity level contained by the
 * context.
 */
public final class Context {

    /**
     * Holds the collection of error objects for the context instance.
     */
    private ArrayList mErrorObjects = new ArrayList();

    /**
     * Indicates the highest severity level error in the array list.
     */
    private int mHighestErrorLvl;

    /**
     * Indicates if the Error messages due to Logger class needs to be added to the context.
     */
    private boolean mLoadLoggerErrs;

    /**
     * Constructor for Context
     */
    protected Context() {
    }


    /**
     * Indicates the highest severity level error contained in the Context.
     *
     * @return highestErrorLvl int
     */
    public int getHighestErrorLvl() {
        int errCnt;
        int errMaxCnt;
        int errSeverityLevel;

        errMaxCnt = mErrorObjects.size();
        for (errCnt = 0; errCnt < errMaxCnt; errCnt++) {
            errSeverityLevel = ((ErrorObject) mErrorObjects.get(errCnt)).getSeverityLevel();
            if (mHighestErrorLvl < errSeverityLevel) {
                mHighestErrorLvl = errSeverityLevel;
            }
        }
        return mHighestErrorLvl;
    }

    /**
     * Indicates if the Error messages due to Logger class needs to be added to the context.
     *
     * @return mLoadLoggerErrs boolean
     */
    protected boolean getLoadLoggerErrs() {
        return mLoadLoggerErrs;
    }

    /**
     * This function can be set to check if logger errors need to be logged.
     *
     * @param value boolean
     */
    protected void setLoadLoggerErrs(boolean value) {

        mLoadLoggerErrs = value;

    }

    /**
     * This method adds the passed error object in the array list contained by
     * the context object
     *
     * @param errObject ErrorObject
     */
    protected void addError(ErrorObject errObject) {

        if (mErrorObjects == null) {
            mErrorObjects = new ArrayList();
        }
        if (!mErrorObjects.contains(errObject)) {
            mErrorObjects.add(0, errObject);
        }

    }

    /**
     * This method adds the passed arraylist of error objects
     * to the context object
     *
     * @param errorObjects ArrayList
     */
    protected void addErrors(ArrayList errorObjects) {

        if (mErrorObjects == null) {
            mErrorObjects = new ArrayList();
        }
        Iterator iter = errorObjects.iterator();
        ErrorObject err;
        while (iter.hasNext()) {
            err = (ErrorObject) iter.next();
            if (!mErrorObjects.contains(err)) {
                mErrorObjects.add(err);
            }
        }
    }

    /**
     * This method will log all the error and exceptions contained in the ErrorObjects
     * arraylist.This returns true if the logging is successful.
     *
     * @return retVal boolean
     */
    public boolean logErrors() {

        boolean retVal;
        try {
            int errCnt = 0;
            Logger instance;
            ArrayList populatedErr;
            if (mErrorObjects != null) {
                instance = Logger.getInstance();
                populatedErr = instance.populateErrorDetails(mErrorObjects);
                mErrorObjects.clear();
                mErrorObjects.addAll(errCnt, populatedErr);
                instance.log(mErrorObjects);
            }
            retVal = true;
        } catch (Exception ex) {
            retVal = false;
        }
        return retVal;
    }

    /**
     * This method will check if the context contains any error message.This method
     * can be used for checking if the context is empty.
     *
     * @return errorContained boolean
     */
    public boolean isErrorContained() {

        boolean retVal = false;
        if (mErrorObjects != null) {
            if (mErrorObjects.size() > 0)
                retVal = true;
        }

        return retVal;
    }

    /**
     * This method will check if the context contains a specific error message.This method
     * can be used for checking if the context is empty.
     *
     * @param error ErrorObject
     * @return retFlag boolean
     */
    protected boolean isCommunicationErrorContained(ErrorObject error) {

        boolean retFlag = false;
        if (isErrorContained()) {
            ErrorObject err;

            for (int i = 0; i <= mErrorObjects.size() - 1; i++) {
                err = (ErrorObject) mErrorObjects.get(i);
                if (err != null && err.getMessageCode().equals(error.getMessageCode())) {
                    if (err.getMessageParams() != null && error.getMessageParams() != null) {
                        if (err.getMessageParams().get(0).equals(error.getMessageParams().get(0))) {
                            retFlag = true;
                        }
                    }
                    //return false;
                }
            }
        }
        return retFlag;
    }

    /**
     * This method will return the error object from the Context as per the index
     * passed to the function.If the index value passed is more than the count of the
     * errors in the array list then it returns a null.
     *
     * @param index int
     * @return errobject ErrorObject
     */
    public ErrorObject getError(int index) {

        ErrorObject errObject = null;
        populateErrors();
        if (index < mErrorObjects.size()) {
            errObject = (ErrorObject) mErrorObjects.get(index);
        }

        return errObject;
    }

    /**
     * This method returns the array list populated with all the error contained
     * in the context
     *
     * @return mErrorObjects ArrayList
     */
    public ArrayList getErrors() {

        populateErrors();
        return mErrorObjects;
    }


    /**
     * This method will return the array list populated with all the error contained
     * in the context which are equal to or above the severity level passed to the
     * function
     *
     * @param sevLvl int
     * @return highSevErrors ArrayList
     */
    public ArrayList getErrors(int sevLvl) {
        ArrayList highSevErrors = new ArrayList();
        int errMaxCount;
        int errCnt;
        populateErrors();
        errMaxCount = mErrorObjects.size();
        for (errCnt = 0; errCnt < errMaxCount; errCnt++) {
            if (((ErrorObject) mErrorObjects.get(errCnt)).getSeverityLevel() >=
                    sevLvl) {
                highSevErrors.add(mErrorObjects.get(errCnt));
            }
        }
        return highSevErrors;
    }

    /**
     * This method will return the total number of errors contained in the
     * Context Object.
     *
     * @return errorCOunt int
     */
    public int getErrorCount() {
        int errorCount = 0;
        if (mErrorObjects != null) {
            errorCount = mErrorObjects.size();
        }
        return errorCount;
    }

    /**
     * This method will populate all the error objects contained in the arraylist with
     * details such as the severity level and message body.It uses 'PopulateErrorDetails'
     * method of the Logger class.
     */
    private void populateErrors() {
        int errCnt = 0;
        Logger instance;
        ArrayList populatedErr;
        if (mErrorObjects != null) {
            instance = Logger.getInstance();
            populatedErr = instance.populateErrorDetails(mErrorObjects);
            if (getLoadLoggerErrs()) {
                //PopulatedErr.AddRange (Instance.GetLoggerErrs);
                //Check for duplicate Logger errors
                ArrayList tempList = instance.getLoggerErrs();
                if (tempList != null) {
                    for (int i = 0; i < tempList.size(); i++) {
                        if (!populatedErr.contains(tempList.get(i))) {
                            populatedErr.add(tempList.get(i));
                        }
                    }
                }
            }
            mErrorObjects.clear();
            mErrorObjects.addAll(errCnt, populatedErr);
        }
    }


    /**
     * This method overrides the toString() method of the System.Object Class.This method
     * converts the information in the Context in the string format.The format is as follows:
     *  * <p>
     * "Message (Message Number in the context) :[(Message severity Level)](Message code)-(Formatted message body with context info)
     * Message stack Trace"
     *
     * @return errString String
     */
    public String toString() {
        StringBuffer retVal = new StringBuffer(PayflowConstants.EMPTY_STRING);
        int errCount;
        int errMaxCount;
        ErrorObject err;

        populateErrors();
        errMaxCount = mErrorObjects.size();
        for (errCount = 0; errCount < errMaxCount; errCount++) {
            err = (ErrorObject) mErrorObjects.get(errCount);
            if (null != err) {
                if (errMaxCount > 0) {
                    retVal.append(PayflowConstants.FORMAT_MSG_SEPERATOR);
                    retVal.append(errCount + 1);
                    retVal.append(PayflowConstants.FORMAT_MSG_LINESEPERATOR);
                    //retVal.append("\n\r");
                }
                retVal.append(PayflowConstants.FORMAT_MSG_OPENBRACKET);
                retVal.append(getStringSeverity(err.getSeverityLevel()));
                retVal.append(PayflowConstants.FORMAT_MSG_CLOSEBRACKET);
                retVal.append(err.toString());
                retVal.append("\n");
                if (null != err.getErrorStackTrace()) {
                    retVal.append(err.getErrorStackTrace());
                }
                //if (errCount < errMaxCount - 1)
                //	retVal.append("\n\r");
            }
        }

        return retVal.toString();
    }

    /**
     * This method is another overload for the method toString().This method
     * converts the information in the Context in the string format.This will return
     * the formatted error string for messages that have severity level equal to or above
     * the severitylevel parameter passed to this function.The messages for different errors
     * are separated by the separator format passed to the method.In case no separator is
     * passed a new line character is used.
     *
     * @param severityLevel int
     * @param seperator     String
     * @return retVal String
     */
    public String toString(int severityLevel, String seperator) {

        StringBuffer retVal = new StringBuffer(PayflowConstants.EMPTY_STRING);
        int errCount;
        int errMaxCount;
        ErrorObject err;
        ArrayList errObjects;
        errObjects = getErrors(severityLevel);

        errMaxCount = errObjects.size();
        for (errCount = 0; errCount < errMaxCount; errCount++) {
            err = (ErrorObject) errObjects.get(errCount);
            retVal.append(err.toString());
            if (errCount < errMaxCount - 1) {
                if (seperator != null && seperator.length() != 0) {
                    retVal.append(seperator);
                } else {
                    retVal.append("\n\r");
                }
            }
        }

        return retVal.toString();
    }

    /**
     * This resets the context object
     */
    public void clearErrors() {

        if (mErrorObjects != null) {
            mErrorObjects.clear();
            mHighestErrorLvl = 0;
        }

    }

    /**
     * This gets the severity level for a
     * severity integer value.
     *
     * @param severity int
     * @return retVal String
     */
    private static String getStringSeverity(int severity) {

        String retVal = PayflowConstants.ERROR_WARN;

        switch (severity) {
            case PayflowConstants.SEVERITY_DEBUG:
                retVal = PayflowConstants.ERROR_DEBUG;
                break;
            case PayflowConstants.SEVERITY_INFO:
                retVal = PayflowConstants.ERROR_INFO;
                break;
            case PayflowConstants.SEVERITY_WARN:
                retVal = PayflowConstants.ERROR_WARN;
                break;
            case PayflowConstants.SEVERITY_ERROR:
                retVal = PayflowConstants.ERROR_ERROR;
                break;
            case PayflowConstants.SEVERITY_FATAL:
                retVal = PayflowConstants.ERROR_FATAL;
                break;
        }

        return retVal;
    }

}