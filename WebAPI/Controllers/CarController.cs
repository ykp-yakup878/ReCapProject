using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_carService.GetById(id));
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            return Ok(_carService.Add(car));
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
                return Ok(_carService.Update(car));
        }
        [HttpGet("cardetail")]
        public IActionResult CarDetail()
        {
            return Ok(_carService.GetCarDetail());
        }
        
    }
}
