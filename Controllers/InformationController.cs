using System.Linq;
using New_Portal_Web_API.Models;
using System.Collections.Generic;
using New_Portal_Web_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace New_Portal_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InformationController : Controller
    {
        private List<News> _news;
        private INewsRepository _newsRepository;

        public InformationController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult GetAllNews()
        {

            _news = _newsRepository.GetAllNews().ToList();

            if (_news == null)
            {
                return NotFound();
            }

            return Ok(_news);
        }

        [HttpGet("{id}")]
        public IActionResult GetNewsById(int id)
        {
            _news = _newsRepository.GetNewsById(id).ToList();

            if (_news == null)
            {
                return NotFound();
            }
            return Ok(_news);
        }

        [HttpGet("/CategoryId/{id}")]
        public IActionResult GetNewsByCategory(int id)
        {
             _news = _newsRepository.GetNewsByCategory(id).ToList();

            if (_news.Any())
            {
                return NotFound();
            }
            return Ok(_news);
        }
    }
}