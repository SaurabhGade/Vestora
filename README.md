**While build new setup following commands**


**Pull postgres image from docker**

`bash`
 docker compose up -d


**Migrate schema into database**
`bash`
dotnet ef database update \
 --project dal/Vestora.DAL \
 --startup-project auth/Vestora.Auth