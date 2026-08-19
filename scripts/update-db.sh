#!/usr/bin/env bash

set -e

echo "Applying Vestora database migrations..."

dotnet ef database update \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api

echo ""
echo "Database is up to date."