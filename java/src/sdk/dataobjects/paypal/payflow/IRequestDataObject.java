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
 * Interface for all request data objects.
 * <p/>
 * This interface can be used to create a new request data object.
 * </p>
 */

public interface IRequestDataObject {

    /**
     * /// Generates the transaction request.
     * /// <p>When implemented in the derived class, this method
     * /// should be preferred to be made as an internal method.</p>
     */
    void generateRequest();

}

