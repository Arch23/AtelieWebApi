using Business.ApiModel;
using FluentValidation;
using Model.DataAccess.Interface;

namespace Business.Validator
{
    public class UnitGroupValidation : AbstractValidator<UnitGroupApiModel>
    {
        private const string entityName = "tipo de unidade";
        private const string TitleName = "Nome";
        private const int TitleMin = 1;
        private const int TitleMax = 255;

        private readonly IUnitGroupDataAccess _unitGroupDataAccess;

        public UnitGroupValidation(IUnitGroupDataAccess unitGroupDataAccess)
        {
            _unitGroupDataAccess = unitGroupDataAccess;
            RuleFor(unitGroup => unitGroup.Title).NotNull().NotEmpty().WithMessage($"{TitleName} do {entityName} não pode estar vazio");
            RuleFor(unitGroup => unitGroup.Title).Length(1,255).WithMessage($"{TitleName} do {entityName} precisa ter entre {TitleMin} e {TitleMax} caracteres");
            RuleFor(unitGroup => unitGroup.Title).Must(NotAlreadyExists).WithMessage($"{TitleName} do {entityName} já existe");

        }

        private bool NotAlreadyExists(string title) => !_unitGroupDataAccess.TitleAlreadyExists(title);
    }
}
