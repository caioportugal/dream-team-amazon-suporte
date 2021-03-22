using System;
using System.Text.Json.Serialization;
using Amazon.Suporte.Constants;
using Amazon.Suporte.Setup.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Amazon.Suporte.Database;
namespace Amazon.Suporte
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
            services.AddControllers().AddJsonOptions(options =>
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddMvc();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = Environment.GetEnvironmentVariable(EnvironmentVariable.APITitle),
                    Version = Environment.GetEnvironmentVariable(EnvironmentVariable.APIVersion)
                });
            });
            services.AddDbContext<SupportDBContext>(options => options.UseMySql(DefineConnectionString()));
            services.RegisterServices();
        }

        private string DefineConnectionString()
        {
            var server = Environment.GetEnvironmentVariable(EnvironmentVariable.DBServer) ?? string.Empty;
            var port = Environment.GetEnvironmentVariable(EnvironmentVariable.DBPort) ?? string.Empty;
            var user = Environment.GetEnvironmentVariable(EnvironmentVariable.DBUser) ?? string.Empty;
            var databaseName = Environment.GetEnvironmentVariable(EnvironmentVariable.DBName) ?? string.Empty;
            var password = Environment.GetEnvironmentVariable(EnvironmentVariable.DBPassword) ?? string.Empty;
            return @$"Server={server};
                   Port={port};
                   Database={databaseName};
                   Uid={user};
                   Pwd={password};";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Environment.GetEnvironmentVariable(EnvironmentVariable.SwaggerEndpoint),
                                 Environment.GetEnvironmentVariable(EnvironmentVariable.APIVersion));
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepDB.ExecuteMigrations(app);
        }
    }
}
