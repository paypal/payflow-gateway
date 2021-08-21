#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for PayPal User account information
	/// </summary>
	/// <remarks>
	/// <para>This is a required class for a strong assembly 
	/// transactions. This class is used to store the 
	/// user credential needed to authenticate the user 
	/// performing the transaction.</para>
	/// <para>Every transaction takes UserInfo
	/// mandatorily.</para>
	/// <para>Following are the required user credentials:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Payflow Parameter</term>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <term>USER</term>
	/// <description>Login name. This value is case-sensitive. 
	/// The login name created while registering for the Payflow
	/// account.</description>
	/// </item>
	/// <item>
	/// <term>VENDOR</term>
	/// <description>Login name. This value is case-sensitive. 
	/// The login name created while registering for the Payflow
	/// account.</description>
	/// </item>
	/// <item>
	/// <term>PARTNER</term>
	/// <description>The authorized PayPal Reseller that 
	/// registered this account for the Payflow service 
	/// provided you with a Partner ID.
	/// If you registered yourself, use PayPal.
	/// Case-sensitive.</description>
	/// </item>
	/// <item>
	/// <term>PWD</term>
	/// <description>Case-sensitive 7 to 32-character password.</description>
	/// </item>
	/// </list>
	/// </remarks>
	public sealed class UserInfo : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// User id
		/// </summary>
		private String mUser;

		/// <summary>
		/// Vendor id
		/// </summary>
		private String mVendor;

		/// <summary>
		/// Partner id
		/// </summary>
		private String mPartner;

		/// <summary>
		/// Password
		/// </summary>
		private String mPwd;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="User">User id</param>
		/// <param name="Vendor">Vendor id</param>
		/// <param name="Partner">Partner id</param>
		/// <param name="Pwd">Password</param>
		/// <remarks>
		/// <para>This is a required class for a strong assembly 
		/// transactions. This class is used to store the 
		/// user credential needed to authenticate the user 
		/// performing the transaction.</para>
		/// <para>Every transaction takes UserInfo
		/// mandatorily.</para>
		/// <para>Following are the required user credentials:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Payflow Parameter</term>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <term>USER</term>
		/// <description>Login name. This value is case-sensitive. 
		/// The login name created while registering for the Payflow
		/// account.</description>
		/// </item>
		/// <item>
		/// <term>VENDOR</term>
		/// <description>Login name. This value is case-sensitive. 
		/// The login name created while registering for the Payflow
		/// account.</description>
		/// </item>
		/// <item>
		/// <term>PARTNER</term>
		/// <description>The authorized PayPal Reseller that 
		/// registered this account for the Payflow service 
		/// provided you with a Partner ID.
		/// If you registered yourself, use PayPal.
		/// Case-sensitive.</description>
		/// </item>
		/// <item>
		/// <term>PWD</term>
		/// <description>Case-sensitive 6- to 32-character password.</description>
		/// </item>
		/// </list>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///  ..............
		///  // Create the User data object with the required user details.
		///  UserInfo User = new UserInfo("user", "vendor", "partner", "password");
		///  ..............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///  ..............
		///  ' Create the User data object with the required user details.
		///  Dim User As UserInfo = New UserInfo("user", "vendor", "partner", "password");
		///  ..............
		/// </code>
		/// </example>
		public UserInfo(String User, String Vendor, String Partner, String Pwd)
		{
			mUser = User;
			mVendor = Vendor;
			mPartner = Partner;
			mPwd = Pwd;

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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER, mUser));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_VENDOR, mVendor));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PARTNER, mPartner));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PWD, mPwd));
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