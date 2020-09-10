using System;

namespace PayPal.Payments.Common.Utility
{
	/// <summary>
	/// Summary description for GlobalClass.
	/// </summary>
	public class GlobalClass
	{
		private static string m_globalVar = "";

		public static string GlobalVar
		{
			get { return m_globalVar; }
			set { m_globalVar = value; }
		}
	}
}
