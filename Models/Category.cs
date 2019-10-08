using System.Collections.Generic;

namespace New_Portal_Web_API.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<News> News { get; set; }
    }
}