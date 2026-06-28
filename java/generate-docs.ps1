# Generate the Payflow Java SDK API reference (Javadoc)
# Output: target/site/apidocs/index.html
# Prerequisites: JDK 11+, Maven 3.6+

$ErrorActionPreference = "Stop"
$root = $PSScriptRoot

Write-Host "Generating Javadoc for Payflow Java SDK..." -ForegroundColor Cyan
Push-Location $root
mvn javadoc:javadoc --no-transfer-progress
if ($LASTEXITCODE -ne 0) { Pop-Location; Write-Error "Javadoc generation failed."; exit 1 }
Pop-Location

$index = Join-Path $root "target\site\apidocs\index.html"
Write-Host ""
Write-Host "Done. Open: $index" -ForegroundColor Green
