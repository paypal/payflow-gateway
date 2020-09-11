#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
    /// <summary>
    /// Used for swipe card information
    /// </summary>
    /// <remarks>
    /// Used to pass the Track 1 or Track 2 data (the card’s
    /// magnetic stripe information) for card-present
    /// transactions. Include either Track 1 or Track 2
    /// data—not both. If Track 1 is physically damaged, the
    /// POS application can send Track 2 data instead.
    /// <para>SwipeCard is associated with CardTender.</para>
    /// <seealso cref="CardTender"/>
    /// </remarks>
    public sealed class SwipeCard : PaymentDevice
    {

        #region "Constructors"

        /// <summary>
        /// Constructor for SwipeCard
        /// </summary>
        /// <param name="Swipe">Card Swipe value</param>
        /// <remarks>This is used as Payment Device for the CardTender.
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>Swipe --> SWIPE</code>
        /// </remarks>
        /// <example>
        ///  <code lang="C#" escaped="false">
        ///		.............
        ///		
        ///		SwipeCard PayDevice = new SwipeCard("XXXXXXXXXXXXXXXXXXXXXXXXXXX");
        ///		
        ///		..............
        ///  </code>
        ///  <code lang="C#" escaped="false">
        ///		.............
        ///		
        ///		Dim PayDevice As SwipeCard = New SwipeCard("XXXXXXXXXXXXXXXXXXXXXXXXXXX")
        ///		
        ///		..............
        ///  </code>
        ///  </example>
        ///  <seealso cref="CardTender"/>
        public SwipeCard(String Swipe) : base(Swipe)
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
                //Set the base acct field as swipe in the request.
                if (base.Acct != "")
                {
                   RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_SWIPE, base.Acct));
                }
                if (mMagtekInfo != null)
                {
                    mMagtekInfo.RequestBuffer = RequestBuffer;
                    mMagtekInfo.GenerateRequest();
                }
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