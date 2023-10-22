using FourSix.Application.Services;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.Infrastructure.DataAccess;
using FourSix.Infrastructure.DataAccess.Repositories;

namespace FourSix.WebApi.Modules
{
    public static class SQLServerExtensions
    {
        public static IServiceCollection AddSQLServer(
        this IServiceCollection services)
        {
                services.AddDbContext<Context>();
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<IClienteRepository, ClienteRepository>();
                services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }

}
