using Business.ApiModel;
using FluentValidation;
using Infra.BusinessRuleSets;
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

        private const string BrandName = "marca";
        private const int BrandMin = 1;
        private const int BrandMax = 255;

        private const string PriceName = "preço";

        private const string QuantityName = "quantidade";

        private const string IdUnitName = "unidade";

        private const string NoteName = "observação";
        private const int NoteMin = 1;
        private const int NoteMax = 5000;

        private readonly IUnitDataAccess _unitDataAccess;
        private readonly IMaterialDataAccess _materialDataAccess;

        public MaterialValidation(
            IUnitDataAccess unitDataAccess,
            IMaterialDataAccess materialDataAccess)
        {
            _unitDataAccess = unitDataAccess;
            _materialDataAccess = materialDataAccess;

            RuleSet(string.Join(",",
                Enum.GetName(typeof(MaterialRuleSet), MaterialRuleSet.Create),
                Enum.GetName(typeof(MaterialRuleSet), MaterialRuleSet.Update)),
                () => {
                    RuleFor(material => material.Name).NotNull().NotEmpty().WithMessage($"{NameName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.Name).Length(NameMin, NameMax).WithMessage($"{NameName} da {entityName} precisa ter entre {NameMin} e {NameMax} caracteres");

                    When(material => !string.IsNullOrEmpty(material.Brand), () => 
                    {
                        RuleFor(material => material.Brand).Length(BrandMin, BrandMax).WithMessage($"{BrandName} da {entityName} precisa ter entre {BrandMin} e {BrandMax} caracteres");
                    });


                    RuleFor(material => material.Price).GreaterThan(0).WithMessage($"{PriceName} da {entityName} precisa ser diferente de zero e positivo");

                    RuleFor(material => material.Quantity).GreaterThan(0).WithMessage($"{QuantityName} da {entityName} precisa ser diferente de zero e positivo");

                    RuleFor(material => material.IdUnit).GreaterThan(0).WithMessage($"{IdUnitName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.IdUnit).Must(IdUnitAlreadyExists).WithMessage($"{IdUnitName} da {entityName} não existe");

                    When(material => !string.IsNullOrEmpty(material.Note), () =>
                    {
                        RuleFor(material => material.Brand).Length(NoteMin, NoteMax).WithMessage($"{NoteName} da {entityName} precisa ter entre {BrandMin} e {BrandMax} caracteres");
                    });
                });

            RuleSet(string.Join(",",
                Enum.GetName(typeof(MaterialRuleSet), MaterialRuleSet.Delete),
                Enum.GetName(typeof(MaterialRuleSet), MaterialRuleSet.Update)),
                () => {
                    RuleFor(material => material.Id).GreaterThan(0).WithMessage($"{IdName} da {entityName} não pode estar vazio");
                    RuleFor(material => material.Id).Must(IdAlreadyExists).WithMessage($"{IdName} da {entityName} não existe");
                });
        }

        private bool IdAlreadyExists(long id) => _materialDataAccess.IdAlreadyExists(id);
        private bool IdUnitAlreadyExists(long id) => _unitDataAccess.IdAlreadyExists(id);
    }
}
