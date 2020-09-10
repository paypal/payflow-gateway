#region "Copyright"

//PayPal Payflow Pro .NET SDK
//Copyright (C) 2014  PayPal, Inc.
//
//This file is part of the Payflow Pro .NET SDK
//
//The Payflow .NET SDK is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//any later version.
//
//The Payflow .NET SDK is is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with the Payflow .NET SDK.  If not, see <http://www.gnu.org/licenses/>.


#endregion

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
