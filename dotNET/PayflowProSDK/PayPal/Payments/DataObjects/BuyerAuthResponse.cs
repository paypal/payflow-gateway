#region "Imports"

using System;
using System.Collections;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for the Buyer Authorization operation
	/// </summary>
	public class BuyerAuthResponse : BaseResponseDataObject
	{
		#region "CONSTRUCTOR"

		internal BuyerAuthResponse()
		{}

		#endregion

		#region "Member Variables"

		/// <summary>
		/// Holds Acs Url
		/// </summary>
		private String mAcsUrl;

		/// <summary>
		/// Holds Authentication Id
		/// </summary>
		private String mAuthenticationId;

		/// <summary>
		/// Holds Authentication status
		/// </summary>
		private String mAuthenticationStatus;

		/// <summary>
		/// Holds CAVV
		/// </summary>
		private String mCavv;

		/// <summary>
		/// Holds ECI
		/// </summary>
		private String mEci;

		/// <summary>
		/// Holds PAREQ
		/// </summary>
		private String mPaReq;

		/// <summary>
		/// Holds XID
		/// </summary>
		private String mXid;

		/// <summary>
		/// Holds MD
		/// </summary>
		private String mMd;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets the AcsUrl parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ACSURL</code>
		/// </remarks>
		public String AcsUrl
		{
			get { return mAcsUrl; }
		}

		/// <summary>
		/// Gets the authentication_id parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AUTHENTICATION_ID</code>
		/// </remarks>
		public String Authentication_Id
		{
			get { return mAuthenticationId; }
		}

		/// <summary>
		/// Gets the authentication_status parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AUTHENTICATION_STATUS</code>
		/// </remarks>
		public String Authentication_Status
		{
			get { return mAuthenticationStatus; }
		}

		/// <summary>
		/// Gets the CAVV parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CAVV</code>
		/// </remarks>
		public String CAVV
		{
			get { return mCavv; }
		}

		/// <summary>
		/// Gets the ECI parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ECI</code>
		/// </remarks>
		public String ECI
		{
			get { return mEci; }
		}

		/// <summary>
		/// Gets the PaReq parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAREQ</code>
		/// </remarks>
		public String PaReq
		{
			get { return mPaReq; }
		}

		/// <summary>
		/// Gets the XID parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>XID</code>
		/// </remarks>
		public String XID
		{
			get { return mXid; }
		}

		/// <summary>
		/// Gets the MD parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MD</code>
		/// </remarks>
		public String MD
		{
			get { return mMd; }
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Sets the Response parameters in Response data objects.
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal void SetParams(ref Hashtable ResponseHashTable)
		{
			mAcsUrl = (String) ResponseHashTable[PayflowConstants.PARAM_ACSURL];
			mAuthenticationId = (String) ResponseHashTable[PayflowConstants.PARAM_AUTHENICATION_ID];
			mAuthenticationStatus = (String) ResponseHashTable[PayflowConstants.PARAM_AUTHENICATION_STATUS];
			mCavv = (String) ResponseHashTable[PayflowConstants.PARAM_CAVV];
			mEci = (String) ResponseHashTable[PayflowConstants.PARAM_ECI];
			mMd = (String) ResponseHashTable[PayflowConstants.PARAM_MD];
			mPaReq = (String) ResponseHashTable[PayflowConstants.PARAM_PAREQ];
			mXid = (String) ResponseHashTable[PayflowConstants.PARAM_XID];

			ResponseHashTable.Remove(PayflowConstants.PARAM_ACSURL);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AUTHENICATION_ID);
			ResponseHashTable.Remove(PayflowConstants.PARAM_AUTHENICATION_STATUS);
			ResponseHashTable.Remove(PayflowConstants.PARAM_CAVV);
			ResponseHashTable.Remove(PayflowConstants.PARAM_ECI);
			ResponseHashTable.Remove(PayflowConstants.PARAM_MD);
			ResponseHashTable.Remove(PayflowConstants.PARAM_PAREQ);
			ResponseHashTable.Remove(PayflowConstants.PARAM_XID);
		}

		#endregion
	}

}