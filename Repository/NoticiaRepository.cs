using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using New_Portal_Web_API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using MySql.Data.MySqlClient;

namespace New_Portal_Web_API.Repository
{
    public class NoticiaRepository : INewsRepository
    {
        private IConfiguration _config;
        private List<News> _news;
        public NoticiaRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IEnumerable<News> GetAllNews()
        {
            using (var connection = new MySqlConnection(
                _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<News>(
                    "Select * from Noticias order by 1 desc limit 100;");
                    _news = query.ToList();
                    return _news;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }
    }
}