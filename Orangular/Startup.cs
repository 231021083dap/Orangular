using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// -- tilf�jet af Victor -- //
using Orangular.Database.Entities;
using Orangular.Services.categories;
using Orangular.Repositories.categories;
// -- tilf�jet af Victor -- //

namespace Orangular
{
    public class Startup
    {

        private readonly string CORSRules = "CORSRules";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // HI
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSRules,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            // -- tilf�jet af Victor -- //
            // Forbinder sql serveren
            services.AddDbContext<OrangularProjectContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString("Default")));
            // -- tilf�jet af Victor -- //

            services.AddControllers();
            //Addedd by Muhmen
            //These two lines refering to Service, and Repository files and Interfaces
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orangular", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orangular v1"));
            }

            // skal implementeres Victor 
            //services.AddControllers().AddJsonOptions(x =>
            //{
            //    // serialize enums as strings in api responses (e.g. Role)
            //    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});


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
