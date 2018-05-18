Payflow client SDK for Windows v3 patch
=======================================

**This is a temporary solution for v3 integrations that cannot be immediately upgrades.**  It is *strongly* recommended for you to upgrade to either the new SDKs or use the HTTPS interface.  The V3 SDK will no longer be supported in the near future.

If you are using the V3 Payflow client SDK for Windows and are not able to connect using SSL v3 protocol, you can download the [Payflow-Windows-v3-patch](Payflow-Windows-v3-patch.zip) as temporary solution.  Once you download the and unzip the file to your server, you will then need to replace the appropriate DLL, EXE or LIB files from your current integration.  Next, you will need to change the end point to one of the following URLs to use the patch:
 
- Live - https://payflowpro.paypal.com
- Test - https://pilot-payflowpro.paypal.com
 
Once you have made the changes you can verify the Client SDK you are using by looking at the transaction details within the Payflow Manager.
