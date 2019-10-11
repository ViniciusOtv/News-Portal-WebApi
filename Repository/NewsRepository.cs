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

namespace New_Portal_Web_API.Repository
{
    public class NewsRepository : INewsRepository
    {
        private IConfiguration _config;
        private List<News> _news;
        public NewsRepository(IConfiguration configuration)
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

        public IEnumerable<News> GetNewsById(int id)
        {
            using (var connection = new MySqlConnection(
               _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<News>(
                    "Select * from Noticias WHERE Id = @Id",
                    new { @Id = id });

                    _news = query.ToList();
                    return _news;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }
        
        public IEnumerable<News> GetNewsByCategory(int id)
        {
            using (var connection = new MySqlConnection(
                _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<News>(
                        "Select * from Noticias Where CategoriaId = @CategoriaId Order By DataPublicacao Desc",
                        new { @CategoriaId = id });

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