Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Authorize transaction using Encrypted Swipe Data 
    ''' from card readers by Magtek, http://www.magtek.com.
    ''' 
    ''' The request Is sent as a Data Object And the response received Is also a Data Object.
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
    '''	See the Payflow Gateway Developer Guide and Reference at https://developer.paypal.com/docs/classic/payflow/integration-guide for more information.
    ''' </summary>
    Public Class DOEncryptedSwipe
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOEncryptedSwipe.vb")
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
            Inv.Comment1 = "Magtek Encrypted Swipe Example"

            ' Create a new Payment Device - Swipe data object.  The input parameter is Encrypted Swipe Data.
            ' The data passed in this example will be extracted from a Magtek Encrypted Card reader.  Please refer
            ' to the Magtek SDK and documentation on how to obtain the data from the reader.
            ' The parameter data for the SwipeCard object Is usually obtained with a card reader And this shows
            ' how to send data obtained from a Magtek Encrypted reader.
            ' NOTE: The SWIPE parameter is not supported on accounts where PayPal is the Processor.

            ' Create a New Magtek data object with the device serial number, track data, etc.
            Dim MT As MagtekInfo = New MagtekInfo()

            ' The data below CANNOT be used for Testing. It Is only here to show what the data fields look Like once you
            ' obtain them from the reader itself.  Refer to the Payflow Pro Developers Guide And the Appendix related to processing
            ' with Magtek card readers for more information.
            ' The Payflow Gateway Developer Guide And Reference found at https://developer.paypal.com/docs/classic/payflow/integration-guide/
            MT.DeviceSN = "B32XXXXXXXXXXAA"
            MT.EncMP = "34F29380E6AFED395472A63063B6XXXXXXXXXXXXXXXXXXXXXXXXXC987D2A1F7A50554DFC4A0D215A8AA0591D82B6DB13516F220C4CB93899"
            MT.EncryptionBlockType = "1"
            MT.EncTrack1 = "80BC13515EF76421FCXXXXXXXXXXXXXXXXXXXXXXXXX02E53C0ECCC83B1787DE05BB5D8C7FA679D0C40CC989F7FAF307FE7FD0B588261DDA0"
            MT.EncTrack2 = "4CDD6BC521B397CD2DB1324199XXXXXXXXXXXXXXXXXXXXXXXXX83A9044B397C1D14AFEE2C0BA1002"
            MT.EncTrack3 = ""
            MT.KSN = "901188XXXXXXXXXX00F4"
            MT.MagtekCardType = "1"
            MT.MPStatus = "61403000"
            MT.RegisteredBy = "PayPal"
            MT.SwipedECRHost = "MAGT"

            ' When using Encrypted Card Readers you do Not populate the SwipeCard object as the data from the Magtek object
            ' will be used instead.
            Dim Swipe As SwipeCard = New SwipeCard("")
            Swipe.MagtekInfo = MT

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
                    ' Magtek Response will only be available if a failure Or error in the request.
                    Console.WriteLine("MAGTRESPONSE = " + TrxnResponse.MagTResponse)
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