#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class holds the Invoice Line Item item related information.
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
	public sealed class LineItem : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// line item amount
		/// </summary>
		private Currency mAmt;

		/// <summary>
		/// line item cost
		/// </summary>
		private Currency mCost;

		/// <summary>
		/// line item freight amount
		/// </summary>
		private Currency mFreightAmt;

		/// <summary>
		/// line item tax amount
		/// </summary>
		private Currency mTaxAmt;

		/// <summary>
		/// line item uom
		/// </summary>
		private String mUom;

		/// <summary>
		/// line item pickup street
		/// </summary>
		private String mPickupStreet;

		/// <summary>
		/// line item pickup state
		/// </summary>
		private String mPickupState;

		/// <summary>
		/// line item pickup country
		/// </summary>
		private String mPickupCountry;

		/// <summary>
		/// line item pickup city
		/// </summary>
		private String mPickupCity;

		/// <summary>
		/// line item pickup zip
		/// </summary>
		private String mPickupZip;

		/// <summary>
		/// line item desc
		/// </summary>
		private String mDesc;

		/// <summary>
		/// line item discount
		/// </summary>
		private Currency mDiscount;

		/// <summary>
		/// line item manufacturer
		/// </summary>
		private String mManufacturer;

		/// <summary>
		/// line item prodcode
		/// </summary>
		private String mProdCode;

		/// <summary>
		/// line item qty
		/// </summary>
		private long mQty = PayflowConstants.INVALID_NUMBER;

		/// <summary>
		/// line item sku
		/// </summary>
		private String mSku;

		/// <summary>
		/// line item taxrate
		/// </summary>
		private Currency mTaxRate;

		/// <summary>
		/// line item tax type
		/// </summary>
		private String mTaxType;

		/// <summary>
		/// line item type
		/// </summary>
		private String mType;

		/// <summary>
		/// line item commcode
		/// </summary>
		private String mCommCode;

		/// <summary>
		/// line item tracking number
		/// </summary>
		private String mTrackingNum;

		/// <summary>
		/// line item cost center number
		/// </summary>
		private String mCostCenterNum;

		/// <summary>
		/// line item catalog number
		/// </summary>
		private String mCatalogNum;

		/// <summary>
		/// line item upc
		/// </summary>
		private String mUpc;

		/// <summary>
		/// line item handlingamount
		/// </summary>
		private Currency mHandlingAmt;

		/// <summary>
		/// line item unspsc code
		/// </summary>
		private String mUnspscCode;

		/// <summary>
		/// line item alternate tax amount
		/// </summary>
		private String mAltTaxAmt;
		/// <summary>
		/// line item alternate tax Id
		/// </summary>
		private String mAltTaxId;
		/// <summary>
		/// line item alternate tax rate
		/// </summary>
		private String mAltTaxRate;
		/// <summary>
		/// line item carrier service level code
		/// </summary>
		private String mCarrierServiceLevelCode;
		/// <summary>
		/// line item extra amount
		/// </summary>
		private String mExtAmt;


		/// --------------------------------------
		/// 
		/// <summary>
		/// line item name
		/// </summary>
		private String mName;


		/// <summary>
		/// line item number
		/// </summary>
		private String mItemNumber;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets line item Amt.
		/// </summary>
		/// <remarks>
		/// <para>Total line item amount including tax and 
		///  discount. + for debit, - for credits. 
		///  Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_AMTn</code>
		/// </remarks>
		public Currency Amt
		{
			get { return mAmt; }
			set { mAmt = value; }
		}

		/// <summary>
		/// Gets, Sets line item Cost.
		/// </summary>
		/// <remarks>
		/// <para>Cost per item, excluding tax. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_COSTn</code>
		/// </remarks>
		public Currency Cost
		{
			get { return mCost; }
			set { mCost = value; }
		}

		/// <summary>
		/// Gets, Sets line item FreightAmt.
		/// </summary>
		/// <remarks>
		/// <para>Freight Amount per item. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_FREIGHTAMTn</code>
		/// </remarks>
		public Currency FreightAmt
		{
			get { return mFreightAmt; }
			set { mFreightAmt = value; }
		}

		/// <summary>
		/// Gets, Sets line item TaxAmt.
		/// </summary>
		/// <remarks>
		/// <para>Tax Amount per item. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_TAXAMTn</code>
		/// </remarks>
		public Currency TaxAmt
		{
			get { return mTaxAmt; }
			set { mTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets line item UOM.
		/// </summary>
		/// <remarks>
		/// <para>Item unit of measure.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_UOMn</code>
		/// </remarks>
		public String UOM
		{
			get { return mUom; }
			set { mUom = value; }
		}

		/// <summary>
		/// Gets, Sets line item PickupStreet.
		/// </summary>
		/// <remarks>
		/// <para>Item drop-off address1.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PICKUPSTREETn</code>
		/// </remarks>
		public String PickupStreet
		{
			get { return mPickupStreet; }
			set { mPickupStreet = value; }
		}

		/// <summary>
		/// Gets, Sets line item PickupState.
		/// </summary>
		/// <remarks>
		/// <para>Item drop-off state.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PICKUPSTATEn</code>
		/// </remarks>
		public String PickupState
		{
			get { return mPickupState; }
			set { mPickupState = value; }
		}

		/// <summary>
		/// Gets, Sets line item PickupCountry.
		/// </summary>
		/// <remarks>
		/// <para>Item drop-off country.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PICKUPCOUNTRYn</code>
		/// </remarks>
		public String PickupCountry
		{
			get { return mPickupCountry; }
			set { mPickupCountry = value; }
		}

		/// <summary>
		/// Gets, Sets line item PickupCity.
		/// </summary>
		/// <remarks>
		/// <para>Item drop-off city.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PICKUPCITYn</code>
		/// </remarks>
		public String PickupCity
		{
			get { return mPickupCity; }
			set { mPickupCity = value; }
		}

		/// <summary>
		/// Gets, Sets line item PickupZip.
		/// </summary>
		/// <remarks>
		/// <para>Item drop-off zip.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PICKUPZIPn</code>
		/// </remarks>
		public String PickupZip
		{
			get { return mPickupZip; }
			set { mPickupZip = value; }
		}

		/// <summary>
		/// Gets, Sets line item Desc.
		/// </summary>
		/// <remarks>
		/// <para>Item description.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_DESCn</code>
		/// </remarks>
		public String Desc
		{
			get { return mDesc; }
			set { mDesc = value; }
		}

		/// <summary>
		/// Gets, Sets line item Discount.
		/// </summary>
		/// <remarks>
		/// <para>Discount Amount per item. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_DISCOUNTn</code>
		/// </remarks>
		public Currency Discount
		{
			get { return mDiscount; }
			set { mDiscount = value; }
		}

		/// <summary>
		/// Gets, Sets line item Manufacturer.
		/// </summary>
		/// <remarks>
		/// <para>Item manufacturer.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_MANUFACTURERn</code>
		/// </remarks>
		public String Manufacturer
		{
			get { return mManufacturer; }
			set { mManufacturer = value; }
		}

		/// <summary>
		/// Gets, Sets line item ProdCode.
		/// </summary>
		/// <remarks>
		/// <para>Item product code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_PRODCODEn</code>
		/// </remarks>
		public String ProdCode
		{
			get { return mProdCode; }
			set { mProdCode = value; }
		}

		/// <summary>
		/// Gets, Sets line item Qty.
		/// </summary>
		/// <remarks>
		/// <para>Quantity per item.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_QTYn</code>
		/// </remarks>
		public long Qty
		{
			get { return mQty; }
			set { mQty = value; }
		}

		/// <summary>
		/// Gets, Sets line item SKU.
		/// </summary>
		/// <remarks>
		/// <para>Item SKU.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_SKUn</code>
		/// </remarks>
		public String SKU
		{
			get { return mSku; }
			set { mSku = value; }
		}

		/// <summary>
		/// Gets, Sets line item TaxRate.
		/// </summary>
		/// <remarks>
		/// <para>Tax Rate Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_TAXRATEn</code>
		/// </remarks>
		public Currency TaxRate
		{
			get { return mTaxRate; }
			set { mTaxRate = value; }
		}

		/// <summary>
		/// Gets, Sets line item TaxType.
		/// </summary>
		/// <remarks>
		/// <para>Item tax type.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_TAXTYPEn</code>
		/// </remarks>
		public String TaxType
		{
			get { return mTaxType; }
			set { mTaxType = value; }
		}

		/// <summary>
		/// Gets, Sets line item Type.
		/// </summary>
		/// <remarks>
		/// <para>Item type.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_TYPEn</code>
		/// </remarks>
		public String Type
		{
			get { return mType; }
			set { mType = value; }
		}

		/// <summary>
		/// Gets, Sets line item CommCode.
		/// </summary>
		/// <remarks>
		/// <para>Item commodity code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_COMMCODEn</code>
		/// </remarks>
		public String CommCode
		{
			get { return mCommCode; }
			set { mCommCode = value; }
		}

		/// <summary>
		/// Gets, Sets line item TrackingNum.
		/// </summary>
		/// <remarks>
		/// <para>Item tracking number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_TRACKINGNUMn</code>
		/// </remarks>
		public String TrackingNum
		{
			get { return mTrackingNum; }
			set { mTrackingNum = value; }
		}

		/// <summary>
		/// Gets, Sets line item CostCenterNum.
		/// </summary>
		/// <remarks>
		/// <para>Item cost center number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_COSTCENTERNUMn</code>
		/// </remarks>
		public String CostCenterNum
		{
			get { return mCostCenterNum; }
			set { mCostCenterNum = value; }
		}

		/// <summary>
		/// Gets, Sets line item CatalogNum.
		/// </summary>
		/// <remarks>
		/// <para>Item catalog number.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_CATALOGNUMn</code>
		/// </remarks>
		public String CatalogNum
		{
			get { return mCatalogNum; }
			set { mCatalogNum = value; }
		}

		/// <summary>
		/// Gets, Sets line item UPC.
		/// </summary>
		/// <remarks>
		/// <para>Item universal product code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_UPCn</code>
		/// </remarks>
		public String UPC
		{
			get { return mUpc; }
			set { mUpc = value; }
		}

		/// <summary>
		/// Gets, Sets line item HandlingAmt.
		/// </summary>
		/// <remarks>
		/// <para>Item Handling Amount. Amount should always be a decimal.
		///  Exact amount to the cent (34.00, not 34). 
		///  Do not include comma separators. Use 1199.95 
		///  instead of 1,199.95.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_HANDLINGAMTn</code>
		/// </remarks>
		public Currency HandlingAmt
		{
			get { return mHandlingAmt; }
			set { mHandlingAmt = value; }
		}

		/// <summary>
		/// Gets, Sets line item unspsc code.
		/// </summary>
		/// <remarks>
		/// <para>Item UnspscCode.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_UNSPSCCODEn</code>
		/// </remarks>
		public String UnspscCode
		{
			get { return mUnspscCode; }
			set { mUnspscCode = value; }
		}

		/// <summary>
		/// Gets, Sets line item alternate tax code.
		/// </summary>
		/// <remarks>
		/// <para>Item AltTaxAmt.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_ALTTAXAMT</code>
		/// </remarks>
		public String AltTaxAmt
		{
			get { return mAltTaxAmt; }
			set { mAltTaxAmt = value; }
		}

		/// <summary>
		/// Gets, Sets line item alternate tax Id.
		/// </summary>
		/// <remarks>
		/// <para>Item AltTaxId.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_ALTTAXID</code>
		/// </remarks>
		public String AltTaxId
		{
			get { return mAltTaxId; }
			set { mAltTaxId = value; }
		}

		/// <summary>
		/// Gets, Sets line item alternate tax rate.
		/// </summary>
		/// <remarks>
		/// <para>Item AltTaxRate.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_ALTTAXRATE</code>
		/// </remarks>
		public String AltTaxRate
		{
			get { return mAltTaxRate; }
			set { mAltTaxRate = value; }
		}

		/// <summary>
		/// Gets, Sets line item carrier service level code
		/// </summary>
		/// <remarks>
		/// <para>Item CarrierServiceLevelCode.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_CARRIERSERVICELEVELCODE</code>
		/// </remarks>
		public String CarrierServiceLevelCode
		{
			get { return mCarrierServiceLevelCode; }
			set { mCarrierServiceLevelCode = value; }
		}

		/// <summary>
		/// Gets, Sets line item extended amount
		/// <remarks>
		/// <para>Item ExtAmt</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_EXTAMT</code>
		/// </remarks>
		/// </summary>
		public String ExtAmt
			{
			get { return mExtAmt; }
			set { mExtAmt = value; }
		}





















		/// ------------------------------------------------------

		/// <summary>
		/// Gets, Sets line item name.
		/// </summary>
		/// <remarks>
		/// <para>Item UnspscCode.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_NAMEn</code>
		/// </remarks>
		public String Name
		{
			get { return mName; }
			set { mName = value; }
		}

		/// <summary>
		/// Gets, Sets line item number.
		/// </summary>
		/// <remarks>
		/// <para></para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>L_xxxxn</code>
		/// </remarks>
		public String ItemNumber
		{
			get { return mItemNumber; }
			set { mItemNumber = value; }
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
		public LineItem()
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

				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_AMT + IndexVal, mAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_COST + IndexVal, mCost));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_FREIGHTAMT + IndexVal, mFreightAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_HANDLINGAMT + IndexVal, mHandlingAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_TAXAMT + IndexVal, mTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_UOM + IndexVal, mUom));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PICKUPSTREET + IndexVal, mPickupStreet));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PICKUPSTATE + IndexVal, mPickupState));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PICKUPCOUNTRY + IndexVal, mPickupCountry));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PICKUPCITY + IndexVal, mPickupCity));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PICKUPZIP + IndexVal, mPickupZip));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_DESC + IndexVal, mDesc));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_DISCOUNT + IndexVal, mDiscount));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_MANUFACTURER + IndexVal, mManufacturer));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_PRODCODE + IndexVal, mProdCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_ITEMNUMBER + IndexVal, mItemNumber));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_NAME + IndexVal, mName));
				if (mQty != PayflowConstants.INVALID_NUMBER)
				{
					RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_QTY + IndexVal, mQty));
				}
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_SKU + IndexVal, mSku));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_TAXRATE + IndexVal, mTaxRate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_TAXTYPE + IndexVal, mTaxType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_TYPE + IndexVal, mType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_COMMCODE + IndexVal, mCommCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_TRACKINGNUM + IndexVal, mTrackingNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_COSTCENTERNUM + IndexVal, mCostCenterNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_CATALOGNUM + IndexVal, mCatalogNum));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_UPC + IndexVal, mUpc));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_UNSPSCCODE + IndexVal, mUnspscCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_ALTTAXAMT + IndexVal, mAltTaxAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_ALTTAXID + IndexVal, mAltTaxId));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_ALTTAXRATE + IndexVal, mAltTaxRate));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_CARRIERSERVICELEVELCODE + IndexVal, mCarrierServiceLevelCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_L_EXTAMT + IndexVal, mExtAmt));


				
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