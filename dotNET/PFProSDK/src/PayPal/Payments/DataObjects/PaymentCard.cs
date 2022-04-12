#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This abstract class serves as base
	/// class for Card Payment devices.
	/// </summary>
	/// <remarks>This class can be extended to create a new payment device type.</remarks>
	public class PaymentCard : PaymentDevice
	{
		#region "Member Variables"

		/// <summary>
		/// Card Expiry Date
		/// </summary>
		private String mExpDate;

		/// <summary>
		/// Card CVV2 code
		/// </summary>
		private String mCvv2;
		
		/// <summary>
		/// CardStart
		/// </summary>
		private String mCardStart;

		/// <summary>
		/// Card Issue
		/// </summary>
		private String mCardIssue;

        /// <summary>
        /// Card on File
        /// </summary>
        private String mCardonFile;

        /// <summary>
        /// Card on File Transaction ID
        /// </summary>
        private String mTxId;

		/// <summary>
		/// Payment Account Reference
		/// </summary>
		private String mParId;




		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Acct">Card number</param>
		/// <param name="ExpDate">Card expiry date</param>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		public PaymentCard(String Acct, String ExpDate) : base(Acct)
		{
			mExpDate = ExpDate;
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets  Cvv2
		/// </summary>
		/// <remarks>
		/// Card validation code. This is the 3 or 4 digit code 
		/// present at the back side of the card.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CVV2</code>
		/// </remarks>
		public String Cvv2
		{
			get { return mCvv2; }
			set { mCvv2 = value; }
		}
		/// <summary>
		/// Gets, Sets  CardStart
		/// </summary>
		/// <remarks>
		/// Used for Switch/Solo Cards.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CARDSTART</code>
		/// </remarks>
		public String CardStart
		{
			get { return mCardStart; }
			set { mCardStart= value; }
		}
		/// <summary>
		/// Gets, Sets  CardIssue
		/// </summary>
		/// <remarks>
		/// Used for Switch/Solo Cards. 
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CARDISSUE</code>
		/// </remarks>
		public String CardIssue
		{
			get { return mCardIssue; }
			set { mCardIssue = value; }
		}

        /// <summary>
        /// Gets, Sets  Card on File
        /// </summary>
        /// <remarks>
        /// Used to flag if the card is on file.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CARDONFILE</code>
        /// </remarks>
        public String CardonFile
        {
            get { return mCardonFile; }
            set { mCardonFile = value; }
        }

        /// <summary>
        /// Gets, Sets  Transaction ID
        /// </summary>
        /// <remarks>
        /// Used to flag if the card is on file.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>TXID</code>
        /// </remarks>
        public String TxId
        {
            get { return mTxId; }
            set { mTxId = value; }
        }

		/// <summary>
		/// Gets, Sets PAR
		/// </summary>
		/// <remarks>
		/// Reference number assigned to each unique Primary Account Number (PAN).
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAR</code>
		/// </remarks>
		public String ParId
		{
			get { return mParId; }
			set { mParId = value; }
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
				base.GenerateRequest();
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_EXPDATE, mExpDate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CVV2, mCvv2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CARDSTART, mCardStart));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CARDISSUE, mCardIssue));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CARDONFILE, mCardonFile));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TXID, mTxId));
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
		}
		#endregion
	}
}