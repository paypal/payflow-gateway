Imports Microsoft.VisualBasic
Imports System
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Recurring
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a Recurring Add transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    ''' </summary>
    Public Class DORecurringAdd
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DORecurringAdd.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Creating a profile where our customer is paying three installments of $25.75 with a shipping
            ' charge of $9.95.  So, our first payment will be $25.75 + 9.95 with two more payments of $25.75 due.
            '
            ' This is just one example of how you might create a new profile.

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set Amount.
            Dim Amt As Currency = New Currency(New Decimal(25.75))
            Inv.Amt = Amt
            'Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            ' Only Street and Zip are set below for AVS check; however, you would probably want
            ' to include full name and address information.
            Dim Bill As BillTo = New BillTo
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0115")
            ' CVV2 is used for Optional Transaction (Sale or Authorization) Only.  It is not stored as
            ' part of the profile, nor is it sent when payments are made.
            CC.Cvv2 = "123"

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)

            Dim RecurInfo As RecurringInfo = New RecurringInfo
            ' The date that the first payment will be processed. 
            ' This will be of the format mmddyyyy.
            RecurInfo.Start = "09152009"

            RecurInfo.ProfileName = "Test_Profile1"  ' User provided Profile Name.

            ' Specifies how often the payment occurs. All PAYPERIOD values must use 
            ' capital letters and can be any of WEEK / BIWK / SMMO / FRWK / MONT / 
            ' QTER / SMYR / YEAR
            RecurInfo.PayPeriod = "WEEK"
            RecurInfo.Term = "2" ' Number of payments

            ' Peform an Optional Transaction.
            RecurInfo.OptionalTrx = "S"  ' S = Sale, A = Authorization
            ' Set the amount if doing a "Sale" for the Optional Transaction.
            Dim oTrxAmt As Currency = New Currency(New Decimal(25.75 + 9.95))
            RecurInfo.OptionalTrxAmt = oTrxAmt

            ' Create a new Recurring Add Transaction.
            Dim Trans As RecurringAddTransaction = New RecurringAddTransaction(User, Connection, Inv, Card, RecurInfo, PayflowUtility.RequestId)

            ' Use ORIGID to create a profile based on the details of another transaction. See Reference Transaction. 
            'Trans.OrigId = "<ORIGINAL_PNREF>"

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine(("Result Code (RESULT) = " + TrxnResponse.Result.ToString))
                    Console.WriteLine(("Response Message (RESPMSG) = " + TrxnResponse.RespMsg))
                End If

                ' Get the Recurring Response parameters.
                Dim RecurResponse As RecurringResponse = Resp.RecurringResponse
                If Not RecurResponse Is Nothing Then
                    Dim ProfileMsg As String
                    If (TrxnResponse.Result = "0") Then
                        ProfileMsg = "Profile Created."
                    Else
                        ProfileMsg = "Error, Profile Not Created."
                    End If
                    Console.WriteLine("------------------------------------------------------")
                    Console.WriteLine(("Profile Status: " + ProfileMsg))
                    Console.WriteLine("Recurring Profile Reference (RPREF) = " + RecurResponse.RPRef)
                    Console.WriteLine("Recurring Profile ID (PROFILEID) = " + RecurResponse.ProfileId)
                    ' Was an Optional Transaction processed?
                    If Not RecurResponse.TrxResult Is Nothing Then
                        Console.WriteLine("------------------------------------------------------")
                        Console.WriteLine("Optional Transaction Details:")
                        Console.WriteLine("Transaction PNREF (TRXPNREF) = " + RecurResponse.TrxPNRef)
                        Console.WriteLine("Transaction Result (TRXRESULT) = " + RecurResponse.TrxResult)
                        Console.WriteLine("Transaction Message (TRXRESPMSG) = " + RecurResponse.TrxRespMsg)
                        Console.WriteLine(("Authorization (AUTHCODE) = " + TrxnResponse.AuthCode))
                        Console.WriteLine(("Security Code Match (CVV2MATCH) = " + TrxnResponse.CVV2Match))
                        Console.WriteLine(("Street Address Match (AVSADDR) = " + TrxnResponse.AVSAddr))
                        Console.WriteLine(("Streep Zip Match (AVSZIP) = " + TrxnResponse.AVSZip))
                        Console.WriteLine(("International Card (IAVS) = " + TrxnResponse.IAVS))

                        ' Was this a duplicate transaction?
                        ' If this value is true, you will probably receive a result code 19, Original transaction ID not found.
                        Console.WriteLine("------------------------------------------------------")
                        Console.WriteLine("Duplicate Response:")
                        Dim DupMsg As String
                        If (TrxnResponse.Duplicate = "1") Then
                            DupMsg = "Duplicate Transaction"
                        Else
                            DupMsg = "Not a Duplicate Transaction"
                        End If
                        Console.WriteLine(("Duplicate Transaction (DUPLICATE) = " + DupMsg))
                    End If
                End If

                ' Display the response.  This is normally not used in production.
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