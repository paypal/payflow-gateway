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

/**
 * Summary description for BasicAuthorizationTransaction.
 */
class BasicAuthorizationTransaction extends AuthorizationTransaction {

    /**
     * @param tender                PayPalTender
     * @param invoice               Invoice
     * @param userInfo              UserInfo
     * @param payflowConnectionData PayflowConnectionData
     * @param requestId             String
     */
    public BasicAuthorizationTransaction(PayPalTender tender, Invoice invoice, UserInfo userInfo, PayflowConnectionData payflowConnectionData, String requestId) {
        super("B", userInfo, payflowConnectionData, invoice, tender, requestId);
    }

    /**
     * @param tender    PayPalTender
     * @param invoice   Invoice
     * @param userInfo  UserInfo
     * @param requestId String
     */
    public BasicAuthorizationTransaction(PayPalTender tender, Invoice invoice, UserInfo userInfo, String requestId) {
        super("B", userInfo, invoice, tender, requestId);
    }

}

