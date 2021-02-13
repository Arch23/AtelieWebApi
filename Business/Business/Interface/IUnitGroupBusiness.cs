using Business.ApiModel;
using Infra.Business;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IUnitGroupBusiness
    {
        BusinessResponse<IEnumerable<UnitGroupApiModel>> Get();
        BusinessResponse<UnitGroupApiModel> Get(long id);
        BusinessResponse<long> Insert(UnitGroupApiModel model);
        BusinessResponse<bool> Update(UnitGroupApiModel model);
        BusinessResponse<bool> Delete(long id);
    }
}
