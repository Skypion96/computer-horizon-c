﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerHorizon.Controllers;
using ComputerHorizon.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ComputerHorizon
{
    public class Startup
    {
        private static readonly string PATH_ANGULAR_APP = "wwwroot/js";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSpaStaticFiles(spa => spa.RootPath = PATH_ANGULAR_APP); // modifier
            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles(); //modifier
            app.UseSpaStaticFiles(); // modifier
            app.UseMvc();
            app.UseSpa(spa => spa.Options.SourcePath = PATH_ANGULAR_APP);
            
        }
    }
}


    