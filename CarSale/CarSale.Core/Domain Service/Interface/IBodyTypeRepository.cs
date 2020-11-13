using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Domain_Service.Interface
{
    public interface IBodyTypeRepository
    {
        // CREATE
        public BodyType CreateType(BodyType type);


        // READ
        public IEnumerable<BodyType> GetAllTypes();
        public BodyType GetTypeFromId(int id);
        public BodyType GetTypesWithCars(int id);

        // UPDATE
        public BodyType UpdateType(BodyType typeToUpdate);


        // DELETE
        public BodyType DeleteType(int id);



    }
}
