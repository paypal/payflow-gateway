Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Reference Transaction object to do a Sale transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' The Reference Transaction object should be used be used only in a remote scenario when the user
    ''' needs to do a reference transaction type which is not directly supported by the transaction objects 
    ''' provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
    ''' terms of specifying the transaction type (TRXTYPE).
    ''' For normal transactions, please use BaseTransaction class and for Recurring use RecurringTransaction 
    ''' base class.
    ''' <seealso cref="DOSale_Base"/>
    ''' <seealso cref="PayPal.Payments.Samples.VB.DataObjects.Recurring.DORecurring"/>
    ''' </summary>
    Public Class DOReference
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOReference.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.12))
            Inv.Amt = Amt

            ' Create a new Tender - Base Tender data object and set the Tender Type to "C".
            ' We do not pass any payment device
            Dim Tender As BaseTender = New BaseTender("C", Nothing)

            ' To modify the expiration date, you can either use the ExtendData object (see below) or you can create a CreditCard object
            ' without passing the credit card number.
            'Dim CC As CreditCard = New CreditCard(Nothing, "1215")
            'Dim Card As CardTender = New CardTender(CC)

            ' Create a new Reference Transaction.
            Dim Trans As ReferenceTransaction = New ReferenceTransaction("S", "<PNREF>", User, Connection, Inv, Tender, PayflowUtility.RequestId)
            ' If expiration date is changed too.
            'Dim Trans As ReferenceTransaction = New ReferenceTransaction("S", "<PNREF>", User, Connection, Inv, Card, Tender, PayflowUtility.RequestId)

            ' You can also change the expiration date of the new reference transaction, by passing the EXPDATE via the ExtendData object.
            'Dim ExpDate As ExtendData = New ExtendData("EXPDATE", "1211")
            'Trans.AddToExtendData(ExpDate)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
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