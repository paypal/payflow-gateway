@echo off
setlocal EnableDelayedExpansion

set "MAVEN_WRAPPER_PROPERTIES=%~dp0.mvn\wrapper\maven-wrapper.properties"
set "WRAPPER_CACHE=%USERPROFILE%\.m2\wrapper\dists"

if not exist "%MAVEN_WRAPPER_PROPERTIES%" (
    echo [mvnw] ERROR: .mvn\wrapper\maven-wrapper.properties not found.
    exit /b 1
)

rem Read distributionUrl from properties file
set "DIST_URL="
for /f "usebackq tokens=1,* delims==" %%a in ("%MAVEN_WRAPPER_PROPERTIES%") do (
    if "%%a"=="distributionUrl" set "DIST_URL=%%b"
)

if "!DIST_URL!"=="" (
    echo [mvnw] ERROR: distributionUrl not found in maven-wrapper.properties.
    exit /b 1
)

rem Derive names:  apache-maven-3.9.9-bin.zip -> apache-maven-3.9.9-bin -> apache-maven-3.9.9
for %%f in ("!DIST_URL!") do set "DIST_FILENAME=%%~nxf"
set "DIST_NAME=%DIST_FILENAME:.zip=%"
set "MAVEN_DIRNAME=%DIST_NAME:-bin=%"

set "DIST_DIR=%WRAPPER_CACHE%\%DIST_NAME%"
set "MAVEN_HOME=%DIST_DIR%\%MAVEN_DIRNAME%"
set "MVN_CMD=%MAVEN_HOME%\bin\mvn.cmd"

if exist "%MVN_CMD%" goto :run

echo [mvnw] Maven not found locally. Downloading from:
echo [mvnw]   !DIST_URL!
echo [mvnw] This is a one-time download (~10 MB). Please wait...

if not exist "%DIST_DIR%" mkdir "%DIST_DIR%"

powershell -NoProfile -Command ^
    "Invoke-WebRequest -Uri '!DIST_URL!' -OutFile '%DIST_DIR%\%DIST_FILENAME%' -UseBasicParsing"
if errorlevel 1 (
    echo [mvnw] ERROR: Download failed.
    exit /b 1
)

powershell -NoProfile -Command ^
    "Expand-Archive -Path '%DIST_DIR%\%DIST_FILENAME%' -DestinationPath '%DIST_DIR%' -Force"
if errorlevel 1 (
    echo [mvnw] ERROR: Extraction failed.
    exit /b 1
)

del "%DIST_DIR%\%DIST_FILENAME%"

if not exist "%MVN_CMD%" (
    echo [mvnw] ERROR: Maven executable not found after extraction: %MVN_CMD%
    exit /b 1
)

echo [mvnw] Maven downloaded to: %MAVEN_HOME%
echo.

:run
"%MVN_CMD%" %*
