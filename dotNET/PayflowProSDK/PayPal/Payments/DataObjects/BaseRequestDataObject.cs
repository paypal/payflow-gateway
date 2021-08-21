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