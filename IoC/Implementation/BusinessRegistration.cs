using Business.Business.Implementation;
using Business.Business.Interface;
using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Implementation
{
    public class BusinessRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IMaterialBusiness, MaterialBusiness>();
            services.AddSingleton<IUnitGroupBusiness, UnitGroupBusiness>();
            services.AddSingleton<IUnitBusiness, UnitBusiness>();
            services.AddSingleton<IBrandBusiness, BrandBusiness>();
        }
    }
}
