using Business.ApiModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAggregator.Interface
{
    public interface IUnitBusinessAggregator
    {
        IEnumerable<UnitApiModel> GetUnits();
        UnitApiModel GetUnit(long id);
        long InsertUnit(UnitApiModel model);
        bool UpdateUnit(UnitApiModel model);
        bool DeleteUnit(long id);

        IEnumerable<UnitGroupApiModel> GetUnitGroups();
        UnitGroupApiModel GetUnitGroup(long id);
        long InsertUnitGroup(UnitGroupApiModel model);
        bool UpdateUnitGroup(UnitGroupApiModel model);
        bool DeleteUnitGroup(long id);
    }
}
