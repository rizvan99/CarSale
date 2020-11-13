using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Application_Service.Service
{
    public class BodyTypeService : IBodyTypeService
    {

        private readonly IBodyTypeRepository _typeRepo;
        public BodyTypeService(IBodyTypeRepository typeRepo)
        {
            _typeRepo = typeRepo;
        }

        public BodyType CreateType(BodyType type)
        {
            return _typeRepo.CreateType(type);
        }

        public BodyType DeleteType(int id)
        {
            return _typeRepo.DeleteType(id);
        }

        public IEnumerable<BodyType> ReadAllTypes()
        {
            return _typeRepo.GetAllTypes();
        }

        public BodyType ReadTypeById(int id)
        {
            return _typeRepo.GetTypeFromId(id);
        }

        public BodyType ReadTypeWithCars(int id)
        {
            return _typeRepo.GetTypesWithCars(id);
        }

        public BodyType UpdateType(BodyType typeToUpdate)
        {
            return _typeRepo.UpdateType(typeToUpdate);
        }
    }
}
