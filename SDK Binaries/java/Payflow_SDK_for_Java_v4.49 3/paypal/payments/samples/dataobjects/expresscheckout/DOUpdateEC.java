package paypal.payments.samples.dataobjects.expresscheckout;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do an Update Express Checkout transaction. Used
// for reference transaction only, see below.
//
// The request is sent as a Data Object and the response received is also a Data Object.
//
// This sample is for reference and for testing purposes only.  See the eStoreFront sample for
// one way to perform an Express Checkout transaction from your web site.
//
// Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developers
// Guide (US, AU) or the Websites Payments Pro Payflow Edition Developers Guide (UK).
//
// Besides doing a standard Express Checkout transactions, you can also do a Express Checkout Reference
// Transaction.
//
// A reference transaction takes existing billing information already gathered from a previously
// authorized transaction and reuses it to charge the customer in a subsequent transaction.
// Reference transactions, typically used for repeat billing to a merchants PayPal account when
// customers are not present to log in, are now supported through Express Checkout.
//
// NOTE: You must be enabled by PayPal to use reference transactions.  Contact your account manager
// or the sales department for more details.
//
// See the DOSetEC Sample for more details on Reference Transations using Express Checkout.

public class DOUpdateEC {

    public DOUpdateEC() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOUpdateEC.cs");
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
        //SDKProperties.setProxyPort(0);

        // Create the Data Objects.
        // Create the User data object with the required user details.
        UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow  Connection data object with the required connection details.
        // The PAYFLOW_HOST property is defined in the App config file.
        PayflowConnectionData Connection = new PayflowConnectionData();

        // You can use the Update Billing Agreement request to cancel the billing agreement or update
        // the billing agreement description.
        //
        // For more information on Reference Transactions, see the DOSetEC Sample for more details.

        // For Express Checkout Reference Transaction without Purchase.
        ECUpdateBARequest updateRequest = new ECUpdateBARequest("<BAID>", "<BA_STATUS>", "<BA_DESC>");

        // Create the Tender object.
        PayPalTender paypalTender = new PayPalTender(updateRequest);

        // Create the transaction object.  We do not pass a Transaction Type for an update call.
        BaseTransaction Trans = new BaseTransaction(
                null, User, Connection, null, paypalTender, PayflowUtility.getRequestId());

        // Submit the transaction.
        Response Resp = Trans.submitTransaction();

        // Display the transaction response parameters.
        if (Resp != null) {
            // Get the Transaction Response parameters.
            TransactionResponse TrxnResponse = Resp.getTransactionResponse();

            if (TrxnResponse != null) {
                System.out.println("RESULT = " + TrxnResponse.getResult());
                System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
                if (TrxnResponse.getResult() == 0) {
                    System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
                    System.out.println("PAYERID = " + Trans.getResponse().getEcGetResponse().getPayerId());
                    System.out.println("PAYERSTATUS = " + Trans.getResponse().getEcGetResponse().getPayerStatus());
                    System.out.println("FIRST = " + Trans.getResponse().getEcGetResponse().getFirstName());
                    System.out.println("LAST = " + Trans.getResponse().getEcGetResponse().getLastName());
                    System.out.println("EMAIL = " + Trans.getResponse().getEcGetResponse().getEmail());
                    System.out.println("BAID = " + Trans.getResponse().getEcDoResponse().getbaId());
                    System.out.println("BA_STATUS = " + Trans.getResponse().getEcUpdateResponse().getba_Status());
                    System.out.println("BA_DESC = " + Trans.getResponse().getEcUpdateResponse().getba_Desc());
                }
                // If value is true, then the Request ID has not been changed and the original response
                // of the original transction is returned.
                System.out.println("DUPLICATE = " + TrxnResponse.getDuplicate());
            }

            // Display the response.
            System.out.println();
            System.out.println(PayflowUtility.getStatus(Resp));

            // Get the Transaction Context and check for any contained SDK specific errors (optional code).
            Context TransCtx = Resp.getContext();
            if (TransCtx != null && TransCtx.getErrorCount() > 0) {
                System.out.println();
                System.out.println("Transaction Errors = " + TransCtx.toString());
            }
        }
    }
}
