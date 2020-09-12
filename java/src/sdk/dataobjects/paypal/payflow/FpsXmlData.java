/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

package paypal.payflow;

import java.util.ArrayList;


/**
 * Used for storing Fraud Protection Services
 * XML response message after parsing them.
 * <p>If the VERBOSITY set for the transaction is HIGH,
 * Fraud Protection Services return FPS_PREXMLDATA and/or
 * FPS_POSTXMLDATA response messages. This are xml messages.
 * <p>While parsing the response, these xml messages are parsed
 * and populated into Rule data objects. These Rule objects are rules applied
 * by the Fraud Protection Services.. FpsXmlData is the container class
 * for all such rules.</p>
 * <p>FpsXmlData data objects instances are contained in
 * FraduResponse and populated if obtained.</p>
 * {@link FraudResponse}
 * {@link Rule}
 * {@link RuleParameter}
 * </p>
 * Following example shows how to obtained and use FpsXmlData.
 *
 * @paypal.sample ..............................
 * // resp is the Response object
 * // obtained after submitting the transaction.
 * ..............................
 * <p/>
 * <p/>
 * FpsXmlData preXmlData = fraudResp.getFpsPreXmlData();
 * if (preXmlData != null)
 * {
 * // Get the list of Rules.
 * ArrayList rulesList = preXmlData.getRules();
 * if (rulesList != null && rulesList.size()> 0)
 * {
 * Iterator rulesEnum = rulesList.iterator();
 * Rule doRule = null;
 * // Loop through the list of Rules.
 * while (rulesEnum.hasNext())
 * {
 * doRule = (Rule)rulesEnum.next();
 * System.out.println("Rule Number = " + String.valueOf(doRule.getNum()));
 * System.out.println("Rule Id = " + doRule.getRuleId());
 * System.out.println("Rule Alias = " + doRule.getRuleAlias());
 * System.out.println("Rule Description = " + doRule.getRuleDescription());
 * System.out.println("Action = " + doRule.getAction());
 * System.out.println("Triggered Message = " + doRule.getTriggeredMessage());
 * <p/>
 * // Get the list of Rule Vendor Parameters.
 * ArrayList ruleVendorParmsList = doRule.getRuleVendorParms();
 * <p/>
 * if (ruleVendorParmsList != null && ruleVendorParmsList.size() > 0)
 * {
 * Iterator ruleParametersEnum = ruleVendorParmsList.iterator();
 * // Loop through the list of Rule Parameters.
 * while (ruleParametersEnum.hasNext())
 * {
 * RuleParameter doRuleParam = (RuleParameter)ruleParametersEnum.next();
 * System.out.println("Number = " + String.valueOf(doRuleParam.getNum()));
 * System.out.println("Name = " + doRuleParam.getName());
 * System.out.println("Type = " + doRuleParam.getType());
 * System.out.println("Value = " + doRuleParam.getValue());
 * }
 * }
 * }
 */
public class FpsXmlData {


    private ArrayList rules;

    /**
     * Gets the Rules list.
     *
     * @return ArrayList
     */
    public ArrayList getRules() {
        return rules;
    }

    /**
     * constructor
     */
    public FpsXmlData() {
        rules = new ArrayList();
    }

    protected void SetRuleList(ArrayList RuleList) {
        rules = RuleList;
    }


}

