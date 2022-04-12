#region "Imports"

using System;
using PayPal.Payments.Common.Utility;
using PayPal.Payments.Common;
using PayPal.Payments.Common.Exceptions;

#endregion

namespace PayPal.Payments.DataObjects
{
    /// <summary>
    /// This class holds the User1 to User10 related information.
    /// </summary>
    /// <remarks>
    /// <para>You are able to send up to 10 string type parameters that you can use to store temporary data (for example, variables, 
    /// session IDs, order numbers, and so on). These parameters enable you to echo back the data to your server either 
    /// via the Payflow API or as part of the Return or Silent Post if using the hosted checkout page.
    /// 
    /// Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in 
    /// the PayPal transaction database.</para>
    /// </remarks>
    /// <example>
    /// <para>Following example shows how to use user item.</para>
    /// <code lang="C#" escaped="false">
    ///  .................
    ///  //Inv is the Invoice object.
    ///	 .................
    ///	 
    ///	 //Create a user item.
    ///	 UserItem nUser = new UserItem();
    ///	 
    ///	 //Add information to user item.
    ///	 nUser.UserItem1 = "TUSER1";
    ///	 nUser.UserItem2 = "TUSER2";
    ///	 
    ///	 //Add line item to invoice.
    ///	 Inv.UserItem = nUser;
    ///	 
    ///	 ..................
    /// </code>
    /// <code lang="Visual Basic" escaped="false">
    ///  .................
    ///  'Inv is the Invoice object.
    ///	 .................
    ///	 
    ///	 //Create a user item.
    ///	 Dim nUser As New UserItem
    ///	 
    ///	 'Add info to line item.
    ///	 nUser.UserItem1 = "TUSER1"
    ///	 nUser.UserItem2 = "TUSER2"
    ///	 	 
    ///	 'Add line item to invoice.
    ///	 Inv.UserItem = nUser
    ///	 
    ///	 ..................
    /// </code>
    /// </example>
    public sealed class UserItem : BaseRequestDataObject
    {
        #region "Member Variables"

        /// <summary>
        /// User item 1
        /// </summary>
        private String mUserItem1;
        /// <summary>
        /// User item 2
        /// </summary>
        private String mUserItem2;
        /// <summary>
        /// User item 3
        /// </summary>
        private String mUserItem3;
        /// <summary>
        /// User item 4
        /// </summary>
        private String mUserItem4;
        /// <summary>
        /// User item 5
        /// </summary>
        private String mUserItem5;
        /// <summary>
        /// User item 6
        /// </summary>
        private String mUserItem6;
        /// <summary>
        /// User item 7
        /// </summary>
        private String mUserItem7;
        /// <summary>
        /// User item 8
        /// </summary>
        private String mUserItem8;
        /// <summary>
        /// User item 9
        /// </summary>
        private String mUserItem9;
        /// <summary>
        /// User item 10
        /// </summary>
        private String mUserItem10;

        #endregion

        #region "Constructors"

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <remarks>
        /// <para>You are able to send up to 10 string type parameters that you can use to store temporary data (for example, variables, 
        /// session IDs, order numbers, and so on). These parameters enable you to echo back the data to your server either 
        /// via the Payflow API or as part of the Return or Silent Post if using the hosted checkout page.
        /// 
        /// Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in 
        /// the PayPal transaction database.</para>
        /// </remarks>
        /// <example>
        /// <para>Following example shows how to use user item.</para>
        /// <code lang="C#" escaped="false">
        ///  .................
        ///  //Inv is the Invoice object.
        ///	 .................
        ///	 
        ///	 //Create a user item.
        ///	 UserItem nUser = new UserItem();
        ///	 
        ///	 //Add information to user item.
        ///	 nUser.UserItem1 = "tUSER1";
        ///	 nUser.UserItem2 = "TUSER2";
        ///	 
        ///	 //Add line item to invoice.
        ///	 Inv.UserItem = nUser;
        ///	 
        ///	 ..................
        /// </code>
        /// <code lang="Visual Basic" escaped="false">
        ///  .................
        ///  'Inv is the Invoice object.
        ///	 .................
        ///	 
        ///	 //Create a user item.
        ///	 Dim nUser As New UserItem
        ///	 
        ///	 'Add info to line item.
        ///	 nUser.UserItem1 = "TUSER1"
        ///	 nUser.UserItem2 = "TUSER2"
        ///	 	 
        ///	 'Add line item to invoice.
        ///	 Inv.UserItem = nUser
        ///	 
        ///	 ..................
        /// </code>
        /// </example>
        public UserItem()
        {
        }

        #endregion

        #region "Properties"

        /// <summary>
        /// Gets, Sets user item.
        /// </summary>
        /// <remarks>
        /// <para> 
        /// These ten string type parameters are intended to store temporary data (for example, variables, 
        /// session IDs, order numbers, and so on). These parameters enable you to return the values 
        /// to your server by using the Post or Silent Post feature.
        /// 
        /// Note: UserItem1 through UserItem10 are not displayed to the customer and are not stored in 
        /// the PayPal transaction database.
        /// </para>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER1</code>
        /// </remarks>
        public String UserItem1
        {
            get { return mUserItem1; }
            set { mUserItem1 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER2</code>
        /// </remarks>
        public String UserItem2
        {
            get { return mUserItem2; }
            set { mUserItem2 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER3</code>
        /// </remarks>
        public String UserItem3
        {
            get { return mUserItem3; }
            set { mUserItem3 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER4</code>
        /// </remarks>
        public String UserItem4
        {
            get { return mUserItem4; }
            set { mUserItem4 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER5</code>
        /// </remarks>
        public String UserItem5
        {
            get { return mUserItem5; }
            set { mUserItem5 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER6</code>
        /// </remarks>
        public String UserItem6
        {
            get { return mUserItem6; }
            set { mUserItem6 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER7</code>
        /// </remarks>
        public String UserItem7
        {
            get { return mUserItem7; }
            set { mUserItem7 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER8</code>
        /// </remarks>
        public String UserItem8
        {
            get { return mUserItem8; }
            set { mUserItem8 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USER9</code>
        /// </remarks>
        public String UserItem9
        {
            get { return mUserItem9; }
            set { mUserItem9 = value; }
        }
        /// <remarks>
        /// <para>Maps to Payflow Parameter:</para>
        /// <code>USERn</code>
        /// </remarks>
        public String UserItem10
        {
            get { return mUserItem10; }
            set { mUserItem10 = value; }
        }

        #endregion

        #region "Core functions"

        /// <summary>
        /// Generates user item request
        /// </summary>
        internal override void GenerateRequest()
        {
            try
            {
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER1, mUserItem1));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER2, mUserItem2));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER3, mUserItem3));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER4, mUserItem4));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER5, mUserItem5));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER6, mUserItem6));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER7, mUserItem7));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER8, mUserItem8));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER9, mUserItem9));
                RequestBuffer.Append(PayflowUtility.AppendToRequest(PayflowConstants.PARAM_USER10, mUserItem10));
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