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

import paypal.payflow.ECGetResponse;

import java.util.ArrayList;
import java.util.Enumeration;
import java.util.Hashtable;

/**
 * Container class for response messages.
 * <p>This class enclosed response data objects specific to
 * following:
 * <ol>
 * <li>Transaction response
 * --> Response messages common to all transactions.</li>
 * <li>Fraud response
 * --> Fraud Filters response messages.</li>
 * <li>Recurring response
 * --> Recurring transaction response messages.</li>
 * <li>Buyerauth response
 * --> Buyer auth response messages. (Not supported.)</li>
 * </ol>
 * <p>Additionally the Response class also contains the
 * transaction context, full request response string values.</p>
 * {@link FraudResponse}
 * {@link TransactionResponse}
 * {@link RecurringResponse}
 * {@link BuyerAuthResponse}
 * {@link Context}
 * </p>
 * Following example shows, how to obtain response
 * of a transaction and how to use it.
 *
 * @paypal.sample ..........
 * // Trans is the transaction object.
 * *		...................
 * // Submit the transaction.
 * Response resp = trans.SubmitTransaction();
 * <p/>
 * if (resp != null)
 * {
 * // Get the Transaction Response parameters.
 * TransactionResponse trxnResponse =  resp.getTransactionResponse();
 * if (trxnResponse!= null)
 * {
 * System.out.println("RESULT = " + trxnResponse.Result);
 * System.out.println("RESPMSG = " + trxnResponse.RespMsg);
 * }
 * <p/>
 * // Get the Recurring Response parameters.
 * RecurringResponse recurResponse = resp.getRecurringResponse();
 * if (recurResponse != null)
 * {
 * System.out.println("RPREF = " + recurResponse.getRPRef());
 * System.out.println("PROFILEID = " + recurResponse.getProfileId());
 * }
 * }
 * <p/>
 * // Get the Context and check for any contained SDK specific errors.
 * Context ctx = resp.getTransactionContext();
 * if (ctx != null &amp;&amp; ctx.getErrorCount() > 0)
 * {
 * System.out.println( "Errors = " + ctx());
 * }
 */
public final class Response extends BaseResponseDataObject {

    private FraudResponse fraudResponse;
    private BuyerAuthResponse buyerAuthResponse;
    private RecurringResponse recurringResponse;
    private ECDoResponse ecDoResponse;
    private TransactionResponse transactionResponse;
    private Context context;
    private Hashtable responseHashTable;
    private ArrayList extDataList;
    private String requestString;
    private String responseString;
    private String requestId;
    private ECGetResponse ecGetResponse;
    private ExpressCheckoutResponse ecSetResponse;
    private ECUpdateResponse ecUpdateResponse;

    /**
     * Gets the container object for all the fraud filters
     * related response messages.
     * {@link FraudResponse}
     *
     * @return - FraudResponse
     */
    public FraudResponse getFraudResponse() {
        return fraudResponse;
    }

    /**
     * Gets the container object for all the express
     * checkout related response messages for GET.
     * {@link ECGetResponse}
     *
     * @return - ECGetResponse
     */
    public ECGetResponse getEcGetResponse() {
        return ecGetResponse;
    }

    /**
     * Gets the container object for all the express
     * checkout related response messages for SET.
     * {@link ExpressCheckoutResponse}
     *
     * @return - ExpressCheckoutResponse
     */
    public ExpressCheckoutResponse getEcSetResponse() {
        return ecSetResponse;
    }

    /**
     * Gets the container object for all the express
     * checkout related response messages for SET.
     * {@link ExpressCheckoutResponse}
     *
     * @return - ExpressCheckoutResponse
     */
    public ECUpdateResponse getEcUpdateResponse() {
        return ecUpdateResponse;
    }

    /**
     * Gets the container object for all the buyer auth
     * related response messages.
     * {@link BuyerAuthResponse}
     *
     * @return - BuyerAuthResponse
     */
    public BuyerAuthResponse getBuyerAuthResponse() {
        return buyerAuthResponse;
    }

    /**
     * Gets the container object for all the recurring
     * transaction related response messages.
     * {@link RecurringResponse}
     *
     * @return - RecurringResponse
     */
    public RecurringResponse getRecurringResponse() {
        return recurringResponse;
    }

    /**
     * Gets the container object for all the express
     * checkout related response messages for DO.
     * {@link ECDoResponse}
     *
     * @return - ECDoResponse
     */
    public ECDoResponse getEcDoResponse() {
        return ecDoResponse;
    }

    /**
     * Gets the container object for response messages common to
     * all the transactions.
     * {@link TransactionResponse}
     *
     * @return - TransactionResponse
     */
    public TransactionResponse getTransactionResponse() {
        return transactionResponse;
    }

    /**
     * Gets the transaction context
     * populated with errors, if any.
     * {@link Context}
     *
     * @return - Context
     */
    public Context getContext() {
        return context;
    }

    /**
     * Gets the The arraylist containing the extend data objects populated
     * with the response messages..
     * {@link ExtendData}
     *
     * @return - ArrayList
     */
    public ArrayList getExtDataList() {
        return extDataList;
    }

    /**
     * Gets the request string sent to the gateway.
     *
     * @return - String
     */
    public String getRequestString() {
        return requestString;
    }

    /**
     * Gets the response string.
     *
     * @return - String
     */
    public String getResponseString() {
        return responseString;
    }

    /**
     * Gets the request id sent to the gateway.
     *
     * @return - String
     */
    public String getRequestId() {
        return requestId;
    }

    protected void setRequestString(String RequestString) {
        requestString = RequestString;
    }

    /**
     * Constructor
     */
    public Response() {
        context = new Context();
    }

    /**
     * Constructor
     *
     * @param RequestId  String
     * @param TrxContext String
     */
    public Response(String RequestId, Context TrxContext) {
        context = TrxContext;
        requestId = RequestId;
    }

    /**
     * @param Response String
     */
    private void parseResponse(String Response) {
        Context respContext;
        respContext = new Context();
        if (respContext.getHighestErrorLvl() == PayflowConstants.SEVERITY_FATAL) {

            String Result = PayflowUtility.locateValueForName(Response, PayflowConstants.PARAM_RESULT, false);
            String RespMsg = PayflowUtility.locateValueForName(Response, PayflowConstants.PARAM_RESPMSG, false);
            if (responseHashTable == null) {
                responseHashTable = new Hashtable();
            }

            responseHashTable.put(PayflowConstants.INTL_PARAM_FULLRESPONSE, responseString);
            responseHashTable.put(PayflowConstants.PARAM_RESULT, Result);
            responseHashTable.put(PayflowConstants.PARAM_RESPMSG, RespMsg);


        } else {
            responseHashTable = ParameterListValidator.parseNVPList(Response, respContext, true);
            if (responseHashTable != null) {
                responseHashTable.put(PayflowConstants.INTL_PARAM_FULLRESPONSE, Response);
            }
        }

    }

    private void setResultParams() {
        transactionResponse = new TransactionResponse();
        transactionResponse.setParams(responseHashTable);
    }


    private void setBuyerAuthResultParams() {
        buyerAuthResponse = new BuyerAuthResponse();
        buyerAuthResponse.setParams(responseHashTable);
    }


    private void setRecurringResultParams() {
        recurringResponse = new RecurringResponse();
        recurringResponse.setParams(responseHashTable);
    }

    private void setFraudResultParams() {
        fraudResponse = new FraudResponse();
        fraudResponse.setContext(context);
        fraudResponse.setParams(responseHashTable);
    }

    private void setECGetResultParams() {
        ecGetResponse = new ECGetResponse();
        ecGetResponse.setParams(responseHashTable);
    }

    private void setECDoResultParms() {
        ecDoResponse = new ECDoResponse();
        ecDoResponse.setParams(responseHashTable);
    }

    private void setECUpdateResultParams() {
        ecUpdateResponse = new ECUpdateResponse();
        ecUpdateResponse.setParams(responseHashTable);
    }

    private void setECSetResultParams() {
        ecSetResponse = new ExpressCheckoutResponse();
        ecSetResponse.setParams(responseHashTable);
    }

    private void setResponseDataObjects() {
        this.setResultParams();
        this.setFraudResultParams();
        this.setBuyerAuthResultParams();
        String TrxType = PayflowUtility.locateValueForName(requestString,
                PayflowConstants.PARAM_TRXTYPE, false);

        if (PayflowConstants.TRXTYPE_RECURRING.equals(TrxType)) {
            this.setRecurringResultParams();
        } else {
            this.setECDoResultParms();
            this.setECGetResultParams();
            this.setECSetResultParams();
            this.setECUpdateResultParams();
        }
        this.setExtDataList();
        responseHashTable = null;
    }

    /**
     * @param Response String
     */
    protected void setParams(String Response) {
        try {
            responseString = Response;
            if (Response != null) {
                int ResultIndex = Response.indexOf(PayflowConstants.PARAM_RESULT);
                if (ResultIndex >= 0) {
                    if (ResultIndex > 0) {
                        Response = Response.substring(ResultIndex);
                    }
                    this.parseResponse(Response);
                    this.setResponseDataObjects();
                } else {
                    // Append the RESULT and RESPMSG for error code E_UNKNOWN_STATE and create a message.
                    // Call SetParams again on it.
                    String responseValue = PayflowConstants.PARAM_RESULT
                            + PayflowConstants.SEPARATOR_NVP
                            + PayflowConstants.CommErrorCodes.get(PayflowConstants.E_UNKNOWN_STATE)
                            + PayflowConstants.DELIMITER_NVP
                            + PayflowConstants.PARAM_RESPMSG
                            + PayflowConstants.SEPARATOR_NVP
                            + PayflowConstants.CommErrorMessages.get(PayflowConstants.E_UNKNOWN_STATE)
                            + ", " + responseString;
                    this.setParams(responseValue);
                }
            } else {
                String AddlMessage = "Empty response";
                ErrorObject Err = PayflowUtility.populateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_WARN, false, AddlMessage);
                context.addError(Err);
                Err = context.getError(context.getErrorCount() - 1);
                String ResponseValue = Err.toString();
                this.setParams(ResponseValue);
            }
        } catch (Exception Ex) {
            ErrorObject Error = PayflowUtility.populateCommError(PayflowConstants.E_UNKNOWN_STATE, Ex, PayflowConstants.SEVERITY_ERROR, false, null);
            context.addError(Error);
            String ResponseValue = Error.toString();
            this.setParams(ResponseValue);
        }
    }

    /**
     *
     */
    private void setExtDataList() {
        ExtendData ExtData;
        String Name;
        String Value;
        if (responseHashTable == null || responseHashTable.size() == 0) {
            extDataList = null;
        } else {
            extDataList = new ArrayList();

            Enumeration respKeys = responseHashTable.keys();

            while (respKeys.hasMoreElements()) {
                Name = (String) respKeys.nextElement();
                Value = (String) responseHashTable.get(Name);
                int DuplicateKeyIndex = Name.indexOf(PayflowConstants.TAG_DUPLICATE);
                if (DuplicateKeyIndex > 0) {
                    Name = Name.substring(0, DuplicateKeyIndex - 1);
                }
                if (Name.startsWith(PayflowConstants.PREFIX_RECURRING_INQUIRY_RESP)) {
                    recurringResponse.getInquiryParams().put(Name, Value);
                } else {
                    ExtData = new ExtendData(Name, Value);
                    extDataList.add(ExtData);
                }
            }
        }
    }
}



