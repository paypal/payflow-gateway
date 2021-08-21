#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for advice detail items.
	/// </summary>
	/// <remarks>
	/// This class holds the advice detail related information.
	/// Detail of a charge where *n* is a value from 1 - 5. Use for additional breakdown of the amount.
	/// For example ADDLAMT1=1 is the amount for the additional amount for advice detail item 1 and is equal to 1,
	/// </remarks>
	/// <example>
	/// <para>Following example shows how to use AdviceDetail.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Inv is the Invoice object.
	///  .................
	/// // Set the Advice Detail items.
	/// AdviceDetail AddDetail1 = new AdviceDetail();
	///	AddDetail1.AddLAmt = "1";
	///	AddDetail1.AddLAmtType = "1";
	///	Inv.AddAdviceDetailItem(AddDetail1);
	///	// To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///  .................
	///  'Inv is the Invoice object.
	///  .................
    ///  ' Set the Advice Detail items.
    ///  Dim AddDetail1 As AdviceDetail = New AdviceDetail
    ///  AddDetail1.AddLAmt = "1"
    ///  AddDetail1.AddLAmtType = "1"
    ///  Inv.AddAdviceDetailItem(AddDetail1)
	///  ' To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
	///	.................
	/// </code>
	/// </example>
	public sealed class AdviceDetail : BaseRequestDataObject
	{
		#region "Member Variables"

		
		/// <summary>
		/// Advice Detail Number
		/// </summary>
		private String mAdviceDetailNumber;

		/// <summary>
		/// Advice Detail Amount
		/// </summary>
		private String mAddLAmt;

		/// <summary>
		/// Advice Detail Amount Type
		/// </summary>
		private String mAddLAmtType;


		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets advice detail amount
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ADDLAMTn</code>
		/// </remarks>
		public String AddLAmt
		{
			get { return mAddLAmt; }
			set { mAddLAmt = value; }
		}

		/// <summary>
		/// Gets, Sets advice detail amount type
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ADDLAMTTYPEn</code>
		/// </remarks>
		public String AddLAmtType
		{
			get { return mAddLAmtType; }
			set { mAddLAmtType = value; }
		}

		

		/// ------------------------------------------------------


		/// <summary>
		/// Gets, Sets advice detail line item number.
		/// </summary>
		/// <remarks>
		/// <para></para>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>ADDLxxxxn</code>
		/// </remarks>
		public String AdviceDetailNumber
		{
			get { return mAdviceDetailNumber; }
			set { mAdviceDetailNumber = value; }
		}

		#endregion

		#region "Constructors"

	/// <summary>
	/// Used for advice detail items.
	/// </summary>
	/// <remarks>
	/// This class holds the advice detail related information.
	/// Detail of a charge where *n* is a value from 1 - 5. Use for additional breakdown of the amount.
	/// For example ADDLAMT1=1 is the amount for the additional amount for advice detail item 1 and is equal to 1,
	/// </remarks>
	/// <example>
	/// <para>Following example shows how to use AdviceDetail.</para>
	/// <code lang="C#" escaped="false">
	///  .................
	///  //Inv is the Invoice object.
	///  .................
	/// // Set the Advice Detail items.
	/// AdviceDetail AddDetail1 = new AdviceDetail();
	///	AddDetail1.AddLAmt = "1";
	///	AddDetail1.AddLAmtType = "1";
	///	Inv.AddAdviceDetailItem(AddDetail1);
	///	// To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
	///	.................
	/// </code>
	/// <code lang="Visual Basic" escaped="false">
	///  .................
	///  'Inv is the Invoice object.
	///  .................
    ///  ' Set the Advice Detail items.
    ///  Dim AddDetail1 As AdviceDetail = New AdviceDetail
    ///  AddDetail1.AddLAmt = "1"
    ///  AddDetail1.AddLAmtType = "1"
    ///  Inv.AddAdviceDetailItem(AddDetail1)
	///  ' To add another item, just do the same as above but increment the value of AddDetail to 2: AddDetail2
	///	.................
	/// </code>
	/// </example>
		public AdviceDetail()
		{
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates advice detail item request
		/// </summary>
		/// <param name="Index">index number of advice detail item</param>
		internal void GenerateRequest(int Index)  
		{
			try
			{
				String IndexVal = (Index + 1).ToString();  // adding +1 as range is 1 to 5.

				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ADDLAMT+ IndexVal, mAddLAmt));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_ADDLAMTTYPE + IndexVal, mAddLAmtType));
				
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
		}
		#endregion
	}

}