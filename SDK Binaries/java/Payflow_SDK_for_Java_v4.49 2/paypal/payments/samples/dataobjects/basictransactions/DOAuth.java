package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Authorize transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOAuth {
    public DOAuth() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOAuth.java");
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
        //SDKProperties.setMaxLogFileSize(1000000);

        // Uncomment the lines below and set the proxy address and port, if a proxy has to be used.
        //SDKProperties.setProxyAddress("");
        //SDKProperties.setProxyPort(80);
        //SDKProperties.setProxyLogin("");
        //SDKProperties.setProxyPassword("");

        // Create the Data Objects.
        // Create the User data object with the required user details.
        UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow Connection data object with the required connection details.
        PayflowConnectionData connection = new PayflowConnectionData();

        // Create a new Invoice data object with the Amount, Billing Address etc. details.
        Invoice inv = new Invoice();

        // Set Amount.
        Currency amt = new Currency(new Double(25.12));
        inv.setAmt(amt);
        inv.setPoNum("PO12345");
        inv.setInvNum("INV12345");

        // Set the Billing Address details.
        BillTo bill = new BillTo();
        bill.setStreet("123 Main St.");
        bill.setZip("12345");
        inv.setBillTo(bill);

        // Create a new Payment Device - Credit Card data object.
        // The input parameters are Credit Card No. and Expiry Date for the Credit Card.
        CreditCard cc = new CreditCard("5105105105105100", "0109");
        cc.setCvv2("123");

        // Create a new Tender - Card Tender data object.
        CardTender card = new CardTender(cc);
        ///////////////////////////////////////////////////////////////////

        // Create a new Auth Transaction.
        AuthorizationTransaction trans = new AuthorizationTransaction(
                user, connection, inv, card, PayflowUtility.getRequestId());

        trans.setPartialAuth("Y");

        // Submit the Transaction
        Response resp = trans.submitTransaction();

        // Display the transaction response parameters.
        if (resp != null) {
            // Get the Transaction Response parameters.
            TransactionResponse trxnResponse = resp.getTransactionResponse();

            if (trxnResponse != null) {

                System.out.println("RESULT = " + trxnResponse.getResult());
                System.out.println("PNREF = " + trxnResponse.getPnref());
                System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
                System.out.println("AUTHCODE = " + trxnResponse.getAuthCode());
                System.out.println("AVSADDR = " + trxnResponse.getAvsAddr());
                System.out.println("AVSZIP = " + trxnResponse.getAvsZip());
                System.out.println("IAVS = " + trxnResponse.getIavs());
                System.out.println("CVV2MATCH = " + trxnResponse.getCvv2Match());
                // If value is true, then the Request ID has not been changed and the original response
                // of the original transction is returned.
                System.out.println("DUPLICATE = " + trxnResponse.getDuplicate());
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
