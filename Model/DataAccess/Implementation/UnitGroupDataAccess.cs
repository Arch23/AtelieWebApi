using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;

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
    }
}
