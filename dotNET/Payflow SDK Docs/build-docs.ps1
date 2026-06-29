#Requires -Version 5.1
<#
.SYNOPSIS
    Builds the SHFB API documentation for the Payflow .NET SDK.
.DESCRIPTION
    Compiles PFProSDK in Release (to regenerate the XML doc file) then runs
    the Sandcastle Help File Builder project to produce the Help/ website output.
    Requires SHFB to be installed: https://github.com/EWSoftware/SHFB/releases
#>

$docsDir  = $PSScriptRoot
$sdkProj  = Join-Path $docsDir "..\PFProSDK\PFProSDK.csproj"
$shfbProj = Join-Path $docsDir "PayflowSDKDocs.shfbproj"

Write-Host "Building PFProSDK (Release)..." -ForegroundColor Cyan
dotnet build $sdkProj -c Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "PFProSDK build failed."
    Read-Host "Press Enter to exit"
    exit 1
}

Write-Host ""
Write-Host "Building SHFB documentation..." -ForegroundColor Cyan
dotnet msbuild $shfbProj /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "SHFB documentation build failed.`nEnsure Sandcastle Help File Builder is installed: https://github.com/EWSoftware/SHFB/releases"
    Read-Host "Press Enter to exit"
    exit 1
}

Write-Host ""
Write-Host "Documentation built successfully." -ForegroundColor Green
Write-Host "Output: $docsDir\Help\"
Write-Host "Run .\view-docs.ps1 to open in browser."
Write-Host ""
Read-Host "Press Enter to exit"
