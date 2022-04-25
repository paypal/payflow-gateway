namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// <para>This is the Payflow Parameter Mapping supported in current release.</para>
	/// <list type='table'><listheader><term>Payflow Param</term><description>Data Object</description><description>Property Reference</description><description>Data type</description></listheader>
	/// <item><term>ABA</term><description>BankAcct</description><description><see cref='BankAcct.Aba'>Aba</see></description><description>String</description></item>
	/// <item><term>ACCT</term><description>BankAcct ,  CreditCard , PurchaseCard , SwipeCard , CheckPayment , RecurringResponse, TransactionResponse</description><description>Acct</description><description>String</description></item>
	/// <item><term>ACCTTYPE</term><description>BankAcct</description><description><see cref='BankAcct.AcctType'>AcctType</see></description><description>String</description></item>
	/// <item><term>ACI</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Aci'>Aci</see></description><description>String</description></item>
	/// <item><term>ACSURL</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.AcsUrl'>AcsUrl</see></description><description>String</description></item>
	/// <item><term>ACTION</term><description>Value is set based on Transaction object used:RecurringAddTransaction, RecurringModifyTransaction, RecurringCancelTransaction, RecurringInquiryTransaction, RecurringReActivateTransaction, RecurringPaymentTransaction</description><description>NA</description><description>String</description></item>
	/// <item><term>ADDLAMTn</term><description>AdviceDetail</description><description><see cref='AdviceDetail.AddLAmt'>AddLAmt</see></description><description>String</description></item>
	/// <item><term>ADDLAMTTYPEn</term><description>AdviceDetail</description><description><see cref='AdviceDetail.AddLAmtType'>AddLAmtType</see></description><description>String</description></item>
	/// <item><term>ADDLMSGS</term><description>TransactionResponse</description><description><see cref='TransactionResponse.AddlMsgs'>AddlMsgs</see></description><description>String</description></item>
	/// <item><term>ADDROVERRIDE</term><description>ECSetRequest</description><description><see cref='ECSetRequest.AddrOverride'>AddrOverride</see></description><description>String</description></item>
	/// <item><term>ADDRSTATUS</term><description>ECGetResponse</description><description><see cref='ECGetResponse.AddressStatus'>AddressStatus</see></description><description>String</description></item>
	/// <item><term>AGGREGATEAMT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.AggregateAmt'>AggregateAmt</see></description><description>String</description></item>
	/// <item><term>AGGREGATEOPTIONALAMT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.AggregateOptionalAmt'>AggregateOptionalAmt</see></description><description>String</description></item>
	/// <item><term>ALTTAXAMT</term><description>Invoice</description><description><see cref='Invoice.AltTaxAmt'>AltTaxAmt</see></description><description>Currency</description></item>
	/// <item><term>AMEXID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.AmexID'>AmexID</see></description><description>String</description></item>
	/// <item><term>AMEXPOSID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.AmexPosData'>AmexPosData</see></description><description>String</description></item>
	/// <item><term>AMT</term><description>Invoice, RecurringResponse ,BuyerAuthVETransaction ,ECDoResponse, TransactionResponse</description><description>Amt</description><description>Currency (Invoice) ,String(RecurringResponse),Currency</description></item>
	/// <item><term>AUTHCODE</term><description>VoiceAuthTransaction,  TransactionResponse</description><description>AuthCode</description><description>String</description></item>
	/// <item><term>AUTHENTICATION_ID</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.Authentication_Id'>Authentication_Id</see></description><description>String</description></item>
	/// <item><term>AUTHENTICATION_STATUS</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.Authentication_Status'>Authentication_Status</see></description><description>String</description></item>
	/// <item><term>AUTHTYPE</term><description>ACHTender</description><description><see cref='AACHTender.'>AuthType</see></description><description>String</description></item>
	/// <item><term>AVSADDR</term><description>TransactionResponse</description><description><see cref='TransactionResponse.AVSAddr'>AVSAddr</see></description><description>String</description></item>
	/// <item><term>AVSZIP</term><description>TransactionResponse</description><description><see cref='TransactionResponse.AVSZip'>AVSZip</see></description><description>String</description></item>
	/// <item><term>BA_CUSTOM</term><description>ECSetRequest</description><description><see cref='ECSetRequest.BA_Custom'>BA_Custom</see></description><description>String</description></item>
	/// <item><term>BA_DESC</term><description>ECSetRequest</description><description><see cref='ECSetRequest.BA_Desc'>BA_Desc</see></description><description>String</description></item>
	/// <item><term>BAID</term><description>ECDoResponse</description><description><see cref='ECDoResponse.BAId'>BAId</see></description><description>String</description></item>
	/// <item><term>BALAMT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.BalAmt'>BalAmt</see></description><description>String</description></item>
	/// <item><term>BILLINGTYPE</term><description>ECSetRequest</description><description><see cref='ECSetRequest.BillingType'>BillingType</see></description><description>String</description></item>
	/// <item><term>BATCHID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.BatchId'>BatchId</see></description><description>String</description></item>
	/// <item><term>BILLINGTYPE</term><description>ECSetRequest</description><description><see cref='ECSetRequest.BillingType'>BillingType</see></description><description>String</description></item>
	/// <item><term>BILLTOCITY</term><description>BillTo, RecurringResponse</description><description>BillToCity</description><description>String</description></item>
	/// <item><term>BILLTOCOUNTRY</term><description>BillTo, RecurringResponse</description><description>BillToCountry</description><description>String</description></item>
	/// <item><term>BILLTOEMAIL</term><description>BillTo,RecurringResponse,ECGetResponse</description><description>BillToEmail</description><description>String</description></item>
	/// <item><term>BILLTOFAX</term><description>BillTo</description><description><see cref='BillTo.BillToFax'>BillToFax</see></description><description>String</description></item>
	/// <item><term>BILLTOFIRSTNAME</term><description>BillTo, RecurringResponse ,ECGetResponse, TransactionResponse</description><description>BillToFirstName</description><description>String</description></item>
	/// <item><term>BILLTOHOMEPHONE</term><description>BillTo</description><description><see cref='BillTo.BillToHomePhone'>BillToHomePhone</see></description><description>String</description></item>
	/// <item><term>BILLTOLASTNAME</term><description>BillTo, RecurringResponse,ECGetResponse, TransactionResponse</description><description>BillToLastName</description><description>String</description></item>
	/// <item><term>BILLTOMIDDLENAME</term><description>BillTo, RecurringResponse</description><description>BillToMiddleName</description><description>String</description></item>
	/// <item><term>BillToPHONENUM</term><description>BillTo, RecurringResponse</description><description>BillToPhoneNum</description><description>String</description></item>
	/// <item><term>BILLTOPHONE2</term><description>BillTo</description><description><see cref='BillTo.BillToPhone2'>BillToPhone2</see></description><description>String</description></item>
	/// <item><term>BILLTOSTATE</term><description>BillTo, RecurringResponse</description><description>BillToState</description><description>String</description></item>
	/// <item><term>BILLTOSTREET</term><description>BillTo, RecurringResponse</description><description>BillToStreet</description><description>String</description></item>
	/// <item><term>BILLTOSTREET2</term><description>BillTo</description><description><see cref='BillTo.BillToStreet2'>BillToStreet2</see></description><description>String</description></item>
	/// <item><term>BILLTOZIP</term><description>BillTo, RecurringResponse</description><description>BillToZip</description><description>String</description></item>
	/// <item><term>BROWSERCOUNTRYCODE</term><description>BrowserInfo</description><description><see cref='BrowserInfo.BrowserCountryCode'>BrowserCountryCode</see></description><description>String</description></item>
	/// <item><term>BROWSERTIME</term><description>BrowserInfo</description><description><see cref='BrowserInfo.BrowserTime'>BrowserTime</see></description><description>String</description></item>
	/// <item><term>BROWSERUSERAGENT</term><description>BrowserInfo</description><description><see cref='BrowserInfo.BrowserUserAgent'>BrowserUserAgent</see></description><description>String</description></item>
	/// <item><term>BUTTONSOURCE</term><description>BrowserInfo</description><description><see cref='BrowserInfo.ButtonSource'>ButtonSource</see></description><description>String</description></item>
	/// <item><term>CANCELURL</term><description>ECSetRequest</description><description><see cref='ECSetRequest.CancelURL'>CancelURL</see></description><description>String</description></item>
	/// <item><term>CAPTURECOMPLETE</term><description>CaptureTransaction</description><description>String</description></item>
	/// <item><term>CARDISSUE</term><description>PurchaseCard, CreditCard</description><description>CardIssue</description><description>String</description></item>
	/// <item><term>CARDSECURE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.CardSecure'>CardSecure</see></description><description>String</description></item>
	/// <item><term>CARDSTART</term><description>PurchaseCard, CreditCard</description><description>CardStart</description><description>String</description></item>
	/// <item><term>CARDTYPE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.CardType'>CardType</see></description><description>String</description></item>
	/// <item><term>CATTYPE</term><description>Devices</description><description><see cref='Devices.CatType'>CatType</see></description><description>String</description></item>
	/// <item><term>CAVV</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.CAVV'>CAVV</see></description><description>String</description></item>
	/// <item><term>CCTRANSID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.CCTransId'>CCTransId</see></description><description>String</description></item>
	/// <item><term>CCTRANS_POSDATA</term><description>TransactionResponse</description><description><see cref='TransactionResponse.CCTrans_POSData'>CCTrans_POSData</see></description><description>String</description></item>
	/// <item><term>CHKNUM</term><description>ACHTender, CheckTender, CardTender</description><description>ChkNum</description><description>String</description></item>
	/// <item><term>CHKTYPE</term><description>ACHTender, CheckTender, CardTender</description><description>ChkType</description><description>String</description></item>
	/// <item><term>CITDATE</term><description>Invoice</description><description><see cref='Invoice.CitDate'>CitDate</see></description><description>String</description></item>
	/// <item><term>COMMCARD</term><description>PurchaseCard</description><description></description><description>String</description></item>
	/// <item><term>COMMCODE</term><description>Invoice</description><description><see cref='Invoice.CommCode'>CommCode</see></description><description>String</description></item>
	/// <item><term>COMMENT1</term><description>Invoice</description><description><see cref='Invoice.Comment1'>Comment1</see></description><description>String</description></item>
	/// <item><term>COMMENT2</term><description>Invoice</description><description><see cref='Invoice.Comment2'>Comment2</see></description><description>String</description></item>
	/// <item><term>COMPANYNAME</term><description>BillTo, RecurringResponse</description><description>CompanyName</description><description>String</description></item>
	/// <item><term>CONTACTLESS</term><description>Devices</description><description><see cref='Devices.Contactless'>Contactless</see></description><description>String</description></item>
	/// <item><term>COUNTRYCODE</term><description>BillTo,ECGetResponse</description><description>CountryCode</description><description>String</description></item>
	/// <item><term>COUNTRYCODE</term><description>ExpressCheckoutRequest</description><description><see cref='ExpressCheckoutRequest.CountryCode'>CountryCode</see></description><description>String</description></item>
	/// <item><term>CURRENCY</term><description>BuyerAuthVETransaction</description><description></description><description>Currency</description></item>
	/// <item><term>CUSTCODE</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustCode'>CustCode</see></description><description>String</description></item>
	/// <item><term>CUSTDATA</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustData'>CustData</see></description><description>String</description></item>
	/// <item><term>CUSTID</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustId'>CustId</see></description><description>String</description></item>
	/// <item><term>CUSTIP</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustIP'>CustIP</see></description><description>String</description></item>
	/// <item><term>CUSTOM</term><description>BrowserInfo</description><description><see cref='BrowserInfo.Custom'>Custom</see></description><description>String</description></item>
	/// <item><term>CUSTOMERID</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustomerId'>CustomerId</see></description><description>String</description></item>
	/// <item><term>CUSTOMERNUMBER</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustomerNumber'>CustomerNumber</see></description><description>String</description></item>
	/// <item><term>CUSTREF</term><description>Invoice, TransactionResponse</description><description>CustRef</description><description>String</description></item>
	/// <item><term>CUSTVATREGNUM</term><description>CustomerInfo</description><description><see cref='CustomerInfo.CustVatRegNum'>CustVatRegNum</see></description><description>String</description></item>
	/// <item><term>CVV2</term><description>PurchaseCard, CreditCard</description><description>CVV2</description><description>String</description></item>
	/// <item><term>CVV2MATCH</term><description>TransactionResponse</description><description><see cref='TransactionResponse.CVV2Match'>CVV2Match</see></description><description>String</description></item>
	/// <item><term>DATETOSETTLE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.DateToSettle'>DateToSettle</see></description><description>String</description></item>
	/// <item><term>DESC</term><description>Invoice</description><description><see cref='Invoice.Desc'>Desc</see></description><description>String</description></item>
	/// <item><term>DESC1</term><description>Invoice</description><description><see cref='Invoice.Desc1'>Desc1</see></description><description>String</description></item>
	/// <item><term>DESC2</term><description>Invoice</description><description><see cref='Invoice.Desc2'>Desc2</see></description><description>String</description></item>
	/// <item><term>DESC3</term><description>Invoice</description><description><see cref='Invoice.Desc3'>Desc3</see></description><description>String</description></item>
	/// <item><term>DESC4</term><description>Invoice</description><description><see cref='Invoice.Desc4'>Desc4</see></description><description>String</description></item>
	/// <item><term>DISCOUNT</term><description>Invoice</description><description><see cref='Invoice.Discount'>Discount</see></description><description>Currency</description></item>
	/// <item><term>DL</term><description>BaseTender</description><description><see cref='BaseTender.DL'>DL</see></description><description>String</description></item>
	/// <item><term>DOB</term><description>CustomerInfo</description><description><see cref='CustomerInfo.DOB'>DOB</see></description><description>String</description></item>
	/// <item><term>DUPLICATE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Duplicate'>Duplicate</see></description><description>String</description></item>
	/// <item><term>DUTYAMT</term><description>Invoice</description><description><see cref='Invoice.DutyAmt'>DutyAmt</see></description><description>Currency</description></item>
	/// <item><term>ECI</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.ECI'>ECI</see></description><description>String</description></item>
	/// <item><term>EMAILMATCH</term><description>TransactionResponse</description><description><see cref='TransactionResponse.EmailMatch'>EmailMatch</see></description><description>String</description></item>
	/// <item><term>ENDTIME</term><description>Invoice, TransactionResponse</description><description>EndTime</description><description>DateTime</description></item>
	/// <item><term>EXCHANGERATE</term><description>ECDoResponse</description><description><see cref='ECDoResponse.ExchangeRate'>ExchangeRate</see></description><description>String</description></item>
	/// <item><term>EXPDATE</term><description>CreditCard, PurchaseCard, RecurringResponse, TransactionResponse</description><description>ExpDate</description><description>String</description></item>
	/// <item><term>EXTRSPMSG</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ExtRspMsg'>ExtRspMsg</see></description><description>String</description></item>
	/// <item><term>FEEAMT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.FeeAmt'>FeeAmt</see></description><description>String</description></item>
	/// <item><term>FPS_POSTXMLDATA</term><description>FraudResponse</description><description><see cref='FraudResponse.Fps_PostXmlData'>Fps_PostXmlData</see></description><description>FpsXmlData object</description></item>
	/// <item><term>FPS_PREXMLDATA</term><description>FraudResponse</description><description><see cref='FraudResponse.Fps_PreXmlData'>Fps_PreXmlData</see></description><description>FpsXmlData object</description></item>
	/// <item><term>FREIGHTAMT</term><description>Invoice</description><description><see cref='Invoice.FreightAmt'>FreightAmt</see></description><description>Currency</description></item>
	/// <item><term>HANDLINGAMT</term><description>Invoice</description><description><see cref='Invoice.HandlingAmt'>HandlingAmt</see></description><description>Currency</description></item>
	/// <item><term>HDRBACKCOLOR</term><description>ECSetRequest</description><description><see cref='ECSetRequest.HeaderBackColor'>HeaderBackColor</see></description><description>String</description></item>
	/// <item><term>HDRBORDERCOLOR</term><description>ECSetRequest</description><description><see cref='ECSetRequest.HeaderBorderColor'>HeaderBorderColor</see></description><description>String</description></item>
	/// <item><term>HDRIMG</term><description>ECSetRequest</description><description><see cref='ECSetRequest.HeaderImage'>HeaderImage</see></description><description>String</description></item>
	/// <item><term>HOSTADDRESS</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.HostAddress'>HostAddress</see></description><description>String</description></item>
	/// <item><term>HOSTCODE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.HostCode'>HostCode</see></description><description>String</description></item>
	/// <item><term>HOSTPORT</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.HostPort'>HostPort</see></description><description>int</description></item>
	/// <item><term>IAVS</term><description>TransactionResponse</description><description><see cref='TransactionResponse.IAVS'>IAVS</see></description><description>String</description></item>
	/// <item><term>INVNUM</term><description>Invoice</description><description><see cref='Invoice.InvNum'>InvNum</see></description><description>String</description></item>
	/// <item><term>INVOICEDATE</term><description>Invoice</description><description><see cref='Invoice.InvoiceDate'>InvoiceDate</see></description><description>Date</description></item>
	/// <item><term>L_ALTTAXAMTn</term><description>LineItem</description><description><see cref='LineItem.AltTaxAmt'>AltTaxAmt</see></description><description>Currency</description></item>
	/// <item><term>L_ALTTAXIDn</term><description>LineItem</description><description><see cref='LineItem.AltTaxId'>AltTaxId</see></description><description>Currency</description></item>
	/// <item><term>L_ALTTAXRATEn</term><description>LineItem</description><description><see cref='LineItem.AltTaxRate'>AltTaxRate</see></description><description>Currency</description></item>
	/// <item><term>L_AMTn</term><description>LineItem</description><description><see cref='LineItem.Amt'>Amt</see></description><description>Currency</description></item>
	/// <item><term>L_CARRIERSERVICELEVELCODEn</term><description>LineItem</description><description><see cref='LineItem.CarrierServiceLevelCode'>CarrierServiceLevelCode</see></description><description>Currency</description></item>
	/// <item><term>L_CATALOGNUMn</term><description>LineItem</description><description><see cref='LineItem.CatalogNum'>CatalogNum</see></description><description>String</description></item>
	/// <item><term>L_COMMCODEn</term><description>LineItem</description><description><see cref='LineItem.CommCode'>CommCode</see></description><description>String</description></item>
	/// <item><term>L_COSTCENTERNUMn</term><description>LineItem</description><description><see cref='LineItem.CostCenterNum'>CostCenterNum</see></description><description>String</description></item>
	/// <item><term>L_COSTn</term><description>LineItem</description><description><see cref='LineItem.Cost'>Cost</see></description><description>Currency</description></item>
	/// <item><term>L_DESCn</term><description>LineItem</description><description><see cref='LineItem.Desc'>Desc</see></description><description>String</description></item>
	/// <item><term>L_DISCOUNTn</term><description>LineItem</description><description><see cref='LineItem.Discount'>Discount</see></description><description>Currency</description></item>
	/// <item><term>L_EXTAMTn</term><description>LineItem</description><description><see cref='LineItem.ExtAmt'>ExtAmt</see></description><description>Currency</description></item>
	/// <item><term>L_FREIGHTAMTn</term><description>LineItem</description><description><see cref='LineItem.FreightAmt'>FreightAmt</see></description><description>Currency</description></item>
	/// <item><term>L_HANDLINGAMTn</term><description>LineItem</description><description><see cref='LineItem.HandlingAmt'>HandlingAmt</see></description><description>Currency</description></item>
	/// <item><term>L_MANUFACTURERn</term><description>LineItem</description><description><see cref='LineItem.Manufacturer'>Manufacturer</see></description><description>String</description></item>
	/// <item><term>L_PICKUPCITYn</term><description>LineItem</description><description><see cref='LineItem.PickupCity'>PickupCity</see></description><description>String</description></item>
	/// <item><term>L_PICKUPCOUNTRYn</term><description>LineItem</description><description><see cref='LineItem.PickupCountry'>PickupCountry</see></description><description>String</description></item>
	/// <item><term>L_PICKUPSTATEn</term><description>LineItem</description><description><see cref='LineItem.PickupState'>PickupState</see></description><description>String</description></item>
	/// <item><term>L_PICKUPSTREETn</term><description>LineItem</description><description><see cref='LineItem.PickupStreet'>PickupStreet</see></description><description>String</description></item>
	/// <item><term>L_PICKUPZIPn</term><description>LineItem</description><description><see cref='LineItem.PickupZip'>PickupZip</see></description><description>String</description></item>
	/// <item><term>L_PRODCODEn</term><description>LineItem</description><description><see cref='LineItem.ProdCode'>ProdCode</see></description><description>String</description></item>
	/// <item><term>L_QTYn</term><description>LineItem</description><description><see cref='LineItem.Qty'>Qty</see></description><description>int</description></item>
	/// <item><term>L_SKUn</term><description>LineItem</description><description><see cref='LineItem.SKU'>SKU</see></description><description>String</description></item>
	/// <item><term>L_TAXAMTn</term><description>LineItem</description><description><see cref='LineItem.TaxAmt'>TaxAmt</see></description><description>Currency</description></item>
	/// <item><term>L_TAXRATEn</term><description>LineItem</description><description><see cref='LineItem.TaxRate'>TaxRate</see></description><description>Currency</description></item>
	/// <item><term>L_TAXTYPEn</term><description>LineItem</description><description><see cref='LineItem.TaxType'>TaxType</see></description><description>String</description></item>
	/// <item><term>L_TRACKINGNUMn</term><description>LineItem</description><description><see cref='LineItem.TrackingNum'>TrackingNum</see></description><description>String</description></item>
	/// <item><term>L_TYPEn</term><description>LineItem</description><description><see cref='LineItem.Type'>Type</see></description><description>String</description></item>
	/// <item><term>L_UNSPSCCODEn</term><description>LineItem</description><description><see cref='LineItem.UnspscCode'>UnspscCode</see></description><description>String</description></item>
	/// <item><term>L_UOMn</term><description>LineItem</description><description><see cref='LineItem.UOM'>UOM</see></description><description>String</description></item>
	/// <item><term>L_UPCn</term><description>LineItem</description><description><see cref='LineItem.UPC'>UPC</see></description><description>String</description></item>
	/// <item><term>LOCALECODE</term><description>ECSetRequest</description><description><see cref='ECSetRequest.LocaleCode'>LocaleCode</see></description><description>String</description></item>
	/// <item><term>LOCALTAXAMT</term><description>Invoice</description><description><see cref='Invoice.LocalTaxAmt'>LocalTaxAmt</see></description><description>Currency</description></item>
	/// <item><term>MAXAMT</term><description>ECSetRequest</description><description><see cref='ECSetRequest.MaxAmt'>MaxAmt</see></description><description>String</description></item>
	/// <item><term>MAXFAILPAYMENTS</term><description>RecurringResponse, RecurringInfo</description><description>MaxFailPayments</description><description>String</description></item>
	/// <item><term>MD</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.MD'>MD</see></description><description>String</description></item>
	/// <item><term>MERCHDESCR</term><description>PurchaseCard, CreditCard</description><description><see cref='MerchantInfo.MerchDescr'>MerchDescr</see></description><description>String</description></item>
	/// <item><term>MERCHSVC</term><description>PurchaseCard, CreditCard</description><description><see cref='MerchantInfo.MerchSvc'>MerchSvc</see></description><description>String</description></item>
	/// <item><term>MERCHANTCITY</term><description>CMerchantInfo</description><description><see cref='MerchantInfo.MerchantCity'>MerchantCity</see></description><description>String</description></item>
	/// <item><term>MERCHANTCONTACTINFO</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantContactInfo'>MerchantContactInfo</see></description><description>String</description></item>
	/// <item><term>MERCHANTID</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantId'>MerchantId</see></description><description>String</description></item>
	/// <item><term>MERCHANTINVNUM</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantInvNum'>>MerchantInvNum</see></description><description>String</description></item> 
	/// <item><term>MERCHANTLOCATIONID</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantLocationId'>MerchantLocationId</see></description><description>String</description></item>
	/// <item><term>MERCHANTNAME</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantName'>MerchantName</see></description><description>String</description></item>
	/// <item><term>MERCHANTSTATE</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantState'>MerchantState</see></description><description>String</description></item> 
	/// <item><term>MERCHANTSTREET</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantStreet'>MerchantStreet</see></description><description>String</description></item>
	/// <item><term>MERCHANTURL</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantUrl'>MerchantUrl</see></description><description>String</description></item> 
	/// <item><term>MERCHANTVATNUM</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantVatNum'>MerchantVatNum</see></description><description>String</description></item> 
	/// <item><term>MERCHANTZIP</term><description>MerchantInfo</description><description><see cref='MerchantInfo.MerchantZip'>MerchantZip</see></description><description>String</description></item> 
	/// <item><term>MICR</term><description>CheckPayment</description><description></description><description>String</description></item>
	/// <item><term>MISCDATA</term><description>Invoice</description><description><see cref='Invoice.MiscData'>MiscData</see></description><description>Currency</description></item>
	/// <item><term>NAME</term><description>BankAcct, CreditCard, PurchaseCard, SwipeCard, CheckPayment, RecurringResponse</description><description>Name</description><description>String</description></item>
	/// <item><term>NATIONALTAXAMT</term><description>Invoice</description><description><see cref='Invoice.NationalTaxAmt'>NationalTaxAmt</see></description><description>Currency</description></item>
	/// <item><term>NEXTPAYMENT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.NextPayment'>NextPayment</see></description><description>String</description></item>
	/// <item><term>NOSHIPPING</term><description>ECSetRequest</description><description><see cref='ECSetRequest.NoShipping'>NoShipping</see></description><description>String</description></item>
	/// <item><term>NOTIFYURL</term><description>BrowserInfo</description><description><see cref='BrowserInfo.NotifyURL'>NotifyURL</see></description><description>String</description></item>
	/// <item><term>OPTIONALTRX</term><description>RecurringInfo</description><description><see cref='RecurringInfo.OptionalTrx'>OptionalTrx</see></description><description>String</description></item>
	/// <item><term>OPTIONALTRXAMT</term><description>RecurringInfo</description><description><see cref='RecurringInfo.OptionalTrxAmt'>OptionalTrxAmt</see></description><description>Currency</description></item>
	/// <item><term>ORDERDATE</term><description>Invoice</description><description><see cref='Invoice.OrderDate'>OrderDate</see></description><description>String</description></item>
	/// <item><term>ORDERDESC</term><description>Invoice</description><description><see cref='Invoice.OrderDesc'>OrderDesc</see></description><description>String</description></item>
	/// <item><term>ORDERID</term><description>Invoice</description><description><see cref='Invoice.OrderId'>OrderId</see></description><description>String</description></item>
	/// <item><term>ORDERTIME</term><description>Invoice</description><description><see cref='Invoice.OrderTime'>OrderTime</see></description><description>String</description></item>
	/// <item><term>ORIGAMT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.OrigAmt'>OrigAmt</see></description><description>String</description></item>
	/// <item><term>ORIGID</term><description>ReferenceTransaction, CaptureTransaction, FraudReviewTransaction, InquiryTransaction, VoidTransaction</description><description>OrigId</description><description>String</description></item>
	/// <item><term>ORIGPROFILEID</term><description>RecurringInfo</description><description><see cref='RecurringInfo.OrigProfileId'>OrigProfileId</see></description><description>String</description></item>
	/// <item><term>ORIGRESULT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.OrigResult'>OrigResult</see></description><description>String</description></item>
	/// <item><term>P_AMTn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>P_PNREFn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>P_RESULTn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>P_TENDERn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>P_TRANSTATEn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>P_TRANSTIMEn</term><description>RecurringResponse</description><description><see cref='RecurringResponse.InquiryParams'>InquiryParams</see></description><description>String</description></item>
	/// <item><term>PAGESTYLE</term><description>ECSetRequest</description><description><see cref='ECSetRequest.PageStyle'>PageStyle</see></description><description>String</description></item>
	/// <item><term>PAR</term><description>Invoice</description><description><see cref='Invoice.Par'>Par</see></description><description>String</description></item>
	/// <item><term>PAREQ</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.PaReq'>PaReq</see></description><description>String</description></item>
	/// <item><term>PARES</term><description>BuyerAuthVATransaction</description><description></description><description>String</description></item>
	/// <item><term>PARID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ParId'>ParId</see ></description><description>String</description></item >
	/// <item><term>PARTIALAUTH</term><description>AuthorizationTransaction</description><description></description><description>String</description></item>
	/// <item><term>PARTNER</term><description>UserInfo</description><description></description><description>String</description></item>
	/// <item><term>PAYERID</term><description>ECDoRequest ,ECGetResponse</description><description>PayerId</description><description>String</description></item>
	/// <item><term>PAYERSTATUS</term><description>ECGetResponse</description><description><see cref='ECGetResponse.PayerStatus'>PayerStatus</see></description><description>String</description></item>
	/// <item><term>PAYFLOWCOLOR</term><description>ECSetRequest</description><description><see cref='ECSetRequest.PayFlowColor'>PayFlowColor</see></description><description>String</description></item>
	/// <item><term>PAYMENTDATE</term><description>ECDoResponse</description><description><see cref='ECDoResponse.PaymentDate'>PaymentDate</see></description><description>String</description></item>
	/// <item><term>PAYMENTHISTORY</term><description>RecurringInfo</description><description><see cref='RecurringInfo.PaymentHistory'>PaymentHistory</see></description><description>String</description></item>
	/// <item><term>PAYMENTNUM</term><description>RecurringInfo</description><description><see cref='RecurringInfo.PaymentNum'>PaymentNum</see></description><description>String</description></item>
	/// <item><term>PAYMENTSLEFT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.PaymentsLeft'>PaymentsLeft</see></description><description>String</description></item>
	/// <item><term>PAYMENTSTATUS</term><description>ECDoResponse</description><description><see cref='ECDoResponse.PaymentStatus'>PaymentStatus</see></description><description>String</description></item>
	/// <item><term>PAYMENTTYPE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.PaymentType'>PaymentType</see></description><description>String</description></item>
	/// <item><term>PAYPALCHECKOUTBTNTYPE</term><description>PayLater</description><description><see cref='PayLater.PayPalCheckoutBtnType'>PayPalCheckoutBtnType</see></description><description>String</description></item>
	/// <item><term>PAYPERIOD</term><description>RecurringResponse, RecurringInfo</description><description>PayPeriod</description><description>String</description></item>
	/// <item><term>PENDINGREASON</term><description>TransactionResponse</description><description><see cref='TransactionResponse.PendingReason'>PendingReason</see></description><description>String</description></item>
	/// <item><term>PHONEMATCH</term><description>TransactionResponse</description><description><see cref='TransactionResponse.PhoneMatch'>PhoneMatch</see></description><description>String</description></item>
	/// <item><term>PNREF</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Pnref'>Pnref</see></description><description>String</description></item>
	/// <item><term>PONUM</term><description>Invoice</description><description><see cref='Invoice.PoNum'>PoNum</see></description><description>String</description></item>
	/// <item><term>POSTALCODE</term><description>ExpressCheckoutRequest</description><description><see cref='ExpressCheckoutRequest.PostalCode'>PostalCode</see></description><description>String</description></item>
	/// <item><term>POSTFPSMSG</term><description>FraudResponse</description><description><see cref='FraudResponse.PostFpsMsg'>PostFpsMsg</see></description><description>String</description></item>
	/// <item><term>PPREF</term><description>TransactionResponse</description><description><see cref='TransactionResponse.PPref'>PPref</see></description><description>String</description></item>
	/// <item><term>PREFPSMSG</term><description>FraudResponse</description><description><see cref='FraudResponse.PreFpsMsg'>PreFpsMsg</see></description><description>String</description></item>
	/// <item><term>PRENOTE</term><description>ACHTender</description><description><see cref='ACHTender.PreNote'>PreNote</see></description><description>String</description></item>
	/// <item><term>PROCAVS</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ProcAVS'>ProcAVS</see></description><description>String</description></item>
	/// <item><term>PROCCARDSECURE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ProcCardSecure'>ProcCardSecure</see></description><description>String</description></item>
	/// <item><term>PROCCVV2</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ProcCVV2'>ProcCVV2</see></description><description>String</description></item>
	/// <item><term>PRODUCTCATEGORY</term><description>PayLater</description><description><see cref='PayLater.ProductCategory'>ProductCategory</see></description><description>String</description></item>
	/// <item><term>PROFILEADDRESSCHANGEDATE</term><description>PayLater</description><description><see cref='PayLater.ProfileAddressChangeDate'>ProfileAddressChangeDate</see></description><description>String</description></item>
	/// <item><term>PROFILEID</term><description>RecurringResponse</description><description><see cref='RecurringResponse.ProfileId'>ProfileId</see></description><description>String</description></item>
	/// <item><term>PROFILENAME</term><description>RecurringResponse, RecurringInfo</description><description>ProfileName</description><description>String</description></item>
	/// <item><term>PROMOCODE</term><description>PayLaterLineItem</description><description><see cref='PayLaterLineItem.PromoCode'>PromoCode</see></description><description>String</description></item>
	/// <item><term>PROMOCODEOVERRIDE</term><description>PayLater</description><description><see cref='PayLater.PromoCodeOverride'>PromoCodeOverride</see></description><description>String</description></item>
	/// <item><term>PROXYADDRESS</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.ProxyAddress'>ProxyAddress</see></description><description>String</description></item>
	/// <item><term>PROXYLOGON</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.ProxyLogon'>ProxyLogon</see></description><description>String</description></item>
	/// <item><term>PROXYPASSWORD</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.ProxyPassword'>ProxyPassword</see></description><description>String</description></item>
	/// <item><term>PROXYPORT</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.ProxyPort'>ProxyPort</see></description><description>int</description></item>
	/// <item><term>PUR_DESC</term><description>BuyerAuthVETransaction</description><description></description><description>String</description></item>
	/// <item><term>PWD</term><description>UserInfo</description><description></description><description>String</description></item>
	/// <item><term>RECURRING</term><description>RecurringInfo, Invoice</description><description>Recurring</description><description>String</description></item>
	/// <item><term>RECURRINGTYPE</term><description>Invoice</description><description><see cref='Invoice.RecurringType'>RecurringType</see></description><description>String</description></item>
	/// <item><term>REPORTGROUP</term><description>Invoice</description><description><see cref='Invoice.ReportGroup'>ReportGroup</see></description><description>Currency</description></item>
	/// <item><term>REQCONFIRMSHIPPING</term><description>ECSetRequest</description><description><see cref='ECSetRequest.ReqConfirmShipping'>ReqConfirmShipping</see></description><description>String</description></item>
	/// <item><term>REQNAME</term><description>CustomerInfo</description><description><see cref='CustomerInfo.ReqName'>ReqName</see></description><description>String</description></item>
	/// <item><term>RESPMSG</term><description>TransactionResponse</description><description><see cref='TransactionResponse.RespMsg'>RespMsg</see></description><description>String</description></item>
	/// <item><term>RESPTEXT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.RespText'>RespText</see></description><description>String</description></item>
	/// <item><term>RESULT</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Result'>Result</see></description><description>String</description></item>
	/// <item><term>RETRYNUMDAYS</term><description>RecurringResponse, RecurringInfo</description><description>RetryNumDays</description><description>String</description></item>
	/// <item><term>RETURNURL</term><description>ECSetRequest</description><description><see cref='ECSetRequest.ReturnURL'>ReturnURL</see></description><description>String</description></item>
	/// <item><term>RPREF</term><description>RecurringResponse</description><description><see cref='RecurringResponse.RPRef'>RPRef</see></description><description>String</description></item>
	/// <item><term>RRN</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Rrn'>Rrn</see></description><description>String</description></item>
	/// <item><term>SCAEXEMPTION</term><description>Invoice</description><description><see cref='Invoice.SCAExemption'>SCAExemption</see></description><description>String</description></item>
	/// <item><term>SECURETOKEN</term><description>TransactionResponse</description><description><see cref='TransactionResponse.SecureToken'>SecureToken</see></description><description>String</description></item>
	/// <item><term>SECURETOKENID</term><description>TransactionResponse</description><description><see cref='TransactionResponse.SecureTokenId'>SecureTokenId</see></description><description>String</description></item>
	/// <item><term>SETTLEAMT</term><description>ECDoResponse</description><description><see cref='ECDoResponse.SettleAmt'>SettleAmt</see></description><description>String</description></item>
	/// <item><term>SHIPCARRIER</term><description>ShipTo</description><description><see cref='ShipTo.ShipCarrier'>ShipCarrier</see></description><description>String</description></item>
	/// <item><term>SHIPFROMZIP</term><description>ShipTo</description><description><see cref='ShipTo.ShipFromZip'>ShipFromZip</see></description><description>String</description></item>
	/// <item><term>SHIPMETHOD</term><description>ShipTo</description><description><see cref='ShipTo.ShipMethod'>ShipMethod</see></description><description>String</description></item>
	/// <item><term>SHIPPEDFROMZIP</term><description>ShipTo</description><description><see cref='ShipTo.ShipFromZip'>ShipFromZip</see></description><description>String</description></item>
	/// <item><term>SHIPPINGMETHOD</term><description>PayLater</description><description><see cref='PayLater.ShippingMethod'>ShippingMethod</see></description><description>String</description></item>
	/// <item><term>SHIPTOBUSINESS</term><description>ECGetResponse</description><description><see cref='ECGetResponse.ShipToBusiness'>ShipToBusiness</see></description><description>String</description></item>
	/// <item><term>SHIPTOCITY</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToCity</description><description>String</description></item>
	/// <item><term>SHIPTOCOUNTRY</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToCountry</description><description>String</description></item>
	/// <item><term>SHIPTOEMAIL</term><description>ShipTo</description><description><see cref='ShipTo.ShipToEmail'>ShipToEmail</see></description><description>String</description></item>
	/// <item><term>SHIPTOFIRSTNAME</term><description>ShipTo, RecurringResponse ,ECGetResponse</description><description>ShipToFirstName</description><description>String</description></item>
	/// <item><term>SHIPTOLASTNAME</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToLastName</description><description>String</description></item>
	/// <item><term>SHIPTOMIDDLENAME</term><description>ShipTo, RecurringResponse</description><description>ShipToMiddleName</description><description>String</description></item>
	/// <item><term>SHIPTOPHONE</term><description>ShipTo</description><description><see cref='ShipTo.ShipToPhone'>ShipToPhone</see></description><description>String</description></item>
	/// <item><term>SHIPTOPHONE2</term><description>ShipTo</description><description><see cref='ShipTo.ShipToPhone2'>ShipToPhone2</see></description><description>String</description></item>
	/// <item><term>SHIPTOSTATE</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToState</description><description>String</description></item>
	/// <item><term>SHIPTOSTREET</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToStreet</description><description>String</description></item>
	/// <item><term>SHIPTOSTREET2</term><description>ShipTo, ECGetResponse</description><description><see cref='ShipTo.ShipToStreet2'>ShipToStreet2</see></description><description>String</description></item>
	/// <item><term>SHIPTOZIP</term><description>ShipTo, RecurringResponse,ECGetResponse</description><description>ShipToZip</description><description>String</description></item>
	/// <item><term>SS</term><description>CheckTender</description><description></description><description>String</description></item>
	/// <item><term>STAN</term><description>TransactionResponse</description><description><see cref='TransactionResponse.Stan'>Stan</see></description><description>String</description></item>
	/// <item><term>START</term><description>RecurringResponse, RecurringInfo</description><description>Start</description><description>String</description></item>
	/// <item><term>STARTTIME</term><description>Invoice, TransactionResponse</description><description>StartTime</description><description>String</description></item>
	/// <item><term>STATUS</term><description>RecurringResponse</description><description><see cref='RecurringResponse.Status'>Status</see></description><description>String</description></item>
	/// <item><term>SWIPE</term><description>SwipeCard</description><description></description><description>String</description></item>
	/// <item><term>TAXAMT</term><description>Invoice ,ECDoResponse</description><description>TaxAmt</description><description>Currency</description></item>
	/// <item><term>TAXEXEMPT </term><description>Invoice</description><description><see cref='Invoice.TaxExempt'>TaxExempt</see></description><description>Boolean</description></item>
	/// <item><term>TENDER</term><description>Value is set based on Data object used:ACHTender, CardTender, CheckTender. Used in RecurringResponse also.</description><description>Tender</description><description>String</description></item>
	/// <item><term>TERM</term><description>RecurringResponse, RecurringInfo</description><description>Term</description><description>String</description></item>
	/// <item><term>TERMCITY</term><description>ACHTender</description><description><see cref='ACHTender.TermCity'>TermCity</see></description><description>String</description></item>
	/// <item><term>TERMSTATE</term><description>ACHTender</description><description><see cref='ACHTender.TermState'>TermState</see></description><description>String</description></item>
	/// <item><term>TIMEOUT</term><description>PayflowConnectionData</description><description><see cref='PayflowConnectionData.TimeOut'>TimeOut</see></description><description>int</description></item>
	/// <item><term>TOKEN</term><description>ExpressCheckoutRequest</description><description><see cref='ExpressCheckoutRequest.Token'>Token</see></description><description>String</description></item>
	/// <item><term>TRANSSTATE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.TransState'>TransState</see></description><description>String</description></item>
	/// <item><term>TRANSTIME</term><description>TransactionResponse</description><description><see cref='TransactionResponse.TransTime'>TransTime</see></description><description>String</description></item>
	/// <item><term>TRXPNREF</term><description>RecurringResponse</description><description><see cref='RecurringResponse.TrxPNRef'>TrxPNRef</see></description><description>String</description></item>
	/// <item><term>TRXRESPMSG</term><description>RecurringResponse</description><description><see cref='RecurringResponse.TrxRespMsg'>TrxRespMsg</see></description><description>String</description></item>
	/// <item><term>TRXRESULT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.TrxResult'>TrxResult</see></description><description>String</description></item>
	/// <item><term>TRXTYPE</term><description>Value is set based on the Transaction object used:SaleTransaction, CreditTransaction, VoidTransaction, CaptureTransaction etc.</description><description>TrxType</description><description>String</description></item>
	/// <item><term>TXID</term><description>BuyerAuthResponse</description><description><see cref='TransactionResponse.TxId'>TxId</see></description><description>String</description></item>
	/// <item><term>USER</term><description>UserInfo</description><description></description><description>String</description></item>
	/// <item><term>USER1</term><description>UserItem</description><description><see cref='UserItem.UserItem1'>UserItem1</see></description><description>String</description></item>
	/// <item><term>USER2</term><description>UserItem</description><description><see cref='UserItem.UserItem2'>UserItem2</see></description><description>String</description></item>
	/// <item><term>USER3</term><description>UserItem</description><description><see cref='UserItem.UserItem3'>UserItem3</see></description><description>String</description></item>
	/// <item><term>USER4</term><description>UserItem</description><description><see cref='UserItem.UserItem4'>UserItem4</see></description><description>String</description></item>
	/// <item><term>USER5</term><description>UserItem</description><description><see cref='UserItem.UserItem5'>UserItem5</see></description><description>String</description></item>
	/// <item><term>USER6</term><description>UserItem</description><description><see cref='UserItem.UserItem6'>UserItem6</see></description><description>String</description></item>
	/// <item><term>USER7</term><description>UserItem</description><description><see cref='UserItem.UserItem7'>UserItem7</see></description><description>String</description></item>
	/// <item><term>USER8</term><description>UserItem</description><description><see cref='UserItem.UserItem8'>UserItem8</see></description><description>String</description></item>
	/// <item><term>USER9</term><description>UserItem</description><description><see cref='UserItem.UserItem9'>UserItem9</see></description><description>String</description></item>
	/// <item><term>USER10</term><description>UserItem</description><description><see cref='UserItem.UserItem10'>UserItem10</see></description><description>String</description></item>
	/// <item><term>VALIDATRIONCODE</term><description>TransactionResponse</description><description><see cref='TransactionResponse.ValidationCode'>ValidationCode</see></description><description>String</description></item>
	/// <item><term>VATINVNUM</term><description>Invoice</description><description><see cref='Invoice.VatInvNum'>VatInvNum</see></description><description>String</description></item>
	/// <item><term>VATREGNUM</term><description>Invoice</description><description><see cref='Invoice.VatRegNum'>VatRegNum</see></description><description>String</description></item>
	/// <item><term>VATTAXAMT</term><description>Invoice</description><description><see cref='Invoice.VatTaxAmt'>VatTaxAmt</see></description><description>Currency</description></item>
	/// <item><term>VATTAXPERCENT</term><description>Invoice</description><description><see cref='Invoice.VatTaxPercent'>VatTaxPercent</see></description><description>String</description></item>
	/// <item><term>VATTAXRATE</term><description>Invoice</description><description><see cref='Invoice.VatTaxRate'>VatTaxRate</see></description><description>String</description></item>
	/// <item><term>VENDOR</term><description>UserInfo</description><description></description><description>String</description></item>
	/// <item><term>VERBOSITY</term><description>Value is set based on the Transaction object used:SaleTransaction, CreditTransaction, VoidTransaction, CaptureTransaction, AuthorizationTransaction, VoiceAuthTransaction, InquiryTransaction, FraudReviewTransaction, RecurringAddTransaction, RecurringModifyTransaction, RecurringCancelTransaction, RecurringInquiryTransaction, RecurringReActivateTransaction, RecurringPaymentTransaction</description><description>Verbosity</description><description>String</description></item>
	/// <item><term>VIT_INTGTYPE</term><description>Value is set from all the Transaction objects: SaleTransaction, CreditTransaction, VoidTransaction, CaptureTransaction etc.</description><description>Vit_IntgType</description><description>String</description></item>
	/// <item><term>VIT_INTGVERSION</term><description>Value is set from all the Transaction objects: SaleTransaction, CreditTransaction, VoidTransaction, CaptureTransaction etc.</description><description>Vit_IntgVersion</description><description>String</description></item>
	/// <item><term>VIT_OSARCH</term><description>Internal to the SDK.</description><description></description><description>String</description></item>
	/// <item><term>VIT_OSNAME</term><description>Internal to the SDK.</description><description></description><description>String</description></item>
	/// <item><term>VIT_OSVERSION</term><description>Internal to the SDK.</description><description></description><description>String</description></item>
	/// <item><term>VIT_PROXY</term><description>Internal to the SDK.</description><description></description><description>String</description></item>
	/// <item><term>VIT_SDKRUNTIMEVERSION</term><description>Internal to the SDK.</description><description></description><description>String</description></item>
	/// <item><term>XID</term><description>BuyerAuthResponse</description><description><see cref='BuyerAuthResponse.XID'>XID</see></description><description>String</description></item>
	/// <item><term>VMAID</term><description>Invoice</description><description><see cref='Invoice.VMaid'>VMaid</see></description><description>String</description></item>
	/// <item><term>PAYFLOW-REQUEST-ID (Header)</term><description>Value is set from all the transactions:SaleTransaction, CaptureTransaction, VoidTransaction etc.</description><description>RequestId</description><description>String</description></item>
	/// <item><term>NEXTPAYMENTNUM</term><description>RecurringResponse</description><description><see cref='RecurringResponse.NextPaymentNumber'>NEXTPAYMENTNUM</see></description><description>String</description></item>
	/// <item><term>RPSTATE</term><description>RecurringResponse</description><description><see cref='RecurringResponse.RPState'>RPSTATE</see></description><description>String</description></item>
	/// <item><term>NEXTPAYMENT</term><description>RecurringResponse</description><description><see cref='RecurringResponse.NextPayment'>NextPayment</see></description><description>String</description></item>
	/// <item><term>CREATIONDATE</term><description>RecurringResponse</description><description><see cref='RecurringResponse.CreationDate'>CREATIONDATE</see></description><description>String</description></item>
	/// <item><term>LASTCHANGED</term><description>RecurringResponse</description><description><see cref='RecurringResponse.LastChangedDate'>LASTCHANGE</see></description><description>String</description></item>
	/// <item><term>FREQUENCY</term><description>RecurringResponse</description><description><see cref='RecurringResponse.Frequency'>FREQUENCY</see></description><description>String</description></item>
	/// </list>
	/// </summary>

	internal class NamespaceDoc
	{		
	}
}
