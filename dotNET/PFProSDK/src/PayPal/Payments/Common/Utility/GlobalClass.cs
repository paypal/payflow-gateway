using System;

namespace PayPal.Payments.Common.Utility
{
	/// <summary>
	/// Summary description for GlobalClass.
	/// </summary>
	public class GlobalClass
	{
		private static string m_globalVar = "";

		/// <summary>
		/// Gets or Sets a global string variable available across the SDK session.
		/// </summary>
		public static string GlobalVar
		{
			get { return m_globalVar; }
			set { m_globalVar = value; }
		}
	}
}
