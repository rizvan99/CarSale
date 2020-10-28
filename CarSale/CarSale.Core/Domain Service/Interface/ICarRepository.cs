using CarSale.Core.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Domain_Service.Interface
{
    public interface ICarRepository
    {

        //CREATE
        public Car CreateCar(Car car);


        //READ
        public IEnumerable<Car> ReadAllCars();
        public Car ReadCarById(int id);


        //UPDATE
        public Car UpdateCar(Car carToUpdate);


        //DELETE
        public Car DeleteCar(int id);


    }
}
