#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;
using System.Collections;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Container class for response messages.
	/// </summary>
	/// <remarks>This class enclosed response data objects specific to
	/// following:
	/// <list type="bullet">
	/// <item>Transaction response 
	/// --> Response messages common to all transactions.</item>
	/// <item>Fraud response 
	/// --> Fraud Filters response messages.</item>
	/// <item>Recurring response 
	/// --> Recurring transaction response messages.</item>
	/// <item>Buyerauth response 
	/// --> Buyer auth response messages. (Not supported.)</item>
	/// </list>
	/// <para>Additionally the Response class also contains the 
	/// transaction context, full request response string values.</para>
	/// <seealso cref="FraudResponse"/>
	/// <seealso cref="TransactionResponse"/>
	/// <seealso cref="RecurringResponse"/>
	/// <seealso cref="BuyerAuthResponse"/>
	/// <seealso cref="Context"/>
	/// </remarks>
	/// <example>Following example shows, how to obtain response
	///  of a transaction and how to use it.
	/// <code lang="C#" escaped="false">
	///		..........
	///		// Trans is the transaction object.
	///		..........
	///		
	///		//Submit the transaction.
	///		Trans.SubmitTransaction();
	///			
	///		// Get the Response.
	///		Response Resp = Trans.Response;
	///		if (Resp != null)
	///		{
	///			// Get the Transaction Response parameters.
	///			TransactionResponse TrxnResponse =  Resp.TransactionResponse;
	///			if (TrxnResponse != null)
	///			{
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result);
	///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref);
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg);
	///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode);
	///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr);
	///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip);
	///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS);
	///			}
	///			// Get the Fraud Response parameters.
	///			FraudResponse FraudResp =  Resp.FraudResponse;
	///			if (FraudResp != null)
	///			{
	///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg);
	///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg);
	///			}
	///		}
	///		// Get the Context and check for any contained SDK specific errors.
	///		Context Ctx = Resp.TransactionContext;
	///		if (Ctx != null &amp;&amp; Ctx.getErrorCount() > 0)
	///		{
	///			Console.WriteLine(Environment.NewLine + "Errors = " + Ctx.ToString());
	///		}	
	///</code>
	///<code lang="Visual Basic" escaped="false">
	///		..........
	///		' Trans is the transaction object.
	///		..........
	///		
	///		' Submit the transaction.
	///		Trans.SubmitTransaction()
	///
	///		' Get the Response.
	///		Dim Resp As Response = Trans.Response
	///		
	///		If Not Resp Is Nothing Then
	///		' Get the Transaction Response parameters.
	///		
	///			Dim TrxnResponse As TransactionResponse = Resp.TransactionResponse
	///			
	///			If Not TrxnResponse Is Nothing Then
	///				Console.WriteLine("RESULT = " + TrxnResponse.Result)
	///				Console.WriteLine("PNREF = " + TrxnResponse.Pnref)
	///				Console.WriteLine("RESPMSG = " + TrxnResponse.RespMsg)
	///				Console.WriteLine("AUTHCODE = " + TrxnResponse.AuthCode)
	///				Console.WriteLine("AVSADDR = " + TrxnResponse.AVSAddr)
	///				Console.WriteLine("AVSZIP = " + TrxnResponse.AVSZip)
	///				Console.WriteLine("IAVS = " + TrxnResponse.IAVS)
	///			End If
	///
	///			' Get the Fraud Response parameters.
	///			Dim FraudResp As FraudResponse = Resp.FraudResponse
	///			If Not FraudResp Is Nothing Then
	///				Console.WriteLine("PREFPSMSG = " + FraudResp.PreFpsMsg)
	///				Console.WriteLine("POSTFPSMSG = " + FraudResp.PostFpsMsg)
	///			End If
	///		End If
	///
	///		' Get the Context and check for any contained SDK specific errors.
	///		Dim Ctx As Context = Resp.TransactionContext
	///		
	///		If Not Ctx Is Nothing AndAlso Ctx.getErrorCount() > 0 Then
	///			Console.WriteLine(Constants.vbLf + "Errors = " + Ctx.ToString())
	///		End If												
	/// </code>
	///  </example>
	public sealed class Response
	{
		#region "Member Variables"

		/// <summary>
		/// Fraud Response
		/// </summary>
		private FraudResponse mFraudResponse;

		/// <summary>
		/// Buyer auth response
		/// </summary>
		private BuyerAuthResponse mBuyerAuthResponse;

		/// <summary>
		/// Recurring response
		/// </summary>
		private RecurringResponse mRecurringResponse;

		/// <summary>
		/// Get express checkout details response
		/// </summary>
		private ECGetResponse mGetExpressCheckoutDetailsResponse;

		/// <summary>
		/// DoExpressCheckoutResponse
		/// </summary>
		private ECDoResponse mDoExpressCheckoutPaymentResponse;

		/// <summary>
		/// ExpressCheckoutResponse
		/// </summary>
		private ExpressCheckoutResponse mSetExpressCheckoutPaymentResponse;

		/// <summary>
		/// UpdateExpressCheckoutResponse
		/// </summary>
		private ECUpdateResponse mUpdateExpressCheckoutPaymentResponse;

		/// <summary>
		/// Transaction response
		/// </summary>
		private TransactionResponse mTransactionResponse;

		/// <summary>
		/// Holds the transaction context
		/// </summary>
		private Context mContext;

		/// <summary>
		/// Holds parsed response hash table
		/// </summary>
		private Hashtable mResponseHashTable;

		/// <summary>
		/// Holds Extended data from response
		/// if any
		/// populated into extend data objects
		/// </summary>
		private ArrayList mExtDataList;
		/// <summary>
		/// Request
		/// </summary>
		private String mRequestString;

		/// <summary>
		/// Response string
		/// </summary>
		private String mResponseString;

		/// <summary>
		/// Request id
		/// </summary>
		private String mRequestId;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets FraudResult
		/// </summary>
		/// <remarks>Gets the container object for all the fraud filters
		/// related response messages.
		/// <seealso cref="FraudResponse"/>
		/// </remarks>
		public FraudResponse FraudResponse
		{
			get { return mFraudResponse; }
		}

		/// <summary>
		/// Gets BuyerAuthResult
		/// </summary>
		/// <remarks>Gets the container object for all the buyer auth 
		/// related response messages.
		/// <seealso cref="BuyerAuthResponse"/>
		/// </remarks>
		public BuyerAuthResponse BuyerAuthResponse
		{
			get { return mBuyerAuthResponse; }
		}

		/// <summary>
		/// Gets RecurringResult
		/// </summary>
		/// <remarks>Gets the container object for all the recurring 
		/// transaction related response messages.
		/// <seealso cref="RecurringResponse"/>
		/// </remarks>
		public RecurringResponse RecurringResponse
		{
			get { return mRecurringResponse; }
		}

		/// <summary>
		/// Gets ExpressCheckout Response for GET action
		/// </summary>
		/// <remarks>Gets the container object for all the express
		/// checkout related response messages for GET.
		/// <seealso cref="RecurringResponse"/>
		/// </remarks>
		public ECGetResponse ExpressCheckoutGetResponse
		{
			get { return mGetExpressCheckoutDetailsResponse; }
		}

		/// <summary>
		/// Gets ExpressCheckout Response for DO action
		/// </summary>
		/// <remarks>Gets the container object for all the express
		/// checkout related response messages for DO.
		/// <seealso cref="RecurringResponse"/>
		/// </remarks>
		public ECDoResponse ExpressCheckoutDoResponse
		{
			get { return mDoExpressCheckoutPaymentResponse; }
		}
		
		/// <summary>
		/// Gets ExpressCheckout Response for Set action
		/// </summary>
		/// <remarks>Gets the container object for all the express
		/// checkout related response messages for SET.
		/// <seealso cref="RecurringResponse"/>
		/// </remarks>
		public ExpressCheckoutResponse ExpressCheckoutSetResponse
		{
			get { return mSetExpressCheckoutPaymentResponse; }
		}
		/// <summary>
		/// Gets ExpressCheckout Response for Update action
		/// </summary>
		/// <remarks>Gets the container object for all the express
		/// checkout related response messages for UPDATE.
		/// <seealso cref="RecurringResponse"/>
		/// </remarks>
		public ECUpdateResponse ExpressCheckoutUpdateResponse
		{
			get { return mUpdateExpressCheckoutPaymentResponse; }
		}
		/// <summary>
		/// Gets TransactionResult
		/// </summary>
		/// <remarks>Gets the container object for response messages common to
		/// all the transactions.
		/// <seealso cref="TransactionResponse"/>
		/// </remarks>
		public TransactionResponse TransactionResponse
		{
			get { return mTransactionResponse; }
		}

		/// <summary>
		/// Gets transaction context
		/// </summary>
		/// <remarks>Gets the transaction context 
		/// populated with errors, if any.
		/// <seealso cref="Context"/>
		/// </remarks>
		public Context TransactionContext
		{
			get { return mContext; }
		}

		/// <summary>
		/// Gets extended response
		/// list.
		/// </summary>
		/// <remarks>This arraylist contains the extend data objects populated
		/// with the response messages.
		/// <seealso cref="ExtendData"/>
		/// </remarks>
		public ArrayList ExtendDataList
		{
			get { return mExtDataList; }
		}
		// moved from transaction response to response obj
		/// <summary>
		/// Gets Request
		/// </summary>
		/// <remarks>This is the request string as sent to the
		/// PayPal payment gateway.</remarks>
		public String RequestString
		{
			get { return mRequestString; }
			//set { mRequestString = value; }
		}

		/// <summary>
		/// Gets RequestId
		/// </summary>
		/// <remarks>This is the request id set 
		/// for the transaction as sent to the PayPal payment
		/// gateway.
		/// </remarks>
		public String RequestId
		{
			get { return mRequestId; }
		}

		/// <summary>
		/// Gets Response
		/// </summary>
		/// <remarks>This is the response string as obtained from the
		/// PayPal payment gateway.</remarks>
		public String ResponseString
		{
			get { return mResponseString; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for Response
		/// </summary>
		public Response()
		{
		}

		/// <summary>
		/// Constructor for Response
		/// </summary>
		/// <param name="RequestId">Request Id</param>
		/// <param name="TrxContext">Transaction Context object</param>
		public Response(String RequestId, Context TrxContext)
		{
			mContext = TrxContext;
			//mTransactionResponse = new TransactionResponse(RequestId, ResponseId);\
			mRequestId = RequestId;
		}

		#endregion

		#region "Core Functions"

		/// <summary>
		/// Sets the response params
		/// </summary>
		/// <param name="Response">Response string</param>
		internal void SetParams(String Response)
		{
			try
			{
				mResponseString = Response;
				if (Response != null)
				{
					int ResultIndex = Response.IndexOf(PayflowConstants.PARAM_RESULT);
					if (ResultIndex >= 0)
					{
						if (ResultIndex > 0)
						{
							Response = Response.Substring(ResultIndex);
						}
						ParseResponse(Response);
						SetResultParams(ref mResponseHashTable);
						SetFraudResultParams(ref mResponseHashTable);
						SetBuyerAuthResultParams(ref mResponseHashTable);
						String TrxType = PayflowUtility.LocateValueForName (RequestString ,
										PayflowConstants.PARAM_TRXTYPE, false );
						if (String.Equals (TrxType ,PayflowConstants.TRXTYPE_RECURRING ))
						{
							SetRecurringResultParams(ref mResponseHashTable);
						}
						else
						{
							SetExpressCheckoutDOResultParams (ref mResponseHashTable);
							SetExpressCheckoutGETResultParams (ref mResponseHashTable);
							SetExpressCheckoutSETResultParams (ref mResponseHashTable);
							SetExpressCheckoutUPDATEResultParams (ref mResponseHashTable);
						}
						mResponseHashTable.Remove(PayflowConstants.INTL_PARAM_FULLRESPONSE);
						SetExtDataList();
						mResponseHashTable = null;
					}
					else
					{
						//Append the RESULT and RESPMSG for error code
						//E_UNKNOWN_STATE and create a message.
						//Call SetParams again on it.
						String ResponseValue = PayflowConstants.PARAM_RESULT 
											+  PayflowConstants.SEPARATOR_NVP
											+ (String)PayflowConstants.CommErrorCodes[PayflowConstants.E_UNKNOWN_STATE]
											+ PayflowConstants.DELIMITER_NVP
											+ PayflowConstants.PARAM_RESPMSG
											+  PayflowConstants.SEPARATOR_NVP
											+ (String)PayflowConstants.CommErrorMessages[PayflowConstants.E_UNKNOWN_STATE]
											+ ", " + mResponseString ;
						this.SetParams(ResponseValue);
					}
				}
				else
				{
					String AddlMessage = "Empty response";
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_WARN, false, AddlMessage);
					mContext.AddError(Err);
					Err = mContext.GetError(mContext.getErrorCount() - 1);
					String ResponseValue = Err.ToString();
					this.SetParams(ResponseValue);
				}

			}
			catch (BaseException BaseEx)
			{
				//ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE,BaseEx,PayflowConstants.SEVERITY_ERROR,false, null);
				ErrorObject Error = BaseEx.GetFirstErrorInExceptionContext();
				mContext.AddError(Error);
				String ResponseValue = Error.ToString();
				this.SetParams(ResponseValue);
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE,DEx,PayflowConstants.SEVERITY_ERROR,false,null);
				mContext.AddError(Error);
				String ResponseValue = Error.ToString();
				this.SetParams(ResponseValue);
			}
            //catch
            //{
            //    ErrorObject Error = PayflowUtility.PopulateCommError(PayflowConstants.E_UNKNOWN_STATE,null,PayflowConstants.SEVERITY_ERROR,false,null);
            //    mContext.AddError(Error);
            //    String ResponseValue = Error.ToString();
            //    this.SetParams(ResponseValue);
            //}
		}

		/// <summary>
		/// Sets the transaction result params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mTransactionResponse = new TransactionResponse();
				mTransactionResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}

		/// <summary>
		/// Sets fraud result params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetFraudResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mFraudResponse = new FraudResponse();
				mFraudResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}

		/// <summary>
		/// Sets recurring result params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetRecurringResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mRecurringResponse = new RecurringResponse();
				mRecurringResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}

		/// <summary>
		/// Sets the ExpressCheckout response for GET params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetExpressCheckoutGETResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mGetExpressCheckoutDetailsResponse = new ECGetResponse();
				mGetExpressCheckoutDetailsResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
			//catch
			//{
			//    throw new Exception();				
			//}
		}

		/// <summary>
		/// Sets the ExpressCheckout response for DO params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetExpressCheckoutDOResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mDoExpressCheckoutPaymentResponse  = new ECDoResponse();
				mDoExpressCheckoutPaymentResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
			//catch
			//{
			//    throw new Exception();				
			//}
		}

		/// <summary>
		/// Sets the ExpressCheckout response for SET params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetExpressCheckoutSETResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mSetExpressCheckoutPaymentResponse   = new ExpressCheckoutResponse();
				mSetExpressCheckoutPaymentResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
			//catch
			//{
			//    throw new Exception();				
			//}
		}

		/// <summary>
		/// Sets the ExpressCheckout response for UPDATE params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetExpressCheckoutUPDATEResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mUpdateExpressCheckoutPaymentResponse   = new ECUpdateResponse();
				mUpdateExpressCheckoutPaymentResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
			//catch
			//{
			//    throw new Exception();				
			//}
		}

		/// <summary>
		/// Sets buyer auth results params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetBuyerAuthResultParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mBuyerAuthResponse = new BuyerAuthResponse();
				mBuyerAuthResponse.SetParams(ref ResponseHashTable);
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
		}

		/// <summary>
		/// Parses response
		/// </summary>
		/// <param name="Response">Response string</param>
		private void ParseResponse(String Response)
		{
			//Pass a new context object to the validator. We do not mean to
			//validate request here. We just need to parse it and populate
			//the response hashtable.
			Context RespContext = new Context();
			//Check newly created context for fatal error. If the newly created
			//context has fatal error, it means that, there is a problem with the
			//message file. So we'll have manually assign the result,respmsg value.
			//Add following values in hashtable manually 
			//RESULT=<Code for E_UNKNOWN_STATE>
			//RESPMSG=<Message for E_UNKNOWN_STATE>, <Response String>
			if(RespContext.HighestErrorLvl == PayflowConstants.SEVERITY_FATAL)
			{
				
				String Result = PayflowUtility.LocateValueForName(Response,PayflowConstants.PARAM_RESULT,false);
				String RespMsg = PayflowUtility.LocateValueForName(Response,PayflowConstants.PARAM_RESPMSG,false);
				if (mResponseHashTable == null)
				{
					mResponseHashTable = new Hashtable();
				}
				
				mResponseHashTable.Add(PayflowConstants.INTL_PARAM_FULLRESPONSE, mResponseString);
				mResponseHashTable.Add(PayflowConstants.PARAM_RESULT ,Result);
				mResponseHashTable.Add(PayflowConstants.PARAM_RESPMSG,RespMsg);


			}
			else
			{
				mResponseHashTable = ParameterListValidator.ParseNVPList(Response, ref RespContext, true);
				RespContext = null;
				if (mResponseHashTable != null)
				{
					mResponseHashTable.Add(PayflowConstants.INTL_PARAM_FULLRESPONSE, Response);
				}
			}

		}

		/// <summary>
		/// Populates extended response
		/// array list
		/// </summary>
		private void SetExtDataList()
		{
			ExtendData ExtData = null;
			String Name;
			String Value;
			if (mResponseHashTable == null || mResponseHashTable.Count == 0)
			{
				mExtDataList = null;
			}
			else
			{
				mExtDataList = new ArrayList();
				foreach (DictionaryEntry ExtDataPair in mResponseHashTable)
				{
					Name = (String) ExtDataPair.Key;
					Value = (String) ExtDataPair.Value;
					//Separate the recurring inquiry response here
					int DuplicateKeyIndex = Name.IndexOf(PayflowConstants.TAG_DUPLICATE);
					if (DuplicateKeyIndex > 0)
					{
						Name = Name.Substring(0, DuplicateKeyIndex - 1);
					}
					if (Name.StartsWith(PayflowConstants.PREFIX_RECURRING_INQUIRY_RESP))
					{
						mRecurringResponse.InquiryParams.Add(Name, Value);
					}
					else
					{
						ExtData = new ExtendData(Name, Value);
						mExtDataList.Add(ExtData);
					}
					Name = null;
					Value = null;
					ExtData = null;
				}
			}
		}
		internal void setRequestString(string RequestString)
		{
			mRequestString = RequestString;
		}

		#endregion
	}

}