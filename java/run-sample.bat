@echo off
:: Build the SDK JAR with Maven then compile and run DOSaleComplete
:: Usage: run-sample.bat
:: Prerequisites: JDK 11+, Maven 3.6+

setlocal
set ROOT=%~dp0
set JAR=%ROOT%target\payflow.jar
set SAMPLEBIN=%ROOT%samplebin
set SAMPLESRC=%ROOT%src\paypal\payments\samples\dataobjects\basictransactions\DOSaleComplete.java

echo Building SDK JAR with Maven...
pushd "%ROOT%"
mvn clean package -q
if errorlevel 1 (
    popd
    echo Maven build failed.
    exit /b 1
)
popd

echo Compiling DOSaleComplete sample...
if not exist "%SAMPLEBIN%" mkdir "%SAMPLEBIN%"
javac -cp "%JAR%" -d "%SAMPLEBIN%" "%SAMPLESRC%"
if errorlevel 1 (
    echo Sample compilation failed.
    exit /b 1
)

echo.
echo Running DOSaleComplete...
echo ------------------------------------------------------
java -cp "%JAR%;%SAMPLEBIN%" paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete
