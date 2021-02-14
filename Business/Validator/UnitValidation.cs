using Business.ApiModel;
using FluentValidation;
using Infra.BusinessRuleSets;
using Infra.Helpers;
using Model.DataAccess.Interface;

namespace Business.Validator
{
    public class UnitValidation : AbstractValidator<UnitApiModel>
    {
        private const string entityName = "unidade";

        private const string TitleName = "nome";
        private const int TitleMin = 1;
        private const int TitleMax = 255;

        private const string IdName = "Código";

        private const string AbbreviationName = "abreviação";
        private const int AbbreviationMin = 1;
        private const int AbbreviationMax = 25;

        private const string IdGroupName = "tipo de grupo";

        private const string ReferenceUnitName = "unidade de referência";

        private const string ReferenceValueName = "valor em relação a referência";


        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IUnitGroupDataAccess _unitGroupDataAccess;

        public UnitValidation(
            IUnitDataAccess unitDataAccess,
            IUnitGroupDataAccess unitGroupDataAccess)
        {
            _unitDataAccess = unitDataAccess;
            _unitGroupDataAccess = unitGroupDataAccess;

            RuleSet(ValidationHelper.GetRuleSets(UnitRuleSet.Create,UnitRuleSet.Update),
                () => {
                    RuleFor(unit => unit.Title).NotNull().NotEmpty().WithMessage($"{TitleName} do {entityName} não pode estar vazio");
                    RuleFor(unit => unit.Title).Length(TitleMin, TitleMax).WithMessage($"{TitleName} do {entityName} precisa ter entre {TitleMin} e {TitleMax} caracteres");
                    RuleFor(unit => unit.Title).Must(TitleNotAlreadyExists).WithMessage($"{TitleName} do {entityName} já existe");

                    RuleFor(unit => unit.Abbreviation).NotNull().NotEmpty().WithMessage($"{AbbreviationName} do {entityName} não pode estar vazio");
                    RuleFor(unit => unit.Abbreviation).Length(AbbreviationMin, AbbreviationMax).WithMessage($"{AbbreviationName} do {entityName} precisa ter entre {AbbreviationMin} e {AbbreviationMax} caracteres");
                    RuleFor(unit => unit.Abbreviation).Must(AbbreviationNotAlreadyExists).WithMessage($"{AbbreviationName} do {entityName} já existe");

                    RuleFor(unit => unit.IdGroup).GreaterThan(0).WithMessage($"{IdGroupName} do {entityName} não pode estar vazio");
                    RuleFor(unit => unit.IdGroup).Must(IdGroupAlreadyExists).WithMessage($"{IdGroupName} do {entityName} não existe");

                    When(unit => unit.ReferenceUnit.HasValue && unit.ReferenceUnit.Value != 0, () =>
                    {
                        RuleFor(unit => unit.ReferenceUnit.Value).Must(IdAlreadyExists).WithMessage($"{ReferenceUnitName} do {entityName} não existe");
                        RuleFor(unit => unit.ReferenceValue).GreaterThan(0).WithMessage($"{ReferenceValueName} do {entityName} tem que ser maior que zero");
                    }).Otherwise(() => 
                    {
                        RuleFor(unit => unit.ReferenceValue).Equal(1).WithMessage($"{ReferenceValueName} do {entityName} precisa ser 1.0 caso não tenha unidade de referência");
                    });
                });

            RuleSet(ValidationHelper.GetRuleSets(UnitRuleSet.Delete, UnitRuleSet.Update),
                () => {
                    RuleFor(unit => unit.Id).GreaterThan(0).WithMessage($"{IdName} do {entityName} não pode estar vazio");
                    RuleFor(unit => unit.Id).Must(IdAlreadyExists).WithMessage($"{IdName} do {entityName} não existe");
                });
        }

        public bool TitleNotAlreadyExists(string title) => !_unitDataAccess.TitleAlreadyExists(title);
        public bool AbbreviationNotAlreadyExists(string abbreviation) => !_unitDataAccess.AbbreviationAlreadyExists(abbreviation);
        public bool IdGroupAlreadyExists(long id) => _unitGroupDataAccess.IdAlreadyExists(id);
        public bool IdAlreadyExists(long id) => _unitDataAccess.IdAlreadyExists(id);
    }
}
