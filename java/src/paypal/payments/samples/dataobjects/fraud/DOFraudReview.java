package paypal.payments.samples.dataobjects.fraud;

import paypal.payflow.*;

// <summary>
// This class uses the Payflow SDK Data Objects to Approve a Fraudulent transaction.

public class DOFraudReview {
    public DOFraudReview() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOFraudReview.java");
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
        // Create the user data object with the required user details.
        UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow Connection data object with the required connection details.
        PayflowConnectionData connection = new PayflowConnectionData();
        ///////////////////////////////////////////////////////////////////

        // Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
        FraudReviewTransaction trans = new FraudReviewTransaction("<origId>", "RMS_APPROVE",
                user, connection, PayflowUtility.getRequestId());

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
