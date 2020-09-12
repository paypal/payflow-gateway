package paypal.payflow;

import java.util.ArrayList;

public class Rule extends BaseResponseDataObject {
    private int num;
    private String ruleId;
    private String ruleAlias;
    private String ruleDescription;
    private String action;
    private String triggeredMessage;
    private ArrayList ruleVendorParms;

    public int getNum() {
        return num;
    }

    public void setNum(int num) {
        this.num = num;
    }

    public String getRuleId() {
        return ruleId;
    }

    public void setRuleId(String ruleId) {
        this.ruleId = ruleId;
    }

    public String getRuleAlias() {
        return ruleAlias;
    }

    public void setRuleAlias(String rleAlias) {
        this.ruleAlias = rleAlias;
    }

    public String getRuleDescription() {
        return ruleDescription;
    }

    public void setRuleDescription(String ruleDescription) {
        this.ruleDescription = ruleDescription;
    }

    public String getAction() {
        return action;
    }

    public void setAction(String action) {
        this.action = action;
    }

    public String getTriggeredMessage() {
        return triggeredMessage;
    }

    public void setTriggeredMessage(String triggeredMessage) {
        this.triggeredMessage = triggeredMessage;
    }

    public ArrayList getRuleVendorParms() {
        return ruleVendorParms;
    }

    public void setRuleVendorParms(ArrayList ruleVendorParms) {
        this.ruleVendorParms = ruleVendorParms;
    }

    protected Rule() {
        ruleVendorParms = new ArrayList();
    }

}

