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
using System.Collections ;
using PayPal.Payments.Common.Exceptions ; 
using PayPal.Payments.Common.Utility ; 

#endregion


namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout Do operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ExpressCheckoutResponse"/>
	/// <seealso cref="ECGetResponse"/>
	/// </remarks>	
	public class ECDoResponse : ExpressCheckoutResponse
	{
		#region "Member variable"

		private String mAmt;
		private String mSettleAmt;
		private String mTaxAmt;
		private String mExchangeRate;
		private String mPaymentDate;
		private String mPaymentStatus;
		private String mBAId;

		#endregion

		#region "Constructor"
		/// <summary>
		/// constructor
		/// </summary>
		internal ECDoResponse() : base()
		{
		}
		#endregion

		#region "properties"

		/// <summary>
		/// Gets the amt parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>AMT</code>
		/// </remarks>
		public String Amt
		{
			get {return mAmt;}
		}
		/// <summary>
		/// Gets the settleamt parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SETTLEAMT</code>
		/// </remarks>
		public String SettleAmt
		{
			get {return mSettleAmt;}
		}
		/// <summary>
		/// Gets the taxamt parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TAXAMT</code>
		/// </remarks>
		public String TaxAmt
		{
			get {return mTaxAmt;}
		}
		/// <summary>
		/// Gets the exchangerate parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>EXCHANGERATE</code>
		/// </remarks>
		public String ExchangeRate
		{
			get {return mExchangeRate;}
		}
		/// <summary>
		/// Gets the PaymentDate parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTDATE</code>
		/// </remarks>
		public String PaymentDate
		{
			get {return mPaymentDate;}
		}
		/// <summary>
		/// Gets the PaymentStatus parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYMENTSTATUS</code>
		/// </remarks>
		public String PaymentStatus
		{
			get {return mPaymentStatus;}
		}
		/// <summary>
		/// Gets the BAID parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BAID</code>
		/// </remarks>
		public String BAId
		{
			get {return mBAId;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Sets Response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal override void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mAmt = (String) ResponseHashTable[PayflowConstants.PARAM_AMT];
				mSettleAmt = (String) ResponseHashTable[PayflowConstants.PARAM_SETTLEAMT];
				mTaxAmt = (String) ResponseHashTable[PayflowConstants.PARAM_TAXAMT];
				mExchangeRate = (String) ResponseHashTable[PayflowConstants.PARAM_EXCHANGERATE];
				mPaymentDate  = (String) ResponseHashTable[PayflowConstants.PARAM_PAYMENTDATE ];
				mPaymentStatus = (String) ResponseHashTable[PayflowConstants.PARAM_PAYMENTSTATUS];
				mBAId = (String) ResponseHashTable[PayflowConstants.PARAM_BAID];
	
				ResponseHashTable.Remove(PayflowConstants.PARAM_AMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_FEEAMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_SETTLEAMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_TAXAMT);
				ResponseHashTable.Remove(PayflowConstants.PARAM_EXCHANGERATE);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PENDINGREASON);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTDATE);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTSTATUS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_PAYMENTTYPE);
				ResponseHashTable.Remove(PayflowConstants.PARAM_BAID);
				  
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
			//catch
			//{
			//    throw new Exception();				
			//}

		}

		#endregion

	}
}
