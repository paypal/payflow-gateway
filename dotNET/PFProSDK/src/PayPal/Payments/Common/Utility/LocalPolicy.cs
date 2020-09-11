#region "Imports"

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

#endregion

namespace PayPal.Payments.Common.Utility
{
	/// <summary>
	/// Custom class to define custom security
	/// policy for SSL server certificates.
	/// </summary>
	
	// This class is deprecated in VS2005 and is only here to allow testing of .NET SDK in the 
	// QA environment where the certificate does not match the host URL.  If you do not uncomment the line listed
	// below you will receive an exception of "The underlying connection was closed: Could not establish trust
	// relationship with remote server."
	// 
	// The line to uncomment can be found in PaymentConnection.cs within the SendToServer function and is:
	//
	// System.Net.ServicePointManager.CertificatePolicy = new LocalPolicy(ref mContext,IsXmlPayRequest);
	// 
	// IMPORTANT: Make sure to comment the line prior to creating a build for release.
	
	internal class LocalPolicy : System.Net.ICertificatePolicy
	{

		#region "Member Variables"
		/// <summary>
		/// Context object
		/// </summary>
		private Context mContext;
		/// <summary>
		/// Flag to indicate whether NVP or
		/// XML Pay request
		/// </summary>
		private bool mIsXmlPayRequest;
		#endregion
		
		#region "Constructors"
		/// <summary>
		/// Constructor
		/// </summary>
		public LocalPolicy(ref Context CurrentContext, bool IsXmlPayRequest) : this()
		{
			mContext = CurrentContext;
			mIsXmlPayRequest = IsXmlPayRequest;
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		private LocalPolicy()
		{
		}

		#endregion

		#region "Functions"
		/// <summary>
		/// This overridden method is called by the 
		/// runtime after the server cert is validated
		/// </summary>
		/// <param name="ServicePoint">Current Service point of the request</param>
		/// <param name="Cert">Certificate</param>
		/// <param name="WebRequest">Web request</param>
		/// <param name="ProblemCode">Problem Code</param>
		/// <returns>True if certificate is valid, false otherwise</returns>
		public bool CheckValidationResult(ServicePoint ServicePoint, X509Certificate Cert,
		                                  WebRequest WebRequest, int ProblemCode)
		{
			return true;
		
		}

		#endregion
	}

}