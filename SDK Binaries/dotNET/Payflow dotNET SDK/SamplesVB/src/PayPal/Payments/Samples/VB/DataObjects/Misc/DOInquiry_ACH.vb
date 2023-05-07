Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do an ACH Inquiry transaction.
    '''
    ''' You perform an inquiry using a reference to an original transaction that you specified for the original
    ''' transaction.
    ''' 
    ''' Transaction results (especially values for declines and error conditions) returned by each PayPal-supported
    ''' processor vary in detail level and in format. The Payflow Pro Verbosity parameter enables you to control
    ''' the kind and level of information you want returned.  By default, Verbosity is set to LOW.
    ''' A LOW setting causes PayPal to normalize the transaction result values. Normalizing the values limits
    ''' them to a standardized set of values and simplifies the process of integrating Payflow Pro.
    '''   
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOInquiry_ACH
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOInquiry_ACH.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Inquiry Transaction.
            ' Replace <PNREF> with a previous transaction ID that you processed on your account.
            Dim Trans As InquiryTransaction = New InquiryTransaction("<PNREF>", User, Connection, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
                'Display the transaction response parameters. Refer to the Payflow Pro Developer's Guide for explanations.
                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("--------------------------------------------")
                    Console.WriteLine("Original Response Data")
                    Console.WriteLine("--------------------------------------------")
                    Console.WriteLine("ORIGRESULT = " + TrxnResponse.OrigResult)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("STATUS = " + TrxnResponse.Status)
                    Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
                End If

                ' Display the response.
                Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

                ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                Dim TransCtx As Context = Resp.TransactionContext
                If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                    Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                End If
            End If

            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace