using AutoMapper;
using Business.Business.Interface;
using Business.ApiModel;
using Model.DataAccess.Interface;
using System.Collections.Generic;
using Model.Entity;
using Infra.Business;
using FluentValidation;
using System.Linq;
using System;
using Infra.BusinessRuleSets;
using Infra.Helpers;

namespace Business.Business.Implementation
{
    public class MaterialBusiness : IMaterialBusiness
    {
        private readonly IMaterialDataAccess _materialDataAccess;
        private readonly IMapper _mapper;
        private IValidator<MaterialApiModel> _validator;

        public MaterialBusiness(
            IMaterialDataAccess materialDataAccess,
            IMapper mapper,
            IValidator<MaterialApiModel> validator)
        {
            _materialDataAccess = materialDataAccess;
            _mapper = mapper;
            _validator = validator;
        }

        public BusinessResponse<IEnumerable<MaterialApiModel>> Get() 
            => BusinessResponse<IEnumerable<MaterialApiModel>>
                .GenerateOk(_mapper.Map<IEnumerable<MaterialApiModel>>(_materialDataAccess.Get()));

        public BusinessResponse<MaterialApiModel> Get(long id) 
            => BusinessResponse<MaterialApiModel>
                .GenerateOk(_mapper.Map<MaterialApiModel>(_materialDataAccess.Get(id)));

        public BusinessResponse<long> Insert(MaterialApiModel model)
        {

            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(MaterialRuleSet.Create)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<long>.GenerateError(result);
            }

            return BusinessResponse<long>
                .GenerateOk(_materialDataAccess.Insert(_mapper.Map<Material>(model))); 
        }

        public BusinessResponse<bool> Update(MaterialApiModel model)
        {

            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(MaterialRuleSet.Update)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_materialDataAccess.Update(_mapper.Map<Material>(model))); 
        }

        public BusinessResponse<bool> Delete(long id)
        {

            var result = _validator.Validate(new MaterialApiModel() { Id = id }, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(MaterialRuleSet.Delete)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_materialDataAccess.Delete(id)); 
        }
    }
}
