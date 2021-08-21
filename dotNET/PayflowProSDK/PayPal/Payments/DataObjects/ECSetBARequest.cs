#region "Imports"

using System;
using PayPal.Payments.Common ;
using PayPal.Payments.Common.Utility ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout with Billing Agreement (Reference Transaction) without Purchase SET operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECGetBARequest"/>
	/// <seealso cref="ECDoBARequest"/>
	/// </remarks>
	public class ECSetBARequest : ECSetRequest
	{
		#region "Constructor"
		/// <summary>
		/// Constructor for ECSetBARequest
		/// </summary>
		/// <param name="ReturnUrl">String</param>
		/// <param name="CancelUrl">String</param>
		/// <param name="BillingType">String</param>
		/// <param name="BA_Desc">String</param>
		/// <param name="PaymentType">String</param>
		/// <param name="BA_Custom">String</param>
		/// <remarks>
		/// ECSetBARequest is used to set the data required for a Express Checkout Billing Agreement SET operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECSetBARequest object
		///		ECSetBARequest SetEC = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom);
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECSetBARequest object
		///		Dim SetEC As ECSetBARequest = new ECSetBARequest(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom)
		///		
		///		.............
		/// </code>
		/// </example>
		public ECSetBARequest(String ReturnUrl, String CancelUrl, String BillingType, String BA_Desc, String PaymentType, String BA_Custom)
			: base(ReturnUrl, CancelUrl, BillingType, BA_Desc, PaymentType, BA_Custom, PayflowConstants.ACTIONTYPE_SETBA)
		{
		}
		#endregion
	}
}
