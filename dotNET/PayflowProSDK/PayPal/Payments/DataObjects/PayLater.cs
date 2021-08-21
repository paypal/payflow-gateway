#region "Imports"

using System;
using System.Collections;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used as the PayPal PayLater class. All the customers promotional financing
	/// related information can be stored in this class.
	/// </summary>
	/// <remarks>
	/// <para> PayPal Pay Later is a new, convenient, and secure service that allows you to offer your
	/// customers promotional financing. Buyers that choose the promotional offer can defer
	/// payments for purchases on participating merchant web sites, allowing them to shop now and
	/// pay later.
	/// The PayPal Pay Later service allows online merchants to offer promotional financing to
	/// buyers at checkout - even if a buyer doesn't have a PayPal account. Promotional offers, such as
	/// no payments for 90 days, give merchants new and powerful ways to market to online
	/// shoppers.
	/// 
	/// PayPal's new promotional financing is currently available to consumers and select merchants
	/// in the U.S. If you are a merchant and would like to add this service, please contact your sales
	/// representative for information and additional documentation.</para>
	/// </remarks>
	/// <example>
	/// <para>Following example shows how to use PayLater in the Express Checkout Set call.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Create the data object for PayLater
	///	 PayLater setPayLater = new PayLater();
	///	 setPayLater.ShippingMethod = "UPSGround";
	///	 setPayLater.ProductCategory = "E"; // Camera and Photos
	///	 setPayLater.PayPalCheckoutBtnType = "P";
	///	 // You can combine up to 10 promotions for PayPal Promotional Financing.
	///	 // L_PROMOCODE0
	///	 PayLaterLineItem setPayLaterLineItem = new PayLaterLineItem();
	///	 setPayLaterLineItem.PromoCode = "101";
	///	 setPayLater.PayLaterAddLineItem(setPayLaterLineItem);
	///	 // L_PROMOCODE1
	///	 PayLaterLineItem setPayLaterLineItem1 = new PayLaterLineItem();
	///	 setPayLaterLineItem1.PromoCode = "102";
	///	 setPayLater.PayLaterAddLineItem(setPayLaterLineItem1);
	///	 // If using Pay Later, you would create the data object as below.
	///	 ECSetRequest setRequest = new ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", setPayLater);
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///	.................
	///	Dim SetPayLater As New PayLater
	///	SetPayLater.ShippingMethod = "UPSGround"
	///	SetPayLater.ProductCategory = "E" ' Camera and Photos
	///	SetPayLater.PayPalCheckoutBtnType = "P"
	///	' You can combine up to 10 promotions for PayPal Promotional Financing.
	///	' L_PROMOCODE0
	///	Dim SetPayLaterLineItem As New PayLaterLineItem
	///	SetPayLaterLineItem.PromoCode = "101"
	///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem)
	///	' L_PROMOCODE1
	///	Dim SetPayLaterLineItem1 As New PayLaterLineItem
	///	SetPayLaterLineItem1.PromoCode = "102"
	///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem1)
	///	' If using Pay Later, you would create the data object as below.
	///	Dim SetRequest As New ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", setPayLater)
	///	.................
	/// </code>
	/// </example>
	public class PayLater : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Product Category
		/// </summary>
		private String mProductCategory;

		/// <summary>
		/// Shipping Method
		/// </summary>
		private String mShippingMethod;

		/// <summary>
		/// PayPal Checkout Button Type
		/// </summary>
		private String mPayPalCheckoutBtnType;

		/// <summary>
		/// Profile Address Change Date
		/// </summary>
		private String mProfileAddressChangeDate;

		/// <summary>
		/// Promo Code Override
		/// </summary>
		private String mPromoCodeOverride;

		/// <summary>
		/// List of Line Items
		/// </summary>
		private ArrayList mItemList;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>
		/// <para> PayPal Pay Later is a new, convenient, and secure service that allows you to offer your
		/// customers promotional financing. Buyers that choose the promotional offer can defer
		/// payments for purchases on participating merchant web sites, allowing them to shop now and
		/// pay later.
		/// The PayPal Pay Later service allows online merchants to offer promotional financing to
		/// buyers at checkout - even if a buyer doesn't have a PayPal account. Promotional offers, such as
		/// no payments for 90 days, give merchants new and powerful ways to market to online
		/// shoppers.
		/// 
		/// PayPal's new promotional financing is currently available to consumers and select merchants
		/// in the U.S. If you are a merchant and would like to add this service, please contact your sales
		/// representative for information and additional documentation.</para>
		/// </remarks>
		/// <example>
		/// <para>Following example shows how to use PayLater in the Express Checkout Set call.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Create the data object for PayLater
		///	 PayLater setPayLater = new PayLater();
		///	 setPayLater.ShippingMethod = "UPSGround";
		///	 setPayLater.ProductCategory = "E"; // Camera and Photos
		///	 setPayLater.PayPalCheckoutBtnType = "P";
		///	 // You can combine up to 10 promotions for PayPal Promotional Financing.
		///	 // L_PROMOCODE0
		///	 PayLaterLineItem setPayLaterLineItem = new PayLaterLineItem();
		///	 setPayLaterLineItem.PromoCode = "101";
		///	 setPayLater.PayLaterAddLineItem(setPayLaterLineItem);
		///	 // L_PROMOCODE1
		///	 PayLaterLineItem setPayLaterLineItem1 = new PayLaterLineItem();
		///	 setPayLaterLineItem1.PromoCode = "102";
		///	 setPayLater.PayLaterAddLineItem(setPayLaterLineItem1);
		///	 // If using Pay Later, you would create the data object as below.
		///	 ECSetRequest setRequest = new ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", setPayLater);
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	Dim SetPayLater As New PayLater
		///	SetPayLater.ShippingMethod = "UPSGround"
		///	SetPayLater.ProductCategory = "E" ' Camera and Photos
		///	SetPayLater.PayPalCheckoutBtnType = "P"
		///	' You can combine up to 10 promotions for PayPal Promotional Financing.
		///	' L_PROMOCODE0
		///	Dim SetPayLaterLineItem As New PayLaterLineItem
		///	SetPayLaterLineItem.PromoCode = "101"
		///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem)
		///	' L_PROMOCODE1
		///	Dim SetPayLaterLineItem1 As New PayLaterLineItem
		///	SetPayLaterLineItem1.PromoCode = "102"
		///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem1)
		///	' If using Pay Later, you would create the data object as below.
		///	Dim SetRequest As New ECSetRequest("http://www.myreturnurl.com", "http://www.mycancelurl.com", setPayLater)
		///	.................
		/// </code>
		/// </example>
		public PayLater()
		{
			mItemList = new ArrayList();
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets  ShippingMethod
		/// </summary>
		/// <remarks>
		/// <para>Use this method to set the Shipping method
		/// for this transaction.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>SHIPPINGMETHOD</code>
		/// </remarks>
		public String ShippingMethod
		{
			get { return mShippingMethod; }
			set { mShippingMethod = value; }
		}

		/// <summary>
		/// Gets, Sets  PromoCodeOverride
		/// </summary>
		/// <remarks>
		/// <para>Value is 0 or 1. Default value is 0.
		/// Set to 1 to override promotions from Set Express 
		/// Checkout request.  Otherwise, promotions will not be
		/// overridden.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROMOCODEOVERRIDE</code>
		/// </remarks>
		public String PromoCodeOverride
		{
			get { return mPromoCodeOverride; }
			set { mPromoCodeOverride = value; }
		}

		/// <summary>
		/// Gets, Sets  ProfileAddressChangeDate
		/// </summary>
		/// <remarks>
		/// <para>The last date that the billing address
		/// stored in the customers profile with the merchant 
		/// was changed. The date must be in UTC/GMT format.
		/// For example, 2007-12-15T17:23:15Z.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROFILEADDRESSCHANGEDATE</code>
		/// </remarks>
		public String ProfileAddressChangeDate
		{
			get { return mProfileAddressChangeDate; }
			set { mProfileAddressChangeDate = value; }
		}

		/// <summary>
		/// Gets, Sets  PayPalCheckoutBtnType
		/// </summary>
		/// <remarks>
		/// <para>Only for the No payment 90 days button, you
		/// must set this variable to P, which allows PayPal
		/// to make 90 days no payments the default payment
		/// option in the PayPal checkout flow.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PAYPALCHECKOUTBTNTYPE</code>
		/// </remarks>
		public String PayPalCheckoutBtnType
		{
			get { return mPayPalCheckoutBtnType; }
			set { mPayPalCheckoutBtnType = value; }
		}

		/// <summary>
		/// Gets, Sets  ProductCategory
		/// </summary>
		/// <remarks>
		/// <para>The product category for this order. If the 
		/// customers cart contains more than one item, use
		/// the product category for the most expensive item.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PRODUCTCATEGORY</code>
		/// </remarks>
		public String ProductCategory
		{
			get { return mProductCategory; }
			set { mProductCategory = value; }
		}

		#endregion

		#region "LineItem related Methods"

		/// <summary>
		/// Add a promo code to promo code.
		/// </summary>
		/// <param name="Item">Lineitem object</param>
		/// <remarks>
		/// <para>Use this method to add a promo code to the request.  A promotion code for
		/// PayPal Promotional Financing where n is a value from 0 to 9. The first promotion
		/// must be specified as L_PROMOCODE0.  Combine promotions by using additonal parameters,
		/// such as L_PROMOCODE1 and L_PROMOCODE2.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		/// // You can combine up to 10 promotions for PayPal Promotional Financing.
		/// // L_PROMOCODE0
		/// PayLaterLineItem setPayLaterLineItem = new PayLaterLineItem();
		/// setPayLaterLineItem.PromoCode = "101";
		/// setPayLater.PayLaterAddLineItem(setPayLaterLineItem);
		/// // L_PROMOCODE1
		/// PayLaterLineItem setPayLaterLineItem1 = new PayLaterLineItem();
		/// setPayLaterLineItem1.PromoCode = "102";
		/// setPayLater.PayLaterAddLineItem(setPayLaterLineItem1);
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	' You can combine up to 10 promotions for PayPal Promotional Financing.
		///	' L_PROMOCODE0
		///	Dim SetPayLaterLineItem As New PayLaterLineItem
		///	SetPayLaterLineItem.PromoCode = "101"
		///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem)
		///	' L_PROMOCODE1
		///	Dim SetPayLaterLineItem1 As New PayLaterLineItem
		///	SetPayLaterLineItem1.PromoCode = "102"
		///	SetPayLater.PayLaterAddLineItem(SetPayLaterLineItem1)
		///	.................
		///	</code>
		/// </example>
		public void PayLaterAddLineItem(PayLaterLineItem Item)
		{
			mItemList.Add(Item);
		}

		/// <summary>
		/// Removes a promo code from line item list.
		/// </summary>
		/// <param name="Index">Index of promo code to be removed.</param>
		/// <remarks>
		/// <para>Use this method to remove a promo code at a particular index 
		/// in the requester.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// SetPayLaterLineItem is the PayLater object
		///	.................
		///	// Remove item at index 0
		///	setPayLater.PayLaterRemoveLineItem(0);
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' SetPayLaterLineItem is the PayLater object
		///	.................
		///	' Remove item at index 0;
		///	SetPayLater.PayLaterRemoveLineItem(0)
		///	.................
		///	</code>
		/// </example>
		public void PayLaterRemoveLineItem(int Index)
		{
			mItemList.RemoveAt(Index);
		}

		/// <summary>
		/// Clears the promo code list.
		/// </summary>
		/// <remarks>
		/// <para>Use this method to clear all the 
		/// promo codes added to the request.</para>
		/// </remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// SetPayLaterLineItem is the PayLater object
		///	.................
		///	// Remove all line items.
		///	setPayLater.PayLaterRemoveAllLineItems();
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' SetPayLaterLineItem is the PayLater object
		///	.................
		///	' Remove all line items.
		///	SetPayLater.PayLaterRemoveAllLineItems()
		///	.................
		///	</code>
		/// </example>
		public void PayLaterRemoveAllLineItems()
		{
			mItemList.Clear();
		}

		/// <summary>
		/// Generates transaction request for promo codes
		/// </summary>
		private void GenerateItemRequest()
		{
			for (int Index = 0; Index < mItemList.Count; Index++)
			{
				PayLaterLineItem Item = (PayLaterLineItem) mItemList[Index];
				if (Item != null)
				{
					Item.RequestBuffer = RequestBuffer;
					Item.GenerateRequest(Index);
				}
			}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SHIPPINGMETHOD, mShippingMethod));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PROMOCODEOVERRIDE, mPromoCodeOverride));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PROFILEADDRESSCHANGEDATE, mProfileAddressChangeDate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PAYPALCHECKOUTBTNTYPE, mPayPalCheckoutBtnType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PRODUCTCATEGORY, mProductCategory));
				if (mItemList != null && mItemList.Count > 0)
				{
					GenerateItemRequest();
				}
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