package paypal.payflow;

import java.util.Hashtable;

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
 * This class is used to store the Payflow Client related properties.
 */
public final class ClientInfo extends BaseRequestDataObject {
    private Hashtable clientInfoHash = null;

    /**
     * Constructor
     */
    public ClientInfo() {
        clientInfoHash = new Hashtable();
    }

    /**
     * Gets the client info hash table
     *
     * @return clientInfoHash HashTable
     */
    protected Hashtable getClientInfoHash() {
        return clientInfoHash;
    }

    /**
     * gets the clientVersion
     *
     * @return clientVersion
     */
    public String getClientVersion() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_CLIENT_VERSION);
    }

    /**
     * Gets the OS architecture
     *
     * @return osArchitecture String
     */
    protected String getOsArchitecture() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_ARCHITECTURE);
    }

    /**
     * Sets the OS architecture
     *
     * @param value String
     */
    protected void setOsArchitecture(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_ARCHITECTURE, value);
    }

    /**
     * gets the OS version
     *
     * @return osVersion String
     */
    protected String getOsVersion() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_VERSION);
    }

    /**
     * sets the OsVersion
     *
     * @param value String
     */
    protected void setOsVersion(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_VERSION, value);
    }

    /**
     * Gets the OS Name
     *
     * @return osName String
     */
    protected String getOsName() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_NAME);
    }

    /**
     * sets the OsName
     *
     * @param value String
     */
    protected void setOsName(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_NAME, value);
    }

    /**
     * Gets the Proxy header.
     *
     * @return proxy String
     */
    protected String getProxy() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_PROXY);
    }

    /**
     * sets the Proxy header
     *
     * @param value String
     */
    protected void setProxy(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_PROXY, value);
    }

    /**
     * Gets the Java runtime version
     *
     * @return runTimeVersion String
     */
    protected String getRunTimeVersion() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_RUNTIME_VERSION);
    }

    /**
     * Sets the Java runtime version
     *
     * @param value String
     */
    protected void setRunTimeVersion(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_RUNTIME_VERSION, value);
    }

    /**
     * Sets the integration product
     *
     * @param value String
     */
    public void setIntegrationProduct(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_PRODUCT, value);
    }

    /**
     * Sets the integration version
     *
     * @param value String
     */
    public void setIntegrationVersion(String value) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_VERSION, value);
    }

    /**
     * Gets Client Type
     *
     * @return ClientType String
     */
    public String getClientType() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_CLIENT_TYPE);
    }

    /**
     * Sets client version
     *
     * @param version String
     */
    protected void setClientVersion(String version) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_CLIENT_VERSION, version);
    }

    /**
     * Gets integration product
     *
     * @return IntegrationProduct String
     */
    protected String getIntegrationProduct() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_PRODUCT);
    }

    /**
     * Gets integration version
     *
     * @return IntegrationVersion String
     */
    protected String getIntegrationVersion() {
        return (String) getHeaderFromHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_VERSION);
    }

    /**
     * @param clientType String
     */
    protected void setClientType(String clientType) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_CLIENT_TYPE, clientType);
    }

    /**
     * payflowAssembly, the possible values are PayflowConstants.STRONG_ASSEMBLY or PayflowConstants.WEAK_ASSEMBLY
     *
     * @param payflowAssembly String
     */
    protected void setPayflowAssembly(String payflowAssembly) {
        addHeaderToHash(PayflowConstants.PAYFLOWHEADER_PAYFLOW_ASSEMBLY, payflowAssembly);
    }

    /**
     * Adds a header to the header hash table
     *
     * @param headerName  String
     * @param headerValue Object
     */
    protected void addHeaderToHash(String headerName, Object headerValue) {
        Logger.getInstance().log("paypal.payflow.ClientInfo.addHeaderToHash(String, Object): Entered", PayflowConstants.SEVERITY_DEBUG);
        // Null Header Names & Values are not allowed.
        // Empty Header Names are not allowed.
        if (!(headerName == null || headerName.length() == 0 || headerValue == null)) {

            ClientInfoHeader currHeader
                    = new ClientInfoHeader(headerName, headerValue);

            if (clientInfoHash == null) {
                clientInfoHash = new Hashtable();
            }

            if (clientInfoHash.containsKey(headerName)) {
                clientInfoHash.remove(headerName);
            }

            clientInfoHash.put(headerName, currHeader);
        }
        Logger.getInstance().log("paypal.payflow.ClientInfo.addHeaderToHash(String, Object): Exiting", PayflowConstants.SEVERITY_DEBUG);
    }

    /**
     * Gets a header value from hash
     *
     * @param headerName String
     * @return headerValue Object
     */
    protected Object getHeaderFromHash(String headerName) {
        Logger.getInstance().log("paypal.payflow.ClientInfo.getHeaderFromHash(String): Entered", PayflowConstants.SEVERITY_DEBUG);
        Object header = null;
        if (null != clientInfoHash) {
            ClientInfoHeader currHeader = (ClientInfoHeader) clientInfoHash.get(headerName);
            if (null != currHeader) {
                header = currHeader.getHeaderValue();
            }
        }
        Logger.getInstance().log("paypal.payflow.ClientInfo.getHeaderFromHash(String): Exiting", PayflowConstants.SEVERITY_DEBUG);
        return header;

    }

}