using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using New_Portal_Web_API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;


namespace New_Portal_Web_API
{

    public class CategoryRepository
    {
        private IConfiguration _config;

        private List<Category> _category;
        
        public CategoryRepository(IConfiguration configuration)
        {
            _config = configuration;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            using (var connection = new MySqlConnection(
                _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<Category>(
                   "Select * from Categorias");
                    _category = query.ToList();
                    return _category;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }
    }
}