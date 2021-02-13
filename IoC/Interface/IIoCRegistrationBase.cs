using Microsoft.Extensions.DependencyInjection;

namespace IoC.Interface
{
    public interface IIoCRegistrationBase
    {
        static void Register(IServiceCollection services) { }
    }
}
