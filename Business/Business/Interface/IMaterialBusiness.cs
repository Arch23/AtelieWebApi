using Business.ApiModel;
using System.Collections.Generic;

namespace Business.Business.Interface
{
    public interface IMaterialBusiness
    {
        IEnumerable<MaterialApiModel> Get();
        MaterialApiModel Get(long id);
        long Insert(MaterialApiModel model);
        bool Update(MaterialApiModel model);
        bool Delete(long id);
    }
}
