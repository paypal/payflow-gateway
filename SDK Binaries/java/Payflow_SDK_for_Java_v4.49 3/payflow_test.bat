@echo off
cls

REM ============================================================
REM You can compile and execute any of the samples provided in the 
REM samples package using this batch file.
REM ============================================================

REM Set the classpath.
REM Note: 
REM SUN JRE requires to separate the entries in -classpath variables with ";" (Default)
REM IBM JRE requires to separate the entries in -classpath variables with ":"
REM Change the separator to ";" or ":" according to the the JRE you are using.
set CLASSPATH=%CLASSPATH%;.\lib\payflow.jar;

REM Create the classes directory if it does not already exist.
REM The compiled sample classes will be put in this directory and
REM will be executed from here.
IF NOT EXIST .\classes mkdir .\classes

REM ============================================================
REM Example
REM ============================================================

REM This sample by default compiles and executes the sample DOSaleComplete.java
REM from file samples\paypal\samples\dataobjects\basictransactions\DOSaleComplete.java
REM Before executing following lines, make sure that you have changed the 
REM [user],  [vendor], [partner] and [password]  in 
REM DOSaleComplete.java (or any other samples java file that you want to execute)
REM to your User, Vendor, Partner and Password, otherwise you will receive either and
REM result code 26, Invalid vendor account or a result code 1, User Authentication failed.

REM If you have not setup a Payflow USER within PayPal Manger then USER and VENDOR 
REm are both your Merchant ID (the login ID you created when you signed up for the Payflow service.)

REM Process transaction.

REM If you want to execute a different sample. Modify the path below to point to
REM the required sample .java file to be compiled. Make sure you also point to the correct sample
REM to be executed on the next statement.
javac -d "classes" paypal\payments\samples\dataobjects\basictransactions\DOSaleComplete.java

REM If you want to execute a different sample. Modify the path below to point to
REM the required sample class name you are compiling in the above statement.

REM Note: 
REM SUN JRE requires to separate the entries in -classpath variables with ";" (Default)
REM IBM JRE requires to separate the entries in -classpath variables with ":"
REM Change the separator to ";" or ":" according to the the JRE you are using.

java -classpath "classes;%CLASSPATH%" paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete

pause