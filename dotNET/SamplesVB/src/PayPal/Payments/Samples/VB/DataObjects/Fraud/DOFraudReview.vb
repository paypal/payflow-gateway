Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Fraud
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to Approve a Fraudulent transaction.
    ''' </summary>
    Public Class DOFraudReview
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOFraudReview.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData
            '/////////////////////////////////////////////////////////////////

            ' Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
            Dim Trans As FraudReviewTransaction = New FraudReviewTransaction("B10T6D55539B", "RMS_APPROVE", User, Connection, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
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