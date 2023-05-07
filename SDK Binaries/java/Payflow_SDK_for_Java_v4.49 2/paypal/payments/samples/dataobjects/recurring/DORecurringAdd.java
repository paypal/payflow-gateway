package paypal.payments.samples.dataobjects.recurring;

import paypal.payflow.*;

// This class uses the Payflow SDK Data Objects to do a Recurring Add transaction.
// The request is sent as a Data Object and the response received is also a Data Object.

public class DORecurringAdd {
    public DORecurringAdd() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DORecurringAdd.java");
        System.out.println("------------------------------------------------------");

        // Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
        // For testing: 	 pilot-payflowpro.paypal.com
        // For production:   payflowpro.paypal.com
        // DO NOT use payflow.verisign.com or test-payflow.verisign.com!
        SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
        SDKProperties.setHostPort(443);
        SDKProperties.setTimeOut(45);

        // Logging is by default off. To turn logging on uncomment the following lines:
        SDKProperties.setLogFileName("payflow_java.log");
        SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
        SDKProperties.setMaxLogFileSize(100000);

        // Uncomment the lines below and set the proxy address and port, if a proxy has to be used.
        //SDKProperties.setProxyAddress("");
        //SDKProperties.setProxyPort(0);

        // Create the Data Objects.
        // Create the User data object with the required user details.
        UserInfo user = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

        // Create the Payflow Connection data object with the required connection details.
        PayflowConnectionData connection = new PayflowConnectionData();

        // Creating a profile where our customer is paying three installments of $25.75 with a shipping
        // charge of $9.95.  So, our first payment will be $25.75 + 9.95 with two more payments of $25.75 due.
        //
        // This is just one example of how you might create a new profile.

        // Create a new Invoice data object with the Amount, Billing Address etc. details.
        Invoice inv = new Invoice();

        // Set Amount.
        Currency amt = new Currency(new Double(25.75), "USD");
        inv.setAmt(amt);
        inv.setPoNum("PO12345");
        // inv.setInvNum("INV12345");

        // Set the Billing Address details.
        BillTo bill = new BillTo();
        bill.setStreet("123 Main St.");
        bill.setZip("12345");
        bill.setBillToCountry("GB");
        inv.setBillTo(bill);

        // Create a new Payment Device - Credit Card data object.
        // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
        CreditCard cc = new CreditCard("5105105105105100", "0109");
        // CVV2 is used for Optional Transaction (Sale or Authorization) Only.  It is not stored as part of the
        // profile, nor is it sent when payments are mad
        cc.setCvv2("123");

        // Create a new Tender - Card Tender data object.
        CardTender card = new CardTender(cc);
        ///////////////////////////////////////////////////////////////////

        RecurringInfo recurInfo = new RecurringInfo();
        // The date that the first payment will be processed.
        // This will be of the format mmddyyyy.
        recurInfo.setStart("07252008");
        recurInfo.setProfileName("Test_Profile_1");    // User provided Profile Name.
        // Specifies how often the payment occurs. All PAYPERIOD values must use
        // capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT /
        // QTER / SMYR / YEAR
        recurInfo.setPayPeriod("WEEK");
        recurInfo.setTerm(2);        // Number of payments

        // Peform an Optional Transaction.
        recurInfo.setOptionalTrx("S"); // S = Sale, A = Authorization
        // Set the amount if doing a "Sale" for the Optional Transaction.
        Currency oTrxAmt = new Currency(new Double(25.75 + 9.95), "USD");
        recurInfo.setOptionalTrxAmt(oTrxAmt);

        // Create a new Recurring Add Transaction.
        RecurringAddTransaction trans = new RecurringAddTransaction(
                user, connection, inv, card, recurInfo, PayflowUtility.getRequestId());

        // Use ORIGID to create a profile based on the details of another transaction. See Reference Transaction.
        //trans.setOrigId("<ORIGINAL_PNREF>");

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
                System.out.println("RESPMSG = " + trxnResponse.getRespMsg());
            }

            // Get the Recurring Response parameters.
            RecurringResponse recurResponse = resp.getRecurringResponse();

            if (recurResponse != null) {
                String ProfileMsg;
                if (trxnResponse.getResult() == 0) {
                    ProfileMsg = "Profile Created.";
                } else {
                    ProfileMsg = "Error, Profile Not Created.";
                }
                System.out.println("------------------------------------------------------");
                System.out.println(("Profile Status: " + ProfileMsg));
                System.out.println("Recurring Profile Reference (RPREF) = " + recurResponse.getRpRef());
                System.out.println("Recurring Profile ID (PROFILEID) = " + recurResponse.getProfileId());

                // Was an Optional Transaction processed?
                if (recurResponse.getTrxResult() != null) {
                    System.out.println("------------------------------------------------------");
                    System.out.println("Optional Transaction Details:");
                    System.out.println("Transaction PNREF (TRXPNREF) = " + recurResponse.getTrxPNRef());
                    System.out.println("Transaction Result (TRXRESULT) = " + recurResponse.getTrxResult());
                    System.out.println("Transaction Message (TRXRESPMSG) = " + recurResponse.getTrxRespMsg());
                    System.out.println(("Authorization (AUTHCODE) = " + trxnResponse.getAuthCode()));
                    System.out.println(("Security Code Match (CVV2MATCH) = " + trxnResponse.getCvv2Match()));
                    System.out.println(("Street Address Match (AVSADDR) = " + trxnResponse.getAvsAddr()));
                    System.out.println(("Streep Zip Match (AVSZIP) = " + trxnResponse.getAvsZip()));
                    System.out.println(("International Card (IAVS) = " + trxnResponse.getIavs()));

                    // Was this a duplicate transaction?
                    // If this value is true, you will probably receive a result code 19, Original transaction ID not found.
                    System.out.println("------------------------------------------------------");
                    System.out.println("Duplicate Response:");
                    String DupMsg;
                    if (trxnResponse.getDuplicate() == null) {
                        DupMsg = "Not a Duplicate Transaction";
                    } else {
                        DupMsg = "Duplicate Transaction";
                    }
                    System.out.println(("Duplicate Transaction (DUPLICATE) = " + DupMsg));

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
    }
}


