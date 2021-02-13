using AutoMapper;
using Business.ApiModel;
using Business.Business.Interface;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;

namespace Business.Business.Implementation
{
    public class UnitBusiness : IUnitBusiness
    {
        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IMapper _mapper;

        public UnitBusiness(
            IUnitDataAccess materialDataAccess,
            IMapper mapper
            )
        {
            _unitDataAccess = materialDataAccess;
            _mapper = mapper;
        }

        public IEnumerable<UnitApiModel> Get() => _mapper.Map<IEnumerable<UnitApiModel>>(_unitDataAccess.Get());

        public UnitApiModel Get(long id) => _mapper.Map<UnitApiModel>(_unitDataAccess.Get(id));

        public long Insert(UnitApiModel model) => _unitDataAccess.Insert(_mapper.Map<Unit>(model));

        public bool Update(UnitApiModel model) => _unitDataAccess.Update(_mapper.Map<Unit>(model));

        public bool Delete(long id) => _unitDataAccess.Delete(id);
    }
}
