using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AutofacWebApi
{
    public class PrognoseSqlRepository : IPrognoseRepository
    {
        private string conn;

        public PrognoseSqlRepository(string connectionString)
        {
            this.conn = connectionString;
        }

        public List<Prognose> GetPrognoses()
        {
            var sql = "select name, standardprognosis from spoorweb.dbo.incidentlabel";
            using (var connection = new SqlConnection(conn))
            {
                connection.Open();
                var prognoses = connection.Query<Prognose>(sql).ToList();
                connection.Close();
                return prognoses;
            }
            return null;

        }
    }
}