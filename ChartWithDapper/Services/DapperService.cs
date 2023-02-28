using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace ChartWithDapper.Services
{
    public class DapperService
    {
        private readonly string connection;
        public DapperService(IConfiguration configuration)
        {
            connection = configuration.GetConnectionString("DbConnectionString");
        }

        public List<T> getData<T>(string query)
        {
            using(IDbConnection dbConnection=new SqlConnection(connection))
            {
                var list = dbConnection.Query<T>(query).ToList();
                return list;
            }
        }
        public T getDatum<T>(string query)
        {
            using(IDbConnection dbConnection=new SqlConnection(connection))
            {
                var datum = dbConnection.Query<T>(query).ToList();
                return datum.FirstOrDefault();
            }
        }
        public int execution(string query)
        {
            using(IDbConnection dbConnection=new SqlConnection(connection))
            {
                var result = dbConnection.Execute(query);
                return result;
            }
        }
    }
}
