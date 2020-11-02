using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarSale.Core.Application_Service.Service
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepo;

        public CarService(ICarRepository carRepository)
        {
            _carRepo = carRepository;
        }

        public Car CreateCar(Car car)
        {
            return _carRepo.CreateCar(car);
        }

        public Car DeleteCar(int id)
        {
            if (_carRepo.DeleteCar(id) == null || id <= 0)
            {
                throw new InvalidDataException("Car not found");
            }
            return _carRepo.DeleteCar(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _carRepo.ReadAllCars();
        }

        public Car GetCarById(int id)
        {
            return _carRepo.ReadCarById(id);
        }

        public Car UpdateCar(Car carToUpdate)
        {
            return _carRepo.UpdateCar(carToUpdate);
        }
    }
}
