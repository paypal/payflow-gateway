package paypal.payments.samples.dataobjects.misc;

import paypal.payflow.*;

/// <summary>
/// This class uses the Payflow SDK Data Objects to do a simple ACH - Sale transaction.
/// The request is sent as a Data Object and the response received is also a Data Object.
///
/// Refer to the Payflow ACH Payment Service Guide for more information.

/// </summary>
public class DOSale_ACH {
    public DOSale_ACH() {
    }

    public static void main(String args[]) {
        System.out.println("------------------------------------------------------");
        System.out.println("Executing Sample from File: DOSale_ACH.java");
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

        // Create a new Payment Device - Bank Account data object.
        // The input parameters are Account No. and ABA.
        BankAcct ba = new BankAcct("1111111111", "111111118");
        // The Account Type can be "C" for Checking and "S" for Saving.
        ba.setAcctType("C");
        ba.setName("John Doe");

        // Create a new Tender - ACH Tender data object.
        ACHTender ach = new ACHTender(ba);
        ach.setAuthType("PPD");
        //ach.setChkNum("1233");

        // Create a new ach - Sale Transaction.
        SaleTransaction trans = new SaleTransaction(
                user, connection, inv, ach, PayflowUtility.getRequestId());

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
