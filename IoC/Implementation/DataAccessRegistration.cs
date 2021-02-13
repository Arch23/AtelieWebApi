using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;
using Model.DataAccess.Implementation;
using Model.DataAccess.Interface;

namespace IoC.Implementation
{
    public class DataAccessRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IMaterialDataAccess, MaterialDataAccess>();
            services.AddSingleton<IUnitGroupDataAccess, UnitGroupGroupDataAccess>();
            services.AddSingleton<IUnitDataAccess, UnitDataAccess>();
        }
    }
}
