Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Authorize transaction using Swipe Data.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' Payflow Pro supports card-present transactions (face-to-face purchases).
    '''
    ''' Follow these guidelines to take advantage of the lower card-present transaction rate:
    ''' 
    '''		* Contact your merchant account provider to ensure that they support card-present transactions.
    '''		* Contact PayPal Customer Service to request having your account set up properly for accepting and passing 
    '''		  swipe data.
    '''		* If you plan to process card-present as well as card-not-present transactions, set up two separate Payflow
    '''		  Pro accounts.  Request that one account be set up for card-present transactions, and use it solely for that
    '''		  purpose. Use the other for card-not-present transactions. Using the wrong account may result in downgrades.
    '''		* A Sale is the preferred method to use for card-present transactions. Consult with your acquiring bank for
    '''		  recommendations on other methods.
    '''		
    '''	NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.  This would include Website
    '''	      Payments Pro UK accounts.
    '''	
    '''	See the Payflow Pro Developer's Guide or Websites Payments Pro Payflow Edition Guide for more information.
    ''' </summary>
    Public Class DOSwipe
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSwipe.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.12))
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"
            Inv.Comment1 = "Swipe Example"

            ' Create a new Payment Device - Swipe data object.  The input parameter is Swipe Data.
            ' Used to pass the Track 1 or Track 2 data (the card’s magnetic stripe information) for card-present
            ' transactions. Include either Track 1 or Track 2 data—not both. If Track 1 is physically damaged,
            ' the POS application can send Track 2 data instead.

            ' The parameter data for the SwipeCard object is usually obtained with a card reader.
            ' NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.
            Dim Swipe As SwipeCard = New SwipeCard(";5105105105105100=20121011000012345678?")
            ' Create a new Tender - Swipe Tender data object.
            Dim Card As CardTender = New CardTender(Swipe)

            ' Create a new Sale Transaction using Swipe data.
            Dim Trans As SaleTransaction = New SaleTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId)

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
                    ' If value is true, then the Request ID has not been changed and the original response
                    ' of the original transction is returned. 
                    Console.WriteLine("DUPLICATE = " + TrxnResponse.Duplicate)
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