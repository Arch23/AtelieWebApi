using AutoMapper;
using Business.ApiModel;
using Business.Business.Interface;
using FluentValidation;
using Infra.Business;
using Infra.BusinessRuleSets;
using Infra.Helpers;
using Model.DataAccess.Interface;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Business.Implementation
{
    public class UnitBusiness : IUnitBusiness
    {
        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IMapper _mapper;
        private IValidator<UnitApiModel> _validator;

        public UnitBusiness(
            IUnitDataAccess materialDataAccess,
            IMapper mapper,
            IValidator<UnitApiModel> validator
            )
        {
            _unitDataAccess = materialDataAccess;
            _mapper = mapper;
            _validator = validator;
        }

        public BusinessResponse<IEnumerable<UnitApiModel>> Get() 
            => BusinessResponse<IEnumerable<UnitApiModel>>
                .GenerateOk(_mapper.Map<IEnumerable<UnitApiModel>>(_unitDataAccess.Get()));

        public BusinessResponse<UnitApiModel> Get(long id) 
            => BusinessResponse<UnitApiModel>
                .GenerateOk(_mapper.Map<UnitApiModel>(_unitDataAccess.Get(id)));

        public BusinessResponse<long> Insert(UnitApiModel model)
        {

            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(UnitRuleSet.Create)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<long>.GenerateError(result);
            }

            return BusinessResponse<long>
                .GenerateOk(_unitDataAccess.Insert(_mapper.Map<Unit>(model))); 
        }

        public BusinessResponse<bool> Update(UnitApiModel model)
        {
            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(UnitRuleSet.Update)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_unitDataAccess.Update(_mapper.Map<Unit>(model)));
        }

        public BusinessResponse<bool> Delete(long id)
        {
            var result = _validator.Validate(new UnitApiModel() { Id = id }, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(UnitRuleSet.Delete)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_unitDataAccess.Delete(id));
        }
    }
}
