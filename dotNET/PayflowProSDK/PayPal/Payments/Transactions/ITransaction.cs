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