using FourSix.Controllers.Adapters.Clientes.NovoCliente;
using FourSix.Controllers.Adapters.Clientes.ObtemCliente;
using FourSix.Controllers.Adapters.Pagamentos.CancelaPagamento;
using FourSix.Controllers.Adapters.Pagamentos.GeraPagamento;
using FourSix.Controllers.Adapters.Pagamentos.ObtemStatusPagamentoPedido;
using FourSix.Controllers.Adapters.Pagamentos.RealizaPagamento;
using FourSix.Controllers.Adapters.Pedidos.AlteraStatusPedido;
using FourSix.Controllers.Adapters.Pedidos.CancelaPedido;
using FourSix.Controllers.Adapters.Pedidos.NovoPedido;
using FourSix.Controllers.Adapters.Pedidos.ObtemPedidosPorStatus;
using FourSix.Controllers.Adapters.Produtos.AlteraProduto;
using FourSix.Controllers.Adapters.Produtos.InativaProduto;
using FourSix.Controllers.Adapters.Produtos.NovoProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProduto;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutoPorCategoria;
using FourSix.Controllers.Adapters.Produtos.ObtemProdutos;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Modules
{
    public static class RoutesExtensions
    {
        public static void AddRoutesMaps(this IEndpointRouteBuilder app)
        {
            #region [ Clientes ]

            app.MapGet("clientes/{cpf}",
            [SwaggerOperation(Summary = "Obtém cliente")]
            ([SwaggerParameter("CPF do cliente")] string cpf, IObtemClienteAdapter adapter) =>
            {
                return adapter.Get(cpf);
            }).WithTags("Clientes");

            app.MapPost("clientes",
            [SwaggerOperation(Summary = "Cria novo cliente")]
            ([FromBody] NovoClienteRequest request, INovoClienteAdapter adapter) =>
            {
                adapter.Inserir(request);
            }).WithTags("Clientes");

            #endregion

            #region [ Pedidos ]

            app.MapGet("pedidos/{statusId}",
            [SwaggerOperation(Summary = "Obtém lista de pedido por status")]
            ([SwaggerParameter("Status do Pedido")] EnumStatusPedido statusId, IObtemPedidosPorStatusAdapter adapter) =>
            {
                return adapter.Listar(statusId);
            }).WithTags("Pedidos");

            app.MapPost("pedidos",
            [SwaggerOperation(Summary = "Cria novo pedido")]
            ([FromBody] NovoPedidoRequest request, INovoPedidoAdapter adapter) =>
            {
                adapter.Inserir(request);
            }).WithTags("Pedidos");

            app.MapPut("pedidos/cancelamentos",
            [SwaggerOperation(Summary = "Cancela pedido")]
            ([FromBody] CancelaPedidoRequest request, ICancelaPedidoAdapter adapter) =>
            {
                adapter.Cancelar(request);
            }).WithTags("Pedidos");

            app.MapPut("pedidos/{pedidoId:guid}/status/{statusId}",
            [SwaggerOperation(Summary = "Altera status do pedido")]
            ([SwaggerParameter("ID do Pedido")] Guid pedidoId, [SwaggerParameter("Status do Pedido")] EnumStatusPedido statusId, IAlteraStatusPedidoAdapter adapter) =>
            {
                adapter.Alterar(pedidoId, statusId);
            }).WithTags("Pedidos");

            #endregion

            #region [ Pagamentos ]

            app.MapPut("pagamentos/cancelamentos",
            [SwaggerOperation(Summary = "Cancela pagamento")]
            ([SwaggerParameter("Dados do pagamento")][FromBody] CancelaPagamentoRequest request, ICancelaPagamentoAdapter adapter) =>
            {
                return adapter.Cancelar(request);
            }).WithTags("Pagamentos");

            app.MapPost("pagamentos",
            [SwaggerOperation(Summary = "Gera novo pagamento")]
            ([SwaggerParameter("Dados do pagamento")][FromBody] GeraPagamentoRequest request, IGeraPagamentoAdapter adapter) =>
            {
                return adapter.Gerar(request);
            }).WithTags("Pagamentos");

            app.MapGet("pagamentos/pedidos/{pedidoId:Guid}",
            [SwaggerOperation(Summary = "Obtém o status do pagamento do pedido")]
            ([SwaggerParameter("Id do pedido")] Guid pedidoId, IObtemStatusPagamentoPedidoAdapter adapter) =>
            {
                return adapter.ObterStatusPagamento(pedidoId);
            }).WithTags("Pagamentos");

            app.MapPut("pagamentos/efetivacoes",
            [SwaggerOperation(Summary = "Efetiva pagamento pendente")]
            ([SwaggerParameter("Dados do pagamento")][FromBody] RealizaPagamentoRequest request, IRealizaPagamentoAdapter adapter) =>
            {
                return adapter.Realizar(request);
            }).WithTags("Pagamentos");

            #endregion

            #region [ Produtos ]

            app.MapPut("produtos/{id:guid}",
            [SwaggerOperation(Summary = "Altera produto")]
            ([SwaggerParameter("Id do produto")] Guid id, [FromBody] AlteraProdutoRequest request, IAlteraProdutoAdapter adapter) =>
            {
                return adapter.Edit(id, request);
            }).WithTags("Produtos");

            app.MapDelete("produtos/{id:guid}",
            [SwaggerOperation(Summary = "Inativa produto")]
            ([SwaggerParameter("Id do produto")] Guid id, IInativaProdutoAdapter adapter) =>
            {
                return adapter.Edit(id);
            }).WithTags("Produtos");

            app.MapPost("produtos",
            [SwaggerOperation(Summary = "Insere novo produto")]
            ([SwaggerParameter("Id do produto")][FromBody] NovoProdutoRequest request, INovoProdutoAdapter adapter) =>
            {
                return adapter.Inserir(request);
            }).WithTags("Produtos");

            app.MapGet("produtos/{id:guid}",
            [SwaggerOperation(Summary = "Obtém o produto")]
            ([SwaggerParameter("Id do produto")] Guid id, IObtemProdutoAdapter adapter) =>
            {
                return adapter.Get(id);
            }).WithTags("Produtos");

            app.MapGet("produtos/{categoria}",
            [SwaggerOperation(Summary = "Obtém o produto por categoria")]
            ([SwaggerParameter("Categoria do produto")] EnumCategoriaProduto categoria, IObtemProdutoPorCategoriaAdapter adapter) =>
            {
                return adapter.Get(categoria);
            }).WithTags("Produtos");

            app.MapGet("produtos/",
            [SwaggerOperation(Summary = "Obtém os produto")]
            (IObtemProdutosAdapter adapter) =>
            {
                return adapter.Get();
            }).WithTags("Produtos");

            #endregion
        }
    }
}
