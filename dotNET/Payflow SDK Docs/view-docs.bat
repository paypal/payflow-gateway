@echo off
setlocal EnableDelayedExpansion

set "HELP_DIR=%~dp0Help"
set "PORT=8080"
set "URL=http://localhost:%PORT%/"
set "SERVE_EXE=%USERPROFILE%\.dotnet\tools\dotnet-serve.exe"

if not exist "%HELP_DIR%" (
    echo ERROR: Help\ directory not found. Build the docs first:
    echo   dotnet msbuild PayflowSDKDocs.shfbproj /p:Configuration=Release
    exit /b 1
)

rem Install dotnet-serve if not already present
dotnet tool list -g 2>nul | findstr /i "dotnet-serve" >nul
if !ERRORLEVEL! neq 0 (
    echo Installing dotnet-serve (one-time^)...
    dotnet tool install -g dotnet-serve
    if !ERRORLEVEL! neq 0 (
        echo ERROR: Failed to install dotnet-serve.
        echo Install manually: dotnet tool install -g dotnet-serve
        exit /b 1
    )
)

echo Serving docs at %URL%
echo Press Ctrl+C to stop.
start "" "%URL%"

"%SERVE_EXE%" -p %PORT% -d "%HELP_DIR%"
