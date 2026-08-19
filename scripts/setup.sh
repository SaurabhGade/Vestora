#!/usr/bin/env bash

set -e

echo "Setting up Vestora..."

echo ""
echo "Starting infrastructure..."
docker compose up -d postgres

echo ""
echo "Waiting for PostgreSQL..."

until docker exec vestora-postgres \
    pg_isready \
    -U vestora \
    -d vestora \
    > /dev/null 2>&1
do
    sleep 1
done

echo "PostgreSQL ready."

echo ""
echo "Restoring .NET dependencies..."
dotnet restore Vestora.slnx

echo ""
echo "Applying database migrations..."
dotnet ef database update \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api

echo ""
echo "Installing UI dependencies..."
cd ui/Vestora.UI
yarn install

echo ""
echo "======================================"
echo " Vestora setup completed!"
echo "======================================"