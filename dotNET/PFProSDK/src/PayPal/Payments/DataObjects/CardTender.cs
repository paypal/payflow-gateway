#region "Imports"

using PayPal.Payments.Common.Utility;

#endregion

namespace PayPal.Payments.DataObjects
{
	/// <summary>
	/// Used for Card tender related information
	/// </summary>
	/// <remarks>CreditCard, PurchaseCard and SwipeCard are
	/// the Payment devices associated with this tender type.
	/// <seealso cref="CreditCard"/>
	/// <seealso cref="PurchaseCard"/>
	/// <seealso cref="SwipeCard"/>
	/// </remarks>
	public sealed class CardTender : BaseTender
	{
		#region "Constructors"

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="CredCard">Credit Card object</param>
		/// <remarks>This constructor is used to create a CardTender
		///  with CreditCard as the payment device</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//CredCard is the CreditCard object.
		///		.............
		///		
		///		CardTender Tender = new CardTender(CredCard);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'CredCard is the CreditCard object.
		///		.............
		///		
		///		Dim Tender As CardTender = new CardTender(CredCard)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="CreditCard"/>
		public CardTender(CreditCard CredCard):base(PayflowConstants.TENDERTYPE_CARD,CredCard)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="PurCard">Purchase Card object</param>
		/// <remarks>This constructor is used to create a CardTender
		///  with PurchaseCard as the payment device</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//PurCard is the PurchaseCard object.
		///		.............
		///		
		///		CardTender Tender = new CardTender(PurCard);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'PurCard is the PurchaseCard object.
		///		.............
		///		
		///		Dim Tender As CardTender = new CardTender(PurCard)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="PurchaseCard"/>
		public CardTender(PurchaseCard PurCard):base(PayflowConstants.TENDERTYPE_CARD,PurCard)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="SwpCard">Swipe Card object</param>
		/// <remarks>This constructor is used to create a CardTender
		///  with SwipeCard as the payment device</remarks>
		///  <example>
		///  <code lang="C#" escaped="false">
		///		.............
		///		//SwpCard is the SwipeCard object.
		///		.............
		///		
		///		CardTender Tender = new CardTender(SwpCard);
		///		
		///		..............
		///  </code>
		///  <code lang="C#" escaped="false">
		///		.............
		///		'SwpCard is the SwipeCard object.
		///		.............
		///		
		///		Dim Tender As CardTender = new CardTender(SwpCard)
		///		
		///		..............
		///  </code>
		///  </example>
		/// <seealso cref="SwipeCard"/>
		public CardTender(SwipeCard SwpCard):base(PayflowConstants.TENDERTYPE_CARD, SwpCard)
		{
		}
        #endregion
    }

}