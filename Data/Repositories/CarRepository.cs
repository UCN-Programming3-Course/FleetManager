using Dapper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CarRepository
    {
        private readonly string _connectionString = "Data Source=(localdb)\\mssqllocaldb; Initial Catalog=FleetManager; Integrated Security=true";

        public IEnumerable<Car> GetAvailableCars()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cars JOIN Locations ON Locations.Id = Cars.LocationId WHERE Reserved IS NULL";

                return conn.Query<Car, Location, Car>(sql, (c, l) => {
                    c.Location = l;
                    return c;
                });
            }
        }

        public void MarkCarAsRented(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Cars SET Reserved = @rented WHERE Id = @id";

                conn.Execute(sql, new { rented = DateTime.Now, id });
            }
        }

        public void MarkCarAsReturned(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Cars SET Reserved = null WHERE Id = @id";

                conn.Execute(sql, new { id });
            }
        }

    }
}
