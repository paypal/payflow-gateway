/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

package paypal.payflow;

import paypal.payflow.ExpressCheckoutResponse;

import java.util.Hashtable;

/**
 * Used for ExpressCheckout update operation.
 * {@link ExpressCheckoutResponse}
 */

public class ECGetResponse extends ExpressCheckoutResponse {
    private String email;
    private String payerId;
    private String payerStatus;
    private String shipToFirstName;
    private String shipToLastName;
    private String shipToName;
    private String shipToCountryCode;
    private String shipToBusiness;
    //private String firstName;
    //private String lastName;
    private String shipToStreet;
    private String shipToStreet2;
    private String shipToCity;
    private String shipToState;
    private String shipToZip;
    private String countryCode;
    private String phoneNum;
    private String ba_Flag;
    private String street;
    private String street2;
    private String city;
    private String state;
    private String zip;
    private String addressStatus;

    /**
     * Gets the email parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: EMAIL
     */
    public String getEmail() {
        return email;
    }

    /**
     * Gets the payerid parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYERID
     */
    public String getPayerId() {
        return payerId;
    }

    /**
     * Gets the payerstatus parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PAYERSTATUS
     */
    public String getPayerStatus() {
        return payerStatus;
    }

    /**
     * Gets the shiptoname parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTONAME
     */
    public String getShipToName() {
        return shipToName;
    }

    /**
     * Gets the shiptofirstname parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOFIRSTNAME
     */
    public String getShipToFirstName() {
         return shipToFirstName;
    }

    /**
     * Gets the shiptolastname parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOLASTNAME
     */
    public String getShipToLastName() {
         return shipToLastName;
    }

    /**
     * Gets the shiptocountry parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOCOUNTRY
     */
    public String getShipToCountry() {
        return shipToCountryCode;
    }

    /**
     * Gets the shiptobusiness parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOBUSINESS
     */
    public String getShipToBusiness() {
        return shipToBusiness;
    }

    /**
     * Gets the firstname parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: FIRSTNAME
     */
    //public String getFirstName() {
      //  return firstName;
    //}

    /**
     * Gets the lastname parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: LASTNAME
     */
    //public String getLastName() {
      //  return lastName;
   // }

    /**
     * Gets the shiptostreet parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOSTREET
     */
    public String getShipToStreet() {
        return shipToStreet;
    }

    /**
     * Gets the shiptostreet2 parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOSTREET2
     */
    public String getShipToStreet2() {
        return shipToStreet2;
    }

    /**
     * Gets the shiptocity parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOCITY
     */
    public String getShipToCity() {
        return shipToCity;
    }

    /**
     * Gets the shiptostate parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOSTATE
     */
    public String getShipToState() {
        return shipToState;
    }

    /**
     * Gets the countrycode parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: COUNTRYCODE
     */
    public String getCountryCode() {
        return countryCode;
    }

    /**
     * Gets the shiptozip parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: SHIPTOZIP
     */
    public String getShipToZip() {
        return shipToZip;
    }

    /**
     * Gets the ba_flag parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: BA_FLAG
     */
    public String getba_Flag() {
        return ba_Flag;
    }

    /**
     * Gets the phonenum parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: PHONENUM
     */
    public String getPhoneNum() {
        return phoneNum;
    }

    /**
     * Gets the street parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: STREET
     */
    public String getStreet() {
        return street;
    }

    /**
     * Gets the street2 parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: STREET2
     */
    public String getStreet2() {
        return street2;
    }

    /**
     * Gets the city parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: CITY
     */
    public String getCity() {
        return city;
    }

    /**
     * Gets the state parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: STATE
     */
    public String getState() {
        return state;
    }

    /**
     * Gets the zip parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: ZIP
     */
    public String getZip() {
        return zip;
    }

    /**
     * Gets the addressStatus parameter
     *
     * @return - String
     * @paypal.sample <p>Maps to Payflow Parameter: ADDRESSSTATUS
     */
    public String getAddressStatus() {
        return addressStatus;
    }

    protected ECGetResponse() {
    }

    protected void setParams(Hashtable ResponseHashTable) {
        email = (String) ResponseHashTable.get(PayflowConstants.PARAM_EMAIL);
        payerId = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYERID);
        payerStatus = (String) ResponseHashTable.get(PayflowConstants.PARAM_PAYERSTATUS);
        shipToName = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTONAME);
        // 04/08/2015 shipToFirstName and shipToLastName are not returned in the response, mapping only.
        shipToFirstName = (String) ResponseHashTable.get(PayflowConstants.PARAM_FIRSTNAME);
        shipToLastName = (String) ResponseHashTable.get(PayflowConstants.PARAM_LASTNAME);
        shipToCountryCode = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOCOUNTRY);
        shipToBusiness = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOBUSINESS);
        //firstName = (String) ResponseHashTable.get(PayflowConstants.PARAM_FIRSTNAME);
        //lastName = (String) ResponseHashTable.get(PayflowConstants.PARAM_LASTNAME);
        street = (String) ResponseHashTable.get(PayflowConstants.PARAM_STREET);
        street2 = (String) ResponseHashTable.get(PayflowConstants.PARAM_STREET2);
        city = (String) ResponseHashTable.get(PayflowConstants.PARAM_CITY);
        state = (String) ResponseHashTable.get(PayflowConstants.PARAM_STATE);
        zip = (String) ResponseHashTable.get(PayflowConstants.PARAM_ZIP);
        shipToStreet = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOSTREET);
        shipToStreet2 = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOSTREET2);
        shipToCity = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOCITY);
        shipToState = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOSTATE);
        shipToZip = (String) ResponseHashTable.get(PayflowConstants.PARAM_SHIPTOZIP);
        countryCode = (String) ResponseHashTable.get(PayflowConstants.PARAM_COUNTRYCODE);
        phoneNum = (String) ResponseHashTable.get(PayflowConstants.PARAM_PHONENUM);
        ba_Flag = (String) ResponseHashTable.get(PayflowConstants.PARAM_BA_FLAG);
        addressStatus = (String) ResponseHashTable.get(PayflowConstants.PARAM_ADDRESSSTATUS);

        ResponseHashTable.remove(PayflowConstants.PARAM_EMAIL);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYERID);
        ResponseHashTable.remove(PayflowConstants.PARAM_PAYERSTATUS);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTONAME);
        //ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOFIRSTNAME);
        //ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOLASTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOCOUNTRY);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOBUSINESS);
        ResponseHashTable.remove(PayflowConstants.PARAM_FIRSTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_LASTNAME);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOSTREET);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOSTREET2);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOCITY);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOSTATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_SHIPTOZIP);
        ResponseHashTable.remove(PayflowConstants.PARAM_COUNTRYCODE);
        ResponseHashTable.remove(PayflowConstants.PARAM_PHONENUM);
        ResponseHashTable.remove(PayflowConstants.PARAM_BA_FLAG);
        ResponseHashTable.remove(PayflowConstants.PARAM_STREET);
        ResponseHashTable.remove(PayflowConstants.PARAM_STREET2);
        ResponseHashTable.remove(PayflowConstants.PARAM_CITY);
        ResponseHashTable.remove(PayflowConstants.PARAM_STATE);
        ResponseHashTable.remove(PayflowConstants.PARAM_ZIP);
        ResponseHashTable.remove(PayflowConstants.PARAM_ADDRESSSTATUS);

    }
}

