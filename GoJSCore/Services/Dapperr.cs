using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GoJSCore.Services
{
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "DefaultConnection";

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            throw new NotImplementedException();
        }
        public T Get<T>(long id) where T : class
        {
            using (SqlConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring)))
            {
                return db.Get<T>(id);
            }
        }


        public List<T> GetAll<T>(string sp, object parms = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<T>(sp, parms, null, true, null, commandType).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }
        public Task<int> Insert<T>(T model) where T : class
        {
            SqlConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));

            db.Open();
            return db.InsertAsync<T>(model);

        }
        public Task<bool> Update<T>(T model) where T : class
        {
            SqlConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));

            db.Open();
            return db.UpdateAsync<T>(model);

        }
    }
}
