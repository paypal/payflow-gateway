package paypal.payflow;

import org.apache.xerces.parsers.DOMParser;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.InputSource;

import java.io.ByteArrayInputStream;
import java.util.ArrayList;
import java.util.Hashtable;

/**
 * Container class for response messages specific Fraud Protections Services.
 * <p/>
 * This class contains the fraud protection
 * services related response messages and data objects parsed
 * from the xml data in the fraud response.
 * </p>
 * {@link FpsXmlData}
 */
public final class FraudResponse extends BaseResponseDataObject {

    private Context context;
    private String preFpsMsg;
    private String postFpsMsg;
    private FpsXmlData fpsPreXmlData;
    private FpsXmlData fpsPostXmlData;

    /**
     * Gets the PreFpsMsg parameter.
     *
     * @return - String
     *  Maps to Payflow Parameter: PREFPSMSG
     */
    public String getPreFpsMsg() {
        return preFpsMsg;
    }

    /**
     * Gets the PostFpsMsg parameter.
     *
     * @return - String
     *  Maps to Payflow Parameter: POSTFPSMSG
     */
    public String getPostFpsMsg() {
        return postFpsMsg;
    }

    /**
     * Gets the Fps_PreXmlData parameter.
     *
     * @return - String
     *         <p>Its an itemized list of responses for triggered filters</p>
     *         {@link FpsXmlData}
     */
    public FpsXmlData getFpsPreXmlData() {
        return fpsPreXmlData;
    }

    /**
     * Gets the FpsPostXmlData parameter.
     *
     * @return - String
     *         Gets the FPS Post Xml data message populated in FpsXmlData object.
     *         {@link FpsXmlData}
     *  <p>Maps to Payflow Parameter: FPS_POSTXMLDATA
     */
    public FpsXmlData getFpsPostXmlData() {
        return fpsPostXmlData;
    }


    protected void setContext(Context context) {
        this.context = context;
    }

    protected FraudResponse() {
    }

    private ArrayList parseXmlData(String XmlData) throws Exception {

        DOMParser parser = new DOMParser();
        ByteArrayInputStream byteStream = new ByteArrayInputStream(XmlData.getBytes());
        InputSource source = new InputSource(byteStream);
        ArrayList fraudRuleList = new ArrayList();
        //try
        //{
        parser.parse(source);

        Document xmlDocument = parser.getDocument();

        NodeList ruleList = xmlDocument.getElementsByTagName(PayflowConstants.XML_PARAM_RULE);
        if (ruleList != null) {
            int length = ruleList.getLength();
            if (length > 0) {
                for (int index = 0; index < length; index++) {
                    Node ruleNode = ruleList.item(index);
                    Rule currRule = new Rule();
                    currRule.setNum(Integer.parseInt(ruleNode.getAttributes().getNamedItem(PayflowConstants.XML_PARAM_NUM).getNodeValue()));
                    NodeList childNodes = ruleNode.getChildNodes();
                    int childLength = childNodes.getLength();
                    for (int cindex = 0; cindex < childLength; cindex++) {
                        Element currChild = (Element) childNodes.item(cindex);
                        String Name = currChild.getNodeName();
                        Node child = currChild.getFirstChild();
                        if (PayflowConstants.XML_PARAM_RULEID.equals(Name)) {
                            currRule.setRuleId(child.getNodeValue());
                        } else if (PayflowConstants.XML_PARAM_RULEALIAS.equals(Name)) {
                            currRule.setRuleAlias(child.getNodeValue());
                        } else if (PayflowConstants.XML_PARAM_RULEDESCRIPTION.equals(Name)) {
                            currRule.setRuleDescription(child.getNodeValue());
                        } else if (PayflowConstants.XML_PARAM_ACTION.equals(Name)) {
                            currRule.setAction(child.getNodeValue());
                        } else if (PayflowConstants.XML_PARAM_TRIGGEREDMESSAGE.equals(Name)) {
                            currRule.setTriggeredMessage(child.getNodeValue());
                        } else if (PayflowConstants.XML_PARAM_RULEVENDORPARMS.equals(Name)) {
                            Element ruleVendorParams;
                            ruleVendorParams = currChild;
                            NodeList ruleParamList = ruleVendorParams.getElementsByTagName(PayflowConstants.XML_PARAM_RULEPARAMETER);
                            int ruleParamLength = ruleParamList.getLength();
                            for (int rindex = 0; rindex < ruleParamLength; rindex++) {
                                Node ruleParamNode = ruleParamList.item(rindex);
                                RuleParameter currRuleParam = new RuleParameter();
                                currRuleParam.setNum(Integer.parseInt(ruleParamNode.getAttributes().getNamedItem(PayflowConstants.XML_PARAM_NUM).getNodeValue()));
                                NodeList ruleParamChildNodes = ruleParamNode.getChildNodes();
                                int ruleParamChildLength = ruleParamChildNodes.getLength();
                                for (int rpindex = 0; rpindex < ruleParamChildLength; rpindex++) {
                                    Element currRuleParamChild = (Element) ruleParamChildNodes.item(rpindex);
                                    String ruleParamName = currRuleParamChild.getNodeName();
                                    Node ruleParamChild = currRuleParamChild.getFirstChild();
                                    if (PayflowConstants.XML_PARAM_NAME.equals(ruleParamName)) {
                                        currRuleParam.setName(ruleParamChild.getNodeValue());
                                    } else if (PayflowConstants.XML_PARAM_VALUE.equals(ruleParamName)) {
                                        currRuleParam.setType(currRuleParamChild.getAttribute(PayflowConstants.XML_PARAM_TYPE));
                                        currRuleParam.setValue(ruleParamChild.getNodeValue());
                                    }
                                }
                                currRule.getRuleVendorParms().add(currRuleParam);
                            }
                        }

                    }
                    fraudRuleList.add(currRule);
                }
            }
        }

        //}
        //catch(Exception ex)
        //{
        //	throw ex;
        //}
        return fraudRuleList;
    }


    protected void setParams(Hashtable ResponseHashTable) {
        preFpsMsg = (String) ResponseHashTable.get(PayflowConstants.PARAM_PREFPSMSG);
        postFpsMsg = (String) ResponseHashTable.get(PayflowConstants.PARAM_POSTFPSMSG);
        ResponseHashTable.remove(PayflowConstants.PARAM_PREFPSMSG);
        ResponseHashTable.remove(PayflowConstants.PARAM_POSTFPSMSG);
        SetFpsXmlData(ResponseHashTable);
    }

    private void SetFpsXmlData(Hashtable ResponseHashTable) {
        String XmlData;
        XmlData = (String) ResponseHashTable.get(PayflowConstants.PARAM_FPS_PREXMLDATA);
        fpsPreXmlData = SetRules(XmlData);
        XmlData = (String) ResponseHashTable.get(PayflowConstants.PARAM_FPS_POSTXMLDATA);
        fpsPostXmlData = SetRules(XmlData);
        ResponseHashTable.remove(PayflowConstants.PARAM_FPS_PREXMLDATA);
        ResponseHashTable.remove(PayflowConstants.PARAM_FPS_POSTXMLDATA);
    }

    private FpsXmlData SetRules(String XmlData) {
        FpsXmlData FpsData = new FpsXmlData();
        try {
            if (XmlData != null && XmlData.length() > 0) {
                ArrayList ruleList;

                ruleList = parseXmlData(XmlData);
                if (ruleList != null && ruleList.size() > 0) {
                    FpsData.SetRuleList(ruleList);
                }
            }
        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", "Error occured while parsing: " + ex.toString());
            if (context != null) {
                context.addError(err);
            }
        }
        return FpsData;
    }

}


