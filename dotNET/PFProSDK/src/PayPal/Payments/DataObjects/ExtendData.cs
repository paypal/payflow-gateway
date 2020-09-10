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
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Extended param information
	/// </summary>
	/// <remarks>Extended data are the Payflow parameters which are 
	/// not mapped through the data objects. 
	/// This class can be used to send such extended parameter information 
	/// in the transaction request.</remarks>
	/// <example>
	/// Following example shows how to use this class.
	/// <code lang="C#" escaped="false">
	///		.............
	///		// Trans is the transaction object.
	///		.............
	///		
	///		// Set the extended data value.
	///		ExtendData ExtData = new ExtendData("PAYFLOW_PARAM_NAME","Param Value");
	///		
	///		// Add extended data to transaction.
	///		Trans.AddToExtendData(ExtData);
	///		
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///		.............
	///		' Trans is the transaction object.
	///		.............
	///		
	///		' Set the extended data value.
	///		Dim ExtData As ExtendData  = new ExtendData("PAYFLOW_PARAM_NAME","Param Value")
	///		
	///		' Add extended data to transaction.
	///		Trans.AddToExtendData(ExtData)
	///		
	/// </code>
	/// </example>
	public sealed class ExtendData : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Payflow Param name
		/// </summary>
		private String mParamName;

		/// <summary>
		/// Param value
		/// </summary>
		private String mParamValue;

		#endregion

		#region Properties"
		/// <summary>
		/// ParamName
		/// </summary>
		public String ParamName 
		{
			get { return(mParamName); }
		}

		/// <summary>
		/// ParamValue
		/// </summary>
		public String ParamValue
		{
			get { return(mParamValue); }
		}

		#endregion
		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="ParamName">Payflow pram name</param>
		/// <param name="ParamValue">param value</param>
		/// <remarks>Extended data are the Payflow parameters which are 
		/// not mapped through the data objects. 
		/// This class can be used to send such extended parameter information 
		/// in the transaction request.</remarks>
		/// <example>
		/// Following example shows how to use this class.
		/// <code lang="C#" escaped="false">
		///		.............
		///		// Trans is the transaction object.
		///		.............
		///		
		///		// Set the extended data value.
		///		ExtendData ExtData = new ExtendData("PFPRO_PARAM_NAME","Param Value");
		///		
		///		// Add extended data to transaction.
		///		Trans.AddToExtendData(ExtData);
		///		
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		' Trans is the transaction object.
		///		.............
		///		
		///		' Set the extended data value.
		///		Dim ExtData As ExtendData  = new ExtendData("PFPRO_PARAM_NAME","Param Value")
		///		
		///		' Add extended data to transaction.
		///		Trans.AddToExtendData(ExtData)
		///		
		/// </code>
		/// </example>
		public ExtendData(String ParamName, String ParamValue)
		{
			mParamName = ParamName;
			mParamValue = ParamValue;
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(mParamName, mParamValue));
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