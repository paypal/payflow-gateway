#region "Imports"

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

#endregion

// This class is deprecated (was already marked so in VS2005) and exists only to allow QA testing
// against environments where the server certificate does not match the host URL.
// System.Net.ICertificatePolicy was removed in .NET 5+; the class is excluded from net8.0+ builds.
// To suppress certificate errors on modern .NET, use HttpClientHandler.ServerCertificateCustomValidationCallback
// or ServicePointManager.ServerCertificateValidationCallback (net48 only).
#if NET48

namespace PayPal.Payments.Common.Utility
{
	internal class LocalPolicy : System.Net.ICertificatePolicy
	{
		private Context mContext;
		private bool mIsXmlPayRequest;

		public LocalPolicy(ref Context CurrentContext, bool IsXmlPayRequest) : this()
		{
			mContext = CurrentContext;
			mIsXmlPayRequest = IsXmlPayRequest;
		}

		private LocalPolicy() { }

		public bool CheckValidationResult(ServicePoint ServicePoint, X509Certificate Cert,
		                                  WebRequest WebRequest, int ProblemCode)
		{
			return true;
		}
	}
}

#endif
