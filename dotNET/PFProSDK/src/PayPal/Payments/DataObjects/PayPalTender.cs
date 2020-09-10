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
using PayPal.Payments.DataObjects ;
using PayPal.Payments.Common.Utility ; 
using PayPal.Payments.Common; 
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for PayPal tender related information
	/// </summary>
	/// <remarks>
	/// CreditCard is the the Payment device associated with this tender type.
	/// ExpressCheckoutRequest is the DataObject associated with this tendet 
	/// in case of a exprecc Checout operation.
	/// <seealso cref="CreditCard"/>
	/// <seealso cref="ExpressCheckoutRequest"/>
	/// </remarks>
	public class PayPalTender : BaseTender
	{
		#region "Member Variables"

		private ExpressCheckoutRequest mExpressCheckoutRequest = null;


		#endregion

		#region "Properties"		

		/// <summary>
		/// 
		/// </summary>
		public ExpressCheckoutRequest ExpressCheckoutRequest 
		{
			get {return mExpressCheckoutRequest ;}
			set {mExpressCheckoutRequest = value;}
		}
		#endregion

		#region "Constructor"	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="CreditCard">Credit Card object</param>
		/// <remarks>This constructor is used to create a PayPalTender
		///  with CreditCard as the payment device</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//CredCard is the CreditCard object.
		///		.............
		///		
		///		PayPalTender Tender = new PayPalTender(CredCard);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'CredCard is the CreditCard object.
		///		.............
		///		
		///		Dim Tender As PayPalTender = new PayPalTender(CredCard)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="CreditCard"/>

		
		public PayPalTender(CreditCard CreditCard) : base( "P", CreditCard)
		{

		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ECReq">ExpressCheckoutRequest object</param>
		/// <remarks>This constructor is used to create a PayPalTender
		///  with ExpressCheckoutRequest dataobject.</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//ECReq could be one of these ECSetRequest ,ECGetRequest or ECDoRequest.
		///		.............
		///		
		///		PayPalTender Tender = new PayPalTender(ECReq);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'ECReq could be one of these ECSetRequest ,ECGetRequest or ECDoRequest.
		///		.............
		///		
		///		Dim Tender As PayPalTender = new PayPalTender(ECReq)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="ExpressCheckoutRequest"/>
		/// <seealso cref="ECSetRequest"/>
		///	<seealso cref="ECGetRequest"/>
		/// <seealso cref="ECDoRequest"/>
		public PayPalTender(ExpressCheckoutRequest ECReq) : base(PayflowConstants.TENDERTYPE_PAYPAL, null)
		{
			mExpressCheckoutRequest = ECReq;
		}

		#endregion

		#region "Methods"

		internal override void GenerateRequest()
		{
			base.GenerateRequest ();
			if (mExpressCheckoutRequest != null)
			{
				mExpressCheckoutRequest.RequestBuffer = RequestBuffer ;
				mExpressCheckoutRequest.GenerateRequest ();
			}
		}
		#endregion
	}
}
