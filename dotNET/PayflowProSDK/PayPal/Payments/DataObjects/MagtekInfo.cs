#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
    /// <summary>
    /// Used for Magtek related information.
    /// </summary>
    /// <remarks>Use the MagtekInfo object for the Magtek
    /// encrypted card reader related information.</remarks>
    /// <example>
    /// <para>Following example shows how to use the MagtekInfo object.</para>
    /// <code lang="C#" escaped="false">
    ///	.................
    ///	// Swipe is the SwipeCard object
    ///	.................
    ///	// Set the Magtek Info details.
    /// MagtekInfo MT = new MagtekInfo();
    /// MT.DeviceSN = "Device Serial Number from reader";
    /// MT.EncMP = "ENCMP from reader";
    /// MT.EncryptionBlockType = "1";
    /// MT.EncTrack1 = "Track 1 data from reader";
    /// MT.EncTrack2 = "Track 2 data from reader";
    /// MT.EncTrack3 = "";
    /// MT.KSN = "KSN from reader";
    /// MT.MagtekCardType = "1";
    /// MT.MPStatus = "MPStatus from reader";
    /// MT.RegisteredBy = "PayPal";
    /// MT.SwipedECRHost = "MAGT";
    /// // When using Encrypted Card Readers you do not populate the SwipeCard object as the data from the Magtek object
    /// // will be used instead.
    /// SwipeCard Swipe = new SwipeCard("");
    /// Swipe.MagtekInfo = MT;
    ///	.................
    ///	</code>
    /// <code lang="Visual Basic" escaped="false">
    ///	.................
    ///	' Inv is the Invoice object
    ///	.................
    ///	' Set the Browser Info details.
    ///	Dim Browser As BrowserInfo = New BrowserInfo
    ///	Browser.BrowserCountryCode  = "USA"
    ///	Browser.BrowserUserAgent = "IE 6.0"
    ///	Inv.BrowserInfo = Browser
    ///	.................
    ///	</code>
    /// </example>
    public sealed class MagtekInfo : BaseRequestDataObject
    {
        #region "Member Variables"

        /// <summary>
        /// Holds Encrypted MagnePrint Information
        /// </summary>
        private String mEncMP;
        /// <summary>
        /// Holds Encryption Block
        /// </summary>
        private String mEncryptionBlockType;
        /// <summary>
        /// Holds Encrypted Track 1 
        /// </summary>
        private String mEncTrack1;
        /// <summary>
        /// Holds Encrypted Track 2
        /// </summary>
        private String mEncTrack2;
        /// <summary>
        /// Holds Encrypted Track 3
        /// </summary>
        private String mEncTrack3;
        /// <summary>
        /// Holds KSN
        /// </summary>
        private String mKSN;
        /// <summary>
        /// Holds Card Type
        /// /// </summary>
        private String mMagtekCardType;
        /// <summary>
        /// Holds MP Status
        /// </summary>
        private String mMPStatus;
        /// <summary>
        /// Holds Registered By
        /// </summary>
        private String mRegisteredBy;
        /// <summary>
        /// Holds Swiped ECR Host
        /// </summary>
        private String mSwipedECRHost;
        /// <summary>
        /// Holds Device Serial Number
        /// </summary>
        private String mDeviceSN;
        /// <summary>
        /// Holds Merchant Id
        /// </summary>
        private String mMerchantId;
        /// <summary>
        /// Holds 4-digit PAN
        /// </summary>
        private String mPAN4;
        /// <summary>
        /// Holds Protection Code
        /// </summary>
        private String mPCode;
        /// <summary>
        /// Holds Authorization Value 1
        /// </summary>
        private String mAuthValue1;
        /// <summary>
        /// Holds Authorization Value 2
        /// </summary>
        private String mAuthValue2;
        /// <summary>
        /// Holds Authorization Value 3
        /// </summary>
        private String mAuthValue3;
        /// <summary>
        /// Holds Magtek User Name
        /// </summary>
        private String mMagtekUserName;
        /// <summary>
        /// Holds Magtek Password
        /// </summary>
        private String mMagtekPassword;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor for BrowserInfo
        /// </summary>
        /// <remarks>Use the MagtekInfo object for the Magtek
        /// encrypted card reader related information.</remarks>
        /// <example>
        /// <para>Following example shows how to use a 
        /// Magtek Info object.</para>
        /// <code lang="C#" escaped="false">
        ///	.................
        ///	// Swipe is the SwipeCard object
        ///	.................
        /// // Set the MagtekInfo object.
        /// MagtekInfo MT = new MagtekInfo();
        /// MT.DeviceSN = "Device Serial Number from reader";
        /// MT.EncMP = "ENCMP from reader";
        /// MT.EncryptionBlockType = "1";
        /// MT.EncTrack1 = "Track 1 data from reader";
        /// // When using Encrypted Card Readers you do not populate the SwipeCard object as the data from the Magtek object
        /// // will be used instead.
        /// SwipeCard Swipe = new SwipeCard("");
        /// Swipe.MagtekInfo = MT;
        ///	.................
        ///	.................
        ///	</code>
        /// <code lang="Visual Basic" escaped="false">
        ///	.................
        ///	' Inv is the Invoice object
        ///	.................
        ///	' Set the Browser Info details.
        ///	Dim Browser As BrowserInfo = New BrowserInfo
        ///	Browser.BrowserCountryCode  = "USA"
        ///	Browser.BrowserUserAgent = "IE 6.0"
        ///	Inv.BrowserInfo = Browser
        ///	.................
        ///	</code>
        /// </example>
        public MagtekInfo()
        {
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets, Sets Magtek Encrypted MagnePrint Information.
        /// </summary>
        /// <remarks>
        /// <para>Encrypted MagnePrint Information returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ENCMP</code>
        /// </remarks>
        public String EncMP
        {
            get { return mEncMP; }
            set { mEncMP = value; }
        }

        /// <summary>
        /// Gets, Sets Magtek Encryption Block.
        /// </summary>
        /// <remarks>
        /// <para>The code which indicates what type of Encryption Block is used.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ENCRYPTIONBLOCKTYPE</code>
        /// </remarks>
        public String EncryptionBlockType
        {
            get { return mEncryptionBlockType; }
            set { mEncryptionBlockType = value; }
        }

        /// <summary>
        /// Gets, Sets Magtek Encrypted Track 1.
        /// </summary>
        /// <remarks>
        /// <para>Encrypted Track 1 information returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ENCTRACKE1</code>
        /// </remarks>
        public String EncTrack1
        {
            get { return mEncTrack1; }
            set { mEncTrack1 = value; }
        }
        /// <summary>
        /// Gets, Sets Magtek Encrypted Track 2.
        /// </summary>
        /// <remarks>
        /// <para>Encrypted Track 2 information returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ENCTRACKE2</code>
        /// </remarks>
        public String EncTrack2
        {
            get { return mEncTrack2; }
            set { mEncTrack2 = value; }
        }
        /// <summary>
        /// Gets, Sets Magtek Encrypted Track 3.
        /// </summary>
        /// <remarks>
        /// <para>Encrypted Track 3 information returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>ENCTRACKE2</code>
        /// </remarks>
        public String EncTrack3
        {
            get { return mEncTrack3; }
            set { mEncTrack3 = value; }
        }

        /// <summary>
        /// Gets or Sets Magtek KSN
        /// </summary>
        /// <remarks>
        /// <para>20 character string returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>KSN</code>
        /// </remarks>
        public String KSN
        {
            get { return mKSN; }
            set { mKSN = value; }
        }

        /// <summary>
        /// Gets or Sets Magtek Card Data Format
        /// </summary>
        /// <remarks>
        /// <para>The code which indicates what type of Card Data Format is being submitted.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MAGTEKCARDTYPE</code>
        /// </remarks>
        public String MagtekCardType
        {
            get { return mMagtekCardType; }
            set { mMagtekCardType = value; }
        }

        /// <summary>
        /// Gets or Sets Magtek MagnePrint Status
        /// </summary>
        /// <remarks>
        /// <para>MagnePrint Status of Card Swipe. This is an alpha numeric string, returned by a MagneSafe device when a card is swiped.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MPSTATUS</code>
        /// </remarks>
        public String MPStatus
        {
            get { return mMPStatus; }
            set { mMPStatus = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Registered By
        /// </summary>
        /// <remarks>
        /// <para>An alpha numeric entry between 1 and 20 characters long.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>REGISTEREDBY</code>
        /// </remarks>
        public String RegisteredBy
        {
            get { return mRegisteredBy; }
            set { mRegisteredBy = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Swipe ECR Host
        /// </summary>
        /// <remarks>
        /// <para>MAGT is the only value that is accepted in the SWIPEDECRHOST parameter.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>SWIPEDECRHOST</code>
        /// </remarks>
        public String SwipedECRHost
        {
            get { return mSwipedECRHost; }
            set { mSwipedECRHost = value; }
        }

        /// <summary>
        /// Gets or Sets Magtek device serial number
        /// </summary>
        /// <remarks>
        /// <para>The device serial number of the Magtek card reader.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>DEVICESN</code>
        /// </remarks>
        public String DeviceSN
        {
            get { return mDeviceSN; }
            set { mDeviceSN = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Merchant Id
        /// </summary>
        /// <remarks>
        /// <para>Your Merchant ID or the Merchant ID of the merchant redeeming the Protection Code.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTID</code>
        /// </remarks>
        public String MerchantId
        {
            get { return mMerchantId; }
            set { mMerchantId = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek PAN4
        /// </summary>
        /// <remarks>
        /// <para>The last four digits of the PAN / account number encoded in the card.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>PAN4</code>
        /// </remarks>
        public String PAN4
        {
            get { return mPAN4; }
            set { mPAN4 = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Protection Code
        /// </summary>
        /// <remarks>
        /// <para>The generated Protection Code.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>PCODE</code>
        /// </remarks>
        public String PCode
        {
            get { return mPCode; }
            set { mPCode = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Authentication Value 1
        /// </summary>
        /// <remarks>
        /// <para>Authentication Value 1 generated with the PCode.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>AUTHVALUE1</code>
        /// </remarks>
        public String AuthValue1
        {
            get { return mAuthValue1; }
            set { mAuthValue1 = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Authentication Value 2
        /// </summary>
        /// <remarks>
        /// <para>Authentication Value 2 generated with the PCode.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>AUTHVALUE2</code>
        /// </remarks>
        public String AuthValue2
        {
            get { return mAuthValue2; }
            set { mAuthValue2 = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek Authentication Value 3
        /// </summary>
        /// <remarks>
        /// <para>Authentication Value 3 generated with the PCode.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>AUTHVALUE3</code>
        /// </remarks>
        public String AuthValue3
        {
            get { return mAuthValue3; }
            set { mAuthValue3 = value; }
        }
        /// <summary>
        /// Gets or Sets MagTek User Name
        /// </summary>
        /// <remarks>
        /// <para> MagTek user name.</para> 
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MAGTEKUSERNAME</code>
        /// </remarks>
        public String MagtekUserName
        {
            get { return mMagtekUserName; }
            set { mMagtekUserName = value; }
        }
        /// <summary>
        /// Gets or Sets Magtek password
        /// </summary>
        /// <remarks>
        /// <para>Magtek password.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MAGTEKPWD</code>
        /// </remarks>
        public String MagtekPassword
        {
            get { return mMagtekPassword; }
            set { mMagtekPassword = value; }
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
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_ENCMP, mEncMP));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_ENCRYPTIONBLOCKTYPE, mEncryptionBlockType));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK1, mEncTrack1));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK2, mEncTrack2));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_ENCTRACK3, mEncTrack3));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_KSN, mKSN));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKCARDTYPE, mMagtekCardType));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_REGISTEREDBY, mRegisteredBy));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_SWIPEDECRHOST, mSwipedECRHost));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_DEVICESN, mDeviceSN));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_MPSTATUS, mMPStatus));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_MERCHANTID, mMerchantId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_PAN4, mPAN4));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_PCODE, mPCode));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE1, mAuthValue1));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE2, mAuthValue2));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_AUTHVALUE3, mAuthValue3));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKUSERNAME, mMagtekUserName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.MAGTEK_PARAM_MAGTEKPWD, mMagtekPassword));
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