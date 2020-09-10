#region "Imports"
using System;
using System.Collections;
using PayPal.Payments.Common.Utility;
#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class is used to store the 
	/// Payflow Client related properties
	/// </summary>
	public sealed class ClientInfo : BaseRequestDataObject
	{
		private Hashtable mClientInfoHash = null;
		/// <summary>
		/// Constructor
		/// </summary>
		public ClientInfo()
		{
			mClientInfoHash = new Hashtable();
		}

		#region "Properties and getter, setter Methods"

		#region "Properties"
		/// <summary>
		/// Gets the client info hash table
		/// </summary>
		internal Hashtable ClientInfoHash
		{
			get { return mClientInfoHash;}
		}

		/// <summary>
		/// Gets client version
		/// </summary>
		/// <remarks>
		/// <para>Client version.</para>
		/// <para>Maps to HTTP Header:</para>
		/// <code>PAYFLOW-CLIENT-VERSION</code>
		/// </remarks>
		public String ClientVersion
		{
			get { return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_CLIENT_VERSION);}
		}
		/// <summary>
		/// Gets, sets OS architecture
		/// </summary>
		internal String OsArchitecture
		{
			get { return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_ARCHITECTURE);}
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_ARCHITECTURE, value); }
		}
		/// <summary>
		/// Gets, sets OS version
		/// </summary>
		internal String OsVersion
		{
			get{ return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_VERSION);}
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_VERSION, value); }
		}
		/// <summary>
		/// Gets, sets OS Name
		/// </summary>
		internal String OsName
		{
			get{ return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_OS_NAME);}
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_OS_NAME, value); }
		}
		/// <summary>
		/// Gets, sets Proxy
		/// </summary>
		internal String Proxy
		{
			get{ return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_PROXY);}
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_PROXY, value); }
		}
		/// <summary>
		/// Gets, sets runtime version
		/// </summary>
		internal String RunTimeVersion
		{
			get{ return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_RUNTIME_VERSION);}
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_RUNTIME_VERSION, value); }
		}
		/// <summary>
		/// Sets integration product
		/// </summary>
		/// <remarks>
		/// <para>Integration product.</para>
		/// <para>Maps to HTTP Header:</para>
		/// <code>PAYFLOW-INTEGRATION-PRODUCT</code>
		/// </remarks>
		public String IntegrationProduct
		{
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_PRODUCT, value); }
		}
		/// <summary>
		/// Sets integration version
		/// </summary>
		/// <remarks>
		/// <para>Integration product.</para>
		/// <para>Maps to HTTP Header:</para>
		/// <code>PAYFLOW-INTEGRATION-VERSION</code>
		/// </remarks>
		public String IntegrationVersion
		{
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_VERSION, value); }
		}
	
		/// <summary>
		/// Gets Client Type
		/// </summary>
		/// <remarks>
		/// <para>Client type.</para>
		/// <para>Maps to HTTP Header:</para>
		/// <code>PAYFLOW-CLIENT-TYPE</code>
		/// </remarks>
		public String ClientType
		{
			get { return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_CLIENT_TYPE);}
		}
		
		/// <summary>
		/// Sets Request Type
		/// </summary>
		/// <remarks>
		/// <para>Request type.</para>
		/// <para>Maps to HTTP Header:</para>
		/// <code>PAYFLOW-ASSEMBLY</code>
		/// </remarks>
		internal String RequestType
		{
			set { AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_ASSEMBLY, value);}
		}

		#endregion

		#region "Getters and setter"
		/// <summary>
		/// Sets client version
		/// </summary>
		/// <param name="Version">String value of client version</param>
		internal void SetClientVersion(String Version)
		{
			AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_CLIENT_VERSION, Version);
		}
		/// <summary>
		/// Gets integration product
		/// </summary>
		/// <returns>String value of integration product</returns>
		internal String GetIntegrationProduct()
		{
			return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_PRODUCT);
		}
		/// <summary>
		/// Gets integration version
		/// </summary>
		/// <returns>String value of integration version</returns>
		internal String GetIntegrationVersion()
		{
			return (String) GetHeaderFromHash(PayflowConstants.PAYFLOWHEADER_INTEGRATION_VERSION);
		}
		
		/// <summary>
		/// Sets client type
		/// </summary>
		/// <param name="ClientType">String value of Client Type</param>
		internal void SetClientType(String ClientType)
		{
				AddHeaderToHash(PayflowConstants.PAYFLOWHEADER_CLIENT_TYPE, ClientType);			
		}
		#endregion

		#endregion

		#region "Private and internal methods"
		/// <summary>
		/// Adds a header to the header hash table
		/// </summary>
		/// <param name="HeaderName">Header name</param>
		/// <param name="HeaderValue">Header value</param>
		internal void AddHeaderToHash(String HeaderName, Object HeaderValue)
		{
			// Null Header Names & Values are not allowed.
			// Empty Header Names are not allowed.
			if (HeaderName == null || HeaderName.Length == 0 ||HeaderValue == null)
			{
				return;
			}

			ClientInfoHeader CurrHeader
				= new ClientInfoHeader(HeaderName, HeaderValue);

			if (mClientInfoHash == null)
			{
				mClientInfoHash = new Hashtable();
			}

			if (mClientInfoHash.ContainsKey(HeaderName))
			{
				mClientInfoHash.Remove(HeaderName);
			}

			mClientInfoHash.Add(HeaderName, CurrHeader);
		}
		
		/// <summary>
		/// Gets a header value from hash
		/// </summary>
		/// <param name="HeaderName">Header name</param>
		/// <returns>Header value object</returns>
		internal Object GetHeaderFromHash(String HeaderName)
		{
			if (mClientInfoHash == null)
			{
				return null;
			}

			ClientInfoHeader CurrHeader = (ClientInfoHeader) mClientInfoHash[HeaderName];

			if (CurrHeader == null)
			{
				return null;
			}

			return CurrHeader.HeaderValue;


		}

		#endregion
	}
}