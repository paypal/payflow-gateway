#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Billing Address information
	/// </summary>
	/// <remarks>Billing address is Cardholder's address information.</remarks>
	/// <example>
	/// <para>Following example shows how to use BillTo.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Inv is the Invoice object.
	///  .................
	///  
	///	//Set the Billing Address details.
	///	BillTo Bill = new BillTo();
	///	Bill.BillToStreet = "123 Main St.";
	///	Bill.BillToZip = "12345";
	///	Inv.BillTo = Bill;
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///  .................
	///  'Inv is the Invoice object.
	///  .................
	///  
	///	'Set the Billing Address details.
	///	Dim Bill As BillTo = New BillTo
	///	Bill.BillToStreet = "123 Main St."
	///	Bill.BillToZip = "12345"
	///	Inv.BillTo = Bill
	///	.................
	/// </code>
	/// </example>
	public sealed class BillTo : Address
	{
		#region "Member variables"

		/// <summary>
		/// Home phone
		/// </summary>
		private String mBillToHomePhone;

		/// <summary>
		/// Company Name
		/// </summary>
		private String mBillToCompanyName;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Billing City.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s billing city.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOCITY</code>
		/// </remarks>
		public String BillToCity
		{
			get { return base.AddressCity; }
			set { base.AddressCity = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Country.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s billing country code</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOCOUNTRY</code>
		/// </remarks>
		public String BillToCountry
		{
			get { return base.AddressCountry; }
			set { base.AddressCountry = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Email.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s e-mail address</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOEMAIL</code>
		/// </remarks>
		public String BillToEmail
		{
			get { return base.AddressEmail; }
			set { base.AddressEmail = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Fax
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s fax address.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOFAX</code>
		/// </remarks>
		public String BillToFax
		{
			get { return base.AddressFax; }
			set { base.AddressFax = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Firstname.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s first name.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOFIRSTNAME</code>
		/// </remarks>
		public String BillToFirstName
		{
			get { return base.AddressFirstName; }
			set { base.AddressFirstName = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Lastname.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s last name.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BillTOLASTNAME</code>
		/// </remarks>
		public String BillToLastName
		{
			get { return base.AddressLastName; }
			set { base.AddressLastName = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Middlename.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s middle name.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOMIDDLENAME</code>
		/// </remarks>
		public String BillToMiddleName
		{
			get { return base.AddressMiddleName; }
			set { base.AddressMiddleName = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Phone2.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s 2nd telephone number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOPHONE2</code>
		/// </remarks>
		public String BillToPhone2
		{
			get { return base.AddressPhone2; }
			set { base.AddressPhone2 = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Phonenum
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s telephone number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOPHONENUM</code>
		/// </remarks>
		public String BillToPhone
		{
			get { return base.AddressPhone; }
			set { base.AddressPhone = value; }
		}

		/// <summary>
		/// Gets, Sets Billing State.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s billing state code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOSTATE</code>
		/// </remarks>
		public String BillToState
		{
			get { return base.AddressState; }
			set { base.AddressState = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Street.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s billing street address 
		/// (used for AVS and reporting).</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOSTREET</code>
		/// </remarks>
		public String BillToStreet
		{
			get { return base.AddressStreet; }
			set { base.AddressStreet = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Street2
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s billing street 2 address 
		/// (used for AVS and reporting).</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOSTREET2</code>
		/// </remarks>
		public String BillToStreet2
		{
			get { return base.AddressStreet2; }
			set { base.AddressStreet2 = value; }
		}

		/// <summary>
		/// Gets, Sets Billing Zip.
		/// </summary>
		/// <remarks>
		/// <para>Account holder’s 5- to 9-digit postal code
		///  (called ZIP code in the USA). 
		///  Do not use spaces, dashes, 
		///  or non-numeric characters.
		///  The postal code is verified by the 
		///  AVS service.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BILLTOZIP</code>
		/// </remarks>
		public String BillToZip
		{
			get { return base.AddressZip; }
			set { base.AddressZip = value; }
		}

		/// <summary>
		/// Gets, Sets Billing HomePhone.
		/// </summary>
		/// <remarks>
		/// <para>Cardholder’s home telephone number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>HOMEPHONE</code>
		/// </remarks>
		public String BillToHomePhone
		{
			get { return mBillToHomePhone; }
			set { mBillToHomePhone = value; }
		}

		/// <summary>
		/// Gets, Sets  CompanyName.
		/// </summary>
		/// <remarks>
		/// <para>Company Name.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COMPANYNAME</code>
		/// </remarks>
		public String BillToCompanyName
		{
			get { return mBillToCompanyName; }
			set { mBillToCompanyName = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>Billing address is Cardholder's address information.</remarks>
		/// <example>
		/// <para>Following example shows how to use BillTo.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///  .................
		///  
		///	//Set the Billing Address details.
		///	BillTo Bill = new BillTo();
		///	Bill.BillToStreet = "123 Main St.";
		///	Bill.BillToZip = "12345";
		///	Inv.BillTo = Bill;
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///  .................
		///  'Inv is the Invoice object.
		///  .................
		///  
		///	'Set the Billing Address details.
		///	Dim Bill As BillTo = New BillTo
		///	Bill.BillToStreet = "123 Main St."
		///	Bill.BillToZip = "12345"
		///	Inv.BillTo = Bill
		///	.................
		/// </code>
		/// </example>
		public BillTo()
		{
		}

		#endregion

		#region "Utility function"

		/// <summary>
		/// This method copies the common contents
		/// from billing to shipping address.
		/// </summary>
		/// <returns>ShipTo object</returns>
		/// <remarks>This method can be used to 
		/// populate the shipping addresses directly 
		/// from the billing addresses when 
		/// both are the same.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		/// 
		///		................
		///		//Bill is the object of
		///		//BillTo populated with 
		///		//the billing addresses.
		///		................
		///		
		///		
		///		ShipTo Ship;
		///		
		///		//Populate shipping addresses
		///		//from billing addresses.
		///		Ship = Bill.Copy();
		///		
		///		................
		/// 
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		/// 
		///		................
		///		'Bill is the object of
		///		'BillTo populated with 
		///		'the billing addresses.
		///		................
		///		
		///		
		///		Dim Ship As ShipTo
		///		
		///		'Populate shipping addresses
		///		'from billing addresses.
		///		Ship = Bill.Copy()
		///		
		///		................
		/// 
		/// </code>
		/// </example>
		/// <seealso cref="ShipTo"/>
		public ShipTo Copy()
		{
			ShipTo CopyObject = new ShipTo();
			CopyObject.AddressCity = AddressCity;
			CopyObject.AddressCountry = AddressCountry;
			CopyObject.AddressEmail = AddressEmail;
			CopyObject.AddressFax = AddressFax;
			CopyObject.AddressFirstName = AddressFirstName;
			CopyObject.AddressLastName = AddressLastName;
			CopyObject.AddressMiddleName = AddressMiddleName;
			CopyObject.AddressPhone2 = AddressPhone2;
			CopyObject.AddressPhone = AddressPhone;
			CopyObject.AddressState = AddressState;
			CopyObject.AddressStreet = AddressStreet;
			CopyObject.AddressStreet2 = AddressStreet2;
			CopyObject.AddressZip = AddressZip;
			return CopyObject;
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_STREET, this.BillToStreet));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BILLTOSTREET2, this.BillToStreet2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CITY, this.BillToCity));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_STATE, this.BillToState));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BILLTOCOUNTRY, this.BillToCountry));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ZIP, this.BillToZip));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PHONENUM, this.BillToPhone));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BILLTOPHONE2, this.BillToPhone2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_EMAIL, this.BillToEmail));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_FAX, this.BillToFax));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_FIRSTNAME, this.BillToFirstName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MIDDLENAME, this.BillToMiddleName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_LASTNAME, this.BillToLastName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_HOMEPHONE, mBillToHomePhone));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COMPANYNAME, mBillToCompanyName));
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