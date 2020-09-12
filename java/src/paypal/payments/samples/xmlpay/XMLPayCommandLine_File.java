// Before you can use the XMLPay example, you must download the Xerces-J 2.7.1 package (XML parser) called Xerces-J-bin.2.7.1.tar.gz
// from Apache's archive download Web site at http://archive.apache.org/dist/xml/xerces-j/. A higher version probably will work, but has
// not been tested at this time.
//
// The Xerces jars (xercesImpl.jar and xml-apis.jar) need to be copied in the "lib" folder in the package.
//

package paypal.payments.samples.xmlpay;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.text.MessageFormat;

import paypal.payflow.*;

// This class uses the Payflow SDK API to run XML Pay transactions by reading the files.
// The request is sent as a XMLPay string & the response received
// is also XMLPay string.

public class XMLPayCommandLine_File {
    public XMLPayCommandLine_File() {
    }

    public static void main(String[] args) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: XMLPayCommandLine_File.java");
        System.out.println("------------------------------------------------------");

        // Logging is by default off. To turn logging on uncomment the following lines:
        //SDKProperties.setLogFileName("payflow_java.log");
        //SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        //SDKProperties.setMaxLogFileSize(100000);
        if (args.length < 4) {
            System.out.println("Incorrect number of arguments. Usage:" + "java XMLPayCommandLine_File <hostAddress> <hostPort> <xml filename> <timeout> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>");
            System.out.println("Example transaction:" + "java XMLPayCommandLine_File pilot-payflowpro.paypal.com 443 \"C:" +
                    "\\" + "Sale.xml\" 45");
            return;
        }

        PayflowAPI payflowapi;
        if (args.length == 4) {
            // Replace the <certs_path> in the following line by the absolute path
            // of the certs directory.
            // E.g. For windows os: "C:\\Payflow SDK for Java \\certs".
            // Pls note that '\' needs to be escaped with another '\'.
            // For non-windows os: "/usr/Payflow SDK for Java /certs"
            payflowapi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]));
        } else {
            // Replace the <certs_path> in the following line by the absolute path
            // of the certs directory.
            // E.g. For windows os: "C:\\Payflow SDK for Java \\certs".
            // Pls note that '\' needs to be escaped with another '\'.
            // For non-windows os: "/usr/Payflow SDK for Java /certs"
            payflowapi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]), args[4],
                    Integer.parseInt(args[5]),
                    args[6], args[7]);
        }

        String XmlFile = ReadFile(args[2]);
        if (XmlFile != null) {
            String responseStr = payflowapi.submitTransaction(XmlFile, PayflowUtility.getRequestId());

            // Create a new Client Information data object.
            ClientInfo clInfo = new ClientInfo();

            // Set the ClientInfo object of the PayflowAPI.
            payflowapi.setClientInfo(clInfo);

            // To write the Response on to the console.
            System.out.println("Request = " + payflowapi.getTransactionRequest());
            System.out.println("Response = " + responseStr);

            // Following lines of code are optional.
            // Begin optional code for displaying SDK errors ...
            // It is used to read any errors that might have occured in the SDK.
            // Get the transaction errors.
            String transErrors = payflowapi.getTransactionContext().toString();
            if (transErrors != null && transErrors.length() > 0) {
                System.out.println("Transaction Errors from SDK = " + transErrors);
            }

        }
    }

    // Read the xml file into a string.
    private static String ReadFile(String FilePath) {
        String fileString = null;
        File xmlFile = new File(FilePath);
        if (xmlFile.exists()) {
            char[] xmlContent = new char[(int) xmlFile.length()];

            try {
                BufferedReader br = new BufferedReader(new InputStreamReader(new FileInputStream(xmlFile)));
                br.read(xmlContent, 0, (int) xmlFile.length());
                fileString = xmlContent.toString();
            } catch (FileNotFoundException e) {
                System.err.println(MessageFormat.format("FileNotFoundException: {0}", new Object[]{e.getMessage()}));
            } catch (IOException e) {
                System.err.println(MessageFormat.format("Caught IOException: {0}", new Object[]{e.getMessage()}));
            }
        } else {
            System.out.println("<XMLPayResponse><ResponseData><Vendor></Vendor><Partner></Partner><TransactionResults><Result>-100</Result><Message>" +
                    "Failed to open XML file at location " + FilePath + "</Message><PNRef>V00000000000</PNRef>" +
                    "<AuthCode>000000</AuthCode><HostCode>0</HostCode></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>");
        }
        return fileString;
    }
}

