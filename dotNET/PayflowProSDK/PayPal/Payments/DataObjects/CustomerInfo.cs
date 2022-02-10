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

        /// <summary>
        /// Holds ReqName
        /// </summary>
        private String mReqName;

        /// <summary>
        /// Holds Customer Data
        /// </summary>
        private String mCustData;

        /// <summary>
        /// Holds Customer Id
        /// </summary>
        private String mCustomerId;

        /// <summary>
        /// Holds Customer Number
        /// </summary>
        private String mCustomerNumber;

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
        /// Gets, Sets Customer Data
        /// </summary>
        /// <remarks>
        /// <para>Requester Name.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTDATAE</code>
        /// </remarks>
        public String CustData
        {
            get { return mCustData; }
            set { mCustData = value; }
        }

        /// <summary>
        /// Gets, Sets Customer identification.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTOMERID</code>
        /// </remarks>
        public String CustomerId
        {
            get { return mCustomerId; }
            set { mCustomerId = value; }
        }

        /// <summary>
        /// Gets, Sets Customer Number.
        /// </summary>
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>CUSTOMERNUMBER</code>
        /// </remarks>
        public String CustomerNumber
        {
            get { return mCustomerNumber; }
            set { mCustomerNumber = value; }
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
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_REQNAME, mReqName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTCODE, mCustCode));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTIP, mCustIP));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTVATREGNUM, mCustVatRegNum));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DOB, mDob));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTID, mCustId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTHOSTNAME, mCustHostName));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTBROWSER, mCustBrowser));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTDATA, mCustData));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTOMERID, mCustomerId));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTOMERNUMBER, mCustomerNumber));
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