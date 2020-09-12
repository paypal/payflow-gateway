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

import java.text.DecimalFormat;

/**
 * This class is used as the currency data type
 * by all data and transaction objects.
 * <p>This class should be used to denote any
 * currency parameter. By default, the currency code is
 * USD (US Dollars).</p>
 *
 * @paypal.sample Following example shows how to use this class.
 * .............
 * //inv is the Invoice object
 * .............
 * <p/>
 * //Set the currency object.
 * Currency mt = new Currency(new Double(25.12));
 * // A valid amount is a two decimal value.
 * // For values which have more than two decimal places
 * Currency amt = new Currency(new Double(25.1214));
 * amt.setNoOfDecimalDigits( 2);
 * //If the NoOfDecimalDigits property is used then it is mandatory to set one of the following properties to true.
 * amt.setRound (true);
 * amt.setTruncate (true);
 * <p/>
 * //Set the amount in the invoice object
 * inv.setAmt( Amt);
 * .............
 */
public final class Currency extends BaseRequestDataObject {

    private Double currencyValue;
    private String currencyCode = "USD";
    private boolean round = false;
    private boolean truncate = false;
    private int noOfDecimalDigits = 2;

    /**
     * Constructor
     *
     * @param currValue Double
     *                  <p>Currency code is set as default USD.</p>
     * @paypal.sample .............
     * //inv is the Invoice object
     * .............
     * <p/>
     * //Set the invoice amount.
     * inv.setAmt(new Currency(new Double(25.12)));
     * <p/>
     * .............
     */

    public Currency(Double currValue) {
        currencyValue = currValue;
    }

    /**
     * Constructor.
     *
     * @param currencyValue Double Currency value
     * @param currCode      String 3 letter Currency code
     *                      <p>Currency code if not given is set as default USD.</p>
     * @paypal.sample .............
     * //inv is the Invoice object
     * .............
     * <p/>
     * //Set the invoice amount.
     * inv.setAmt(new Currency(new Double(25.12),"USD"));
     * <p/>
     * .............
     */

    public Currency(Double currencyValue, String currCode) {
        this(currencyValue);
        if (currCode != null && currCode.length() > 0) {
            currencyCode = currCode;
        }
    }


    protected String roundCurrencyValue(String currStringValue, int noOfdecimalDigits) {

        StringBuffer retVal = new StringBuffer(currStringValue);

        if (retVal.length() == 0) {
            return PayflowConstants.EMPTY_STRING;
        }

        int indexOfDecimal = retVal.indexOf(".");
        int length = retVal.length();

        if (indexOfDecimal > 0 && indexOfDecimal < length) {
            if (indexOfDecimal == length - 1) {
                for (int i = 0; i < noOfdecimalDigits; i++) {
                    retVal.append("0");
                }
            } else if (noOfdecimalDigits == 0) {
                retVal = new StringBuffer(retVal.substring(0, indexOfDecimal));
            } else {
                int lenAfterTruncate = indexOfDecimal + noOfdecimalDigits + 1;

                if (lenAfterTruncate > length) {
                    int padding = lenAfterTruncate - length;
                    for (int i = 0; i < padding; i++) {
                        retVal.append("0");
                    }
                } else if (lenAfterTruncate < length) {
                    int trimming = length - lenAfterTruncate;
                    int endLen = length - 1;
                    for (int i = 0; i < trimming; i++) {
                        int val = Integer.parseInt(retVal.substring(endLen, 1));
                        if (val >= 5) {
                            int roundVal = Integer.parseInt(retVal.substring(endLen - 1, 1));
                            roundVal += 1;
                            if (roundVal >= 10) {
                                roundVal = 1;
                            }
                            retVal = retVal.delete(endLen - 1, 2);
                            retVal = retVal.insert(endLen - 1, Integer.toString(roundVal));
                        } else {
                            retVal = retVal.delete(endLen, 1);
                        }
                        endLen -= 1;
                    }
                }
            }

        }
        return retVal.toString();
    }


    protected String truncateCurrencyValue(String currStringValue, int noOfdecimalDigits) {

        String retVal;
        retVal = currStringValue;
        if (retVal == null || retVal.length() == 0) {
            return PayflowConstants.EMPTY_STRING;
        }

        int indexOfDecimal = retVal.indexOf(".");
        int length = retVal.length();
        if (indexOfDecimal > 0 && indexOfDecimal <= length - 1) {
            if (indexOfDecimal == length - 1) {
                for (int i = 1; i < noOfdecimalDigits; i++) {
                    retVal += "0";
                }
            } else if (noOfdecimalDigits == 0) {
                retVal = retVal.substring(0, indexOfDecimal);
            } else {
                int lenAfterTruncate = indexOfDecimal + noOfdecimalDigits + 1;

                if (lenAfterTruncate > length) {
                    int padding = lenAfterTruncate - length;
                    for (int i = 0; i < padding; i++) {
                        retVal += "0";
                    }
                } else if (lenAfterTruncate < length) {
                    retVal = retVal.substring(0, lenAfterTruncate);
                }
            }
        }
        return retVal;
    }


    /**
     * Overrides ToString
     *
     * @return String</returns>
     *         <p>Formats string value of currency in format "$.CC"</p>
     * @paypal.sample .............
     * //inv is the Invoice object
     * .............
     * <p/>
     * //Set the invoice amount.
     * inv.setAmt (new Currency(new Double(25.12),"USD"));
     * String currValue = inv.ToString();
     * .............
     */
    public String toString() {
        try {
            //Overridden toString. Returns held Currency Value.
            String retVal = PayflowConstants.EMPTY_STRING;
            // We need to double check here whether currency value
            //is non-zero positive before converting it.
            if (noOfDecimalDigits < 0) {
                noOfDecimalDigits = 2;
            }

            if (round && truncate) {
                //
                ErrorObject err = PayflowUtility.populateCommError(PayflowConstants.E_CURRENCY_PROCESS_ERROR, null, PayflowConstants.SEVERITY_FATAL, false, null);
                if (getContext() == null) {
                    setContext(new Context());
                }
                getContext().addError(err);
            } else if (round) {
                String format = ".0";
                for (int i = 1; i < noOfDecimalDigits; i++) {
                    format = format + "0";
                }
                DecimalFormat decFormat = new DecimalFormat(format);
                retVal = decFormat.format(currencyValue);

            } else if (truncate) {
                retVal = truncateCurrencyValue(currencyValue.toString(), noOfDecimalDigits);
            } else {
                retVal = currencyValue.toString();
            }

            int startIndex = retVal.indexOf(".");
            if (startIndex < 0 && noOfDecimalDigits == 0) {
                return retVal;
            } else {
                if (startIndex < 0)
                    retVal += ".00";
                //         substring(startIndex, retVal.length()-startIndex);
                //String tempStr = retVal.substring(startIndex + 1, retVal.length() - startIndex - 1);
                //int len = tempStr.length();
                int len = retVal.substring(startIndex, retVal.length() - 1).length();
                if (len < 2 && noOfDecimalDigits != 0) {
                    for (int i = len; i < 2; i++)
                        retVal = retVal + "0";
                }
                //  currencyValue = new Double(doubleValue);
                return retVal;
            }
        }

        catch (
                Exception ex
                )

        {
            ErrorObject err = new ErrorObject(PayflowConstants.SEVERITY_FATAL, "", ex.toString());
            if (getContext() == null) {
                setContext(new Context());
            }
            getContext().addError(err);
            return PayflowConstants.EMPTY_STRING;
        }
    }

    /**
     * Gets the currency code.
     *
     * @return currencyCode
     */
    public String getCurrencyCode() {
        return this.currencyCode;
    }

    /**
     * Sets the number of decimal digits required after rounding or truncation.
     *
     * @param noOfDecimalDigits int
     */
    public void setNoOfDecimalDigits(int noOfDecimalDigits) {
        this.noOfDecimalDigits = noOfDecimalDigits;
    }

    /**
     * Sets Currency value rounding flag to true.
     *
     * @param round boolean .
     *              Note that only one of round OR truncate can be set to true.
     */
    public void setRound(boolean round) {
        this.round = round;
    }

    /**
     * Sets Currency value truncate flag to true.
     *
     * @param truncate boolean .
     *                 Note that only one of round OR truncate can be set to true.
     */

    public void setTruncate(boolean truncate) {
        this.truncate = truncate;
    }

    /**
     * Gets the error generated by the class.This should be used in case the toString() return blank.
     *
     * @return error String
     */
    public String getError() {
        if (getContext() != null) {
            return getContext().toString();
        }
        return PayflowConstants.EMPTY_STRING;
    }

}

