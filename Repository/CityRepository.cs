using Dapper;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using New_Portal_Web_API.Models;
using MySql.Data.MySqlClient;

using New_Portal_Web_API.Repository;

namespace New_Portal_Web_API
{
    public class CityRepository : ICityRepository
    {
        private IConfiguration _config;
        private List<City> _city;

        public CityRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IEnumerable<City> GetAllCities()
        {
            using (var connection = new MySqlConnection(
                _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<City>(
                   "Select * from Cidades");
                    _city = query.ToList();
                    return _city;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }

        public IEnumerable<City> GetCityById(int cityId)
        {
             using (var connection = new MySqlConnection(
                _config.GetConnectionString("JornalDb")))
                try
                {
                    var query = connection.Query<City>(
                   "Select * from Cidades WHERE id = @cityId", 
                   new  { @cityId = cityId });
                    _city = query.ToList();
                    return _city;
                }
                catch (System.Exception)
                {
                    throw;
                }
        }
    }

}