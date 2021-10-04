using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MOVIES.Entities.Movies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Dapper;
using System.Linq;

namespace MOVIES.DataServices.DBContext
{
    public class MoviesDbContext
    {
        public static string ConnectionString ="Persist Security Info=False;Integrated Security = true; Initial Catalog = Movies; server=LAPTOP-CSHJ510S\\SQLEXPRESS";

        public static List<T> GetFromStoredproc<T>(string name,  DynamicParameters param)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>(name, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

 

    }
}
