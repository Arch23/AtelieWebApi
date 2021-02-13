using Model.Entity;
using System.Collections.Generic;

namespace Model.DataAccess.Interface
{
    public interface IUnitDataAccess
    {
        IEnumerable<Unit> Get();
        Unit Get(long id);
        long Insert(Unit model);
        bool Update(Unit model);
        bool Delete(long id);

        bool IdAlreadyExists(long id);
        bool TitleAlreadyExists(string title);
        bool AbbreviationAlreadyExists(string abbreviation);
    }
}
