#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
HELP_DIR="$SCRIPT_DIR/Help"
PORT=8080
URL="http://localhost:$PORT/"

if [[ ! -d "$HELP_DIR" ]]; then
    echo "ERROR: Help/ directory not found. Build the docs first:" >&2
    echo "  dotnet msbuild PayflowSDKDocs.shfbproj /p:Configuration=Release" >&2
    exit 1
fi

open_browser() {
    if command -v xdg-open &>/dev/null; then
        xdg-open "$URL" &
    elif command -v open &>/dev/null; then
        open "$URL"
    else
        echo "Open $URL in your browser."
    fi
}

# Try dotnet-serve first (already required for the project)
if dotnet tool list -g 2>/dev/null | grep -qi "dotnet-serve"; then
    :
else
    echo "Installing dotnet-serve (one-time)..."
    dotnet tool install -g dotnet-serve
fi

if command -v dotnet-serve &>/dev/null || dotnet tool list -g 2>/dev/null | grep -qi "dotnet-serve"; then
    echo "Serving docs at $URL"
    echo "Press Ctrl+C to stop."
    open_browser
    dotnet serve -p "$PORT" -d "$HELP_DIR"
    exit 0
fi

# Fallback: Python
if command -v python3 &>/dev/null; then
    echo "Serving docs at $URL  (via Python)"
    echo "Press Ctrl+C to stop."
    open_browser
    cd "$HELP_DIR"
    python3 -m http.server "$PORT"
    exit 0
fi

if command -v python &>/dev/null; then
    echo "Serving docs at $URL  (via Python)"
    echo "Press Ctrl+C to stop."
    open_browser
    cd "$HELP_DIR"
    python -m http.server "$PORT"
    exit 0
fi

echo "ERROR: Could not find dotnet-serve or Python. Install one and re-run." >&2
exit 1
