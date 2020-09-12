package paypal.payflow;

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

/**
 * This class is used to store the complete information
 * about a client information header.
 */
final class ClientInfoHeader extends BaseRequestDataObject {
    /**
     * Stores Header name
     */
    private String headerName;

    /**
     * Stores Header value
     */
    private Object headerValue;

    /**
     * Contructor
     *
     * @param headerName  String
     * @param headerValue Object
     */
    public ClientInfoHeader(String headerName, Object headerValue) {
        this.headerName = headerName;
        this.headerValue = headerValue;
    }

    /**
     * Gets header name
     *
     * @return mHeaderName String
     */
    public String getHeaderName() {
        return this.headerName;
    }

    /**
     * Gets header value
     *
     * @return mHeaderValue Object
     */
    public Object getHeaderValue() {
        return this.headerValue;
    }
}
