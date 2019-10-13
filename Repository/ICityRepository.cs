using System.Collections.Generic;
using New_Portal_Web_API.Models;

namespace New_Portal_Web_API.Repository
{
    public interface ICityRepository
    {
        IEnumerable<City> GetAllCities();

        // IEnumerable<Category> GetCategoryById(int id);
    }

}