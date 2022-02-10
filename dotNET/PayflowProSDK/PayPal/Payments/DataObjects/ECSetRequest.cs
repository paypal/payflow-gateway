#region "Imports"

using System;
using PayPal.Payments.Common ;
using PayPal.Payments.Common.Utility ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout SET operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECGetRequest"/>
	/// <seealso cref="ECDoRequest"/>
	/// </remarks>
	public class ECSetRequest : ExpressCheckoutRequest
	{
		#region "Member variables"
		private String mReturnURL;
		private String mCancelURL;
		private String mReqConfirmShipping;
        private String mReqBillingAddress;
		private String mNoShipping;
		private String mAddrOverride;
		private String mLocalecode;
		private Currency mMaxAmt;
		private String mPageStyle;
		private String mHdrImg ;		//"cpp-headerimage"
		private String mHdrBorderColor;	//"cpp-header-border-color";
		private String mHdrBackColor;	//"cpp-header-back-color";
		private String mPayFlowColor;	//"cpp-payflow-color";
		private String mBillingType;
		private String mBA_Desc;
		private String mPaymentType;
		private String mBA_Custom;
        private String mShipToName;
        private String mAllowNote;

		// Transaction PayLater object. Has parameters like PromoCode, ProductCategory, etc.
		private PayLater mPayLater;

		#endregion

		#region "Constructor"
		/// <summary>
		/// Constructor for ECSetRequest
		/// </summary>
		/// <param name="ReturnUrl">String</param>
		/// <param name="CancelUrl">String</param>
		/// <remarks>
		/// ECSetRequest is used to set the data required for a Express Checkout SET operation.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECSetrequest object
		///		ECSetRequest SetEC = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECSetrequest object
		///		Dim SetEC As ECSetRequest = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com")
		///		
		///		.............
		/// </code>
		/// </example>
        public ECSetRequest(String ReturnUrl ,String CancelUrl) 
			: base(PayflowConstants.ACTIONTYPE_SET)
		{
			mReturnURL = ReturnUrl;
			mCancelURL = CancelUrl;
		}
		/// <summary>
		/// Constructor for ECSetRequest
		/// </summary>
		/// <param name="ReturnUrl">String</param>
		/// <param name="CancelUrl">String</param>
		/// <param name="PayLater">String</param>
		/// <remarks>
		/// ECSetRequest is used to set the data required for a Express Checkout SET operation.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECSetrequest object
		///		ECSetRequest SetEC = new ECSetRequest("http://www.yourwebsitereturnurl.com", "http://www.yourwebsitecancelurl.com", PayLater);
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECSetrequest object
		///		Dim SetEC As ECSetRequest = new ECSetRequest("http://www.yourwebsitereturnurl.com", "http://www.yourwebsitecancelurl.com", PayLater)
		///		
		///		.............
		/// </code>
		/// </example>
		public ECSetRequest(String ReturnUrl ,String CancelUrl, PayLater PayLater) 
			: base(PayflowConstants.ACTIONTYPE_SET)
		{
			mReturnURL = ReturnUrl;
			mCancelURL = CancelUrl;
			mPayLater = PayLater;
		}
		/// <summary>
		/// Constructor for ECSetRequest
		/// </summary>
		/// <param name="ReturnUrl">String</param>
		/// <param name="CancelUrl">String</param>
		/// <param name="BillingType">String</param>
		/// <param name="BA_Desc">String</param>
		/// <param name="PaymentType">String</param>
		/// <param name="BA_Custom">String</param>
		/// <remarks>
		/// ECSetRequest is used to set the data required for a Express Checkout SET operation.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECSetRequest object.
		///		ECSetRequest SetEC = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com",
		///		"MerchantInitiatedBilling", "Test Transaction", "any", "Something");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECSetRequest object for Reference Transaction with Purchase.
		///		Dim SetEC As ECSetRequest = new ECSetRequest("http://www.yourwebsitereturnurl.com","http://www.yourwebsitecancelurl.com"
		///		"MerchantInitiatedBilling", "Test Transaction", "any", "Something")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECSetRequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom) 
			: base(PayflowConstants.ACTIONTYPE_SET)
		{
			mReturnURL = ReturnUrl;
			mCancelURL = CancelUrl;
			mBillingType = BillingType;
			mBA_Desc = BA_Desc;
			mPaymentType = PaymentType;
			mBA_Custom = BA_Custom;
		}
		protected ECSetRequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom, String Action) 
			: base(PayflowConstants.ACTIONTYPE_SETBA)
		{
			mReturnURL = ReturnUrl;
			mCancelURL = CancelUrl;
			mBillingType = BillingType;
			mBA_Desc = BA_Desc;
			mPaymentType = PaymentType;
			mBA_Custom = BA_Custom;
		}
		#endregion

		#region "Properties"
		
		/// <summary>
		/// Gets or Sets the returnurl.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>RETURNURL</code>
		/// </remarks>
		public String ReturnURL
		{
			get{return mReturnURL; }
			set{mReturnURL = value;}
		}

		/// <summary>
		/// Gets or Sets the cancelurl.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CANCELURL</code>
		/// </remarks>
		public String CancelURL
		{
			get{return mCancelURL; }
			set{mCancelURL = value;}
		}

		/// <summary>
		/// Gets or Sets the ReqConfirmShipping parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>REQCONFIRMSHIPPING</code>
		/// </remarks>
		public String ReqConfirmShipping
		{
			get{return mReqConfirmShipping; }
			set{mReqConfirmShipping = value;}
		}

        /// <summary>
        /// Gets or Sets the ReqBillingAddress parameter.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>REQBILLINGADDRESS</code>
        /// </remarks>
        public String ReqBillingAddress
        {
            get { return mReqBillingAddress; }
            set { mReqBillingAddress = value; }
        }

		/// <summary>
		/// Gets or Sets the NoShipping parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NOSHIPPING</code>
		/// </remarks>
		public String NoShipping
		{
			get{return mNoShipping; }
			set{mNoShipping = value;}
		}

		/// <summary>
		/// Gets or Sets the AddrOveride Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ADDROVERRIDE</code>
		/// </remarks>
		public String AddrOverride
		{
			get{return mAddrOverride; }
			set{mAddrOverride = value;}
		}

		/// <summary>
		/// Gets or Sets the LocaleCode Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>LOCALECODE</code>
		/// </remarks>
		public String LocaleCode
		{
			get{return mLocalecode; }
			set{mLocalecode = value;}
		}

		/// <summary>
		/// Gets or Sets the MaxAmt Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MAXAMT</code>
		/// </remarks>
		public Currency MaxAmt
		{
			get{return mMaxAmt; }
			set{mMaxAmt = value;}
		}

		/// <summary>
		/// Gets or Sets the PageStyle Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAGESTYLE</code>
		/// </remarks>
		public String PageStyle
		{
			get{return mPageStyle; }
			set{mPageStyle = value;}
		}

		/// <summary>
		/// Gets or Sets the HdrImg Parameter.
		/// </summary>
		/// <remarks>	
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>cpp-header-image</code>
		/// </remarks>
		public String HeaderImage
		{
			get{return mHdrImg; }
			set{mHdrImg = value;}
		}

		/// <summary>
		/// Gets or Sets the HdrBorderColor Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>cpp-header-border-color</code>
		/// </remarks>
		public String HeaderBorderColor
		{
			get{return mHdrBorderColor; }
			set{mHdrBorderColor = value;}
		}

		/// <summary>
		/// Gets or Sets the HdrBackColor Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>cpp-header-back-color</code>
		/// </remarks>
		public String HeaderBackColor
		{
			get{return mHdrBackColor; }
			set{mHdrBackColor = value;}
		}

		/// <summary>
		/// Gets or Sets the PayFlowColor Parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>cpp-paflow-color</code>
		/// </remarks>
		public String PayFlowColor
		{
			get{return mPayFlowColor; }
			set{mPayFlowColor = value;}
		}
		/// <summary>
		/// Gets or Sets the Billing Type Parameter.
		/// </summary>
		/// <remarks>
		/// Sets up automated recurring billing for the customer.  The
		/// value is MerchantInitiatedBilling.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLINGTYPE</code>
		/// </remarks>
		public String BillingType
		{
			get{return mBillingType; }
			set{mBillingType = value;}
		}
		/// <summary>
		/// Gets or Sets the Description Parameter.
		/// </summary>
		/// <remarks>
		/// Description of goods or services associated with the
		/// billing agreement.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_DESC</code>
		/// </remarks>
		public String BA_Desc
		{
			get{return mBA_Desc; }
			set{mBA_Desc = value;}
		}
		/// <summary>
		/// Gets or Sets the Payment Type Parameter.
		/// </summary>
		/// <remarks>
		/// Type of payment you require. 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTTYPE</code>
		/// </remarks>
		public String PaymentType
		{
			get{return mPaymentType; }
			set{mPaymentType = value;}
		}
		/// <summary>
		/// Gets or Sets the Custom field Parameter.
		/// </summary>
		/// <remarks>
		/// Custom annotation field for your exclusive use.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_CUSTOM</code>
		/// </remarks>
		public String BA_Custom
		{
			get{return mBA_Custom; }
			set{mBA_Custom = value;}
		}
        /// <summary>
        /// Gets or Sets the Ship to Name Parameter.
        /// </summary>
        /// <remarks>
        /// Custom annotation field for your exclusive use.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>SHIPTONAME</code>
        /// </remarks>
        public String ShipToName
        {
            get { return mShipToName; }
            set { mShipToName = value; }
        }
        /// <summary>
        /// Gets or Sets the Allow Note Parameter.
        /// </summary>
        /// <remarks>
        /// Custom annotation field for your exclusive use.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ALLOWNOTE</code>
        /// </remarks>
        public String AllowNote
        {
            get { return mAllowNote; }
            set { mAllowNote = value; }
        }

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			// This function is not called. All the
			// address information is validated and generated
			// in its respective derived classes.
			base.GenerateRequest ();

			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_RETURNURL, mReturnURL));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CANCELURL, mCancelURL));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_REQCONFIRMSHIPPING, mReqConfirmShipping));
            RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_REQBILLINGADDRESS, mReqBillingAddress));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_NOSHIPPING, mNoShipping));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ADDROVERRIDE, mAddrOverride));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_LOCALECODE, mLocalecode));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MAXAMT, mMaxAmt));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAGESTYLE, mPageStyle));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_HDRIMG, mHdrImg));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_HDRBORDERCOLOR, mHdrBorderColor));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_HDRBACKCOLOR, mHdrBackColor));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYFLOWCOLOR, mPayFlowColor));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BILLINGTYPE, mBillingType));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BA_DESC, mBA_Desc));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYMENTTYPE, mPaymentType));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BA_CUSTOM, mBA_Custom));
            RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTONAME, mShipToName));
            RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ALLOWNOTE, mAllowNote));

			if (mPayLater != null)
			{
				mPayLater.RequestBuffer = RequestBuffer;
				mPayLater.GenerateRequest();;
			}
		}
		#endregion
	}
}
