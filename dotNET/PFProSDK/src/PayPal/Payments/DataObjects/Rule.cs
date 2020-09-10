#region "Copyright"

//PayPal Payflow Pro .NET SDK
//Copyright (C) 2014  PayPal, Inc.
//
//This file is part of the Payflow Pro .NET SDK
//
//The Payflow .NET SDK is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//any later version.
//
//The Payflow .NET SDK is is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with the Payflow .NET SDK.  If not, see <http://www.gnu.org/licenses/>.


#endregion

#region "Imports"

using System;
using System.Collections;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for fraud rule information
	/// </summary>
	/// <remarks>These are the fraud rules applied for the transaction.</remarks>
	public class Rule : BaseResponseDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Number
		/// </summary>
		private int mNum;

		/// <summary>
		/// Rule id
		/// </summary>
		private String mRuleId;

		/// <summary>
		/// rule alias
		/// </summary>
		private String mRuleAlias;

		/// <summary>
		/// Rule description
		/// </summary>
		private String mRuleDescription;

		/// <summary>
		/// Action
		/// </summary>
		private String mAction;

		/// <summary>
		/// triggered message
		/// </summary>
		private String mTriggeredMessage;

		/// <summary>
		/// Rule Vendor params
		/// </summary>
		private ArrayList mRuleVendorParms;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Num
		/// </summary>
		/// <remarks>This is the fraud rule number.</remarks>
		public int Num
		{
			get { return mNum; }
			set { mNum = value; }
		}

		/// <summary>
		/// Gets, Sets RuleId
		/// </summary>
		/// <remarks>This is the fraud rule id.</remarks>
		public String RuleId
		{
			get { return mRuleId; }
			set { mRuleId = value; }
		}

		/// <summary>
		/// Gets, Sets RuleAlias
		/// </summary>
		/// <remarks>This is the fraud rule alias.</remarks>
		public String RuleAlias
		{
			get { return mRuleAlias; }
			set { mRuleAlias = value; }
		}

		/// <summary>
		/// Gets, Sets RuleDescription
		/// </summary>
		/// <remarks>This is the fraud rule description.</remarks>
		public String RuleDescription
		{
			get { return mRuleDescription; }
			set { mRuleDescription = value; }
		}

		/// <summary>
		/// Gets, Sets Action
		/// </summary>
		/// <remarks>This is the fraud rule action.</remarks>
		public String Action
		{
			get { return mAction; }
			set { mAction = value; }
		}

		/// <summary>
		/// Gets, Sets TriggeredMessage
		/// </summary>
		/// <remarks>This is the fraud rule triggered message.</remarks>
		public String TriggeredMessage
		{
			get { return mTriggeredMessage; }
			set { mTriggeredMessage = value; }
		}

		/// <summary>
		/// Gets, Sets RuleVendorParms
		/// </summary>
		/// <remarks>This is the fraud rule vendor params arraylist
		///  containing objects of RuleParameter.</remarks>
		public ArrayList RuleVendorParms
		{
			get { return mRuleVendorParms; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for Rule
		/// </summary>
		internal Rule()
		{
			mRuleVendorParms = new ArrayList();
		}

		#endregion
	}

}