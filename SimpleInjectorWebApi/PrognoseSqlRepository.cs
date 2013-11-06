using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace SimpleInjectorWebApi
{
    public class PrognoseSqlRepository : IPrognoseRepository
    {
        private readonly string _connection;

        public PrognoseSqlRepository(string connectionString)
        {
            _connection = connectionString;
        }

        public List<Prognose> GetPrognoses()
        {
            const string sql = "select name, standardprognosis from spoorweb.dbo.incidentlabel";
            using (var connection = new SqlConnection(_connection))
            {
                connection.Open();
                var prognoses = connection.Query<Prognose>(sql).ToList();
                connection.Close();
                return prognoses;
            }
        }
    }
}