using AutoMapper;
using Business.ApiModel;
using Business.Business.Interface;
using FluentValidation;
using Infra.Business;
using Model.DataAccess.Interface;
using Model.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Business.Business.Implementation
{
    public class UnitGroupBusiness : IUnitGroupBusiness
    {
        private readonly IUnitGroupDataAccess _unitGroupDataAccess;
        private readonly IMapper _mapper;
        private IValidator<UnitGroupApiModel> _validator;

        public UnitGroupBusiness(
            IUnitGroupDataAccess materialDataAccess,
            IMapper mapper,
            IValidator<UnitGroupApiModel> validator
            )
        {
            _unitGroupDataAccess = materialDataAccess;
            _mapper = mapper;
            _validator = validator;
        }

        public BusinessResponse<IEnumerable<UnitGroupApiModel>> Get() 
            => BusinessResponse<IEnumerable<UnitGroupApiModel>>
                .GenerateOk(_mapper.Map<IEnumerable<UnitGroupApiModel>>(_unitGroupDataAccess.Get()));

        public BusinessResponse<UnitGroupApiModel> Get(long id) 
            => BusinessResponse<UnitGroupApiModel>
                .GenerateOk(_mapper.Map<UnitGroupApiModel>(_unitGroupDataAccess.Get(id)));

        public BusinessResponse<long> Insert(UnitGroupApiModel model) {

            var result = _validator.Validate(model);

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<long>.GenerateError(result);
            }

            return BusinessResponse<long>
                .GenerateOk(_unitGroupDataAccess.Insert(_mapper.Map<UnitGroup>(model))); 
        }

        public BusinessResponse<bool> Update(UnitGroupApiModel model) {
            var result = _validator.Validate(model);

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_unitGroupDataAccess.Update(_mapper.Map<UnitGroup>(model)));
        }

        public BusinessResponse<bool> Delete(long id) 
            => BusinessResponse<bool>
                .GenerateOk(_unitGroupDataAccess.Delete(id));
    }
}
