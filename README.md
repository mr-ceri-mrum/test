Get Starting

use for migrations :"dotnet ef migrations add "App2" --project ../DataMatrix.Data/DataMatrix.Data.csproj --context DataContext"
-
then use the :"dotnet ef database update --project ../DataMatrix.Data/DataMatrix.Data.csproj --context DataContext".
After executing these commands, a PostgreSQL database will be created.


I've decided to employ a Layered Architecture approach for this task, utilizing PostgreSQL as the database backend.

I have a DataMatrix.API where the controllers are located. When you run this project, it will launch together with Swagger UI, providing a convenient way to use our API.There, in our Program.cs, is where the configuration of our application takes place.
-------------------

In "DataMatrix.Core," the application's core logic resides, including the Repository where all the logic is described. In IRepository, our interfaces and the base interface are located. All interfaces inherit from the base one. And in the Repository have a all implementations are located. I've decided to use LINQ for the queries, But I coud use SQL if I need.
-------------------

In DataMatrix.Domain, all the main models and entities for interacting with them are located. I have a directory called ActionResponse where I store regular responses for methods.In the Entities derictory have a base Entities. I have a main entity for. When we create a new entity, we can override the primary key, which can be either an integer or a GUID it's comfortable. in Enums we have OrderStatus. You can see that when a denial status occurs, it starts with 101. This is done for convenient scaling of statuses.
------------------

In DataMatrix.Data, my dataContext resides, where interaction with the database occurs.
-


