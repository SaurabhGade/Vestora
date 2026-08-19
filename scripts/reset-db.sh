#!/usr/bin/env bash

set -e

echo "WARNING: This will destroy the Vestora database."

read -r -p "Continue? [y/N] " answer

if [[ "$answer" != "y" && "$answer" != "Y" ]]; then
    echo "Cancelled."
    exit 0
fi

echo "Stopping containers..."

docker compose down -v

echo "Starting PostgreSQL..."

docker compose up -d postgres

echo "Waiting for PostgreSQL..."

until docker exec vestora-postgres \
    pg_isready \
    -U vestora \
    -d vestora \
    > /dev/null 2>&1
do
    sleep 1
done

echo "Applying all migrations..."

dotnet ef database update \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api

echo ""
echo "Database reset completed."