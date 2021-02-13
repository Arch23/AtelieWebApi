using Business.ApiModel;
using Infra.Business;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IMaterialBusiness
    {
        BusinessResponse<IEnumerable<MaterialApiModel>> Get();
        BusinessResponse<MaterialApiModel> Get(long id);
        BusinessResponse<long> Insert(MaterialApiModel model);
        BusinessResponse<bool> Update(MaterialApiModel model);
        BusinessResponse<bool> Delete(long id);
    }
}
