using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using OrangularAPI.Database;
using OrangularAPI.Repositories.addresses;
using OrangularAPI.Repositories.users;
using OrangularAPI.Services.AddressService;
using OrangularAPI.Services.UsersService;

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

            services.AddControllers();

            // --- sql connect --- //
            services.AddDbContext<OrangularProjectContext>
            (o => o.UseSqlServer(Configuration.GetConnectionString("Default")));
            // --- sql connect --- //


            // --- Scopes --- //
            // This is where we are pointing to concrete implementations
            // when using these interfaces
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressesRepository, AddressesRepository>(); 
            // --- Scopes --- //

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
