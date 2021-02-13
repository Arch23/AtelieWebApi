using Business.ApiModel;
using Infra.Business;
using System.Collections.Generic;

namespace Business.BusinessAggregator.Interface
{
    public interface IUnitBusinessAggregator
    {
        IEnumerable<UnitApiModel> GetUnits();
        UnitApiModel GetUnit(long id);
        long InsertUnit(UnitApiModel model);
        bool UpdateUnit(UnitApiModel model);
        bool DeleteUnit(long id);

        BusinessResponse<IEnumerable<UnitGroupApiModel>> GetUnitGroups();
        BusinessResponse<UnitGroupApiModel> GetUnitGroup(long id);
        BusinessResponse<long> InsertUnitGroup(UnitGroupApiModel model);
        BusinessResponse<bool> UpdateUnitGroup(UnitGroupApiModel model);
        BusinessResponse<bool> DeleteUnitGroup(long id);
    }
}
