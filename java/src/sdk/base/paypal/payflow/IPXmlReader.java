package paypal.payflow;

import org.w3c.dom.Document;
import org.xml.sax.InputSource;

import javax.xml.parsers.DocumentBuilderFactory;
import java.io.StringReader;
import java.util.HashMap;

class IPXmlReader {

    private HashMap xmlData = null;

    private Document xmlDocumentElement = null;

    /**
     * Parses an XML string into a DOM Document.
     *
     * @param xmlString XML input string.
     * @throws Exception if the string is null or cannot be parsed.
     */
    public IPXmlReader(String xmlString)
            throws Exception {
        Logger.getInstance().log("paypal.payflow.IPXmlReader.IPXmlReader(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        if (xmlString == null) {
            throw new Exception("The xml String is null");
        }

        xmlData = new HashMap();

        StringReader xmlStringReader = new StringReader(xmlString);
        InputSource xmlInputSource = new InputSource(xmlStringReader);
        this.xmlDocumentElement = DocumentBuilderFactory.newInstance()
                .newDocumentBuilder()
                .parse(xmlInputSource);

        Logger.getInstance().log("paypal.payflow.IPXmlReader.IPXmlReader(String) : Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * @return Returns the xmlDocumentElement.
     */
    public Document getXmlDocumentElement() {
        Logger.getInstance().log("paypal.payflow.IPXmlReader.getXmlDocumentElement() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.IPXmlReader.getXmlDocumentElement() : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return xmlDocumentElement;
    }

    /**
     * @return Returns the xmlData.
     */
    public HashMap getXmlData() {
        Logger.getInstance().log("paypal.payflow.IPXmlReader.getXmlData() : Entered", PayflowConstants.SEVERITY_DEBUG);
        Logger.getInstance().log("paypal.payflow.IPXmlReader.getXmlData() : Exiting", PayflowConstants.SEVERITY_DEBUG);
        return xmlData;
    }
}
