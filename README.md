Get Starting

use for migrations "dotnet ef migrations add "App2" --project ../DataMatrix.Data/DataMatrix.Data.csproj --context DataContext"
then use the "dotnet ef database update --project ../DataMatrix.Data/DataMatrix.Data.csproj --context DataContext"

After executing these commands, a PostgreSQL database will be created.

I've decided to employ a Layered Architecture approach for this task, utilizing PostgreSQL as the database backend.


