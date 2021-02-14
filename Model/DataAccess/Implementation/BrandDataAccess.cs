using Dapper;
using Dapper.Contrib.Extensions;
using Infra.Database.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Model.DataAccess.Implementation
{
    public class BrandDataAccess : IBrandDataAccess
    {
        private readonly IConnectionFactory _connection;

        public BrandDataAccess(IConnectionFactory connection)
        {
            _connection = connection;
        }

        public IEnumerable<Brand> Get()
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.GetAll<Brand>(); ;
        }

        public Brand Get(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Get<Brand>(id); ;
        }

        public long Insert(Brand model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Insert(model); ;
        }

        public bool Update(Brand model)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Update(model); ;
        }
        public bool Delete(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Delete<Brand>(new Brand() { Id = id });
        }

        public bool TitleAlreadyExists(string title)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_BRANDS B WHERE B.Title = @Title", new { Title = title }).Any();
        }

        public bool IdAlreadyExists(long id)
        {
            using var conn = _connection.GetConnection();
            conn.Open();

            return conn.Query("SELECT 1 FROM TB_DOMAIN_BRANDS B WHERE B.Id = @Id", new { Id = id }).Any();
        }
    }
}
