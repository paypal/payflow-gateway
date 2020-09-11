#region "Imports"

using System;
using PayPal.Payments.Common.Utility ;  
using PayPal.Payments.Common; 
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout DO operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ECSetRequest"/>
	/// <seealso cref="ECGetRequest"/>
	/// </remarks>
	public class ECDoRequest : ExpressCheckoutRequest
	{
		#region "Member Variables"
		private String mPayerId;
		#endregion
		
		#region "Constructors"
		/// <summary>
		/// Constructor for ECDoRequest
		/// </summary>
		/// <param name="Token">String</param>
		/// <param name="PayerId">String</param>
		/// <remarks>
		/// ECDoRequest is used to set the data required for a Express Checkout DO operation.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECDoRequest object
		///		ECDoRequest DoEC = new ECDoRequest("[tokenid]","[payerid]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECDoRequest object
		///		Dim DoEC As ECDoRequest = new ECDoRequest("[tokenid]","[payerid]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECDoRequest(String Token, String PayerId) : base(PayflowConstants.ACTIONTYPE_DO, Token)
		{
			mPayerId = PayerId;
		}
		protected ECDoRequest(String Token, String PayerId, String Action) : base(PayflowConstants.ACTIONTYPE_DOBA, Token)
		{
			mPayerId = PayerId;
		}

		#endregion

		#region "Properties"
		
		/// <summary>
		/// Gets or Sets the payerid parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYERID</code>
		/// </remarks>
		public String PayerId
		{
			get{return mPayerId; }
			set{mPayerId = value;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			// This function is not called. All the
			//address information is validated and generated
			//in its respective derived classes.
			base.GenerateRequest ();
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYERID , mPayerId));
		}
		#endregion
	}
}
