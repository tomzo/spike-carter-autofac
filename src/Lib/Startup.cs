namespace MyCarterApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Carter;
    using FluentValidation;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class MyAssemblyCatalog : DependencyContextAssemblyCatalog {
        public override IReadOnlyCollection<Assembly> GetAssemblies() {
            var assemblies = new [] { typeof(HomeModule).Assembly }; 
            return assemblies;
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }

        public static void ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called.
            // This registration of assembly with carter modules is necessary for tests to work.
            // see https://github.com/CarterCommunity/Carter/pull/88
            services.AddCarter(new MyAssemblyCatalog());
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you. If you
        // need a reference to the container, you need to use the
        // "Without ConfigureContainer" mechanism shown later.
        public static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MyAutofacModule());
        }

        // Configure is where you add middleware. This is called after
        // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public static void Configure(IApplicationBuilder app)
        {
            app.UseCarter();            
        }
    }
}
