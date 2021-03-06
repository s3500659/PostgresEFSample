using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PostgresEF.Data;
using PostgresEF.Factory;
using PostgresEF.Factory.Interfaces;
using PostgresEF.Interfaces;
using PostgresEF.Models.Interfaces;
using PostgresEF.Repositories;
using PostgresEF.Repositories.Interfaces;
using PostgresEF.Services;
using System;
using Newtonsoft.Json.Serialization;

namespace PostgresEF
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
            services.AddDbContext<DataContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDataContext>(provider => provider.GetService<DataContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IToyRepository, ToyRepository>();

            services.AddScoped<IToyFactory, ToyFactory>();

            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            services.AddScoped<ITodoItemFactory, TodoItemFactory>();

            services.AddScoped<IProductFactory, ProductFactory>();

            services.AddScoped<ICommanderRepository, CommandRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PostgresEF", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = 
                    new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
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
