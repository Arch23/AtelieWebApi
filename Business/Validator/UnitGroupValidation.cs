using Business.ApiModel;
using FluentValidation;
using Infra.BusinessRuleSets;
using Model.DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace Business.Validator
{
    public class UnitGroupValidation : AbstractValidator<UnitGroupApiModel>
    {
        private const string entityName = "tipo de unidade";
        private const string TitleName = "Nome";
        private const string IdName = "Código";
        private const int TitleMin = 1;
        private const int TitleMax = 255;

        private readonly IUnitGroupDataAccess _unitGroupDataAccess;

        public UnitGroupValidation(IUnitGroupDataAccess unitGroupDataAccess)
        {
            _unitGroupDataAccess = unitGroupDataAccess;

            RuleSet(string.Join(",",
                Enum.GetName(typeof(UnitGroupRuleSet), UnitGroupRuleSet.Create),
                Enum.GetName(typeof(UnitGroupRuleSet), UnitGroupRuleSet.Update)), 
                () => {
                    RuleFor(unitGroup => unitGroup.Title).NotNull().NotEmpty().WithMessage($"{TitleName} do {entityName} não pode estar vazio");
                    RuleFor(unitGroup => unitGroup.Title).Length(TitleMin, TitleMax).WithMessage($"{TitleName} do {entityName} precisa ter entre {TitleMin} e {TitleMax} caracteres");
                    RuleFor(unitGroup => unitGroup.Title).Must(TitleNotAlreadyExists).WithMessage($"{TitleName} do {entityName} já existe");
                });

            RuleSet(string.Join(",",
                Enum.GetName(typeof(UnitGroupRuleSet), UnitGroupRuleSet.Delete),
                Enum.GetName(typeof(UnitGroupRuleSet), UnitGroupRuleSet.Update)),
                () => {
                    RuleFor(unitGroup => unitGroup.Id).GreaterThan(0).WithMessage($"{IdName} do {entityName} não pode estar vazio");
                    RuleFor(unitGroup => unitGroup.Id).Must(AlreadyExists).WithMessage($"{IdName} do {entityName} não existe");
                });
        }

        private bool TitleNotAlreadyExists(string title) => !_unitGroupDataAccess.TitleAlreadyExists(title);
        private bool AlreadyExists(long id) => _unitGroupDataAccess.IdAlreadyExists(id);
    }
}
