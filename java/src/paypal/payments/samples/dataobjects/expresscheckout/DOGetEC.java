package paypal.payments.samples.dataobjects.expresscheckout;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a normal GET Express Checkout transaction.
// The request is sent as a Data Object and the response received is also a Data Object.
//
// This sample is for reference and for testing purposes only.  See the eStoreFront sample for
// one way to perform an Express Checkout transaction from your web site.
//
// Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developer's
// Guide (US, AU) or the Websites Payments Pro Payflow Edition Developer's Guide (UK).
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

public class DOGetEC {

    public DOGetEC() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOGetEC.java");
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

        // Calling a GET operation is second step in PayPal Express checkout process. Once the
        // customner has logged into his/her paypal account, selected shipping address and clicked on
        // "Continue checkout", the PayPal server will redirect the page to the ReturnUrl you have
        // specified in the previous SET request.  To obtain the shipping details chosen by the
        // Customer, you will then need to do a GET operation.
        //
        // For more information on Reference Transactions, see the DOSetEC Sample for more details.

        // For Regular Express Checkout or Express Checkout Reference Transaction with Purchase.
        ECGetRequest getRequest = new ECGetRequest("<TOKEN>");

        // For Express Checkout Reference Transaction without Purchase.
        //ECGetBARequest getRequest = new ECGetBARequest("<TOKEN>");

        // Create the Tender.
        PayPalTender paypalTender = new PayPalTender(getRequest);

        // Create a transaction.
        AuthorizationTransaction Trans = new AuthorizationTransaction
                (User, Connection, null, paypalTender, PayflowUtility.getRequestId());

        // Submit the Transaction
        Response Resp = Trans.submitTransaction();

        // Display the transaction response parameters.
        if (Resp != null) {
            // Get the Transaction Response parameters.
            TransactionResponse TrxnResponse = Resp.getTransactionResponse();

            if (TrxnResponse != null) {
                System.out.println("RESULT = " + TrxnResponse.getResult());
                System.out.println("RESPMSG = " + TrxnResponse.getRespMsg());
                // The TOKEN is needed for the DODoEC Sample.
                System.out.println("TOKEN = " + Trans.getResponse().getEcSetResponse().getToken());
                System.out.println("CORRELATIONID = " + TrxnResponse.getCorrelationId());
                System.out.println("EMAIL = " + Trans.getResponse().getEcGetResponse().getEmail());
                System.out.println("PHONENUM = " + Trans.getResponse().getEcGetResponse().getPhoneNum());
                // The PAYERID is needed for the DODoEC Sample.
                System.out.println("PAYERID = " + Trans.getResponse().getEcGetResponse().getPayerId());
                System.out.println("PAYERSTATUS = " + Trans.getResponse().getEcGetResponse().getPayerStatus());
                // Express Checkout Transactions and Express Checkout Reference Transactions with Purchase
                // begin with EC, while Express Checkout Reference Transactions without Purchase begin with BA.
                // Reference Transactions without Purchase do not return shipping information.
                if (Trans.getResponse().getEcSetResponse().getToken() != null) {
                    if (Trans.getResponse().getEcSetResponse().getToken().startsWith("EC")) {
                        System.out.println();
                        System.out.println("Shipping Information:");
                        System.out.println("SHIPTOFIRSTNAME = " + Trans.getResponse().getEcGetResponse().getShipToFirstName());
                        System.out.println("SHIPTOLASTNAME = " + Trans.getResponse().getEcGetResponse().getShipToLastName());
                        System.out.println("SHIPTOSREET = " + Trans.getResponse().getEcGetResponse().getShipToStreet());
                        System.out.println("SHIPTOSTREET2 = " + Trans.getResponse().getEcGetResponse().getShipToStreet2());
                        System.out.println("SHIPTOCITY = " + Trans.getResponse().getEcGetResponse().getShipToCity());
                        System.out.println("SHIPTOSTATE = " + Trans.getResponse().getEcGetResponse().getShipToState());
                        System.out.println("SHIPTOZIP = " + Trans.getResponse().getEcGetResponse().getShipToZip());
                        System.out.println("SHIPTOCOUNTRY = " + Trans.getResponse().getEcGetResponse().getShipToCountry());
                        System.out.println("AVSADDR = " + Trans.getResponse().getTransactionResponse().getAvsAddr());
                    }
                    // ba_Flag is returned with Express Checkout Reference Transaction with Purchase.
                    // See the notes in DOSetEC regarding this feature.
                    if (Trans.getResponse().getEcGetResponse().getba_Flag() != null) {
                        System.out.println();
                        System.out.println("BA_FLAG = " + Trans.getResponse().getEcGetResponse().getba_Flag());
                        if (Trans.getResponse().getEcGetResponse().getba_Flag().equals("1")) {
                            System.out.println("Buyer Agreement was created.");
                        } else {
                            System.out.println("Buyer Agreement not was accepted.");
                        }
                    }
                }

                // If value is true, then the Request ID has not been changed and the original response
                // of the original transction is returned.
                System.out.println();
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
