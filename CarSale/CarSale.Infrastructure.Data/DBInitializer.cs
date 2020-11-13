using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Entity.Entity;
using CarSale.Core.Entity.Login;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Infrastructure.Data
{
    public class DBInitializer : IDBInitializer
    {
        private readonly IAuthenticationService _authService;
        public DBInitializer(IAuthenticationService aut)
        {
            _authService = aut;
        }

        public void SeedDB(CarSaleContext ctx)
        {
            

            //To avoid duplicate seeding
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            #region Users
            //Users
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            _authService.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            _authService.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };
            ctx.Users.AddRange(users);
            #endregion

            var hatchback = new BodyType()
            {
                Type = "Hatchback"
            };
            ctx.BodyTypes.Add(hatchback);

            var sedan = new BodyType()
            {
                Type = "Sedan"
            };
            ctx.BodyTypes.Add(sedan);

            var minivan = new BodyType()
            {
                Type = "Minivan"
            };
            ctx.BodyTypes.Add(minivan);




            var car1 = new Car()
            {
                Name = "Golf 3",
                Brand = "Volkswagen",
                Body = hatchback,
                Color = "Red",
                ModelYear = DateTime.Now.AddYears(-20),
                Price = 8000
            };
            ctx.Cars.Add(car1);


            var car2 = new Car()
            {
                Name = "Traveller",
                Brand = "Peugeot",
                Body = minivan,
                Color = "Grey",
                ModelYear = DateTime.Now.AddYears(-1),
                Price = 32000
            };
            ctx.Cars.Add(car2);


            var car3 = new Car()
            {
                Name = "320d",
                Brand = "BMW",
                Body = sedan,
                Color = "Black",
                ModelYear = DateTime.Now.AddYears(-8),
                Price = 84000
            };
            ctx.Cars.Add(car3);


            //Saving after adding all
            ctx.SaveChanges();

        }

    }
}
