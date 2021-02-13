using Dapper;
using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;
using System.Linq;

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

        public bool TitleAlreadyExists(string title)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_UNITS U WHERE U.Title = @Title", new { Title = title }).Any();
        }

        public bool IdAlreadyExists(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_UNITS U WHERE U.Id = @Id", new { Id = id }).Any();
        }

        public bool AbbreviationAlreadyExists(string abbreviation)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_UNITS U WHERE U.Abbreviation = @Abbreviation", new { Abbreviation = abbreviation }).Any();
        }
    }
}
