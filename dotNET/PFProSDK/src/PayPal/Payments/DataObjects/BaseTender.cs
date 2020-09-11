#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This abstract class serves as base class 
	/// of all tender objects.
	/// </summary>
	/// <remarks>
	/// <para>Each tender type is associated with a Payment Device.</para>
	/// <para>Following are the Payment Devices associated with 
	/// different tender types:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Tender type</term>
	/// <description>Payment Device Data Object</description>
	/// </listheader>
	/// <item>
	/// <term>ACHTender</term>
	/// <description><see cref="BankAcct">BankAcct Class</see></description>
	/// </item>
	/// <item>
	/// <term>CardTender</term>
	/// <description>
	/// <para><see cref="CreditCard">CreditCard Class</see></para>
	/// <para><see cref="PurchaseCard">PurchaseCard Class</see></para>
	/// <para><see cref="SwipeCard">SwipeCard Class</see></para>
	/// </description>
	/// </item>
	/// <item>
	/// <term>CheckTender</term>
	/// <description><see cref="CheckPayment">CheckPayment Class</see></description>
	/// </item>
	/// </list>
	/// </remarks>
	public class BaseTender : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Holds the tender type.
		/// </summary>
		private String mTender;

		/// <summary>
		/// Holds the associated 
		/// payment device.
		/// </summary>
		private PaymentDevice mPaymentDevice;

		/// <summary>
		/// Holds Check number
		/// </summary>
		private String mChkNum;

		/// <summary>
		/// Holds Check type
		/// </summary>
		private String mChkType;
		
		/*/// <summary>
		/// Holds Dl State
		/// </summary>
		///private String mDlState;
		
		/// <summary>
		/// Holds Consent medium
		/// </summary>
		///private String mConsentMedium;
		
		/// <summary>
		/// Holds Customer type
		/// </summary>
		///private String mCustomerType;
		
		/// <summary>
		/// Holds Bank Name
		/// </summary>
		///private String mBankName;
		
		/// <summary>
		/// Holds Bank State
		/// </summary>
		///private String mBankState;*/
		/// <summary>
		/// Holds DL
		/// </summary>
		private String mDL;

		/// <summary>
		/// Holds SS
		/// </summary>
		private String mSS;

        /// <summary>
        /// Holds AuthType
        /// </summary>
        private String mAuthType;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor for BaseTender.
        /// </summary>
        /// <param name="Tender">Tender Type ("C"/"A"/"K")</param>
        /// <param name="PayDevice">Payment Device</param>
        /// Abstract class. Instance cannot be created directly.
        public BaseTender(String Tender, PaymentDevice PayDevice)
		{
			mTender = Tender;
			mPaymentDevice = PayDevice;

		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Tender Type.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TENDER</code>
		/// </remarks>
		protected String Tender
		{
			get { return mTender; }
//			set { mTender = value; }
		}

//		/// <summary>
//		/// Gets, Sets Payment Device.
//		/// </summary>
//		/// <remarks>
//		/// <para>This is the Payment Device associated with
//		/// this tender object.</para>
//		/// <para>Following are the Payment Devices associated with 
//		/// different tender types:</para>
//		/// <list type="table">
//		/// <listheader>
//		/// <term>Tender type</term>
//		/// <description>Payment Device Data Object</description>
//		/// </listheader>
//		/// <item>
//		/// <term>ACHTender</term>
//		/// <description><see cref="BankAcct">BankAcct</see></description>
//		/// </item>
//		/// <item>
//		/// <term>CardTender</term>
//		/// <description>
//		/// <para><see cref="CreditCard">CreditCard</see></para>
//		/// <para><see cref="PurchaseCard">PurchaseCard</see></para>
//		/// <para><see cref="SwipeCard">SwipeCard</see></para>
//		/// </description>
//		/// </item>
//		/// <item>
//		/// <term>CheckTender</term>
//		/// <description><see cref="CheckPayment">CheckPayment</see></description>
//		/// </item>
//		/// </list>
//		/// </remarks>
//		internal PaymentDevice PayDevice
//		{
//			get { return mPaymentDevice; }
//			set { mPaymentDevice = value; }
//		}

		/// <summary>
		/// Gets, Sets Check number.
		/// </summary>
		/// <remarks>
		/// <para>For ACH - The check serial number. 
		/// Required for POP, ARC, and RCK.
		/// </para>
		/// <para>For TeleCheck - Account holder’s next unused 
		/// (available) check number.
		/// </para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CHKNUM</code>
		/// </remarks>
		public virtual String ChkNum
		{
			get { return mChkNum; }
			set { mChkNum = value; }
		}

		/// <summary>
		/// Gets, Sets Check type.
		/// </summary>
		/// <remarks>
		/// <para>Check type.</para>
		/// <para>Allowed CheckTypes are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>CHKTYPE</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>P</term>
		/// <description>Personal.</description>
		/// </item>
		/// <item>
		/// <term>C</term>
		/// <description>Company.</description>
		/// </item>
		/// </list>
		/// </remarks>
		public virtual String ChkType
		{
			get { return mChkType; }
			set { mChkType = value; }
		}
		
/*		/// <summary>
		/// Gets, Sets DlState  
		/// </summary>
		/// <remarks>Not Supported.</remarks>
//		public virtual String DlState
//		{
//			get { return mDlState; }
//			set { mDlState = value; }
//		}

		/// <summary>
		/// Gets, Sets Consent Medium  
		/// </summary>
		/// <remarks>Not Supported.</remarks>
//		public virtual String ConsentMedium
//		{
//			get { return mConsentMedium; }
//			set { mConsentMedium = value; }
//		}

		/// <summary>
		/// Gets, Sets Customer Type  
		/// </summary>
		/// <remarks>Not Supported.</remarks>
//		public virtual String CustomerType
//		{
//			get { return mCustomerType; }
//			set { mCustomerType = value; }
//		}

		/// <summary>
		/// Gets, Sets Bank Name  
		/// </summary>
		/// <remarks>Not Supported.</remarks>
//		public virtual String BankName
//		{
//			get { return mBankName; }
//			set { mBankName = value; }
//		}

		/// <summary>
		/// Gets, Sets Bank State  
		/// </summary>
		/// <remarks>Not Supported.</remarks>
//		public virtual String BankState
//		{
//			get { return mBankState; }
//			set { mBankState = value; }
//		}*/

		/// <summary>
		/// Gets, Sets DL  
		/// </summary>
		/// <remarks>
		/// <para> Driver’s license number.</para>
		/// <para>Format: XXnnnnnnnn</para>
		/// <para>XX = State Code, nnnnnnnn = DL Number</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DL</code>
		/// </remarks>
		public virtual String DL
		{
			get { return mDL; }
			set { mDL = value; }
		}

		/// <summary>
		/// Gets, Sets SS  
		/// </summary>
		/// <remarks>
		/// <para>Account holder’s social security number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SS</code>
		/// </remarks>

		public virtual String SS
		{
			get { return mSS; }
			set { mSS = value; }
		}


        /// <summary>
        /// Sets,gets the AuthType.
        /// </summary>
        /// <remarks>
        /// <para>The type of authorization received from the payer. For both ACH and TeleCheck.</para>
        /// <para>Allowed AuthTypes for ACH are:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>AUTHTYPE</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>CCD</term>
        /// <description>Default for B2B format accounts.</description>
        /// </item>
        /// <item>
        /// <term>PPD</term>
        /// <description>Standard customer authorization method for B2C format accounts.</description>
        /// </item>
        /// <item>
        /// <term>ARC</term>
        /// <description>Accounts Receivables check entry for a single entry debit.</description>
        /// </item>
        /// <item>
        /// <term>RCK</term>
        /// <description>Re-presented check entry for a single entry debit.</description>
        /// </item>
        /// <item>
        /// <term>WEB</term>
        /// <description>The customer authorized the payment over the Internet.</description>
        /// </item>
        /// <item>
        /// <term>TEL</term>
        /// <description>Debit authorization obtained by telephone.</description>
        /// </item>
        /// <item>
        /// <term>POP</term>
        /// <description>Point of Purchase check entry for a single entry debit.</description>
        /// </item>
        /// </list>
        /// <para>Allowed AuthTypes for TeleCheck are:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>AUTHTYPE</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>I</term>
        /// <description>Internet Check Acceptance (ICA) provides the capability to authorize and electronically settle checks over the Internet.</description>
        /// </item>
        /// <item>
        /// <term>P</term>
        /// <description>Checks By Phone (CBP) provides the capability to authorize and electronically settle checks over the phone.</description>
        /// </item>
        /// <item>
        /// <term>D</term>
        /// <description>Prearranged Deposit Services (PPD) debits the customer's account provided the customer has previously accepted a written authorization.</description>
        /// </item>
        /// </list>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>AUTHTYPE</code>
        /// </remarks>
        public virtual String AuthType
        {
            get { return mAuthType; }
            set { mAuthType = value; }
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
				if (mPaymentDevice != null)
				{
					mPaymentDevice.RequestBuffer = RequestBuffer;
					mPaymentDevice.GenerateRequest();
				}

				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TENDER, mTender));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CHKNUM, mChkNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CHKTYPE, mChkType));
//				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DLSTATE , mDlState));
//				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CONSENTMEDIUM, mConsentMedium));
//				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTOMERTYPE, mCustomerType));
//				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BANKNAME, mBankName));
//				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BANKSTATE, mBankState));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DL, mDL));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SS, mSS));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHTYPE, mAuthType));


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