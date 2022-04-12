#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class is used to create and use an ACH
	/// ( Automatic Clearing House ) Tender type.
	/// </summary>
	/// <remarks>BankAcct is the Payment device associated with this
	/// tender type.</remarks>
	/// <seealso cref="BankAcct"/>
	public sealed class ACHTender : BaseTender
	{
        #region "Member Variables"

        /// <summary>
        /// ACH Auth Type
        /// </summary>
        private String mAuthType;

        /// <summary>
        /// ACH Prenote (Y/N)
        /// </summary>
        private String mPreNote;

		/// <summary>
		/// ACH Term City
		/// </summary>
		private String mTermCity;

		/// <summary>
		/// ACH Term State
		/// </summary>
		private String mTermState;

		#endregion 

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="BnkAcct">Bank Account object.</param>
		/// <remarks>
		/// ACHTender should be used to perform the transactions 
		/// in which the user provides his bank account details for
		/// the online payment processing.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TENDER</code>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		//BnkAcct is the populated BankAcct object.
		///		.............
		///		
		///		//Create the Tender object
		///		ACHTender Tender = new ACHTender(BnkAcct);
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		//BnkAcct is the populated BankAcct object.
		///		.............
		///		
		///		'Create the Tender object
		///		Dim Tender As ACHTender = new ACHTender(BnkAcct)
		///		
		///		.............
		/// </code>
		/// <seealso cref="BankAcct"/>
		/// </example>
		public ACHTender(BankAcct BnkAcct) : base(PayflowConstants.TENDERTYPE_ACH, BnkAcct)
		{
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets the Prenote.
		/// </summary>
		/// <remarks>
		/// <para>Prenote indicates a prenotification payment with no amount.
		/// Used to verify bank account validity. Receiving banks are not required 
		/// to respond to prenotification payments.</para>
		/// <para>Allowed Prenote values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>PRENOTE</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>N</term>
		/// <description>Default. AMT needs to be passed.</description>
		/// </item>
		/// <item>
		/// <term>Y</term>
		/// <description>Default. AMT does not need to be passed.</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PRENOTE</code>
		/// </remarks>
		public String PreNote
		{
			get { return mPreNote; }

			set { mPreNote = value; }
		}

		/// <summary>
		/// Gets, Sets the Termcity.
		/// </summary>
		/// <remarks>
		/// <para>City where the merchant's terminal is located. 
		/// Used only for POP.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TERMCITY</code>
		/// </remarks>
		public String TermCity
		{
			get { return mTermCity; }

			set { mTermCity = value; }
		}

		/// <summary>
		/// Gets, Sets the Termstate.
		/// </summary>
		/// <remarks>
		/// <para>State where the merchant's terminal is located. 
		/// Used only for POP.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TERMSTATE</code>
		/// </remarks>
		public String TermState
		{
			get { return mTermState; }

			set { mTermState = value; }
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHTYPE, mAuthType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PRENOTE, mPreNote));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TERMCITY, mTermCity));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TERMSTATE, mTermState));
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