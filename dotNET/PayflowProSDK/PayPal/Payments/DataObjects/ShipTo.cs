#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for shipping address information
	/// </summary>
	/// <remarks>Shipping address is destination address information.</remarks>
	/// <example>
	/// <para>Following example shows how to use ShipTo.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Inv is the Invoice object.
	///  .................
	///  
	///	//Set the Shipping Address details.
	///	ShipTo Ship = new ShipTo();
	///	Ship.ShipToStreet = "685A E. Middlefield Rd.";
	///	Ship.ShipToStree2 = "Apt. #2";
	///	Ship.ShipToZip = "94043";
	///	Inv.ShipTo = Ship;
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///  .................
	///  'Inv is the Invoice object.
	///  .................
	///  
	///	'Set the Shipping Address details.
	///	Dim Ship As ShipTo = New ShipTo
	///	Ship.ShipToStreet = "685A E. Middlefield Rd."
	///	Ship.ShipToStree2 = "Apt. #2";
	///	Ship.ShipToZip = "94043"
	///	Inv.ShipTo = Ship
	///	.................
	/// </code>
	/// </example>
	public sealed class ShipTo : Address
	{
		#region "Member Variables"

		/// <summary>
		/// Shipping method.
		/// </summary>
		private String mShipMethod;

		/// <summary>
		/// Shipping carrier
		/// </summary>
		private String mShipCarrier;

		/// <summary>
		/// Ship from zip
		/// </summary>
		private String mShipFromZip;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets shipping city 
		/// </summary>
		/// <remarks>
		/// Shipping city
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOCITY</code>
		/// </remarks>
		public String ShipToCity
		{
			get { return base.AddressCity; }
			set { base.AddressCity = value; }
		}

		/// <summary>
		/// Gets, Sets shipping country
		/// </summary>
		/// <remarks>
		/// Shipping country
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOCOUNTRY</code>
		/// </remarks>
		public String ShipToCountry
		{
			get { return base.AddressCountry; }
			set { base.AddressCountry = value; }
		}

		/// <summary>
		/// Gets, Sets shipping email
		/// </summary>
		/// <remarks>
		/// Shipping email
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOEMAIL</code>
		/// </remarks>
		public String ShipToEmail
		{
			get { return base.AddressEmail; }
			set { base.AddressEmail = value; }
		}

		/// <summary>
		/// Gets, Sets shipping first name
		/// </summary>
		/// <remarks>
		/// Shipping first name
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOFIRSTNAME</code>
		/// </remarks>
		public String ShipToFirstName
		{
			get { return base.AddressFirstName; }
			set { base.AddressFirstName = value; }
		}

		/// <summary>
		/// Gets, Sets shipping last name
		/// </summary>
		/// <remarks>
		/// Shipping last name
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOLASTNAME</code>
		/// </remarks>
		public String ShipToLastName
		{
			get { return base.AddressLastName; }
			set { base.AddressLastName = value; }
		}

		/// <summary>
		/// Gets, Sets shipping middle name
		/// </summary>
		/// <remarks>
		/// Shipping middle name
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOMIDDLENAME</code>
		/// </remarks>
		public String ShipToMiddleName
		{
			get { return base.AddressMiddleName; }
			set { base.AddressMiddleName = value; }
		}

		/// <summary>
		/// Gets, Sets shipping phone2
		/// </summary>
		/// <remarks>
		/// Shipping phone 2
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOPHONE2</code>
		/// </remarks>
		public String ShipToPhone2
		{
			get { return base.AddressPhone2; }
			set { base.AddressPhone2 = value; }
		}

		/// <summary>
		/// Gets, Sets shipping phone
		/// </summary>
		/// <remarks>
		/// Shipping phone
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOPHONE</code>
		/// </remarks>
		public String ShipToPhone
		{
			get { return base.AddressPhone; }
			set { base.AddressPhone = value; }
		}

		/// <summary>
		/// Gets, Sets shipping state
		/// </summary>
		/// <remarks>
		/// Shipping state
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOSTATE</code>
		/// </remarks>
		public String ShipToState
		{
			get { return base.AddressState; }
			set { base.AddressState = value; }
		}

		/// <summary>
		/// Gets, Sets shipping street
		/// </summary>
		/// <remarks>
		/// Shipping street
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOSTREET</code>
		/// </remarks>
		public String ShipToStreet
		{
			get { return base.AddressStreet; }
			set { base.AddressStreet = value; }
		}

		/// <summary>
		/// Gets, Sets shipping street2
		/// </summary>
		/// <remarks>
		/// Shipping street 2.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOSTREET2</code>
		/// </remarks>
		public String ShipToStreet2
		{
			get { return base.AddressStreet2; }
			set { base.AddressStreet2 = value; }
		}

		/// <summary>
		/// Gets, Sets shipping zip
		/// </summary>
		/// <remarks>
		/// Ship to postal code (called ZIP code in the USA).
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPTOZIP</code>
		/// </remarks>
		public String ShipToZip
		{
			get { return base.AddressZip; }
			set { base.AddressZip = value; }
		}

		/// <summary>
		/// Gets, Sets shipping method
		/// </summary>
		/// <remarks>
		/// Shipping method
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPMETHOD</code>
		/// </remarks>
		public String ShipMethod
		{
			get { return mShipMethod; }
			set { mShipMethod = value; }
		}

		/// <summary>
		/// Gets, Sets shipping carrier
		/// </summary>
		/// <remarks>
		/// Shipping carrier
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPCARRIER</code>
		/// </remarks>
		public String ShipCarrier
		{
			get { return mShipCarrier; }
			set { mShipCarrier = value; }
		}

		/// <summary>
		/// Gets, Sets ship from zip
		/// </summary>
		/// <remarks>
		/// Ship from postal code (called ZIP code in the USA).
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPFROMZIP</code>
		/// </remarks>
		public String ShipFromZip
		{
			get { return mShipFromZip; }
			set { mShipFromZip = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>Shipping address is destination address information.</remarks>
		/// <example>
		/// <para>Following example shows how to use ShipTo.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///  .................
		///  
		///	//Set the Shipping Address details.
		///	ShipTo Ship = new ShipTo();
		///	Ship.ShipToStreet = "685A E. Middlefield Rd.";
		///	Ship.ShipToStree2 = "Apt. #2";
		///	Ship.ShipToZip = "94043";
		///	Inv.ShipTo = Ship;
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///  .................
		///  'Inv is the Invoice object.
		///  .................
		///  
		///	'Set the Shipping Address details.
		///	Dim Ship As ShipTo = New ShipTo
		///	Ship.ShipToStreet = "685A E. Middlefield Rd."
		///	Ship.ShipToStree2 = "Apt. #2";
		///	Ship.ShipToZip = "94043"
		///	Inv.ShipTo = Ship
		///	.................
		/// </code>
		/// </example>
		public ShipTo()
		{
		}

		#endregion

		#region "Utility function"

		/// <summary>
		/// This method copies the common contents
		/// from shipping to billing address.
		/// </summary>
		/// <returns>Billing Address object</returns>
		/// <remarks>This method can be used to 
		/// populate the shipping addresses directly 
		/// from the billing addresses when 
		/// both are the same.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		/// 
		///		................
		///		//Ship is the object of
		///		//ShipTo populated with 
		///		//the shipping addresses.
		///		................
		///		
		///		
		///		BillTo Bill;
		///		
		///		//Populate billing addresses
		///		//from shipping addresses.
		///		Bill = Ship.Copy();
		///		
		///		................
		/// 
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		/// 
		///		................
		///		'Ship is the object of
		///		'ShipTo populated with 
		///		'the shipping addresses.
		///		................
		///		
		///		
		///		BillTo Bill;
		///		
		///		'Populate billing addresses
		///		'from shipping addresses.
		///		Bill = Ship.Copy()
		///		
		///		................
		/// 
		/// </code>
		/// </example>
		/// <seealso cref="BillTo"/>
		public BillTo Copy()
		{
			BillTo CopyObject = new BillTo();
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOSTREET, this.ShipToStreet));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOSTREET2, this.ShipToStreet2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOCITY, this.ShipToCity));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOSTATE, this.ShipToState));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOCOUNTRY, this.ShipToCountry));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOZIP, this.ShipToZip));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOPHONE, this.ShipToPhone));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOPHONE2, this.ShipToPhone2));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOEMAIL, this.ShipToEmail));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOFIRSTNAME, this.ShipToFirstName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOMIDDLENAME, this.ShipToMiddleName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPTOLASTNAME, this.ShipToLastName));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPCARRIER, mShipCarrier));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPMETHOD, mShipMethod));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPFROMZIP, mShipFromZip));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPPEDFROMZIP, mShipFromZip));
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