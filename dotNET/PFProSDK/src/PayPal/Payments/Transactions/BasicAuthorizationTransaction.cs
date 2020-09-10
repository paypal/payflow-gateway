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
using PayPal.Payments.DataObjects; 
#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// Summary description for BasicAuthorizationTransaction.
	/// </summary>
	internal class BasicAuthorizationTransaction : AuthorizationTransaction
	{
		#region "Constructors"
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tender"></param>
		/// <param name="Invoice"></param>
		/// <param name="UserInfo"></param>
		/// <param name="PayflowConnectionData"></param>
		/// <param name="RequestId"></param>
		public BasicAuthorizationTransaction (PayPalTender Tender, Invoice Invoice, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) 
			: base("B" ,UserInfo ,PayflowConnectionData ,Invoice ,Tender   ,RequestId)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tender"></param>
		/// <param name="Invoice"></param>
		/// <param name="UserInfo"></param>
		/// <param name="RequestId"></param>
		public BasicAuthorizationTransaction (PayPalTender Tender, Invoice Invoice, UserInfo UserInfo, String RequestId) 
			: base("B", UserInfo ,Invoice , Tender ,RequestId)
		{
		}
		#endregion

	}
}
