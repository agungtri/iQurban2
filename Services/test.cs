using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Services
{
    public class test : Itest
    {
        private readonly IConfiguration _config;

        public test(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public string GetIdSO()
        {
            using (IDbConnection con = connection)
            {
                string query = "select top 1 [SO Number] from [OSHA Sales Database].dbo.[Sales Order]";
                con.Open();
                var result = con.QueryAsync<string>(query);
                 
                return result.ToString();
            }
        }
    }
}
