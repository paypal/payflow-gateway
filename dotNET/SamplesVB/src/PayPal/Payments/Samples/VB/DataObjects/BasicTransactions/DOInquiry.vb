Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do an Inquiry transaction.
    '''
    ''' You perform an inquiry using a reference to an original transaction—either the PNREF
    ''' value returned for the original transaction or the CUSTREF value that you specified for the original
    ''' transaction.
    '''
    ''' While the amount of information returned in an Inquiry transaction depends upon the VERBOSITY setting, 
    ''' Inquiry responses mimic the verbosity level of the original transaction as much as possible.
    ''' 
    ''' Transaction results (especially values for declines and error conditions) returned by eachPayPal-supported
    ''' processor vary in detail level and in format. The Payflow Pro Verbosity parameter enables you to control
    ''' the kind and level of information you want returned.  By default, Verbosity is set to LOW.
    ''' A LOW setting causes PayPal to normalize the transaction result values. Normalizing the values limits
    ''' them to a standardized set of values and simplifies the process of integrating Payflow Pro.
    ''' By setting Verbosity to MEDIUM, you can view the processor?s raw response values. This setting is more
    ''' "verbose" than the LOW setting in that it returns more detailed, processor-specific information.
    '''   
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOInquiry
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOInquiry.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Inquiry Transaction.
            ' Replace <PNREF> with a previous transaction ID that you processed on your account.
            Dim Trans As InquiryTransaction = New InquiryTransaction("<PNREF>", User, Connection, PayflowUtility.RequestId)

            ' To use CUSTREF Or SECURETOKEN instead of PNREF you need to set the CustRef Or SecureToken And include the INVOICE object in your
            ' request.  Since you will be using CUSTREF Or SECURETOKEN instead of PNREF, PNREF will be "" (null).
            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            'Dim Inv As Invoice = New Invoice
            'Inv.CustRef = "CUSTREF" ' Can also use Inv.SecureToken.
            'Dim Trans As InquiryTransaction = New InquiryTransaction("", User, Connection, Inv, PayflowUtility.RequestId)

            ' Refer to the Payflow Pro Developer's Guide for more information regarding the parameters returned
            ' when VERBOSITY is set.
            Trans.Verbosity = "HIGH" ' Set to HIGH to see all available data available.

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()
            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
                'Display the transaction response parameters. Refer to the Payflow Pro Developer's Guide for explanations.
                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("--------------------------------------------")
                    Console.WriteLine("Original Response Data")
                    Console.WriteLine("--------------------------------------------")
                    Console.WriteLine("RESULT = " + TrxnResponse.OrigResult)
                    Console.WriteLine("PNREF = " + TrxnResponse.OrigPnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                    Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode)
                    Console.WriteLine("RESPTEXT = " + TrxnResponse.RespText)
                    Console.WriteLine("PROCAVS = " + TrxnResponse.ProcAVS)
                    Console.WriteLine("PROCCVV2 = " + TrxnResponse.ProcCVV2)
                    Console.WriteLine("PROCCARDSECURE = " + TrxnResponse.ProcCardSecure)
                    Console.WriteLine("ADDLMSGS = " + TrxnResponse.AddlMsgs)
                    Console.WriteLine("TRANSSTATE = " + TrxnResponse.TransState)
                    Console.WriteLine("DATE_TO_SETTLE = " + TrxnResponse.DateToSettle)
                    Console.WriteLine("BATCHID = " + TrxnResponse.BatchId)
                    Console.WriteLine("SETTLE_DATE = " + TrxnResponse.SettleDate)
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