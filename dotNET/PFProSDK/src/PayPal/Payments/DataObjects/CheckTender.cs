#region "Copyright"

//             Unpublished Proprietary Program Material
//
// This material is proprietary to PayPal, Inc. and is not to be reproduced, 
// used or disclosed except in accordance with a written license agreement 
// with PayPal, Inc..
//
// (C) Copyright 2005  PayPal, Inc.   All Rights Reserved.
//
// PayPal, Inc. believes that this material furnished herewith is accurate 
// and reliable.  However, no responsibility, financial or otherwise, can be 
// accepted for any consequences arising out of the use of this material. 
// The copyright notice above does not evidence any actual or intended 
// publication of such source code. 
//

#endregion

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