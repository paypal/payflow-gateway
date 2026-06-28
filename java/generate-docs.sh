#!/usr/bin/env bash
# Generate the Payflow Java SDK API reference (Javadoc)
# Output: target/site/apidocs/index.html
# Prerequisites: JDK 11+, Maven 3.6+

set -euo pipefail
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

echo "Generating Javadoc for Payflow Java SDK..."
(cd "$SCRIPT_DIR" && ./mvnw javadoc:javadoc --no-transfer-progress)

echo ""
echo "Done. Open: $SCRIPT_DIR/target/site/apidocs/index.html"
