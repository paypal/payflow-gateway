Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.ExpressCheckout
    ''' <summary> 
    ''' This class uses the Payflow SDK Data Objects to do a normal SET Express Checkout transaction. 
    ''' The request is sent as a Data Object and the response received is also a Data Object. 
    ''' 
    ''' Express Checkout offers your customers an easy, convenient checkout experience. It lets them 
    ''' use shipping and billing information stored securely at PayPal to check out, so they don’t have 
    ''' to re-enter it on your site. 
    ''' 
    ''' From the perspective of website development, Express Checkout works like other Payflow Pro 
    ''' features. You submit transaction information to the server as name-value pair parameter 
    ''' strings or using Data Objects as this example. 
    ''' 
    ''' Refer to the "PayPal Express Checkout Transaction Processing" chapter of the Payflow Pro Developer's 
    ''' Guide (US, AU) or the Websites Payments Pro Payflow Edition Developer's Guide (UK). 
    ''' 
    ''' This sample is for reference and for testing purposes only. See the eStoreFront sample for 
    ''' one way to perform an Express Checkout transaction from your web site. The eStoreFront sample does 
    ''' not include reference transactions.
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
    ''' To implement a reference transaction, you must first obtain a billing agreement from the 
    ''' customer. The customer logs into PayPal once to consent to the billing agreement, after which 
    ''' customer login is not required. The customer’s consent allows PayPal to withdraw funds from 
    ''' the customer’s PayPal account. 
    ''' 
    ''' The billing agreement is good until canceled by you or the customer. A customer may have 
    ''' more than one billing agreement for your website. This can occur if the customer establishes 
    ''' separate agreements for different kinds of service. If you use reference transactions, be sure 
    ''' that they are associated with the correct billing agreement. 
    ''' 
    ''' When you implement reference transactions on your website, the customer can choose to 
    ''' accept or reject the billing agreement with or without making a purchase. 
    ''' </summary> 
    Public Class DOSetEC
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSetEC.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects. 
            ' Create the User data object with the required user details. 
            Dim User As New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow Connection data object with the required connection details. 
            ' See the DoSaleComplete sample for more information on setting the Connection object.
            Dim Connection As New PayflowConnectionData

            ' Create the invoice object and set the amount value. 
            Dim Inv As New Invoice
            Inv.Amt = New Currency(New Decimal(21.98), "USD")
            Inv.OrderDesc = "This is my Order Description"

            ' **** PayPal Pay Later Service ****
            ' PayPal Pay Later is a new, convenient, and secure service that allows you to offer your
            ' customers promotional financing. Buyers that choose the promotional offer can defer
            ' payments for purchases on participating merchant web sites, allowing them to shop now and
            ' pay later.
            ' The PayPal Pay Later service allows online merchants to offer promotional financing to
            ' buyers at checkout - even if a buyer doesn't have a PayPal account. Promotional offers, such as
            ' no payments for 90 days, give merchants new and powerful ways to market to online
            ' shoppers.
            ' The PayPal Pay Later service is issued by GE Money Bank, one of the world's leading
            ' providers of consumer credit.
            ' **** Signing Up for PayPal Pay Later ****
            ' PayPal's new promotional financing is currently available to consumers and select merchants
            ' in the U.S. If you are a merchant and would like to add this service, please contact your sales
            ' representative for information and additional documentation.
            '
            'Dim SetPayLater As New PayLater
            'SetPayLater.ShippingMethod = "UPSGround"
            'SetPayLater.ProductCategory = "E" ' Camera and Photos
            'SetPayLater.PayPalCheckoutBtnType = "P"
            ' You can combine up to 10 promotions for PayPal Promotional Financing.
            ' L_PROMOCODE0
            'Dim SetPayLaterLineItem As New PayLaterLineItem
            'SetPayLaterLineItem.PromoCode = "101"
            'SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem)
            ' L_PROMOCODE1
            'Dim SetPayLaterLineItem1 As New PayLaterLineItem
            'SetPayLaterLineItem1.PromoCode = "102"
            'SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem1)

            ' **** Performing a Standard Transaction using Express Checkout ****
            '
            ' Express Checkout offers your customers an easy, convenient checkout experience. It lets them 
            ' use shipping and billing information stored securely at PayPal to check out, so they don’t have 
            ' to re-enter it on your site. 
            '
            ' From the perspective of website development, Express Checkout works like other Payflow Pro 
            ' features. You submit transaction information to the server as name-value pair parameter 
            ' strings. 
            '   
            ' Create the data object for Express Checkout SET operation using ECSetRequest Data Object. 
            Dim SetRequest As New ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com")

            ' If using Pay Later, you would create the data object as below.
            'Dim SetRequest As New ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", setPayLater)

            ' **** Performing a Reference Transaction using Express Checkout ****
            '
            ' NOTE: You must be enabled by PayPal to use reference transactions. Contact your account manager 
            ' or the sales department for more details. 
            '
            ' See the "Using Reference Transactions with Express Checkout" guide that is supplied to you 
            ' once your account is active with the feature. 

            ' *** With Making a Purchase ***
            ' Say that you have implemented Express Checkout on your website. The customer logs in to 
            ' purchase an item of merchandise and chooses PayPal to pay for it. In the normal Express 
            ' Checkout flow, the customer is then redirected to PayPal to log in to verify their billing 
            ' information. If the customer approves payment on the Confirmation page when you are using 
            ' a reference transaction, you receive the billing agreement as part of the transaction.You can 
            ' use that billing agreement later to bill the customer a set amount on a recurring basis, such as 
            ' once-a-month, for future purchases. The customer doesn’t need to log into PayPal each time to 
            ' make a payment. 
            ' 
            ' Create the data object for Express Checkout Reference Transaction SET operation 
            ' with Purchase using ECSetRequest Data Object.
            'Dim SetRequest As New ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", _
            '       "MerchantInitiatedBilling", "Test Description", "any", "BACustom")

            ' *** Without Making a Purchase ***
            ' Typically, the customer chooses a billing agreement without making a purchase when they 
            ' subscribe for merchandise they will pay for on a recurring schedule. If, for example, the 
            ' customer logs in to your website to order a magazine subscription, you set up an agreement to 
            ' bill the customer on a scheduled basis, say, once a month. In the billing agreement flow 
            ' without purchase, the customer is redirected to PayPal to log in. On the PayPal site, they 
            ' consent to the billing agreement. Next month, when you send the customer the first magazine 
            ' issue, the billing agreement authorizes you to start charging the customer’s PayPal account on 
            ' the agreed upon recurring basis without having the customer log in to PayPal. 
            '  
            ' Create the data object for Express Checkout Reference Transaction SET operation 
            ' without Purchase using ECSetBARequest Data Object.
            'Dim SetRequest As New ECSetBARequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", _
            '    "MerchantInitiatedBilling", "Test Description", "any", "BACustom")

            ' Create the Tender object. 
            Dim Tender As New PayPalTender(SetRequest)

            ' Create the transaction object. 
            Dim Trans As New AuthorizationTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)

            ' Create an Order Transaction.  An Order transaction represents an agreement to pay one or more 
            ' authorized amounts up to the specified total over a maximum of 29 days. 
            ' Refer to the Express Checkout for Payflow Pro Developer's Guide regarding Orders.
            'Dim Trans As New OrderTransaction(User, Connection, Inv, Tender, PayflowUtility.RequestId)

            ' Submit the Transaction 
            Dim Resp As Response = Trans.SubmitTransaction()

            ' Display the transaction response parameters. 
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters. 
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("TOKEN = " + Trans.Response.ExpressCheckoutSetResponse.Token)
                    Console.WriteLine("CORRELATIONID = " + TrxnResponse.CorrelationId)
                    ' If value is true, then the Request ID has not been changed and the original response 
                    ' of the original transction is returned. 
                    Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate)
                End If

                If TrxnResponse.Result = 0 Then
                    Console.WriteLine(Environment.NewLine + "Transaction was Approved.")
                    Console.WriteLine(Environment.NewLine + "The next step would be to redirect to PayPal to allow customer to log")
                    Console.WriteLine("into their account to select payment. For this demo, DO NOT CLOSE the browser")
                    Console.WriteLine("as you will need the TOKEN and/or PAYER ID from the URL for the GET and DO")
                    Console.WriteLine("samples.")
                    Console.WriteLine(Environment.NewLine + "Make sure you are logged into Developer Central (https://developer.paypal.com) before continuing.")
                    Console.WriteLine(Environment.NewLine + "Press <Enter> to redirect to PayPal.")
                    Console.ReadLine()

                    ' *** Using the PayPal SandBox for Express Checkout ***
                    ' Before you can use the PayPal Sandbox with a Gateway account you'll need to do the following: 
                    ' To setup a PayPal Sandbox account to work with a Payflow Pro account you will need to go to 
                    ' https://developer.paypal.com and create an account. Once you have access to the Sandbox then 
                    ' you will be able to set up test business accounts, premier accounts and personal accounts. Please 
                    ' set up a test business account and personal account so you can test Express Checkout. 
                    ' 
                    ' Once you have a test business account created, create a ticket at http://www.paypal.com/mts 
                    ' under Contact Support and request to have your Payflow Pro (US, AU) or Websites Payments Pro 
                    ' Payflow Edition (UK) account modified to use the PayPal Sandbox. Provide the e-mail ID you 
                    ' used when you created your account on the Sandbox. 
                    ' 
                    ' Once you are notified that your account has been updated you will then need to modify the host 
                    ' URLs of the Payflow Pro Express Checkout test servers to the URLs used by the Sandbox. 
                    ' For example, https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&useraction=commit&token=<token>. 
                    ' 
                    ' If the SET operation succeeds, you will get a secure session token id in the response of this 
                    ' operation. Using this token, redirect the user's browser as follows: 

                    ' For Regular Express Checkout or Express Checkout Reference Transaction with Purchase. 
                    'Dim PayPalUrl As String = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&useraction=commit&token="

                    ' For Express Checkout Reference Transaction without Purchase. 
                    Dim PayPalUrl As String = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_customer-billing-agreement&useraction=commit&token="

                    PayPalUrl += Trans.Response.ExpressCheckoutSetResponse.Token
                    Process.Start(PayPalUrl) ' Open default browser. 
                    'Process.Start("iexplore.exe", PayPalUrl); 
                    'Process.Start("C:\Program Files\Mozilla Firefox\firefox.exe", PayPalUrl)
                End If

                ' Display the response. 
                Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

                ' Get the Transaction Context and check for any contained SDK specific errors (optional code). 
                Dim TransCtx As Context = Resp.TransactionContext
                If Not TransCtx Is Nothing AndAlso TransCtx.getErrorCount() > 0 Then
                    Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
                End If
            End If
            Console.WriteLine("Press <Enter> to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace