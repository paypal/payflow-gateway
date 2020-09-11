#region "Imports"

using PayPal.Payments.Common.Utility;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Check tender related information.
	/// </summary>
	/// <remarks>CheckPayment is the Payment device associated with
	/// this tender type.
	/// <seealso cref="CheckPayment"/>
	/// </remarks>
	public sealed class CheckTender : BaseTender
	{

		#region "Constructors"

		/// <summary>
		/// Constructor for CheckTender
		/// </summary>
		/// <param name="Check">Check Payment object.</param>
		/// <remarks>This constructor is used to create a CheckTender
		///  with CheckPayment as the payment device</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//Check is the CheckPayment object.
		///		.............
		///		
		///		CheckTender Tender = new CheckTender(Check);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'Check is the CheckPayment object.
		///		.............
		///		
		///		Dim Tender As CheckTender = new CheckTender(Check)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="CheckPayment"/>
		public CheckTender(CheckPayment Check) : base(PayflowConstants.TENDERTYPE_TELECHECK, Check)
		{
		}

		#endregion
	}
}