#region "Imports"

using System;
using PayPal.Payments.DataObjects;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// This class is used as base class for all reference transactions.
	/// </summary>
	/// <remarks>This class can be derived to create a new reference transaction 
	/// or can be used as is to submit a new type of reference transaction.
	/// <para>A reference transaction is a transaction which always takes
	///  the PNRef of a previously submitted transaction.</para>
	/// </remarks>
	public class ReferenceTransaction : BaseTransaction
	{
		#region "Member Variables"

		/// <summary>
		/// Original Transaction Id. Mandatory for any reference transaction.
		/// </summary>
		private String mOrigId;
		/// <summary>
		/// Original PayPal Transaction Id. 
		/// </summary>
		private String mOrigPpref;

		#endregion

		#region "Properties"
		/// <summary>
		/// Gets, Sets OrigPpref
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ORIGPPREF</code>
		/// </remarks>
		public String OrigPpref
		{
			get { return mOrigPpref;}
			set { mOrigPpref = value;}
		}
		#endregion

		#region "Constructors"

		/// <summary>
		/// protected Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		protected ReferenceTransaction()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(String TrxType, 
			String OrigId, 
			UserInfo UserInfo, 
			PayflowConnectionData PayflowConnectionData, 
			String RequestId) : base(TrxType, UserInfo, PayflowConnectionData, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(
			String TrxType, 
			String OrigId, 
			UserInfo UserInfo, 
			String RequestId) : base(TrxType, UserInfo,  RequestId)
		{
			mOrigId = OrigId;
		}


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(String TrxType, 
			String OrigId, 
			UserInfo UserInfo, 
			PayflowConnectionData PayflowConnectionData, 
			Invoice Invoice, String RequestId) : base(TrxType, UserInfo, PayflowConnectionData, Invoice, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(String TrxType, String OrigId, UserInfo UserInfo, Invoice Invoice, String RequestId) : this(TrxType, OrigId, UserInfo, null, Invoice, RequestId)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(String TrxType, 
			String OrigId, 
			UserInfo UserInfo, 
			PayflowConnectionData PayflowConnectionData, 
			Invoice Invoice, 
			BaseTender Tender, String RequestId) : base(TrxType, UserInfo, PayflowConnectionData, Invoice, Tender, RequestId)
		{
			mOrigId = OrigId;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="TrxType">Transaction Type</param>
		/// <param name="OrigId">Original Transaction Id.</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="Invoice">Invoice object.</param>
		/// <param name="Tender">Tender object.</param>
		/// <param name="RequestId">Request Id</param>
		/// <remarks>This class can be derived to create a new reference transaction 
		/// or can be used as is to submit a new type of reference transaction.
		/// <para>A reference transaction is a transaction which always takes
		///  the PNRef of a previously submitted transaction.</para>
		/// </remarks>
		public ReferenceTransaction(String TrxType, String OrigId, UserInfo UserInfo, Invoice Invoice, BaseTender Tender, String RequestId) : this(TrxType, OrigId, UserInfo, null, Invoice, Tender, RequestId)
		{
		}

		#endregion


		

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				base.GenerateRequest();
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORIGID, mOrigId));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ORIGPPREF, mOrigPpref));

			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TEx = new TransactionException(Ex);
				throw TEx;
			}
		}

		#endregion

	}

}