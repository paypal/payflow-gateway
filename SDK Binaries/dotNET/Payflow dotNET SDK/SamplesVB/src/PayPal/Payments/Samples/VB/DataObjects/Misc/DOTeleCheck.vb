Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Misc
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Telecheck - Authorization transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DOTeleCheck
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("---------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOTeleCheck.vb")
            Console.WriteLine("---------------------------------------------------------")

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

            ' Set the Billing Address details required for a teleCheck transaction.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.City = "New York"
            Bill.State = "PA"
            Bill.Zip = "12345"
            Bill.Country = "US"
            Bill.PhoneNum = "123-4546-7890"
            Bill.Email = "ivan@test.com"
            Inv.BillTo = Bill

            ' Set the IP address of the customer
            Dim custInfo As CustomerInfo = New CustomerInfo()
            custInfo.CustIP = "111.111.11.111"
            Inv.CustomerInfo = custInfo

            ' Create a new Payment Device - Check Payment data object.
            ' The input parameters is MICR. Magnetic Ink Check Reader. This is the entire line
            ' of numbers at the bottom of all checks. It includes the transit number, account 
            ' number, and check number.
            Dim ChkPayment As CheckPayment = New CheckPayment("1234567804390850001234")

            ' Name property needs to be set for the Check Payment.
            ChkPayment.Name = "Ivan Smith"

            ' Create a new Tender - Check Tender data object.
            Dim ChkTender As CheckTender = New CheckTender(ChkPayment)
            ' Account holder’s next unused (available) check number. Up to 7 characters.
            ChkTender.ChkNum = "1234"

            ' DL or SS is required for a TeleCheck transaction.
            ' If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
            ' If CHKTYPE=C, the Federal Tax ID must be passed as the SS value.
            ChkTender.ChkType = "P"

            ' Driver’s License number. If CHKTYPE=P, a value for either DL or SS must be passed as an identifier.
            ' Format: XXnnnnnnnn
            ' XX = State Code
            ' nnnnnnnn = DL Number - up to 31 characters.
            ChkTender.DL = "CAN85452345"

            ' Social Security number. Needed if ChkType = P
            ChkTender.SS = "456765833"

            ' AuthType = I-Internet Check, P-Checks by Phone, D-Prearranged Deposit
            ChkTender.AuthType = "I"

            ' Create a new TeleCheck - Authorization Transaction.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(User, Connection, Inv, ChkTender, PayflowUtility.RequestId)

            ' Want VERBOSITY=HIGH to get all the response values back.
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
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode)
                    Console.WriteLine("TRACEID = " + TrxnResponse.TraceId)
                    Console.WriteLine("ACHSTATUS = " + TrxnResponse.AchStatus)
                End If
                ' Display the response.
                Console.WriteLine(PayflowUtility.GetStatus(Resp) + Environment.NewLine)
                ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                Dim TransCtx As Context = Resp.TransactionContext
                If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                    Console.WriteLine("Transaction Errors = " + TransCtx.ToString() + Environment.NewLine)
                End If
                If TrxnResponse.Result = "0" Then
                    ' Transaction approved, display acceptance verbiage, after consumer accepts, capture the
                    ' transaction to finalize it.
                    Dim capTrans As CaptureTransaction = New CaptureTransaction(TrxnResponse.Pnref, User, Connection, Nothing, ChkTender, PayflowUtility.RequestId)
                    capTrans.Verbosity = "HIGH"

                    Dim capResp As Response = capTrans.SubmitTransaction()

                    If Not capResp Is Nothing Then
                        ' Get the Transaction Response parameters.
                        Dim capTrxnResponse As TransactionResponse = capResp.TransactionResponse
                        If Not TrxnResponse Is Nothing Then
                            Console.WriteLine("RESULT = " + capTrxnResponse.Result.ToString)
                            Console.WriteLine("PNREF = " + capTrxnResponse.Pnref)
                            Console.WriteLine("RESPMSG = " + capTrxnResponse.RespMsg)
                            Console.WriteLine("HOSTCODE = " + capTrxnResponse.HostCode)
                            Console.WriteLine("TRACEID = " + capTrxnResponse.TraceId)
                        End If
                        ' Display the response.
                        Console.WriteLine(PayflowUtility.GetStatus(Resp) + Environment.NewLine)
                        ' Get the Transaction Context and check for any contained SDK specific errors (optional code).
                        Dim capTransCtx As Context = Resp.TransactionContext
                        If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                            Console.WriteLine("Transaction Errors = " + TransCtx.ToString() + Environment.NewLine)
                        End If
                    End If
                Else
                    Console.WriteLine("Unable to capture transaction as it declined or failed." + Environment.NewLine)
                End If
            End If
            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace