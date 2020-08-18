using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Uplift.DataAccess.Data;
using Uplift.DataAccess.Repository.IRepository;
using Uplift.Models;

namespace Uplift.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(ConnectionString);

            sqlCon.Open();
            return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
        }

        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(ConnectionString);

            sqlCon.Open();
            sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(ConnectionString);

            sqlCon.Open();

            return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure); ;
        }
    }
}
