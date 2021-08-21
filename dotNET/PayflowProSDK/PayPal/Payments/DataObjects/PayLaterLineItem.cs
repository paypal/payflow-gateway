#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class holds the PayLater Line Item related information.
	/// </summary>
	/// <remarks>
	/// <para>Line item data describes the details of the PayLater promo codes and can be can be passed 
	///  for each transaction. The convention for passing line item data in name/value pairs 
	///  is that each name/value starts with L_ and ends with n where n is the line item number.
	///  For example L_PROMOCODEn=101 is promo code 101, with n starting at 0</para>
	/// </remarks>
	/// <example>
	/// <para>Following example shows how to use line item.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Inv is the Invoice object.
	///	 .................
	///	 
	///	 //Create a line item.
	///	 LineItem Item = new LineItem();
	///	 
	///	 //Add info to line item.
	///	 Item.Amt = new Currency(new Decimal(25.12));
	///	 Item.PickupStreet = "685A E. Middlefield Rd.";
	///	 
	///	 //Add line item to invoice.
	///	 Inv.AddLineItem(Item);
	///	 
	///	 ..................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///  .................
	///  'Inv is the Invoice object.
	///	 .................
	///	 
	///	 //Create a line item.
	///	 Dim Item As LineItem  = New LineItem
	///	 
	///	 'Add info to line item.
	///	 Item.Amt = New Currency(new Decimal(25.12))
	///	 Item.PickupStreet = "685A E. Middlefield Rd."
	///	 
	///	 'Add line item to invoice.
	///	 Inv.AddLineItem(Item)
	///	 
	///	 ..................
	/// </code>
	/// </example>
	public sealed class PayLaterLineItem : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Promo Code
		/// </summary>
		private String mPromoCode;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets  Promo Code
		/// </summary>
		/// <remarks>
		/// <para>The product category for this order. If the 
		/// customers cart contains more than one item, use
		/// the product category for the most expensive item.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PROMOCODE</code>
		/// </remarks>
		public String PromoCode
		{
			get { return mPromoCode; }
			set { mPromoCode = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>
		/// <para>Line item data describes the details of the item purchased and can be can be passed 
		///  for each transaction. The convention for passing line item data in name/value pairs 
		///  is that each name/value starts with L_ and ends with n where n is the line item number.
		///  For example L_QTY0=1 is the quantity for line item 0 and is equal to 1, 
		///  with n starting at 0</para>
		/// </remarks>
		/// <example>
		/// <para>Following example shows how to use line item.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///	 .................
		///	 
		///	 //Create a line item.
		///	 LineItem Item = new LineItem();
		///	 
		///	 //Add info to line item.
		///	 Item.Amt = new Currency(new Decimal(25.12));
		///	 Item.PickupStreet = "685A E. Middlefield Rd.";
		///	 
		///	 //Add line item to invoice.
		///	 Inv.AddLineItem(Item);
		///	 
		///	 ..................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///  .................
		///  'Inv is the Invoice object.
		///	 .................
		///	 
		///	 //Create a line item.
		///	 Dim Item As LineItem  = New LineItem
		///	 
		///	 'Add info to line item.
		///	 Item.Amt = New Currency(new Decimal(25.12))
		///	 Item.PickupStreet = "685A E. Middlefield Rd."
		///	 
		///	 'Add line item to invoice.
		///	 Inv.AddLineItem(Item)
		///	 
		///	 ..................
		/// </code>
		/// </example>
		public PayLaterLineItem()
		{
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates line item request
		/// </summary>
		/// <param name="Index">index number of line item</param>
		internal void GenerateRequest(int Index)
		{
			try
			{
				String IndexVal = Index.ToString();
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_PROMOCODE + IndexVal, mPromoCode));
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
		}
		#endregion
	}
}