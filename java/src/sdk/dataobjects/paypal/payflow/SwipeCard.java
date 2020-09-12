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
 * Used for swipe card information
 * <p/>
 * Used to pass the Track 1 or Track 2 data (the card's magnetic stripe information) for card-present
 * transactions. Include either Track 1 or Track 2 data'not both. If Track 1 is physically damaged, the
 * POS application can send Track 2 data instead.
 * <p/>
 * SwipeCard is associated with CardTender. {@link CardTender}
 * </p>
 */

public final class SwipeCard extends PaymentDevice {
    /**
     * Constructor for SwipeCard
     *
     * @param swipe Card Swipe value
     *              <p/>
     *              This is used as Payment Device for the CardTender.
     * @paypal.sample <p>
     * Maps to Payflow Parameter: SWIPE
     * <p/>
     * //Create the SwipeCard object
     * SwipeCard payDevice = new SwipeCard("XXXXXXXXXXXXXXXXXXXXXXXXXXX");
     */
    public SwipeCard(String swipe) {
        super(swipe);
    }

    /**
     *
     */
    protected void generateRequest() {
        super.generateRequest();
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_SWIPE, super.getAcct()));
    }
}

