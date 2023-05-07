// Before you can use the XMLPay example, you must download the Xerces-J 2.7.1 package (XML parser) called Xerces-J-bin.2.7.1.tar.gz
// from Apache’s archive download Web site at http://archive.apache.org/dist/xml/xerces-j/. A higher version probably will work, but has 
// not been tested at this time.
//
// The Xerces jars (xercesImpl.jar and xml-apis.jar) need to be copied in the "lib" folder in the package.
//
package paypal.payments.samples.xmlpay;

import paypal.payflow.*;

// This class uses the Payflow SDK API to do a simple Sale transaction from the Command Line.
// The request is sent as a Name-Value pair string & the response received is also

// Name-Value Pair string.
public class XMLPayCommandLine {
    public XMLPayCommandLine() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: XMLPayCommandLine.java");
        System.out.println("------------------------------------------------------");

        // Logging is by default off. To turn logging on uncomment the following lines:
        //SDKProperties.setLogFileName("payflow_java.log");
        //SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        //SDKProperties.setMaxLogFileSize(100000);

        String responseStr;

        if (args.length < 4) {
            System.out.println("\nIncorrect number of arguments. Usage:\n"
                    + "java XMLPayCommandLine <hostAddress> <hostPort> <parmList> <timeOut> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>");
            System.out.println("\nExample transaction:\n" + "java XMLPayCommandLine pilot-payflowpro.paypal.com 443 \"<?xml version='1.0'?><XMLPayRequest Timeout='45' version='2.0'><RequestData><Partner>[partner]</Partner><Vendor>[vendor]</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='USD'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>200901</ExpDate></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>[user]</User><Password>[password]</Password></UserPass></RequestAuth></XMLPayRequest>\" 45");
            return;
        }

        PayflowAPI payflowApi;
        if (args.length == 4) {
            // Replace the <certs_path> in the following line by the absolute path
            // of the certs directory.
            // E.g. For windows os: "C:\\Payflow SDK for Java \\certs".
            // Pls note that '\' needs to be escaped with another '\'.
            // For non-windows os: "/usr/Payflow SDK for Java /certs"
            payflowApi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]));

        } else {
            // Replace the <certs_path> in the following line by the absolute path
            // of the certs directory.
            // E.g. For windows os: "C:\\Payflow SDK for Java \\certs".
            // Pls note that '\' needs to be escaped with another '\'.
            // For non-windows os: "/usr/Payflow SDK for Java /certs"
            payflowApi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]), args[4],
                    Integer.parseInt(args[5]),
                    args[6], args[7]);

        }

        responseStr = payflowApi.submitTransaction(args[2],
                PayflowUtility.getRequestId());

        // Create a new Client Information data object.
        ClientInfo clInfo = new ClientInfo();

        // Set the ClientInfo object of the PayflowAPI.
        payflowApi.setClientInfo(clInfo);

        // To write the Response on to the console.
        System.out.println("\nRequest = " + payflowApi.getTransactionRequest());
        System.out.println("\nResponse = " + responseStr);

        // Following lines of code are optional.
        // Begin optional code for displaying SDK errors ...
        // It is used to read any errors that might have occured in the SDK.
        // Get the transaction errors.
        String transErrors = payflowApi.getTransactionContext().toString();
        if (transErrors != null && transErrors.length() > 0) {
            System.out.println("\nTransaction Errors from SDK = " + transErrors);
        }

    }
}

