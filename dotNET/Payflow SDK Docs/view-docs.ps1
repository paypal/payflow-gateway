#Requires -Version 5.1
<#
.SYNOPSIS
    Serves the SHFB Help output over HTTP and opens it in the default browser.
.DESCRIPTION
    The SHFB Website output uses JavaScript that modern browsers block when loaded
    directly from disk (file:// protocol). This script starts a local HTTP server
    so the docs work correctly.
#>

$helpDir = Join-Path $PSScriptRoot "Help"
$port    = 8080
$url     = "http://localhost:$port/"

if (-not (Test-Path $helpDir)) {
    Write-Error "Help/ directory not found. Build the docs first:`n  dotnet msbuild PayflowSDKDocs.shfbproj /p:Configuration=Release"
    exit 1
}

$serveExe = Join-Path $env:USERPROFILE ".dotnet\tools\dotnet-serve.exe"

# Install dotnet-serve if not already installed
$installed = dotnet tool list -g 2>$null | Select-String "dotnet-serve"
if (-not $installed) {
    Write-Host "Installing dotnet-serve (one-time)..." -ForegroundColor Cyan
    dotnet tool install -g dotnet-serve
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Failed to install dotnet-serve. Install it manually: dotnet tool install -g dotnet-serve"
        exit 1
    }
}

Write-Host "Serving docs at $url" -ForegroundColor Cyan
Write-Host "Press Ctrl+C to stop." -ForegroundColor Yellow
Start-Process $url

& $serveExe -p $port -d $helpDir
