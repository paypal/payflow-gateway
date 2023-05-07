Imports System
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Communication
Imports PayPal.Payments.DataObjects


Namespace PayPal.Payments.Samples.VB.NameValuePairs
    ''' <summary>
    ''' This class uses the Payflow SDK API to do a simple Sale transaction.
    ''' The request is sent as a Name-Value pair string and the response received 
    ''' is also Name-Value Pair string.
    ''' </summary>
    Public Class NVPSale
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: NVPSale.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Sample Request. 
            ' Please replace <user>, <vendor>, <password> & <partner> with your merchant information.
            Dim Request As String = "TRXTYPE=S&ACCT=5105105105105100&EXPDATE=0115&TENDER=C&INVNUM=INV12345&AMT=25.12&PONUM=PO12345&STREET=123 Main St.&ZIP=12345&USER=<user>&VENDOR=<vendor>&PARTNER=<partner>&PWD=<password>"
            ' Create an instantce of PayflowNETAPI.
            Dim PayflowNETAPI As PayflowNETAPI = New PayflowNETAPI
            ' Can also pass the values in the constructor itself instead of using .config file.
            'PayflowNETAPI.SetParameters("pilot-payflowpro.paypal.com", 443, 45, "", 0, "", "", "enabled", "1", "payflow.log", "10240000", False)

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
            ' It is used to read any errors that might have occured in the SDK.
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