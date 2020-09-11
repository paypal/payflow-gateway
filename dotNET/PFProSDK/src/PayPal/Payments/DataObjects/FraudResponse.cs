#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;
using PayPal.Payments.Common;
using System.Collections;
using System.Xml;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Container class for response messages 
	/// specific Fraud Protections Services
	/// </summary>
	/// <remarks>This class contains the fraud protection 
	/// services related response messages and data objects parsed 
	/// from the xml data in the fraud response.
	/// <seealso cref="FpsXmlData"/>
	/// </remarks>
	public sealed class FraudResponse : BaseResponseDataObject
	{
		/// <summary>
		/// Holds PreFpsMsg
		/// </summary>
		private String mPreFpsMsg;

		/// <summary>
		/// Holds PostFpsMsg
		/// </summary>
		private String mPostFpsMsg;

		/// <summary>
		/// Holds Fps Pre Xml Data
		/// </summary>
		private FpsXmlData mFpsPreXmlData;

		/// <summary>
		/// Holds Fps Post Xml Data
		/// </summary>
		private FpsXmlData mFpsPostXmlData;

		#region "Constructors"

		/// <summary>
		/// Constructor for Fraud response.
		/// </summary>
		internal FraudResponse ()
		{

		}


		#endregion

		#region "Properties"

		
		/// <summary>
		/// Gets, Sets  PreFpsMsg
		/// </summary>
		/// <remarks>
		/// Gets the FPS Pre FPS message.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>PREFPSMSG</code>
		/// </remarks>
		public String PreFpsMsg
		{
			get { return mPreFpsMsg; }
		}

		/// <summary>
		/// Gets, Sets  PostFpsMsg
		/// </summary>
		/// <remarks>
		/// Gets the FPS Post FPS message.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>POSTFPSMSG</code>
		/// </remarks>
		public String PostFpsMsg
		{
			get { return mPostFpsMsg; }
		}		

		/// <summary>
		/// Gets, Sets  Fps_PreXmlData
		/// </summary>
		/// <remarks>
		/// Gets the FPS Pre Xml data message populated in
		/// FpsXmlData object.
		/// Its an itemized list of responses for trigerred filters
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FPS_PREXMLDATA</code>
		/// <seealso cref="FpsXmlData"/>
		/// </remarks>
		public FpsXmlData Fps_PreXmlData
		{
			get { return mFpsPreXmlData; }
		}

		/// <summary>
		/// Gets, Sets  Fps_PostXmlData
		/// </summary>
		/// <remarks>
		/// Gets the FPS Post Xml data message populated in
		/// FpsXmlData object.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>FPS_POSTXMLDATA</code>
		/// <seealso cref="FpsXmlData"/>
		/// </remarks>
		public FpsXmlData Fps_PostXmlData
		{
			get { return mFpsPostXmlData; }
		}

		#endregion

		#region "Functions"

		/// <summary>
		/// Sets the Response params in
		/// response data objects.
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		internal void SetParams(ref Hashtable ResponseHashTable)
		{
			try
			{
				
				mPreFpsMsg = (String) ResponseHashTable[PayflowConstants.PARAM_PREFPSMSG];
				mPostFpsMsg = (String) ResponseHashTable[PayflowConstants.PARAM_POSTFPSMSG];
				
				
				ResponseHashTable.Remove(PayflowConstants.PARAM_PREFPSMSG);
				ResponseHashTable.Remove(PayflowConstants.PARAM_POSTFPSMSG);
				
				SetFpsXmlData(ref ResponseHashTable);
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

		/// <summary>
		/// Sets the Fps Xml data
		/// </summary>
		///<param name="ResponseHashTable">Response Hash table by ref</param>
		private void SetFpsXmlData(ref Hashtable ResponseHashTable)
		{
			String XmlData = null;
			try
			{
				XmlData = (String) ResponseHashTable[PayflowConstants.PARAM_FPS_PREXMLDATA];
				mFpsPreXmlData = SetRules(XmlData);
				XmlData = (String) ResponseHashTable[PayflowConstants.PARAM_FPS_POSTXMLDATA];
				mFpsPostXmlData = SetRules(XmlData);
				ResponseHashTable.Remove(PayflowConstants.PARAM_FPS_PREXMLDATA);
				ResponseHashTable.Remove(PayflowConstants.PARAM_FPS_POSTXMLDATA);
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

		/// <summary>
		/// Sets the FPS rules applied.
		/// </summary>
		/// <param name="XmlData">Xml String</param>
		/// <returns>FPS Xml Data object</returns>
		private FpsXmlData SetRules(String XmlData)
		{
			try
			{
				FpsXmlData FpsData = new FpsXmlData();
				if (XmlData != null && XmlData.Length > 0)
				{
					ArrayList RuleList = null;

					RuleList = ParseXmlData(XmlData);
					if (RuleList != null && RuleList.Count > 0)
					{
						FpsData.SetRuleList(RuleList);
					}

				}
				return FpsData;
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

		/// <summary>
		/// Parses FPS Xml String Data
		/// </summary>
		/// <param name="XmlData">Xml String Data</param>
		/// <returns>Rulelist</returns>
		private ArrayList ParseXmlData(String XmlData)
		{
			try
			{
				ArrayList RuleList = new ArrayList();
				XmlDocument FpsXmlRules = new XmlDocument();
				FpsXmlRules.LoadXml(XmlData);
				XmlNodeList RuleNodeList = FpsXmlRules.GetElementsByTagName(PayflowConstants.XML_PARAM_RULE);
				if (RuleNodeList != null && RuleNodeList.Count > 0)
				{
					foreach (XmlNode RuleNode in RuleNodeList)
					{
						String TempValue;
						Rule FraudRule = new Rule();
						TempValue = RuleNode.Attributes.GetNamedItem(PayflowConstants.XML_PARAM_NUM).Value;
						if (TempValue != null)
						{
							FraudRule.Num = Int32.Parse(TempValue);
						}
						FraudRule.RuleId = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_RULEID).InnerText;
						FraudRule.RuleAlias = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_RULEALIAS).InnerText;
						FraudRule.RuleDescription = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_RULEDESCRIPTION).InnerText;
						FraudRule.Action = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_ACTION).InnerText;
						FraudRule.TriggeredMessage = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_TRIGGEREDMESSAGE).InnerText;
						XmlNode RuleVendorParamNode = RuleNode.SelectSingleNode(PayflowConstants.XML_PARAM_RULEVENDORPARMS);
						if (RuleVendorParamNode != null)
						{
							XmlNodeList RuleParamList = RuleVendorParamNode.SelectNodes(PayflowConstants.XML_PARAM_RULEPARAMETER);
							if (RuleParamList != null)
							{
								foreach (XmlNode RuleParamNode in RuleParamList)
								{
									RuleParameter RuleParam = new RuleParameter();
									String TempValue1;
									TempValue1 = RuleParamNode.Attributes.GetNamedItem(PayflowConstants.XML_PARAM_NUM).Value;
									if (TempValue1 != null)
										RuleParam.Num = Int32.Parse(TempValue);
									RuleParam.Name = RuleParamNode.SelectSingleNode(PayflowConstants.XML_PARAM_NAME).InnerText;
									RuleParam.Type = RuleParamNode.SelectSingleNode(PayflowConstants.XML_PARAM_VALUE).Attributes.GetNamedItem(PayflowConstants.XML_PARAM_TYPE).Value;
									RuleParam.Value = RuleParamNode.SelectSingleNode(PayflowConstants.XML_PARAM_VALUE).InnerText;
									FraudRule.RuleVendorParms.Add(RuleParam);
								}
							}
						}
						RuleList.Add(FraudRule);
					}
				}

				return RuleList;
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				ErrorObject Error = new PayPal.Payments.Common.ErrorObject("Error While parsing XmlData", Ex.Message);
				DataObjectException DEx = new DataObjectException(Error);
				throw DEx;
			}
			//catch
			//{
			//    ErrorObject Error = new PayPal.Payments.Common.ErrorObject("Error While parsing XmlData", "");
			//    DataObjectException DEx = new DataObjectException(Error);
			//    throw DEx;
			//}
		}

		#endregion
	}

}