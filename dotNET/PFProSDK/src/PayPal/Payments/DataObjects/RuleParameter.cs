#region "Imports"

using System;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for fraud rule parameter
	/// </summary>
	/// <remarks>Rule parameter are the parameters of each fraud rule.</remarks>
	public class RuleParameter : BaseResponseDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Number
		/// </summary>
		private int mNum;

		/// <summary>
		/// Name
		/// </summary>
		private String mName;

		/// <summary>
		/// Value
		/// </summary>
		private String mValue;

		/// <summary>
		/// Type
		/// </summary>
		private String mType;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets Num
		/// </summary>
		/// <remarks>This is the fraud rule parameter number.</remarks>
		public int Num
		{
			get { return mNum; }
			set { mNum = value; }
		}

		/// <summary>
		/// Gets Name
		/// </summary>
		/// <remarks>This is the fraud rule parameter name.</remarks>
		public String Name
		{
			get { return mName; }
			set { mName = value; }
		}

		/// <summary>
		/// Gets Value
		/// </summary>
		/// <remarks>This is the fraud rule parameter value.</remarks>
		public String Value
		{
			get { return mValue; }
			set { mValue = value; }
		}

		/// <summary>
		/// Gets Type
		/// </summary>
		/// <remarks>This is the fraud rule parameter type.</remarks>
		public String Type
		{
			get { return mType; }
			set { mType = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor for RuleParameter
		/// </summary>
		internal RuleParameter()
		{
		}


		#endregion 
	}
}