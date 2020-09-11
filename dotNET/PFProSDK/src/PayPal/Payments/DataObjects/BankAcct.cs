#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for BankAcct information.
	/// </summary>
	/// <remarks>
	/// BankAcct is associated with ACHTender.
	/// <seealso cref="ACHTender"/>
	/// </remarks>
	public sealed class BankAcct : PaymentDevice
	{
		#region "Member Variables"

		/// <summary>
		/// Holds Aba
		/// </summary>
		private String mAba;

		/// <summary>
		/// Holds Bank Acct type
		/// </summary>
		private String mAcctType;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for BankAcct
		/// </summary>
		/// <param name="Acct">Bank Account number</param>
		/// <param name="Aba">Aba number</param>
		/// <remarks>
		/// BankAcct should be used to perform the transactions 
		/// in which the user provides his bank account details for
		/// the online payment processing.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the BankAcct object
		///		BankAcct Account = new BankAcct("XXXXXXXXXXX","XXXXXXXXXXX");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the BankAcct object
		///		Dim Account As BankAcct = new BankAcct("XXXXXXXXXXX","XXXXXXXXXXX")
		///		
		///		.............
		/// </code>
		/// </example>
		public BankAcct(String Acct, String Aba) : base(Acct)
		{
			mAba = Aba;
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets Acct.
		/// </summary>
		/// <remarks>
		/// <para>Customer’s bank account number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ACCT</code>
		/// </remarks>
		public override String Acct
		{
			get { return base.Acct; }
		}

		/// <summary>
		/// Gets, Sets Aba.
		/// </summary>
		/// <remarks>
		/// <para>Target Bank's transit ABA routing number.</para>
		/// <para>Appies only to ACH transactions.(8-digit number)</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ABA</code>
		/// </remarks>
		public String Aba
		{
			get { return mAba; }
			set { mAba = value; }
		}

		/// <summary>
		/// Gets, Sets Acct type
		/// </summary>
		/// <remarks>
		/// <para>Customer's bank account type</para>
		/// <para>Allowed AcctType values are:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>ACCTTYPE</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>C</term>
		/// <description>Checking account</description>
		/// </item>
		/// <item>
		/// <term>S</term>
		/// <description>Savings account</description>
		/// </item>
		/// </list>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ACCTTYPE</code>
		/// </remarks>
		public String AcctType
		{
			get { return mAcctType; }
			set { mAcctType = value; }
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
				//Get the request from base.			
				base.GenerateRequest();
				//Add ABA and ACCTTYPE to parameter list.
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ABA, mAba));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ACCTTYPE, mAcctType));
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