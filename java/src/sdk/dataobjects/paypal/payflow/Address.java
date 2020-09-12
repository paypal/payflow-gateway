/**
 * This program is free software: you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */package paypal.payflow;

/// <summary>
/// Abstract class to hold the Address information.
/// </summary>

/// <remarks>This class can be extended to create a new address type.</remarks>
public abstract class Address extends BaseRequestDataObject {

    private String addressStreet;
    private String addressStreet2;
    private String city;
    private String state;
    private String zip;
    private String country;
    private String phoneNum;
    private String phone2;
    private String email;
    private String fax;
    private String firstName;
    private String middleName;
    private String lastName;


    /// <summary>
    /// Constructor for Address.
    /// </summary>
    /// <remarks>Abstract class. Instance cannot be created directly.</remarks>
    protected Address() {
    }

    protected String getAddressStreet() {
        return addressStreet;
    }

    protected void setAddressStreet(String addressStreet) {
        this.addressStreet = addressStreet;
    }

    protected String getAddressStreet2() {
        return addressStreet2;
    }

    protected void setAddressStreet2(String addressStreet2) {
        this.addressStreet2 = addressStreet2;
    }

    protected String getAddressCity() {
        return city;
    }

    protected void setAddressCity(String city) {
        this.city = city;
    }

    protected String getAddressCountry() {
        return country;
    }

    protected void setAddressCountry(String country) {
        this.country = country;
    }

    protected String getAddressEmail() {
        return email;
    }

    protected void setAddressEmail(String email) {
        this.email = email;
    }

    protected String getAddressFax() {
        return fax;
    }

    protected void setAddressFax(String fax) {
        this.fax = fax;
    }

    protected String getAddressFirstName() {
        return firstName;
    }

    protected void setAddressFirstName(String firstName) {
        this.firstName = firstName;
    }

    protected String getAddressLastName() {
        return lastName;
    }

    protected void setAddressLastName(String lastName) {
        this.lastName = lastName;
    }

    protected String getAddressMiddleName() {
        return middleName;
    }

    protected void setAddressMiddleName(String middleName) {
        this.middleName = middleName;
    }

    protected String getAddressPhone2() {
        return phone2;
    }

    protected void setAddressPhone2(String phone2) {
        this.phone2 = phone2;
    }

    protected String getAddressPhone() {
        return phoneNum;
    }

    protected void setAddressPhone(String phoneNum) {
        this.phoneNum = phoneNum;
    }

    protected String getAddressState() {
        return state;
    }

    protected void setAddressState(String state) {
        this.state = state;
    }

    protected String getAddressZip() {
        return zip;
    }

    protected void setAddressZip(String zip) {
        this.zip = zip;
    }

}