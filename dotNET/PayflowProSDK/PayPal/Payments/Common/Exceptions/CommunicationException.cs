using System;

namespace PayPal.Payments.Common.Exceptions
{
	/// <summary>
	/// This Exception class will be used for handling the Communication Exceptions.
	/// </summary>
	[Serializable()]
	internal  class CommunicationException : BaseException
	{
		#region "constructor"

		/// <summary>
		/// Constructor with Error object as a parameter.
		/// </summary>
		/// <param name="ErrObject" >ErrorObject which needs to be added to the exception.</param>
		internal CommunicationException(ErrorObject ErrObject) : base(ErrObject)
		{
		}

		/// <summary>
		/// Constructor with another exception as a parameter.
		/// </summary>
		/// <param name="Ex" >Exception which needs to be converted into a Communication 
		/// exception type. </param>
		internal CommunicationException(Exception Ex) : base(Ex)
		{
		}

		#endregion
	} // END CLASS DEFINITION CommunicationException

} // Payments.Common.Exceptions