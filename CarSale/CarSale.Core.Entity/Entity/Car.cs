using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Entity.Entity
{
    public class Car
    {
        public int Id { get; set; }

        //e.g. Golf 4, 320d, C63 AMG
        public string Name { get; set; }

        //e.g. Volkswagen, BMW, Mercedes
        public string Brand { get; set; }

        //e.g. Sedan, Hatchback, Stationcar, Minivan, Coupe
        public string Body { get; set; }

        public double Price { get; set; }

        public string Color { get; set; }

        public DateTime ModelYear { get; set; }

    }
}
