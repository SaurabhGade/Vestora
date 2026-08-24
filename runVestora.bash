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

if [[ $? == 0 ]]; then
  dotnet run --project ./api/Vestora.Api &
else
  echo "Clean up failed";
  return 1;
fi
if [[ $1 == 0 ]]; then
  dotnet run --project ./auth/Vestora.auth &
else
  echo "Unable to run API Project";  
  return 2;
fi
if [[$1 == 0]]; then
  yarn --cwd ./ui/Vestora.UI dev &
else
  echo "Unable to run UI Project";
  return 3;
fi
# Wait keeps the script alive to capture logs
wait
