using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Connection
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;        
        public IDbConnection CreateConnection(string name = "default")
        {
            switch (name)
            {
                case "default":
                    {
                        var connectionString = _configuration.GetConnectionString("DefaultConnection");
                        return new SqlConnection(connectionString);
                    }
                default:
                    {
                        throw new Exception("name 不存在。");
                    }
            }
        }
    }
}
