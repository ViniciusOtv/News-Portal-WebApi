using System.Collections.Generic;
using New_Portal_Web_API.Models;

namespace ICategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }

}