#region "Imports"

using System;
using System.Globalization;
using System.Threading;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// This class is used as the currency data type 
	/// by all data and transaction objects.
	/// </summary>
	/// <remarks>This class should be used to denote any 
	/// currency parameter. By default, the currency code is
	/// USD (US Dollars).
	/// </remarks>
	/// <example>
	/// Following example shows how to use this class.
	/// <code lang="C#" escaped="false">
	///		.............
	///		//Inv is the Invoice object
	///		.............
	///		
	///     // Set the amount object.
	///     // Currency Code USD is US ISO currency code.  If no code passed, USD is default.
	///     // See the Developer's Guide regarding the CURRENCY parameter for the list of
	///     // three-character currency codes available.
	///     Currency Amt = new Currency(new decimal(25.25), "USD");  
	///		
	///     // A valid amount has either no decimal value or only a two decimal value. 
	///     // An invalid amount will generate a result code 4.
	///     //
	///     // For values which have more than two decimal places such as:
	///     // Currency Amt = new Currency(new Decimal(25.2575));
	///     // You will either need to truncate or round as needed using the following properties:
	///     //
	///     // If the NoOfDecimalDigits property is used then it is mandatory to set one of the following
	///     // properties to true.
	///     //
	///     //Amt.Round = true;
	///     //Amt.Truncate = true;
	///     //
	///     // For Currencies without a decimal, you'll need to set the NoOfDecimalDigits = 0.
	///     //Amt.NoOfDecimalDigits = 0;
	///		
	///		//Set the amount in the invoice object
	///		Inv.Amt = Amt;
	///		.............
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///		.............
	///		'Inv is the Invoice object
	///		.............
	///		
	///		' Set the amount object.
	///     ' Currency Code USD is US ISO currency code.  If no code passed, USD is default.
	///     ' See the Developer's Guide for the list of three-character currency codes available.
	///     Dim Amt As New Currency(New Decimal(25.25), "USD")
	///     
	///		' A valid amount has either no decimal value or only a two decimal value. 
	///		' An invalid amount will generate a result code 4.
	///     '
	///     ' For values which have more than two decimal places such as:
	///     ' Dim Amt As New Currency(New Decimal(25.2575))
	///     ' You will either need to truncate or round as needed using the following property: Amt.NoOfDecimalDigits
	///     '
	///     ' If the NoOfDecimalDigits property is used then it is mandatory to set one of the following
	///     ' properties to true.
	///     '
	///     'Amt.Round = true
	///     'Amt.Truncate = true
	///     '
	///     ' For Currencies without a decimal, you'll need to set the NoOfDecimalDigits = 0.
	///     'Amt.NoOfDecimalDigits = 0
	///		
	///		'Set the amount in the invoice object
	///		Inv.Amt = Amt;
	///		.............
	/// </code>
	/// </example>
	public sealed class Currency : BaseRequestDataObject
	{
		#region "Member Variables"

		/// <summary>
		/// Currency Value
		/// </summary>
		private decimal mCurrencyValue;

		/// <summary>
		/// Currency code, default USD
		/// </summary>
		private String mCurrencyCode = PayflowConstants.CURRENCYCODE_DEFAULT;
		private bool mRound = false;
		private bool mTruncate = false;
		private int mNoOfDecimalDigits = 2;
		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="CurrencyValue">Currency value</param>
		/// <remarks>Currency code is set as default USD.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		//Inv is the Invoice object
		///		.............
		///		
		///		//Set the invoice amount.
		///		Inv.Amt = new Currency(new Decimal(25.12));
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		'Inv is the Invoice object
		///		.............
		///		
		///		'Set the invoice amount.
		///		Inv.Amt = New Currency(New Decimal(25.12))
		///		
		///		.............
		/// </code>
		/// </example>
		public Currency(decimal CurrencyValue)
		{
			mCurrencyValue = CurrencyValue;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="CurrencyValue">Currency value</param>
		/// <param name="CurrencyCode">3 letter Currency code</param>
		/// <remarks>Currency code if not given is set as default USD.</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		//Inv is the Invoice object
		///		.............
		///		
		///		//Set the invoice amount.
		///		Inv.Amt = new Currency(new Decimal(25.12),"USD");
		///		
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		'Inv is the Invoice object
		///		.............
		///		
		///		'Set the invoice amount.
		///		Inv.Amt = New Currency(New Decimal(25.12),"USD")
		///		
		///		.............
		/// </code>
		/// </example>
		public Currency(decimal CurrencyValue, String CurrencyCode) : this(CurrencyValue)
		{
			if(CurrencyCode != null && CurrencyCode.Length > 0)
			{
				mCurrencyCode = CurrencyCode;
			}
		}

		#endregion

		#region "Properties"
		/// <summary>
		/// Sets Currency value rounding flag to true.
		/// Note that only one of round OR truncate can be set to true.
		/// </summary>
		public bool Round
		{
			set { mRound = value; }
		}
		/// <summary>
		/// Sets Currency value truncation flag to true.
		/// Note that only one of round OR truncate can be set to true.
		/// </summary>
		public bool Truncate
		{
			set { mTruncate = value; }
		}
		/// <summary>
		/// Sets the number of decimal digits required after rounding or truncation.
		/// </summary>
		public int NoOfDecimalDigits
		{
			set { mNoOfDecimalDigits = value; }
		}
		/// <summary>
		/// Gets the currency code..
		/// </summary>
		public String CurrencyCode
		{
			get {return mCurrencyCode ;}
		}
		#endregion

		#region "Core functions"


		#endregion

		#region "Rounding and Truncation Methods"
		/// <summary>
		/// Rounds the currency String value
		/// </summary>
		/// <param name="CurrStringValue">Currency String Value</param>
		/// <param name="NoOfdecimalDigits">Number of decimal digits to round to</param>
		/// <returns>Rounded Currency String value</returns>
		internal String RoundCurrencyValue(String CurrStringValue,int NoOfdecimalDigits)
		{
			
			String RetVal;
			RetVal = CurrStringValue;
			if(RetVal == null || RetVal.Length == 0)
			{
				return PayflowConstants.EMPTY_STRING;
			}
			
			int IndexOfDecimal = RetVal.IndexOf(".");
			int Length = RetVal.Length;

			if(IndexOfDecimal > 0 && IndexOfDecimal < Length)
			{
				if(IndexOfDecimal == Length -1)
				{
					for(int i=0;i<NoOfdecimalDigits;i++)
					{
						RetVal += "0";
					}
				}
				else if(NoOfdecimalDigits == 0)
				{
					RetVal = RetVal.Substring(0,IndexOfDecimal);
				}
				else
				{
					int LenAfterTruncate = IndexOfDecimal + NoOfdecimalDigits + 1 ;

					if(LenAfterTruncate > Length)
					{
						int Padding = LenAfterTruncate - Length;
						for(int i=0; i<Padding; i++)
						{
							RetVal += "0";
						}	
					}
					else if(LenAfterTruncate < Length)
					{
						int Trimming = Length -  LenAfterTruncate ;
						int EndLen = Length -1 ;
						for(int i=0;i<Trimming;i++)
						{
							int Val = int.Parse(RetVal.Substring(EndLen,1));
							if(Val >= 5)
							{
								int RoundVal = int.Parse(RetVal.Substring(EndLen-1,1));
								RoundVal += 1;
								if(RoundVal >= 10)
								{
									RoundVal = 1;
								}
								RetVal = RetVal.Remove(EndLen-1,2);
								RetVal = RetVal.Insert(EndLen-1,RoundVal.ToString());
							}
							else
							{
								RetVal = RetVal.Remove(EndLen,1);
							}
							EndLen -= 1;
						}
					}
				}
				
			}
			return RetVal;
		}
		
		/// <summary>
		/// Truncates the currency String value
		/// </summary>
		/// <param name="CurrStringValue">Currency String Value</param>
		/// <param name="NoOfdecimalDigits">Number of decimal digits to round to</param>
		/// <returns>Truncated Currency String value</returns>
		internal String TruncateCurrencyValue(String CurrStringValue,int NoOfdecimalDigits)
		{
			
			String RetVal;
			RetVal = CurrStringValue;
			if(RetVal == null || RetVal.Length == 0)
			{
				return PayflowConstants.EMPTY_STRING;
			}

			int IndexOfDecimal = RetVal.IndexOf(".");
			int Length = RetVal.Length ;
			if(IndexOfDecimal >0 && IndexOfDecimal <= Length - 1)
			{
				if(IndexOfDecimal == Length - 1)
				{
					for(int i=0; i<NoOfdecimalDigits; i++)
					{
						RetVal += "0";
					}
				}
				else if(NoOfdecimalDigits == 0)
				{
					RetVal = RetVal.Substring(0,IndexOfDecimal);
				}

				else
				{
					int LenAfterTruncate = IndexOfDecimal + NoOfdecimalDigits + 1 ;

					if(LenAfterTruncate > Length)
					{
						int Padding = LenAfterTruncate - Length;
						for(int i=0; i<Padding; i++)
						{
							RetVal += "0";
						}	
					}
					else if(LenAfterTruncate < Length)
					{
						RetVal = RetVal.Substring(0,LenAfterTruncate);
					}
				}
			}
			return RetVal;
		}

		#endregion

		#region "System.Object Overrides"

		/// <summary>
		/// Overrides ToString
		/// </summary>
		/// <returns>String value of currency</returns>
		/// <remarks>Formats string value of currency in format "$.CC"</remarks>
		/// <example>
		/// <code lang="C#" escaped="false">
		///		.............
		///		//Inv is the Invoice object
		///		.............
		///		
		///		//Set the invoice amount.
		///		Inv.Amt = new Currency(new Decimal(25.12),"USD");
		///		String CurrValue = Inv.ToString();
		///		.............
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		///		.............
		///		'Inv is the Invoice object
		///		.............
		///		
		///		'Set the invoice amount.
		///		Inv.Amt = New Currency(New Decimal(25.12),"USD")
		///		CurrValue As String = Inv.ToString
		///		.............
		/// </code>
		/// </example>
		public override string ToString()
		{
			try
			{
				//Overridden ToString. Returns held Currency Value.
				String RetVal = PayflowConstants.EMPTY_STRING;
				// We need to double check here whether currency value
				// is non-zero positive before converting it.
			
				if(mNoOfDecimalDigits < 0 )
				{
					mNoOfDecimalDigits = 2;
				}
						
				if(mRound && mTruncate)
				{
					ErrorObject Err = PayflowUtility.PopulateCommError(PayflowConstants.E_CURRENCY_PROCESS_ERROR,null,PayflowConstants.SEVERITY_FATAL,false,null);
					throw new DataObjectException(Err);
				}
				else if(mRound)
				{
					mCurrencyValue = decimal.Round(mCurrencyValue,mNoOfDecimalDigits);
					RetVal = RoundCurrencyValue(mCurrencyValue.ToString(),mNoOfDecimalDigits);
					//RetVal = mCurrencyValue.ToString("c", LocalFormat);

				}
				else if(mTruncate)
				{
					//RetVal = TruncateCurrencyValue(mCurrencyValue.ToString("c", LocalFormat),mNoOfDecimalDigits);
                    RetVal = TruncateCurrencyValue(mCurrencyValue.ToString(), mNoOfDecimalDigits);
				}
				else
				{
					//RetVal = mCurrencyValue.ToString("c", LocalFormat);
                    RetVal = mCurrencyValue.ToString();
				}
			
				int IndexOfDecimal = RetVal.IndexOf(".",1);
				if(IndexOfDecimal < 0 && mNoOfDecimalDigits != 0)
				{
					RetVal += ".00";
				}
				string TempStr = RetVal.Substring(IndexOfDecimal+1,RetVal.Length-IndexOfDecimal-1);
				int Len = TempStr.Length;
				if (Len < 2)
				{
					for (int i=Len;i<2;i++)
						RetVal = RetVal + "0";
				}
				return RetVal;
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