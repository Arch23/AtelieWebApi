using AutoMapper;
using IoC.Interface;
using Microsoft.Extensions.DependencyInjection;
using IoC.Implementation.AutoMapper;

namespace IoC.Implementation
{
    public class AutoMapperRegistration : IIoCRegistrationBase
    {
        public static void Register(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config => {
                config.AddProfile<EntityProfile>();
                config.AddProfile<ApiModelProfile>();
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
