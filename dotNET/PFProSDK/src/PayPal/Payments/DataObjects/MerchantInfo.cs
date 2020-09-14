#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
    /// <summary>
    /// Used for Merchant related information.
    /// </summary>
    /// <remarks>Use this class to set the Merchant related 
    /// information.  Used for Soft Descriptors.  
    /// 
    /// Refer to the Payflow Gateway Developer's Guide for your processor
    /// for more information related to this fields.</remarks>
    /// <example>
    /// <code lang="C#" escaped="false">
    ///	.................
    ///	// Inv is the Invoice object
    ///	.................
    ///	// Set the Merchant Info details.
    ///	MerchantInfo Merchant = new MerchantInfo();
    ///	Merchant.MerchantName = "MerchantXXXXX";
    ///	Merchant.MerchantCity = "Anywhere";
    ///	Inv.MerchantInfo = Merchant;
    ///	.................
    ///	</code>
    /// <code lang="Visual Basic" escaped="false">
    ///	.................
    ///	' Inv is the Invoice object
    ///	.................
    ///	' Set the Merchant Info details.
    ///	Dim Merchant As MerchantInfo = new MerchantInfo
    ///	Merchant.MerchantName = "MerchantXXXXX"
    ///	Merchant.MerchantCity = "Anywhere"
    ///	Inv.MerchantInfo = Merchant
    ///	.................
    ///	</code>
    /// </example>
    public sealed class MerchantInfo : BaseRequestDataObject
    {
        #region "Member Variables"

        /// <summary>
        /// Merchant Description
        /// </summary>
        private String mMerchDescr;
        /// <summary>
        /// Merchant Telephone
        /// </summary>
        private String mMerchSvc;
        /// <summary>
        /// Holds Merchant Name
        /// </summary>
        private String mMerchantName;
        /// <summary>
        /// Holds Merchant Street
        /// </summary>
        private String mMerchantStreet;
        /// <summary>
        /// Holds Merchant City
        /// </summary>
        private String mMerchantCity;
        /// <summary>
        /// Holds Merchant State
        /// </summary>
        private String mMerchantState;
        /// <summary>
        /// Holds Merchant CountryCode
        /// </summary>
        private String mMerchantCountryCode;
        /// <summary>
        /// Holds Merchant Zip
        /// </summary>
        private String mMerchantZip;
        /// <summary>
        /// Holds Merchant Url
        /// </summary>
        private String mMerchantUrl;
        /// <summary>
        /// Holds Merchant VAT Number
        /// </summary>
        private String mMerchantVatNum;
        /// <summary>
        /// Holds Merchant Invoice Number
        /// </summary>
        private String mMerchantInvNum;
        /// <summary>
        /// MerrchantLocationId
        /// </summary>
        private String mMerchantLocationId;
        /// <summary>
        /// MerchantId
        /// </summary>
        private String mMerchantId;
        /// <summary>
        /// MerchantContactInfo
        /// </summary>
        private String mMerchantContactInfo;

        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        /// Use this class to set the Soft merchant information which is detailed data about a merchant such
        /// as the merchant's name, business address, business location identifier, and contact information.
        /// </remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	.................
        ///	// Inv is the Invoice object
        ///	.................
        ///	// Set the Merchant Info details.
        ///	MerchantInfo Merchant = New MerchantInfo();
        ///	Merchant.MerchantName = "MerchantXXXXX";
        ///	Merchant.MerchantCity = "Somewhere";
        ///	Inv.MerchantInfo = Merchant;
        ///	.................
        ///	</code>
        /// <code lang="Visual Basic" escaped="false">
        ///	.................
        ///	' Inv is the Invoice object
        ///	.................
        ///	' Set the Merchant Info details.
        ///	Dim Merchant As MerchantInfo = New MerchantInfo
        ///	Merchant.MerchantName = "MerchantXXXXX"
        ///	Merchant.MerchantCity = "Somewhere"
        ///	Inv.MerchantInfo = Merchant
        ///	.................
        ///	</code>
        /// </example>
        public MerchantInfo()
        {
        }
        #endregion

        #region "Properties"
     
        /// <summary>
        /// Gets, Sets  Merchant Name
        /// </summary>
        /// <remarks>
        /// <para>Name of Merchant</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTNAME</code>
        /// </remarks>
        public String MerchantName
        {
            get { return mMerchantName; }
            set { mMerchantName = value; }
        }
        /// <summary>
        /// Gets, Sets  Merchant Street
        /// </summary>
        /// <remarks>
        /// <para>Merchant's Street Address (Number and Street Name)</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTSTREET</code>
        /// </remarks>
        public String MerchantStreet
        {
            get { return mMerchantStreet; }
            set { mMerchantStreet = value; }
        }
        /// <summary>
        /// Gets, Sets  Merchant City
        /// </summary>
        /// <remarks>
        /// <para>Merchant's City</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTCITY</code>
        /// </remarks>
        public String MerchantCity
        {
            get { return mMerchantCity; }
            set { mMerchantCity = value; }
        }
        /// <summary>
        /// Gets, Sets  Merchant State
        /// </summary>
        /// <remarks>
        /// <para>Merchant's State</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTSTATE</code>
        /// </remarks>
        public String MerchantState
        {
            get { return mMerchantState; }
            set { mMerchantState = value; }
        }
        /// <summary>
        /// Gets, Sets  Merchant Country Code
        /// </summary>
        /// <remarks>
        /// <para>Merchant's Numeric Country Code.  Example: USA = 840</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTCOUNTRYCODE</code>
        /// </remarks>
        public String MerchantCountryCode
        {
            get { return mMerchantCountryCode; }
            set { mMerchantCountryCode = value; }
        }
        /// <summary>
        /// Gets, Sets  Merchant Zip
        /// </summary>
        /// <remarks>
        /// <para>Merchant's 5- to 9-digit ZIP (postal) code excluding
        /// spaces, dashes, and non-numeric characters.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTZIP</code>
        /// </remarks>
        public String MerchantZip
        {
            get { return mMerchantZip; }
            set { mMerchantZip = value; }
        }

        /// <summary>
        /// Gets, Sets  Merchant Url
        /// </summary>
        /// <remarks>
        /// <para>Merchant's website (URL)</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTURL</code>
        /// </remarks>
        public String MerchantUrl
        {
            get { return mMerchantUrl; }
            set { mMerchantUrl = value; }
        }

        /// <summary>
        /// Gets, Sets  Merchant VAT Number
        /// </summary>
        /// <remarks>
        /// <para>Merchant's VAT Number</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTVATNUM</code>
        /// </remarks>
        public String MerchantVatNum
        {
            get { return mMerchantVatNum; }
            set { mMerchantVatNum = value; }
        }

        /// <summary>
        /// Gets, Sets  Merchant Invoice Number
        /// </summary>
        /// <remarks>
        /// <para>Merchant's Invoice Number</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTINVNUM</code>
        /// </remarks>
        public String MerchantInvNum
        {
            get { return mMerchantInvNum; }
            set { mMerchantInvNum = value; }
        }

        		/// <summary>
        /// Gets, Sets the Merchant Location Id.
        /// </summary>
		/// Merchant assigned store or location number.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTLOCATIONID</code>
        /// </remarks>
        public String MerchantLocationId
        {
            get { return mMerchantLocationId; }
            set { mMerchantLocationId = value; }
        }
		/// <summary>
        /// Gets, Sets the Merchant Id.
        /// </summary>
		/// Processor assigned number.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTID</code>
        /// </remarks>
        public String MerchantId
        {
            get { return mMerchantId; }
            set { mMerchantId = value; }
        }
		/// <summary>
        /// Gets, Sets the Merchant Contact Information.
        /// </summary>
		/// Merchants telephone, URl or email.
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTCONTACTINFO</code>
        /// </remarks>
        public String MerchantContactInfo
        {
            get { return mMerchantContactInfo; }
            set { mMerchantContactInfo = value; }
        }

        /// <summary>
        /// Gets, Sets  MerchDescr
        /// </summary>
        /// <remarks>
        /// <para>Merchant's description.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHDESCR</code>
        /// </remarks>
        /// 
        public String MerchDescr
        {
            get { return mMerchDescr; }
            set { mMerchDescr = value; }
        }

        /// <summary>
        /// Gets, Sets  MerchSvc
        /// </summary>
        /// <remarks>
        /// <para>Merchant's contact number.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHSVC</code>
        /// </remarks>
        public String MerchSvc
        {
            get { return mMerchSvc; }
            set { mMerchSvc = value; }
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
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTNAME, mMerchantName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTSTREET, mMerchantStreet));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTCITY, mMerchantCity));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTSTATE, mMerchantState));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTZIP, mMerchantZip));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTCOUNTRYCODE, mMerchantCountryCode));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTURL, mMerchantUrl));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTVATNUM, mMerchantVatNum));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTINVNUM, mMerchantInvNum));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTLOCATIONID, mMerchantLocationId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTID, mMerchantId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTCONTACTINFO, mMerchantContactInfo));

                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHDESCR, mMerchDescr));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHSVC, mMerchSvc));
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