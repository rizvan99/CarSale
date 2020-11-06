using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Infrastructure.Data
{
    public interface IDBInitializer
    {
        public void SeedDB(CarSaleContext ctx);
    }
}
