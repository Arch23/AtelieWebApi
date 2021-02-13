using Business.ApiModel;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IUnitBusiness
    {
        IEnumerable<UnitApiModel> Get();
        UnitApiModel Get(long id);
        long Insert(UnitApiModel model);
        bool Update(UnitApiModel model);
        bool Delete(long id);
    }
}
