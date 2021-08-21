#region "Imports"

using System;
using PayPal.Payments.Common ;
using PayPal.Payments.Common.Utility ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout GET operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECSetRequest"/>
	/// <seealso cref="ECDoRequest"/>
	/// </remarks>
	public class ECGetRequest : ExpressCheckoutRequest
	{
		#region "Constructor"
		/// <summary>
		/// Constructor for ECGetRequest
		/// </summary>
		/// <param name="Token">String</param>
		/// <remarks>
		/// ECGetRequest is used to set the data required for a Express Checkout GET operation.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECGetRequest object
		///		ECGetRequest GetEC = new ECGetRequest("[tokenid]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECGetRequest object
		///		Dim GetEC As ECGetRequest = new ECGetRequest("[tokenid]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECGetRequest(String Token) : base(PayflowConstants.ACTIONTYPE_GET, Token)
		{			
		}
		protected ECGetRequest(String Token, String Action) : base(PayflowConstants.ACTIONTYPE_GETBA, Token)
		{			
		}
		#endregion
	}
}
