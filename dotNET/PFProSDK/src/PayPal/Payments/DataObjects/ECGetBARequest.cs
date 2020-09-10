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
	/// Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase GET operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECSetBARequest"/>
	/// <seealso cref="ECDoBARequest"/>
	/// </remarks>
	public class ECGetBARequest : ECGetRequest
	{
		#region "Constructor"
		/// <summary>
		/// Constructor for ECGetBARequest
		/// </summary>
		/// <remarks>
		/// ECGetBARequest is used to set the data required for a Express Checkout GET operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECGetBARequest object
		///		ECGetBARequest GetEC = new ECGetRequest("[tokenid]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECGetBARequest object
		///		Dim GetEC As ECGetBARequest = new ECGetBARequest("[tokenid]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECGetBARequest(String Token) : base(Token, PayflowConstants.ACTIONTYPE_GETBA)
		{
		}
		#endregion
	}
}
