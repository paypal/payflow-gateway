# Build and run the C# DOSaleComplete sample (quick connectivity test)
# Usage: .\run-sample.ps1
#        .\run-sample.ps1 -VB              to run the Visual Basic sample instead
#        .\run-sample.ps1 -Framework net48 to run against a specific target framework
#        .\run-sample.ps1 -VB -Framework net10.0

param(
    [switch]$VB,
    [ValidateSet("net8.0","net10.0","net48")]
    [string]$Framework = "net8.0"
)

$ErrorActionPreference = "Stop"
$root = $PSScriptRoot

if ($VB) {
    $project = Join-Path $root "SamplesVB\SamplesVB.vbproj"
    Write-Host "Building SamplesVB (VB .NET) [$Framework]..." -ForegroundColor Cyan
} else {
    $project = Join-Path $root "SamplesCS\SamplesCS.csproj"
    Write-Host "Building SamplesCS (C#) [$Framework]..." -ForegroundColor Cyan
}

dotnet build $project -c Release -f $Framework --nologo
if ($LASTEXITCODE -ne 0) { Write-Error "Build failed."; exit 1 }

Write-Host ""
Write-Host "Running DOSaleComplete..." -ForegroundColor Cyan
Write-Host "------------------------------------------------------"
dotnet run --project $project -c Release -f $Framework --no-build
