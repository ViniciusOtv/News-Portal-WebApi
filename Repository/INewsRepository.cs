using System.Collections.Generic;
using New_Portal_Web_API.Models;

namespace New_Portal_Web_API.Repository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAllNews();
    }
}