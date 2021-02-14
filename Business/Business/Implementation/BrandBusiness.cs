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
using System.Text;

namespace Business.Business.Implementation
{
    public class BrandBusiness : IBrandBusiness
    {
        private readonly IBrandDataAccess _brandDataAccess;
        private readonly IMapper _mapper;
        private IValidator<BrandApiModel> _validator;

        public BrandBusiness (
            IBrandDataAccess brandDataAccess,
            IMapper mapper,
            IValidator<BrandApiModel> validator
            )
        {
            _brandDataAccess = brandDataAccess;
            _mapper = mapper;
            _validator = validator;
        }

        public BusinessResponse<IEnumerable<BrandApiModel>> Get()
            => BusinessResponse<IEnumerable<BrandApiModel>>
                .GenerateOk(_mapper.Map<IEnumerable<BrandApiModel>>(_brandDataAccess.Get()));

        public BusinessResponse<BrandApiModel> Get(long id)
            => BusinessResponse<BrandApiModel>
                .GenerateOk(_mapper.Map<BrandApiModel>(_brandDataAccess.Get(id)));

        public BusinessResponse<long> Insert(BrandApiModel model)
        {

            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(BrandRuleSet.Create)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<long>.GenerateError(result);
            }

            return BusinessResponse<long>
                .GenerateOk(_brandDataAccess.Insert(_mapper.Map<Brand>(model)));
        }

        public BusinessResponse<bool> Update(BrandApiModel model)
        {
            var result = _validator.Validate(model, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(BrandRuleSet.Update)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_brandDataAccess.Update(_mapper.Map<Brand>(model)));
        }

        public BusinessResponse<bool> Delete(long id)
        {
            var result = _validator.Validate(new BrandApiModel() { Id = id }, options => options.IncludeRuleSets(ValidationHelper.GetRuleSets(BrandRuleSet.Delete)));

            if (!result.IsValid || result.Errors.Any())
            {
                return BusinessResponse<bool>.GenerateError(result);
            }

            return BusinessResponse<bool>
                .GenerateOk(_brandDataAccess.Delete(id));
        }
    }
}
