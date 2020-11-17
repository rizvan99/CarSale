using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSale.Infrastructure.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private CarSaleContext _ctx;

        public CarRepository(CarSaleContext ctx)
        {
            _ctx = ctx;
        }

        public Car CreateCar(Car car)
        {
            /* Another way of adding, works too
            if (car.Body != null)
            {
                _ctx.Attach(car.Body);
            }
            var newCar = _ctx.Cars.Add(car).Entity;
            _ctx.SaveChanges();
            return newCar;*/

            _ctx.Attach(car).State = EntityState.Added;
            _ctx.SaveChanges();
            return car;
        }

        public Car DeleteCar(int id)
        {
            var carToDelete = ReadCarById(id);
            if (carToDelete != null)
            {
                _ctx.Cars.Remove(carToDelete);
                _ctx.SaveChanges();
            }

            return carToDelete;
            
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _ctx.Cars
                .AsNoTracking()
                .Include(c => c.Body);
        }

        public Car ReadCarById(int id)
        {
            return _ctx.Cars
                .AsNoTracking()
                .Include(c => c.Body)
                .FirstOrDefault(c => c.Id == id);
        }

        public Car UpdateCar(Car carToUpdate)
        {
            var carUpdated = _ctx.Cars.Update(carToUpdate);
            _ctx.SaveChanges();
            return carUpdated.Entity;

        }
    }
}
