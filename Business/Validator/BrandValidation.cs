using Business.ApiModel;
using FluentValidation;
using Infra.BusinessRuleSets;
using Infra.Helpers;
using Model.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validator
{
    public class BrandValidation : AbstractValidator<BrandApiModel>
    {
        private const string entityName = "marca";
        private const string TitleName = "Nome";
        private const string IdName = "Código";
        private const int TitleMin = 1;
        private const int TitleMax = 255;

        private readonly IBrandDataAccess _brandDataAccess;

        public BrandValidation(IBrandDataAccess brandDataAccess)
        {
            _brandDataAccess = brandDataAccess;

            RuleSet(ValidationHelper.GetRuleSets(BrandRuleSet.Create, BrandRuleSet.Update),
                () => {
                    RuleFor(unitGroup => unitGroup.Title).NotNull().NotEmpty().WithMessage($"{TitleName} da {entityName} não pode estar vazio");
                    RuleFor(unitGroup => unitGroup.Title).Length(TitleMin, TitleMax).WithMessage($"{TitleName} da {entityName} precisa ter entre {TitleMin} e {TitleMax} caracteres");
                    RuleFor(unitGroup => unitGroup.Title).Must(TitleNotAlreadyExists).WithMessage($"{TitleName} da {entityName} já existe");
                });

            RuleSet(ValidationHelper.GetRuleSets(BrandRuleSet.Delete, BrandRuleSet.Update),
                () => {
                    RuleFor(unitGroup => unitGroup.Id).GreaterThan(0).WithMessage($"{IdName} da {entityName} não pode estar vazio");
                    RuleFor(unitGroup => unitGroup.Id).Must(AlreadyExists).WithMessage($"{IdName} da {entityName} não existe");
                });
        }

        private bool TitleNotAlreadyExists(string title) => !_brandDataAccess.TitleAlreadyExists(title);
        private bool AlreadyExists(long id) => _brandDataAccess.IdAlreadyExists(id);
    }
}
