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