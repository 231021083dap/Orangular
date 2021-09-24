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
using Orangular.Database;
using Orangular.Services.addresses;
using Orangular.Repositories.addresses;
using Orangular.Services.users;
using Orangular.Repositories.users;
// -- tilf�jet af Victor -- //

using Orangular.Services.users;
using Orangular.Repositories.users;
using Orangular.Repositories.order_items;
using Orangular.Services.order_items;
using Orangular.Repositories.order_lists;
using Orangular.Services.Order_List;
using Orangular.Services.products;
using Orangular.Services;
using Orangular.Repositories.products;
using Orangular.Repositories;
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
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // -- tilf�jet af Victor -- //
            // Forbinder sql serveren
            services.AddControllers();
            services.AddDbContext<OrangularProjectContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Default")));

            // -- tilf�jet af Victor -- //

            //Addedd by Muhmen
            //These two lines refering to Service, and Repository files and Interfaces
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // ---- Victor --- //
            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IAddressesRepository, AddressesRepository>();
            // ---- Victor --- //

            // -- tilf�jet af Victor -- //
            // Tilføjer scope til OrderLists services & repository
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            // Tilføjer scope til OrderLists services & repository
            services.AddScoped<IOrder_ListsService, Order_ListsService>();
            services.AddScoped<IOrder_ListsRepository, Order_ListsRepository>();

            // Tilføjer scope til OrderItems services & repository
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            // Tilføjer scope til User services & repository
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

            app.UseCors(CORSRules);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
