Imports System
Imports System.Globalization
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.BasicTransactions
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a simple Partial Authorize transaction.
    ''' The request is sent as a Data Object and the response received is also a Data Object.
    '''
    ''' Partial Approval is supported for Visa, MasterCard, American Express and Discover (JCB (US Domestic only), 
    ''' and Diners) Prepaid card products such as gift, Flexible Spending Account (FSA) or Healthcare Reimbursement 
    ''' Account (HRA) cards. In addition Discover (JCB (US Domestic only), and Diners) supports partial Approval on 
    ''' their consumer credit card. It is often difficult for the consumer to spend the exact amount available on 
    ''' the prepaid account, as the purchase can be for amounts greater than the value available. This can result 
    ''' in unnecessary declines. Visa, MasterCard, American Express and Discover (JCB (US Domestic only), and 
    ''' Diners) recognize that the prepaid products represent unique opportunities for both merchants and consumers. 
    ''' With Partial Approval issuers may approve a portion of the amount requested. This will enable the residual 
    ''' transaction amount to be paid by other means. The introduction of the partial approval capability will 
    ''' reduce decline frequency and enhance the consumer and merchant experience at the point of sale. Merchants 
    ''' will now have the ability to accept partial approval rather than having the sale declined. 
    '''
    ''' </summary>
    Public Class DOPartialAuth
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOPartialAuth.vb")
            Console.WriteLine("------------------------------------------------------")

            ' Create the Data Objects.
            ' Creates a CultureInfo for English in the U.S.
            ' Not necessary, just here for example of using currency formatting.
            Dim us As New CultureInfo("en-US")
            Dim usCurrency As String = "USD"

            ' Create the User data object with the required user details.
            Dim User As UserInfo = New UserInfo("<user>", "<vendor>", "<partner>", "<password>")

            ' Create the Payflow  Connection data object with the required connection details.
            ' The PAYFLOW_HOST property is defined in the App config file.
            Dim Connection As PayflowConnectionData = New PayflowConnectionData

            ' Create a new Invoice data object with the Amount, Billing Address etc. details.
            Dim Inv As Invoice = New Invoice

            ' Set the amount and currency being used.  
            ' See the Developer's Guide for the list of the three-digit currency codes.
            ' Refer to the Payflow Pro Developer's Guide on testing parameters for Partial Authorization.
            ' In this example, sending $120.00 will generate a partial approval of only $100.00.

            Dim Amt As Currency = New Currency(New Decimal(120.0), usCurrency)
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.FirstName = "Sam"
            Bill.LastName = "Smith"
            Bill.Street = "123 Main St."
            Bill.Zip = "12345"
            Inv.BillTo = Bill

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("5105105105105100", "0115")
            CC.Cvv2 = "123"

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)

            ' Create a new Auth Transaction.
            Dim Trans As AuthorizationTransaction = New AuthorizationTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId)

            ' Set the flag to request that Partial Authorizations be accepted.
            Trans.PartialAuth = "Y"

            ' You must set the transaction verbosity to HIGH to display the appropriate response.
            Trans.Verbosity = "HIGH"

            ' Submit the transaction.
            Dim Resp As Response = Trans.SubmitTransaction()

            If Not Resp Is Nothing Then
                ' Get the Transaction Response parameters.
                Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse

                If Not TrxnResponse Is Nothing Then
                    Console.WriteLine("RESULT = " + TrxnResponse.Result.ToString)
                    Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
                    ' If the amount is partially authorized the RESPMSG will be "Partial Approval".
                    ' If the amount is fully authorized the RESPMSG will be "Approved".
                    Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
                    Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                    Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match)
                    Console.WriteLine("------------------------------------------------------")
                    ' These are all new items returned when VERBOSITY=HIGH.
                    Console.WriteLine("Credit Card Information:")
                    Console.WriteLine("Last 4-digits Credit Card Number (ACCT) = " + TrxnResponse.Acct)
                    If Not TrxnResponse.CardType Is Nothing Then
                        Console.Write("Card Type (CARDTYPE) = ")
                        Select Case TrxnResponse.CardType
                            Case "0"
                                Console.WriteLine("Visa")
                            Case "1"
                                Console.WriteLine("MasterCard")
                            Case "2"
                                Console.WriteLine("Discover")
                            Case "3"
                                Console.WriteLine("American Express")
                            Case "4"
                                Console.WriteLine("Diner's Club")
                            Case "5"
                                Console.WriteLine("JCB")
                            Case "6"
                                Console.WriteLine("Maestro")
                            Case Else
                                Console.WriteLine("Unknown: " + TrxnResponse.CardType) ' new or unknown card type
                        End Select
                    End If
                    Console.WriteLine("Expiration Date (EXPDATE) = " + TrxnResponse.ExpDate)
                    Console.WriteLine("Billing Name (FIRSTNAME, LASTNAME) = " + TrxnResponse.FirstName + " " + TrxnResponse.LastName)
                    Console.WriteLine("------------------------------------------------------")
                    Console.WriteLine("Verbosity Response:")
                    Console.WriteLine("Processor AVS (PROCAVS) = " + TrxnResponse.ProcAVS)
                    Console.WriteLine("Processor CSC (PROCCVV2) = " + TrxnResponse.ProcCVV2)
                    Console.WriteLine("Processor Result (HOSTCODE) = " + TrxnResponse.HostCode)
                    Console.WriteLine("Transaction Date/Time (TRANSTIME) = " + TrxnResponse.TransTime)

                    ' For Partial Authorization you will need to check the following 3 items to see if the card was
                    ' fully authorized or partially authorized.
                    '
                    ' For example, if you send in a request of $120.00 (AMT=120.00) and the card only has $100.00 of available credit on it,
                    ' the card will be authorized for $100.00, the AMT field will be changed from 120.00 to 100.00 (AMT=100.00 to reflect 
                    ' this and ORIGAMT will be set with the original amount sent, in this case 120.00.
                    ' Since the amount of the charge is greater than the amount available on the card, the balance amount is set to zero.
                    ' If BALAMT is zero, it is suggested that you see if there is a balance still due by looking at the original amount
                    ' and the amount charged.
                    Console.WriteLine("------------------------------------------------------")
                    Console.WriteLine("Partial Payment Response:")
                    Console.WriteLine("Original Amount (ORIGAMT) = " + TrxnResponse.OrigAmt)
                    Console.WriteLine("Amount of Transaction (AMT) = " + TrxnResponse.Amt)
                    If TrxnResponse.BalAmt = 0 And (TrxnResponse.OrigAmt > TrxnResponse.Amt) Then
                        Dim BalDue As Decimal = Decimal.Parse(TrxnResponse.OrigAmt) - Decimal.Parse(TrxnResponse.Amt)
                        If BalDue > 0 Then
                            ' Seems a balance is still due, collect the difference.
                            Console.WriteLine("Please provide additional payment of: " + BalDue.ToString("c", us))
                        ElseIf BalDue = 0 Then
                            Console.WriteLine("Transaction is Paid in Full.")
                        End If
                    Else
                        ' Card still has available balance on it.
                        Console.WriteLine("Balance Amount (BALAMT) = " + TrxnResponse.BalAmt)
                    End If
                    Console.WriteLine("------------------------------------------------------")
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