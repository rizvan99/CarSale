using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Application_Service.Service;
using CarSale.Core.Domain_Service.Interface;
using CarSale.Infrastructure.Data;
using CarSale.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarSale.WebAPI
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

            //DATABASE
            services.AddDbContext<CarSaleContext>
                (
                    opt => opt.UseSqlite("Data Source=carsale.db").EnableSensitiveDataLogging(), ServiceLifetime.Transient
                );


            //Avoid reference loop
            services.AddControllers().AddNewtonsoftJson
                (x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<CarSaleContext>();
                    new DBInitializer().SeedDB(ctx);
                    //DBInitializer.SeedDB(ctx);
                }
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
