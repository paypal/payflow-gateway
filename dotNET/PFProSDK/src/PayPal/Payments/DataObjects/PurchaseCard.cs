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
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Purchase card related information
	/// </summary>
	/// <remarks>
	/// PurchaseCard is associated with CardTender.
	/// <seealso cref="CardTender"/>
	/// </remarks>
	public sealed class PurchaseCard : PaymentCard
	{
		#region "Member Variables"

		/// <summary>
		/// Purchase card type
		/// </summary>
		private String mCommCard;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for PurchaseCard
		/// </summary>
		/// <param name="Acct">Purchase Card number</param>
		/// <param name="ExpDate">Card expiry date</param>
		/// <param name="CommCard">Purchase Card  type</param>
		/// <remarks>This is used as Payment Device for the CardTender.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>Acct --> ACCT, ExpDate --> EXPDATE, CommCard --> COMMCARD</code>
		/// </remarks>
		/// <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		PurchaseCard PayDevice = new PurchaseCard("XXXXXXXXXX","XXXX","C");
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		Dim PayDevice As PurchaseCard = new PurchaseCard("XXXXXXXXXX","XXXX","C")
		///		
		///		..............
		///  </code>
		///  </example>
		///  <seealso cref="CardTender"/>
		public PurchaseCard(String Acct, String ExpDate, String CommCard) : base(Acct, ExpDate)
		{
			mCommCard = CommCard;
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_COMMCARD, mCommCard));
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