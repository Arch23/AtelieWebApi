using Business.ApiModel;
using Infra.Business;
using System.Collections.Generic;

namespace Business.BusinessAggregator.Interface
{
    public interface IUnitBusinessAggregator
    {
        BusinessResponse<IEnumerable<UnitApiModel>> GetUnits();
        BusinessResponse<UnitApiModel> GetUnit(long id);
        BusinessResponse<long> InsertUnit(UnitApiModel model);
        BusinessResponse<bool> UpdateUnit(UnitApiModel model);
        BusinessResponse<bool> DeleteUnit(long id);

        BusinessResponse<IEnumerable<UnitGroupApiModel>> GetUnitGroups();
        BusinessResponse<UnitGroupApiModel> GetUnitGroup(long id);
        BusinessResponse<long> InsertUnitGroup(UnitGroupApiModel model);
        BusinessResponse<bool> UpdateUnitGroup(UnitGroupApiModel model);
        BusinessResponse<bool> DeleteUnitGroup(long id);
    }
}
