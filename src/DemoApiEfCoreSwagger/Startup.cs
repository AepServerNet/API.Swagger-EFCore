using System;
using DemoApiEfCoreSwagger.Models.Services.Application;
using DemoApiEfCoreSwagger.Models.Services.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DemoApiEfCoreSwagger
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Demo API EfCore Swagger", 
                    Version = "v1",
                    Description = "API example that returns the current time",
                    TermsOfService = new Uri("https://example.com/terms"), 

                    Contact = new OpenApiContact
                    {
                        Name = "Nominativo contatto",
                        Email = "Email contatto",
                        Url = new Uri("https://twitter.com/username-contatto"),
                    },

                    License = new OpenApiLicense
                    {
                        Name = "Nome licenza API",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

            services.AddDbContextPool<MyDatabaseDbContext>(optionsBuilder => {
                string connectionString = Configuration.GetSection("ConnectionStrings").GetValue<string>("Default");
                optionsBuilder.UseSqlite(connectionString);
            });

            services.AddTransient<IPersoneService, EfCorePersoneService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApiEfCoreSwagger v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
