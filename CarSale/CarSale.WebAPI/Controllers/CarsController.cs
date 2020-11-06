using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Entity.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<CarsController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            return _carService.GetAllCars().ToList();
        }

        // GET api/<CarsController>/5
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            var car = _carService.GetCarById(id);

            if (id < 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            if (car == null)
            {
                return StatusCode(404, $"Car with id {id} not found");
            }

            return StatusCode(200, car);
        }

        // POST api/<CarsController>
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            try
            {
                if (string.IsNullOrEmpty(car.Name))
                {
                    return BadRequest("Must specify name for car");
                }
                if (string.IsNullOrEmpty(car.Brand))
                {
                    return BadRequest("Must specify brand for car");
                }
                if (car.Price <= 0)
                {
                    return BadRequest("Must specify price for car");
                }

                return StatusCode(201, _carService.CreateCar(car));

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<CarsController>/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car car)
        {
            if (id < 0 || id != car.Id)
            {
                return BadRequest($"Car with id {id} not found");
            }

            return _carService.UpdateCar(car);

        }

        // DELETE api/<CarsController>/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            try
            {
                var carDelete = _carService.DeleteCar(id);
                return Ok($"Car with id {id} has been deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
