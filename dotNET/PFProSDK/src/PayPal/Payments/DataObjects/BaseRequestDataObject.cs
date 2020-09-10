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

using PayPal.Payments.Common;
using System.Text;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Abstract base Class of all request data objects.
	/// </summary>
	/// <remarks>This class can be used to create a new request data 
	/// object.</remarks>
	public abstract class BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Static context
		/// </summary>
		private Context mContext;

		/// <summary>
		/// Static request buffer
		/// </summary>
		private StringBuilder mRequestBuffer;

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>Abstract class. Instance cannot be created directly.</remarks>
		protected BaseRequestDataObject()
		{
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets context
		/// </summary>
		internal virtual Context Context
		{
			get { return mContext; }
			set { mContext = value; }
		}

		/// <summary>
		/// Gets, Sets Requestbuffer
		/// </summary>
		internal virtual StringBuilder RequestBuffer
		{
			get { return mRequestBuffer; }
			set { mRequestBuffer = value; }
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal virtual void GenerateRequest()
		{
			// This function is not called. All the
			//address information is validated and generated
			//in its respective derived classes.

		}

		/// <summary>
		/// Resets the context
		/// </summary>
		/// <remarks>Not supported.</remarks>
		public static void ResetContext()
		{
		}

		#endregion
	}


}