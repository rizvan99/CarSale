using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSale.Infrastructure.Data.Repositories
{
    public class BodyTypeRepository : IBodyTypeRepository
    {

        private readonly CarSaleContext _ctx;

        public BodyTypeRepository(CarSaleContext context)
        {
            _ctx = context;
        }


        public BodyType CreateType(BodyType type)
        {
            var newCar = _ctx.BodyTypes.Add(type).Entity;
            _ctx.SaveChanges();
            return newCar;
        }

        public BodyType DeleteType(int id)
        { 
            var typeDeleted = _ctx.BodyTypes.FirstOrDefault(type => type.Id == id);
            if (typeDeleted != null)
            {
                _ctx.Remove(typeDeleted);
                _ctx.SaveChanges();
            }

            return typeDeleted;

        }

        public IEnumerable<BodyType> GetAllTypes()
        {
            return _ctx.BodyTypes;
        }

        public BodyType GetTypeFromId(int id)
        {
            return _ctx.BodyTypes.AsNoTracking()
                .FirstOrDefault(bt => bt.Id == id);
        }

        public BodyType GetTypesWithCars(int id)
        {
            return _ctx.BodyTypes
                .AsNoTracking()
                .Include(t => t.Cars)
                .FirstOrDefault(ty => ty.Id == id);
            
        }

        public BodyType UpdateType(BodyType typeToUpdate)
        {
            var updatedType = _ctx.Update(typeToUpdate).Entity;
            _ctx.SaveChanges();
            return updatedType;
        }
    }
}
