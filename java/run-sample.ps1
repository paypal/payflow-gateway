# Build the SDK JAR with Maven then compile and run DOSaleComplete
# Usage: .\run-sample.ps1
# Prerequisites: JDK 11+, Maven 3.6+

$ErrorActionPreference = "Stop"
$root = $PSScriptRoot

# Step 1: Build SDK JAR
Write-Host "Building SDK JAR with Maven..." -ForegroundColor Cyan
Push-Location $root
& "$root\mvnw.cmd" clean package -q
if ($LASTEXITCODE -ne 0) { Pop-Location; Write-Error "Maven build failed."; exit 1 }
Pop-Location

$jar = Join-Path $root "target\payflow.jar"
$sampleBin = Join-Path $root "samplebin"
$sampleSrc = Join-Path $root "src\paypal\payments\samples\dataobjects\basictransactions\DOSaleComplete.java"

# Step 2: Compile sample
Write-Host "Compiling DOSaleComplete sample..." -ForegroundColor Cyan
New-Item -ItemType Directory -Force -Path $sampleBin | Out-Null
javac -cp $jar -d $sampleBin $sampleSrc
if ($LASTEXITCODE -ne 0) { Write-Error "Sample compilation failed."; exit 1 }

# Step 3: Run
Write-Host ""
Write-Host "Running DOSaleComplete..." -ForegroundColor Cyan
Write-Host "------------------------------------------------------"
java -cp "$jar;$sampleBin" paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete
