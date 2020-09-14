#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{	
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>Items that reflect what type of device; either terminal or card is used or presented.</remarks>
		/// <example>
		/// <para>Following example shows how to use Devices.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///  .................
		/// // Create a new Devices object.
		///	Devices UsedDevices = new Devices();
		///	UsedDevices.CatType = "3";
		///	UsedDevices.Contactless = "RFD";
		///	Inv.Devices = UsedDevices;
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		/// .................
		/// 'Inv is the Invoice object.
		/// .................
        /// ' Set the device/card capabilities
        /// Dim UsedDevices As Devices = New Devices
        /// UsedDevices.CatType = "3"
        /// UsedDevices.Contactless = "RFD"
        /// Inv.Devices = UsedDevices
		///	.................
		/// </code>
		/// </example>

    public sealed class Devices : BaseRequestDataObject
    {
        #region "Member Variables"

		/// <summary>
		/// Type of Terminal
		/// </summary>
		private String mCatType;

		/// <summary>
		/// Card Input Capability
		/// </summary>
		private String mContactless;

		#endregion

		#region "Properties"

		/// <summary>
		/// Gets, Sets Terminal type
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CATTYPE</code>
		/// </remarks>
		public String CatType
		{
            get { return mCatType; }
            set { mCatType = value; }
        }

		/// <summary>
		/// Gets, Sets Card Input Capability
		/// </summary>
		/// <remarks>
		/// <para>Maps to Payflow Parameter:</para>
		/// <code>CONTACTLESS</code>
		/// </remarks>
		public String Contactless
		{
            get { return mContactless; }
            set { mContactless = value; }
		}

		#endregion

		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>Items that reflect what type of device; either terminal or card is used or presented.</remarks>
		/// <example>
		/// <para>Following example shows how to use Devices.</para>
		/// <code lang="C#" escaped="false">
		///  .................
		///  //Inv is the Invoice object.
		///  .................
		/// // Create a new Devices object.
		///	Devices UsedDevices = new Devices();
		///	UsedDevices.CatType = "3";
		///	UsedDevices.Contactless = "RFD";
		///	Inv.Devices = UsedDevices;
		///	.................
		/// </code>
		/// <code lang="Visual Basic" escaped="false">
		/// .................
		/// 'Inv is the Invoice object.
		/// .................
        /// ' Set the device/card capabilities
        /// Dim UsedDevices As Devices = New Devices
        /// UsedDevices.CatType = "3"
        /// UsedDevices.Contactless = "RFD"
        /// Inv.Devices = UsedDevices
		///	.................
		/// </code>
		/// </example>
		public Devices()
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
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CATTYPE, mCatType));
				RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_CONTACTLESS, mContactless));
		
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