Imports Microsoft.VisualBasic
Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Recurring
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a Recurring Modify transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DORecurringModify
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DORecurringModify.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")
           
            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            Dim RecurInfo As RecurringInfo = New RecurringInfo
            RecurInfo.OrigProfileId = "<PROFILE_ID>"  ' RT0000001350
            RecurInfo.ProfileName = "<PROFILE_NAME>"  ' Test_Profile 

            ' Create a new Invoice data object with the Amount, Billing Address etc. details for the data you 
            ' want to change.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(10.0, "USD")
            Inv.Amt = Amt
            'Inv.PoNum = "PO12345"
            'Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            'Bill.Street = "123 Main St."
            'Bill.Zip = "12345"
            'Bill.Email = "abc@abc.com"
            'Bill.PhoneNum = "123-123-1234"
            Inv.BillTo = Bill

            ' If you want to modify the credit card information, create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0112")

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)

            'If NO card details available and want to modify only information like E-Mail or Phone Number, use following:
            'Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User, Connection, RecurInfo, Inv, Nothing, PayflowUtility.RequestId)

            'If you want to modify the RecurringInfo information only, use the following:
            'Dim Trans as RecurringModifyTransaction  = New RecurringModifyTransaction(User, Connection, RecurInfo,PayflowUtility.RequestId))

            ' Create a new Recurring Modify Transaction.
            Dim Trans As RecurringModifyTransaction = New RecurringModifyTransaction(User, Connection, RecurInfo, Inv, Card, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                End If

                ' Get the Recurring Response parameters.
                Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
                If Not RecurResponse Is Nothing Then
                    Console.WriteLine("RPREF = " + RecurResponse.RPRef)
                    Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
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