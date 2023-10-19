using FourSix.Domain.Entities;
using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Infrastructure.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FourSix.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ReadDefaultConnectionStringFromAppSettings());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PagamentoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
        }

        private static string ReadDefaultConnectionStringFromAppSettings()
        {
            string envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{envName}.json", false)
                .AddEnvironmentVariables()
                .Build();
            //P@$$w0rd
            string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
            return connectionString;
        }
    }
}
