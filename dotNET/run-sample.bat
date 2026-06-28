@echo off
:: Build and run the C# DOSaleComplete sample (quick connectivity test)
:: Usage: run-sample.bat
::        run-sample.bat vb              (runs the Visual Basic sample instead)
::        run-sample.bat cs net48        (run C# against a specific target framework)
::        run-sample.bat vb net10.0      (run VB against .NET 10)
:: Supported frameworks: net8.0 (default), net10.0, net48

setlocal
set PROJECT=SamplesCS\SamplesCS.csproj
set LABEL=C#
set TFM=net8.0

if /I "%~1"=="vb" (
    set PROJECT=SamplesVB\SamplesVB.vbproj
    set LABEL=VB
)

if not "%~2"=="" set TFM=%~2

echo Building %LABEL% sample [%TFM%]...
dotnet build "%~dp0%PROJECT%" -c Release -f %TFM% --nologo
if errorlevel 1 (
    echo Build failed.
    exit /b 1
)

echo.
echo Running DOSaleComplete...
echo ------------------------------------------------------
dotnet run --project "%~dp0%PROJECT%" -c Release -f %TFM% --no-build
