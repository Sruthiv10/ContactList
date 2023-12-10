
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using ContactList.Infrastructure.Repositories;
using ContactList.Application.Interface;
using ContactList.Core.Interface;
using ContactList.Core;
using ContactList.Infrastructure.Repositories;
using ContactList.Application.ContactList;
using System.Reflection;
using System.Data;
using ContactList.Core.Common;
using ContactList.API.Shared;
using ContactList.API.Authentication;
using Microsoft.AspNetCore.Authentication;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

   
    public void ConfigureServices(IServiceCollection services)
    {      
        #region DbContext
        services.AddDbContext<ContactDBContext>(options =>
     options.UseSqlServer(
         Configuration.GetConnectionString("ContactDBConnection")));
        
        #endregion
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
        services.AddMemoryCache();
       // services.AddAutoMapper(typeof(Startup));    
        services.AddTransient<IContactListRepository, ContactListRepository>();
        services.AddTransient<IContactListService, ContactListService>();
        services.AddTransient<IContactListAppService, ContactListAppService>();
        services.AddAutoMapper(typeof(EntityMapper).GetTypeInfo().Assembly, typeof(ModelMapper).GetTypeInfo().Assembly);
        services.AddHttpClient();
        services.AddAuthentication("BasicAuthentication")
       .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            c.RoutePrefix = "swagger";
        });
        app.UseHttpsRedirection();
        app.UseRouting();      
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
