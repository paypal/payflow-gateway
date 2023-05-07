Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do create a Secure Token used with the 
    ''' hosted checkout page.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOSecureTokenAuth
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSecureTokenAuth.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData
            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount. The amount cannot be changed once submitted.
            Dim Amt As Currency = New Currency(New Decimal(25.0), "USD")
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.  You can also send the shipping information.  Both the Billing
            ' and Shipping information can be changed if the functionality is allowed in the Configuration section
            ' of Manager.  No other information submitted using a secure token call can be changed.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Inv.BillTo = Bill

            ' Since we are using the hosted payment pages, you will not be sending the credit card data with the 
            ' Secure Token Request.  You just send all other 'sensitive' data within this request and when you
            ' call the hosted payment pages, you'll only need to pass the SECURETOKEN; which is generated and returned
            ' and the SECURETOKENID that was created and used in the request.
            '
            ' Create a new Secure Token Authorization Transaction.  Even though this example is performing
            ' an authorization, you can create a secure token using SaleTransction too.  Only Authorization and Sale
            ' type transactions are permitted.
            '
            ' Remember, all data submitted as part of the Secure Token call cannot be modified at a later time.  The only exception
            ' is the billing and shipping information if these items are selection in the Setup section in PayPal Manager.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(User, Connection, Inv, PayflowUtility.RequestId)

            ' Set the flag to create a Secure Token.
            Trans.CreateSecureToken = "Y"
            ' The Secure Token Id must be a unique id up to 36 characters.  Using the RequestID object to 
            ' generate a random id, but any means to create an id can be used.
            Trans.SecureTokenId = PayflowUtility.RequestId

            ' IMPORTANT NOTE:
            ' 
            ' Remember, the Secure Token can only be used once.  Once it is redeemed by a valid transaction it cannot be used again and you will 
            ' need to generate a new token.  Also, the token has a life time of 30 minutes.

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("SECURETOKEN = " + TrxnResponse.SecureToken)
                    Console.WriteLine("SECURETOKENID = " + TrxnResponse.SecureTokenId)
                    ' If value is true, then the Request ID has not been changed and the original response
                    ' of the original transction is returned. 
                    Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate)
                End If

                If TrxnResponse.Result = 0 Then
                    Console.WriteLine(Environment.NewLine + "Transaction was successful.")
                    Console.WriteLine(Environment.NewLine + "The next step would be to redirect to PayPal to display the hosted")
                    Console.WriteLine("checkout page to allow your customer to select and enter payment.")
                    Console.WriteLine(Environment.NewLine + "This is only a simple example, which does not take into account things like")
                    Console.WriteLine(Environment.NewLine + "RETURN or SILENT POST URL, etc.")
                    Console.WriteLine(Environment.NewLine + "Press <Enter> to redirect to PayPal.")
                    Console.ReadLine()
                    ' Simple way to pass token data to Payflow Link Servers.
                    Dim PayPalUrl As String = "https://payflowlink.paypal.com?securetoken=" + TrxnResponse.SecureToken + "&securetokenid=" + TrxnResponse.SecureTokenId + "&mode=test"
                    ' Process.Start(PayPalUrl);  // Open default browser.
                    Process.Start("iexplore.exe", PayPalUrl)
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