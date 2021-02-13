using Dapper;
using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Model.DataAccess.Implementation
{
    public class UnitGroupGroupDataAccess : IUnitGroupDataAccess
    {
        private readonly IConnectionFactory _connection;

        public UnitGroupGroupDataAccess(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public IEnumerable<UnitGroup> Get()
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.GetAll<UnitGroup>(); ;
        }

        public UnitGroup Get(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Get<UnitGroup>(id); ;
        }

        public long Insert(UnitGroup model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Insert(model); ;
        }

        public bool Update(UnitGroup model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Update(model); ;
        }
        public bool Delete(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Delete<UnitGroup>(new UnitGroup() { Id = id });
        }

        public bool TitleAlreadyExists(string title)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_UNITS_GROUP UG WHERE UG.Title = @Title", new { Title = title }).Any();
        }

        public bool IdAlreadyExists(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_UNITS_GROUP UG WHERE UG.Id = @Id", new { Id = id }).Any();
        }
    }
}
