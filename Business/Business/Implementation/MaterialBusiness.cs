using AutoMapper;
using Business.Business.Interface;
using Business.ApiModel;
using Model.DataAccess.Interface;
using System.Collections.Generic;
using Model.Entity;

namespace Business.Business.Implementation
{
    public class MaterialBusiness : IMaterialBusiness
    {
        private readonly IMaterialDataAccess _materialDataAccess;
        private readonly IMapper _mapper;

        public MaterialBusiness(
            IMaterialDataAccess materialDataAccess,
            IMapper mapper
            )
        {
            _materialDataAccess = materialDataAccess;
            _mapper = mapper;
        }

        public IEnumerable<MaterialApiModel> Get() => _mapper.Map<IEnumerable<MaterialApiModel>>(_materialDataAccess.Get());

        public MaterialApiModel Get(long id) => _mapper.Map<MaterialApiModel>(_materialDataAccess.Get(id));

        public long Insert(MaterialApiModel model) => _materialDataAccess.Insert(_mapper.Map<Material>(model));

        public bool Update(MaterialApiModel model) => _materialDataAccess.Update(_mapper.Map<Material>(model));

        public bool Delete(long id) => _materialDataAccess.Delete(id);
    }
}
