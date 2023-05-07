Imports Microsoft.VisualBasic
Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Recurring
    ''' <summary>
    ''' This class uses the Payflow SDK Recurring Transaction object to do a simple Recurring Add transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' The Recurring Transaction object should be used be used only in a remote scenario when the user
    ''' needs to do a recurring transaction type which is not directly supported by the transaction objects 
    ''' provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
    ''' terms of specifying the transaction type (TRXTYPE).
    ''' For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction 
    ''' base class.
    ''' <seealso cref="PayPal.Payments.Samples.VB.DataObjects.Misc.DOSale_Base"/>
    ''' <seealso cref="PayPal.Payments.Samples.VB.DataObjects.Misc.DOReference"/>
    ''' </summary>
    Public Class DORecurring
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DORecurring.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object details.
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
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0112")

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)

            Dim RecurInfo As RecurringInfo = New RecurringInfo
            ' The date that the first payment will be processed. 
            ' This will be of the format mmddyyyy.
            RecurInfo.Start = "01012012"
            RecurInfo.ProfileName = "PayPal"
            ' Specifies how often the payment occurs. All PAYPERIOD values must use 
            ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT / 
            ' QTER / SMYR / YEAR
            RecurInfo.PayPeriod = "WEEK"
            '/////////////////////////////////////////////////////////////////

            ' Create a new Recurring Transaction.
            Dim Trans As RecurringTransaction = New RecurringTransaction("A", RecurInfo, User, Connection, Inv, Card, PayflowUtility.RequestId)

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