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
using PayPal.Payments.Common.Utility ;  
using PayPal.Payments.Common; 
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase DO operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECSetBARequest"/>
	/// <seealso cref="ECGetBARequest"/>
	/// </remarks>
	public class ECDoBARequest : ECDoRequest
	{
		#region "Constructor"

		/// <summary>
		/// Constructor for ECDoBARequest
		/// </summary>
		/// <param name="Token">String</param>
		/// <param name="PayerId">String</param>
		/// <remarks>
		/// ECDoBARequest is used to set the data required for a Express Checkout DO operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECDoBARequest object
		///		ECDoBARequest DoEC = new ECDoBARequest("[tokenid]","[payerid]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECDoBARequest object
		///		Dim DoEC As ECDoBARequest = new ECDoBARequest("[tokenid]","[payerid]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECDoBARequest(String Token, String PayerId) : base(Token, PayerId, PayflowConstants.ACTIONTYPE_DOBA)
		{
		}
		#endregion
	}
}
