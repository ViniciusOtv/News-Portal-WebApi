using System.Linq;
using New_Portal_Web_API.Models;
using System.Collections.Generic;
using New_Portal_Web_API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace New_Portal_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        private List<News> _news;

        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public IActionResult GetAllNews()
        {
        
            _news = _newsRepository.GetAllNews().ToList();

            if(_news == null)
            {
                return NotFound();
            }

            return Ok(_news);
        }
    }
}