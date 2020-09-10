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

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Credit Card related information
	/// </summary>
	/// <remarks>
	/// CreditCard is associated with CardTender.
	/// <seealso cref="CardTender"/>
	/// </remarks>
	public sealed class CreditCard : PaymentCard
	{
		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="Acct">Credit card number</param>
		/// <param name="ExpDate">Card expiry date</param>
		/// <remarks>This is used as Payment Device for the CardTender.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>Acct --> ACCT, ExpDate --> EXPDATE</code>
		/// </remarks>
		/// <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		CreditCard PayDevice = new CreditCard("XXXXXXXXXX","XXXX");
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		Dim PayDevice As CreditCard = new CreditCard("XXXXXXXXXX","XXXX")
		///		
		///		..............
		///  </code>
		///  </example>
		///  <seealso cref="CardTender"/>
		public CreditCard(String Acct, String ExpDate) : base(Acct, ExpDate)
		{
		}

		#endregion
	}

}