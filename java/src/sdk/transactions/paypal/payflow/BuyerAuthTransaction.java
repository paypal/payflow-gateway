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
 * This abstract class serves as base class for
 * Buyer auth transactions.
 */
public class BuyerAuthTransaction extends BaseTransaction {

    /**
     * @param trxType               Transaction type
     * @param userInfo              User Info object populated with user credentials.
     * @param payflowConnectionData Connection credentials object.
     * @param requestId             String
     */
    protected BuyerAuthTransaction(String trxType, UserInfo userInfo, PayflowConnectionData payflowConnectionData, String requestId) {
        super(trxType, userInfo, payflowConnectionData, requestId);
    }

    /**
     * @param trxType   Transaction type
     * @param userInfo  User Info object populated with user credentials.
     * @param requestId String
     */
    protected BuyerAuthTransaction(String trxType, UserInfo userInfo, String requestId) {
        this(trxType, userInfo, null, requestId);
    }
}

