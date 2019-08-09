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
