#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Check Payment related information
	/// </summary>
	/// <remarks>
	/// CheckPayment is associated with CheckTender.
	/// <seealso cref="CheckTender"/>
	/// </remarks>
	public sealed class CheckPayment : PaymentDevice
	{
		#region "Constructors"

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <remarks>This is used as Payment Device for the CheckTender.
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>Micr --> MICR</code>
		/// </remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		CheckPayment PayDevice = new CheckPayment("XXXXXXXXXX");
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		
		///		Dim PayDevice As CheckPayment = new CheckPayment("XXXXXXXXXX")
		///		
		///		..............
		///  </code>
		///  </example>
		///  <seealso cref="CheckTender"/>
		/// <param name="Micr">MICR value</param>
		public CheckPayment(String Micr) : base(Micr)
		{
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
				//Put the base field Acct as MICR.
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_MICR, base.Acct));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_NAME, base.Name));
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