using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Entity.Entity
{
    public class BodyType
    {
        public int Id { get; set; }

        public string Type { get; set; }
        
        public List<Car> Cars { get; set; }
    }
}
