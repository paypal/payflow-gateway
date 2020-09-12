package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple reference Credit transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOReferenceCredit {
    public DOReferenceCredit() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOReferenceCredit.java");
        System.out.println("------------------------------------------------------");

        // Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
        // For testing: 	pilot-payflowpro.paypal.com
        // For production:  payflowpro.paypal.com
        // DO NOT use payflow.verisign.com or test-payflow.verisign.com!
        SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
        SDKProperties.setHostPort(443);
        SDKProperties.setTimeOut(45);

        // Logging is by default off. To turn logging on uncomment the following lines:
        //SDKProperties.setLogFileName("payflow_java.log");
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
        ///////////////////////////////////////////////////////////////////

        // If you want to change the amount being credited, you'll need to set the Amount object.
        //Invoice inv = new Invoice();
        // Set the amount object if you want to change the amount from the original transaction.
        // Currency Code USD is US ISO currency code.  If no code passed, USD is default.
        // See the Developer's Guide for the list of three-character currency codes available.
        //Currency amt = new Currency(new Double(5.00));
        //inv.setAmt(amt);
        //CreditTransaction trans = new CreditTransaction("<ORIG_TRANS_ID>", user, connection, inv, PayflowUtility.getRequestId());

        // Create a new Credit Transaction from the original transaction.  See above if you
        // need to change the amount.
        CreditTransaction trans = new CreditTransaction("<ORIG_TRANS_ID>", user, connection, PayflowUtility.getRequestId());

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
                System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
                System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
                System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
                System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
                System.out.println("IAVS = " + trxnResponse.getIavs());
                System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
            }

            // Get the Fraud Response parameters.
            FraudResponse fraudResp = resp.getFraudResponse();
            if (fraudResp != null) {
                System.out.println("PREFPSMSG = " + fraudResp.getPreFpsMsg());
                System.out.println("POSTFPSMSG = " + fraudResp.getPostFpsMsg());
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
