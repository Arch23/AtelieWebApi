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
    public class MaterialValidation : AbstractValidator<MaterialApiModel>
    {
        private const string entityName = "matéria prima";

        private const string IdName = "Código";

        private const string NameName = "nome";
        private const int NameMin = 1;
        private const int NameMax = 255;

        private const string IdBrand = "marca";

        private const string PriceName = "preço";

        private const string QuantityName = "quantidade";

        private const string IdUnitName = "unidade";

        private const string NoteName = "observação";
        private const int NoteMin = 1;
        private const int NoteMax = 5000;

        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IMaterialDataAccess _materialDataAccess;
        private readonly IBrandDataAccess _brandDataAccess;

        public MaterialValidation(
            IUnitDataAccess unitDataAccess,
            IMaterialDataAccess materialDataAccess,
            IBrandDataAccess brandDataAccess)
        {
            _unitDataAccess = unitDataAccess;
            _materialDataAccess = materialDataAccess;
            _brandDataAccess = brandDataAccess;

            RuleSet(ValidationHelper.GetRuleSets(MaterialRuleSet.Create, MaterialRuleSet.Update),
                () => {
                    RuleFor(material => material.Name).NotNull().NotEmpty().WithMessage($"{NameName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.Name).Length(NameMin, NameMax).WithMessage($"{NameName} da {entityName} precisa ter entre {NameMin} e {NameMax} caracteres");

                    When(material => material.IdBrand.HasValue && material.IdBrand.Value != 0, () => 
                    {
                        RuleFor(material => material.IdBrand.Value).Must(IdBrandAlreadyExists).WithMessage($"{IdBrand} da {entityName} não existe");
                    });

                    RuleFor(material => material.Price).GreaterThan(0).WithMessage($"{PriceName} da {entityName} precisa ser diferente de zero e positivo");

                    RuleFor(material => material.Quantity).GreaterThan(0).WithMessage($"{QuantityName} da {entityName} precisa ser diferente de zero e positivo");

                    RuleFor(material => material.IdUnit).GreaterThan(0).WithMessage($"{IdUnitName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.IdUnit).Must(IdUnitAlreadyExists).WithMessage($"{IdUnitName} da {entityName} não existe");

                    When(material => !string.IsNullOrEmpty(material.Note), () =>
                    {
                        RuleFor(material => material.Note).Length(NoteMin, NoteMax).WithMessage($"{NoteName} da {entityName} precisa ter entre {NoteMin} e {NoteMax} caracteres");
                    });
                });

            RuleSet(ValidationHelper.GetRuleSets(MaterialRuleSet.Delete, MaterialRuleSet.Update),
                () => {
                    RuleFor(material => material.Id).GreaterThan(0).WithMessage($"{IdName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.Id).Must(IdAlreadyExists).WithMessage($"{IdName} da {entityName} não existe");
                });
        }

        private bool IdAlreadyExists(long id) => _materialDataAccess.IdAlreadyExists(id);
        private bool IdUnitAlreadyExists(long id) => _unitDataAccess.IdAlreadyExists(id);
        private bool IdBrandAlreadyExists(long id) => _brandDataAccess.IdAlreadyExists(id);
    }
}
