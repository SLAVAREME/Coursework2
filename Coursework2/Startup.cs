using Coursework2.Data;
using Coursework2.Data.Interfaces;
using Coursework2.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Coursework2
{
    public class Startup
    {
	    public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
	    public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string fullPath = Path.GetFullPath("..\\Coursework2\\Data\\DB\\Coursework2.mdf");

            string ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =" + fullPath + ";Integrated Security=True";

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(ConnectionString));
            services.AddTransient<ILeading, LeadingRepository>();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 "default",
                 "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
