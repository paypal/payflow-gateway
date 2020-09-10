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
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This abstract class serves as base class for 
	/// Buyer auth transactions.
	/// </summary>
	
	public class BuyerAuthTransaction : BaseTransaction
	{
		#region "Constructors"

		/// <summary>
		/// protected Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		protected BuyerAuthTransaction()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		protected BuyerAuthTransaction(String TrxType, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId)
			: base(TrxType, UserInfo, PayflowConnectionData, RequestId)
		{
		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		protected BuyerAuthTransaction(String TrxType, UserInfo UserInfo, String RequestId)
			: this(TrxType, UserInfo, null, RequestId)
		{
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
				base.GenerateRequest();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TE = new TransactionException(Ex);
				throw TE;
			}
            //catch
            //{
            //    throw new Exception();
            //}
		}

		#endregion
	}

}