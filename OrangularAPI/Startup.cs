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
using OrangularAPI.Database.Entities;

using OrangularAPI.Database;
using OrangularAPI.Services.addresses;
using OrangularAPI.Repositories.addresses;
using OrangularAPI.Services.users;
using OrangularAPI.Repositories.users;
// -- tilf�jet af Victor -- //

using OrangularAPI.Services.users;
using OrangularAPI.Repositories.users;
// -- tilf�jet af Victor -- //


namespace Orangular
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
            // -- tilf�jet af Victor -- //
            // Forbinder sql serveren
            services.AddControllers();
            services.AddDbContext<OrangularProjectContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Default")));

            // -- tilf�jet af Victor -- //


            // ---- Victor --- //
            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IAddressesRepository, AddressesRepository>(); 
            // ---- Victor --- //

            // -- tilf�jet af Victor -- //

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
           
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
