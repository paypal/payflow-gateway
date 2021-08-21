#region "Imports"

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Interface for all response data objects.
	/// </summary>
	/// <remarks>This interface can be used to create a new 
	/// response data object.</remarks>
	public interface IResponseDataObject
	{
		#region "Functions"

		/// <summary>
		/// Sets response params.
		/// </summary>
		/// <remarks>When implemented in the derived class, this method 
		/// should be preferred to be made as an internal method.</remarks>
		void SetParams();

		#endregion
	}

}