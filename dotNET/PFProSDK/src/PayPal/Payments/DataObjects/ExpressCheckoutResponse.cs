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
using System.Collections;
using PayPal.Payments.Common.Exceptions ;  
using PayPal.Payments.Common.Utility  ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This  class serves as base class of all ExpressCheckout response classes.
	/// </summary>
	/// <remarks>
	/// <para>Each response object is associated with a particular type of expressCheckout operation.</para>
	/// <para>Following are the reponse objects associated with 
	/// different operations of ExpressChecout:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ExpressCheckout operation.</term>
	/// <description>Request data object</description>
	/// </listheader>
	/// <item>
	/// <term>SET operation for ExpressCheckout.</term>
	/// <description>ExpressCheckoutResponse</description>
	/// </item>
	/// <item>
	/// <term>GET operation for ExpressCheckout.</term>
	/// <description><see cref="ECGetResponse">ECGetResponse</see></description>
	/// </item>
	/// <item>
	/// <term>DO operation for ExpressCheckout.</term>
	/// <description><see cref="ECDoResponse">ECDoResponse</see></description>
	/// </item>
	/// </list>
	/// </remarks>
	public class ExpressCheckoutResponse : BaseResponseDataObject
	{
		#region "Member Variable"
		private String mToken;
		#endregion

		#region "Constructor"
		/// <summary>
		/// constructor
		/// </summary>
		internal ExpressCheckoutResponse() 
		{
		}
		#endregion

		#region "Properties"
		/// <summary>
		/// Retuns the token for the transaction.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TOKEN</code>
		/// </remarks>
		public String Token
		{
			get {return mToken;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Sets Response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal virtual void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mToken = (String) ResponseHashTable[PayflowConstants.PARAM_TOKEN ];
				ResponseHashTable.Remove(PayflowConstants.PARAM_TOKEN);
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
