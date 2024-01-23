using FourSix.Controllers.Presenters;
using FourSix.UseCases.UseCases.Clientes.NovoCliente;
using FourSix.UseCases.UseCases.Clientes.ObtemCliente;
using FourSix.UseCases.UseCases.Pagamentos.CancelaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using FourSix.UseCases.UseCases.Pagamentos.RealizaPagamento;
using FourSix.UseCases.UseCases.Pedidos.AlteraStatusPedido;
using FourSix.UseCases.UseCases.Pedidos.CancelaPedido;
using FourSix.UseCases.UseCases.Pedidos.NovoPedido;
using FourSix.UseCases.UseCases.Pedidos.ObtemPedidosPorStatus;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using FourSix.UseCases.UseCases.Produtos.InativaProduto;
using FourSix.UseCases.UseCases.Produtos.NovoProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProduto;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutoPorCategoria;
using FourSix.UseCases.UseCases.Produtos.ObtemProdutos;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            #region [ Clientes ]
            services.AddScoped<INovoClienteUseCase, NovoClienteUseCase>();
            //services.Decorate<INovoClienteUseCase, NovoClienteValidationUseCase>();

            services.AddScoped<IObtemClienteUseCase, ObtemClienteUseCase>();
            //services.Decorate<IObtemClienteUseCase, ObtemClienteValidationUseCase>();
            #endregion

            #region [ Produtos ]
            services.AddScoped<IAlteraProdutoUseCase, AlteraProdutoUseCase>();
            //services.Decorate<IAlteraProdutoUseCase, AlteraProdutoValidationUseCase>();

            services.AddScoped<INovoProdutoUseCase, NovoProdutoUseCase>();
            //services.Decorate<INovoProdutoUseCase, NovoProdutoValidationUseCase>();

            services.AddScoped<IInativaProdutoUseCase, InativaProdutoUseCase>();
            //services.Decorate<IInativaProdutoUseCase, InativaProdutoValidationUseCase>();

            services.AddScoped<IObtemProdutoUseCase, ObtemProdutoUseCase>();
            //services.Decorate<IObtemProdutoUseCase, ObtemProdutoValidationUseCase>();

            services.AddScoped<IObtemProdutoPorCategoriaUseCase, ObtemProdutoPorCategoriaUseCase>();
            //services.Decorate<IObtemProdutoPorCategoriaUseCase, ObtemProdutoPorCategoriaValidationUseCase>();

            services.AddScoped<IObtemProdutosUseCase, ObtemProdutosUseCase>();
            //services.Decorate<IObtemProdutosUseCase, ObtemProdutosValidationUseCase>();

            #endregion

            #region [ Pedidos ]
            services.AddScoped<IAlteraStatusPedidoUseCase, AlteraStatusPedidoUseCase>();
            //services.Decorate<IAlteraStatusPedidoUseCase, AlteraStatusPedidoValidationUseCase>();

            services.AddScoped<ICancelaPedidoUseCase, CancelaPedidoUseCase>();
            //services.Decorate<ICancelaPedidoUseCase, CancelaPedidoValidationUseCase>();

            services.AddScoped<INovoPedidoUseCase, NovoPedidoUseCase>();
            //services.Decorate<INovoPedidoUseCase, NovoPedidoValidationUseCase>();

            services.AddScoped<IObtemPedidosPorStatusUseCase, ObtemPedidosPorStatusUseCase>();
            //services.Decorate<IObtemPedidosPorStatusUseCase, ObtemPedidosPorStatusValidationUseCase>();
            #endregion

            #region [ Pagamento ]
            services.AddScoped<IGeraQRCodeUseCase, GeraQRCodeUseCase>();
            //services.Decorate<IGeraQRCodeUseCase, GeraQRCodeValidationUseCase>();

            services.AddScoped<ICancelaPagamentoUseCase, CancelaPagamentoUseCase>();
            //services.Decorate<ICancelaPagamentoUseCase, CancelaPagamentoValidationUseCase>();

            services.AddScoped<IGeraPagamentoUseCase, GeraPagamentoUseCase>();
            //services.Decorate<IGeraPagamentoUseCase, GeraPagamentoValidationUseCase>();

            services.AddScoped<IRealizaPagamentoUseCase, RealizaPagamentoUseCase>();
            //services.Decorate<IRealizaPagamentoUseCase, RealizaPagamentoValidationUseCase>();

            services.AddScoped<IObtemStatusPagamentoPedidoUseCase, ObtemStatusPagamentoPedidoUseCase>();
            #endregion

            return services;
        }
    }
}
