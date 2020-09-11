using System;

namespace PayPal.Payments.Common.Exceptions
{
	/// <summary>
	/// This Exception class will be used for handling the Protocol Exceptions.
	/// </summary>
	[Serializable()]
	internal  class ProtocolException : BaseException
	{
		#region "constructor"

		/// <summary>
		/// Constructor with Error object as a parameter.
		/// </summary>
		/// <param name="ErrObject" >ErrorObject which needs to be added to the exception.</param>
		internal ProtocolException(ErrorObject ErrObject) : base(ErrObject)
		{
		}

		/// <summary>
		/// Constructor with another exception as a parameter.
		/// </summary>
		/// <param name="Ex" >Exception which needs to be converted into 
		/// a ProtocolException type. </param>
		internal ProtocolException(Exception Ex) : base(Ex)
		{
		}

		#endregion
	} // END CLASS DEFINITION ProtocolException

} // Payments.Common.Exceptions