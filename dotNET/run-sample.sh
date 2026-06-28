#!/usr/bin/env bash
# Build and run the C# DOSaleComplete sample (quick connectivity test)
# Usage: ./run-sample.sh
#        ./run-sample.sh vb              (runs the Visual Basic sample instead)
#        ./run-sample.sh cs net48        (run C# against a specific target framework)
#        ./run-sample.sh vb net10.0      (run VB against .NET 10)
# Supported frameworks: net8.0 (default), net10.0, net48

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
LANG_ARG="${1:-cs}"
TFM="${2:-net8.0}"

if [[ "$LANG_ARG" == "vb" ]]; then
    PROJECT="$SCRIPT_DIR/SamplesVB/SamplesVB.vbproj"
    LABEL="VB"
else
    PROJECT="$SCRIPT_DIR/SamplesCS/SamplesCS.csproj"
    LABEL="C#"
fi

echo "Building $LABEL sample [$TFM]..."
dotnet build "$PROJECT" -c Release -f "$TFM" --nologo

echo ""
echo "Running DOSaleComplete..."
echo "------------------------------------------------------"
dotnet run --project "$PROJECT" -c Release -f "$TFM" --no-build
