#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
    /// <summary>
    /// Used for Customer related information.
    /// </summary>
    /// <remarks>Use this class to set the customer related 
    /// information.</remarks>
    /// <example>
    /// <code lang="C#" escaped="false">
    ///	.................
    ///	// Inv is the Invoice object
    ///	.................
    ///	// Set the Customer Info details.
    ///	CustomerInfo Cust = new CustomerInfo();
    ///	Cust.CustCode = "CustXXXXX";
    ///	Cust.CustIP = "255.255.255.255";
    ///	Inv.CustomerInfo = Cust;
    ///	.................
    ///	</code>
    /// <code lang="Visual Basic" escaped="false">
    ///	.................
    ///	' Inv is the Invoice object
    ///	.................
    ///	' Set the Customer Info details.
    ///	Dim Cust As CustomerInfo = New CustomerInfo
    ///	Cust.CustCode = "CustXXXXX"
    ///	Cust.CustIP = "255.255.255.255"
    ///	Inv.CustomerInfo = Cust
    ///	.................
    ///	</code>
    /// </example>
    public sealed class CustomerInfo : BaseRequestDataObject
    {
        #region "Member Variables"

        /// <summary>
        /// Holds customer code
        /// </summary>
        private String mCustCode;

        /// <summary>
        /// Holds customer host name
        /// </summary>
        private String mCustHostName;

        /// <summary>
        /// Holds customer browser
        /// </summary>
        private String mCustBrowser;

        /// <summary>
        /// Holds customer IP
        /// </summary>
        private String mCustIP;

        /// <summary>
        /// Holds Customer Vat registration number
        /// </summary>
        private String mCustVatRegNum;

        /// <summary>
        /// Holds Customer's date of birth
        /// </summary>
        private String mDob;

        /// <summary>
        /// Holds customer id
        /// </summary>
        private String mCustId;

        // <summary>
        // Holds corporate name
        // </summary>
        // Removed 04/07/07 
        // private String mCorpName;

        /// <summary>
        /// Holds ReqName
        /// </summary>
        private String mReqName;
        /// <summary>
        /// Holds MerchantName
        /// </summary>
        private String mMerchantName;
        /// <summary>
        /// Holds MerchantStreet
        /// </summary>
        private String mMerchantStreet;
        /// <summary>
        /// Holds MerchantCity
        /// </summary>
        private String mMerchantCity;
        /// <summary>
        /// Holds MerchantState
        /// </summary>
        private String mMerchantState;
        /// <summary>
        /// Holds MerchantCountryCode
        /// </summary>
        private String mMerchantCountryCode;
        /// <summary>
        /// Holds MerchantZip
        /// </summary>
        private String mMerchantZip;

        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Use this class to set the customer related 
        /// information.</remarks>
        /// <example>
        /// <code lang="C#" escaped="false">
        ///	.................
        ///	// Inv is the Invoice object
        ///	.................
        ///	// Set the Customer Info details.
        ///	CustomerInfo Cust = New CustomerInfo();
        ///	Cust.CustCode = "CustXXXXX";
        ///	Cust.CustIP = "255.255.255.255";
        ///	Inv.CustomerInfo = Cust;
        ///	.................
        ///	</code>
        /// <code lang="Visual Basic" escaped="false">
        ///	.................
        ///	' Inv is the Invoice object
        ///	.................
        ///	' Set the Customer Info details.
        ///	Dim Cust As CustomerInfo = New CustomerInfo
        ///	Cust.CustCode = "CustXXXXX"
        ///	Cust.CustIP = "255.255.255.255"
        ///	Inv.CustomerInfo = Cust
        ///	.................
        ///	</code>
        /// </example>
        public CustomerInfo()
        {
        }
        #endregion

        #region "Properties"

        /// <summary>
        /// Gets, Sets ReqName.
        /// </summary>
        /// <remarks>
        /// <para>Requester Name.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>REQNAME</code>
        /// </remarks>
        public String ReqName
        {
            get { return mReqName; }
            set { mReqName = value; }
        }

        /// <summary>
        /// Gets, Sets  CustCode.
        /// </summary>
        /// <remarks>
        /// <para>Customer code/customer reference ID.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTCODE</code>
        /// </remarks>
        public String CustCode
        {
            get { return mCustCode; }
            set { mCustCode = value; }
        }

        /// <summary>
        /// Gets, Sets  CustIP.
        /// </summary>
        /// <remarks>
        /// <para>Customer's IP address.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTIP</code>
        /// </remarks>
        public String CustIP
        {
            get { return mCustIP; }
            set { mCustIP = value; }
        }

        /// <summary>
        /// Gets, Sets  CustHostName.
        /// </summary>
        /// <remarks>
        /// <para>Customer's name of server that the account holder is connected to.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTHOSTNAME</code>
        /// </remarks>
        public String CustHostName
        {
            get { return mCustHostName; }
            set { mCustHostName = value; }
        }

        /// <summary>
        /// Gets, Sets  CustBrowser.
        /// </summary>
        /// <remarks>
        /// <para>Account holder’s HTTP browser type. Example:
        /// MOZILLA/4.0~(COMPATIBLE;~MSIE~5.0;~WINDOWS~95)</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTBROWSER</code>
        /// </remarks>
        public String CustBrowser
        {
            get { return mCustBrowser; }
            set { mCustBrowser = value; }
        }

        /// <summary>
        /// Gets, Sets  CustVatRegNum.
        /// </summary>
        /// <remarks>
        /// <para>Customer's VAT registrations number.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTVATREGNUM</code>
        /// </remarks>
        public String CustVatRegNum
        {
            get { return mCustVatRegNum; }
            set { mCustVatRegNum = value; }
        }

        /// <summary>
        /// Gets, Sets  DOB.
        /// </summary>
        /// <remarks>
        /// <para>Account holder’s date of birth.</para>
        /// <para>Format: mmddyyyy.</para>
        /// <para>mm - Month, dd - Day, yy - Year.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>DOB</code>
        /// </remarks>
        public String DOB
        {
            get { return mDob; }
            set { mDob = value; }
        }


        /// <summary>
        /// Gets, Sets  CustId.
        /// </summary>
        /// <remarks>
        /// <para>Customer's Id.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTID</code>
        /// </remarks>
        public String CustId
        {
            get { return mCustId; }
            set { mCustId = value; }
        }

        /// <summary>
        /// Gets, Sets  MerchantName.
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
        /// Gets, Sets  MerchantStreet.
        /// </summary>
        /// <remarks>
        /// <para>Merchant's Stree Address (Number and Street Name)</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHANTSTREET</code>
        /// </remarks>
        public String MerchantStreet
        {
            get { return mMerchantStreet; }
            set { mMerchantStreet = value; }
        }
        /// <summary>
        /// Gets, Sets  MerchantCity.
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
        /// Gets, Sets  MerchantState.
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
        /// Gets, Sets  MerchantCountryCode.
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
        /// Gets, Sets  MerchantZip.
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

        // <summary>
        // Gets, Sets  CorpName.
        // </summary>
        // <remarks>
        // <para>Corporation name.</para>
        // <para>Maps to Payflow Parameter:</para>
        // <code>CORPNAME</code>
        // </remarks>
        //public String CorpName
        //{
        //	get { return mCorpName; }
        //	set { mCorpName = value; }
        //}

        // 04/07/07 - Moved Company Name to BillTo class.

        // 04/07/07 - Moved MerchDescr and MerchSvc to Invoice class.

        #endregion

        #region "Core functions"

        /// <summary>
        /// Generates the transaction request.
        /// </summary>
        internal override void GenerateRequest()
        {
            try
            {
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_REQNAME, mReqName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTCODE, mCustCode));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTIP, mCustIP));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTVATREGNUM, mCustVatRegNum));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DOB, mDob));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTID, mCustId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTHOSTNAME, mCustHostName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTBROWSER, mCustBrowser));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTNAME, mMerchantName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTSTREET, mMerchantStreet));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTCITY, mMerchantCity));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTSTATE, mMerchantState));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTZIP, mMerchantZip));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTCOUNTRYCODE, mMerchantCountryCode));

                // 04/07/07 Moved CompanyName to BillTo class.
                // Removed 04/07/07
                // RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CORPNAME, mCorpName));

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