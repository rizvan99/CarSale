using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Application_Service.Service;
using CarSale.Core.Domain_Service.Interface;
using CarSale.Infrastructure.Data;
using CarSale.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

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

            // DATABASE
            services.AddDbContext<CarSaleContext>
                (
                    opt => opt.UseSqlite("Data Source=carsale.db").EnableSensitiveDataLogging().EnableSensitiveDataLogging(), ServiceLifetime.Transient
                );


            // AAVOID REFERENCE LOOP
            services.AddControllers().AddNewtonsoftJson
                (x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



            // LOGIN AUTHENTICATION
            //Bytes to generate key for signing JWT tokens
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            //Adding JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });


            //Dependency inject helper class and use with byte array
            services.AddSingleton<IAuthenticationService>(new AuthenticationService(secretBytes));


            // SWAGGER
            //To be done


            // CROSS-ORIGIN RESOURCE SHARING
            services.AddCors(options =>
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    })
            );

            services.AddTransient<IDBInitializer, DBInitializer>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetService<CarSaleContext>();
                    var dbInitializer = services.GetService<IDBInitializer>();
                    dbInitializer.SeedDB(dbContext);
                }
            }

            app.UseHttpsRedirection();


            

            

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
