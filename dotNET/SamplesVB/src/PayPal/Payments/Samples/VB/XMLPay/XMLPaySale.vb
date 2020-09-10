Imports System
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Communication
Imports PayPal.Payments.DataObjects
Imports System.Threading

Namespace PayPal.Payments.Samples.VB.XMLPay
    ''' <summary>
    ''' This class uses the Payflow SDK API to do a simple Sale transaction.
    ''' The request is sent as a XML Pay string and the response received 
    ''' is also XML Pay string.
    ''' </summary>
    Public Class XMLPaySale
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: XMLPaySale.vb")
            Console.WriteLine("------------------------------------------------------")

            Thread.Sleep(27000)


            ' Sample Request. 
            ' Please replace [user], [vendor], [password] & [partner] with your merchant information.
            Dim Request As String = "<?xml version=""1.0""?><XMLPayRequest Timeout=""45"" version=""2.0""><RequestData><Partner>[partner]</Partner><Vendor>[vendor]</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='USD'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>201501</ExpDate></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>[user]</User><Password>[password]</Password></UserPass></RequestAuth></XMLPayRequest>"

            ' Create an instantce of PayflowNETAPI.
            Dim PayflowNETAPI As PayflowNETAPI = New PayflowNETAPI
            ' Can also pass the values in the constructor itself instead of using .config file.
            'PayflowNETAPI.SetParameters("pilot-payflowpro.paypal.com", 443, 30, "", 0, "", "", "enabled", "Debug", "c:\logs\PayflowSDK.log", "10240000", True)

            ' RequestId is a unique string that is required for each & every transaction. 
            ' The merchant can use her/his own algorithm to generate this unique request id or 
            ' use the SDK provided API to generate this as shown below (PayflowUtility.GetRequestId()).
            '
            ' NOTE: Review the comments in the DoSaleComplete example under BasicTransactions for
            ' more information on the Request ID.
            Dim Response As String = PayflowNETAPI.SubmitTransaction(Request, PayflowUtility.RequestId)

            ' To write the Response on to the console.
            Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest)
            Console.WriteLine(Environment.NewLine + "Response = " + Response)

            ' Following lines of code are optional. 
            ' Begin optional code for displaying SDK errors ...
            ' It is used to read any errors that might have occurred in the SDK.

            ' Get the transaction errors.
            Dim TransErrors As String = PayflowNETAPI.TransactionContext.ToString()
            If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
                Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
            End If

            Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(Response))
            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace
