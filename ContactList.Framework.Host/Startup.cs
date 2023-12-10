//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Azure.WebJobs;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using RFL.TechStack.Application;
//using RFL.TechStack.Application.Interface;
//using RFL.TechStack.Core;
//using RFL.TechStack.Core.Entities;
//using RFL.TechStack.Core.Interface;
//using RFL.TechStack.Framework.Host.Extension;
//using RFL.TechStack.Infrastructure.Blob;
//using RFL.TechStack.Infrastructure.Repositories;
//using Serilog;
//using Serilog.Events;
//using Serilog.Sinks.Datadog.Logs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using RFL.TechStack.Core.Common;
//using RFL.TechStack.Application.PurchaseOrder;
//using Microsoft.Azure.Amqp.Framing;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;

//namespace RFL.TechStack.Framework.Host
//{
//    public  class Startup
//    {
       
//        public static IFunctionsHostBuilder Configure(IFunctionsHostBuilder builder, IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            #region Serilog

//            var assemblyName = Assembly.GetCallingAssembly().GetName()?.Name?.Replace('.', '_');           
//            if (Enum.IsDefined(typeof(Enums.LogAnalyticWorkspaceAssemblies), assemblyName))
//            {
//                ConfigureSerilogWithLogAnalytic(builder.Services, assemblyName);
//            }
//            else
//            {
//                ConfigureSerilogWithInsight(builder.Services);
//            }
            
//            #endregion Serilog
           
//            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);
//            builder.Services.AddAppConfiguration(configuration);           

//            ConfigureService(builder.Services);
//            return builder;

//            //if (env.IsDevelopment())
//            //{
//            //    app.UseDeveloperExceptionPage();
//            //}
//            //else
//            //{
//            //    // Add production error handling here
//            //}

//            app.UseHttpsRedirection();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//        public static IWebJobsBuilder Configure(IWebJobsBuilder builder)
//        {
//            #region Serilog
//            ConfigureSerilogWithInsight(builder.Services);            
//            #endregion Serilog            
//            var configuration = BuildConfiguration(Environment.CurrentDirectory);
//            builder.Services.AddAppConfiguration(configuration);        
//            string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings");
//            builder.Services.AddDbContext<TECHDBContext>(
//              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
//            #region AutoMapper
//            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//            //builder.Services.AddAutoMapper(typeof(EntityMapper).GetTypeInfo().Assembly, typeof(ModelMapper).GetTypeInfo().Assembly);
//            #endregion AutoMapper
//            builder.Services.TryAddScoped<IPurchaseorderEntryAppService, PurchaseorderEntryAppService>();
//            builder.Services.TryAddScoped<IPurchaseorderEntryService, PurchaseorderEntryService>();
//            builder.Services.TryAddScoped<IPurchaseorderEntryRepository, PurchaseorderEntryRepository>();
           


//            ConfigureService(builder.Services);
//            #region removed
//            //string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
//            //builder.Services.AddDbContext<NECDBContext>(
//            //  options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
//            //#region AutoMapper
//            //builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//            ////builder.Services.AddAutoMapper(typeof(EntityMapper).GetTypeInfo().Assembly, typeof(ModelMapper).GetTypeInfo().Assembly);
//            //#endregion AutoMapper
//            //builder.Services.TryAddScoped<IOrderEntryRepository, OrderEntryRepository>();
//            //builder.Services.TryAddScoped<IOrderEntryService, OrderEntryService>();
//            //builder.Services.TryAddScoped<IOrderEntryAppService, OrderEntryAppService>();

//            #endregion removed
//            return builder;
//        }
//        public static IConfiguration BuildConfiguration(string applicationRootPath)
//        {
//            var config =
//                new ConfigurationBuilder()
//                    .SetBasePath(applicationRootPath)
//                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
//                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
//                    .AddEnvironmentVariables()
//                    .Build();

//            return config;
//        }

//        private static void ConfigureService(IServiceCollection service)
//        {
//            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
//            service.AddDbContext<TECHDBContext>(
//              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
//            #region AutoMapper
//            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//            //builder.Services.AddAutoMapper(typeof(EntityMapper).GetTypeInfo().Assembly, typeof(ModelMapper).GetTypeInfo().Assembly);
//            #endregion AutoMapper
           
//            #region Blob Storage 
            
           
           
//            #endregion
           

//        }

//        private static void ConfigureSerilogWithInsight(IServiceCollection service)
//        {
//            var appinsightConnection = Environment.GetEnvironmentVariable("ApplicationInsightConnection");
//            var filepath = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")) ? @"D:\home\LogFiles\Application\log.txt" : "log.txt";
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Information()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
//                .MinimumLevel.Override("Worker", LogEventLevel.Error)
//                .MinimumLevel.Override("Host", LogEventLevel.Error)
//                .MinimumLevel.Override("System", LogEventLevel.Error)
//                .MinimumLevel.Override("Function", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Storage.Blobs", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Core", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Messaging.ServiceBus", LogEventLevel.Error)
//                .MinimumLevel.Override("DurableTask.AzureStorage", LogEventLevel.Error)
//                .MinimumLevel.Override("DurableTask.Core", LogEventLevel.Error)
//                .Enrich.WithProperty("Application", System.Reflection.Assembly.GetExecutingAssembly())
//                .Enrich.FromLogContext()
//                .WriteTo.DatadogLogs("XXXXXXXXXXX", configuration: new DatadogConfiguration() { Url = "https://http-intake.logs.datadoghq.eu" }, logLevel: LogEventLevel.Debug)
//                .WriteTo.Console()
//                //.WriteTo.File(filepath, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
//                .WriteTo.File(filepath, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
//                // .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = "065cb9ec-312a-45cc-b9a6-ed3b7b15dc8c" }, new CustomTelemetryTraceConverter())
//                .WriteTo.ApplicationInsights(appinsightConnection, new CustomTelemetryEventConverter())
//                //.WriteTo.ApplicationInsights(GetTelemetryClient("InstrumentationKey=065cb9ec-312a-45cc-b9a6-ed3b7b15dc8c;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/")
//                .CreateLogger();

//            service.AddLogging(lb =>
//            {
//                //lb.ClearProviders(); //--> if used nothing works...
//                lb.AddSerilog(Log.Logger, true);
//            });
//        }
//        private static void ConfigureSerilogWithLogAnalytic(IServiceCollection service, string logAnalyticName)
//        {
//            var logName = $"{logAnalyticName}_Log";
//            var logWorkspaceId = Environment.GetEnvironmentVariable("LogWorkspaceId");
//            var logWorkspaceKey = Environment.GetEnvironmentVariable("LogWorkspaceKey");
//            var filepath = !string.IsNullOrEmpty(System.Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")) ? @"D:\home\LogFiles\Application\log.txt" : "log.txt";
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Information()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
//                .MinimumLevel.Override("Worker", LogEventLevel.Error)
//                .MinimumLevel.Override("Host", LogEventLevel.Error)
//                .MinimumLevel.Override("System", LogEventLevel.Error)
//                .MinimumLevel.Override("Function", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Storage.Blobs", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Core", LogEventLevel.Error)
//                .MinimumLevel.Override("Azure.Messaging.ServiceBus", LogEventLevel.Error)
//                .MinimumLevel.Override("DurableTask.AzureStorage", LogEventLevel.Error)
//                .MinimumLevel.Override("DurableTask.Core", LogEventLevel.Error)
//                .Enrich.WithProperty("Application", System.Reflection.Assembly.GetExecutingAssembly())
//                .Enrich.FromLogContext()
//                //.WriteTo.DatadogLogs("XXXXXXXXXXX", configuration: new DatadogConfiguration() { Url = "https://http-intake.logs.datadoghq.eu" }, logLevel: LogEventLevel.Debug)
//                .WriteTo.Console()
//                //.WriteTo.File(filepath, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
//                .WriteTo.File(filepath, rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Information)
//                .WriteTo.AzureAnalytics(logWorkspaceId, logWorkspaceKey, logName)
//                //.WriteTo.ApplicationInsights(GetTelemetryClient("InstrumentationKey=065cb9ec-312a-45cc-b9a6-ed3b7b15dc8c;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/")
//                .CreateLogger();

//            service.AddLogging(lb =>
//            {
//                //lb.ClearProviders(); //--> if used nothing works...
//                lb.AddSerilog(Log.Logger, true);
//            });
//        }


//    }
//}
