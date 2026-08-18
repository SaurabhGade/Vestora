#!/bin/bash

set -x


# Function to kill all background processes on exit
cleanup() {
    echo "Shutting down all Vestora services..."
    kill $(jobs -p) 2>/dev/null
}

# Trap Ctrl+C and exit signals to trigger cleanup
trap cleanup EXIT SIGINT SIGTERM

# Start components in the background
dotnet run --project ./api/Vestora.Api &
dotnet run --project ./auth/Vestora.auth &
yarn --cwd ./ui/Vestora.UI dev &

# Wait keeps the script alive to capture logs
wait
