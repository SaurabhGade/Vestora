#!/usr/bin/env bash

set -e

echo "======================================"
echo "       Vestora Database Setup"
echo "======================================"

echo ""
echo "[1/3] Starting PostgreSQL..."

docker compose up -d postgres

echo ""
echo "[2/3] Waiting for PostgreSQL..."

until docker exec vestora-postgres \
    pg_isready \
    -U vestora \
    -d vestora \
    > /dev/null 2>&1
do
    sleep 1
done

echo "PostgreSQL is ready."

echo ""
echo "[3/3] Applying EF Core migrations..."

dotnet ef database update \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api

echo ""
echo "======================================"
echo " Database setup completed successfully"
echo "======================================"