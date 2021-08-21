#region "Imports"
using System;
using PayPal.Payments.DataObjects;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class is used to store the complete information 
	/// about a client information header.
	/// </summary>
	internal sealed class ClientInfoHeader : BaseRequestDataObject
	{
		/// <summary>
		/// Stores Header name
		/// </summary>
		private String mHeaderName;
		/// <summary>
		/// Stores Header value
		/// </summary>
		private Object mHeaderValue;
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="HeaderName">Header name</param>
		/// <param name="HeaderValue">Header value</param>
		internal ClientInfoHeader(String HeaderName,Object HeaderValue)
		{
			mHeaderName = HeaderName;
			mHeaderValue = HeaderValue;
		}
		
		/// <summary>
		/// Gets header name
		/// </summary>
		internal String HeaderName
		{
			get { return mHeaderName; }
		}
		/// <summary>
		/// Gets header value
		/// </summary>
		internal Object HeaderValue
		{
			get { return mHeaderValue; }
		}
	}
}
