using Business.ApiModel;
using Infra.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Business.Interface
{
    public interface IBrandBusiness
    {
        BusinessResponse<IEnumerable<BrandApiModel>> Get();
        BusinessResponse<BrandApiModel> Get(long id);
        BusinessResponse<long> Insert(BrandApiModel model);
        BusinessResponse<bool> Update(BrandApiModel model);
        BusinessResponse<bool> Delete(long id);
    }
}
