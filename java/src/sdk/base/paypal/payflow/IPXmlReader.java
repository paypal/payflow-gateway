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

import org.apache.xerces.parsers.DOMParser;
import org.w3c.dom.Document;
import org.xml.sax.InputSource;

import java.io.StringReader;
import java.util.HashMap;

class IPXmlReader {

    //private static final char SEPARATOR =  '/';
    /**
     * Hash representation of the configuration data present in an XML configuration
     * file.
     */
    private HashMap xmlData = null;

    private Document xmlDocumentElement = null;

    /**
     * This variable holds the input xml String.
     * This is used for logging purposes.
     */
    //private String xmlString = null;

    /**
     * IPXmlReader is the sole constructor which reads an XML file and stores
     * the data in a hash data structure which is easier to traverse by the caller, ECMConfiguration.
     * The constructor does the following things :
     * <ol><li> Checks if the Xml file is not null. </li>
     * <li> It parses the Xml file using DOM Parser and generates a Document object</li>
     * <li> The method populateXmlConfigurationData() called by passing the Document object</li>
     *
     * @param xmlString Configuration File name.
     * @throws Exception Exception
     */
    public IPXmlReader(String xmlString)
            throws Exception {
        Logger.getInstance().log("paypal.payflow.IPXmlReader.IPXmlReader(String) : Entered", PayflowConstants.SEVERITY_DEBUG);
        if (xmlString == null) {
            throw new Exception("The xml String is null");
        }

        /* Initializing xmlConfigurationData */
        xmlData = new HashMap();

        /* Initializing xmlParser */
        DOMParser xmlParser;
        xmlParser = new DOMParser();
        //creating a StringReader for the xml string
        StringReader xmlStringReader = new StringReader(xmlString);
        InputSource xmlInputSource = new InputSource(xmlStringReader);
        // Parsing the document
        xmlParser.parse(xmlInputSource);
        // Creating a Document object.
        this.xmlDocumentElement = xmlParser.getDocument();

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
