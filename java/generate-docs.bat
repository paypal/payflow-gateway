@echo off
:: Generate the Payflow Java SDK API reference (Javadoc)
:: Output: target/site/apidocs/index.html
:: Prerequisites: JDK 11+, Maven 3.6+

pushd "%~dp0"
echo Generating Javadoc for Payflow Java SDK...
call "%~dp0mvnw.cmd" javadoc:javadoc --no-transfer-progress
if errorlevel 1 (
    popd
    echo Javadoc generation failed.
    exit /b 1
)
popd

echo.
echo Done. Open: %~dp0target\site\apidocs\index.html
