package paypal.payments.samples.dataobjects.misc;

import paypal.payflow.*;

// This class uses the Payflow SDK Base Transaction object to do a simple Sale transaction.
// The request is sent as a Data Object and the response received is also a Data Object.
// The Base Transaction object should be used be used only in a remote scenario when the user
// needs to do a transaction type which is not directly supported by the transaction objects
// provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in
// terms of specifying the transaction type (TRXTYPE).
// For Reference transactions, please use ReferenceTransaction class and for Recurring use
// RecurringTransaction base class.

public class DOSale_Base {
    public DOSale_Base() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOSale_Base.java");
        System.out.println("------------------------------------------------------");

        // Logging is by default off. To turn logging on uncomment the following lines:
        //SDKProperties.setLogFileName("payflow_java.log");
        //SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        //SDKProperties.setMaxLogFileSize(100000);

        // Create the Data Objects.
        // Create the User data object with the required user details.
        UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow Connection data object with the required connection details.
        // Values of connection details can also be passed in the constructor of
        // PayflowConnectionData. This will override the values passed in the App config file.
        // Example values passed below are as follows:
        // Payflow Pro Host address : pilot-payflowpro.paypal.com
        // Payflow Pro Host Port : 443
        // Timeout : 45 ( in seconds )

        PayflowConnectionData connection = new PayflowConnectionData("pilot-payflowpro.paypal.com", 443, 45);

        // Create a new Invoice data object with the Amount, Billing Address etc. details.
        Invoice inv = new Invoice();

        // Set Amount.
        Currency amt = new Currency(new Double(25.1256));
        inv.setAmt(amt);
        // Truncate the Amount value using the truncate feature of
        // the Currency Data Object.
        // Note: Currency Data Object also has the Round feature
        // which will round the amount value to desired number of decimal
        // digits ( default 2 ). However, round and truncate cannot be used
        // at the same time. You can set one of round or truncate true.
        inv.getAmt().setTruncate(true);
        // Set the truncation decimal digit to 2.
        inv.getAmt().setNoOfDecimalDigits(2);

        inv.setPoNum("PO12345");
        inv.setInvNum("INV12345");

        // Set the Billing Address details.
        BillTo bill = new BillTo();
        bill.setBillToStreet("123 Main St.");
        bill.setBillToZip("12345");
        inv.setBillTo(bill);

        // Create a new Payment Device - Credit Card data object.
        // The input parameters are Credit Card No. and Expiry Date for the Credit Card.
        CreditCard cc = new CreditCard("5105105105105100", "0109");
        cc.setCvv2("123");

        // Create a new Tender - Card Tender data object.
        CardTender card = new CardTender(cc);
        ///////////////////////////////////////////////////////////////////

        // Create a new Base Transaction.
        BaseTransaction trans = new BaseTransaction("S",
                user, connection, inv, card, PayflowUtility.getRequestId());

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
