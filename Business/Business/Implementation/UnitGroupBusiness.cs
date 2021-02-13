using AutoMapper;
using Business.ApiModel;
using Business.Business.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;

namespace Business.Business.Implementation
{
    public class UnitGroupBusiness : IUnitGroupBusiness
    {
        private readonly IUnitGroupDataAccess _unitGroupDataAccess;
        private readonly IMapper _mapper;

        public UnitGroupBusiness(
            IUnitGroupDataAccess materialDataAccess,
            IMapper mapper
            )
        {
            _unitGroupDataAccess = materialDataAccess;
            _mapper = mapper;
        }

        public IEnumerable<UnitGroupApiModel> Get() => _mapper.Map<IEnumerable<UnitGroupApiModel>>(_unitGroupDataAccess.Get());

        public UnitGroupApiModel Get(long id) => _mapper.Map<UnitGroupApiModel>(_unitGroupDataAccess.Get(id));

        public long Insert(UnitGroupApiModel model) => _unitGroupDataAccess.Insert(_mapper.Map<UnitGroup>(model));

        public bool Update(UnitGroupApiModel model) => _unitGroupDataAccess.Update(_mapper.Map<UnitGroup>(model));

        public bool Delete(long id) => _unitGroupDataAccess.Delete(id);
    }
}
