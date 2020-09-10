#region "Copyright"

//PayPal Payflow Pro .NET SDK
//Copyright (C) 2014  PayPal, Inc.
//
//This file is part of the Payflow Pro .NET SDK
//
//The Payflow .NET SDK is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//any later version.
//
//The Payflow .NET SDK is is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with the Payflow .NET SDK.  If not, see <http://www.gnu.org/licenses/>.


#endregion

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
        /// Gets, Sets  MerchDescr
        /// </summary>
        /// <remarks>
        /// <para>Merchant's description.</para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>MERCHDESCR</code>
        /// </remarks>
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