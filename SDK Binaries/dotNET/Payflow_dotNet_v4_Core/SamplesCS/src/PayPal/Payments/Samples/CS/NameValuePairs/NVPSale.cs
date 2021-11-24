using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Communication;
using PayPal.Payments.DataObjects;
using System.Threading;

namespace PayPal.Payments.Samples.CS.NameValuePairs
{
    /// <summary>
    /// This class uses the Payflow SDK API to do a simple Sale transaction.
    /// The request is sent as a Name-Value pair string & the response received 
    /// is also Name-Value Pair string.
    /// </summary>
    public class NVPSale
    {
        public NVPSale()
        {
        }

        public static void Main(string[] Args)
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Executing Sample from File: NVPSale.cs");
            Console.WriteLine("------------------------------------------------------");

            // Ok, what we'll do here is three transactions, the first will succeed, the second we'll pretend we never got a response and attempt again and the third will succeed.
            String RequestID;
            String Response;

            for (int i = 1; i <= 3; i++)
            {
                // Set the Request ID
                RequestID = PayflowUtility.RequestId;
                Console.WriteLine(Environment.NewLine + "RequestID = " + RequestID);

                // Please replace <user>, <vendor>, <password> & <partner> with your merchant information.
                String Request = "USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>&TRXTYPE=S&ACCT=5105105105105100&EXPDATE=0125&CVV2=123&TENDER=C&INVNUM=INV12345&AMT=25.12&PONUM=PO12345&STREET=123 Main St.&ZIP=12345";

                // Create an instantce of PayflowNETAPI.
                PayflowNETAPI PayflowNETAPI = new PayflowNETAPI();
                // Can also pass the values in the constructor itself instead of using .config file.
                PayflowNETAPI.SetParameters("pilot-payflowpro.paypal.com", 443, 45, "", 0, "", "", "enabled", "0", "C:\\logs\\payflow.log", "10240000", false);

                // Try to submit the transaction up to 3 times with 5 second delay.  This can be used
                // in case of network issues.  The idea here is since you are posting via HTTPS behind the scenes there
                // could be general network issues, so try a few times before you tell customer there is an issue.
                int trxCount = 1;
                bool RespRecd = false;
                while (trxCount <= 3 && !RespRecd)
                {
                    // Submit transaction and get the Transaction Response parameters.
                        Response = PayflowNETAPI.SubmitTransaction(Request, RequestID);
                    
                    // Get Status and RESULT code.
                    String Status = PayflowUtility.GetStatus(Response);
                    Int32 Result = Convert.ToInt32(PayflowUtility.LocateValueForName(Response, "RESULT", false));
                    if (i == 2 )
                    {
                        // Let's pretend we get a -12 here on the second transaction, first attempt.  -12 = timeout - transaction received by PayPal but no response. 
                        // This will trigger an reattempt up to 3 times using the same RequestID.  On second attempt, we'll trigger good response.
                        Result = -12;
                        Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest);
                        Console.WriteLine(Environment.NewLine + "We pretend to generate a -12 error!");
                        Console.WriteLine(Environment.NewLine + "Response = " + Response);
                    }
                    // Display the transaction response parameters.
                    if (Response != null && Result >= 0)
                    {
                        RespRecd = true;  // Got a response.
                                          // To write the Response on to the console.
                        Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest);
                        Console.WriteLine(Environment.NewLine + "Response = " + Response);
                        Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(Response));
                        Console.WriteLine("Duplicate Response:");
                        string DupMsg;
                        if (PayflowUtility.LocateValueForName(Response, "DUPLICATE", false) != "")
                        {
                            DupMsg = "Duplicate Transaction";
                        }
                        else
                        {
                            DupMsg = "Not a Duplicate Transaction";
                        }
                        Console.WriteLine(("Duplicate Transaction (DUPLICATE) = " + DupMsg));
                    }
                    else
                    {
                        Thread.Sleep(5000); // let's wait 5 seconds to see if this is a temporary network issue.
                        Console.WriteLine("Retry #: " + trxCount.ToString());
                        trxCount++;
                        i = i + 1;
                        Console.WriteLine(Environment.NewLine + "RequestID = " + RequestID);
                    }
                }
                Console.WriteLine("------------------------------------------------------");
                if (!RespRecd)
                {
                    Console.WriteLine("There is a problem obtaining an authorization for your order.");
                    Console.WriteLine("Please contact Customer Support.");
                    Console.WriteLine("------------------------------------------------------");
                }
            }
            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...");
            Console.ReadLine();
        }
    }
}
