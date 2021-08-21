

#region "Imports"

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Interface for all request data objects.
	/// </summary>
	/// <remarks>This interface can be used to create a new 
	/// request data object.</remarks>
	public interface IRequestDataObject
	{
		#region "Functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		/// <remarks>When implemented in the derived class, this method 
		/// should be preferred to be made as an internal method.</remarks>
		void GenerateRequest();

		#endregion
	}

}