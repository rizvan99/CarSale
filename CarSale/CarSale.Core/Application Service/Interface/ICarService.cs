using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Application_Service.Interface
{
    public interface ICarService
    {
        //CREATE
        public Car CreateCar(Car car);


        //READ
        public IEnumerable<Car> GetAllCars();
        public Car GetCarById(int id);


        //UPDATE
        public Car UpdateCar(Car carToUpdate);

        //DELETE
        public Car DeleteCar(int id);
    }
}
