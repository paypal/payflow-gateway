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
	/// <seealso cref="ECGetBARequest"/>
	/// <seealso cref="ECSetBARequest"/>
  /// <seealso cref="ECDoBARequest"/>
	/// </remarks>
	public class ECUpdateBARequest : ExpressCheckoutRequest
	{
		#region "Member Variables"
		private String mBAId;
		private String mBA_Status;
		private String mBA_Desc;
		#endregion

		#region "Properties"
		
		/// <summary>
		/// Gets or Sets the ba_status parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_STATUS</code>
		/// </remarks>
		public String BA_Status
		{
			get{return mBA_Status; }
			set{mBA_Status = value;}
		}
		/// <summary>
		/// Gets or Sets the baid parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BAID</code>
		/// </remarks>
		public String BAId
		{
			get{return mBAId; }
			set{mBAId = value;}
		}
		/// <summary>
		/// Gets or Sets the ba_desc parameter.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_DESC</code>
		/// </remarks>
		public String BA_Desc
		{
			get{return mBA_Desc; }
			set{mBA_Desc = value;}
		}

		#endregion

		#region "Constructor"

		/// <summary>
		/// Constructor for ECDoBARequest
		/// </summary>
		/// <param name="BAId">String</param>
		/// <remarks>
		/// ECDoBARequest is used to set the data required for a Express Checkout UPDATE operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		ECUpdateBARequest UpdateEC = new ECUpdateBARequest("[baid]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		Dim UpdateEC As ECUpdateBARequest = new ECUpdateBARequest("[baid]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECUpdateBARequest(String BAId) : base(PayflowConstants.ACTIONTYPE_UPDATEBA)
		{
			mBAId = BAId;
		}
		/// <summary>
		/// Constructor for ECDoBARequest
		/// </summary>
		/// <param name="BAId">String</param>
		/// <param name="BA_Status">String</param>
		/// <remarks>
		/// ECDoBARequest is used to set the data required for a Express Checkout UPDATE operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		ECUpdateBARequest UpdateEC = new ECUpdateBARequest("[baid]", "[ba_status]");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		Dim UpdateEC As ECUpdateBARequest = new ECUpdateBARequest("[baid]", "[ba_status]")
		///		
		///		.............
		/// </code>
		/// </example>
		public ECUpdateBARequest(String BAId, String BA_Status) : base(PayflowConstants.ACTIONTYPE_UPDATEBA)
		{
			mBAId = BAId;
			mBA_Status = BA_Status;			
		}
		/// <summary>
		/// Constructor for ECDoBARequest
		/// </summary>
		/// <param name="BAId">String</param>
		/// <param name="BA_Status">String</param>
		/// <param name="BA_Desc">String</param>
		/// <remarks>
		/// ECDoBARequest is used to set the data required for a Express Checkout UPDATE operation
		/// with Billing Agreement (Reference Transaction) without Purchase.
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		ECUpdateBARequest UpdateEC = new ECUpdateBARequest("[baid]", "[ba_status]", ["ba_desc"]);
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		
		///		//Create the ECUpdateBARequest object
		///		Dim UpdateEC As ECUpdateBARequest = new ECUpdateBARequest("[baid]", "[ba_status]", ["ba_desc"])
		///		
		///		.............
		/// </code>
		/// </example>
		public ECUpdateBARequest(String BAId, String BA_Status, String BA_Desc) : base(PayflowConstants.ACTIONTYPE_UPDATEBA)
		{
			mBAId = BAId;
			mBA_Status = BA_Status;
			mBA_Desc = BA_Desc;
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
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BA_STATUS, mBA_Status));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BA_DESC, mBA_Desc));
			RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BAID, mBAId));
		}
		#endregion
	}
}
