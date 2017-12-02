using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ColorName.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace ColorName
{
    public class Startup
    {
        private IConfiguration _configuration;

        // There is Dependency Injection everywhere!
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?tabs=aspnetcore2x#commandline-configuration-provider
            // E.g. 'dotnet run key1=value1'
            // or '"args": ["db=mssql"],' in '.vscode/launch.json'.
            services.AddDbContext<ColorNameContext>(options =>
            {
                if (_configuration["db"] == "mssql")
                {
                    options.UseSqlServer("Initial Catalog=ColorName;User Id=SA;Password=Passw0rd!");
                }
                else
                {
                    options.UseSqlite("Data Source=ColorName.db");
                }
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.GetFullPath("ClientApp")),
                    RequestPath = new PathString("/debug")
                });
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}
