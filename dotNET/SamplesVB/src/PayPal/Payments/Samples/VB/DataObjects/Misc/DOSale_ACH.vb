Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple ACH - Sale transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    '''
    ''' Refer to the Payflow ACH Payment Service Guide for more information.
    '''
    ''' </summary>
    Public Class DOSale_ACH
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOSale_ACH.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.12))
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.BillToStreet = "123 Main St."
            Bill.BillToZip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Bank Account data object.
            ' The input parameters are Account No. and ABA.
            Dim BA As BankAcct = New BankAcct("1111111111", "111111118")
            ' The Account Type can be "C" for Checking & "S" for Saving.
            BA.AcctType = "C"
            BA.Name = "John Doe"

            ' Create a new Tender - ACH Tender data object.
            Dim ACH As ACHTender = New ACHTender(BA)
            ACH.AuthType = "WEB" ' Sending as a Web transaction.
            ACH.ChkNum = "1234"

            ' Create a new ACH - Sale Transaction.
            Dim Trans As SaleTransaction = New SaleTransaction(User, Connection, Inv, ACH, PayflowUtility.RequestId)

            ' Setting verbosity to HIGH to get full response.
            Trans.Verbosity = "HIGH"

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode)
                    Console.WriteLine("TRANSTIME = " + TrxnResponse.TransTime)
                    Console.WriteLine("CHECK NAME (FIRSTNAME) = " + TrxnResponse.FirstName)
                    Console.WriteLine("AMOUNT = " + TrxnResponse.RespMsg)
                    Console.WriteLine("ACCT (Last 4 of MICR) = " + TrxnResponse.Acct)
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