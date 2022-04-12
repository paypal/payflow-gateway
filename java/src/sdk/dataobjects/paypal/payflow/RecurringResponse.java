package paypal.payflow;

import java.util.Hashtable;

/**
 * Container class for all the messages related to
 * recurring transactions.
 * <p>This class contains response messages specific to
 * the recurring transactions.</p>
 * <p>Following example shows how to obtain and use the recurring
 * response.
 * <p>
 * ...................
 * // Trans is the recurring transaction.
 * ...................
 * // Submit the transaction.
 * Response resp = trans.SubmitTransaction();
 * * <p>
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse!= null)
 * {
 * System.out.println("RESULT = " + trxnResponse.Result);
 * System.out.println("RESPMSG = " + trxnResponse.RespMsg);
 * }
 * * <p>
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * }
 * }
 * * <p>
 * ...................
 */
public final class RecurringResponse extends BaseResponseDataObject {


    private String profileId;
    private String rpRef;
    private String trxPNRef;
    private String trxResult;
    private String trxRespMsg;
    private String profileName;
    private String start;
    private String term;
    private String payPeriod;
    private String status;
    private String tender;
    private String paymentsLeft;
    private String nextPayment;
    private String end;
    private String aggregateAmt;
    private String aggregateOptionalAmt;
    private String amt;
    private String acct;
    private String expDate;
    private String maxFailPayments;
    private String numFailPayments;
    private String retryNumDays;
    private String email;
    private String companyName;
    private String name;
    private String firstName;
    private String middleName;
    private String lastname;
    private String street;
    private String city;
    private String state;
    private String zip;
    private String country;
    private String phoneNum;
    private String shipToFName;
    private String shipToMName;
    private String shipToLName;
    private String shipToStreet;
    private String shipToCity;
    private String shipToState;
    private String shipToZip;
    private String shipToCountry;
    private String creationDate;
    private String lastChanged;
    private String rpState;
    private String nextPaymentNumber;
    private String frequency;
    private String currency;
    private Hashtable inquiryParams;

    /**
     * Gets the Profile ID of the original profile.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PROFILEID
     */
    public String getProfileId() {
        return profileId;
    }

    /**
     * Gets the Reference number to this particular action request.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: RPREF
     */
    public String getRpRef() {
        return rpRef;
    }

    /**
     * Gets the PNREF of the optional transaction.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: TRXPNREF
     */
    public String getTrxPNRef() {
        return trxPNRef;
    }

    /**
     * Gets the RESULT of the optional transaction.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: TRXRESULT
     */
    public String getTrxResult() {
        return trxResult;
    }

    /**
     * Gets the RESPMSG of the optional transaction.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: TRXRESPMSG
     */
    public String getTrxRespMsg() {
        return trxRespMsg;
    }

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PROFILENAME
     */
    public String getProfileName() {
        return profileName;
    }

    /**
     * Gets the Beginning date for the recurring billing cycle.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: START
     */
    public String getStart() {
        return start;
    }

    /**
     * Gets the Number of payments to be made over the life of the agreement.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: TERM
     */
    public String getTerm() {
        return term;
    }

    /**
     * Gets the PayPeriod parameter.Specifies how often the payment occurs.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PAYPERIOD
     */
    public String getPayPeriod() {
        return payPeriod;
    }

    /**
     * Gets the Current status of the profile.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: STATUS
     */
    public String getStatus() {
        return status;
    }

    /**
     * Gets the tendertype.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: TENDER
     */
    public String getTender() {
        return tender;
    }

    /**
     * Gets the PaymentsLeft parameter. Number of payments left to be billed.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PAYMENTSLEFT
     */
    public String getPaymentsLeft() {
        return paymentsLeft;
    }

    /**
     * Gets the next payment parameter.Date that the next payment is due.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: NEXTPAYMENT
     */
    public String getNextPayment() {
        return nextPayment;
    }

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: END
     */
    public String getEnd() {
        return end;
    }

    /**
     * Gets AggregateAmt.Amount collected so far for scheduled payments.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: AGGREGATEAMT
     */
    public String getAggregateAmt() {
        return aggregateAmt;
    }

    /**
     * Gets the AggregateOptAmt parameter.Amount collected through sending optional transactions.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: AGGREGATEOPTIONALAMT
     */
    public String getAggregateOptionalAmt() {
        return aggregateOptionalAmt;
    }

    /**
     * Gets the amt parameter.Base dollar amount to be billed.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: AMT
     */
    public String getAmt() {
        return amt;
    }

    /**
     * Gets Acct.Masked credit card number.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: ACCT
     */
    public String getAcct() {
        return acct;
    }

    /**
     * Gets the ExpDate parameter.Expiration date of the credit card account.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: EXPDATE
     */
    public String getExpDate() {
        return expDate;
    }

    /**
     * Gets the maxfailpayments parameter.The number of payment periods (specified by
     * PAYPERIOD) for which the transaction is allowed to fail
     * before PayPal cancels a profile.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: MAXFAILPAYMENTS
     */
    public String getMaxFailPayments() {
        return maxFailPayments;
    }

    /**
     * Gets the NumFailPayments parameter.Number of payments that failed.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: NUMFAILPAYMENTS
     */
    public String getNumFailPayments() {
        return numFailPayments;
    }

    /**
     * Gets the retryNumDays parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: RETRYNUMDAYS
     */
    public String getRetryNumDays() {
        return retryNumDays;
    }

    /**
     * Gets the email parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: EMAIL
     */
    public String getEmail() {
        return email;
    }

    /**
     * Gets the companyName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: COMPANYNAME
     */
    public String getCompanyName() {
        return companyName;
    }

    /**
     * Gets the name parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: NAME
     */
    public String getName() {
        return name;
    }

    /**
     * Gets the firstName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: FIRSTNAME
     */
    public String getFirstName() {
        return firstName;
    }

    /**
     * Gets the middleName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: MIDDLENAME
     */
    public String getMiddleName() {
        return middleName;
    }

    /**
     * Gets the lastname parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: LASTNAME
     */
    public String getLastname() {
        return lastname;
    }

    /**
     * Gets the street parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: STREET
     */
    public String getStreet() {
        return street;
    }

    /**
     * Gets the city parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: CITY
     */
    public String getCity() {
        return city;
    }

    /**
     * Gets the state parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: STATE
     */
    public String getState() {
        return state;
    }

    /**
     * Gets the Zip parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: ZIP
     */
    public String getZip() {
        return zip;
    }

    /**
     * Gets the Country parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: COUNTRY
     */
    public String getCountry() {
        return country;
    }

    /**
     * Gets the PhoneNum parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PHONENUM
     */
    public String getPhoneNum() {
        return phoneNum;
    }

    /**
     * Gets the hipToFName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOFIRSTNAME
     */
    public String getShipToFName() {
        return shipToFName;
    }

    /**
     * Gets the ShipToMName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOMIDDLENAME
     */
    public String getShipToMName() {
        return shipToMName;
    }

    /**
     * Gets the ShipToLName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOLASTNAME
     */
    public String getShipToLName() {
        return shipToLName;
    }

    /**
     * Gets the ShipToStreet parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOSTREET
     */
    public String getShipToStreet() {
        return shipToStreet;
    }

    /**
     * Gets the ShipToCity parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOCITY
     */
    public String getShipToCity() {
        return shipToCity;
    }

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PROFILENAME
     */
    public String getShipToState() {
        return shipToState;
    }

    /**
     * Gets the ShipToZip parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOZIP
     */
    public String getShipToZip() {
        return shipToZip;
    }

    /**
     * Gets the ShipToCountry parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: SHIPTOCOUNTRY
     */
    public String getShipToCountry() {
        return shipToCountry;
    }


    /**
     * Gets the CreationDate parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: CREATIONDATE
     */
    public String getCreationDate() {
        return creationDate;
    }

    /**
     * Gets the LastChanged parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: LASTCHANGED
     */
    public String getLastChanged() {
        return lastChanged;
    }

    /**
     * Gets the RPStateparameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: RPSTATE
     */
    public String getRpState() {
        return rpState;
    }

    /**
     * Gets the NextPaymentNumber parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: NEXTPAYMENTNUMBER
     */
    public String getNextPaymentNumber() {
        return nextPayment;
    }

    /**
     * Gets the Frequency parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: FREQUENCY
     */
    public String getFrequency() {
        return frequency;
    }

    /**
     * Gets the Currency parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: CURRENCY
     */
    public String getCurrency() {
        return currency;
    }

    /**
     * Gets the profileName parameter.
     *
     * @return - String
     * <p>Maps to Payflow Parameter: PROFILENAME
     */
    public Hashtable getInquiryParams() {
        return inquiryParams;
    }

    protected RecurringResponse() {
        inquiryParams = new Hashtable();
    }

    protected void setParams(Hashtable ResponseHashTable) {
        profileId = (String) ResponseHashTable.get(PayflowConstants.PARAM_PROFILEID);
        rpRef = (String) ResponseHashTable.get(PayflowConstants.PARAM_RPREF);
        trxPNRef = (String) ResponseHashTable.get(PayflowConstants.PARAM_TRXPNREF);
        trxResult = (String) ResponseHashTable.get(PayflowConstants.PARAM_TRXRESULT);
        trxRespMsg = (String) ResponseHashTable.get(PayflowConstants.PARAM_TRXRESPMSG);

        //Additional fields for Inquiry transaction
        profileName = (String) ResponseHashTable.get(PayflowConstants.PARAM_PROFILENAME);
        start = (String) ResponseHashTable.get(PayflowConstants.PARAM_START);
        term = (String) ResponseHashTable.get(PayflowConstants.PARAM_TERM);
        payPeriod = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYPERIOD);
        status = (String) ResponseHashTable.get(PayflowConstants.PARAM_STATUS);
        tender = (String) ResponseHashTable.get(PayflowConstants.PARAM_TENDER);
        paymentsLeft = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYMENTSLEFT);
        nextPayment = (String) ResponseHashTable.get(PayflowConstants.PARAM_NEXTPAYMENT);
        end = (String) ResponseHashTable.get(PayflowConstants.PARAM_END);
        aggregateAmt = (String) ResponseHashTable.get(PayflowConstants.PARAM_AGGREGATEAMT);
        aggregateOptionalAmt = (String) ResponseHashTable.get(PayflowConstants.PARAM_AGGREGATEOPTIONALAMT);
        amt = (String) ResponseHashTable.get(PayflowConstants.PARAM_AMT);
        acct = (String) ResponseHashTable.get(PayflowConstants.PARAM_ACCT);
        expDate = (String) ResponseHashTable.get(PayflowConstants.PARAM_EXPDATE);
        maxFailPayments = (String) ResponseHashTable.get(PayflowConstants.PARAM_MAXFAILPAYMENTS);
        numFailPayments = (String) ResponseHashTable.get(PayflowConstants.PARAM_NUMFAILPAYMENTS);
        retryNumDays = (String) ResponseHashTable.get(PayflowConstants.PARAM_RETRYNUMDAYS);
        companyName = (String) ResponseHashTable.get(PayflowConstants.PARAM_COMPANYNAME);
        // Since Recurring Billing was never updated to support "BILLTO" parameters, overriding with older NVPs.
        name = (String) ResponseHashTable.get(PayflowConstants.PARAM_NAME);
        firstName = (String) ResponseHashTable.get(PayflowConstants.PARAM_FIRSTNAME);
        middleName = (String) ResponseHashTable.get(PayflowConstants.PARAM_MIDDLENAME);
        lastname = (String) ResponseHashTable.get("LASTNAME");
        street = (String) ResponseHashTable.get("STREET");
        city = (String) ResponseHashTable.get("CITY");
        state = (String) ResponseHashTable.get("STATE");
        zip = (String) ResponseHashTable.get("ZIP");
        email = (String) ResponseHashTable.get("EMAIL");
        country = (String) ResponseHashTable.get(PayflowConstants.PARAM_COUNTRY);
        phoneNum = (String) ResponseHashTable.get(PayflowConstants.PARAM_PHONENUM);
        shipToFName = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOFIRSTNAME);
        shipToMName = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOMIDDLENAME);
        shipToLName = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOLASTNAME);
        shipToStreet = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOSTREET);
        shipToCity = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOCITY);
        shipToState = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOSTATE);
        shipToZip = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOZIP);
        shipToCountry = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOCOUNTRY);
        creationDate = (String) ResponseHashTable.get(PayflowConstants.PARAM_CREATIONDATE);
        lastChanged = (String) ResponseHashTable.get(PayflowConstants.PARAM_LASTCHANGED);
        rpState = (String) ResponseHashTable.get(PayflowConstants.PARAM_RPSTATE);
        nextPaymentNumber = (String) ResponseHashTable.get(PayflowConstants.PARAM_NEXTPAYMENTNUM);
        frequency = (String) ResponseHashTable.get(PayflowConstants.PARAM_FREQUENCY);
        currency = (String) ResponseHashTable.get(PayflowConstants.PARAM_CURRENCY);


        ResponseHashTable.remove(PayflowConstants.PARAM_PROFILEID);
        ResponseHashTable.remove(PayflowConstants.PARAM_RPREF);
        ResponseHashTable.remove(PayflowConstants.PARAM_TRXPNREF);
        ResponseHashTable.remove(PayflowConstants.PARAM_TRXRESULT);
        ResponseHashTable.remove(PayflowConstants.PARAM_TRXRESPMSG);
        ResponseHashTable.remove(PayflowConstants.PARAM_PROFILENAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_START);
        ResponseHashTable.remove(PayflowConstants.PARAM_TERM);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYPERIOD);
        ResponseHashTable.remove(PayflowConstants.PARAM_STATUS);
        ResponseHashTable.remove(PayflowConstants.PARAM_TENDER);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYMENTSLEFT);
        ResponseHashTable.remove(PayflowConstants.PARAM_NEXTPAYMENT);
        ResponseHashTable.remove(PayflowConstants.PARAM_END);
        ResponseHashTable.remove(PayflowConstants.PARAM_AGGREGATEAMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_AGGREGATEOPTIONALAMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_AMT);
        ResponseHashTable.remove(PayflowConstants.PARAM_ACCT);
        ResponseHashTable.remove(PayflowConstants.PARAM_EXPDATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_MAXFAILPAYMENTS);
        ResponseHashTable.remove(PayflowConstants.PARAM_NUMFAILPAYMENTS);
        ResponseHashTable.remove(PayflowConstants.PARAM_RETRYNUMDAYS);
        ResponseHashTable.remove(PayflowConstants.PARAM_COMPANYNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_NAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_FIRSTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_MIDDLENAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_LASTNAME);
        ResponseHashTable.remove("STREET");
        ResponseHashTable.remove("CITY");
        ResponseHashTable.remove("STATE");
        ResponseHashTable.remove("ZIP");
        ResponseHashTable.remove("EMAIL");
        ResponseHashTable.remove(PayflowConstants.PARAM_COUNTRY);
        ResponseHashTable.remove(PayflowConstants.PARAM_PHONENUM);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOFIRSTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOMIDDLENAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOLASTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOSTREET);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOCITY);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOSTATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOZIP);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOCOUNTRY);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_RESULTn);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_PNREFn);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_TRANSTATEn);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_TENDERn);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_TRANSTIMEn);
        ResponseHashTable.remove(PayflowConstants.PARAM_P_AMOUNTn);
        ResponseHashTable.remove(PayflowConstants.PARAM_CREATIONDATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_LASTCHANGED);
        ResponseHashTable.remove(PayflowConstants.PARAM_RPSTATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_NEXTPAYMENTNUM);
        ResponseHashTable.remove(PayflowConstants.PARAM_FREQUENCY);
        ResponseHashTable.remove(PayflowConstants.PARAM_CURRENCY);
    }

}


