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
