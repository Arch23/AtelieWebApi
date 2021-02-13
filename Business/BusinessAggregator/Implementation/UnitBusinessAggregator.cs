using Business.ApiModel;
using Business.Business.Interface;
using Business.BusinessAggregator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAggregator.Implementation
{
    public class UnitBusinessAggregator : IUnitBusinessAggregator
    {
        private readonly IUnitBusiness _unitBusiness;
        private readonly IUnitGroupBusiness _unitGroupBusiness;

        public UnitBusinessAggregator (
            IUnitBusiness unitBusiness,
            IUnitGroupBusiness unitGroupBusiness
            )
        {
            _unitBusiness = unitBusiness;
            _unitGroupBusiness = unitGroupBusiness;
        }

        public IEnumerable<UnitApiModel> GetUnits() => _unitBusiness.Get();
        public UnitApiModel GetUnit(long id) => _unitBusiness.Get(id);
        public long InsertUnit(UnitApiModel model) => _unitBusiness.Insert(model);
        public bool UpdateUnit(UnitApiModel model) => _unitBusiness.Update(model);
        public bool DeleteUnit(long id) => _unitBusiness.Delete(id);

        public IEnumerable<UnitGroupApiModel> GetUnitGroups() => _unitGroupBusiness.Get();
        public UnitGroupApiModel GetUnitGroup(long id) => _unitGroupBusiness.Get(id);
        public long InsertUnitGroup(UnitGroupApiModel model) => _unitGroupBusiness.Insert(model);
        public bool UpdateUnitGroup(UnitGroupApiModel model) => _unitGroupBusiness.Update(model);
        public bool DeleteUnitGroup(long id) => _unitGroupBusiness.Delete(id);
    }
}
