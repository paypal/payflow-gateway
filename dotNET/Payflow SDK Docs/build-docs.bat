@echo off
setlocal EnableDelayedExpansion

set "DOCS_DIR=%~dp0"
set "SDK_PROJ=%~dp0..\PFProSDK\PFProSDK.csproj"

echo Building PFProSDK (Release)...
dotnet build "%SDK_PROJ%" -c Release
if !ERRORLEVEL! neq 0 (
    echo ERROR: PFProSDK build failed.
    exit /b 1
)

echo.
echo Building SHFB documentation...
dotnet msbuild "%DOCS_DIR%PayflowSDKDocs.shfbproj" /p:Configuration=Release
if !ERRORLEVEL! neq 0 (
    echo ERROR: SHFB documentation build failed.
    echo Ensure Sandcastle Help File Builder is installed:
    echo   https://github.com/EWSoftware/SHFB/releases
    exit /b 1
)

echo.
echo Documentation built successfully. Output: %DOCS_DIR%Help\
echo Run view-docs.bat to open in browser.
