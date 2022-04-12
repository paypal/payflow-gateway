#region "Imports"

using System;
using System.Collections;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used as the Purchase Invoice class. All the purchase 
	/// related information can be stored in this class.
	/// </summary>
	/// <remarks>
	/// <para>Following transactions do require invoice object:</para>
	/// <list type="bullet">
	/// <item>Sale Transaction</item>
	/// <item>Authorization Transaction</item>
	/// <item>Voice Authorization Transaction</item>
	/// <item>Primary Credit Transaction</item>
	/// <item>Recurring Transaction : Action --> Add, Payment</item>
	/// </list>
	/// <para>However, Invoice information can also be passed 
	/// in the following transactions:</para>
	/// <list type="bullet">
	/// <item>Delayed Capture Transaction</item>
	/// <item>Credit Transaction</item>
	/// <item>Void Authorization Transaction</item>
	/// <item>Reference Credit Transaction</item>
	/// </list>
	/// <para>By default, the following fields are copied from the 
	/// primary transaction (if they exist) into the reference 
	/// transaction:</para>
	/// <list type="bullet">
	/// <item>Account number  	Amount  	City  	</item>
	/// <item>Comment1  	Comment2  	Company Name  	</item>
	/// <item>Country Cust_Code  	CustIP  	DL  	</item>
	/// <item>Num  	DOB  	Duty amount  	</item>
	/// <item>EMail  	Expiration date  	First name  	</item>
	/// <item>Freight amount  	Invoice number  	Last name  	</item>
	/// <item>Middle Name  	Purchase order number  	Ship To City  	</item>
	/// <item>Ship To Country  	Ship To First Name  	Ship To Last Name  	</item>
	/// <item>Ship To Middle Name  	Ship To State  	Ship To Street  	</item>
	/// <item>Ship To ZIP  	SS Num  	State  	</item>
	/// <item>Street  	Suffix  	Swipe data  	</item>
	/// <item>Tax amount  	Tax exempt  	Telephone  	</item>
	/// <item>Title		ZIP  	</item>
	/// </list>
	/// <para>If the invoice is passed in the reference transaction, then the 
	/// new values (if they exist in invoice) are used (except Account number,
	/// Expiration date, or Swipe data).</para>
	/// </remarks>
	/// <example>
	/// <para>Following example shows how to use invoice.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///	// Create a new Invoice data object with the Amount, Billing Address etc. details.
	///	Invoice Inv = new Invoice();
	///	// Set Amount.
	///	Currency Amt = new Currency(new decimal(25.12));
	///	Inv.Amt = Amt;
	///	Inv.PoNum = "PO12345";
	///	Inv.InvNum = "INV12345";
	///	Inv.AltTaxAmt = new Currency(new decimal(25.14));
	///	// Set the Billing Address details.
	///	BillTo Bill = new BillTo();
	///	Bill.BillToStreet = "123 Main St.";
	///	Bill.BillToZip = "12345";
	///	Inv.BillTo = Bill;
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	.................
	///	' Create a new Invoice data object with the Amount, Billing Address etc. details.
	///	Dim Inv As Invoice = New Invoice
	///	' Set Amount.
	///	Dim Amt As Currency = New Currency(New Decimal(25.12))
	///	Inv.Amt = Amt
	///	Inv.PoNum = "PO12345"
	///	Inv.InvNum = "INV12345"
	///	' Set the Billing Address details.
	///	Dim Bill As BillTo = New BillTo
	///	Bill.BillToStreet = "123 Main St."
	///	Bill.BillToZip = "12345"
	///	Inv.BillTo = Bill
	///	.................
	/// </code>
	/// </example>
	public class Invoice : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Billing Addresses
		/// </summary>
		private BillTo mBillTo;

		/// <summary>
		/// Shipping Addresses
		/// </summary>
		private ShipTo mShipTo;

		/// <summary>
		/// List of line items
		/// </summary>
		private ArrayList mItemList;

		/// <summary>
		/// Invoice number
		/// </summary>
		private String mInvNum;

		/// <summary>
		/// Amount
		/// </summary>
		private Currency mAmt;

		/// <summary>
		/// Tax Amount
		/// </summary>
		private Currency mTaxAmt;

		/// <summary>
		/// Duty amount
		/// </summary>
		private Currency mDutyAmt;

		/// <summary>
		/// Freight amount
		/// </summary>
		private Currency mFreightAmt;

		/// <summary>
		/// Handling amount
		/// </summary>
		private Currency mHandlingAmt;
		
		/// <summary>
		/// Shipping amount
		/// </summary>
		///private Currency mShippingAmt;

        /// <summary>
		/// Discount
		/// </summary>
		private Currency mDiscount;

		/// <summary>
		/// Description
		/// </summary>
		private String mDesc;

		/// <summary>
		/// Comment1
		/// </summary>
		private String mComment1;

		/// <summary>
		/// Comment2
		/// </summary>
		private String mComment2;

		/// <summary>
		/// Description 1
		/// </summary>
		private String mDesc1;

		/// <summary>
		/// Description 2
		/// </summary>
		private String mDesc2;

		/// <summary>
		/// Description 3
		/// </summary>
		private String mDesc3;

		/// <summary>
		/// Description 3
		/// </summary>
		private String mDesc4;

		/// <summary>
		/// Customer Reference
		/// </summary>
		private String mCustRef;

		/// <summary>
		/// Invoice date
		/// </summary>
		private String mInvoiceDate;

		/// <summary>
		/// Start time
		/// </summary>
		private String mStartTime;

		/// <summary>
		/// End time
		/// </summary>
		private String mEndTime;

		/// <summary>
		/// Purchase order number
		/// </summary>
		private String mPoNum;

		/// <summary>
		/// Vat reg number
		/// </summary>
		private String mVatRegNum;

		/// <summary>
		/// Vat tax amount
		/// </summary>
		private Currency mVatTaxAmt;

		/// <summary>
		/// Local tax amount
		/// </summary>
		private Currency mLocalTaxAmt;

		/// <summary>
		/// National tax amount
		/// </summary>
		private Currency mNationalTaxAmt;

		/// <summary>
		/// Alt tax amount
		/// </summary>
		private Currency mAltTaxAmt;

		/// <summary>
		/// Is Tax Exempt
		/// </summary>
		private String mTaxExempt;

		/// <summary>
		/// Browser information object
		/// </summary>
		private BrowserInfo mBrowserInfo;

		/// <summary>
		/// Customer information object
		/// </summary>
		private CustomerInfo mCustomerInfo;

        /// <summary>
        /// Merchant information object
        /// </summary>
        private MerchantInfo mMerchantInfo;

        /// <summary>
        /// User information object
        /// </summary>
        private UserItem mUserItem;

		/// <summary>
		/// Order Date
		/// </summary>
		private String mOrderDate;

		/// <summary>
		/// Order Time
		/// </summary>
		private String mOrderTime;

		/// <summary>
		/// Comm Code
		/// </summary>
		private String mCommCode;

		/// <summary>
		/// VatTax Percent
		/// </summary>
		private String mVatTaxPercent;

		/// <summary>
		/// Recurring
		/// </summary>
		private String mRecurring;

		/// <summary>
		/// line item amount 
		/// </summary>
		private Currency  mItemAmt;
		
		/// <summary>
		/// OrderDesc
		/// </summary>
		private String mOrderDesc;

		/// <summary>
		/// RecurringType
		/// </summary>
		private String mRecurringType;
		
        /// <summary>
        /// Order Id
        /// </summary>
        private String mOrderId;
		/// <summary>
        /// Echo data
        /// </summary>
        private String mEchoData;
		/// <summary>
		/// VAT Invoice Number
		/// </summary>
		private String mVatInvNum;
		/// <summary>
        /// VAT Tax Rate
        /// </summary>
        private String mVatTaxRate;
		/// <summary>
        /// Report Group
        /// </summary>
        private String mReportGroup;
		/// <summary>
		/// AdviceDetailList
		/// </summary>
		private ArrayList mAdviceDetailList;
		/// <summary>
		/// Devices
		/// </summary>
		private Devices mDevices;
		/// <summary>
		/// Miscellaneous Data
        /// </summary>
        private String mMiscData;
		///<summary>
		///Secure Token, used for Inquiry transaction
		///</summary>
		private String mSecureToken;
		///<summary>
		///SCA Exemption
		///</summary>
		private String mSCAExemption;
		///<summary>
		///CitiDate
		///</summary>
		private String mCitDate;
		///<summary>
		/// MVaid
		///</summary>
		private String mVMaid;
		///<summary>
		/// Par
		///</summary>
		private String mPar;
		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>
		/// <para>Following transactions do require invoice object:</para>
		/// <list type="bullet">
		/// <item>Sale Transaction</item>
		/// <item>Authorization Transaction</item>
		/// <item>Voice Authorization Transaction</item>
		/// <item>Primary Credit Transaction</item>
		/// <item>Recurring Transaction : Action --> Add, Payment</item>
		/// </list>
		/// <para>However, Invoice information can also be passed 
		/// in the following transactions:</para>
		/// <list type="bullet">
		/// <item>Delayed Capture Transaction</item>
		/// <item>Credit Transaction</item>
		/// <item>Void Authorization Transaction</item>
		/// <item>Reference Credit Transaction</item>
		/// </list>
		/// <para>By default, the following fields are copied from the 
		/// primary transaction (if they exist) into the reference 
		/// transaction:</para>
		/// <list type="bullet">
		/// <item>Account number  	Amount  	City  	</item>
		/// <item>Comment1  	Comment2  	Company Name  	</item>
		/// <item>Country Cust_Code  	CustIP  	DL  	</item>
		/// <item>Num  	DOB  	Duty amount  	</item>
		/// <item>EMail  	Expiration date  	First name  	</item>
		/// <item>Freight amount  	Invoice number  	Last name  	</item>
		/// <item>Middle Name  	Purchase order number  	Ship To City  	</item>
		/// <item>Ship To Country  	Ship To First Name  	Ship To Last Name  	</item>
		/// <item>Ship To Middle Name  	Ship To State  	Ship To Street  	</item>
		/// <item>Ship To ZIP  	SS Num  	State  	</item>
		/// <item>Street  	Suffix  	Swipe data  	</item>
		/// <item>Tax amount  	Tax exempt  	Telephone  	</item>
		/// <item>Title		ZIP  	</item>
		/// <item>UK: Capture Complete Recurring Type  	</item>
		/// </list>
		/// <para>If the invoice is passed in the reference transaction, then the 
		/// new values (if they exist in invoice) are used (except Account number,
		/// Expiration date, or Swipe data).</para>
		/// </remarks>
		/// <example>
		/// <para>Following example shows how to use invoice.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///	// Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	Invoice Inv = new Invoice();
		///	// Set Amount.
		///	Currency Amt = new Currency(new decimal(25.12));
		///	Inv.Amt = Amt;
		///	Inv.PoNum = "PO12345";
		///	Inv.InvNum = "INV12345";
		///	Inv.AltTaxAmt = new Currency(new decimal(25.14));
		///	// Set the Billing Address details.
		///	BillTo Bill = new BillTo();
		///	Bill.BillToStreet = "123 Main St.";
		///	Bill.BillToZip = "12345";
		///	Inv.BillTo = Bill;
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Create a new Invoice data object with the Amount, Billing Address etc. details.
		///	Dim Inv As Invoice = New Invoice
		///	' Set Amount.
		///	Dim Amt As Currency = New Currency(New Decimal(25.12))
		///	Inv.Amt = Amt
		///	Inv.PoNum = "PO12345"
		///	Inv.InvNum = "INV12345"
		///	' Set the Billing Address details.
		///	Dim Bill As BillTo = New BillTo
		///	Bill.BillToStreet = "123 Main St."
		///	Bill.BillToZip = "12345"
		///	Inv.BillTo = Bill
		///	.................
		/// </code>
		/// </example>
		public Invoice()
		{
			mItemList = new ArrayList();
			mAdviceDetailList = new ArrayList();
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets  BillTo.
		/// </summary>
		/// <remarks>
		/// <para>Use this property to set the billing
		/// addresses of the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the Billing Address details.
		///	BillTo Bill = New BillTo();
		///	Bill.BillToStreet = "123 Main St.";
		///	Bill.BillToZip = "12345";
		///	Inv.BillTo = Bill;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Billing Address details.
		///	Dim Bill As BillTo = New BillTo
		///	Bill.BillToStreet = "123 Main St."
		///	Bill.BillToZip = "12345"
		///	Inv.BillTo = Bill
		///	.................
		///	</code>
		/// </example>
		public BillTo BillTo
		{
			get { return mBillTo; }
			set { mBillTo = value; }

		}

		/// <summary>
		/// Gets, Sets  ShipTo.
		/// </summary>
		/// <remarks>
		/// <para>Use this property to set the shipping
		/// addresses of the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the Shipping Address details.
		///	ShipTo Ship = New ShipTo();
		///	Ship.ShipToStreet = "685A E. Middlefield Rd.";
		///	Ship.ShipToZip = "94043";
		///	Inv.ShipTo = Ship;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Shipping Address details.
		///	Dim Ship As ShipTo = New ShipTo
		///	Ship.ShipToStreet = "685A E. Middlefield Rd."
		///	Ship.ShipToZip = "94043"
		///	Inv.ShipTo = Ship
		///	.................
		///	</code>
		/// </example>
		public ShipTo ShipTo
		{
			get { return mShipTo; }
			set { mShipTo = value; }

		}

		/// <summary>
		/// Gets, Sets  TaxExempt.
		/// </summary>
		/// <remarks>
		/// <para>Is the customer tax exempt? Y or N</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TAXEXEMPT</code>
		/// </remarks>
		public String TaxExempt
		{
			get { return mTaxExempt; }
			set { mTaxExempt = value; }
		}

		/// <summary>
		/// Gets, Sets  InvNum
		/// </summary>
		/// <remarks>
		/// <para>Merchant invoice number. This reference number 
		/// (PNREF—generated by PayPal) is used for authorizations 
		/// and settlements.</para>
		/// <para>The Acquire decides if this information will 
		/// appear on the merchant’s bank reconciliation statement.
		/// </para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>INVNUM</code>
		/// </remarks>
		public String InvNum
		{
			get { return mInvNum; }
			set { mInvNum = value; }
		}

		/// <summary>
		/// Gets, Sets  Amt.
		/// </summary>
		/// <remarks>
		/// <para>Amount (US Dollars) U.S. based currency. 
		/// Specify the exact amount to the cent using a decimal 
		/// point—use 34.00, not 34. Do not include comma 
		/// separators—use 1199.95 not 1,199.95.</para>
		/// <para>Your processor and/or Internet merchant account 
		/// provider may stipulate a maximum amount.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMT</code>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		/// // Set the Amount for the invoice.
		/// // A valid amount is a two decimal value.
		/// Currency Amt = new Currency(new decimal(25.12))
		/// //For values which have more than two decimal places 
		/// Currency Amt = new Currency(new decimal(25.1214));
		/// Amt.NoOfDecimalDigits = 2;
		/// //If the NoOfDecimalDigits property is used then it is mandatory to set one of the following properties to true.
		/// Amt.Round = true;
		/// Amt.Truncate = true;
		/// Inv.Amt = Amt;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		/// 'Set the Amount for the invoice.
		/// 'A valid amount is a two decimal value.
		/// Dim Amt as new Currency(new decimal(25.12))
		/// 'For values which have more than two decimal places 
		/// Dim Amt as new Currency(new decimal(25.1214))
		/// Amt.NoOfDecimalDigits = 2
		/// 'If the NoOfDecimalDigits property is used then it is mandatory to set one of the following properties to true.
		/// Amt.Round = true
		/// Amt.Truncate = true
		/// Inv.Amt = Amt;
		/// ................
		///	</code>
		/// </example>
		public Currency Amt
		{
			get { return mAmt; }
			set { mAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  TaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>Tax Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TAXAMT</code>
		/// </remarks>
		public Currency TaxAmt
		{
			get { return mTaxAmt; }
			set { mTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  DutyAmt.
		/// </summary>
		/// <remarks>
		/// <para>Sometimes called import tax.
		///  Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DUTYAMT</code>
		/// </remarks>
		public Currency DutyAmt
		{
			get { return mDutyAmt; }
			set { mDutyAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  FreightAmt.
		/// </summary>
		/// <remarks>
		/// <para>Freight Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FREIGHTAMT</code>
		/// </remarks>
		public Currency FreightAmt
		{
			get { return mFreightAmt; }
			set { mFreightAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  HandlingAmt
		/// </summary>
		/// <remarks>
		/// <para>Handling Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>HANDLINGAMT</code>
		/// </remarks>
		public Currency HandlingAmt
		{
			get { return mHandlingAmt; }
			set { mHandlingAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  ShippingAmt
		/// </summary>
		/// <remarks>
		/// <para>Shipping Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPPINGAMT</code>
		/// </remarks>
		///public Currency ShippingAmt
		///{
		/// get { return mShippingAmt; }
		///	set { mShippingAmt = value; }
		///}

		

		/// <summary>
		/// Gets, Sets  Discount.
		/// </summary>
		/// <remarks>
		/// <para>Discount amount on total sale. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DISCOUNT</code>
		/// </remarks>
		public Currency Discount
		{
			get { return mDiscount; }
			set { mDiscount = value; }
		}

		/// <summary>
		/// Gets, Sets  Desc.
		/// </summary>
		/// <remarks>
		/// <para>General description of the transaction.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DESC</code>
		/// </remarks>
		public String Desc
		{
			get { return mDesc; }
			set { mDesc = value; }
		}

		/// <summary>
		/// Gets, Sets  Comment1
		/// </summary>
		/// <remarks>
		/// <para>Merchant-defined value for reporting and auditing
		/// purposes.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COMMENT1</code>
		/// </remarks>
		public String Comment1
		{
			get { return mComment1; }
			set { mComment1 = value; }
		}

		/// <summary>
		/// Gets, Sets  Comment2
		/// </summary>
		/// <remarks>
		/// <para>Merchant-defined value for reporting and auditing
		/// purposes.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COMMENT2</code>
		/// </remarks>
		public String Comment2
		{
			get { return mComment2; }
			set { mComment2 = value; }
		}

		/// <summary>
		/// Gets, Sets  Desc1.
		/// </summary>
		/// <remarks>
		/// <para>Up to 4 lines of additional description of
		/// the charge.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DESC1</code>
		/// </remarks>
		public String Desc1
		{
			get { return mDesc1; }
			set { mDesc1 = value; }
		}

		/// <summary>
		/// Gets, Sets  Desc2.
		/// </summary>
		/// <remarks>
		/// <para>Up to 4 lines of additional description of
		/// the charge.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DESC2</code>
		/// </remarks>
		public String Desc2
		{
			get { return mDesc2; }
			set { mDesc2 = value; }
		}

		/// <summary>
		/// Gets, Sets  Desc3.
		/// </summary>
		/// <remarks>
		/// <para>Up to 4 lines of additional description of
		/// the charge.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DESC3</code>
		/// </remarks>
		public String Desc3
		{
			get { return mDesc3; }
			set { mDesc3 = value; }
		}

		/// <summary>
		/// Gets, Sets  Desc4.
		/// </summary>
		/// <remarks>
		/// <para>Up to 4 lines of additional description of
		/// the charge.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DESC4</code>
		/// </remarks>
		public String Desc4
		{
			get { return mDesc4; }
			set { mDesc4 = value; }
		}

		/// <summary>
		/// Gets, Sets  CustRef.
		/// </summary>
		/// <remarks>
		///	<para> Merchant-defined identifier for reporting and auditing
		///	purposes. For example, you can set CUSTREF to the
		///	invoice number.</para>
		///	<para>You can use CUSTREF when performing Inquiry
		///	transactions. To ensure that you can always access
		///	the correct transaction when performing an Inquiry,
		///	you must provide a unique CUSTREF when
		///	submitting any transaction, including retries.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CUSTREF</code>
		/// </remarks>
		public String CustRef
		{
			get { return mCustRef; }
			set { mCustRef = value; }
		}

		/// <summary>
		/// Gets, Sets  InvoiceDate.
		/// </summary>
		/// <remarks>
		/// <para>Transaction Date.</para>
		/// <para>Format: yyyymmdd.</para>
		/// <para>yyyy - Year, mm - Month, dd - Day.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>INVOICEDATE</code>
		/// </remarks>
		public String InvoiceDate
		{
			get { return mInvoiceDate; }
			set { mInvoiceDate = value; }
		}

		/// <summary>
		/// Gets, Sets  StartTime
		/// </summary>
		/// <remarks>
		///	<para>STARTTIME specifies the beginning of the time
		///	period during which the transaction specified by the
		///	CUSTREF occurred. </para>
		///	<para>If you set STARTTIME, and not ENDTIME, then
		///	ENDTIME is defaulted to 30 days after STARTTIME.
		///	If neither STARTTIME nor ENDTIME is specified, then
		///	the system searches the last 30 days.</para>
		///	<para>Format: yyyymmddhhmmss</para>
		///	<para>yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>STARTTIME</code>
		/// </remarks>
		public String StartTime
		{
			get { return mStartTime; }
			set { mStartTime = value; }
		}

		/// <summary>
		/// Gets, Sets  EndTime.
		/// </summary>
		/// <remarks>
		///<para>	ENDTIME specifies the end of the time period during 
		/// which the transaction specified by the CUSTREF occurred.</para>
		///<para>	ENDTIME must be less than 30 days after STARTTIME.
		/// An inquiry cannot be performed across a date range 
		/// greater than 30 days.</para>
		///<para>	If you set ENDTIME, and not STARTTIME, then STARTTIME is 
		/// defaulted to 30 days before ENDTIME. If neither 
		/// STARTTIME nor ENDTIME is specified, then the
		/// system searches the last 30 days.</para>
		///<para>	Format: yyyymmddhhmmss</para>
		///<para>yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ENDTIME</code>
		/// </remarks>
		public String EndTime
		{
			get { return mEndTime; }
			set { mEndTime = value; }
		}

		/// <summary>
		/// Gets, Sets  PoNum.
		/// </summary>
		/// <remarks>
		/// <para>Purchase Order Number / Merchant related
		/// data.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PONUM</code>
		/// </remarks>
		public String PoNum
		{
			get { return mPoNum; }
			set { mPoNum = value; }
		}

		/// <summary>
		/// Gets, Sets  VatRegNum
		/// </summary>
		/// <remarks>
		/// <para>VAT registration number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>VATREGNUM</code>
		/// </remarks>
		public String VatRegNum
		{
			get { return mVatRegNum; }
			set { mVatRegNum = value; }
		}

		/// <summary>
		/// Gets, Sets  VatTaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>VAT Tax Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>VATTAXAMT</code>
		/// </remarks>
		public Currency VatTaxAmt
		{
			get { return mVatTaxAmt; }
			set { mVatTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  LocalTaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>Local Tax Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>LOCALTAXAMT</code>
		/// </remarks>
		public Currency LocalTaxAmt
		{
			get { return mLocalTaxAmt; }
			set { mLocalTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  NationalTaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>National Tax Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NATIONALTAXAMT</code>
		/// </remarks>
		public Currency NationalTaxAmt
		{
			get { return mNationalTaxAmt; }
			set { mNationalTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  AltTaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>Alternate Tax Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ALTTAXAMT</code>
		/// </remarks>
		public Currency AltTaxAmt
		{
			get { return mAltTaxAmt; }
			set { mAltTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  BrowserInfo.
		/// </summary>
		/// <remarks>
		/// <para>Use this property to set the browser 
		/// related information of the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the Browser Info details.
		///	BrowserInfo Browser = New BrowserInfo();
		///	Browser.BrowserCountryCode = "USA";
		///	Browser.BrowserUserAgent = "IE 6.0";
		///	Inv.BrowserInfo = Browser;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Browser Info details.
		///	Dim Browser As BrowserInfo = New BrowserInfo
		///	Browser.BrowserCountryCode  = "USA"
		///	Browser.BrowserUserAgent = "IE 6.0"
		///	Inv.BrowserInfo = Browser
		///	.................
		///	</code>
		/// </example>
		public BrowserInfo BrowserInfo
		{
			get { return mBrowserInfo; }
			set { mBrowserInfo = value; }
		}

		/// <summary>
		/// Gets, Sets  CustomerInfo.
		/// </summary>
		/// <remarks>
		/// <para>Use this property to set the customer 
		/// related information of the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the Customer Info details.
		///	CustomerInfo Cust = New CustomerInfo();
		///	Cust.CustCode = "CustXXXXX";
		///	Cust.CustIP = "255.255.255.255";
		///	Inv.CustomerInfo = Cust;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Customer Info details.
		///	Dim Cust As CustomerInfo = New CustomerInfo
		///	Cust.CustCode = "CustXXXXX"
		///	Cust.CustIP = "255.255.255.255"
		///	Inv.CustomerInfo = Cust
		///	.................
		///	</code>
		/// </example>
		public CustomerInfo CustomerInfo
		{
			get { return mCustomerInfo; }
			set { mCustomerInfo = value; }
		}

        /// <summary>
        /// Used for Merchant related information.
        /// </summary>
        /// <remarks>Use this class to set the Merchant related 
        /// information.  Used for Soft Descriptors.  
        /// 
        /// Refer to the Payflow Gateway Developer's Guide for your processor
        /// for more information related to this fields.</remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	.................
        ///	// Inv is the Invoice object
        ///	.................
        ///	// Set the Merchant Info details.
        ///	MerchantInfo Merchant = New MerchantInfo();
        ///	Merchant.MerchantCode = "MerchantXXXXX";
        ///	Merchant.MerchantCity = "Anywhere";
        ///	Inv.MerchantInfo = Merchant;
        ///	.................
        ///	</code>
        /// <code lang="Visual Basic" escaped="false">
        ///	.................
        ///	' Inv is the Invoice object
        ///	.................
        ///	' Set the Merchant Info details.
        ///	Dim Merchant As MerchantInfo = New MerchantInfo
        ///	Merchant.MerchantCode = "MerchantXXXXX"
        ///	Merchant.MerchantCity = "Anywhere"
        ///	Inv.MerchantInfo = Merchant
        ///	.................
        ///	</code>
        /// </example>
        public MerchantInfo MerchantInfo
        {
            get { return mMerchantInfo; }
            set { mMerchantInfo = value; }
        }

        /// <summary>
        /// Gets, Sets  UserItem.
        /// </summary>
        /// <remarks>
        /// <para>Use this property to set the user 
        /// related information that is echoed back in the response.</para>
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	.................
        ///	// Inv is the Invoice object
        ///	.................
        ///	// Set the User Item details.
        /// UserItem nUser = new UserItem();
        /// nUser.UserItem1 = "ABCDEF";
        /// nUser.UserItem2 = "GHIJKL";
        /// Inv.UserItem = nUser;
        ///	.................
        ///	</code>
        /// <code lang="Visual Basic" escaped="false">
        ///	.................
        ///	' Inv is the Invoice object
        ///	.................
        ///	' Set the User Item details.
        /// Dim nUser As New UserItem
        /// nUser.UserItem1 = "ABCDEF"
        /// nUser.UserItem2 = "GHIJKL"
        /// Inv.UserItem = nUser
        ///	.................
        ///	</code>
        /// </example>
        public UserItem UserItem
        {
            get { return mUserItem; }
            set { mUserItem = value; }
        }

		/// <summary>
		/// Gets, Sets  OrderDate.
		/// </summary>
		/// <remarks>
		/// <para>Order date.</para>
		/// <para>Format: mmddyy</para>
		/// <para>mm - Month, dd - Day, yy - Year.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORDERDATE</code>
		/// </remarks>
		public String OrderDate
		{
			get { return mOrderDate; }
			set { mOrderDate = value; }
		}

		/// <summary>
		/// Gets, Sets  OrderTime.
		/// </summary>
		/// <remarks>
		/// <para>Order Time.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORDERTIME</code>
		/// </remarks>
		public String OrderTime
		{
			get { return mOrderTime; }
			set { mOrderTime = value; }
		}

		/// <summary>
		/// Gets, Sets  CommCode.
		/// </summary>
		/// <remarks>
		/// <para>Commodity Code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COMMCODE</code>
		/// </remarks>
		public String CommCode
		{
			get { return mCommCode; }
			set { mCommCode = value; }
		}

		/// <summary>
		/// Gets, Sets  VATTAXPERCENT.
		/// </summary>
		/// <remarks>
		/// <para>VAT Tax percentage.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>VATTAXPERCENT</code>
		/// </remarks>
		public String VatTaxPercent
		{
			get { return mVatTaxPercent; }
			set { mVatTaxPercent = value; }
		}

		/// <summary>
		/// Gets, Sets  Recurring.
		/// </summary>
		/// <remarks>
		/// <para>Is a recurring transaction? Y or N.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RECURRING</code>
		/// </remarks>
		public String Recurring
		{
			get { return mRecurring; }
			set { mRecurring = value; }
		}

		/// <summary>
		/// Gets, Sets line item Amount.
		/// </summary>
		/// <remarks>
		/// <para>Item Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ITEMAMT</code>
		/// </remarks>
		public Currency ItemAmt
		{
			get { return mItemAmt; }
			set { mItemAmt = value; }
		}

		/// <summary>
		/// Gets, Sets  OrderDesc.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORDERDESC</code>
		/// </remarks>
		public String OrderDesc
		{
			get { return mOrderDesc; }
			set { mOrderDesc = value; }
		}
		
		/// <summary>
		/// Gets, Sets  RecurringType.
		/// </summary>
		/// <remarks>
		/// <para>UK Only: The type of transaction occurrence.
		/// Values are: F = First occurrence, S = Subsequent
		/// occurrence (default).</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RECURRINGTYPE</code>
		/// </remarks>
		public String RecurringType
		{
			get { return mRecurringType; }
			set { mRecurringType = value; }
		}

        /// <summary>
        /// Gets, Sets  OrderId
        /// </summary>
        /// <remarks>
        /// <para>Order ID is used to prevent duplicate "orders" from being processed.</para>
        /// <para>This is NOT the same as Request ID; which is used at the transaction level.</para>
        /// <para>Order ID (ORDERID) is used to check for a duplicate order in the future.</para>
        /// <para>For example, if you pass ORDERID=10101 and in two weeks another order is processed</para>
        /// <para>with the same ORDERID, a duplicate condition will occur.  The results you receive</para>
        /// <para>will be from the original order with DUPLICATE=2 to show that it was ORDERID that</para>
        /// <para>triggered the duplicate.  The order id is stored for 3 years.</para>
        /// <para></para>
        /// <para>Important Note: Order ID functionality to catch duplicate orders processed withing</para>
        /// <para>seconds of each other is limited.  Order ID should be used in conjunction with Request ID</para>
        /// <para>to prevent duplicates due to processing / communication errors. DO NOT use ORDERID</para>
        /// <para>as your only means to check for duplicate transactions.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ORDERID</code>
        /// </remarks>
        public String OrderId
        {
            get { return mOrderId; }
            set { mOrderId = value; }
        }

        /// <summary>
        /// Gets, Sets  EchoData
        /// </summary>
        /// <remarks>
        /// <para>Echo Data is used to "echo" back data sent for processing in the response.</para>
        /// <para>For example, if you send "ECHODATA=ADDRESS" then the Billing Address fields</para>
        /// <para>will be returned in the response.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ECHODATA</code>
        /// </remarks>
        public String EchoData
        {
            get { return mEchoData; }
            set { mEchoData = value; }
        }

		/// <summary>
		/// Gets, Sets  VAT Invoice Number.
		/// </summary>
		/// <remarks>
		/// <para>Value added tax invoice number.</para>
		/// <para>Maps to Payflow Parameter: 
		/// <code>VATINVNUM</code></para>
		/// </remarks>
		public String VatInvNum
		{
			get { return mVatInvNum; }
			set { mVatInvNum = value; }
		}

		/// <summary>
		/// Gets, Sets  VAT Tax Rate.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>VATTAXRATE</code>
		/// </remarks>
		public String VatTaxRate
		{
			get { return mVatTaxRate; }
			set { mVatTaxRate = value; }
		}

		/// <summary>
		/// Gets, Sets  Report Group.
		/// </summary>
		/// <remarks>
		/// <para>Category that the transaction is in, for example: coffee mugs.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>REPORTGROUP</code>
		/// </remarks>
		public String ReportGroup
		{
			get { return mReportGroup; }
			set { mReportGroup = value; }
		}

		/// <summary>
		/// Gets, Sets Devices.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Items that reflect what type of device; either termainal or card is used or presented.
		/// </para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Create a new Devices object.
		///	Devices UsedDevices = new Devices();
		///	UsedDevices.CatType = "3";
		///	UsedDevices.Contactless = "RFD";
		///	Inv.Devices = UsedDevices;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
        /// ' Set the device/card capabilities
        /// Dim UsedDevices As Devices = New Devices
        /// UsedDevices.CatType = "3"
        /// UsedDevices.Contactless = "RFD"
        /// Inv.Devices = UsedDevices
		///	.................
		///	</code>
		/// </example>
		public Devices Devices
		{
			get { return mDevices; }
			set { mDevices = value; }
		}

		/// <summary>
		/// Gets, Sets  Miscellaneous Data.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MISCDATA</code>
		/// </remarks>
		public String MiscData
		{
			get { return mMiscData; }
			set { mMiscData = value; }
		}

		/// <summary>
		/// Gets, Sets  SecureToken.
		/// </summary>
		/// <remarks>
		///	<para> Merchant-defined identifier used in the Secure Token flow.
		///	</para>
		///	<para>You can use SECURETOKEN when performing Inquiry transactions. To ensure that you can always access
		///	the correct transaction when performing an Inquiry, you must use CREATESECURETOKEN when
		///	submitting any transaction.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SECURETOKEN</code>
		/// </remarks>
		public String SecureToken
		{
			get { return mSecureToken; }
			set { mSecureToken = value; }
		}

		/// <summary>
		/// Gets, Sets  SCAExemption.
		/// </summary>
		/// <remarks>
		///	<para> Value to flag exemption status.
		///	</para>
		///	<para> Only one of the following values can be sent: TM, SCP, TRA, LVP, MIT, RP, SD, TM</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SCAEXEMPTION</code>
		/// </remarks>
		public String SCAExemption
		{
			get { return mSCAExemption; }
			set { mSCAExemption = value; }
		}

		/// Gets, Sets  CitDate.
		/// </summary>
		/// <remarks>
		///	<para> Original transaction date of the CIT transaction.
		///	</para>
		///	<para> MasterCard only. Merchant initiated(MIT) and recurring(RP) transactions must contain the original settlement date which is received from the initial Cardholder Initiated(CITI) transaction response.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CITDATE</code>
		/// </remarks>
		public String CitDate
		{
			get { return mCitDate; }
			set { mCitDate = value; }
		}

		/// Gets, Sets  VMaid.
		/// </summary>
		/// <remarks>
		///	<para> Visa Merchant Authentication ID
		///	</para>
		///	<para> Visa only. Visa Merchant Authentication ID assigned by Visa EU.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>VMAID</code>
		/// </remarks>
		public String VMaid
		{
			get { return mVMaid; }
			set { mVMaid = value; }
		}

		/// Gets, Sets  Par.
		/// </summary>
		/// <remarks>
		///	<para> Payment Account Reference
		///	</para>
		///	<para> American Express only. The Payment Account Reference (PAR) is a non-financial reference number assigned to each unique Primary Account Number (PAN) and mapped to all its affiliated Payment Tokens. 
		///		For Merchants that encounter both PAN and Token transactions, PAR provides the ability to link both types of Transactions and activities for a card account.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAR/code>
		/// </remarks>
		public String Par
		{
			get { return mPar; }
			set { mPar = value; }
		}
		#endregion

		#region "AdviceDetailItem related Methods"

		/// <summary>
		/// Used for advice detail items.
		/// </summary>
		/// <remarks>
		/// This class holds the advice detail related information.
		/// Detail of a charge where *n* is a value from 1 - 5. Use for additional breakdown of the amount.
		/// For example ADDLAMT1=1 is the amount for the additional amount for advice detail item 1 and is equal to 1,
		/// </remarks>
		/// <example>
		/// <para>Following example shows how to use AdviceDetail.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///  .................
		/// // Set the Advice Detail items.
		/// AdviceDetail AddDetail1 = new AdviceDetail();
		///	AddDetail1.AddLAmt = "1";
		///	AddDetail1.AddLAmtType = "1";
		///	Inv.AddAdviceDetailItem(AddDetail1);
		///	// To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///  .................
		///  'Inv is the Invoice object.
		///  .................
		///  ' Set the Advice Detail items.
		///  Dim AddDetail1 As AdviceDetail = New AdviceDetail
		///  AddDetail1.AddLAmt = "1"
		///  AddDetail1.AddLAmtType = "1"
		///  Inv.AddAdviceDetailItem(AddDetail1)
		///  ' To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
		///	.................
		/// </code>
		/// </example>
		public void AddAdviceDetailItem(AdviceDetail Item)
		{
			mAdviceDetailList.Add(Item);
		}

		/// <summary>
		/// Removes a advice detail item from line item list.
		/// </summary>
		/// <param name="Index">Index of line item to be removed.</param>
		/// <remarks>
		/// <para>Use this method to remove an advice detail item at a particular 
		/// index in the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Remove item at index 0
		///	Inv.RemoveAdviceDetailItem(0);
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Remove item at index 0;
		///	Inv.RemoveAdviceDetailItem(0)
		///	.................
		///	</code>
		/// </example>
		public void RemoveAdviceDetailItem(int Index)
		{
			mAdviceDetailList.RemoveAt(Index);
		}

		/// <summary>
		/// Clears the advice detail item list.
		/// </summary>
		/// <remarks>
		/// <para>Use this method to clear all the 
		/// advice detail items added to the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Remove all advice detail items.
		///	Inv.RemoveAllAdviceDetailItems();
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Remove all advice detail items.
		///	Inv.RemoveAllAdviceDetailItems()
		///	.................
		///	</code>
		/// </example>
		public void RemoveAllAdviceDetailItems()
		{
			mAdviceDetailList.Clear();
		}
		#endregion

		#region "LineItem related Methods"

		/// <summary>
		/// Adds a line item to line item list.
		/// </summary>
		/// <param name="Item">Lineitem object</param>
		/// <remarks>
		/// <para>Use this method to add a line item in
		/// the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the line item details.
		///	LineItem Item = New LineItem();
		///	Item.PickupStreet = "685A E. Middlefield Rd.";
		///	Item.PickupState = "CA";
		///	Inv.AddLineItem(Item);
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Customer Info details.
		///	Dim Item As LineItem = New LineItem
		///	Item.PickupStreet = "685A E. Middlefield Rd."
		///	Item.PickupState = "CA"
		///	Inv.AddLineItem(Item);
		///	.................
		///	</code>
		/// </example>
		public void AddLineItem(LineItem Item)
		{
			mItemList.Add(Item);
		}

		/// <summary>
		/// Removes a line item from line item list.
		/// </summary>
		/// <param name="Index">Index of lineitem to be removed.</param>
		/// <remarks>
		/// <para>Use this method to remove a line item at a particular 
		/// index in the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Remove item at index 0
		///	Inv.RemoveLineItem(0);
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Remove item at index 0;
		///	Inv.RemoveLineItem(0)
		///	.................
		///	</code>
		/// </example>
		public void RemoveLineItem(int Index)
		{
			mItemList.RemoveAt(Index);
		}

		/// <summary>
		/// Clears the line item list.
		/// </summary>
		/// <remarks>
		/// <para>Use this method to clear all the 
		/// line items added to the purchase order.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Remove all line items.
		///	Inv.RemoveAllLineItems();
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Remove all line items.
		///	Inv.RemoveAllLineItems()
		///	.................
		///	</code>
		/// </example>
		public void RemoveAllLineItems()
		{
			mItemList.Clear();
		}

		/// <summary>
		/// Generates transaction request for line items
		/// </summary>
		private void GenerateItemRequest()
		{
			for (int Index = 0; Index < mItemList.Count; Index++)
			{
				LineItem Item = (LineItem) mItemList[Index];
				if (Item != null)
				{
					Item.RequestBuffer = RequestBuffer;
					Item.GenerateRequest(Index);
				}
			}
		}

		/// <summary>
		/// Generates transaction request for advice detail items
		/// </summary>
		private void GenerateAdviceDetailRequest()
		{
			for (int Index = 0; Index < mAdviceDetailList.Count; Index++)
			{
				AdviceDetail Item = (AdviceDetail) mAdviceDetailList[Index];
				if (Item != null)
				{
					Item.RequestBuffer = RequestBuffer;
					Item.GenerateRequest(Index);
				}
			}
		}
	
		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_INVNUM, mInvNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AMT, mAmt));
				// if no Amt passed, skip CurrencyCode.
				if (mAmt != null) 
				{
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CURRENCY,mAmt.CurrencyCode));
				}
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TAXEXEMPT, mTaxExempt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TAXAMT, mTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DUTYAMT, mDutyAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_FREIGHTAMT, mFreightAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_HANDLINGAMT, mHandlingAmt));
				//RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPPINGAMT, mShippingAmt ));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DISCOUNT, mDiscount));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DESC, mDesc));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COMMENT1, mComment1));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COMMENT2, mComment2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DESC1, mDesc1));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DESC2, mDesc2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DESC3, mDesc3));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DESC4, mDesc4));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTREF, mCustRef));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PONUM, mPoNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VATREGNUM, mVatRegNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VATTAXAMT, mVatTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_LOCALTAXAMT, mLocalTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_NATIONALTAXAMT, mNationalTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ALTTAXAMT, mAltTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COMMCODE, mCommCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VATTAXPERCENT, mVatTaxPercent));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_INVOICEDATE, mInvoiceDate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_STARTTIME, mStartTime));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ENDTIME, mEndTime));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORDERDATE, mOrderDate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORDERTIME, mOrderTime));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_RECURRING, mRecurring));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ITEMAMT, mItemAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORDERDESC, mOrderDesc));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_RECURRINGTYPE, mRecurringType));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORDERID, mOrderId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ECHODATA, mEchoData));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VATINVNUM, mVatInvNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VATTAXRATE, mVatTaxRate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_REPORTGROUP, mReportGroup));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MISCDATA, mMiscData));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SECURETOKEN, mSecureToken)); 
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SCAEXEMPTION, mSCAExemption));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CITDATE, mCitDate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VMAID, mVMaid));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAR, mPar));



				if (mBillTo != null)
				{
					mBillTo.RequestBuffer = RequestBuffer;
					mBillTo.GenerateRequest();
				}
				if (mShipTo != null)
				{
					mShipTo.RequestBuffer = RequestBuffer;
					mShipTo.GenerateRequest();
				}
				if (mBrowserInfo != null)
				{
					mBrowserInfo.RequestBuffer = RequestBuffer;
					mBrowserInfo.GenerateRequest();
				}
				if (mCustomerInfo != null)
				{
					mCustomerInfo.RequestBuffer = RequestBuffer;
					mCustomerInfo.GenerateRequest();
				}
                if (mMerchantInfo != null)
                {
                    mMerchantInfo.RequestBuffer = RequestBuffer;
                    mMerchantInfo.GenerateRequest();
                }
                if (mItemList != null && mItemList.Count > 0)
				{
					GenerateItemRequest();
				}
                if (mUserItem != null)
                {
                    mUserItem.RequestBuffer = RequestBuffer;
                    mUserItem.GenerateRequest();
                }
				if (mAdviceDetailList != null && mAdviceDetailList.Count > 0)
				{
					GenerateAdviceDetailRequest();
				}
                if (mDevices!= null)
                {
                    mDevices.RequestBuffer = RequestBuffer;
                    mDevices.GenerateRequest();
                }

			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}
		#endregion
	}
}