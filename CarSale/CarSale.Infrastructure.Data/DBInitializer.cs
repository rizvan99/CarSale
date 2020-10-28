using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Infrastructure.Data
{
    public class DBInitializer
    {
        public void SeedDB(CarSaleContext ctx)
        {
            //To avoid duplicate seeding
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            var car1 = new Car()
            {
                Name = "Golf 3",
                Brand = "Volkswagen",
                Body = "Hatchback",
                Color = "Red",
                ModelYear = DateTime.Now.AddYears(-20),
                Price = 8000
            };
            ctx.Cars.Add(car1);


            var car2 = new Car()
            {
                Name = "Traveller",
                Brand = "Peugeot",
                Body = "Minivan",
                Color = "Grey",
                ModelYear = DateTime.Now.AddYears(-1),
                Price = 32000
            };
            ctx.Cars.Add(car2);


            var car3 = new Car()
            {
                Name = "320d",
                Brand = "BMW",
                Body = "Sedan",
                Color = "Black",
                ModelYear = DateTime.Now.AddYears(-8),
                Price = 84000
            };
            ctx.Cars.Add(car3);


            //Saving after adding all cars
            ctx.SaveChanges();

        }

    }
}
