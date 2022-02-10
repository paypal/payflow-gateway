#region "Imports"

using System;
using System.Collections;
using PayPal.Payments.Common.Exceptions ;  
using PayPal.Payments.Common.Utility  ;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This  class serves as base class of all ExpressCheckout response classes.
	/// </summary>
	/// <remarks>
	/// <para>Each response object is associated with a particular type of expressCheckout operation.</para>
	/// <para>Following are the reponse objects associated with 
	/// different operations of ExpressChecout:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>ExpressCheckout operation.</term>
	/// <description>Request data object</description>
	/// </listheader>
	/// <item>
	/// <term>SET operation for ExpressCheckout.</term>
	/// <description>ExpressCheckoutResponse</description>
	/// </item>
	/// <item>
	/// <term>GET operation for ExpressCheckout.</term>
	/// <description><see cref="ECGetResponse">ECGetResponse</see></description>
	/// </item>
	/// <item>
	/// <term>DO operation for ExpressCheckout.</term>
	/// <description><see cref="ECDoResponse">ECDoResponse</see></description>
	/// </item>
	/// </list>
	/// </remarks>
	public class ExpressCheckoutResponse : BaseResponseDataObject
	{
		#region "Member Variable"
		private String mToken;
		#endregion

		#region "Constructor"
		/// <summary>
		/// constructor
		/// </summary>
		internal ExpressCheckoutResponse() 
		{
		}
		#endregion

		#region "Properties"
		/// <summary>
		/// Retuns the token for the transaction.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>TOKEN</code>
		/// </remarks>
		public String Token
		{
			get {return mToken;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Sets Response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal virtual void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mToken = (String) ResponseHashTable[PayflowConstants.PARAM_TOKEN ];
				ResponseHashTable.Remove(PayflowConstants.PARAM_TOKEN);
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

		#endregion

	}
}
