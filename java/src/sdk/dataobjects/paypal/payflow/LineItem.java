package paypal.payflow;

/**
 * This class holds the line item related information.
 * <p>Line item data describes the details of the item purchased and can be can be passed
 * for each transaction. The convention for passing line item data in name/value pairs
 * is that each name/value starts with L_ and ends with n where n is the line item number.
 * For example L_QTY0=1 is the quantity for line item 0 and is equal to 1,
 * with n starting at 0</p>
 * <p>Following example shows how to use line item.</p>
 *
 *  .................
 * //inv is the Invoice object.
 * .................
 * // Create a line item.
 * LineItem item = new LineItem();
 * // Add first item.
 * Currency lnamt = new Currency(new Double(8.95), "USD");
 * item.setAmt(lnamt);
 * item.setDesc("Line 1");
 * item.setQty(1);
 * item.setItemNumber("1");
 * // Add line item to invoice.
 * inv.addLineItem(item);
 * // Create a line item.
 * LineItem item1 = new LineItem();
 * // Add second item.
 * Currency lnamt1 = new Currency(new Double(5.25), "USD");
 * item1.setAmt(lnamt);
 * item1.setDesc("Line 2");
 * item1.setQty(2);
 * item1.setItemNumber("2");
 * // Add line item to invoice.
 * inv.addLineItem(item1);
 * ..................
 */

public final class LineItem extends BaseRequestDataObject {

    private Currency amt;
    private Currency cost;
    private Currency freightAmt;
    private Currency taxAmt;
    private String uom;
    private String pickupStreet;
    private String pickupState;
    private String pickupCountry;
    private String pickupCity;
    private String pickupZip;
    private String desc;
    private Currency discount;
    private String manufacturer;
    private String prodCode;
    private long qty = PayflowConstants.INVALID_NUMBER;
    private String sku;
    private Currency taxRate;
    private String taxType;
    private String type;
    private String commCode;
    private String trackingNum;
    private String costCenterNum;
    private String catalogNum;
    private String upc;
    private Currency handlingAmt;
    private String unspscCode;
    private String itemNumber;

    /**
     * Gets the Line Item Amount
     * <p>Total line item amount including tax and
     * discount. + for debit, - for credits.
     * Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return amt
     *  <p>Maps to Payflow Parameter: L_AMTn</p>
     */
    public Currency getAmt() {
        return amt;
    }

    /**
     * Sets the Line Item Amount
     * <p>Total line item amount including tax and
     * discount. + for debit, - for credits.
     * Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param amt Currency
     *  <p>Maps to Payflow Parameter: L_AMTn</p>
     */
    public void setAmt(Currency amt) {
        this.amt = amt;
    }

    /**
     * Gets the Line Item Cost
     * <p>Cost per item, excluding tax. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return cost
     *  <p>Maps to Payflow Parameter: L_COSTn</p>
     */
    public Currency getCost() {
        return cost;
    }

    /**
     * Sets the Line item cost
     * <p>Cost per item, excluding tax. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param cost Currency
     *  <p>Maps to Payflow Parameter: L_COSTn</p>
     */
    public void setCost(Currency cost) {
        this.cost = cost;
    }

    /**
     * Gets the line item FreightAmt.
     * <p>Freight Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return freightAmt
     *  <p>Maps to Payflow Parameter: L_FREIGHTAMTn</p>
     */
    public Currency getFreightAmt() {
        return freightAmt;
    }

    /**
     * Sets the line item FreightAmt.
     * <p>UFreight Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param freightAmt Currency
     *  <p>Maps to Payflow Parameter: L_FREIGHTAMTn</p>
     */
    public void setFreightAmt(Currency freightAmt) {
        this.freightAmt = freightAmt;
    }

    /**
     * Gets the line item tax amount.
     * <p>Tax Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return taxAmt
     *  <p>Maps to Payflow Parameter: L_TAXAMTn</p>
     */
    public Currency getTaxAmt() {
        return taxAmt;
    }

    /**
     * Sets the line item tax amount.
     * <p>Tax Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param taxAmt Currency
     *  <p>Maps to Payflow Parameter: L_TAXAMTn</p>
     */
    public void setTaxAmt(Currency taxAmt) {
        this.taxAmt = taxAmt;
    }

    /**
     * Gets the Line item UOM
     * <p>Item unit of measure.</P>
     *
     * @return uom
     *  <p>Maps to Payflow Parameter: L_UOMn</p>
     */
    public String getUom() {
        return uom;
    }

    /**
     * Sets the Line item UOM
     * <p>Item unit of measure.</P>
     *
     * @param uom String
     *  <p>Maps to Payflow Parameter: L_UOMn</p>
     */
    public void setUom(String uom) {
        this.uom = uom;
    }

    /**
     * Gets the line item PickupStreet.
     * <p>Item drop-off address1.</P>
     *
     * @return pickupStreet
     *  <p>Maps to Payflow Parameter: L_PICKUPSTREETn</p>
     */
    public String getPickupStreet() {
        return pickupStreet;
    }

    /**
     * Sets the line item PickupStreet.
     * <p>Item drop-off address1.</P>
     *
     * @param pickupStreet String
     *  <p>Maps to Payflow Parameter: L_PICKUPSTREETn</p>
     */
    public void setPickupStreet(String pickupStreet) {
        this.pickupStreet = pickupStreet;
    }

    /**
     * Gets the line item PickupState.
     * <p>Item drop-off state.</P>
     *
     * @return pickupState
     *  <p>Maps to Payflow Parameter: L_PICKUPSTATEn</p>
     */
    public String getPickupState() {
        return pickupState;
    }

    /**
     * Sets the line item PickupState.
     * <p>Item drop-off state.</P>
     *
     * @param pickupState String
     *  <p>Maps to Payflow Parameter: L_PICKUPSTATEn</p>
     */
    public void setPickupState(String pickupState) {
        this.pickupState = pickupState;
    }

    /**
     * Gets the line item PickupCountry.
     * <p>Item drop-off country.</P>
     *
     * @return pickupCountry
     *  <p>Maps to Payflow Parameter: L_PICKUPCOUNTRYn</p>
     */
    public String getPickupCountry() {
        return pickupCountry;
    }

    /**
     * Sets the line item PickupCountry.
     * <p>Item drop-off country.</P>
     *
     * @param pickupCountry String
     *  <p>Maps to Payflow Parameter: L_PICKUPCOUNTRYn</p>
     */
    public void setPickupCountry(String pickupCountry) {
        this.pickupCountry = pickupCountry;
    }

    /**
     * Gets the line item PickupCity.
     * <p>Item drop-off city.</P>
     *
     * @return pickupCity
     *  <p>Maps to Payflow Parameter: L_PICKUPCITYn</p>
     */
    public String getPickupCity() {
        return pickupCity;
    }

    /**
     * Sets the line item PickupCity.
     * <p>Item drop-off city.</P>
     *
     * @param pickupCity String
     *  <p>Maps to Payflow Parameter: L_PICKUPCITYn</p>
     */
    public void setPickupCity(String pickupCity) {
        this.pickupCity = pickupCity;
    }

    /**
     * Gets the line item PickupZip.
     * <p>Item drop-off zip.</P>
     *
     * @return pickupZip
     *  <p>Maps to Payflow Parameter: L_PICKUPZIPn</p>
     */
    public String getPickupZip() {
        return pickupZip;
    }

    /**
     * Sets the line item PickupZip.
     * <p>Item drop-off zip.</P>
     *
     * @param pickupZip String
     *  <p>Maps to Payflow Parameter: L_PICKUPZIPn</p>
     */
    public void setPickupZip(String pickupZip) {
        this.pickupZip = pickupZip;
    }

    /**
     * Gets the Line Item description
     *
     * @return desc
     *  <p>Maps to Payflow Parameter: L_DESCn</p>
     */
    public String getDesc() {
        return desc;
    }

    /**
     * Sets the Line Item description
     *
     * @param desc String
     *  <p>Maps to Payflow Parameter: L_DESCn</p>
     */
    public void setDesc(String desc) {
        this.desc = desc;
    }


    /**
     * Gets the line item Discount.
     * <p>Discount Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return discount
     *  <p>Maps to Payflow Parameter: L_DISCOUNTn</p>
     */
    public Currency getDiscount() {
        return discount;
    }

    /**
     * Sets the line item Discount.
     * <p>Discount Amount per item. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param discount String
     *  <p>Maps to Payflow Parameter: L_DISCOUNTn</p>
     */
    public void setDiscount(Currency discount) {
        this.discount = discount;
    }


    /**
     * Gets the  line item Manufacturer.
     *
     * @return manufacturer
     *  <p>Maps to Payflow Parameter: L_MANUFACTURERn</p>
     */
    public String getManufacturer() {
        return manufacturer;
    }

    /**
     * Sets the  line item Manufacturer.
     *
     * @param manufacturer String
     *  <p>Maps to Payflow Parameter: L_MANUFACTURERn</p>
     */
    public void setManufacturer(String manufacturer) {
        this.manufacturer = manufacturer;
    }

    /**
     * Gets the Item product code.
     *
     * @return prodCode
     *  <p>Maps to Payflow Parameter: L_PRODCODEn</p>
     */
    public String getProdCode() {
        return prodCode;
    }

    /**
     * Sets the Item product code.
     *
     * @param prodCode String
     *  <p>Maps to Payflow Parameter: L_PRODCODEn</p>
     */
    public void setProdCode(String prodCode) {
        this.prodCode = prodCode;
    }

    /**
     * Gets the Quantity per item.
     *
     * @return qty
     *  <p>Maps to Payflow Parameter: L_QTYn</p>
     */
    public long getQty() {
        return qty;
    }

    /**
     * Sets the Quantity per item.
     *
     * @param qty long
     *  <p>Maps to Payflow Parameter: L_QTYn</p>
     */
    public void setQty(long qty) {
        this.qty = qty;
    }

    /**
     * Gets the Item SKU.
     *
     * @return sku
     *  <p>Maps to Payflow Parameter: L_SKUn</p>
     */
    public String getSku() {
        return sku;
    }

    /**
     * Sets the Item SKU.
     *
     * @param sku String
     *  <p>Maps to Payflow Parameter: L_SKUn</p>
     */
    public void setSku(String sku) {
        this.sku = sku;
    }

    /**
     * Gets the Line item tax rate.
     * <p>Tax Rate Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return taxRate
     *  <p>Maps to Payflow Parameter: L_TAXRATEn</p>
     */
    public Currency getTaxRate() {
        return taxRate;
    }

    /**
     * Sets the Line item tax rate.
     * <p>Tax Rate Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param taxRate Currency
     *  <p>Maps to Payflow Parameter: L_TAXRATEn</p>
     */
    public void setTaxRate(Currency taxRate) {
        this.taxRate = taxRate;
    }

    /**
     * Gets the line item TaxType
     *
     * @return taxType
     *  <p>Maps to Payflow Parameter: L_TAXTYPEn</p>
     */
    public String getTaxType() {
        return taxType;
    }

    /**
     * Sets the line item TaxType
     *
     * @param taxType String
     *  <p>Maps to Payflow Parameter: L_TAXTYPEn</p>
     */
    public void setTaxType(String taxType) {
        this.taxType = taxType;
    }

    /**
     * Gets the line item Type.
     *
     * @return String
     *  <p>Maps to Payflow Parameter: L_TYPEn</p>
     */
    public String getType() {
        return type;
    }

    /**
     * Sets the line item Type.
     *
     * @param type String
     *  <p>Maps to Payflow Parameter: L_TYPEn</p>
     */
    public void setType(String type) {
        this.type = type;
    }

    /**
     * Gets the line item CommCode
     * <p>Use this method to get the Commodity Code
     * for the line item.</P>
     *
     * @return commCode
     *  <p>Maps to Payflow Parameter: L_COMMCODEn</p>
     */
    public String getCommCode() {
        return commCode;
    }

    /**
     * Sets the line item CommCode
     * <p>Use this method to set the Commodity Code
     * for the line item.</P>
     *
     * @param commCode String
     *  <p>Maps to Payflow Parameter: L_COMMCODEn</p>
     */
    public void setCommCode(String commCode) {
        this.commCode = commCode;
    }

    /**
     * Gets the line item TrackingNum.
     *
     * @return trackingNum
     *  <p>Maps to Payflow Parameter: L_TRACKINGNUMn</p>
     */
    public String getTrackingNum() {
        return trackingNum;
    }

    /**
     * Sets the line item TrackingNum.
     *
     * @param trackingNum String
     *  <p>Maps to Payflow Parameter: L_TRACKINGNUMn</p>
     */
    public void setTrackingNum(String trackingNum) {
        this.trackingNum = trackingNum;
    }

    /**
     * Gets the line item CostCenterNum.
     *
     * @return costCenterNum
     *  <p>Maps to Payflow Parameter: L_COSTCENTERNUMn</p>
     */
    public String getCostCenterNum() {
        return costCenterNum;
    }

    /**
     * Sets the line item CostCenterNum.
     *
     * @param costCenterNum String
     *  <p>Maps to Payflow Parameter: L_COSTCENTERNUMn</p>
     */
    public void setCostCenterNum(String costCenterNum) {
        this.costCenterNum = costCenterNum;
    }

    /**
     * Gets the line item CatalogNum.
     *
     * @return catalogNum
     *  <p>Maps to Payflow Parameter: L_CATALOGNUMn</p>
     */
    public String getCatalogNum() {
        return catalogNum;
    }

    /**
     * Sets the line item CatalogNum.
     *
     * @param catalogNum String
     *  <p>Maps to Payflow Parameter: L_CATALOGNUMn</p>
     */
    public void setCatalogNum(String catalogNum) {
        this.catalogNum = catalogNum;
    }

    /**
     * Gets the line item universal product code..
     *
     * @return upc
     *  <p>Maps to Payflow Parameter: L_UPCn</p>
     */
    public String getUpc() {
        return upc;
    }

    /**
     * Sets the line item universal product code..
     *
     * @param upc String
     *  <p>Maps to Payflow Parameter: L_UPCn</p>
     */
    public void setUpc(String upc) {
        this.upc = upc;
    }

    /**
     * Gets the line item HandlingAmt.
     * <p>Item Handling Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return handlingAmt
     *  <p>Maps to Payflow Parameter: L_HANDLINGAMTn</p>
     */
    public Currency getHandlingAmt() {
        return handlingAmt;
    }

    /**
     * Sets the line item HandlingAmt.
     * <p>UItem Handling Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param handlingAmt String
     *  <p>Maps to Payflow Parameter: L_HANDLINGAMTn</p>
     */
    public void setHandlingAmt(Currency handlingAmt) {
        this.handlingAmt = handlingAmt;
    }

    /**
     * Gets the line item unspsc code
     *
     * @return unspscCode
     *  <p>Maps to Payflow Parameter: L_UNSPSCCODEn</p>
     */
    public String getUnspscCode() {
        return unspscCode;
    }

    /**
     * Sets the line item unspsc code
     *
     * @param unspscCode String
     *  <p>Maps to Payflow Parameter: L_UNSPSCCODEn</p>
     */
    public void setUnspscCode(String unspscCode) {
        this.unspscCode = unspscCode;
    }

    /**
     * Gets the Line item number.
     *
     * @return itemNumber
     *  <p>Maps to Payflow Parameter: L_xxxxn</p>
     */
    public String getItemNumber() {
        return itemNumber;
    }

    /**
     * Sets the Line item number.
     *
     * @param itemNumber String
     *  <p>Maps to Payflow Parameter: L_xxxxn</p>
     */
    public void setItemNumber(String itemNumber) {
        this.itemNumber = itemNumber;
    }


    /**
     * Constructor.
     * <p>Line item data describes the details of the item purchased and can be can be passed
     * for each transaction. The convention for passing line item data in name/value pairs
     * is that each name/value starts with L_ and ends with n where n is the line item number.
     * For example L_QTY0=1 is the quantity for line item 0 and is equal to 1,
     * with n starting at 0</p>
     * <p>Following example shows how to use line item.</p>
     *
     *  .................
     * //inv is the Invoice object.
     * .................
     * // Create a line item.
     * LineItem item = new LineItem();
     * // Add first item.
     * Currency lnamt = new Currency(new Double(8.95), "USD");
     * item.setAmt(lnamt);
     * item.setDesc("Line 1");
     * item.setQty(1);
     * item.setItemNumber("1");
     * // Add line item to invoice.
     * inv.addLineItem(item);
     * // Create a line item.
     * LineItem item1 = new LineItem();
     * // Add second item.
     * Currency lnamt1 = new Currency(new Double(5.25), "USD");
     * item1.setAmt(lnamt);
     * item1.setDesc("Line 2");
     * item1.setQty(2);
     * item1.setItemNumber("2");
     * // Add line item to invoice.
     * inv.addLineItem(item1);
     * ..................
     */
    public LineItem() {
    }


    protected void generateRequest(int Index) {

        try {
            String IndexVal = String.valueOf(Index);

            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_AMT + IndexVal, amt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_COST + IndexVal, cost));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_FREIGHTAMT + IndexVal, freightAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_HANDLINGAMT + IndexVal, handlingAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_TAXAMT + IndexVal, taxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_UOM + IndexVal, uom));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PICKUPSTREET + IndexVal, pickupStreet));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PICKUPSTATE + IndexVal, pickupState));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PICKUPCOUNTRY + IndexVal, pickupCountry));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PICKUPCITY + IndexVal, pickupCity));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PICKUPZIP + IndexVal, pickupZip));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_DESC + IndexVal, desc));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_DISCOUNT + IndexVal, discount));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_MANUFACTURER + IndexVal, manufacturer));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_PRODCODE + IndexVal, prodCode));

            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_ITEMNUMBER + IndexVal, itemNumber));
            if (qty != PayflowConstants.INVALID_NUMBER) {
                super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_QTY + IndexVal, String.valueOf(qty)));
            }
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_SKU + IndexVal, sku));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_TAXRATE + IndexVal, taxRate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_TAXTYPE + IndexVal, taxType));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_TYPE + IndexVal, type));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_COMMCODE + IndexVal, commCode));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_TRACKINGNUM + IndexVal, trackingNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_COSTCENTERNUM + IndexVal, costCenterNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_CATALOGNUM + IndexVal, catalogNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_UPC + IndexVal, upc));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_L_UNSPSCCODE + IndexVal, unspscCode));
        }
        catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() != null) {
                getContext().addError(err);
            }
        }
    }
}