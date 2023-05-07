#!/usr/bin/perl
##########################

use Config;
$: = $Config{path_sep};

# You can compile and execute any of the samples provided in the 
# samples package using this batch file.


# Create the classes directory if it does not already exist.
# The compiled sample classes will be put in this directory and
# will be executed from here.
if(! -d './classes')
{
	print `mkdir classes`;
}


# Set the classpath.
# Note: 
# SUN JRE requires to separate the entries in -classpath variables with ";" (Default)
# IBM JRE requires to separate the entries in -classpath variables with ":"
# Change the separator to ";" or ":" according to the the JRE you are using.
$ENV{CLASSPATH} .= "$ENV{CLASSPATH};./lib/payflow.jar";

# ============================================================
# Example
# ============================================================

# This sample by default compiles and executes the sample DOSaleComplete.java
# from file samples\paypal\samples\dataobjects\basictransactions\DOSaleComplete.java.
# Before executing following lines, make sure that you have changed the 
# [user],  [vendor], [partner] and [password]  in 
# DOSaleComplete.java (or any other samples java file that you want to execute)
# to your User, Vendor, Partner and Password, otherwise you will receive either and
# result code 26, Invalid vendor account or a result code 1, User Authentication failed.

# If you have not setup a Payflow USER within PayPal Manger then USER and VENDOR 
# are both your Merchant ID (the login ID you created when you signed up for the Payflow service.)

# Process transaction.

# Compile the sample
# If you want to compile and execute a different sample. Modify the path below to point to
# the required sample .java file to be compiled. Make sure you also point to the correct sample
# to be executed on the next statement.
print `javac -d "classes" paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java`;

# If you want to execute a different sample. Modify the path below to point to
# the required sample class name you are compiling in the above statement.

# Note: 
# SUN JRE requires to separate the entries in -classpath variables with ";" (Default)
# IBM JRE or others requires to separate the entries in -classpath variables with ":"
# Change the separator to ";" or ":" according to the the JRE you are using.

#Execute the sample.
print `java -classpath "./classes;$ENV{CLASSPATH}" paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete`;
$ent=<>;