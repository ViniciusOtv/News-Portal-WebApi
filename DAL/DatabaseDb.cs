using Microsoft.EntityFrameworkCore;
using New_Portal_Web_API.Models;

namespace New_Portal_Web_API.DAL
{
    public class DatabaseDb : DbContext
    {
        public DatabaseDb(DbContextOptions<DatabaseDb> options) : 
         base(options)
         {

         }

         public DbSet<News> Noticias { get;  set;}
    }
}