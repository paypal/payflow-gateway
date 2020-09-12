package paypal.payments.samples.namevaluepairs;

import paypal.payflow.*;

// This class uses the Payflow SDK API to do a simple Sale transaction from the Command Line.
// The request is sent as a Name-Value pair string & the response received is also
// Name-Value Pair string.

public class NVPCommandLine {
    public NVPCommandLine() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: NVPCommandLine.java");
        System.out.println("------------------------------------------------------");

        // Logging is by default off. To turn logging on uncomment the following lines:
        //SDKProperties.setLogFileName("payflow_java.log");
        //SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        //SDKProperties.setMaxLogFileSize(100000);
        //SDKProperties.setStackTraceOn(true);

        String responseStr;
        String requestId;

        if (args.length < 4) {
            System.out.println("\nIncorrect number of arguments. Usage:\n"
                    + "java NVPCommandLine <hostAddress> <hostPort> <parmList> <timeOut> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>");
            System.out.println("\nExample transaction:\n" + "java NVPCommandLine pilot-payflowpro.paypal.com 443 \"USER=<user>&TRXTYPE[1]=A&VENDOR=<vendor>&AMT[5]=25.00&PWD=<password>&PARTNER=<partner>&TENDER[1]=C&ACCT[16]=5100000000000008&EXPDATE[4]=0110\" 45");
            return;
        }

        PayflowAPI payflowApi;

        if (args.length == 4) {
            payflowApi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]));
        } else {
            payflowApi = new PayflowAPI(args[0],
                    Integer.parseInt(args[1]),
                    Integer.parseInt(args[3]), args[4],
                    Integer.parseInt(args[5]),
                    args[6], args[7]);
        }

        responseStr = payflowApi.submitTransaction(args[2],
                PayflowUtility.getRequestId());

        requestId = payflowApi.getRequestId();

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

