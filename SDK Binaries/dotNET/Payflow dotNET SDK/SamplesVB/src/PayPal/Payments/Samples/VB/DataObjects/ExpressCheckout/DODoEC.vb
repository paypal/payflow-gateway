Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.ExpressCheckout
    ''' <summary> 
    ''' This class uses the Payflow SDK Data Objects to do a normal DO Express Checkout transaction. 
    ''' The request is sent as a Data Object and the response received is also a Data Object. 
    ''' 
    ''' This sample is for reference and for testing purposes only. See the eStoreFront sample for 
    ''' one way to perform an Express Checkout transaction from your web site. 
    ''' 
    ''' Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developer's 
    ''' Guide (US, AU) or the Websites Payments Pro Payflow Edition Developer's Guide (UK). 
    ''' 
    ''' Besides doing a standard Express Checkout transactions, you can also do a Express Checkout Reference
    ''' Transaction.
    ''' 
    ''' A reference transaction takes existing billing information already gathered from a previously 
    ''' authorized transaction and reuses it to charge the customer in a subsequent transaction. 
    ''' Reference transactions, typically used for repeat billing to a merchants PayPal account when 
    ''' customers are not present to log in, are now supported through Express Checkout. 
    ''' 
    ''' NOTE: You must be enabled by PayPal to use reference transactions. Contact your account manager 
    ''' or the sales department for more details. 
    ''' 
    ''' See the DOSetEC Sample for more details on Reference Transations using Express Checkout. 
    ''' </summary> 
    Public Class DODoEC
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())

            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DODoEC.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects. 
            ' Create the User data object with the required user details. 
            Dim User As New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow Connection data object with the required connection details. 
            ' The PAYFLOW_HOST property is defined in the App config file. 
            Dim Connection As New PayflowConnectionData

            ' Once the customer has reviewed the shipping details and decides to continue 
            ' checkout by clicking on "Continue Checkout" button, it's time to actually 
            ' authorize the transaction. 
            ' This is the third step in PayPal Express Checkout, in which you need to perform a 
            ' DO operation to authorize the purchase amount. 
            '
            ' For more information on Reference Transactions, see the DOSetEC Sample for more details. 

            ' For Regular Express Checkout or Express Checkout Reference Transaction with Purchase. 
            Dim DoRequest As New ECDoRequest("<TOKEN>", "<PAYERID>")

            ' For Express Checkout Reference Transaction without Purchase.
            'Dim DoRequest As New ECDoBARequest("<TOKEN>", "<PAYERID>")

            ' Performing a Reference Transaction, Credit Transaction, Do Authorization or Do Reauthorization
            ' These transactions do not require a token or payerid.  Additional fields
            ' are set using the ExtendData, ECDoRequest or AuthorizationTransaction objects, see below.
            'Dim DoRequest As New ECDoRequest("", "")

            ' Perform a Do Reauthorization
            ' To reauthorize an Authorization for an additional three-day honor period, you can use a Do
            ' Reauthorization transaction. A Do Reauthorization can be used at most once during the 29-day
            ' authorization period.
            ' To set up a Do Reauthorization, you must pass ORIGID in the AuthorizationTransaction object
            ' and set DoReauthorization to 1.
            'DoRequest.DoReauthorization = "1"

            ' Populate Invoice object. 
            Dim Inv As New Invoice
            Inv.Amt = New Currency(New Decimal(21.98), "USD")
            Inv.Comment1 = "Testing Express Checkout"

            ' **** PayPal Pay Later Service ****
            ' See DoSetEC.vb for information on PayPal's Pay Later Service.

            ' Create the Tender object. 
            Dim Tender As New PayPalTender(DoRequest)

            ' Create the transaction object. 
            Dim Trans As New AuthorizationTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)
            ' Doing a credit?
            'Dim Trans As New CreditTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)

            ' Using a Reference Transaction
            ' To be able to "charge" a customer using their Billing Agreement you will need to pass the BAID
            ' and other parameters via the ExtendData Object.
            'Dim BAId As New ExtendData("BAID", "<BAID>")
            'Trans.AddToExtendData(BAId)
            'Dim CaptureComplete As New ExtendData("CAPTURECOMPLETE", "NO")
            'Trans.AddToExtendData(CaptureComplete)
            'Dim MaxAmt As New ExtendData("MAXAMT", "15.00")
            'Trans.AddToExtendData(MaxAmt)

            ' Perform a Do Authorization or Do Reauthorization
            ' You must pass ORIGID using the PNREF of the original order transaction.
            'Trans.OrigId = "<PNREF>"

            ' Submit the transaction. 
            Dim Resp As Response = Trans.SubmitTransaction()

            ' Display the transaction response parameters. 
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters. 
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("PPREF = " + TrxnResponse.PPref)
                    Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
                    Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
                    Console.WriteLine("EMAIL = " + Trans.Response.ExpressCheckoutGetResponse.EMail)
                    Console.WriteLine("PAYERID = " + Trans.Response.ExpressCheckoutGetResponse.PayerId)
                    Console.WriteLine("PAYMENTTYPE = " + Trans.Response.TransactionResponse.PaymentType)
                    Console.WriteLine("PENDINGREASON = " + Trans.Response.TransactionResponse.PendingReason)

                    ' BAID is returned with Express Checkout Reference Transaction with and without Purchase.
                    ' See the notes in DOSetEC regarding this feature. 
                    If Not Trans.Response.ExpressCheckoutDoResponse.BAId Is Nothing Then
                        Console.WriteLine(Environment.NewLine + "BAID = " + Trans.Response.ExpressCheckoutDoResponse.BAId)
                    End If

                    ' If value is true, then the Request ID has not been changed and the original response 
                    ' of the original transction is returned. 
                    Console.WriteLine(Environment.NewLine + "DUPLICATE = " + TrxnResponse.Duplicate)
                End If

                ' Display the response. 
                Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

                ' Get the Transaction Context and check for any contained SDK specific errors (optional code). 
                Dim TransCtx As Context = Resp.TransactionContext
                If Not TransCtx Is Nothing AndAlso TransCtx.getErrorCount() > 0 Then
                    Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                End If
            End If
            Console.WriteLine("Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace