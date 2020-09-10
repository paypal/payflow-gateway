Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Recurring
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a Recurring Inquiry transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DORecurringInquiry
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DORecurringInquiry.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            Dim RecurInfo As RecurringInfo = New RecurringInfo
            RecurInfo.OrigProfileId = "<profile id>"  ' RT0000001350
            ' To show payment history instead of Profile details, change to "Y".
            ' To view "Optional Transactions", use 'O'.
            RecurInfo.PaymentHistory = "N"

            '/////////////////////////////////////////////////////////////////

            ' Create a new Recurring Inquiry Transaction.
            Dim Trans As RecurringInquiryTransaction = New RecurringInquiryTransaction(User, Connection, RecurInfo, PayflowUtility.RequestId)

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    ' TrxnResponse.RespMsg will normally be NULL for Inquiry unless
                    ' there is an issue with the request.
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                End If

                ' Get the Recurring Response parameters.
                Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
                If Not RecurResponse Is Nothing Then
                    Console.WriteLine("RPREF = " + RecurResponse.RPRef)
                    Console.WriteLine("PROFILEID = " + RecurResponse.ProfileId)
                    If RecurResponse.InquiryParams.Count = 0 Then
                        Console.WriteLine("STATUS = " + RecurResponse.Status)
                        Console.WriteLine("PROFILENAME = " + RecurResponse.ProfileName)
                        Console.WriteLine("START = " + RecurResponse.Start)
                        Console.WriteLine("TERM = " + RecurResponse.Term)
                        Console.WriteLine("PAYMENTSLEFT = " + RecurResponse.PaymentsLeft)
                        Console.WriteLine("NEXTPAYMENT = " + RecurResponse.NextPayment)
                        Console.WriteLine("PAYPERIOD = " + RecurResponse.PayPeriod)
                        Console.WriteLine("TENDER = " + RecurResponse.Tender)
                        Console.WriteLine("AMT = " + RecurResponse.Amt)
                        Console.WriteLine("ACCT = " + RecurResponse.Acct)
                        Console.WriteLine("EXPDATE = " + RecurResponse.ExpDate)
                        Console.WriteLine("AGGREGATEAMT = " + RecurResponse.AggregateAmt)
                        Console.WriteLine("AGGREGATEOPTIONALAMT = " + RecurResponse.AggregateOptionalAmt)
                        Console.WriteLine("MAXFAILPAYMENTS = " + RecurResponse.MaxFailPayments)
                        Console.WriteLine("NUMFAILPAYMENTS = " + RecurResponse.NumFailPayments)
                        Console.WriteLine("RETRYNUMDAYS = " + RecurResponse.RetryNumDays)
                        Console.WriteLine("END = " + RecurResponse.End)
                        Console.WriteLine("FIRSTNAME = " + RecurResponse.Name)
                        Console.WriteLine("LASTNAME = " + RecurResponse.LastName)
                        Console.WriteLine("STREET = " + RecurResponse.Street)
                        Console.WriteLine("ZIP = " + RecurResponse.Zip)
                    Else
                        ' Diplay the Payment History instead of Profile data.
                        ' Payment History is stored in the HASHTABLE RecurResponse.InquiryParams.
                        ' PAYMENTHISTORY = Y or O
                        Console.WriteLine("INQUIRY PARAMS")
                        Dim x As Integer
                        While True
                            x = x + 1
                            If RecurResponse.InquiryParams.Item("P_PNREF" + x.ToString) Is Nothing Then
                                Exit While
                            End If
                            Console.WriteLine(x.ToString & ") PAYMENT: {0}" + ControlChars.Tab _
                                + "RESULT: {1}" + ControlChars.Tab _
                                + "PNREF: " + "{2}" + ControlChars.Tab _
                                + "AMOUNT: " + "{3}" + ControlChars.Tab _
                                + "TRANSTIME: " + "{4}" + ControlChars.Tab _
                                + "TRANSTATE: " + "{5}" + ControlChars.Tab _
                                + "TENDER: " + "{6}" + ControlChars.Tab, _
                                x, _
                                RecurResponse.InquiryParams.Item("P_RESULT" + x.ToString), _
                                RecurResponse.InquiryParams.Item("P_PNREF" + x.ToString), _
                                RecurResponse.InquiryParams.Item("P_AMT" + x.ToString), _
                                RecurResponse.InquiryParams.Item("P_TRANSTIME" + x.ToString), _
                                RecurResponse.InquiryParams.Item("P_TRANSTATE" + x.ToString), _
                                RecurResponse.InquiryParams.Item("P_TENDER" + x.ToString))
                        End While
                    End If
                End If
            End If

            Console.WriteLine(Environment.NewLine + PayflowUtility.GetStatus(Resp))

            ' Get the Transaction Context and check for any contained SDK specific errors (optional code).

            Dim TransCtx As Context = Resp.TransactionContext
            If (Not TransCtx Is Nothing) And (TransCtx.getErrorCount() > 0) Then
                Console.WriteLine(Environment.NewLine + "Transaction Errors = " + TransCtx.ToString())
            End If

            Console.WriteLine(Environment.NewLine + "Press Enter to Exit ...")
            Console.ReadLine()
        End Sub
    End Class
End Namespace