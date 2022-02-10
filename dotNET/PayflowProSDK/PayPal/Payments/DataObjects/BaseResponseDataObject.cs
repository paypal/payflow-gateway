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