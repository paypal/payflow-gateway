package paypal.payflow;



import java.util.Hashtable;

/**
 * Parameter List Validator Class.
 */
final class ParameterListValidator {
    /**
     * private Constructor.
     */
    private ParameterListValidator() {
        Logger.getInstance().log("paypal.payflow.ParameterListValidator() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.ParameterListValidator() : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * validates the param list
     *
     * @param paramList      String
     * @param isXmlPayReq    Boolen
     * @param currentContext Context
     */
    public static void validate(String paramList, boolean isXmlPayReq, Context currentContext) {
        Logger.getInstance().log("paypal.payflow.ParameterListValidator.Validate(String,boolean,Context): Entered", PayflowConstants.SEVERITY_DEBUG);
        try {
            if (isXmlPayReq) {
                new IPXmlReader(paramList);
            } else {
                if (paramList != null && paramList.length() > 0) {
                    parseNVPList(paramList, currentContext, false);
                }
            }

        } catch (Exception Ex) {
            ErrorObject Err = PayflowUtility.populateCommError(PayflowConstants.E_INVALID_NVP, Ex, PayflowConstants.SEVERITY_FATAL, isXmlPayReq, null);
            if (!currentContext.isCommunicationErrorContained(Err)) {
                currentContext.addError(Err);
            }
        }
        Logger.getInstance().log("paypal.payflow.ParameterListValidator.Validate(String,bool,Context): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Validates Name Value Pair Request.
     *
     * @param paramList                 String
     * @param currentContext            Context
     * @param populateResponseHashTable boolean
     * @return table HashTable
     */
    public static Hashtable parseNVPList(String paramList, Context currentContext, boolean populateResponseHashTable) {
        Logger.getInstance().log("paypal.payflow.ParameterListValidator.ParseNVPList(String, context, boolean): Entered", PayflowConstants.SEVERITY_DEBUG);
        long paramListLen = paramList.length();
        int index = 0;
        boolean openBracket = false;
        boolean closeBracket = false;
        String addlMessage;
        ErrorObject err;
        Hashtable paramListHashTable = new Hashtable();
        if (paramList == null || paramList.length() <= 0) {
            err = PayflowUtility.populateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_FATAL, false, null);
            currentContext.addError(err);
        }
        while (index < paramListLen && currentContext.getHighestErrorLvl() < PayflowConstants.SEVERITY_FATAL) {
            int NameBuffSize = 1000;
            int ValBuffSize = 1000;
            int LenBuffSize = 1000;
            char[] NameBuffer = new char[NameBuffSize];
            char[] LenValueBuffer = new char[LenBuffSize];
            char[] ValueBuffer = new char[ValBuffSize];
            char[] TempArray;
            int LenIndex = 0;
            int NameIndex = 0;
            while (index < paramListLen && paramList.charAt(index) != '\0' && paramList.charAt(index) != '=') {
                if (paramList.charAt(index) == '[') {
                    if (openBracket) {
                        addlMessage = "Found unmatched '[' followed by another '[' at index  " + (index + 1);
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        break;
                    }
                    openBracket = true;
                    index++;
                    continue;
                }
                if (paramList.charAt(index) == ']') {
                    if (!openBracket) {
                        addlMessage = "Unmatched ']' at index " + (index + 1);
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        break;
                    } else if ((index + 1) < paramListLen && paramList.charAt(index + 1) != '=') {
                        addlMessage = "']' is not followed by '=' in param list at index " + (index + 1);
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        break;
                    } else if ((index + 1) < paramListLen && paramList.charAt(index - 1) == '[') {
                        addlMessage = "Length of value not found in '[]' at index " + (index + 1);
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        break;
                    } else {
                        if (closeBracket) {
                            addlMessage = "Found unmatched ']' followed by another ']' at index  " + (index + 1);
                            err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                            if (!currentContext.isCommunicationErrorContained(err)) {
                                currentContext.addError(err);
                            }
                            break;
                        }
                        index++;
                        closeBracket = true;
                        continue;
                    }
                }
                if (openBracket && !closeBracket) {
                    //increase the size of LenValueBuffer if required
                    if (LenIndex >= LenBuffSize) {
                        LenBuffSize += 2000;
                        TempArray = new char[LenBuffSize];
                        // Commented by CRT
                        //System.Array.Copy(LenValueBuffer, TempArray, LenValueBuffer.length);
                        LenValueBuffer = TempArray;
                    }
                    LenValueBuffer[LenIndex] = paramList.charAt(index);
                    LenIndex++;
                    index++;
                } else {
                    //increase the size of NameBuffer if required
                    if (NameIndex >= NameBuffSize) {
                        NameBuffSize += 2000;
                        TempArray = new char[NameBuffSize];
                        // Commented by CRT
                        //System.Array.Copy(NameBuffer, TempArray, NameBuffer.length);
                        NameBuffer = TempArray;
                    }
                    NameBuffer[NameIndex] = paramList.charAt(index);
                    if (NameBuffer[NameIndex] == '&') {
                        addlMessage = new String(NameBuffer);
                        addlMessage = addlMessage.trim();
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                    }
                    index++;
                    NameIndex++;
                }
            }
            //skip '='
            if (index < paramListLen && paramList.charAt(index) != '\0') {
                index++;
            }
            if (openBracket && !closeBracket) {
                addlMessage = "Unmatched '[' at index " + (index + 1);
                err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                if (!currentContext.isCommunicationErrorContained(err)) {
                    currentContext.addError(err);
                }
                break;
            }
            if (openBracket && closeBracket && LenValueBuffer != null && LenValueBuffer.length > 0 && LenValueBuffer[0] == '-') {
                String Len = new String(LenValueBuffer).trim();
                addlMessage = "Invalid param length = " + Len;
                err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                if (!currentContext.isCommunicationErrorContained(err)) {
                    currentContext.addError(err);
                }
                break;
            }

            int ValIndex = 0;
            while (index < paramListLen && paramList.charAt(index) != '\0' && currentContext.getHighestErrorLvl() < PayflowConstants.SEVERITY_FATAL) {
                if (LenValueBuffer != null && LenValueBuffer.length > 0 && LenValueBuffer[0] != '\0') {
                    String LenString = new String(LenValueBuffer);
                    LenString = LenString.trim();
                    int Len;
                    try {
                        Len = Integer.parseInt(LenString);
                    } catch (Exception Ex) {
                        String Name = new String(NameBuffer).trim();
                        addlMessage = "Value in [] is not numeric data, data in '[]' =  " + LenString.trim() + "for Name = " + Name;
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, Ex, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        break;
                    }
                    int AmpIndex = index + Len;
                    if (AmpIndex < paramListLen && paramList.charAt(AmpIndex) != '&') {
                        // Modified by CRT
                        String Name = new String(NameBuffer).trim();
                        addlMessage = "Param length in '[]' does not match actual value length.Param Name = " + Name;
                        err = PayflowUtility.populateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, addlMessage);
                        if (!currentContext.isCommunicationErrorContained(err)) {
                            currentContext.addError(err);
                        }
                        index += Len + 1;
                        break;
                    } else {
                        //increase the size of ValueBuffer if required
                        if (Len >= ValBuffSize) {
                            // Fixed out of bounds array issue. 11/09/2007 tsieber
                            ValBuffSize += Len + 2000;
                            ValueBuffer = new char[ValBuffSize];
                        }
                        int ValueIndex;
                        for (ValueIndex = 0; ValueIndex < Len && index + ValueIndex < paramListLen; ValueIndex++) {
                            ValueBuffer[ValueIndex] = paramList.charAt(index + ValueIndex);
                        }
                        index += Len + 1;
                        break;
                    }
                } else {
                    //increase the size of NameBuffer if required
                    if (ValIndex >= ValBuffSize) {
                        ValBuffSize += 2000;
                        TempArray = new char[ValBuffSize];
                        // Commented by CRT
                        //System.Array.Copy(ValueBuffer, TempArray, ValueBuffer.length);
                        ValueBuffer = TempArray;
                    }
                    if (paramList.charAt(index) == '&') {
                        if ((index + 1) < paramListLen && paramList.charAt(index + 1) == '&') {
                            ValueBuffer[ValIndex] = paramList.charAt(index);
                        } else if (paramList.charAt(index - 1) == '&') {
                            ValueBuffer[ValIndex] = paramList.charAt(index);
                        } else {
                            index++;
                            // ValIndex++;
                            break;
                        }
                    } else {
                        ValueBuffer[ValIndex] = paramList.charAt(index);
                    }
                }
                index++;
                ValIndex++;
            }
            //put data in hash table as name - value
            if (populateResponseHashTable) {
                String Name = new String(NameBuffer).trim();
                String Value = new String(ValueBuffer).trim();
                if (paramListHashTable.contains(Name)) {
                    Name = Name + PayflowConstants.TAG_DUPLICATE + PayflowUtility.getRequestId();
                }
                paramListHashTable.put(Name, Value);
            }
            openBracket = false;
            closeBracket = false;
        }
        Logger.getInstance().log("paypal.payflow.ParameterListValidator.ParseNVPList(String,context,bool): Exiting", PayflowConstants.SEVERITY_DEBUG);
        return paramListHashTable;
    }
}