#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Browser related information.
	/// </summary>
	/// <remarks>Use the BrowserInfo object for the user
	/// browser related information.</remarks>
	/// <example>
	/// <para>Following example shows how to use a 
	/// Browser Info object.</para>
	/// <code lang="C#" escaped="false">
	///	.................
	///	// Inv is the Invoice object
	///	.................
	///	// Set the Browser Info details.
	///	BrowserInfo Browser = New BrowserInfo();
	///	Browser.BrowserCountryCode = "USA";
	///	Browser.BrowserUserAgent = "IE 6.0";
	///	Inv.BrowserInfo = Browser;
	///	.................
	///	</code>
	/// <code lang="Visual Basic" escaped="false">
	///	.................
	///	' Inv is the Invoice object
	///	.................
	///	' Set the Browser Info details.
	///	Dim Browser As BrowserInfo = New BrowserInfo
	///	Browser.BrowserCountryCode  = "USA"
	///	Browser.BrowserUserAgent = "IE 6.0"
	///	Inv.BrowserInfo = Browser
	///	.................
	///	</code>
	/// </example>
	public sealed class BrowserInfo : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Holds Browser time.
		/// </summary>
		private String mBrowserTime;
		/// <summary>
		/// Holds Browser Country code.
		/// </summary>
		private String mBrowserCountryCode;
		/// <summary>
		/// Holds Browser User Agent
		/// </summary>
		private String mBrowserUserAgent;
		/// <summary>
		/// Holds Buttonsource
		/// </summary>
		private String mButtonSource;
		/// <summary>
		/// Holds notify url
		/// </summary>
		private String mNotifyURL;
		/// <summary>
		/// Holds custom
		/// </summary>
		private String mCustom;
		/// <summary>
		/// Holds merchant session id
		/// </summary>
		private String mMerchantSessionId;
		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for BrowserInfo
		/// </summary>
		/// <remarks>Use the BrowserInfo object for the user
		/// browser related information.</remarks>
		/// <example>
		/// <para>Following example shows how to use a 
		/// Browser Info object.</para>
		/// <code lang="C#" escaped="false">
		///	.................
		///	// Inv is the Invoice object
		///	.................
		///	// Set the Browser Info details.
		///	BrowserInfo Browser = New BrowserInfo();
		///	Browser.BrowserCountryCode = "USA";
		///	Browser.BrowserUserAgent = "IE 6.0";
		///	Inv.BrowserInfo = Browser;
		///	.................
		///	</code>
		/// <code lang="Visual Basic" escaped="false">
		///	.................
		///	' Inv is the Invoice object
		///	.................
		///	' Set the Browser Info details.
		///	Dim Browser As BrowserInfo = New BrowserInfo
		///	Browser.BrowserCountryCode  = "USA"
		///	Browser.BrowserUserAgent = "IE 6.0"
		///	Inv.BrowserInfo = Browser
		///	.................
		///	</code>
		/// </example>
		public BrowserInfo()
		{
		}

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Browser time.
		/// </summary>
		/// <remarks>
		/// <para>Browser's local time.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BROWSERTIME</code>
		/// </remarks>
		public String BrowserTime
		{
			get { return mBrowserTime; }
			set { mBrowserTime = value; }
		}

		/// <summary>
		/// Gets, Sets Browser Country code.
		/// </summary>
		/// <remarks>
		/// <para>Browser's local Country Code.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BROWSERCOUNTRYCODE</code>
		/// </remarks>
		public String BrowserCountryCode
		{
			get { return mBrowserCountryCode; }
			set { mBrowserCountryCode = value; }
		}

		/// <summary>
		/// Gets, Sets Browser user agent.
		/// </summary>
		/// <remarks>
		/// <para>Browser's user agent.</para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BROWSERUSERAGENT</code>
		/// </remarks>
		public String BrowserUserAgent
		{
			get { return mBrowserUserAgent; }
			set { mBrowserUserAgent = value; }
		}

		/// <summary>
		/// Gets or Sets the custom parameter for Direct Payment and Express checkout.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CUSTOM</code>
		/// </remarks>
		public String Custom
		{
			get{return mCustom; }
			set{mCustom= value;}
		}

		/// <summary>
		/// Gets or Sets the buttonsource parameter for Direct Payment and Express checkout.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>BUTTONSOURCE</code>
		/// </remarks>
		public String ButtonSource
		{
			get{return mButtonSource; }
			set{mButtonSource = value;}
		}

		/// <summary>
		/// Gets or Sets the NotifyUrl parameter for Direct Payment and Express checkout.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>NOTIFYURL</code>
		/// </remarks>
		public String NotifyURL
		{
			get{return mNotifyURL; }
			set{mNotifyURL = value;}
		}
		/// <summary>
		/// Gets or Sets the MerchantSessionId parameter for Direct Payment.
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>MERCHANTSESSIONID</code>
		/// </remarks>
		public String MerchantSessionId
		{
			get{return mMerchantSessionId; }
			set{mMerchantSessionId = value;}
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BROWSERTIME, mBrowserTime));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BROWSERCOUNTRYCODE, mBrowserCountryCode));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BROWSERUSERAGENT, mBrowserUserAgent));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CUSTOM, mCustom));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_BUTTONSOURCE, mButtonSource));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_NOTIFYURL, mNotifyURL));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MERCHANTSESSIONID, mMerchantSessionId));
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				DataObjectException DEx = new DataObjectException(Ex);
				throw DEx;
			}
            //catch
            //{
            //    throw new Exception();				
            //}
            }
        		#endregion
	}
}