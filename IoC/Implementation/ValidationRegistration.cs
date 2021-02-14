using Business.ApiModel;
using Business.Validator;
using FluentValidation;
using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Implementation
{
    public class ValidationRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IValidator<UnitGroupApiModel>, UnitGroupValidation>();
            services.AddTransient<IValidator<MaterialApiModel>, MaterialValidation>();
            services.AddTransient<IValidator<UnitApiModel>, UnitValidation>();
            services.AddTransient<IValidator<BrandApiModel>, BrandValidation>();
        }
    }
}
