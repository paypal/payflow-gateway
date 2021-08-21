using System;
using System.Collections;
using PayPal.Payments.Common.Utility;

namespace PayPal.Payments.Common
{
	/// -----------------------------------------------------------------------------
	/// <summary>
	/// This class contains the error message along with the message code ,Severity level 
	/// of the error and the stack Trace.This class represents the format of an error/message. 
	/// </summary>
	/// <remarks>
	///     
	/// </remarks>
	/// -----------------------------------------------------------------------------
	public class ErrorObject
	{
		#region "Member Variables"

		/// <summary>
		/// Holds the message code for the Error.
		/// </summary>
		private String mMsgCode;

		/// <summary>
		/// Holds the context parameters for the place holders.These parameters will be used 
		/// in conjunction with the message body to get the formatted message for the error.
		/// </summary>
		private ArrayList mMsgCodeParams;

		/// <summary>
		/// Holds the Severity Level for the error.Sets this to debug by default.
		/// </summary>
		private int mSeverity;

		/// <summary>
		/// Holds the stack trace, if applicable.This is helpful in case the error is an 
		/// Exception.
		/// </summary>
		private String mStackTrace;

		/// <summary>
		/// Holds the message body for the Error.
		/// </summary>
		private String mMsgBody;

		#endregion

		#region "Property Declarations"

		//Gets the property for the Message Body of the Error Object
		internal String MessageBody
		{
			get { return mMsgBody; }
		}

		//Gets the property for the Message Code of the Error Object
		/// <summary>
		/// Gets Message Code
		/// </summary>
		public String MessageCode
		{
			get { return mMsgCode; }
		}

		/*Gets the property for the Stack Trace of the Error Object.
		 * This is applicable only if the error is an exception*/

		/// <summary>
		/// Gets Stack Trace of the Error Object.
		/// </summary>
		public String ErrorStackTrace
		{
			get { return mStackTrace; }
		}

		//Gets the property for the mSeverityLevel of the Error Object
		/// <summary>
		/// Gets the SeverityLevel
		/// </summary>
		public int SeverityLevel
		{
			get { return mSeverity; }
		}


		/// <summary>
		/// Gets MessageParams
		/// </summary>
		public ArrayList MessageParams
		{
			get { return mMsgCodeParams; }
		}

		#endregion

		#region "Methods"

		/// -----------------------------------------------------------------------------
		/// <summary>
		/// This function overrides the object.toString method.
		/// This function formats the error message by filling the place holders with the 
		/// context parameters
		/// </summary>
		/// <returns>Formatted error String </returns>
		/// <remarks>
		/// </remarks>
		/// -----------------------------------------------------------------------------
		public override String ToString()
		{
			//This needs to get the message bode using the message code 
			String FormattedMessage = PayflowConstants.EMPTY_STRING;
			if (mMsgCodeParams != null)
			{
				//Convert the arraylist mMsgCodeparams to an array of String
				String[] MsgParams = new String[mMsgCodeParams.Count];

				mMsgCodeParams.CopyTo(MsgParams);
				try
				{
					FormattedMessage = String.Format(mMsgBody, MsgParams);
				}
				catch(Exception Ex)
				{
					String StackTrace = PayflowConstants.EMPTY_STRING;
					PayflowUtility.InitStackTraceOn();
					
					if(PayflowConstants.TRACE_ON.Equals(PayflowConstants.TRACE))
					{
						StackTrace = " " + Ex.ToString();
					}

					FormattedMessage = PayflowConstants.MESSAGE_FORMATTING_ERROR + StackTrace;
				}
                //catch
                //{
                //    FormattedMessage = PayflowConstants.MESSAGE_FORMATTING_ERROR;
                //}
			}
			else
			{
				FormattedMessage = mMsgBody;
			}

			return FormattedMessage;
		}

		#endregion

		#region "Constructors"

		// Used for Validation Errors which don’t have a stack trace.
		/// <summary>
		/// Used for Validation Errors which don’t have a stack trace.
		/// </summary>
		/// <param name="Severity">Severity level for the error.</param>
		/// <param name="MsgCode">Message Code.</param>
		/// <param name="MsgCodeParams">Parameters which are used as context information.</param>
		internal ErrorObject(int Severity, String MsgCode,
		                   String[] MsgCodeParams)
		{
			this.mSeverity = Severity;
			this.mMsgCode = MsgCode;
			this.mMsgCodeParams = new ArrayList();
			this.mMsgCodeParams.AddRange(MsgCodeParams);
		}

		// Used for populating error message from the Message xml file.
		/// <summary>
		/// Used for populating error message from the Message xml file.
		/// </summary>
		/// <param name="Severity">Severity level for the error.</param>
		/// <param name="MsgCode">Message Code.</param>
		/// <param name="MsgBody">Message Description for the Error.</param>
		internal ErrorObject(int Severity, String MsgCode, String MsgBody)
		{
			this.mSeverity = Severity;
			this.mMsgCode = MsgCode;
			this.mMsgBody = MsgBody;
			this.mStackTrace = PayflowConstants.EMPTY_STRING;
			this.mMsgCodeParams = new ArrayList();
		}

		// Used for Exception objects, which have a stack trace.
		/// <summary>
		/// Used for Exception objects, which have a stack trace.
		/// </summary>
		/// <param name="Severity">Severity level for the error.</param>
		/// <param name="MsgCode">Message Code.</param>
		/// <param name="MsgCodeParams">Parameters which are used as context information.</param>
		/// <param name="StackTrace">Stack Trace information for the Error.</param>
		internal ErrorObject(int Severity, String MsgCode, String[] MsgCodeParams, String StackTrace) : this(Severity, MsgCode, MsgCodeParams)
		{
			this.mStackTrace = StackTrace;
		}

		// Used for copying the error object in the logger class
		/// <summary>
		/// Used for copying the error object in the logger class.
		/// </summary>
		/// <param name="Severity">Severity level for the error.</param>
		/// <param name="MsgCode">Message Code.</param>
		/// <param name="MsgBody">Message Description for the Error.</param>
		/// <param name="MsgCodeParams">Parameters which are used as context information.</param>
		/// <param name="StackTrace">Stack Trace information for the Error.</param>
		internal ErrorObject(int Severity, String MsgCode, String MsgBody, String[] MsgCodeParams, String StackTrace) : this(Severity, MsgCode, MsgCodeParams)
		{
			this.mMsgBody = MsgBody;
			this.mStackTrace = StackTrace;
		}

		// Used for Exception objects without any message code.
		/// <summary>
		/// Used for Exception objects without any message code.
		/// </summary>
		/// <param name="MsgBody">Message Description for the Error.</param>
		/// <param name="StackTrace">Stack Trace information for the Error.</param>
		internal ErrorObject(String MsgBody, String StackTrace)
		{
			this.mSeverity = PayflowConstants.SEVERITY_FATAL;
			this.mMsgBody = MsgBody;
			this.mStackTrace = StackTrace;
			this.mMsgCode = PayflowConstants.EMPTY_STRING;
			this.mMsgCodeParams = new ArrayList();
		}

		// Used for Exception objects without any message code and stack trace.
		/// <summary>
		/// Used for Exception objects without any message code and stack trace.
		/// </summary>
		/// <param name="MsgBody">Message Description for the Error.</param>
		internal ErrorObject(String MsgBody)
		{
			this.mMsgBody = MsgBody;
			this.mMsgCode = PayflowConstants.EMPTY_STRING;
			this.mMsgCodeParams = new ArrayList();
			this.mStackTrace = PayflowConstants.EMPTY_STRING;
			this.mSeverity = PayflowConstants.SEVERITY_FATAL;
		}

		#endregion
	} // END CLASS DEFINITION ErrorObject
} // Payments.Common