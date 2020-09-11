#region "Imports"

using System;
using System.Collections ;
using PayPal.Payments.Common.Exceptions ; 
using PayPal.Payments.Common.Utility ; 

#endregion


namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for ExpressCheckout Update operation.
	/// </summary>
	/// <remarks>
	/// <seealso cref="ExpressCheckoutResponse"/>
	/// </remarks>	
	public class ECUpdateResponse : ExpressCheckoutResponse
	{
		#region "Member variable"

		private String mBA_Status;
		private String mBA_Desc;

		#endregion

		#region "Constructor"
		/// <summary>
		/// constructor
		/// </summary>
		internal ECUpdateResponse() : base()
		{
		}
		#endregion

		#region "Properties"
		/// <summary>
		/// Gets the BA_STATUS parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_STATUS</code>
		/// </remarks>
		public String BA_Status
		{
			get {return mBA_Status;}
		}
		/// <summary>
		/// Gets the BA_DESC parameter
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BA_DESC</code>
		/// </remarks>
		public String BA_Desc
		{
			get {return mBA_Desc;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Sets Response params
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal override void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				mBA_Status = (String) ResponseHashTable[PayflowConstants.PARAM_BA_STATUS];
				mBA_Desc = (String) ResponseHashTable[PayflowConstants.PARAM_BA_DESC];
	
				ResponseHashTable.Remove(PayflowConstants.PARAM_BA_STATUS);
				ResponseHashTable.Remove(PayflowConstants.PARAM_BA_DESC);
				  
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
