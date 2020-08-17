using SearchAddress.Entities.Models;
using System.Data.SqlClient;
using SearchAddress.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace SearchAddress.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private IConfiguration _configuration;
        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Create(Location location)
        {
            using(IDbConnection connection = new SqlConnection(_configuration["ConnectionString"]))
            {
                await connection.ExecuteAsync(
                    "Insert into [dbo].[locations]( Address, State, City, zip) Values (@address, @state, @city, @zip)", new {
                        address = location.Address, 
                        state = location.State,
                        city = location.City,
                        zip = location.Zip
                    });
            }
        }

        public async Task<IEnumerable<Location>> Search(string query)
        {
            IEnumerable<Location> result;
            using (IDbConnection connection = new SqlConnection(_configuration["ConnectionString"]))
            {
                    result = await connection.QueryAsync<Location>("select * from[dbo].[locations] Where Address like '%' + @query + '%' OR State like '%' + @query + '%' OR City like '%' + @query + '%'", new {
                       query = query });
            }

            return result;
        }
    }
}
