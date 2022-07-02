using Dapper;
using McDonaldsOnWeb.Application.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Data
{
    public class ApplicationContext : IApplicationContext
    {
        public IDbConnection DbConnection { get; set; }
        public ApplicationContext(string connectionString)
        {
            DbConnection = new SqlConnection(connectionString);            
        }
    }
}
