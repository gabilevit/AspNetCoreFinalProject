using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFinalProject.Data;
using AspNetCoreFinalProject.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreFinalProject
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetSiteContext>(options => options.UseSqlServer(connectionString));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
        }
      
        public void Configure(IApplicationBuilder app, PetSiteContext psx)
        {
            psx.Database.EnsureDeleted();            
            psx.Database.EnsureCreated();
            app.UseStaticFiles();
            app.UseRouting();          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Home}/{action=HomePage}/{id?}");
            });
        }
    }
}
