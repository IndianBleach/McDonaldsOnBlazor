using Dapper;
using McDonaldsOnWeb.Application.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonaldsOnWeb.Application.Interfaces
{
    public interface IApplicationContext
    {
        IDbConnection DbConnection { get; set; }
    }
}
