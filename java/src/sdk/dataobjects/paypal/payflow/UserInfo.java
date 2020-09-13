package paypal.payflow;


/**
 * Used for PayPal User account information
 * <p>This is a required class for a strong assembly
 * transactions. This class is used to store the
 * user credential needed to authenticate the user
 * performing the transaction.</p>
 * <p>Every transaction takes UserInfo
 * mandatorily.</p>
 * <p>Following are the required user credentials:</p>
 * {@paypal.listtable}
 * {@paypal.ltr}
 * {@paypal.ltd}Payflow Parameter{@paypal.eltd}
 * {@paypal.ltd}Description {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}USER{@paypal.eltd}
 * {@paypal.ltd}Login name. This value is case-sensitive.
 * The login name created while registering for the Payflow
 * account. {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}VENDOR{@paypal.eltd}
 * {@paypal.ltd}Login name. This value is case-sensitive.
 * The login name created while registering for the Payflow
 * account. {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}PARTNER{@paypal.eltd}
 * {@paypal.ltd}The authorized PayPal Reseller that
 * registered this account for the Payflow service
 * provided you with a Partner ID.
 * If you registered yourself, use PayPal.
 * Case-sensitive. {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.ltr}
 * {@paypal.ltd}PWD{@paypal.eltd}
 * {@paypal.ltd}Case-sensitive 6- to 32-character password. {@paypal.eltd}
 * {@paypal.eltr}
 * {@paypal.endlisttable}
 *
 *  ..............
 * // Create the User data object with the required user details.
 * UserInfo user = new UserInfo("user", "vendor", "partner", "password");
 * ..............
 */
public final class UserInfo extends BaseRequestDataObject {

    private String user;

    private String vendor;

    private String partner;

    private String pwd;

    /**
     * Constructor
     *
     * @param User    - String
     * @param Vendor  - String
     * @param Partner - String
     * @param Pwd     -String
     */

    public UserInfo(String User, String Vendor, String Partner, String Pwd) {
        user = User;
        vendor = Vendor;
        partner = Partner;
        pwd = Pwd;

    }

    protected void generateRequest() {
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_USER, user));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_VENDOR, vendor));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PARTNER, partner));
        super.getRequestBuffer().append(PayflowUtility.appendToRequest(PayflowConstants.PARAM_PWD, pwd));
    }
}
