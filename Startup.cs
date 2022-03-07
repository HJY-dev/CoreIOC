using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoreIOC.Extensions;
using CoreIOC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreIOC
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
            //Autofac 控制器属性注入
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                c.IncludeXmlComments(Path.Combine(basePath, "Project.xml"), true);
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreIOC", Version = "v1" });
                c.IgnoreObsoleteActions();
                c.DocInclusionPredicate((docName, description) => true);
            });

            //默认自带的注入服务
            //services.AddScoped<ITestService, TestService>();


        }

        /// <summary>
        /// Autofac
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule());
        }

        /// <summary>
        /// Autofac 容器
        /// </summary>
        public ILifetimeScope AutofacContainer { get; private set; }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //调试 autofac 属性注册
            //this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            //var servicenamed = this.AutofacContainer.Resolve<ITestService>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreIOC v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
