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
