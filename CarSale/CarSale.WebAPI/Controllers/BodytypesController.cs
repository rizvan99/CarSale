using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Entity.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSale.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodytypesController : ControllerBase
    {

        private readonly IBodyTypeService _typeService;

        public BodytypesController(IBodyTypeService typeService)
        {
            _typeService = typeService;
        }

        // GET: api/<BodytypesController>
        [HttpGet]
        public ActionResult<IEnumerable<BodyType>> Get()
        {
            return _typeService.ReadAllTypes().ToList();
        }

        // GET api/<BodytypesController>/5
        [HttpGet("{id}")]
        public ActionResult<BodyType> Get(int id)
        {
            return _typeService.ReadTypeWithCars(id);
        }

        // POST api/<BodytypesController>
        [HttpPost]
        public ActionResult<BodyType> Post([FromBody] BodyType type)
        {
            return _typeService.CreateType(type);
        }

        // PUT api/<BodytypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BodytypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
