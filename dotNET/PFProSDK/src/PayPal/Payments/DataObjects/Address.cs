#region "Imports"

using System;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Abstract class to hold the
	/// Address information.
	/// </summary>
	/// <remarks>This class can be extended to create a new address type.</remarks>
	public abstract class Address : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Holds Street
		/// </summary>
		private String mStreet;

		/// <summary>
		/// Holds Street2
		/// </summary>
		private String mStreet2;

		/// <summary>
		/// Holds City
		/// </summary>
		private String mCity;

		/// <summary>
		/// Holds State
		/// </summary>
		private String mState;

		/// <summary>
		/// Holds Zip
		/// </summary>
		private String mZip;

		/// <summary>
		/// Holds Country
		/// </summary>
		private String mCountry;

		/// <summary>
		/// Holds Phonenum
		/// </summary>
		private String mPhone;

		/// <summary>
		/// Holds Phone2
		/// </summary>
		private String mPhone2;

		/// <summary>
		/// Holds Email
		/// </summary>
		private String mEmail;

		/// <summary>
		/// Holds Fax
		/// </summary>
		private String mFax;

		/// <summary>
		/// Holds First Name
		/// </summary>
		private String mFirstName;

		/// <summary>
		/// Holds Middle Name
		/// </summary>
		private String mMiddleName;

		/// <summary>
		/// Holds Last Name
		/// </summary>
		private String mLastName;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Street
		/// </summary>
		internal String AddressStreet
		{
			get { return mStreet; }
			set { mStreet = value; }
		}

		/// <summary>
		/// Gets, Sets Street2
		/// </summary>
		internal String AddressStreet2
		{
			get { return mStreet2; }
			set { mStreet2 = value; }
		}

		/// <summary>
		/// Gets, Sets City
		/// </summary>
		internal String AddressCity
		{
			get { return mCity; }
			set { mCity = value; }
		}

		/// <summary>
		/// Gets, Sets State
		/// </summary>
		internal String AddressState
		{
			get { return mState; }
			set { mState = value; }
		}

		/// <summary>
		/// Gets, Sets Zip
		/// </summary>
		internal String AddressZip
		{
			get { return mZip; }
			set { mZip = value; }
		}

		/// <summary>
		/// Gets, Sets Country
		/// </summary>
		internal String AddressCountry
		{
			get { return mCountry; }
			set { mCountry = value; }
		}

		/// <summary>
		/// Gets, Sets Phonenum
		/// </summary>
		internal String AddressPhone
		{
			get { return mPhone; }
			set { mPhone = value; }
		}

		/// <summary>
		/// Gets, Sets Phone2
		/// </summary>
		internal String AddressPhone2
		{
			get { return mPhone2; }
			set { mPhone2 = value; }
		}

		/// <summary>
		/// Gets, Sets Email
		/// </summary>
		internal String AddressEmail
		{
			get { return mEmail; }
			set { mEmail = value; }
		}

		/// <summary>
		/// Gets, Sets Fax
		/// </summary>
		internal String AddressFax
		{
			get { return mFax; }
			set { mFax = value; }
		}

		/// <summary>
		/// Gets, Sets Firstname
		/// </summary>
		internal String AddressFirstName
		{
			get { return mFirstName; }
			set { mFirstName = value; }
		}

		/// <summary>
		/// Gets, Sets Middlename
		/// </summary>
		internal String AddressMiddleName
		{
			get { return mMiddleName; }
			set { mMiddleName = value; }
		}

		/// <summary>
		/// Gets, Sets Lastname
		/// </summary>
		internal String AddressLastName
		{
			get { return mLastName; }
			set { mLastName = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for Address.
		/// </summary>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		protected Address()
		{
		}

		#endregion
	}

}