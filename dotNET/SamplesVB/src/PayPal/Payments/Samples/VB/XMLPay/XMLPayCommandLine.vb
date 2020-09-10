Imports System
Imports System.Configuration
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Communication
Imports PayPal.Payments.DataObjects

Namespace PayPal.Payments.Samples.VB.XMLPay
    ''' <summary>
    ''' This class uses the Payflow SDK API to do a simple Sale transaction 
    ''' from the Command Line using XML Pay parameter list.
    ''' The request is sent as a XML Pay string and the response received 
    ''' is also XML Pay string.
    ''' </summary>
    Public Class XMLPayCommandLine
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: XMLPayCommandLine.vb")
            Console.WriteLine("------------------------------------------------------")

            If Args.Length < 4 Then
                Console.WriteLine(Environment.NewLine + "Incorrect number of arguments. Usage:" + Environment.NewLine + "SamplesVB <hostAddress> <hostPort> <xml-parmList> <timeout> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>")
                Console.WriteLine(Environment.NewLine + "Example transaction:" + Environment.NewLine + "SamplesVB pilot-payflowpro.paypal.com 443 ""<?xml version='1.0'?><XMLPayRequest Timeout='45' version='2.0'><RequestData><Partner>[partner]</Partner><Vendor>[vendor]</Vendor><Transactions><Transaction><Sale><PayData><Invoice><TotalAmt Currency='USD'>25.12</TotalAmt><InvNum>INV12345</InvNum><BillTo><PONum>PO12345</PONum><Address><Street>123 Main St.</Street><Zip>12345</Zip></Address></BillTo></Invoice><Tender><Card><CardNum>5105105105105100</CardNum><ExpDate>201501</ExpDate></Card></Tender></PayData></Sale></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>[user]</User><Password>[password]</Password></UserPass></RequestAuth></XMLPayRequest>"" 45")
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
            ' It is used to read any errors that might have occurred in the SDK.

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