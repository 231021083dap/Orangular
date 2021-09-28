using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrangularAPI.Database;
using OrangularAPI.Repositories.AddressesRepository;
using OrangularAPI.Repositories.CategoryRepository;
using OrangularAPI.Repositories.OrderItemsRepository;
using OrangularAPI.Repositories.OrderListsRepository;
using OrangularAPI.Repositories.ProductsRepository;
using OrangularAPI.Repositories.Users;
using OrangularAPI.Services.AddressServices;
using OrangularAPI.Services.CategoryServices;
using OrangularAPI.Services.OrderItemServices;
using OrangularAPI.Services.OrderListServices;
using OrangularAPI.Services.ProductServices;
using OrangularAPI.Services.UsersService;
using System.Text.Json.Serialization;

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

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // --- sql connect --- //
            services.AddDbContext<OrangularProjectContext>
            (o => o.UseSqlServer(Configuration.GetConnectionString("Default")));
            // --- sql connect --- //

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IOrderListService, OrderListService>();
            services.AddScoped<IOrderListRepository, OrderListRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();            
            

            // --- Scopes (Service og Repository) --- //
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

            // Not sure what this is. Victor
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
