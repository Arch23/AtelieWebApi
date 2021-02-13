using Business.ApiModel;
using Infra.Business;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IUnitBusiness
    {
        BusinessResponse<IEnumerable<UnitApiModel>> Get();
        BusinessResponse<UnitApiModel> Get(long id);
        BusinessResponse<long> Insert(UnitApiModel model);
        BusinessResponse<bool> Update(UnitApiModel model);
        BusinessResponse<bool> Delete(long id);
    }
}
