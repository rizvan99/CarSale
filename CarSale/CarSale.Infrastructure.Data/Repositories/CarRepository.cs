using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Car> ReadAllCars()
        {
            return _ctx.Cars;
        }

        public Car ReadCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Car UpdateCar(Car carToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
