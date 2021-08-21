using System;
using System.Collections;
using PayPal.Payments.Common.Logging;
using PayPal.Payments.Common.Utility;
using System.Text;

namespace PayPal.Payments.Common
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class contains the all error message generated for the class containing 
	/// the context.This also contains the highest severity level contained by the 
	/// context
	/// </summary>
	/// <remarks>
	///     
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class Context
	{
		#region "Member variable"

		/// <summary>
		/// Holds the collection of error objects for the context instance.
		/// </summary>
		private ArrayList mErrorObjects = new ArrayList();

		/// <summary>
		/// Indicates the highest severity level error in the array list.
		/// </summary>
		private int mHighestErrorLvl;

		/// <summary>
		/// Indicates if the Error messages due to Logger class needs to be added to the context.
		/// </summary>
		private  bool mLoadLoggerErrs ;
		
		#endregion

		#region "Constructor"

		/// <summary>
		/// Constructor for Context
		/// </summary>
		internal Context()
		{
		}

		#endregion

		#region "Properties"

		//Gets the highestErrorLvl
		/// <summary>
		/// Indicates the highest severity level error in the array list.
		/// </summary>
		public int HighestErrorLvl
		{
			get
			{
				int ErrCnt = 0;
				int ErrMaxCnt = 0;
				int ErrSeverityLevel = 0;
				PopulateErrors();
				ErrMaxCnt = mErrorObjects.Count;
				for (ErrCnt = 0; ErrCnt < ErrMaxCnt; ErrCnt++)
				{
					ErrSeverityLevel = ((ErrorObject) mErrorObjects[ErrCnt]).SeverityLevel;
					if (mHighestErrorLvl < ErrSeverityLevel)
					{
						mHighestErrorLvl = ErrSeverityLevel;
					}
				}
				return mHighestErrorLvl;
			}
		}

		/// <summary>
		/// Indicates if the Error messages due to Logger class needs to be added to the context.
		/// </summary>
		public bool LoadLoggerErrs
		{
			get
			{
				return mLoadLoggerErrs ;
			}
			set
			{
				mLoadLoggerErrs = value;
			}
		}
		#endregion

		#region "Methods"

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method adds the passed error object in the array list contained by 
		/// the context object
		/// </summary>
		/// <param name="ErrObject">ErrorObject</param>
		/// <returns>Nothing</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		internal void AddError(ErrorObject ErrObject)
		{
			if (mErrorObjects == null)
			{
				mErrorObjects = new ArrayList();
			}
			mErrorObjects.Insert(0,ErrObject);
			return;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method adds the passed arraylist of error objects
		/// to the context object
		/// </summary>
		/// <param name="ErrorObjects">Array List</param>
		/// <returns>Nothing</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		internal void AddErrors(ArrayList ErrorObjects)
		{
			mErrorObjects.InsertRange(0,ErrorObjects);
			return;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will log all the error and exceptions contained in the ErrorObjects 
		/// arraylist.This will then call the log method from the Logger class after 
		/// converting the array list into a ErrorObject array.
		/// </summary>
		/// <returns>Nothing</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public bool LogErrors()
		{
			//This method will log all the errors using the Logger class
			//convert the array list into a array of error objects
			try
			{
				int ErrCnt = 0;
				Logger Instance = null;
				ArrayList PopulatedErr = new ArrayList(0);

				if (mErrorObjects != null)
				{
					Instance = Logger.Instance;
					PopulatedErr = Instance.PopulateErrorDetails(mErrorObjects);
					mErrorObjects.Clear();
					mErrorObjects.InsertRange(ErrCnt, PopulatedErr);
					Instance.Log(mErrorObjects);
				}
				return true;
			}
			catch
			{
				return false;
			}
		}


		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will check if the context contains any error message.This method 
		/// can be used for checking if the context is empty.
		/// </summary>
		/// <returns>boolean value 'true' - If errors are present
		///			false in case of no errors.</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public bool IsErrorContained()
		{
			if (mErrorObjects != null)
			{
				if (mErrorObjects.Count > 0)
					return true;

				return false;
			}
			return false;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will check if the context contains a specific error message.This method 
		/// can be used for checking if the context is empty.
		/// </summary>
		///<param name="Error">Error Object</param>
		/// <returns>boolean value 'true' - If specific Error is present
		///			false in case of no errors.</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		internal bool IsCommunicationErrorContained(ErrorObject Error)
		{
			if (IsErrorContained())
			{
				foreach (ErrorObject Err in mErrorObjects)
				{
					if (Err != null && Err.MessageCode.Equals(Error.MessageCode))
					{
						if (Err.MessageParams != null && Error.MessageParams != null)
						{
							if (Err.MessageParams[0].Equals(Error.MessageParams[0]))
							{
								return true;
							}
						}
						//return false;
					}
				}
				return false;
			}
			return false;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will return the error object from the Context as per the index 
		/// passed to the function.If the index value passed is more than the count of the 
		/// errors in the array list then it returns a null.
		/// </summary>
		/// <param name="Index">int</param> 
		/// <returns>ErrorObject</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		//Get the error object form the array list depending on the index passed
		public ErrorObject GetError(int Index)
		{
			PopulateErrors();
			if (Index < mErrorObjects.Count)
			{
				return (ErrorObject) mErrorObjects[Index];
			}
			return null;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method returns the array list populated with all the error contained 
		/// in the context
		/// </summary>
		/// <returns>Array List</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		//Get all the error contained by the context
		public ArrayList GetErrors()
		{
			PopulateErrors();
			return mErrorObjects;
		}


		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will return the array list populated with all the error contained 
		/// in the context which are equal to or above the severity level passed to the 
		/// function
		/// </summary>
		/// <param name="SevLvl">integer</param> 
		/// <returns>Array List</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		//Get all the error contained by the context equal to or above a severity level
		public ArrayList GetErrors(int SevLvl)
		{
			ArrayList HighSevErrors = new ArrayList();
			int ErrMaxCount = 0;
			int ErrCnt = 0;
			PopulateErrors();
			ErrMaxCount = mErrorObjects.Count;
			for (ErrCnt = 0; ErrCnt < ErrMaxCount; ErrCnt++)
			{
				if (((ErrorObject) mErrorObjects[ErrCnt]).SeverityLevel >=
					SevLvl)
				{
					HighSevErrors.Add(mErrorObjects[ErrCnt]);
				}
			}
			return HighSevErrors;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will return the total number of errors contained in the 
		/// Context Object.
		/// </summary>
		/// <returns>Integer</returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		//Get the count of ErrorObjects in the Context
		public int getErrorCount()
		{
			if (mErrorObjects != null)
			{
				return mErrorObjects.Count;
			}
			return 0;
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method will populate all the error objects contained in the arraylist with 
		/// details such as the severity level and message body.It uses 'PopulateErrorDetails'
		/// method of the Logger class.
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		//Populate the error objects with information from the sorted List
		private void PopulateErrors()
		{
			int ErrCnt = 0;
			Logger Instance = null;
			ArrayList PopulatedErr = new ArrayList(0);

			if (mErrorObjects != null)
			{
				Instance = Logger.Instance;
				PopulatedErr = Instance.PopulateErrorDetails(mErrorObjects);
				if (LoadLoggerErrs)
				{
					//PopulatedErr.AddRange (Instance.GetLoggerErrs);
					//Check for duplicate Logger errors
					ArrayList TempList = Instance.GetLoggerErrs;
					if (TempList != null)
					{
						for (int i=0;i<TempList.Count ;i++)
						{
							if (!PopulatedErr.Contains (TempList[i]))
							{
								PopulatedErr.Add ((ErrorObject)TempList[i]);
							}
						}
					}
				}
				mErrorObjects.Clear();
				mErrorObjects.InsertRange(ErrCnt, PopulatedErr);
			}
		}


		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method overrides the toString() method of the System.Object Class.This method 
		/// converts the information in the Context in the string format.The format is as follows:
		/// 
		/// Message (Message Number in the context)-----------------------------
		/// [(Message severity Level)](Message code)-(Formatted message body with context info)
		/// Message stack Trace
		///  
		/// </summary>
		/// <returns>Returns all the messages contained by the context in the string format.
		/// </returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public override String ToString()
		{
			StringBuilder RetVal = new StringBuilder("");
			int ErrCount = 0;
			int ErrMaxCount = 0;
			ErrorObject Err;

			PopulateErrors();
			ErrMaxCount = mErrorObjects.Count;
			for (ErrCount = 0; ErrCount < ErrMaxCount; ErrCount++)
			{
				Err = (ErrorObject) mErrorObjects[ErrCount];
				if (ErrMaxCount > 0)
				{
					RetVal.Append(PayflowConstants.FORMAT_MSG_SEPERATOR);
					RetVal.Append(ErrCount + 1);
					RetVal.Append(PayflowConstants.FORMAT_MSG_LINESEPERATOR);
					RetVal.Append(Environment.NewLine);
				}
				RetVal.Append(PayflowConstants.FORMAT_MSG_OPENBRACKET);
				RetVal.Append(GetStringSeverity(Err.SeverityLevel));
				RetVal.Append(PayflowConstants.FORMAT_MSG_CLOSEBRACKET);
				//RetVal.Append(Err.MessageCode);
				//RetVal.Append(PayflowConstants.FORMAT_MSG_CODEBODY_SEP);
				RetVal.Append(Err.ToString());
				RetVal.Append(Environment.NewLine);
				RetVal.Append(Err.ErrorStackTrace);
				if (ErrCount < ErrMaxCount - 1)
					RetVal.Append(Environment.NewLine);
			}
			return RetVal.ToString();
		}

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This method is another overload for the method toString().This method 
		/// converts the information in the Context in the string format.This will return 
		/// the formatted error string for messages that have severity level equal to or above
		/// the severitylevel parameter passed to this function.The messages for different errors
		/// are separated by the separator format passed to the method.In case no separator is 
		/// passed a new line character is used.
		///   
		/// </summary>
		/// <param name="SeverityLevel" >All the errors messages which have severity levels equal 
		/// to or greater than this is returned </param>
		/// <param name="Seperator" >Message separator.</param>
		/// <returns>Returns the messages contained by the context in the string format.
		/// </returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		/// 
		public String ToString(int SeverityLevel, String Seperator)
		{
			StringBuilder RetVal = new StringBuilder("");
			int ErrCount = 0;
			int ErrMaxCount = 0;
			ErrorObject Err;
			ArrayList ErrObjects = new ArrayList(0);
			ErrObjects = GetErrors(SeverityLevel);

			ErrMaxCount = ErrObjects.Count;
			for (ErrCount = 0; ErrCount < ErrMaxCount; ErrCount++)
			{
				Err = (ErrorObject) ErrObjects[ErrCount];
				RetVal.Append(Err.ToString());
				if (ErrCount < ErrMaxCount - 1)
				{
					if (Seperator != null && Seperator.Length != 0)
					{
						RetVal.Append(Seperator);
					}
					else
					{
						RetVal.Append(Environment.NewLine);
					}
				}
			}
			return RetVal.ToString();
		}

		/// <summary>
		/// This resets the context object
		/// </summary>
		/// <returns>Void</returns>
		public void ClearErrors()
		{
			if (mErrorObjects != null)
			{
				mErrorObjects.Clear();
				mHighestErrorLvl = 0;
			}
		}
		/// <summary>
		/// This gets the severity level for a
		/// severity integer value.
		/// </summary>
		/// <param name="Severity">Severity level integer value</param>
		/// <returns>Severity level string value</returns>
		private static String GetStringSeverity(int Severity)
		{
			String RetVal = PayflowConstants.ERROR_WARN ;

			switch(Severity)
			{
				case PayflowConstants.SEVERITY_DEBUG: 
					RetVal = PayflowConstants.ERROR_DEBUG;
					break;
				case PayflowConstants.SEVERITY_INFO: 
					RetVal = PayflowConstants.ERROR_INFO;
					break;
				case PayflowConstants.SEVERITY_WARN: 
					RetVal = PayflowConstants.ERROR_WARN;
					break;
				case PayflowConstants.SEVERITY_ERROR: 
					RetVal = PayflowConstants.ERROR_ERROR;
					break;
				case PayflowConstants.SEVERITY_FATAL: 
					RetVal = PayflowConstants.ERROR_FATAL;
					break;
			}
			return RetVal;
		}

		/// <summary>
		/// Not implemented 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>Object.Equals</returns>
		[System.Runtime.InteropServices.ComVisible(false)]
		public override bool Equals(object obj)
		{
			return base.Equals (obj);
		}

		/// <summary>
		/// Not implemented 
		/// </summary>
		/// <returns>Object.GetHashCode</returns>
		[System.Runtime.InteropServices.ComVisible(false)]
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}
		
		#endregion
	} // END CLASS DEFINITION Context

} // Payments.Common