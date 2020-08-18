using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Uplift.DataAccess.Mapping;
using Uplift.UI.Configuration;
using Westwind.AspNetCore.LiveReload;

namespace Uplift.UI
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
            services.RegisterServices(Configuration);

            services.AddMvcConfiguration();

            services.AddIdentityConfiguration();

            services.AddRazorPages();

            services.AddTypeHandlers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvcConfiguration(env);
        }
    }
}
