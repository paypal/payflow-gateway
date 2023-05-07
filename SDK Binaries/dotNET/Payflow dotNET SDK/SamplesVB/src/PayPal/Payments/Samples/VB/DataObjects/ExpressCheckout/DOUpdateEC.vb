Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.ExpressCheckout
    ''' <summary> 
    ''' This class uses the Payflow SDK Data Objects to do an Update Express Checkout transaction. Used 
    ''' for reference transaction only, see below. 
    ''' 
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
    Public Class DOUpdateEC
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOUpdateEC.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects. 
            ' Create the User data object with the required user details. 
            Dim User As New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow Connection data object with the required connection details. 
            ' The PAYFLOW_HOST property is defined in the App config file. 
            Dim Connection As New PayflowConnectionData

            ' You can use the Update Billing Agreement request to cancel the billing agreement or update 
            ' the billing agreement description. 
            ' 
            ' For more information on Reference Transactions, see the DOSetEC Sample for more details. 

            ' For Express Checkout Reference Transaction without Purchase. 
            Dim UpdateRequest As New ECUpdateBARequest("<BAID>", "<BA_STATUS>", "<BA_DESC>")

            ' Create the Tender object. 
            Dim Tender As New PayPalTender(UpdateRequest)

            ' Create the transaction object. We do not pass a Transaction Type for an update call. 
            Dim Trans As New BaseTransaction(Nothing, User, Connection, Nothing, Tender, PayflowUtility.RequestId)

            ' Submit the transaction. 
            Dim Resp As Response = Trans.SubmitTransaction()

            ' Display the transaction response parameters. 
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters. 
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    ' PNREF is not returned with an Update call. 
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    If TrxnResponse.Result = 0 Then
                        Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
                        Console.WriteLine("PAYERID = " + Trans.Response.ExpressCheckoutGetResponse.PayerId)
                        Console.WriteLine("PAYERSTATUS = " + Trans.Response.ExpressCheckoutGetResponse.PayerStatus)
                        Console.WriteLine("FIRST = " + Trans.Response.ExpressCheckoutGetResponse.FirstName)
                        Console.WriteLine("LAST = " + Trans.Response.ExpressCheckoutGetResponse.LastName)
                        Console.WriteLine("EMAIL = " + Trans.Response.ExpressCheckoutGetResponse.EMail)
                        Console.WriteLine("BAID = " + Trans.Response.ExpressCheckoutDoResponse.BAId)
                        Console.WriteLine("BA_STATUS = " + Trans.Response.ExpressCheckoutUpdateResponse.BA_Status)
                        Console.WriteLine("BA_DESC = " + Trans.Response.ExpressCheckoutUpdateResponse.BA_Desc)
                    End If
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

            Console.WriteLine("Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace