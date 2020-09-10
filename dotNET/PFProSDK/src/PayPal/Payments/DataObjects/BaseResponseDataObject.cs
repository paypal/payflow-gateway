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

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Abstract base Class of all response data objects.
	/// </summary>
	/// <remarks>This class can be used to create a new response data 
	/// object.</remarks>
	public class BaseResponseDataObject
	{
		#region "Core Functions"

		/// <summary>
		/// Sets the Response params in
		/// response data objects.
		/// </summary>
		/// <param name="Response">Response String</param>
		internal virtual void SetParams(String Response)
		{
		}

		#endregion
	}

}