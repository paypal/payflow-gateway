Imports System
Imports System.Configuration
Imports System.IO
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.Communication
Imports PayPal.Payments.DataObjects

Namespace PayPal.Payments.Samples.VB.XMLPay
    ''' <summary>
    ''' This class uses the Payflow SDK API to run XML Pay transactions by reading the files.
    ''' The request is sent as a XMLPay string and the response received 
    ''' is also XMLPay string.
    ''' </summary>
    Public Class XMLPayCommandLine_File
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: XMLPayCommandLine_File.vb")
            Console.WriteLine("------------------------------------------------------")

            If Args.Length < 4 Then
                Console.WriteLine(Environment.NewLine + "Incorrect number of arguments. Usage:" + Environment.NewLine + "SamplesVB <hostAddress> <hostPort> <xml filename> <timeout> <proxyAddress> <proxyPort> <proxyLogon> <proxyPassword>")
                Console.WriteLine(Environment.NewLine + "Example transaction:" + Environment.NewLine + "SamplesVB pilot-payflowpro.paypal.com 443 ""C:" + System.IO.Path.DirectorySeparatorChar + "Sale.xml"" 45")
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

            Dim XmlFile As String = ReadFile(Args(2))
            If Not XmlFile Is Nothing Then

                Dim ResponseStr As String = PayflowNETAPI.SubmitTransaction(XmlFile, PayflowUtility.RequestId)
                
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
            Else
                Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
                Console.ReadLine()
            End If
        End Sub

        ' Read the xml file into a string.
        Private Shared Function ReadFile(ByVal FilePath As String) As String
            Dim FileString As String = Nothing
            If File.Exists(FilePath) Then
                Dim sr As StreamReader = New StreamReader(New FileStream(FilePath, FileMode.Open, FileAccess.Read))
                FileString = sr.ReadToEnd()
                sr.Close()
            Else
                Console.WriteLine("<XMLPayResponse><ResponseData><Vendor></Vendor><Partner></Partner><TransactionResults><Result>-100</Result><Message>" + "Failed to open XML file at location " + FilePath + "</Message><PNRef>V00000000000</PNRef>" + "<AuthCode>000000</AuthCode><HostCode>0</HostCode></TransactionResult></TransactionResults></ResponseData></XMLPayResponse>")
            End If
            Return FileString
        End Function
    End Class
End Namespace