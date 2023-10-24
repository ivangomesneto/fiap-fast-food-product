using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.NovoCliente;
using FourSix.Application.UseCases.Clientes.ObtemCliente;
using FourSix.Application.UseCases.Pedidos.NovoPedido;
using FourSix.Application.UseCases.Produtos.AlteraProduto;
using FourSix.Application.UseCases.Produtos.ObtemProdutos;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            #region [ Cliente ]
            services.AddScoped<INovoClienteUseCase, NovoClienteUseCase>();
            services.Decorate<INovoClienteUseCase, NovoClienteValidationUseCase>();

            services.AddScoped<IObtemClienteUseCase, ObtemClienteUseCase>();
            services.Decorate<IObtemClienteUseCase, ObtemClienteValidationUseCase>();
            #endregion

            #region [ Produto ]
            services.AddScoped<IAlteraProdutoUseCase, AlteraProdutoUseCase>();
            services.Decorate<IAlteraProdutoUseCase, AlteraProdutoValidationUseCase>();

            services.AddScoped<IObtemProdutosUseCase, ObtemProdutosUseCase>();
            services.Decorate<IObtemProdutosUseCase, ObtemProdutosValidationUseCase>();
            #endregion

            #region [ Pedido ]
            services.AddScoped<INovoPedidoUseCase, NovoPedidoUseCase>();
            services.Decorate<INovoPedidoUseCase, NovoPedidoValidationUseCase>();
            #endregion

            return services;
        }
    }
}
