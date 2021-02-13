using Model.Entity;
using System.Collections.Generic;

namespace Model.DataAccess.Interface
{
    public interface IMaterialDataAccess
    {
        IEnumerable<Material> Get();
        Material Get(long id);
        long Insert(Material model);
        bool Update(Material model);
        bool Delete(long id);

        bool IdAlreadyExists(long id);
    }
}
