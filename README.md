# Lambda Forum

  FullStack AspNetCore MVC Forum

MVC:

  scaffolded a new dotnet mvc project
    $ dotnet new mvc --auth Individual --no-https --output Mvc
    $ dotnet sln add Mvc\Mvc.csproj

  gitignore made at gitignore.io

  add classlib for data
    $ dotnet new classlib -o Lib.Data
    $ dotnet sln add Lib.Data\Lib.Data.csproj

  @classlib Data created Models:
    ApplicationDbContext
    ApplicationUser : IdentityUser
    Forum
    Post
    PostReply

  @Mvc add project ref to classlib Data

  Env var for connection string

  Add service DbContext + EF + PostgreSQL

  Add Connection String to Dev Env:
    $ dotnet user-secrets set "ConnectionStrings:PostgreSQL:LambdaForumDb" "..."

  Add Migrations: Initial
    $ dotnet build
    $ dotnet ef migrations add InitialCreate --project Lib.Data/ --output-dir 
    Lib.Data/Migrations --startup-project Mvc/
    (*to undone $ dotnet ef migrations remove)

  Run Migration to Database 
    $ dotnet ef database update --project Lib.Data/ --startup-project Mvc/
