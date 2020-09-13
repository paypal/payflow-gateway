package paypal.payflow;

/**
 * This class holds the advice detail related information.
 * Detail of a charge where *n* is a value from 1 - 5. Use for additional breakdown of the amount.
 * For example ADDLAMT1=1 is the amount for the additional amount for advice detail item 1 and is equal to 1,
 * <p>Following example shows how to use advice detail.</p>
 * <p>
 * .................
 * //inv is the Invoice object.
 * .................
 * // Create a advice detail item.
 * AdviceDetail addDetail1 = new AdviceDetail();
 * addDetail1.setAddLAmt("1");
 * addDetail1.setAddLAmtType("1");
 * inv.addAdviceDetailItem(addDetail1);
 * AdviceDetail addDetail2 = new AdviceDetail();
 * addDetail2.setAddLAmt("2");
 * addDetail2.setAddLAmtType("2");
 * inv.addAdviceDetailItem(addDetail2);
 * ..................
 */

public class AdviceDetail extends BaseRequestDataObject {

    private String adviceDetailNumber;
    private String addLAmt;
    private String addLAmtType;

    /**
     * Gets the advice detail amount
     *
     * @return addLAmt
     * <p>Maps to Payflow Parameter: ADDLAMT</p>
     */
    public String getAddLAmt() {
        return addLAmt;
    }

    /**
     * Sets the advice detail amount
     *
     * @param addLAmt String
     * <p>Maps to Payflow Parameter: ADDLAMT</p>
     */
    public void setAddLAmt(String addLAmt) {
        this.addLAmt= addLAmt;
    }

    /**
     * Gets the advice detail amount type
     *
     * @return addLAmtType
     * <p>Maps to Payflow Parameter: ADDLAMTTYPE</p>
     */
    public String getAddLAmtType() {
        return addLAmtType;
    }
    /**
     * Sets the advice detail amount type
     *
     * @param addLAmtType String
     * <p>Maps to Payflow Parameter: ADDLAMTTYPE/p>
     */
    public void setAddLAmtType(String addLAmtType) {
        this.addLAmtType = addLAmtType;
    }

    /// --------------------------------------------
    /**
     * Gets the advice detail number.
     *
     * @return advice detail number.
     * <p>Maps to Payflow Parameter: ADDLXXXXXn</p>
     */
    public String getAdviceDetailNumber() {
        return adviceDetailNumber;
    }

    /**
     * Sets the advice detail number.
     *
     * @param adviceDetailNumber String
     * <p>Maps to Payflow Parameter: ADDLXXXXXn</p>
     */
    public void setAdviceDetailNumber(String adviceDetailNumber) {
        this.adviceDetailNumber = adviceDetailNumber;
    }

    protected void generateRequest(int Index) {

        try {
            String IndexVal = String.valueOf(Index+1);

            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ADDLAMT + IndexVal, addLAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ADDLAMTTYPE+ IndexVal, addLAmtType));

        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }
}