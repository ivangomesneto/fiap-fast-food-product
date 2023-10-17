using FourSix.Application.Services;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Infrastructure.DataAccess;
using FourSix.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FourSix.WebApi.Modules
{
    public static class SQLServerExtensions
    {
        public static IServiceCollection AddSQLServer(
        this IServiceCollection services,
        IConfiguration configuration)
        {
                          services.AddDbContext<Context>(
                    options => options.UseSqlServer(
                        configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }

}
