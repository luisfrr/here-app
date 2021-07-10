using Here.DbContext;
using Here.Models.Domain;
using Here.WebApp.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Here.WebApp
{
  public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
      services.AddDbContext<HereDbContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("HereDbConnection"),
          ServerVersion.AutoDetect(Configuration.GetConnectionString("HereDbConnection"))
          )
        );
      services.AddDefaultIdentity<ApplicationUser>(options =>
      {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
      })
        .AddRoles<ApplicationRole>()
        .AddEntityFrameworkStores<HereDbContext>();
      //services.AddDatabaseDeveloperPageExceptionFilter();
      //services.AddRazorPages();
      services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
      UserManager<ApplicationUser> userManager,
      RoleManager<ApplicationRole> roleManager)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
        IdentityDataInitializer.SeedDefaultUser(userManager, roleManager);
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

      app.UseAuthentication();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
        //endpoints.MapRazorPages();
        endpoints.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Login}/{id?}");
      });
		}
	}
}
