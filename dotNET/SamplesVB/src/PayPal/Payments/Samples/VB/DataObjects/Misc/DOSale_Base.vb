Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Base Transaction object to do a simple Sale transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' The Base Transaction object should be used be used only in a remote scenario when the user
    ''' needs to do a transaction type which is not directly supported by the transaction objects 
    ''' provided by the SDK. Doing a transaction in this fashion enables the user to have flexibility in 
    ''' terms of specifying the transaction type (TRXTYPE).
    ''' For Reference transactions, please use ReferenceTransaction class and for Recurring use 
    ''' RecurringTransaction base class.
    ''' <seealso cref="DOReference"/>
    ''' <seealso cref="PayPal.Payments.Samples.VB.DataObjects.Recurring.DORecurring"/>
    ''' </summary>
    Public Class DOSale_Base
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSale_Base.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' Values of connection details can also be passed in the constructor of 
            ' PayflowConnectionData. This will override the values passed in the App config file.
            ' Example values passed below are as follows:
            ' Payflow Pro Host address : pilot-payflowpro.paypal.com 
            ' Payflow Pro Host Port : 443
            ' Timeout : 45 ( in seconds )
            Dim Connection As PayflowConnectionData = New PayflowConnectionData("pilot-payflowpro.paypal.com", 443, 45)

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.1256))
            Inv.Amt = Amt
            ' Truncate the Amount value using the truncate feature of 
            ' the Currency Data Object.
            ' Note: Currency Data Object also has the Round feature
            ' which will round the amount value to desired number of decimal
            ' digits ( default 2 ). However, round and truncate cannot be used 
            ' at the same time. You can set one of round or truncate true.
            Inv.Amt.Truncate = True
            ' Set the truncation decimal digit to 2.
            Inv.Amt.NoOfDecimalDigits = 2

            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.BillToStreet = "123 Main St."
            Bill.BillToZip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0115")
            CC.Cvv2 = "123"

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)
            '/////////////////////////////////////////////////////////////////

            ' Create a new Base Transaction.
            Dim Trans As BaseTransaction = New BaseTransaction("S", User, Connection, Inv, Card, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                    Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match)
                End If

                ' Get the Fraud Response parameters.
                Dim FraudResp As FraudResponse = Resp.FraudResponse
                If Not FraudResp Is Nothing Then
                    Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
                    Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
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