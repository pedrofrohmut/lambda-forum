using System;
using System.Linq;
using Lib.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Data.Seed
{
  public static class SeedData
  {
    private static DateTime now = DateTime.Now;

    private static Forum[] forums = new Forum[]
    {
      new Forum
      {
        Title = "Python",
        Description = "A popular dynamic, strongly typed general purpose programming language with focus on readability",
        CreatedAt = now,
        ImageUrl = "/images/forums/python.png",
      },
      new Forum
      {
        Title = "CSharp",
        Description = "An Object-oriented programming language for building applications on the .Net Framework",
        CreatedAt = now,
        ImageUrl = "/images/forums/csharp.png",
      },
      new Forum
      {
        Title = "Haskell",
        Description = "A popular functional programming language",
        CreatedAt = now,
        ImageUrl = "/images/forums/haskell.png",
      },
      new Forum
      {
        Title = "JavaScript",
        Description = "Multi-paradigm language based on the ECMAScript specification",
        CreatedAt = now,
        ImageUrl = "/images/forums/javascript.png",
      },
      new Forum
      {
        Title = "Go",
        Description = "Open-source statically-typed programming language developed at Google",
        CreatedAt = now,
        ImageUrl = "/images/forums/go.png",
      },
    };

    public static void Initialize(IServiceProvider serviceProvider)
    {
      var requiredService = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

      using (var context = new ApplicationDbContext(requiredService))
      {
        if (!context.Forums.Any())
        {
          context.AddRange(forums);
          context.SaveChanges();
        }
      }
    }
  }
}