using System;

namespace PayPal.Payments.Common.Exceptions
{
	/// <summary>
	/// This Exception class will be used for handling the Transaction Exceptions.
	/// </summary>
	[Serializable()]
	internal  class TransactionException : BaseException
	{
		#region "constructor"

		/// <summary>
		/// Constructor with Error object as a parameter.
		/// </summary>
		/// <param name="ErrObject" >ErrorObject which needs to be added to the exception.</param>
		internal TransactionException(ErrorObject ErrObject) : base(ErrObject)
		{
		}

		/// <summary>
		/// Constructor with another exception as a parameter.
		/// </summary>
		/// <param name="Ex" >Exception which needs to be converted into 
		/// a GeneralException type. </param>
		internal TransactionException(Exception Ex) : base(Ex)
		{
		}

		#endregion
	} // END CLASS DEFINITION TransactionException

} // Payments.Common.Exceptions