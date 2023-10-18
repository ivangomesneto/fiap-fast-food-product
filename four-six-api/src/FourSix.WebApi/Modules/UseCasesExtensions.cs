using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.NovoCliente;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            services.AddScoped<INovoClienteUseCase, NovoClienteUseCase>();
            //services.Decorate<INovoClienteUseCase, NovoClienteValidationUseCase>();

            return services;
        }
    }
}
