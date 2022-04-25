package paypal.payflow;

import java.util.ArrayList;

/**
 * Used as the Purchase Invoice class. All the purchase related information can be stored in this class.
 * * <p>
 * Following transactions do require invoice object:</p>
 * <ol>
 * <li>Sale Transaction</li>
 * <li>Authorization Transaction</li>
 * <li>Voice Authorization Transaction</li>
 * <li>Primary Credit Transaction</li>
 * <li>Recurring Transaction : Action -- Add, Payment</li>
 * </ol>
 * <p>However, Invoice information can also be passed in the following transactions:</p>
 * <ol>
 * <li>Delayed Capture Transaction</li>
 * <li>Credit Transaction</li>
 * <li>Void Authorization Transaction</li>
 * <li>Reference Credit Transaction</li>
 * </ol>
 *
 * <p>
 * .................
 * // Create a new Invoice data object with the Amount, Billing Address etc. details.
 * Invoice inv = new Invoice();
 * // Set Amount.
 * Currency amt = new Currency(new decimal(25.12));
 * inv.setAmt(amt);
 * inv.setPoNum("PO12345");
 * inv.setInvNum("INV12345");
 * inv.setAltTaxAmt(new Currency(new decimal(25.14)));
 * // Set the Billing Address details.
 * BillTo bill = new BillTo();
 * bill.setBillToStreet("123 Main St.");
 * bill.setBillToZip("12345");
 * inv.setBillTo (Bill);
 * .................
 */
public class Invoice extends BaseRequestDataObject {

    private BillTo billTo;
    private ShipTo shipTo;
    private ArrayList itemList;
    private String invNum;
    private Currency amt;
    private Currency taxAmt;
    private Currency dutyAmt;
    private Currency freightAmt;
    private Currency handlingAmt;
    private Currency shippingAmt;
    private Currency discount;
    private String desc;
    private String comment1;
    private String comment2;
    private String desc1;
    private String desc2;
    private String desc3;
    private String desc4;
    private String custRef;
    private String invoiceDate;
    private String startTime;
    private String endTime;
    private String poNum;
    private String vatRegNum;
    private Currency vatTaxAmt;
    private Currency localTaxAmt;
    private Currency nationalTaxAmt;
    private Currency altTaxAmt;
    private String taxExempt;
    private BrowserInfo browserInfo;
    private CustomerInfo customerInfo;
    private MerchantInfo merchantInfo;
    private UserItem userItem;
    private String orderDate;
    private String orderTime;
    private String orderDesc;
    private String commCode;
    private String vatTaxPercent;
    private String recurring;
    private Currency itemAmt;
    private String recurringType;
    private String transactionId;
    private String echoData;
    private String orderId;
    private String custIp;
    private String vatInvNum;
    private String vatTaxRate;
    private String reportGroup;
    private ArrayList adviceDetailList;
    private Devices devices;
    private String miscData;
    private String scaExemption;
    private String citDate;
    private String vMaid;
    private String par;

    /**
     * Constructor.This is a default constructor which does not take any parameters.
     * *
     */
    public Invoice() {
        itemList = new ArrayList();
        adviceDetailList = new ArrayList();
    }

    /**
     * Adds a line item to line item list.
     *
     * @param item Lineitem object
     *             <p>Use this method to add a line item in the purchase order.</p>
     *             <p>Line item data describes the details of the item purchased and can be can be passed
     *             for each transaction. The convention for passing line item data in name/value pairs
     *             is that each name/value starts with L_ and ends with n where n is the line item number.
     *             For example L_QTY0=1 is the quantity for line item 0 and is equal to 1,
     *             with n starting at 0</p>
     *             <p>Following example shows how to use line item.</p>
     *             <p>
     *             .................
     *             //inv is the Invoice object.
     *             .................
     *             // Create a line item.
     *             LineItem item = new LineItem();
     *             // Add first item.
     *             Currency lnamt = new Currency(new Double(8.95), "USD");
     *             item.setAmt(lnamt);
     *             item.setDesc("Line 1");
     *             item.setQty(1);
     *             item.setItemNumber("1");
     *             // Add line item to invoice.
     *             inv.addLineItem(item);
     *             // Create a line item.
     *             LineItem item1 = new LineItem();
     *             // Add second item.
     *             Currency lnamt1 = new Currency(new Double(5.25), "USD");
     *             item1.setAmt(lnamt);
     *             item1.setDesc("Line 2");
     *             item1.setQty(2);
     *             item1.setItemNumber("2");
     *             // Add line item to invoice.
     *             inv.addLineItem(item1);
     *             .................
     */
    public void addLineItem(LineItem item) {
        itemList.add(item);
    }

    /**
     * Removes a line item from line item list.
     *
     * @param index Index of lineitem to be removed.
     *              <p>Use this method to remove a line item at a particular index in the purchase order.</P>
     *              <p>
     *              .................
     *              // Inv is the Invoice object
     *              .................
     *              // Remove item at index 0
     *              inv.removeLineItem(0);
     *              .................
     */
    public void removeLineItem(int index) {
        itemList.remove(index);
    }

    /**
     * Clears the line item list.
     * <p>Use this method to clear all the
     * line items added to the purchase order.</p>
     *
     * <p>
     * .................
     * // inv is the Invoice object
     * .................
     * // Remove all line items.
     * inv.removeAllLineItems();
     * .................
     */
    public void removeAllLineItems() {
        itemList.clear();
    }

    /**
     *
     */
    private void generateItemRequest() {
        for (int index = 0; index < itemList.size(); index++) {
            LineItem item = (LineItem) itemList.get(index);
            if (item != null) {
                item.setContext(getContext());
                item.setRequestBuffer(super.getRequestBuffer());
                item.generateRequest(index);
            }
        }
    }

    /**
     * Adds a advice detail item to the list.
     *
     * @param item AdviceDetail object
     *             <p>
     *             This class holds the advice detail related information.
     *             Detail of a charge where *n* is a value from 1 - 5. Use for additional breakdown of the amount.
     *             For example ADDLAMT1=1 is the amount for the additional amount for advice detail item 1 and is equal to 1,
     *             <p>Following example shows how to use advice detail.</p>
     *             <p>
     *             .................
     *             //inv is the Invoice object.
     *             .................
     *             // Create a advice detail item.
     *             AdviceDetail addDetail1 = new AdviceDetail();
     *             addDetail1.setAddLAmt("1");
     *             addDetail1.setAddLAmtType("1");
     *             inv.addAdviceDetailItem(addDetail1);
     *             // To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
     *             ..................
     */
    public void addAdviceDetailItem(AdviceDetail item) {
        adviceDetailList.add(item);
    }

    /**
     * Removes a advice detail item from the list.
     *
     * @param index Index of the AdviceDetailItem to be removed.
     *              <p>Use this method to remove a advice detail item at a particular index in the purchase order.</P>
     *              .................
     *              // Inv is the Invoice object
     *              .................
     *              // Remove item at index 2
     *              inv.removeAdviceDetailItem(2);
     *              .................
     */
    public void removeAdviceDetailItem(int index) {
        adviceDetailList.remove(index);
    }

    /**
     * Clears the advice detail item list.
     * <p>Use this method to clear all the items added to the purchase order.</p>
     * .................
     * // inv is the Invoice object
     * .................
     * // Remove all advice detail items.
     * inv.removeAllAdviceDetailItem();
     * .................
     */
    public void removeAllAdviceDetailItem() {
        adviceDetailList.clear();
    }

    /**
     *
     */
    private void generateAdviceDetailRequest() {
        for (int index = 0; index < adviceDetailList.size(); index++) {
            AdviceDetail item = (AdviceDetail) adviceDetailList.get(index);
            if (item != null) {
                item.setContext(getContext());
                item.setRequestBuffer(super.getRequestBuffer());
                item.generateRequest(index);
            }
        }
    }

    protected void generateRequest() {
        try {
            initErrorContext();

            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_INVNUM, invNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_AMT, amt));
            if (amt != null) {
                super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CURRENCY, amt.getCurrencyCode()));
            }
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TAXEXEMPT, taxExempt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TAXAMT, taxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DUTYAMT, dutyAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_FREIGHTAMT, freightAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_HANDLINGAMT, handlingAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SHIPPINGAMT, shippingAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DISCOUNT, discount));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DESC, desc));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COMMENT1, comment1));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COMMENT2, comment2));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DESC1, desc1));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DESC2, desc2));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DESC3, desc3));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_DESC4, desc4));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTREF, custRef));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PONUM, poNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VATREGNUM, vatRegNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VATTAXAMT, vatTaxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_LOCALTAXAMT, localTaxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_NATIONALTAXAMT, nationalTaxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ALTTAXAMT, altTaxAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_COMMCODE, commCode));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VATTAXPERCENT, vatTaxPercent));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_INVOICEDATE, invoiceDate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_STARTTIME, startTime));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ENDTIME, endTime));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORDERDATE, orderDate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORDERTIME, orderTime));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_RECURRING, recurring));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ITEMAMT, itemAmt));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORDERDESC, orderDesc));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CUSTIP, custIp));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_RECURRINGTYPE, recurringType));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_TRANSACTIONID, transactionId));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ECHODATA, echoData));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_ORDERID, orderId));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VATINVNUM, vatInvNum));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VATTAXRATE, vatTaxRate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_REPORTGROUP, reportGroup));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_MISCDATA, miscData));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SCAEXEMPTION, scaExemption));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_CITDATE, citDate));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VMAID, vMaid));
            super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PAR, par));

            if (billTo != null) {
                billTo.setRequestBuffer(getRequestBuffer());
                billTo.generateRequest();
            }
            if (shipTo != null) {
                shipTo.setRequestBuffer(getRequestBuffer());
                shipTo.generateRequest();
            }
            if (browserInfo != null) {
                browserInfo.setRequestBuffer(getRequestBuffer());
                browserInfo.generateRequest();
            }
            if (customerInfo != null) {
                customerInfo.setRequestBuffer(getRequestBuffer());
                customerInfo.generateRequest();
            }
            if (userItem != null) {
                userItem.setRequestBuffer(getRequestBuffer());
                userItem.generateRequest();
            }
            if (itemList != null && itemList.size() > 0) {
                generateItemRequest();
            }
            if (adviceDetailList != null && adviceDetailList.size() > 0) {
                generateAdviceDetailRequest();
            }
            if (devices != null) {
                devices.setRequestBuffer(getRequestBuffer());
                devices.generateRequest();
            }
            if (merchantInfo != null) {
                merchantInfo.setRequestBuffer(getRequestBuffer());
                merchantInfo.generateRequest();
            }

        } catch (Exception ex) {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() == null) {
                getContext().addError(err);
            }
        }
    }


    private void initErrorContext() {
        if (billTo != null) {
            billTo.setContext(getContext());
        }
        if (shipTo != null) {
            shipTo.setContext(getContext());
        }
        if (amt != null) {
            amt.setContext(getContext());
        }
        if (taxAmt != null) {
            taxAmt.setContext(getContext());
        }
        if (dutyAmt != null) {
            dutyAmt.setContext(getContext());
        }
        if (freightAmt != null) {
            freightAmt.setContext(getContext());
        }
        if (handlingAmt != null) {
            handlingAmt.setContext(getContext());
        }
        if (discount != null) {
            discount.setContext(getContext());
        }
        if (vatTaxAmt != null) {
            vatTaxAmt.setContext(getContext());
        }
        if (localTaxAmt != null) {
            localTaxAmt.setContext(getContext());
        }
        if (nationalTaxAmt != null) {
            nationalTaxAmt.setContext(getContext());
        }
        if (browserInfo != null) {
            browserInfo.setContext(getContext());
        }
        if (customerInfo != null) {
            customerInfo.setContext(getContext());
        }
        if (userItem != null) {
            userItem.setContext(getContext());
        }
        if (merchantInfo != null) {
            merchantInfo.setContext(getContext());
        }
        if (devices != null) {
            devices.setContext(getContext());
        }
    }

    /**
     * Gets the AltTaxAmount
     * <p>Alternate Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: ALTTAXAMT</p>
     */
    public Currency getAltTaxAmt() {
        return altTaxAmt;
    }

    /**
     * Sets the AltTaxAmount
     * <p>Alternate Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param altTaxAmt Currency
     *                  <p>Maps to Payflow Parameter: ALTTAXAMT</p>
     */
    public void setAltTaxAmt(Currency altTaxAmt) {
        this.altTaxAmt = altTaxAmt;
    }

    /**
     * Gets the Amount
     * <p>Amount (US Dollars) U.S. based currency.
     * Specify the exact amount to the cent using a decimal
     * point'use 34.00, not 34. Do not include comma
     * separators'use 1199.95 not 1,199.95.</P>
     * <p>Your processor and/or Internet merchant account
     * provider may stipulate a maximum amount.</p>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: AMT</p>
     * .................
     * // inv is the Invoice object
     * .................
     * // Set the Amount for the invoice.
     * // A valid amount is a two decimal value.
     * Currency amt = new Currency(new decimal(25.12))
     * //For values which have more than two decimal places
     * Currency amt = new Currency(new decimal(25.1214));
     * amt.setNoOfDecimalDigits (2);
     * //If the NoOfDecimalDigits property is used then it is mandatory to set one of the following properties to true.
     * amt.setRound (true);
     * amt.setTruncate (true);
     * inv.setAmt (Amt);
     */
    public Currency getAmt() {
        return amt;
    }

    /**
     * Sets the Amount
     * <p>Amount (US Dollars) U.S. based currency.
     * Specify the exact amount to the cent using a decimal
     * point'use 34.00, not 34. Do not include comma
     * separators'use 1199.95 not 1,199.95.</P>
     * <p>Your processor and/or Internet merchant account
     * provider may stipulate a maximum amount.</p>
     *
     * @param amt Currency
     *            <p>Maps to Payflow Parameter: AMT</p>
     *            .................
     *            // inv is the Invoice object
     *            .................
     *            // Set the Amount for the invoice.
     *            // A valid amount is a two decimal value.
     *            Currency amt = new Currency(new decimal(25.12))
     *            //For values which have more than two decimal places
     *            Currency amt = new Currency(new decimal(25.1214));
     *            amt.setNoOfDecimalDigits (2);
     *            //If the NoOfDecimalDigits property is used then it is mandatory to set one of the following properties to true.
     *            amt.setRound (true);
     *            amt.setTruncate (true);
     *            inv.setAmt (Amt);
     */
    public void setAmt(Currency amt) {
        this.amt = amt;
    }

    /**
     * Gets the BillTo Object
     * <p>Use this method to get the billing
     * addresses of the purchase order.</P>
     *
     * @return BillTo
     */
    public BillTo getBillTo() {
        return billTo;
    }

    /**
     * Sets the BillTo Object
     * <p>Use this method to set the billing
     * addresses of the purchase order.</P>
     *
     * @param billTo BillTo
     *               <p>
     *               .................
     *               // inv is the Invoice object
     *               .................
     *               // Set the Billing Address details.
     *               BillTo bill = New BillTo();
     *               bill.setBillToStreet("123 Main St.");
     *               bill.setBillToZip("12345");
     *               inv.setBillTo (bill);
     *               .................
     */
    public void setBillTo(BillTo billTo) {
        this.billTo = billTo;
    }

    /**
     * Gets the BrowserInfo Object
     * <p>Use this method to get the browser
     * related information of the purchase order.</P>
     *
     * @return BrowserInfo
     */
    public BrowserInfo getBrowserInfo() {
        return browserInfo;
    }

    /**
     * Sets the BrowserInfo Object
     * <p>Use this method to set the browser
     * related information of the purchase order.</P>
     *
     * @param browserInfo BrowserInfo
     *                    <p>
     *                    .................
     *                    // inv is the Invoice object
     *                    .................
     *                    // Set the Browser Info details.
     *                    BrowserInfo browser = New BrowserInfo();
     *                    browser.setBrowserCountryCode ("USA");
     *                    browser.setBrowserUserAgent ("IE 6.0");
     *                    inv.setBrowserInfo (browser);
     *                    .................
     */
    public void setBrowserInfo(BrowserInfo browserInfo) {
        this.browserInfo = browserInfo;
    }

    /**
     * Gets the CommCode
     * <p>Use this method to get the Commodity Code
     * for the purchase order.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: COMMCODE</p>
     */
    public String getCommCode() {
        return commCode;
    }

    /**
     * Sets the CommCode
     * <p>Use this method to set the Commodity Code
     * for the purchase order.</P>
     *
     * @param commCode String
     *                 <p>Maps to Payflow Parameter: COMMCODE</p>
     */
    public void setCommCode(String commCode) {
        this.commCode = commCode;
    }

    /**
     * Gets Comment1
     * <p>Merchant-defined value for reporting and auditing
     * purposes.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: COMMENT1</p>
     */
    public String getComment1() {
        return comment1;
    }

    /**
     * Sets Comment1
     * <p>Merchant-defined value for reporting and auditing
     * purposes.</P>
     *
     * @param comment1 String
     *                 <p>Maps to Payflow Parameter: COMMENT1</p>
     */
    public void setComment1(String comment1) {
        this.comment1 = comment1;
    }

    /**
     * Gets Comment2
     * <p>Merchant-defined value for reporting and auditing
     * purposes.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: COMMENT2</p>
     */
    public String getComment2() {
        return comment2;
    }

    /**
     * Sets Comment2
     * <p>Merchant-defined value for reporting and auditing
     * purposes.</P>
     *
     * @param comment2 String
     *                 <p>Maps to Payflow Parameter: COMMENT2</p>
     */
    public void setComment2(String comment2) {
        this.comment2 = comment2;
    }

    /**
     * Gets the CustomerInfo Object
     * <p>Use this method to get the customer
     * related information of the purchase order.</P>
     *
     * @return CustomerInfo
     */
    public CustomerInfo getCustomerInfo() {
        return customerInfo;
    }

    /**
     * Sets the CustomerInfo Object
     * <p>Use this method to set the customer
     * related information of the purchase order.</P>
     *
     * @param customerInfo CustomerInfo
     *                     <p>
     *                     .................
     *                     // inv is the Invoice object
     *                     .................
     *                     // Set the Customer Info details.
     *                     CustomerInfo cust = New CustomerInfo();
     *                     cust.setCustCode ("CustXXXXX");
     *                     cust.setCustIP ("255.255.255.255");
     *                     inv.setCustomerInfo (Cust);
     *                     .................
     */
    public void setCustomerInfo(CustomerInfo customerInfo) {
        this.customerInfo = customerInfo;
    }

    /**
     * Sets the MerchantInfo Object
     * <p>Use this method to set the merchant
     * related information of the purchase order.</P>
     *
     * @param merchantInfo MerchantInfo
     *                     <p>
     *                     .................
     *                     // inv is the Invoice object
     *                     .................
     *                     // Set the Merchant Info details.
     *                     MerchantInfo merchant = new MerchantInfo();
     *                     merchant.setMerchantName("MerchantXXXXX");
     *                     merchant.setMerchantCity("Somewhere");
     *                     inv.setMerchantInfo (merchant);
     *                     .................
     */
    public void setMerchantInfo(MerchantInfo merchantInfo) {
        this.merchantInfo = merchantInfo;
    }

    /**
     * Sets the Devices Object
     * <p>Use this method to set the devices the cardholder used.</P>
     *
     * @param devices Devices
     *                <p>
     *                .................
     *                // inv is the Invoice object
     *                .................
     *                // Set the Devices details.
     *                Devices devices = new Devices();
     *                devices.setCatType("3");
     *                devices.setContactLess("RFD");
     *                inv.set
     *                .................
     */
    public void setDevices(Devices devices) {
        this.devices = devices;
    }


    /**
     * Gets the UserItem Object
     * <p>Use this method to get the User items.</P>
     *
     * @return UserItem
     */
    public UserItem getUserItem() {
        return userItem;
    }

    /**
     * Sets the UserItem Object
     * <p>Use this method to set the User Items.</P>
     *
     * @param userItem UserItem
     *                 <p>
     *                 .................
     *                 // inv is the Invoice object
     *                 .................
     *                 // Set the User Item details.
     *                 UserItem nUser = new UserItem();
     *                 nUser.setUserItem1("TUSER1");
     *                 nUser.setUserItem2("TUSER2");
     *                 inv.setUserItem(nUser);
     *                 .................
     */
    public void setUserItem(UserItem userItem) {
        this.userItem = userItem;
    }

    /**
     * Gets the custref
     * <p>Merchant-defined identifier for reporting and auditing
     * purposes.</P>
     * <p>You can use CUSTREF when performing Inquiry
     * transactions. To ensure that you can always access
     * the correct transaction when performing an Inquiry,
     * you must provide a unique CUSTREF when
     * submitting any transaction, including retries.</p>
     *
     * @return String
     * <p>Maps to Payflow Parameter: CUSTREF</p>
     */
    public String getCustRef() {
        return custRef;
    }

    /**
     * Sets the CommCode
     * <p>Merchant-defined identifier for reporting and auditing
     * purposes.</P>
     * <p>You can use CUSTREF when performing Inquiry
     * transactions. To ensure that you can always access
     * the correct transaction when performing an Inquiry,
     * you must provide a unique CUSTREF when
     * submitting any transaction, including retries.</p>
     *
     * @param custRef String
     *                <p>Maps to Payflow Parameter: CUSTREF</p>
     */
    public void setCustRef(String custRef) {
        this.custRef = custRef;
    }

    /**
     * Gets the description
     * <p>General description of the transaction.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: DESC</p>
     */
    public String getDesc() {
        return desc;
    }

    /**
     * Sets the description
     * <p>General description of the transaction.</P>
     *
     * @param desc String
     *             <p>Maps to Payflow Parameter: DESC</p>
     */
    public void setDesc(String desc) {
        this.desc = desc;
    }

    /**
     * Gets the description1
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: DESC1</p>
     */
    public String getDesc1() {
        return desc1;
    }

    /**
     * Sets the description1
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @param desc1 String
     *              <p>Maps to Payflow Parameter: DESC1</p>
     */
    public void setDesc1(String desc1) {
        this.desc1 = desc1;
    }

    /**
     * Gets the description2
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: DESC2</p>
     */
    public String getDesc2() {
        return desc2;
    }

    /**
     * Sets the description2
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @param desc2 String
     *              <p>Maps to Payflow Parameter: DESC2</p>
     */
    public void setDesc2(String desc2) {
        this.desc2 = desc2;
    }

    /**
     * Gets the description3
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: DESC3</p>
     */
    public String getDesc3() {
        return desc3;
    }

    /**
     * Sets the description3
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @param desc3 String
     *              <p>Maps to Payflow Parameter: DESC3</p>
     */
    public void setDesc3(String desc3) {
        this.desc3 = desc3;
    }

    /**
     * Gets the description4
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: DESC4</p>
     */
    public String getDesc4() {
        return desc4;
    }

    /**
     * Sets the description4
     * <p>Up to 4 lines of additional description of
     * the charge.</P>
     *
     * @param desc4 String
     *              <p>Maps to Payflow Parameter: DESC4</p>
     */
    public void setDesc4(String desc4) {
        this.desc4 = desc4;
    }

    /**
     * Gets the Discount
     * <p>Discount amount on total sale. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: DISCOUNT</p>
     */
    public Currency getDiscount() {
        return discount;
    }

    /**
     * Sets the Discount
     * <p>Discount amount on total sale. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param discount Currency
     *                 <p>Maps to Payflow Parameter: DISCOUNT</p>
     */
    public void setDiscount(Currency discount) {
        this.discount = discount;
    }

    /**
     * Gets the DutyAmount
     * <p>Sometimes called import tax.
     * Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: DUTYAMT</p>
     */
    public Currency getDutyAmt() {
        return dutyAmt;
    }

    /**
     * Sets the DutyAmount
     * <p>Sometimes called import tax.
     * Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param dutyAmt Currency
     *                <p>Maps to Payflow Parameter: DUTYAMT</p>
     */
    public void setDutyAmt(Currency dutyAmt) {
        this.dutyAmt = dutyAmt;
    }

    /**
     * Gets the EndTime
     * <p>	ENDTIME specifies the end of the time period during
     * which the transaction specified by the CUSTREF occurred.</p>
     * <p>	ENDTIME must be less than 30 days after STARTTIME.
     * An inquiry cannot be performed across a date range
     * greater than 30 days.</p>
     * <p>	If you set ENDTIME, and not STARTTIME, then STARTTIME is
     * defaulted to 30 days before ENDTIME. If neither
     * STARTTIME nor ENDTIME is specified, then the
     * system searches the last 30 days.</p>
     * <p>	Format: yyyymmddhhmmss</p>
     * <p>yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</p>
     *
     * @return String
     * <p>Maps to Payflow Parameter: ENDTIME</p>
     */
    public String getEndTime() {
        return endTime;
    }

    /**
     * Sets the EndTime
     * <p>	ENDTIME specifies the end of the time period during
     * which the transaction specified by the CUSTREF occurred.</p>
     * <p>	ENDTIME must be less than 30 days after STARTTIME.
     * An inquiry cannot be performed across a date range
     * greater than 30 days.</p>
     * <p>	If you set ENDTIME, and not STARTTIME, then STARTTIME is
     * defaulted to 30 days before ENDTIME. If neither
     * STARTTIME nor ENDTIME is specified, then the
     * system searches the last 30 days.</p>
     * <p>	Format: yyyymmddhhmmss</p>
     * <p>yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</p>
     *
     * @param endTime String
     *                <p>Maps to Payflow Parameter: ENDTIME</p>
     */
    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }

    /**
     * Gets the Freight Amount
     * <p>Freight Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</p>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: FREIGHTAMT</p>
     */
    public Currency getFreightAmt() {
        return freightAmt;
    }

    /**
     * Sets the Freight Amount
     * <p>Freight Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</p>
     *
     * @param freightAmt Currency
     *                   <p>Maps to Payflow Parameter: FREIGHTAMT</p>
     */
    public void setFreightAmt(Currency freightAmt) {
        this.freightAmt = freightAmt;
    }

    /**
     * Gets the Handling Amount
     * <p>Handling Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: HANDLINGAMT</p>
     */
    public Currency getHandlingAmt() {
        return handlingAmt;
    }

    /**
     * Sets the Handling Amount
     * <p>UHandling Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param handlingAmt Currency
     *                    <p>Maps to Payflow Parameter: HANDLINGAMT</p>
     */
    public void setHandlingAmt(Currency handlingAmt) {
        this.handlingAmt = handlingAmt;
    }

    /**
     * Gets the InvNum
     * <p>Merchant invoice number. This reference number
     * (PNREF'generated by PayPal) is used for authorizations
     * and settlements.
     * The Acquirer decides if this information will
     * appear on the merchant's bank reconciliation statement.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: INVNUM</p>
     */
    public String getInvNum() {
        return invNum;
    }

    /**
     * Sets the InvNum
     * <p>Merchant invoice number. This reference number
     * (PNREF'generated by PayPal) is used for authorizations
     * and settlements.
     * The Acquirer decides if this information will
     * appear on the merchant's bank reconciliation statement.</P>
     *
     * @param invNum String
     *               <p>Maps to Payflow Parameter: INVNUM</p>
     */
    public void setInvNum(String invNum) {
        this.invNum = invNum;
    }

    /**
     * Gets the Invoice Date
     * <p>Transaction Date.</p>
     * <p>Format: yyyymmdd.</p>
     * <p>yyyy - Year, mm - Month, dd - Day.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: INVOICEDATE</p>
     */
    public String getInvoiceDate() {
        return invoiceDate;
    }

    /**
     * Sets the Invoice Date
     * <p>Transaction Date.</p>
     * <p>Format: yyyymmdd.</p>
     * yyyy - Year, mm - Month, dd - Day.
     *
     * @param invoiceDate String
     *                    <p>Maps to Payflow Parameter: INVOICEDATE</p>
     */
    public void setInvoiceDate(String invoiceDate) {
        this.invoiceDate = invoiceDate;
    }


    /**
     * Gets the Local Tax Amount.
     * <p>Local Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: LOCALTAXAMT</p>
     */
    public Currency getLocalTaxAmt() {
        return localTaxAmt;
    }

    /**
     * Sets the Local Tax Amount.
     * <p>Local Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param localTaxAmt Currency
     *                    <p>Maps to Payflow Parameter: LOCALTAXAMT</p>
     */
    public void setLocalTaxAmt(Currency localTaxAmt) {
        this.localTaxAmt = localTaxAmt;
    }

    /**
     * Gets the National Tax Amount
     * <p>National Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: NATIONALTAXAMT</p>
     */
    public Currency getNationalTaxAmt() {
        return nationalTaxAmt;
    }

    /**
     * Sets the National Tax Amount.
     * <p>National Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</p>
     *
     * @param nationalTaxAmt Currency
     *                       <p>Maps to Payflow Parameter: NATIONALTAXAMT</p>
     */
    public void setNationalTaxAmt(Currency nationalTaxAmt) {
        this.nationalTaxAmt = nationalTaxAmt;
    }

    /**
     * Gets the Order date
     * <p>Order date.
     * Format: mmddyy
     * mm - Month, dd - Day, yy - Year.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: ORDERDATE</p>
     */
    public String getOrderDate() {
        return orderDate;
    }

    /**
     * Sets the Order Date
     * <p>Order date.
     * Format: mmddyy
     * mm - Month, dd - Day, yy - Year.</P>
     *
     * @param orderDate String
     *                  <p>Maps to Payflow Parameter: ORDERDATE</p>
     */
    public void setOrderDate(String orderDate) {
        this.orderDate = orderDate;
    }

    /**
     * Gets the Order Time
     *
     * @return String
     * <p>Maps to Payflow Parameter: ORDERTIME</p>
     */
    public String getOrderTime() {
        return orderTime;
    }

    /**
     * Sets the Order Time
     *
     * @param orderTime String
     *                  <p>Maps to Payflow Parameter: ORDERTIME</p>
     */
    public void setOrderTime(String orderTime) {
        this.orderTime = orderTime;
    }

    /**
     * Gets the PoNum.
     * <P>Purchase Order Number / Merchant related data.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: PONUM</p>
     */
    public String getPoNum() {
        return poNum;
    }

    /**
     * Sets the PoNum.
     * <P>Purchase Order Number / Merchant related data.</P>
     *
     * @param poNum String
     *              <p>Maps to Payflow Parameter: PONUM</p>
     */
    public void setPoNum(String poNum) {
        this.poNum = poNum;
    }

    /**
     * Gets the TransactionId.
     * <P>Transaction ID / Merchant related data.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: TRANSACTIONID</p>
     */
    public String getTransactionId() {
        return transactionId;
    }

    /**
     * Sets the TransactionId.
     * <P>Transaction Id / Merchant related data.</P>
     *
     * @param transactionId String
     *                      <p>Maps to Payflow Parameter: TRANSACTIONID</p>
     */
    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    /**
     * Gets the EchoData.
     * <P>Used to echo data back in response.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: ECHODATA</p>
     */
    public String getEchoData() {
        return echoData;
    }

    /**
     * Sets the EchoData.
     * <p>Echo Data is used to "echo" back data sent for processing in the response.</p>
     * <p>For example, if you send "ECHODATA=ADDRESS" then the Billing Address fields
     * will be returned in the response</p>
     *
     * @param echoData String
     *                 <p>Maps to Payflow Parameter: ECHODATA</p>
     */
    public void setEchoData(String echoData) {
        this.echoData = echoData;
    }

    /**
     * Gets the OrderID
     * <P>Used for Order ID</P>
     *
     * @return orderID String
     * <p>Maps to Payflow Parameter: ORDERID</p>
     */
    public String getOrderId() {
        return orderId;
    }

    /**
     * Sets the OrderID.
     * <p>Order ID is used to prevent duplicate "orders" from being processed.
     * This is NOT the same as Request ID; which is used at the transaction level.
     * Order ID (ORDERID) is used to check for a duplicate order in the future.
     * For example, if you pass ORDERID=10101 and in two weeks another order is processed
     * with the same ORDERID, a duplicate condition will occur.  The results you receive
     * will be from the original order with DUPLICATE=2 to show that it was ORDERID that
     * triggered the duplicate.  The order id is stored for 3 years.</p>
     *
     * <p>Important Note: Order ID functionality to catch duplicate orders processed withing
     * seconds of each other is limited.  Order ID should be used in conjunction with Request ID
     * to prevent duplicates due to processing / communication errors. DO NOT use ORDERID
     * as your only means to check for duplicate transactions.</p>
     *
     * @param orderId String
     *                <p>Maps to Payflow Parameter: ORDERID</p>
     */
    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    /**
     * Gets the Recurring status.
     * <p>Is a recurring transaction? Y or N.</P>
     *
     * @return String
     * <p>Maps to Payflow Parameter: RECURRING</p>
     */
    public String getRecurring() {
        return recurring;
    }

    /**
     * Sets the Recurring status.
     * <p>Is a recurring transaction? Y or N.</P>
     *
     * @param recurring String
     *                  <p>Maps to Payflow Parameter: RECURRING</p>
     */
    public void setRecurring(String recurring) {
        this.recurring = recurring;
    }

    /**
     * Gets the Shipping Amt.
     * <p>Shipping Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return Currency
     * <p>Maps to Payflow Parameter: SHIPPINGAMT</p>
     */
    public Currency getShippingAmt() {
        return shippingAmt;
    }

    /**
     * Sets the Shipping Amt
     * <p>Shipping Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param shippingAmt Currency
     *                    <p>Maps to Payflow Parameter: SHIPPINGAMT</p>
     */
    public void setShippingAmt(Currency shippingAmt) {
        this.shippingAmt = shippingAmt;
    }

    /**
     * @return ShipTo
     * <p>Use this method to get the shipping
     * addresses of the purchase order.</p>
     */
    public ShipTo getShipTo() {
        return shipTo;
    }

    /**
     * @param shipTo <p>Use this property to set the shipping
     *               addresses of the purchase order.</p>
     *               .................
     *               // inv is the Invoice object
     *               .................
     *               // Set the Shipping Address details.
     *               ShipTo ship = New ShipTo();
     *               ship.setShipToStreet ("685A E. Middlefield Rd.");
     *               ship.setShipToZip ("94043");
     *               inv.setShipTo(ship);
     *               .................
     */
    public void setShipTo(ShipTo shipTo) {
        this.shipTo = shipTo;
    }

    /**
     * Gets the Start Time
     * <p>STARTTIME specifies the beginning of the time
     * period during which the transaction specified by the
     * CUSTREF occurred.
     * If you set STARTTIME, and not ENDTIME, then
     * ENDTIME is defaulted to 30 days after STARTTIME.
     * If neither STARTTIME nor ENDTIME is specified, then
     * the system searches the last 30 days.
     * Format: yyyymmddhhmmss
     * yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</P>
     *
     * @return startTime String
     * <p>Maps to Payflow Parameter: STARTTIME</p>
     */
    public String getStartTime() {
        return startTime;
    }

    /**
     * Sets the Start Time.
     * <p>STARTTIME specifies the beginning of the time
     * period during which the transaction specified by the
     * CUSTREF occurred.
     * If you set STARTTIME, and not ENDTIME, then
     * ENDTIME is defaulted to 30 days after STARTTIME.
     * If neither STARTTIME nor ENDTIME is specified, then
     * the system searches the last 30 days.
     * Format: yyyymmddhhmmss
     * <p>yyyy - Year, mm - Month dd - Day, hh - Hours, mm - Minutes ss - Seconds.</P>
     *
     * @param startTime String
     *                  <p>Maps to Payflow Parameter: STARTTIME</p>
     */
    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    /**
     * Gets the Tax Amt
     * <p>Tax Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return taxAmt Currency
     * <p>Maps to Payflow Parameter: TAXAMT</p>
     */
    public Currency getTaxAmt() {
        return taxAmt;
    }

    /**
     * Sets the Tax Amt
     * <p>Tax Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param taxAmt Currency
     *               <p>Maps to Payflow Parameter: TAXAMT</p>
     */
    public void setTaxAmt(Currency taxAmt) {
        this.taxAmt = taxAmt;
    }

    /**
     * Gets the TaxExempt
     * <p>Is the customer tax exempt? Y or N</P>
     *
     * @return taxExempt String
     * <p>Maps to Payflow Parameter: TAXEXEMPT</p>
     */
    public String getTaxExempt() {
        return taxExempt;
    }

    /**
     * Sets the TaxExempt
     * <p>Is the customer tax exempt? Y or N</P>
     *
     * @param taxExempt String
     *                  <p>Maps to Payflow Parameter: TAXEXEMPT</p>
     */
    public void setTaxExempt(String taxExempt) {
        this.taxExempt = taxExempt;
    }

    /**
     * Gets the VAT registration number
     *
     * @return vatRegNum String
     * <p>Maps to Payflow Parameter: VATREGNUM</p>
     */
    public String getVatRegNum() {
        return vatRegNum;
    }

    /**
     * Sets the VAT registration number
     *
     * @param vatRegNum String
     *                  <p>Maps to Payflow Parameter: VATREGNUM</p>
     */
    public void setVatRegNum(String vatRegNum) {
        this.vatRegNum = vatRegNum;
    }

    /**
     * Gets the Vat Tax Amt
     * <p>VAT Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return vatTaxAmt Currency
     * <p>Maps to Payflow Parameter: VATTAXAMT</p>
     */
    public Currency getVatTaxAmt() {
        return vatTaxAmt;
    }

    /**
     * Sets the Vat Tax Amt
     * <p>VAT Tax Amount. Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param vatTaxAmt Currency
     *                  <p>Maps to Payflow Parameter: VATTAXAMT</p>
     */
    public void setVatTaxAmt(Currency vatTaxAmt) {
        this.vatTaxAmt = vatTaxAmt;
    }

    /**
     * Gets the VAT Tax percentage.
     *
     * @return vatTaxPercent String
     * <p>Maps to Payflow Parameter: VATTAXPERCENT</p>
     */
    public String getVatTaxPercent() {
        return vatTaxPercent;
    }

    /**
     * Sets the VAT Tax percentage.
     *
     * @param vatTaxPercent String
     *                      <p>Maps to Payflow Parameter: VATTAXPERCENT</p>
     */
    public void setVatTaxPercent(String vatTaxPercent) {
        this.vatTaxPercent = vatTaxPercent;
    }

    /**
     * Gets the line item Amount.
     * <p>Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @return itemAmt String
     * <p>Maps to Payflow Parameter: ITEMAMT</p>
     */
    public Currency getItemAmt() {
        return itemAmt;
    }

    /**
     * Sets the line item Amount.
     * <p>Amount should always be a decimal.
     * Exact amount to the cent (34.00, not 34).
     * Do not include comma separators. Use 1199.95
     * instead of 1,199.95.</P>
     *
     * @param itemAmt String
     *                <p>Maps to Payflow Parameter: ITEMAMT</p>
     */
    public void setItemAmt(Currency itemAmt) {
        this.itemAmt = itemAmt;
    }

    /**
     * Gets the order description for this Invoice
     *
     * @return orderDesc String
     * <p> Maps to Payflow Parameter: ORDERDESC</p>
     */
    public String getOrderDesc() {
        return orderDesc;
    }

    /**
     * Sets the order description for this Invoice
     *
     * @param orderDesc String
     *                  <p> Maps to Payflow Parameter: ORDERDESC</p>
     */
    public void setOrderDesc(String orderDesc) {
        this.orderDesc = orderDesc;
    }

    /**
     * Sets the type of the Recurring transaction (UK).
     * Type of transaction occurrence. The values are:
     * F = First occurrence / S = Subsequent occurrence (default)
     *
     * @param recurringType String
     *                      <p>Maps to Payflow Parameter: RECURRINGTYPE</p>
     */
    public void setRecurringType(String recurringType) {
        this.recurringType = recurringType;
    }

    /**
     * Gets the type of the Recurring transaction (UK).
     *
     * @return recurringType String
     * <p>Maps to Payflow Parameter: RECURRINGTYPE</p>
     */
    public String getRecurringType() {
        return recurringType;
    }

    /**
     * Sets the Customer's IP Address.
     *
     * @param custIp String
     *               <p>Maps to Payflow Parameter: CUSTIP</p>
     */
    public void setCustIp(String custIp) {
        this.custIp = custIp;
    }

    /**
     * Gets the Customer's IP Address.
     *
     * @return custIp String
     * <p>Maps to Payflow Parameter: CUSTIP</p>
     */
    public String getCustIp() {
        return custIp;
    }

    /**
     * Sets the VAT Invoice Number.
     *
     * @param vatInvNum String
     *                  <p>Maps to Payflow Parameter: VATINVNUM</p>
     */
    public void setVatInvNum(String vatInvNum) {
        this.vatInvNum = vatInvNum;
    }

    /**
     * Gets the VAT Invoice Number.
     *
     * @return vatInvNum String
     * <p>Maps to Payflow Parameter: VATINVNUM</p>
     */
    public String getVatInvNum() {
        return vatInvNum;
    }

    /**
     * Sets the VAT Tax Rate.
     *
     * @param vatTaxRate String
     *                   <p>Maps to Payflow Parameter: VATTAXRATE</p>
     */
    public void setVatTaxRate(String vatTaxRate) {
        this.vatTaxRate = vatTaxRate;
    }

    /**
     * Gets the VAT Tax Rate.
     *
     * @return vatTaxRate String
     * <p>Maps to Payflow Parameter: VATTAXRATE</p>
     */
    public String getVatTaxRate() {
        return vatTaxRate;
    }

    /**
     * Sets the Report Group.
     * Category that the transaction is in, for example: coffee mugs.
     *
     * @param reportGroup String
     *                    <p>Maps to Payflow Parameter: REPORTGROUP</p>
     */
    public void setReportGroup(String reportGroup) {
        this.reportGroup = reportGroup;
    }

    /**
     * Gets the Report Group.
     *
     * @return reportGroup String
     * <p>Maps to Payflow Parameter: REPORTGROUP</p>
     */
    public String getReportGroup() {
        return reportGroup;
    }

    /**
     * Sets the Miscellaneous Data.
     *
     * @param miscData String
     *                 <p>Maps to Payflow Parameter: MISCDATA</p>
     */
    public void setMiscData(String miscData) {
        this.miscData = miscData;
    }

    /**
     * Gets the Miscellaneous Data.
     *
     * @return miscData String
     * <p>Maps to Payflow Parameter: MISCDATA</p>
     */
    public String getMiscData() {
        return miscData;
    }

    /**
     * Sets the SCAExemption.
     *
     * @param scaExemption String
     *                     <p>Maps to Payflow Parameter: SCAEXEMPTION</p>
     */
    public void setScaExemption(String scaExemption) {
        this.scaExemption = scaExemption;
    }

    /**
     * Gets the SCAExemption.
     *
     * @return scaExemption String
     * <p>Maps to Payflow Parameter: SCAEXEMPTION</p>
     */
    public String getScaExemption() {
        return scaExemption;
    }

    /**
     * Sets the CitDate.
     *
     * @param citDate String
     *                <p>Maps to Payflow Parameter: CITDATE</p>
     */
    public void setCitDate(String citDate) {
        this.citDate = citDate;
    }

    /**
     * Gets the CitDate
     *
     * @return citDate String
     * <p>Maps to Payflow Parameter: CITDATE</p>
     */
    public String getCitDate() {
        return citDate;
    }

    /**
     * Sets the VMaid
     *
     * @param vMaid String
     *              <p>Maps to Payflow Parameter: VMAID</p>
     */
    public void setVMaid(String vMaid) {
        this.vMaid = vMaid;
    }

    /**
     * Gets the VMaid
     *
     * @return vMaid String
     * <p>Maps to Payflow Parameter: VMAID</p>
     */
    public String getVMaid() {
        return vMaid;
    }

    /**
     * Sets the PAR
     *
     * @param par String
     *              <p>Maps to Payflow Parameter: PAR</p>
     */
    public void setPar(String par) {
        this.par = par;
    }

    /**
     * Gets the Par
     *
     * @return par String
     * <p>Maps to Payflow Parameter: PAR</p>
     */
    public String getPar() {
        return par;
    }
}


