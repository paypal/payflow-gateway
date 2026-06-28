#!/usr/bin/env bash
# Build the SDK JAR with Maven then compile and run DOSaleComplete
# Usage: ./run-sample.sh
# Prerequisites: JDK 11+, Maven 3.6+

set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
JAR="$SCRIPT_DIR/target/payflow.jar"
SAMPLE_BIN="$SCRIPT_DIR/samplebin"
SAMPLE_SRC="$SCRIPT_DIR/src/paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java"

# Step 1: Build SDK JAR
echo "Building SDK JAR with Maven..."
(cd "$SCRIPT_DIR" && ./mvnw clean package -q)

# Step 2: Compile sample
echo "Compiling DOSaleComplete sample..."
mkdir -p "$SAMPLE_BIN"
javac -cp "$JAR" -d "$SAMPLE_BIN" "$SAMPLE_SRC"

# Step 3: Run
echo ""
echo "Running DOSaleComplete..."
echo "------------------------------------------------------"
java -cp "$JAR:$SAMPLE_BIN" paypal.payments.samples.dataobjects.basictransactions.DOSaleComplete
