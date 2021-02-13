using Model.Entity;
using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Model.DataAccess.Implementation
{
    public class MaterialDataAccess : IMaterialDataAccess
    {
        private readonly IConnectionFactory _connection;

        public MaterialDataAccess(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public IEnumerable<Material> Get()
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.GetAll<Material>(); ;
        }

        public Material Get(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Get<Material>(id); ;
        }

        public long Insert(Material model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Insert(model); ;
        }

        public bool Update(Material model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Update(model); ;
        }
        public bool Delete(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Delete<Material>(new Material() { Id = id });
        }
        public bool IdAlreadyExists(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_MATERIALS M WHERE M.Id = @Id", new { Id = id }).Any();
        }
    }
}
