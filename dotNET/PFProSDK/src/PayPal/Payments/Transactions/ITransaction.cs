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

#endregion

namespace PayPal.Payments.Transactions
{
	/// <summary>
	/// Base Interface for all the transaction objects.
	/// </summary>
	/// <remarks>This interface cane be implemented to create a new 
	/// transaction type.</remarks>
	public interface ITransaction
	{
		/// <summary>
		/// Submits the transaction to the Payflow server
		/// and populates the response object.
		/// </summary>
		/// <remarks>When implemented in the derived class, this method 
		/// should be preferred to be made as an internal method.</remarks>
		/// <returns>true if successful, false otherwise.</returns>
		bool SubmitTransaction();

		/// <summary>
		/// generates the request.
		/// </summary>
		/// <remarks>When implemented in the derived class, this method 
		/// should be preferred to be made as an internal method.</remarks>
		void GenerateRequest();

	} 

} 