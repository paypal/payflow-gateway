Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Sale transaction.
    ''' This class also shows how to add/remove custom client information header in a transaction
    ''' and commit operations.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOClientInfo
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOClientInfo.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the PFPro Connection data object with the required connection details.
            ' The PFPRO_HOST and CERT_PATH are properties defined in App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.12))
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0109")
            CC.Cvv2 = "123"

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)
            '/////////////////////////////////////////////////////////////////

            ' Create a new Sale Transaction.
            Dim Trans As SaleTransaction = New SaleTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId)

            ' Create a new Client Information data object.
            Dim ClInfo As ClientInfo = New ClientInfo
            
            ' Set the ClientInfo object of the transaction object.
            Trans.ClientInfo = ClInfo

            ' Add a new custom client informartion header 
            ' to the transaction.
            Trans.AddTransHeader("X-VPS-VIT-WRAPPER-TYPE", "VRSN-VB-SAMPLE")

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            Dim CommitResp As CommitResponse = Nothing

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                ' Re-initialize the client info object.
                ClInfo = New ClientInfo
                
                ' Set the ClientInfo object of the transaction object.
                Trans.ClientInfo = ClInfo

                ' Add a new custom client informartion header to the commit.
                Trans.AddCommitHeader("X-VPS-VIT-WRAPPER-TYPE", "VRSN-VB-SAMPLE")

                ' Submit the Commit transaction.
                CommitResp = Trans.SubmitCommitTransaction()

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                End If

                ' Get the Fraud Response parameters.
                Dim FraudResp As FraudResponse = Resp.FraudResponse
                If Not FraudResp Is Nothing Then
                    Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
                    Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
                End If

                ' Display the commit transaction response parameters.
                If Not CommitResp Is Nothing Then
                    Console.WriteLine(Environment.NewLine + "COMMIT RESULT = " + CommitResp.Result)
                    Console.WriteLine("COMMIT RESPMSG = " + CommitResp.RespMsg)
                End If

                ' Display the response.
                Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

                ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                Dim TransCtx As Context = Resp.TransactionContext
                If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                    Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                End If

                ' Get the Commit Context and check for any contained SDK specific errors (optional code).
                If Not CommitResp Is Nothing Then
                    ' Get the Commit Transaction Context and check for any contained SDK specific errors (optional code).
                    Dim CommitCtx As Context = CommitResp.TransactionContext
                    If (Not CommitCtx Is Nothing) And (CommitCtx.getErrorCount() > 0) Then
                        Console.WriteLine(Environment.NewLine + "Commit Errors = " + CommitCtx.ToString())
                    End If
                End If
            End If

            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace