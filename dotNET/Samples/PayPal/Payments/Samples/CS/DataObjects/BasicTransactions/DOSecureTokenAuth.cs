using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Transactions;

namespace PayPal.Payments.Samples.CS.DataObjects.BasicTransactions
{
    /// <summary>
    /// This class uses the Payflow SDK Data Objects to do create a Secure Token used with the 
    /// hosted checkout page.
    /// The request is sent as a Data Object and the response received is also a Data Object.
    /// </summary>
    public class DOSecureTokenAuth
    {
        public DOSecureTokenAuth()
        {
        }

        public static void Main(string[] Args)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: DOSecureTokenAuth.cs");
            Console.WriteLine("------------------------------------------------------");

            // Create the Data Objects.
            // Create the User data object with the required user details.
            UserInfo User = new UserInfo("<user>", "<vendor>", "<partner>", "<password>");

            // Create the Payflow  Connection data object with the required connection details.
            PayflowConnectionData Connection = new PayflowConnectionData();

            // Create a new Invoice data object with the Amount, Billing Address etc. details.
            Invoice Inv = new Invoice();

            // Set Amount.  The amount cannot be changed once submitted.
            Currency Amt = new Currency(new decimal(10.00), "USD");
            Inv.Amt = Amt;
            Inv.InvNum = "INV12345";

            // Set the Billing Address details.  You can also send the shipping information.  Both the Billing
            // and Shipping information can be changed if the functionality is allowed in the Configuration section
            // of Manager.  No other information submitted using a secure token call can be changed.
            BillTo Bill = new BillTo();
            Bill.BillToFirstName = "Sam";
            Bill.BillToLastName = "Smith";
            Bill.BillToStreet = "123 Main St.";
            Bill.BillToCity = "Any Town";
            Bill.BillToState = "CA";
            Bill.BillToZip = "12345";
            Bill.BillToPhone = "408-123-1234";
            Bill.BillToEmail = "test@myemail.com";
            Bill.BillToCountry = "840";
            Inv.BillTo = Bill;

            // Create a new Payment Device - Credit Card data object.
            // The input parameters are Credit Card Number and Expiration Date of the Credit Card.
            //CreditCard CC = new CreditCard("5105105105105100", "0110");
            //CC.Cvv2 = "023";

            // Create a new Tender - Card Tender data object.
            //CardTender Card = new CardTender(CC);
            ///////////////////////////////////////////////////////////////////

            // Since we are using the hosted payment pages, you will not be sending the credit card data with the 
            // Secure Token Request.  You just send all other 'sensitive' data within this request and when you
            // call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
            // and the SECURETOKENID that was created and used in the request.
            //
            // Create a new Secure Token Authorization Transaction.  Even though this example is performing
            // an authorization, you can create a secure token using SaleTransaction too.  Only Authorization and Sale
            // type transactions are permitted.
            //
            // Remember, all data submitted as part of the Secure Token call cannot be modified at a later time.  The only exception
            // is the billing and shipping information if these items are selection in the Setup section in PayPal Manager.
            AuthorizationTransaction Trans = new AuthorizationTransaction(User, Connection, Inv, null, PayflowUtility.RequestId);

            // Set VERBOSITY to High
            Trans.Verbosity = "High";

            // Set the flag to create a Secure Token.
            Trans.CreateSecureToken = "Y";

            // The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to 
            // generate a random id, but any means to create an id can be used.
            Trans.SecureTokenId = PayflowUtility.RequestId;

            // Set the extended data value.
            //ExtendData ExtData = new ExtendData("SILENTTRAN", "True");
            // Add extended data to transaction.
            //Trans.AddToExtendData(ExtData);

            // IMPORTANT NOTE:
            // 
            // Remember, the Secure Token can only be used once.  Once it is redeemed by a valid transaction it cannot be used again and you will 
            // need to generate a new token.  Also, the token has a life time of 30 minutes.

            // Submit the Transaction
            Response Resp = Trans.SubmitTransaction();
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt") + " : " + Trans.Response.ResponseString);
            Console.WriteLine("Press Enter to Exit ...");
            Console.ReadLine();
        }
    }
}
