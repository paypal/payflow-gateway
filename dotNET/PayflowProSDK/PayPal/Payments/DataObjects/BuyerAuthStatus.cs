#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for BuyerAuth Status information.
	/// </summary>
	/// <remarks>Use this class to set the BuyerAuth Status related 
	/// information.</remarks>
	public sealed class BuyerAuthStatus : BaseRequestDataObject
	{
		#region "Member Variables"
		     
		/// <summary>
		/// Holds AuthenticationId
		/// </summary>
		private String mAuthenticationId;

		/// <summary>
		/// Holds Authentication Status
		/// </summary>
		private String mAuthenticationStatus;

		/// <summary>
		/// Holds ECI value
		/// </summary>
		private String mECI;

		/// <summary>
		/// Holds CAVV
		/// </summary>
		private String mCAVV;

		/// <summary>
		/// Holds XID
		/// </summary>
		private String mXID;

        /// <summary>
        /// Holds Directory Server Transaction Id
        /// </summary>
        private String mDSTransactionId;

        /// <summary>
        /// Holds 3D-Secure version
        /// </summary>
        private String mThreeDSVersion;

        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Use this class to set the BuyerAuth Status
        /// information.</remarks>
        public BuyerAuthStatus()
		{}
		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets AuthenticationId.
		/// </summary>
		/// <remarks>
		/// <para>AuthenticationId.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AUTHENTICATION_ID</code>
		/// </remarks>
		public String AuthenticationId
		{
			get { return mAuthenticationId; }
			set { mAuthenticationId = value; }
		}

		/// <summary>
		/// Gets, Sets  AuthenticationStatus.
		/// </summary>
		/// <remarks>
		/// <para>Authentication Status</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AUTHENTICATION_STATUS</code>
		/// </remarks>
		public String AuthenticationStatus
		{
			get { return mAuthenticationStatus; }
			set { mAuthenticationStatus = value; }
		}

		/// <summary>
		/// Gets, Sets  ECI.
		/// </summary>
		/// <remarks>
		/// <para>ECI</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ECI</code>
		/// </remarks>
		public String ECI
		{
			get { return mECI; }
			set { mECI = value; }
		}

		/// <summary>
		/// Gets, Sets  CAVV.
		/// </summary>
		/// <remarks>
		/// <para>CAVV</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CAVV</code>
		/// </remarks>
		public String CAVV
		{
			get { return mCAVV; }
			set { mCAVV = value; }
		}

		/// <summary>
		/// Gets, Sets  XID.
		/// </summary>
		/// <remarks>
		/// <para>XID</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>XID</code>
		/// </remarks>
		public String XID
		{
			get { return mXID; }
			set { mXID = value; }
		}

        /// <summary>
        /// Gets, Sets  Directory Server Transaction Id.
        /// </summary>
        /// <remarks>
        /// <para>Directory Server Transaction Id</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>DSTRANSACTIONID</code>
        /// </remarks>
        public String DSTransactionId
        {
            get { return mDSTransactionId; }
            set { mDSTransactionId = value; }
        }

        /// <summary>
        /// Gets, Sets 3D-Secure Version.
        /// </summary>
        /// <remarks>
        /// <para>3D-Secure Version</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>THREEDSVERSION</code>
        /// </remarks>
        public String ThreeDSVersion
        {
            get { return mThreeDSVersion; }
            set { mThreeDSVersion = value; }
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHENICATION_ID, mAuthenticationId));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_AUTHENICATION_STATUS, mAuthenticationStatus));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ECI, mECI));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CAVV, mCAVV));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_XID, mXID));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DSTRANSACTIONID, mDSTransactionId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_THREEDSVERSION, mThreeDSVersion));
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