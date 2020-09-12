package paypal.payments.samples.dataobjects.misc;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do an Inquiry transaction.
//
// You perform an inquiry using a reference to an original transaction, the PNREF
// value returned for the original transaction.
//
// While the amount of information returned in an Inquiry transaction depends upon the VERBOSITY setting,
// Inquiry responses mimic the verbosity level of the original transaction as much as possible.
//
// Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
// processor vary in detail level and in format. The Payflow Pro Verbosity parameter enables you to control
// the kind and level of information you want returned.  By default, Verbosity is set to LOW.
// A LOW setting causes PayPal to normalize the transaction result values. Normalizing the values limits
// them to a standardized set of values and simplifies the process of integrating Payflow Pro.
// By setting Verbosity to MEDIUM, you can view the processor?s raw response values. This setting is more
// "verbose" than the LOW setting in that it returns more detailed, processor-specific information.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOInquiry_ACH {
    public DOInquiry_ACH() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOInquiry_ACH.java");
        System.out.println("------------------------------------------------------");

        // Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
        // For testing: 	pilot-payflowpro.paypal.com
        // For production:  payflowpro.paypal.com
        // DO NOT use payflow.verisign.com or test-payflow.verisign.com!
        SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
        SDKProperties.setHostPort(443);
        SDKProperties.setTimeOut(45);

        // Logging is by default off. To turn logging on uncomment the following lines:
        //DKProperties.setLogFileName("payflow_java.log");
        //SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        //SDKProperties.setMaxLogFileSize(100000);

        // Uncomment the lines below and set the proxy address and port, if a proxy has to be used.
        //SDKProperties.setProxyAddress("");
        //SDKProperties.setProxyPort(0);

        // Create the Data Objects.
        // Create the User data object with the required user details.
        UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow Connection data object with the required connection details.
        PayflowConnectionData connection = new PayflowConnectionData();

        // Create a new Inquiry Transaction.
        // Replace <PNREF> with a previous transaction ID that you processed on your account.
        InquiryTransaction trans = new InquiryTransaction("<PNREF>", user, connection, PayflowUtility.getRequestId());

        // Submit the Transaction
        Response resp = trans.submitTransaction();

        // Display the transaction response parameters.
        if (resp != null) {
            // Get the Transaction Response parameters.
            TransactionResponse trxnResponse = resp.getTransactionResponse();

            // Create a new Client Information data object.
            ClientInfo clInfo = new ClientInfo();

            // Set the ClientInfo object of the transaction object.
            trans.setClientInfo(clInfo);

            if (trxnResponse != null) {
                System.out.println("RESULT = " + trxnResponse.getResult());
                System.out.println("PNREF = " + trxnResponse.getPnref());
                System.out.println("--------------------------------------------");
                System.out.println("Original Response Data");
                System.out.println("--------------------------------------------");
                System.out.println("ORIGRESULT = " + trxnResponse.getOrigResult());
                System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
                System.out.println("STATUS = " + trxnResponse.getStatus());
                System.out.println("TRANSSTATE = " + trxnResponse.getTransState());
            }

            // Display the response.
            System.out.println("\n" + PayflowUtility.getStatus(resp));

            // Get the Transaction Context and check for any contained SDK specific errors (optional code).
            Context transCtx = resp.getContext();
            if (transCtx != null && transCtx.getErrorCount() > 0) {
                System.out.println("\nTransaction Errors = " + transCtx.toString());
            }
        }
    }
}