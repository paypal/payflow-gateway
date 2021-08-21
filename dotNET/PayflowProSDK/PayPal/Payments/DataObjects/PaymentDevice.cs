#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This abstract class serves as base class of all
	/// payment devices.
	/// </summary>
	/// <remarks>
	/// <para>Each Payment Device is associated with a tender type .</para>
	/// <para>Following are the Payment Devices associated with 
	/// different tender types:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Payment Device Data Object</term>
	/// <description>Tender type</description>
	/// </listheader>
	/// <item>
	/// <term>BankAcct</term>
	/// <description><see cref="ACHTender">ACHTender</see></description>
	/// </item>
	/// <item>
	/// <term>CreditCard, PurchaseCard, SwipeCard</term>
	/// <description>
	/// <para><see cref="CardTender">CardTender</see></para>
	/// </description>
	/// </item>
	/// <item>
	/// <term>CheckPayment</term>
	/// <description><see cref="CheckTender">CheckTender</see></description>
	/// </item>
	/// </list>
	/// </remarks>
	public class PaymentDevice : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Payment Device number
		/// </summary>
		private String mAcct;

		/// <summary>
		/// Payment Device Holder's name
		/// </summary>
		private String mName;
        /// <summary>
        /// Payment Device Magtek Information
        /// </summary>
        public MagtekInfo mMagtekInfo;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		internal PaymentDevice()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Acct">Payment device Number</param>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		public PaymentDevice(String Acct)
		{
			mAcct = Acct;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Acct">Payment device Number</param>
		/// <param name="Name">Payment device holder's name</param>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		public PaymentDevice(String Acct, String Name)
		{
			mAcct = Acct;
			mName = Name;
		}


        #endregion

        #region "Properties"

        /// <summary>
        /// Gets, Sets Acct  
        /// </summary>
        /// <remarks>Account holder's account number.
        /// <para>Maps to Payflow Parameter:s as follows:</para>
        /// <code>
        /// <list type="table">
        /// <listheader>
        /// <term>Specific transaction</term>
        /// <description>Payflow Parameter</description>
        /// </listheader>
        /// <item>
        /// <term>Transactions with CreditCard, PurchaseCard, BankAcct payment devices</term>
        /// <description>ACCT</description>
        /// </item>
        /// <item>
        /// <term>Transactions with CheckPayment</term>
        /// <description>MICR</description>
        /// </item>
        /// <item>
        /// <term>Transactions with SwipeCard</term>
        /// <description>SWIPE</description>
        /// </item>
        /// </list>
        /// </code>
        /// </remarks>
        public virtual String Acct
		{
			get { return mAcct; }
		}

		/// <summary>
		/// Gets, Sets Name  
		/// </summary>
		/// <remarks>Account holder's name.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NAME</code>
		/// </remarks>
		public String Name
		{
			get { return mName; }
			set { mName = value; }
		}

        /// <summary>
        /// Gets, Sets  MagtekInfo
        /// </summary>
        /// <remarks>
        /// Used to hold the Magtek Data.
        /// </remarks>
        public MagtekInfo MagtekInfo
        {
            get { return mMagtekInfo; }
            set { mMagtekInfo = value; }
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
				//Generate default NV Pair for Acct field.
				//This is with Name as ACCT. Used for CC, ACH trxns.
				//In case of TeleCheck, this will be MICR. Handled from derived class.
				//In case of Swipe, this will be SWIPE. Handled from derived class.
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ACCT, mAcct));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_NAME, mName));
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