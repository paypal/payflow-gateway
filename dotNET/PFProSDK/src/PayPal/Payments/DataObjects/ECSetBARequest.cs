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
using PayPal.Payments.Common ;
using PayPal.Payments.Common.Utility ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase SET operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECGetBARequest"/>
	/// <seealso cref="ECDoBARequest"/>
	/// </remarks>
	public class ECSetBARequest : ECSetRequest
	{
		#region "Constructor"
		/// <summary>
		/// Constructor for ECSetBARequest
		/// </summary>
		/// <param name="ReturnUrl">String</param>
		/// <param name="CancelUrl">String</param>
		/// <param name="BillingType">String</param>
		/// <param name="BA_Desc">String</param>
		/// <param name="PaymentType">String</param>
		/// <param name="BA_Custom">String</param>
		/// <remarks>
		/// ECSetBARequest is used to set the data required for a Express Checkout Billing Agreement SET operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECSetBARequest object
		///		ECSetBARequest SetEC = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom);
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECSetBARequest object
		///		Dim SetEC As ECSetBARequest = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom)
		///		
		///		.............
		/// </code>
		/// </example>
		public ECSetBARequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom)
			: base(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom, PayflowConstants.ACTIONTYPE_SETBA)
		{
		}
		#endregion
	}
}
