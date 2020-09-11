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