using Business.Abstract;
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
    public class CarFindeksController : ControllerBase
    {
        private ICarFindeksService _carFindekService;
        public CarFindeksController(ICarFindeksService carFindeksService)
        {
            _carFindekService = carFindeksService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carFindekService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetail")]
        public IActionResult GetFindeksDetail()
        {
            var result = _carFindekService.GetCarFindeksDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetailbycarid")]
        public IActionResult GetFindeksDetailByUserId(int carId)
        {
            var result = _carFindekService.GetCarFindeksDetailByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarfindeksdetailbyid")]
        public IActionResult GetFindeksDetailByFindeksId(int findeksId)
        {
            var result = _carFindekService.GetCarFindeksDetailById(findeksId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
