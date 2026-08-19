#!/usr/bin/env bash

set -e

if [ -z "$1" ]; then
    echo "Usage:"
    echo "./scripts/create-migration.sh MigrationName"
    exit 1
fi

MIGRATION_NAME="$1"

echo "Creating migration: $MIGRATION_NAME"

dotnet ef migrations add "$MIGRATION_NAME" \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api \
    --output-dir Data/Migrations

echo ""
echo "Migration '$MIGRATION_NAME' created."