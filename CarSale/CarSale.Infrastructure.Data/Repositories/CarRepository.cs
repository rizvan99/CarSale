using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
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
            var newCar = _ctx.Add(car);
            _ctx.SaveChanges();
            return newCar.Entity;
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
            return _ctx.Cars;
        }

        public Car ReadCarById(int id)
        {
            return _ctx.Cars.FirstOrDefault(c => c.Id == id);
        }

        public Car UpdateCar(Car carToUpdate)
        {
            var carUpdated = _ctx.Cars.Update(carToUpdate);
            _ctx.SaveChanges();
            return carUpdated.Entity;

        }
    }
}
