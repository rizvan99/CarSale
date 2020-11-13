using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Application_Service.Interface
{
    public interface IBodyTypeService
    {
        // CREATE
        public BodyType CreateType(BodyType type);


        // READ
        public IEnumerable<BodyType> ReadAllTypes();
        public BodyType ReadTypeById(int id);
        public BodyType ReadTypeWithCars(int id);


        // UPDATE
        public BodyType UpdateType(BodyType typeToUpdate);


        // DELETE
        public BodyType DeleteType(int id);


    }
}
