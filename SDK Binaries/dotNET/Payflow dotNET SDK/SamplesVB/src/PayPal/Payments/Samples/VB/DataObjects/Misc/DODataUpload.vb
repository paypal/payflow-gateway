Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' To assist is providing a PCI compliant solution, PayPal now allows a you to upload your
    ''' existing credit card data using a new transaction type.  As the data is uploaded, a 
    ''' transaction id (PNREF) will be generated that can be stored locally to perform a Reference 
    ''' Transaction (tokenization).  This allows you to remove all credit card data from your 
    ''' local servers.  For more information regarding Reference Transactions review the section in 
    ''' the Payflow Developer's Guide.
    ''' 
    ''' The transaction type value is "L" which allows the credit card data to be sent and stored 
    ''' without being sent to the banks for processing.  You must send at miminum the following 
    ''' items: TRXTYPE, TENDER, ACCT and EXPDATE.
    ''' 
    '''  As you can see, you can send in Billing and Shipping information to be stored, but you must 
    '''  not include the AMT field.  If AMT is passed you will receive a RESULT=4, RESPMSG=Invalid Amount error.  
    ''' 
    ''' IMPORTANT:  The credit card data sent for storage is not verified in any way as it is not 
    ''' sent to the banks for processing.  To validate a transaction, you would do an account 
    ''' verification; also known as a, zero dollar authorization, type transaction. 
    ''' 
    ''' NOTE:  This is processor dependent and not all processors support this feature.
    ''' 
    ''' For Reference transactions, please use ReferenceTransaction class and for Recurring use 
    ''' RecurringTransaction base class.
    ''' <seealso cref="DOReference"/>
    ''' <seealso cref="PayPal.Payments.Samples.VB.DataObjects.Recurring.DORecurring"/>
    ''' </summary>

    Public Class DODataUpload
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DODataUpload.vb")
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

            ' Remember, we do not send in an amount.

            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0115")

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)
            '/////////////////////////////////////////////////////////////////

            ' Create a new Base Transaction.
            Dim Trans As BaseTransaction = New BaseTransaction("L", User, Connection, Inv, Card, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("TRANSTIME = " + TrxnResponse.TransTime)
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