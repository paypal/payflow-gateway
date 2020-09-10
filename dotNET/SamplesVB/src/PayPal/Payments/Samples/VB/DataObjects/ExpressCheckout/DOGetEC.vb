Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.ExpressCheckout
    ''' <summary> 
    ''' This class uses the Payflow SDK Data Objects to do a normal GET Express Checkout transaction. 
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
    Public Class DOGetEC
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOGetEC.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects. 
            ' Create the User data object with the required user details. 
            Dim User As New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow Connection data object with the required connection details. 
            Dim Connection As New PayflowConnectionData

            ' Calling a GET operation is second step in PayPal Express checkout process. Once the 
            ' customner has logged into his/her paypal account, selected shipping address and clicked on 
            ' "Continue checkout", the PayPal server will redirect the page to the ReturnUrl you have 
            ' specified in the previous SET request. To obtain the shipping details chosen by the 
            ' Customer, you will then need to do a GET operation. 
            '
            ' For more information on Reference Transactions, see the DOSetEC Sample for more details. 

            ' For Regular Express Checkout or Express Checkout Reference Transaction with Purchase. 
            Dim GetRequest As New ECGetRequest("<TOKEN>")

            ' For Express Checkout Reference Transaction without Purchase. 
            'Dim GetRequest As New ECGetBARequest("<TOKEN>")

            ' Create the Tender. 
            Dim Tender As New PayPalTender(GetRequest)

            ' Create a transaction. 
            Dim Trans As New AuthorizationTransaction(User, Connection, Nothing, Tender, PayflowUtility.RequestId)

            ' Submit the Transaction 
            Dim Resp As Response = Trans.SubmitTransaction()

            ' Display the transaction response parameters. 
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters. 
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    ' The TOKEN is needed for the DODoEC Sample. 
                    Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
                    Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
                    Console.WriteLine("EMAIL = " + Trans.Response.ExpressCheckoutGetResponse.EMail)
                    ' The PAYERID is needed for the DODoEC Sample. 
                    Console.WriteLine("PAYERID = " + Trans.Response.ExpressCheckoutGetResponse.PayerId)
                    Console.WriteLine("PAYERSTATUS = " + Trans.Response.ExpressCheckoutGetResponse.PayerStatus)
                    ' Express Checkout Transactions and Express Checkout Reference Transactions with Purchase
                    ' begin with EC, while Express Checkout Reference Transactions without Purchase begin with BA.
                    ' Reference Transactions without Purchase do not return shipping information.
                    If Not Trans.Response.ExpressCheckoutSetResponse.Token Is Nothing Then
                        If Trans.Response.ExpressCheckoutSetResponse.Token.StartsWith("EC") Then
                            Console.WriteLine(Environment.NewLine + "Shipping Information:")
                            Console.WriteLine("FIRST = " + Trans.Response.ExpressCheckoutGetResponse.FirstName)
                            Console.WriteLine("LAST = " + Trans.Response.ExpressCheckoutGetResponse.LastName)
                            Console.WriteLine("SHIPTOSREET = " + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet)
                            Console.WriteLine("SHIPTOSTREET2 = " + Trans.Response.ExpressCheckoutGetResponse.ShipToStreet2)
                            Console.WriteLine("SHIPTOCITY = " + Trans.Response.ExpressCheckoutGetResponse.ShipToCity)
                            Console.WriteLine("SHIPTOSTATE = " + Trans.Response.ExpressCheckoutGetResponse.ShipToState)
                            Console.WriteLine("SHIPTOZIP = " + Trans.Response.ExpressCheckoutGetResponse.ShipToZip)
                            Console.WriteLine("SHIPTOCOUNTRY = " + Trans.Response.ExpressCheckoutGetResponse.ShipToCountry)
                            Console.WriteLine("AVSADDR = " + Trans.Response.TransactionResponse.AVSAddr)
                            ' BA_Flag is returned with Express Checkout Reference Transaction with Purchase.
                            ' See the notes in DOSetEC regarding this feature. 
                            If Not Trans.Response.ExpressCheckoutGetResponse.BA_Flag Is Nothing Then
                                Console.WriteLine(Environment.NewLine + "BA_FLAG = " + Trans.Response.ExpressCheckoutGetResponse.BA_Flag)
                                If Trans.Response.ExpressCheckoutGetResponse.BA_Flag = "1" Then
                                    Console.WriteLine("Buyer Agreement was created.")
                                Else
                                    Console.WriteLine("Buyer Agreement not was accepted.")
                                End If
                            End If
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
            End If
            Console.WriteLine("Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace