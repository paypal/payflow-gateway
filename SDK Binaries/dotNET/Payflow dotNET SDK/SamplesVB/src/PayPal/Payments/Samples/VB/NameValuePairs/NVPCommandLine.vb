Imports System
Imports System.Configuration
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Communication
Imports PayPal.Payments.DataObjects

Namespace PayPal.Payments.Samples.VB.NameValuePairs
    ''' <summary>
    ''' This class uses the Payflow SDK API to do a simple Sale transaction from the Command Line.
    ''' The request is sent as a Name-Value pair string and the response received is also 
    ''' Name-Value Pair string.
    ''' </summary>
    Public Class NVPCommandLine
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: NVPCommandLine.vb")
            Console.WriteLine("------------------------------------------------------")

            If Args.Length < 4 Then
                Console.WriteLine(Environment.NewLine + "Incorrect number of arguments. Usage:" + Environment.NewLine + "SamplesVB <hostAddress> <hostPort> <parmList> <timeOut> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>")
                Console.WriteLine(Environment.NewLine + "Example transaction:" + Environment.NewLine + "SamplesVB pilot-payflowpro.paypal.com 443 ""USER=<user>&TRXTYPE[1]=A&VENDOR=<vendor>&AMT[5]=25.00&PWD=<password>&PARTNER=<partner>&TENDER[1]=C&ACCT[16]=5100000000000008&EXPDATE[4]=0115"" 45")
                Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
                Console.ReadLine()
                System.Environment.Exit(-1)
            End If

            Dim PayflowNETAPI As PayflowNETAPI
            If Args.Length = 4 Then
                PayflowNETAPI = New PayflowNETAPI(Args(0), System.Convert.ToInt32(Args(1)), System.Convert.ToInt32(Args(3)))
            Else
                PayflowNETAPI = New PayflowNETAPI(Args(0), System.Convert.ToInt32(Args(1)), System.Convert.ToInt32(Args(3)), Args(4), System.Convert.ToInt32(Args(5)), Args(6), Args(7))
            End If

            Dim ResponseStr As String = PayflowNETAPI.SubmitTransaction(Args(2), PayflowUtility.RequestId)

            ' To write the Response on to the console.
            Console.WriteLine(Environment.NewLine + "Request = " + PayflowNETAPI.TransactionRequest)
            Console.WriteLine(Environment.NewLine + "Response = " + ResponseStr)

            ' Following lines of code are optional. 
            ' Begin optional code for displaying SDK errors ...
            ' It is used to read any errors that might have occured in the SDK.

            ' Get the transaction errors.
            Dim TransErrors As String = PayflowNETAPI.TransactionContext.ToString()
            If (Not TransErrors Is Nothing And TransErrors.Length > 0) Then
                Console.WriteLine(Environment.NewLine + "Transaction Errors from SDK = " + TransErrors)
            End If

            Console.WriteLine(Environment.NewLine + "Status: " + PayflowUtility.GetStatus(ResponseStr))
            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace