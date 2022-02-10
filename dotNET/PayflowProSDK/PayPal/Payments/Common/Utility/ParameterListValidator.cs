#region "Imports"

using System;
using System.Xml;
using System.Collections;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.Common.Utility
{
	/// <summary>
	/// Parameter List Validator Class.
	/// </summary>
	internal sealed class ParameterListValidator
	{
		#region "Private Constructor"

		/// <summary>
		/// private Constructor.
		/// </summary>
		private ParameterListValidator()
		{
		}

		#endregion

		#region "Validator functions"

		/// <summary>
		/// Validates the parameter list.
		/// </summary>
		/// <param name="ParamList">Parameter List</param>
		/// <param name="IsXmlPayReq">true if Request is XmlPay, false otherwise.</param>
		/// <param name="CurrentContext">Context object by reference.</param>
		public static void Validate(String ParamList, bool IsXmlPayReq, ref Context CurrentContext)
		{
			Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.Validate(String,bool,String,String,ref Context): Entered", PayflowConstants.SEVERITY_DEBUG);
			try
			{
				if (IsXmlPayReq)
				{
					XmlDocument XmlPayReq = new XmlDocument();
					XmlPayReq.LoadXml(ParamList);
				}
				else
				{
					if (ParamList != null && ParamList.Length > 0)
					{
						ParseNVPList(ParamList, ref CurrentContext, false);
					}
				}

			}
			catch (Exception Ex)
			{
				ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_INVALID_NVP, Ex, PayflowConstants.SEVERITY_FATAL, IsXmlPayReq, null);
				if (!CurrentContext.IsCommunicationErrorContained(Err))
				{
					CurrentContext.AddError(Err);
				}

			}
            //catch 
            //{
            //    ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_INVALID_NVP, null, PayflowConstants.SEVERITY_FATAL, IsXmlPayReq, null);
            //    if (!CurrentContext.IsCommunicationErrorContained(Err))
            //    {
            //        CurrentContext.AddError(Err);
            //    }

            //}
			finally
			{
				Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.Validate(String,bool,String,String,ref Context): Exiting", PayflowConstants.SEVERITY_DEBUG);
			}
		}

		/// <summary>
		/// Validates Name Value Pair Request.
		/// </summary>
		/// <param name="ParamList">Name Value Param List.</param>
		/// <param name="CurrentContext">Context object by reference.</param>
		/// <param name="PopulateResponseHashTable">True will populate the return hashtable, false will just parse the request and check for validity</param>
		/// <returns>Name value hash table</returns>
		public static Hashtable ParseNVPList(String ParamList, ref Context CurrentContext, bool PopulateResponseHashTable)
		{
			Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.ParseNVPList(String,String,String,ref context,bool): Entered", PayflowConstants.SEVERITY_DEBUG);
			long ParamListLen = ParamList.Length;
			int index = 0;
			bool OpenBracket = false;
			bool CloseBracket = false;
			String AddlMessage;
			ErrorObject Err;
			Hashtable ParamListHashTable = new Hashtable();
			if (ParamList == null || ParamList.Length <= 0)
			{
				Err = PayflowUtility.PopulateCommError(PayflowConstants.E_EMPTY_PARAM_LIST, null, PayflowConstants.SEVERITY_FATAL, false, null);
				CurrentContext.AddError(Err);
			}

			while (index < ParamListLen && CurrentContext.HighestErrorLvl < PayflowConstants.SEVERITY_FATAL)
			{
				long NameBuffSize = 1000;
				long ValBuffSize = 1000;
				long LenBuffSize = 1000;
				char[] NameBuffer = new char[NameBuffSize];
				char[] LenValueBuffer = new char[LenBuffSize];
				char[] ValueBuffer = new char[ValBuffSize];
				char[] TempArray = null;
				int LenIndex = 0;
				int NameIndex = 0;

				while (index < ParamListLen && ParamList[index] != '\0' && ParamList[index] != '=')
				{
					if (ParamList[index] == '[')
					{
						if (OpenBracket)
						{
							AddlMessage = "Found unmatched '[' followed by another '[' at index  " + (index + 1).ToString();
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							break;
						}
						OpenBracket = true;
						index++;
						continue;
					}
					if (ParamList[index] == ']')
					{
						if (!OpenBracket)
						{
							AddlMessage = "Unmatched ']' at index " + (index + 1).ToString();
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							break;
						}
						else if ((index + 1) < ParamListLen && ParamList[index + 1] != '=')
						{
							AddlMessage = "']' is not followed by '=' in param list at index " + (index + 1).ToString();
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							break;
						}
						else if ((index + 1) < ParamListLen && ParamList[index - 1] == '[')
						{
							AddlMessage = "Length of value not found in '[]' at index " + (index + 1).ToString();
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							break;
						}
						else
						{
							if (CloseBracket)
							{
								AddlMessage = "Found unmatched ']' followed by another ']' at index  " + (index + 1).ToString();
								Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
								if (!CurrentContext.IsCommunicationErrorContained(Err))
								{
									CurrentContext.AddError(Err);
								}
								break;
							}
							index++;
							CloseBracket = true;
							continue;
						}
					}

					if (OpenBracket && !CloseBracket)
					{
						//increase the size of LenValueBuffer if required
						if (LenIndex >= LenBuffSize)
						{
							LenBuffSize += 2000;
							TempArray = new char[LenBuffSize];
							System.Array.Copy(LenValueBuffer, TempArray, LenValueBuffer.LongLength);
							LenValueBuffer = TempArray;
						}
						LenValueBuffer[LenIndex] = ParamList[index];
						LenIndex++;
						index++;
						continue;
					}
					else
					{
						//increase the size of NameBuffer if required
						if (NameIndex >= NameBuffSize)
						{
							NameBuffSize += 2000;
							TempArray = new char[NameBuffSize];
							System.Array.Copy(NameBuffer, TempArray, NameBuffer.LongLength);
							NameBuffer = TempArray;
						}
						NameBuffer[NameIndex] = ParamList[index];
						if (NameBuffer[NameIndex] == '&')
						{
							AddlMessage = new string(NameBuffer);
							AddlMessage = AddlMessage.Trim('\0');
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
						}
						index++;
						NameIndex++;
						continue;
					}
				}
				//skip '='
				if (index < ParamListLen && ParamList[index] != '\0')
				{
					index++;
				}

				if (OpenBracket && !CloseBracket)
				{
					AddlMessage = "Unmatched '[' at index " + (index + 1).ToString();
					Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
					if (!CurrentContext.IsCommunicationErrorContained(Err))
					{
						CurrentContext.AddError(Err);
					}
					break;
				}

				/*if(OpenBracket && CloseBracket && LenValueBuffer != null && LenValueBuffer.Length > 0 && LenValueBuffer[0] == '0')
				{
					String Len = new string(LenValueBuffer).Trim('\0');
					AddlMessage = "Invalid param length = " + Len;
					Err =  PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN,null,PayflowConstants.SEVERITY_FATAL,false,AddlMessage);
					if(!CurrentContext.IsCommunicationErrorContained(Err))
					{
						CurrentContext.AddError(Err);
					}
					break;
					
				}*/

				if (OpenBracket && CloseBracket && LenValueBuffer != null && LenValueBuffer.Length > 0 && LenValueBuffer[0] == '-')
				{
					String Len = new string(LenValueBuffer).Trim('\0');
					AddlMessage = "Invalid param length = " + Len;
					Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
					if (!CurrentContext.IsCommunicationErrorContained(Err))
					{
						CurrentContext.AddError(Err);
					}
					break;

				}

				int ValIndex = 0;
				while (index < ParamListLen && ParamList[index] != '\0' && CurrentContext.HighestErrorLvl < PayflowConstants.SEVERITY_FATAL)
				{
					if (LenValueBuffer != null && LenValueBuffer.Length > 0 && LenValueBuffer[0] != '\0')
					{
						String LenString = new String(LenValueBuffer);
						LenString = LenString.Trim();
						int Len;
						try
						{
							Len = Int32.Parse(LenString);
						}
						catch (Exception Ex)
						{
							String Name = new string(NameBuffer).Trim('\0');
							AddlMessage = "Value in [] is not numeric data, data in '[]' =  " + LenString.Trim('\0') + "for Name = " + Name;
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, Ex, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							break;
						}
                        //catch 
                        //{
                        //    String Name = new string(NameBuffer).Trim('\0');
                        //    AddlMessage = "Value in [] is not numeric data, data in '[]' =  " + LenString.Trim('\0') + "for Name = " + Name;
                        //    Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
                        //    if (!CurrentContext.IsCommunicationErrorContained(Err))
                        //    {
                        //        CurrentContext.AddError(Err);
                        //    }
                        //    break;
                        //}

						int AmpIndex = index + Len;
						if (AmpIndex < ParamListLen && ParamList[AmpIndex] != '&')
						{
							String Name = new string(NameBuffer).Trim('\0');
							AddlMessage = "Param length in '[]' does not match actual value length.Param Name = " + Name;
							Err = PayflowUtility.PopulateCommError(PayflowConstants.E_PARM_NAME_LEN, null, PayflowConstants.SEVERITY_FATAL, false, AddlMessage);
							if (!CurrentContext.IsCommunicationErrorContained(Err))
							{
								CurrentContext.AddError(Err);
							}
							index += Len + 1;
							break;
						}
						else
						{
							//increase the size of ValueBuffer if required
							if (Len >= ValBuffSize)
							{
								ValBuffSize += Len + 2000;
								ValueBuffer = new char[ValBuffSize];
							}
							int ValueIndex;
							for (ValueIndex = 0; ValueIndex < Len && index + ValueIndex < ParamListLen; ValueIndex++)
							{
								ValueBuffer[ValueIndex] = ParamList[index + ValueIndex];
							}
							index += Len + 1;
							break;
						}
					}
					else
					{
						//increase the size of NameBuffer if required
						if (ValIndex >= ValBuffSize)
						{
							ValBuffSize += 2000;
							TempArray = new char[ValBuffSize];
							System.Array.Copy(ValueBuffer, TempArray, ValueBuffer.LongLength);
							ValueBuffer = TempArray;
						}
						if (ParamList[index] == '&')
						{
							if ((index + 1) < ParamListLen && ParamList[index + 1] == '&')
							{
								ValueBuffer[ValIndex] = ParamList[index];
							}
							else if (ParamList[index - 1] == '&')
							{
								ValueBuffer[ValIndex] = ParamList[index];
							}
							else
							{
								index++;
								ValIndex++;
								break;
							}
						}
						else
						{
							ValueBuffer[ValIndex] = ParamList[index];
						}

					}
					index++;
					ValIndex++;
				}

				//put data in hash table as name - value
				if (PopulateResponseHashTable)
				{
					String Name = new String(NameBuffer).Trim('\0');
					String Value = new String(ValueBuffer).Trim('\0');
					if (ParamListHashTable.Contains(Name))
					{
						Name = Name + PayflowConstants.TAG_DUPLICATE + PayflowUtility.RequestId;
					}

					ParamListHashTable.Add(Name, Value);

				}

				OpenBracket = false;
				CloseBracket = false;
				NameBuffer = null;
				LenValueBuffer = null;
				ValueBuffer = null;
				TempArray = null;
			}
			Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.ParseNVPList(String,String,String,ref context,bool): Exiting", PayflowConstants.SEVERITY_DEBUG);
			return ParamListHashTable;
		}

//		internal static bool ValidateNVPHighLevel(String ParamList, out String AddlMessage)
//		{
//			bool Invalid = false;
//			AddlMessage = PayflowConstants.EMPTY_STRING;
//			Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.ValidateNVPHighLevel(String,out String): Entered", PayflowConstants.SEVERITY_DEBUG);
//			if (ParamList.StartsWith(PayflowConstants.DELIMITER_NVP))
//			{
//				Invalid = true;
//				AddlMessage = "Param list begins with '&'";
//			}
//			else if (ParamList.IndexOf(PayflowConstants.SEPARATOR_NVP) < 0)
//			{
//				Invalid = true;
//				AddlMessage = "No separator '=' found in param list";
//			}
//			else if (ParamList.StartsWith(PayflowConstants.SEPARATOR_NVP) || ParamList.EndsWith(PayflowConstants.SEPARATOR_NVP))
//			{
//				Invalid = true;
//				AddlMessage = "Param list begins or ends with '='";
//			}
//			else if (ParamList.StartsWith(PayflowConstants.OPENING_BRACE_NVP) || ParamList.EndsWith(PayflowConstants.OPENING_BRACE_NVP))
//			{
//				Invalid = true;
//				AddlMessage = "Param list begins or ends with '['";
//			}
//			else if (ParamList.StartsWith(PayflowConstants.CLOSING_BRACE_NVP) || ParamList.EndsWith(PayflowConstants.CLOSING_BRACE_NVP))
//			{
//				Invalid = true;
//				AddlMessage = "Param list begins or ends with ']'";
//			}
//			else
//			{
//				int Index = ParamList.LastIndexOf(PayflowConstants.DELIMITER_NVP);
//				if (Index >= 0 && Index < ParamList.Length)
//				{
//					if(ParamList[Index-1] != '&' && ParamList.IndexOf(PayflowConstants.SEPARATOR_NVP, Index) < 0)
//					{
//						Invalid = true;
//						AddlMessage = "Parameter list format error: unmatched name";
//					}
//				}
//			}
//			Logger.Instance.Log("PayPal.Payments.Common.Utility.ParameterListValidator.ValidateNVPHighLevel(String,out String): Exiting", PayflowConstants.SEVERITY_DEBUG);
//			return Invalid;
//		}

		#endregion
	}
}