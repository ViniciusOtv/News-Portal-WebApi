using System.Linq;
using New_Portal_Web_API.Models;
using System.Collections.Generic;
using New_Portal_Web_API.Repository;
using Microsoft.AspNetCore.Mvc;


namespace New_Portal_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {

        private List<City> _city;

        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _city = _cityRepository.GetAllCities().ToList();

            if (_city == null || !_city.Any())
            {
                return NotFound();
            }

            return Ok(_city);
        }

        [HttpGet("CityId/{id}")]
        public IActionResult GetCityById(int id)
        {
            _city = _cityRepository.GetCityById(id).ToList();

            if (_city == null || !_city.Any())
            {
                return NotFound();
            }

            return Ok(_city);
        }
    }
}

