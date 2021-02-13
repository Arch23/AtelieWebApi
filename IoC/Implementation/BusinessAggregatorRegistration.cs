using Business.BusinessAggregator.Implementation;
using Business.BusinessAggregator.Interface;
using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Implementation
{
    public class BusinessAggregatorRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IUnitBusinessAggregator, UnitBusinessAggregator>();
        }
    }
}
