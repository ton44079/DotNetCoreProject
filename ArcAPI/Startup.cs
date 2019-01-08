using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArcAPI.Service.Implements;
using ArcAPI.Service.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ArcAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //    services.AddTransient<ICompanyService, CompanyService>();
        //}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            // Add framework services.
            services.AddMvc();
            //services.AddDbContext<DBModel>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ServiceModule());
            //builder.RegisterAssemblyTypes(Assembly.Load("ArcAPI.Service")).Where(e => e.Name.EndsWith("Service", StringComparison.CurrentCulture));
            builder.Populate(services);
            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
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
                app.UseHsts();
            }

            app.UseCors(builder =>
                //   builder.WithOrigins("http://example.com")
                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
           );

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private class ServiceModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {

                builder.RegisterAssemblyTypes(Assembly.Load("ArcAPI.Service"))
                    .Where(t => t.Name.EndsWith("Service", StringComparison.Ordinal))
                    .AsImplementedInterfaces();

            }
        }
    }


}
