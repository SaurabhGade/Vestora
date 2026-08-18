#!/bin/bash

set -x

dotnet ef migrations add AddConfigSettings \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api \
    --output-dir Data/Migrations


if [[ $? == 0 ]]; then
  dotnet ef database update \
    --project dal/Vestora.DAL \
    --startup-project api/Vestora.Api
fi
