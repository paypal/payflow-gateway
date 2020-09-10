Imports System
Imports System.Collections
Imports PayPal.Payments.Common
Imports PayPal.Payments.Common.Utility
Imports PayPal.Payments.DataObjects
Imports PayPal.Payments.Transactions

Namespace PayPal.Payments.Samples.VB.DataObjects.Fraud
    ''' <summary>
    ''' This class uses the Payflow SDK Data Objects to do a Fraudulent Sale transaction. A pre-requisite 
    ''' to this transaction is to set a value of $50 for the "Purchase Price Ceiling Filter". 
    ''' An amount of $51 is passed to trigger the filter.
    ''' </summary>
    Public Class DOFraudFilters
        Public Sub New()
        End Sub

        Public Shared Sub Main(ByVal Args As String())
            Console.WriteLine("------------------------------------------------------")
            Console.WriteLine("Executing Sample from File: DOFraudFilters.vb")
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
            Dim Amt As Currency = New Currency(New Decimal(550.0))
            Inv.Amt = Amt
            Inv.PoNum = "PO12345"
            Inv.InvNum = "INV12345"

            ' Set the Billing Address details.
            Dim Bill As BillTo = New BillTo
            Bill.BillToStreet = "123 Main St."
            Bill.BillToZip = "12345"
            Bill.BillToEmail = "test@myemail.com"
            Inv.BillTo = Bill

            Dim CustInfo As New CustomerInfo
            CustInfo.CustIP = "10.1.1.1"  ' IP Velocity Filter
            Inv.CustomerInfo = CustInfo

            ' Create a new Payment Device - Credit Card data object.
            ' The input parameters are Credit Card No. and Expiry Date for the Credit Card.
            Dim CC As CreditCard = New CreditCard("4111111111111111", "0115")
            CC.Cvv2 = "444"

            ' Create a new Tender - Card Tender data object.
            Dim Card As CardTender = New CardTender(CC)
            '/////////////////////////////////////////////////////////////////

            ' Create a new Sale Transaction with purchase price ceiling amount filter set to $50.
            Dim Trans As SaleTransaction = New SaleTransaction(User, Connection, Inv, Card, PayflowUtility.RequestId)

            ' Set the Verbosity of the transaction to HIGH to get maximum information in the response.
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
                    Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
                    Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
                    Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
                    Console.WriteLine("HOSTCODE = " + TrxnResponse.HostCode)
                    Console.WriteLine("PROCAVS = " + TrxnResponse.ProcAVS)
                    Console.WriteLine("CVV2MATCH = " + TrxnResponse.CVV2Match)
                End If

                ' Get the Fraud Response parameters.
                Dim FraudResp As FraudResponse = Resp.FraudResponse
                If Not FraudResp Is Nothing Then
                    Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
                    Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
                    ' The following lines of code dealing with PreXmlData and PostXmlData will return all th rules
                    ' that were triggered by the Fraud Service. For Example, let's assume the both AVS and CSC (CVV2)
                    ' failed, the FraudResp.PostFpsMsg would something similar to:
                    ' "Review: More than one rule was triggered for Review".
                    '
                    ' The Fps_PreXmlData is returned as an Xml string. This is converted into Data Objects
                    ' with the object hierarchy as shown below:
                    ' FpsXmlData
                    ' >>>>>>>>> List of Rule objects
                    ' >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
                    Dim PreXmlData As FpsXmlData = FraudResp.Fps_PreXmlData
                    If Not PreXmlData Is Nothing Then
                        ' Get the list of Rules.
                        Dim RulesList As ArrayList = PreXmlData.Rules
                        If Not RulesList Is Nothing AndAlso RulesList.Count > 0 Then
                            Dim RulesEnum As IEnumerator = RulesList.GetEnumerator()
                            Dim DORule As Rule = Nothing
                            ' Loop through the list of Rules.
                            Do While RulesEnum.MoveNext()
                                DORule = CType(RulesEnum.Current, Rule)
                                Console.WriteLine("------------------------------------------------------")
                                Console.WriteLine("PRE-XML DATA")
                                Console.WriteLine("------------------------------------------------------")
                                Console.WriteLine("Rule Number = " + DORule.Num.ToString)
                                Console.WriteLine("Rule Id = " + DORule.RuleId)
                                Console.WriteLine("Rule Alias = " + DORule.RuleAlias)
                                Console.WriteLine("Rule Description = " + DORule.RuleDescription)
                                Console.WriteLine("Action = " + DORule.Action)
                                Console.WriteLine("Triggered Message = " + DORule.TriggeredMessage)

                                ' Get the list of Rule Vendor Parameters.
                                Dim RuleVendorParmsList As ArrayList = DORule.RuleVendorParms

                                If Not RuleVendorParmsList Is Nothing AndAlso RuleVendorParmsList.Count > 0 Then
                                    Dim RuleParametersEnum As IEnumerator = RuleVendorParmsList.GetEnumerator()
                                    ' Loop through the list of Rule Parameters.
                                    Do While RuleParametersEnum.MoveNext()
                                        Dim DORuleParam As RuleParameter = CType(RuleParametersEnum.Current, RuleParameter)
                                        Console.WriteLine("Number = " + DORuleParam.Num.ToString)
                                        Console.WriteLine("Name = " + DORuleParam.Name)
                                        Console.WriteLine("Type = " + DORuleParam.Type)
                                        Console.WriteLine("Value = " + DORuleParam.Value)
                                    Loop
                                End If
                            Loop
                        End If
                    End If
                    ' The Fps_PostXmlData is returned as an Xml string. This is converted into Data Objects
                    ' with the object hierarchy as shown below:
                    ' FpsXmlData
                    ' >>>>>>>>> List of Rule objects
                    ' >>>>>>>>>>>>>>>>>> List of RuleVendorParm objects.
                    Dim PostXmlData As FpsXmlData = FraudResp.Fps_PostXmlData
                    If Not PostXmlData Is Nothing Then
                        ' Get the list of Rules.
                        Dim RulesList As ArrayList = PostXmlData.Rules
                        If Not RulesList Is Nothing AndAlso RulesList.Count > 0 Then
                            Dim RulesEnum As IEnumerator = RulesList.GetEnumerator()
                            Dim DORule As Rule = Nothing
                            ' Loop through the list of Rules.
                            Do While RulesEnum.MoveNext()
                                DORule = CType(RulesEnum.Current, Rule)
                                Console.WriteLine("------------------------------------------------------")
                                Console.WriteLine("POST-XML DATA")
                                Console.WriteLine("------------------------------------------------------")
                                Console.WriteLine("Rule Number = " + DORule.Num.ToString)
                                Console.WriteLine("Rule Id = " + DORule.RuleId)
                                Console.WriteLine("Rule Alias = " + DORule.RuleAlias)
                                Console.WriteLine("Rule Description = " + DORule.RuleDescription)
                                Console.WriteLine("Action = " + DORule.Action)
                                Console.WriteLine("Triggered Message = " + DORule.TriggeredMessage)

                                ' Get the list of Rule Vendor Parameters.
                                Dim RuleVendorParmsList As ArrayList = DORule.RuleVendorParms

                                If Not RuleVendorParmsList Is Nothing AndAlso RuleVendorParmsList.Count > 0 Then
                                    Dim RuleParametersEnum As IEnumerator = RuleVendorParmsList.GetEnumerator()
                                    ' Loop through the list of Rule Parameters.
                                    Do While RuleParametersEnum.MoveNext()
                                        Dim DORuleParam As RuleParameter = CType(RuleParametersEnum.Current, RuleParameter)
                                        Console.WriteLine("Number = " + DORuleParam.Num.ToString)
                                        Console.WriteLine("Name = " + DORuleParam.Name)
                                        Console.WriteLine("Type = " + DORuleParam.Type)
                                        Console.WriteLine("Value = " + DORuleParam.Value)
                                    Loop
                                End If
                            Loop
                        End If
                    End If
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