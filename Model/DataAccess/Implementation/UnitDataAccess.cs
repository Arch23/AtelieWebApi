using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;

namespace Model.DataAccess.Implementation
{
    public class UnitDataAccess : IUnitDataAccess
    {
        private readonly IConnectionFactory _connection;

        public UnitDataAccess(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public IEnumerable<Unit> Get()
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.GetAll<Unit>(); ;
        }

        public Unit Get(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Get<Unit>(id); ;
        }

        public long Insert(Unit model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Insert(model); ;
        }

        public bool Update(Unit model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Update(model); ;
        }
        public bool Delete(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Delete<Unit>(new Unit() { Id = id });
        }
    }
}
