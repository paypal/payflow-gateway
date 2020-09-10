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
using PayPal.Payments.DataObjects ;
using PayPal.Payments.Common.Utility; 
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This  class serves as base class of all ExpressCheckout request classes.
	/// </summary>
	/// <remarks>
	/// <para>Each request object is associated with a particular type of expressChecout operation.</para>
	/// <para>Following are the request objects associated with 
	/// different operations of ExpressChecout:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ExpressCheckout operation.</term>
	/// <description>Request data object</description>
	/// </listheader>
	/// <item>
	/// <term>SET operation for ExpressCheckout.</term>
	/// <description><see cref="ECSetRequest">ECSetRequest</see></description>
	/// </item>
	/// <item>
	/// <term>GET operation for ExpressCheckout.</term>
	/// <description><see cref="ECGetRequest">ECGetRequest</see></description>
	/// </item>
	/// <item>
	/// <term>DO operation for ExpressCheckout.</term>
	/// <description><see cref="ECDoRequest">ECDoRequest</see></description>
	/// </item>
	/// </list>
	/// </remarks>
	public class ExpressCheckoutRequest : BaseRequestDataObject
	{
		#region "Member variables"
		private String mToken;
		private String mCountryCode;
		private String mPostalCode;
		private String mAction;
		private String mDoReauthorization;
		#endregion

		#region "Properties"
		
		/// <summary>
		/// Gets and sets the value of the token.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TOKEN</code>
		/// </remarks>
		public String Token
		{
			get{return mToken; }
			set{mToken = value;}
		}

		/// <summary>
		/// Gets and sets the country Code.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>COUNTRYCODE</code>
		/// </remarks>
		public String CountryCode
		{
			get{return mCountryCode; }
			set{mCountryCode = value;}
		}

		/// <summary>
		/// Gets and sets the postal code.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>POSTALCODE</code>
		/// </remarks>
		public String PostalCode
		{
			get{return mPostalCode; }
			set{mPostalCode = value;}
		}

		/// <summary>
		/// Gets and sets the do reauthorization flag.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>DOREAUTHORIZATION</code>
		/// </remarks>
		public String DoReauthorization
		{
			get{return mDoReauthorization; }
			set{mDoReauthorization = value;}
		}

		#endregion

		#region "Constructor"
		/// <summary>
		/// Constructor
		/// </summary>
		internal ExpressCheckoutRequest(String Action) 
		{
			mAction = Action;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		internal ExpressCheckoutRequest(String Action, String Token) 
		{
			mAction = Action;
			mToken = Token;
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal new virtual void GenerateRequest()
		{
			// This function is not called. All the
			// address information is validated and generated
			// in its respective derived classes.
			base.GenerateRequest ();

			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_TOKEN, mToken));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COUNTRYCODE, mCountryCode));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_POSTALCODE, mPostalCode));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ACTION, mAction));	
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_DOREAUTHORIZATION, mDoReauthorization));
		}
		#endregion
	}
}
