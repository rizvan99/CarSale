using CarSale.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Infrastructure.Data
{
    public class CarSaleContext : DbContext
    {

        /**
         * base = calling super class constructor
         **/
        public CarSaleContext(DbContextOptions<CarSaleContext> opt) : base(opt)
        {

        }

        public DbSet<Car> Cars { get; set; }


    }
}
