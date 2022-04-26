@echo off
cls

rem You will need to change the USER, VENDOR, PARTNER and PASSWORD to your
rem User, Vendor, Partner and Password as specified when you signed up with
rem the Payflow Pro service.

set USER=user
set VENDOR=vendor
set PARTNER=partner
set PASSWORD=password

rem Send request using name-value-pairs
pfpro400.exe -gatewaytimeout 45 -host https://pilot-payflowpro.paypal.com -logfile log.txt -contenttype text/namevalue -request "USER=%USER%&VENDOR=%VENDOR%&PARTNER=%PARTNER%&PWD=%PASSWORD%&TENDER=C&TRXTYPE=A&ACCT=5105105105105100&EXPDATE=1209&STREET=123 Main St.&CVV2=123&VERBOSITY=MEDIUM&AMT=1.00" 

rem Send request using XMLPay
rem pfpro400.exe -gatewaytimeout 45 -host https://pilot-payflowpro.paypal.com -logfile log.txt -contenttype text/xml -request "<?xml version='1.0' encoding='UTF-8'?><XMLPayRequest version='2.0' xmlns='http://www.paypal.com/XMLPay'><RequestData><Vendor>%VENDOR%</Vendor><Partner>%PARTNER%</Partner><Transactions><Transaction><Authorization><PayData><Invoice><BillTo><Name>Sam Spade</Name><Address><Street>123 4th street</Street><City>San Jose</City><State>CA</State><Zip>95032</Zip><Country>USA</Country></Address></BillTo><TotalAmt>24.97</TotalAmt></Invoice><Tender><Card><CardType>visa</CardType><CardNum>5105105105105100</CardNum><ExpDate>201211</ExpDate><NameOnCard/></Card></Tender></PayData></Authorization></Transaction></Transactions></RequestData><RequestAuth><UserPass><User>%USER%</User><Password>%PASSWORD%</Password></UserPass></RequestAuth></XMLPayRequest>"

pause