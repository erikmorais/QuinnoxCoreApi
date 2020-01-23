using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;
using Quinnox.OmdbApi.Client;
using Quinnox.OmdbApi.Interfaces;


namespace QuinnoxApi
{
    public class Startup
    {
        private Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.Debug("setting up dependency inject and services");

            try
            {
                services.AddSingleton<IOmdbKey>(new OmdbKey(Configuration.GetSection("AppSettings").GetValue<string>("apiKey")));
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                services.AddHttpClient<IOmdbClient, OmdbClient>(client =>
                {
                    client.BaseAddress = new Uri(Configuration.GetSection("AppSettings").GetValue<string>("OmdbBaseAddress"));
                });

                services.AddSwaggerGen(swagger =>
                {
                    swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Movies API", Version = "v1" });
                });

            }
            catch(Exception ex)
            {
                logger.Error("Error!! " + ex.ToString());
                throw ex;
            }  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            logger.Debug("setting up dependency inject and services");
            try
            {
                if (env.IsDevelopment())
                {
                    logger.Debug("it is a development");
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies API V1");
                });

                app.UseHttpsRedirection();
                app.UseMvc();
            }
            catch(Exception ex)
            {
                logger.Error("Error!! " + ex.ToString());
                throw ex;
            }
        }
    }
}
