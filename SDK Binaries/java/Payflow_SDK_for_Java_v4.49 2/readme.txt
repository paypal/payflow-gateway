Copyright (c) 2020 PayPal Inc. All Rights Reserved

PAYFLOW SDK FOR JAVA README
----------------------------

- For testing the SDK use the payflow_test.bat/payflow_test.pl with the release package. Please make necessary changes in this file before executing.
The required changes have been mentioned within the files.
- Sample code on how to use the Payflow java SDK can be found in the samples directory shipped with this release.
- Go through the docs shipped with this release for java API of public classes of the SDK

INITIALIZING THE SDK PROPERTIES
--------------------------------
- Go through the API for paypal.payflow.SDKProperties class for information on the properties of the SDK that can be set.
- Note that if you are setting the SDKProperties, it must be the first thing you do in your code. These are system parameters of the SDK.
It is important that you do not modify it anywhere else for predictable behavior of the SDK.
- Parameters overriding the SDKProperties can be passed in constructors of certain classes. for example.: some constructors of paypal.payflow.PayflowAPI,
or paypal.payflow.PayflowConnectionData etc will override SDKProperties such as hostAddress, time out etc.
- SDKProperties have been used in the samples shipped with this release. You can use the samples as a guide for your code.

CONFIGURING THE LOGGER
----------------------
- By Default the logging is off.
- Use SDKProperties.setLogFileName(String logFileName) to set the log file name and path.
- Use SDKProperties.setLoggingLevel(int loggingLevel) to modify the logging level.
- Use SDKProperties.setMaxLogFileSize(int size) to set the max log file size (in bytes). The log file will be archived beyond this size.
- Possible values for loggingLevel in descending order:
	- PayflowConstants.LOGGING_OFF
	- PayflowConstants.SEVERITY_FATAL
	- PayflowConstants.SEVERITY_ERROR
	- PayflowConstants.SEVERITY_WARN
	- PayflowConstants.SEVERITY_INFO
	- PayflowConstants.SEVERITY_DEBUG
