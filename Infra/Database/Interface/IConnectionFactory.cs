using System.Data;

namespace Infra.Database.Interface
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
