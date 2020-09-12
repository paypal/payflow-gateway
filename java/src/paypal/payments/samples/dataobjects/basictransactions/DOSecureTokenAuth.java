package paypal.payments.samples.dataobjects.basictransactions;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a simple Authorize transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DOSecureTokenAuth {
    public DOSecureTokenAuth() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOSecureTokenAuth.java");
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
        Currency amt = new Currency(new Double(25.00), "USD");
        inv.setAmt(amt);
        inv.setPoNum("PO12345");
        inv.setInvNum("INV12345");

        // Set the Billing Address details.
        BillTo bill = new BillTo();
        bill.setBillToStreet("123 Main St.");
        bill.setBillToZip("12345");
        inv.setBillTo(bill);

        // Since we are using the hosted payment pages, you will not be sending the credit card data with the
        // Secure Token Request.  You just send all other 'sensitive' data within this request and when you
        // call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
        // and the SECURETOKENID that was created and used in the request.

        // Create a new Secure Token Authorization Transaction.  Even though this example is performing
        // an authorization, you can create a secure token using SaleTransaction too.  Only Authorization and Sale
        // type transactions are permitted.

        // Create a new Auth Transaction.
        AuthorizationTransaction trans = new AuthorizationTransaction(user, connection, inv, null, PayflowUtility.getRequestId());

        // Set the flag to create a Secure Token.
        trans.setCreateSecureToken("Y");
        // The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to
        // generate a random id, but any means to create an id can be used.
        trans.setSecureTokenId(PayflowUtility.getRequestId());

        // Submit the Transaction
        Response resp = trans.submitTransaction();

        // Display the transaction response parameters.
        if (resp != null) {
            // Get the Transaction Response parameters.
            TransactionResponse trxnResponse = resp.getTransactionResponse();

            if (trxnResponse != null) {

                System.out.println("RESULT = " + trxnResponse.getResult());
                System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
                System.out.println("SECURETOKEN = " + trxnResponse.getSecureToken());
                System.out.println("SECURETOKENID = " + trxnResponse.getSecureTokenId());
                // If value is true, then the Request ID has not been changed and the original response
                // of the original transaction is returned.
                System.out.println("DUPLICATE = " + trxnResponse.getDuplicate());
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
