package paypal.payments.samples.xmlpay;

import paypal.payflow.*;
import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class XMLPaySale {

	public static void main(String args[]) {
		System.out.println("------------------------------------------------------");
		System.out.println("Executing Sample from File: XMLPaySale.java");
		System.out.println("------------------------------------------------------");

		// Payflow Pro Host Name. This is the host name for the PayPal Payment Gateway.
		// For testing: pilot-payflowpro.paypal.com
		// For production: payflowpro.paypal.com
		// DO NOT use payflow.verisign.com or test-payflow.verisign.com!
		SDKProperties.setHostAddress("pilot-payflowpro.paypal.com");
		SDKProperties.setHostPort(443);
		SDKProperties.setTimeOut(45);

		// Logging is by default off. To turn logging on uncomment the following lines:
		// SDKProperties.setLogFileName("payflow_java.log");
		// SDKProperties.setLoggingLevel(PayflowConstants.SEVERITY_DEBUG);
		// SDKProperties.setMaxLogFileSize(100000);
		// Log Stack Traces (boolean)
		// SDKProperties.setStackTraceOn(true);

		// Uncomment the lines below and set the proxy address and port, if a proxy has
		// to be used.
		// SDKProperties.setProxyAddress("");
		// SDKProperties.setProxyPort(0);

		// Create an instance of PayflowAPI.
		PayflowAPI pa = new PayflowAPI();

		// Credentials: env vars take priority; payflow.properties is the fallback.
		String mUser     = System.getenv("PAYFLOW_USER");
		String mVendor   = System.getenv("PAYFLOW_VENDOR");
		String mPartner  = System.getenv("PAYFLOW_PARTNER");
		String mPassword = System.getenv("PAYFLOW_PASSWORD");
		if (mUser == null || mVendor == null || mPartner == null || mPassword == null) {
			Properties creds = new Properties();
			try (FileInputStream fis = new FileInputStream("payflow.properties")) {
				creds.load(fis);
			} catch (IOException e) {
				System.err.println("ERROR: Set PAYFLOW_USER/VENDOR/PARTNER/PASSWORD env vars, or create payflow.properties.");
				return;
			}
			if (mUser     == null) mUser     = creds.getProperty("PayflowUser",     "");
			if (mVendor   == null) mVendor   = creds.getProperty("PayflowVendor",   "");
			if (mPartner  == null) mPartner  = creds.getProperty("PayflowPartner",  "");
			if (mPassword == null) mPassword = creds.getProperty("PayflowPassword", "");
		}

		// Sample Request.
		String request = "<?xml version=\"1.0\"?><XMLPayRequest Timeout=\"45\" version=\"2.0\"><RequestData><Partner>" + mPartner + "</Partner><Vendor>" + mVendor + "</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='USD'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>203001</ExpDate></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>" + mUser + "</User><Password>" + mPassword + "</Password></UserPass></RequestAuth></XMLPayRequest>";
		// RequestId is a unique string that is required for each & every transaction.
		// The merchant can use her/his own algorithm to generate this unique request id
		// or
		// use the SDK provided API to generate this as shown below
		// (PayflowAPI.generateRequestId).
		// NOTE: Review the comments in the DoSaleComplete example under
		// BasicTransactions for
		// more information on the Request ID.
		String requestId = pa.generateRequestId();
		// submit the transaction
		String response = pa.submitTransaction(request, requestId);

		// Create a new Client Information data object.
		ClientInfo clInfo = new ClientInfo();

		// Set the ClientInfo object of the PayflowAPI.
		pa.setClientInfo(clInfo);

		System.out.println("Transaction Request :\n-------------------- \n" + pa.getTransactionRequest());
		System.out.println("Transaction Response :\n-------------------- \n" + response);

		// Following lines of code are optional.
		// Begin optional code for displaying SDK errors ...
		// It is used to read any errors that might have occured in the SDK.
		// Get the transaction errors.

		String transErrors = pa.getTransactionContext().toString();
		if (transErrors != null && transErrors.length() > 0) {
			System.out.println("Transaction Errors from SDK = \n" + transErrors);
		}

	}
}