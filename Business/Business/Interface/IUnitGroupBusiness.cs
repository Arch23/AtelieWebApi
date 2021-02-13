using Business.ApiModel;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IUnitGroupBusiness
    {
        IEnumerable<UnitGroupApiModel> Get();
        UnitGroupApiModel Get(long id);
        long Insert(UnitGroupApiModel model);
        bool Update(UnitGroupApiModel model);
        bool Delete(long id);
    }
}
