using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Lib.Data.Models;
using Microsoft.EntityFrameworkCore;
using Lib.Data.Services;
using Lib.Services;

namespace Mvc
{
  public class Startup
  {
    public Startup(IConfiguration configuration) { Configuration = configuration; }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddEntityFrameworkNpgsql()
        .AddDbContext<ApplicationDbContext>(options =>
          options.UseNpgsql(Configuration["ConnectionStrings:PostgreSQL:LambdaForumDb"]));

      services.AddDefaultIdentity<IdentityUser>()
          .AddDefaultUI(UIFramework.Bootstrap4)
          .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddScoped<IForums, ForumsService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseAuthentication();

      app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"));
    }
  }
}
