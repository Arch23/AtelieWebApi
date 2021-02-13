using Infra.Database.Implementation;
using Infra.Database.Interface;
using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Implementation
{
    public class InfraRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services) {
            services.AddSingleton<IConnectionFactory, SqlConnectionFactory>();
        }
    }
}
